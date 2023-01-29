/***************************************************************
     Turbo Prolog Toolbox
     (C) Copyright 1987 Borland International.
***************************************************************/

Global predicates
Determ openRS232(Integer, Integer, Integer,
  	    Integer, Integer, Integer, Integer, Integer)
  	    - (i,i,i,i,i,i,i,i) language c
/*
Determ openRS232(PortNo, InputBufSize, OutputBufSize,
  	    BaudRate, Parity, WordLength, StopBits, Protocol) language c

  PortNo		= 1	Means COM1 communication port located
  				at I/O address $03F8
  			= 2	Means COM2 communication port located
  				at I/O address $02F8
  Range for InputBufSize  1-31767  Number of bytes reserved for the
  				   input buffer
  Range for OutputBufSize 1-31767  Number of bytes reserved for the
  				   output buffer
  BaudRate		= 0	Means  110 Baud
  			= 1	Means  150 Baud
  			= 2	Means  300 Baud
  			= 3	Means  600 Baud
  			= 4	Means 1200 Baud
  			= 5	Means 2400 Baud
  			= 6	Means 4800 Baud
  			= 7	Means 9600 Baud
  Parity		= 0	Means no parity
  			= 1	Means odd parity
  			= 2	Means even parity
  WordLength		= 0	Means 5 data bits
  			= 1	Means 6 data bits
  			= 2	Means 7 data bits
  			= 3	Means 8 data bits
  StopBits		= 0	Means 1 Stop bit
  			= 1	Means 2 Stop bits
  Protocol		= 0	Means pure communication without Xon/Xoff
  				and RTS/CTS
  			= 1	Means communication with Xon/Xoff but
  				without RTS/CTS /* Preferred mode */
  			= 2	Means communication with RTS/CTS but
  				without Xon/Xoff. RTS will always be
  				in the high state.
  			= 3	Means communication with both Xon/Xoff
  				and RTS/CTS. RTS will always be in the
  				high state.

  The protocol must always follow the DTR/DSR signals which means a remote
  device has to keep Pin 6 (DSR) high when it is ready to receive/transmit
  data.
  */

Determ closeRS232(Integer) - (i) language c

/*
  closeRS232(PortNo)
    PortNo		= 1	Means COM1 communication port located
  				at I/O address $03F8
  			= 2	Means COM2 communication port located
  				at I/O address $02F8
    It is very important to close an open communication port
    before a program terminates because this predicate resets
    interrupt vectors and frees allocated buffers
  */




Determ Txch_RS232(Integer,Char) - (i,i) language c
  /*
    Txch_RS232(PortNo,Char)
    PortNo		= 1	Means COM1 communication port located
  				at I/O address $03F8
  			= 2	Means COM2 communication port located
  				at I/O address $02F8
    Char		Character to be transmitted via the COM port.
  */

Determ queuesize_RS232(Integer,Integer,Integer) - (i,o,o) language c
  /*
    queuesize_RS232(PortNo,SizeOfInputQueue,SizeOfOutputQueue)
    PortNo		= 1	Means COM1 communication port located
  				at I/O address $03F8
  			= 2	Means COM2 communication port located
  				at I/O address $02F8
    SizeOfInputQueue		Number of characters in the input queue.
    SizeOfOutputQueue		Number of characters in the output queue.
  */

Determ DelOutbuf_RS232(Integer) - (i) language c
 
  /*
    DelOutbuf_RS232(PortNo)
    PortNo		= 1	Means COM1 communication port located
  				at I/O address $03F8
  			= 2	Means COM2 communication port located
  				at I/O address $02F8
    This predicate flushes the output buffer
  */

Determ Rxch_RS232(Integer,Char) - (i,o) language c

  /*
    Rxch_RS232(PortNo,Char)
    PortNo		= 1	Means COM1 communication port located
  				at I/O address $03F8
  			= 2	Means COM2 communication port located
  				at I/O address $02F8
    Char		Char transferred from the input queue.
  */

Determ DelInbuf_RS232(Integer) - (i) language c
  /*
    DelInbuf_RS232(PortNo)
    PortNo		= 1	Means COM1 communication port located
  				at I/O address $03F8
  			= 2	Means COM2 communication port located
  				at I/O address $02F8
    This predicate flushes the input buffer
 */


Determ status_RS232(Integer,Integer) - (i,o) language c
  /*
    status_RS232(PortNo,Status)
    PortNo		= 1	Means COM1 communication port located
  				at I/O address $03F8
  			= 2	Means COM2 communication port located
  				at I/O address $02F8
    Status		= 1	Input characters have been lost because
    				the input queue was full when characters
    				were received.
    			= 2	Parity error detected
    			= 4	Overrun detected
    			= 8	Framing error detected
    			= 16	Break signal detected
    			= 32	An Xoff has been received
    			= 64	An Xon has been received
    			= 128	An Xoff has been transmitted
    			= 256	An Xon has been transmitted
    			= 512	Input buffer is empty (when trying to read)
    			= 1024	Output buffer is full (when trying to write)
    The Status value is a bit mask and should be checked after
    each transmission.
  */


/*****************************************************************
	SPECIFIC MODEM PREDICATES -- HAYES COMPATIBLE
	Reference Hayes Smartmodem Owner's manual

     It is important to always initialize the modem port with
     OpenRS232 before using the modem predicates
******************************************************************/


Determ SetModemMode(Integer, String, Char, Integer) - (i,i,i,i) language c
  /*
    SetModemMode(PortNo,CommandAttention,CommandTerminator, BreakTime)
    PortNo		= 1	Means COM1 communication port located
  				at I/O address $03F8
  			= 2	Means COM2 communication port located
  				at I/O address $02F8
    CommandAttention		Normally "AT"
    CommandTerminator		Normally '\013'  (CR)
    BreakTime			Means the length of time a break signal
    				will be placed on the line.
    				Range 0-32676 (0-327 sec).
    				Normal values are 10-25.
  
    A Modem can be initialized several times during a connection.
  */
  



Determ TxStr_modem(String,Integer) - (i,o) language c
  /*
    TxStr_Modem(CommandStr, NoofCharTransmitted)
    CommandStr			Command to the modem
    NoofCharTransmitted		Sometimes
    				it is necessary to retransmit a part or
    				the whole command.
  */
  



Determ RxStr_modem(String) - (o) language c
  /*
    RxStr_modem(Message)
    Message			Response from the modem.
  */
  



Determ SendBreak_RS232  language c  
  /*
    Send a break signal
  */


  
Determ Ticks(Integer) - (i)
  /*
    Ticks (0-32767) causes the program to wait for a specified period
    of time, measured in hundredths of seconds.
  */
