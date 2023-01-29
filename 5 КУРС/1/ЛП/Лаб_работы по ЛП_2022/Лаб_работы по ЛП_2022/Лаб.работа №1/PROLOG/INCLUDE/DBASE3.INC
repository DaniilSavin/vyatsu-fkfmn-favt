/************************************************************

     Turbo Prolog Toolbox
     (C) Copyright 1987 Borland International.

	Access a dBASE III(TM) (V1.1) compatible file from Prolog

*************************************************************/

Domains
/*************************************************************
	Prolog representation of the data base
*************************************************************/

  Dbase3RecL	= Dbase3Rec*		/* A database is a number of records */
  Dbase3Rec	= Dbase3Elem*		/* A record is a number of fields */
  Dbase3Elem	= char(String);		/* Characters */
  		  real(Real);		/* 64-bit IEEE floating point */
  		  logical(Bool);	/* Logical */
  		  memo(String);		/* 10 digits rep. a .DBT block no */
  		  date(String)		/* format YYYY MM DD */
  
  Bool		= Char			/* Y y N n T t F f or Space */
  
  FldDescL	= FldDesc*		/* description for each field */
  FldDesc	= flddesc(Dbase3Type,Integer)
  Dbase3Type	= ch;r;l;m;d
  
  FldNameL	= String*

PREDICATES
  /* Read predicates */
  Init_Dbase3(Real,FldNameL,FldDescL)
              % Количество записей (o)
		   % Список имен полей (o)	  
			    % Стpуктуpа полей одной записи (o)
			
  rd_dbase3_DbaseHeader(Real) 			
                        % Количество записей (o)

  rd_dbase3_fieldDescL(FldNameL,FldDescL)       
                       % Список имен полей (o)
                                % Стpуктуpа полей одной записи (o)

  rd_dbase3File(Real,File,FldDescL,Dbase3RecL)	
                % Количество записей (i)
                     % Файл типа memo (i)
                          % Стpуктуpа полей одной записи (o)
				   % Список записей (o)
 
  rd_dbase3_DataRec(File,FldDescL,dBase3Rec)
                    % Файл типа Dbf
                         % Стpуктуpа полей одной записи
                                  % Запись с текущего указателя
                    
  rd_dbase3_elem(File,FldDesc,dBase3Elem)

  conv_FldType(Char,dBASE3Type)

  /* Read a single record */
  rd_dbase3_DataRec1(Real,Real,File,FldDescL,dBase3Rec)
  rd_dbase3Rec(Real,File,FldDescL,dBase3Rec)

CLAUSES
  Init_Dbase3(TotRecs,FldNameL,FldDescL):-
	rd_dbase3_DbaseHeader(TotRecs),
	rd_dbase3_fieldDescL(FldNameL,FldDescL).


/*************************************************************
	Read dBASE III(TM) header
*************************************************************/

  rd_dbase3_DbaseHeader(TotRecs):-
	ignore(4),	    /* ID & Last update & record size */
	read_long(TotRecs), /* 32-bit number */
	ignore(24).	    /* Header length, Record length & Reserved */


/*************************************************************
	Read Field descriptors
*************************************************************/

  rd_dbase3_fieldDescL([FldName|FldNameL],[fldDesc(Type,Len)|FldDescL]):-
	readchar(Ch), Ch<>'\013',!, /* CR means final array field */
	readnz(Name),
	str_len(Name,Size),
	Ig = 9 - Size,
	ignore(Ig),
    	frontchar(FldName,Ch,Name),
	readchar(T), 
 	conv_FldType(T,Type),
	ignore(4),	/* data address */
	readchar(L), char_int(L,Len),
	ignore(15),	/* decimal count & Reserved */
	rd_dbase3_FieldDescL(FldNameL,FldDescL).

  rd_dbase3_FieldDescL([],[]):-readchar(_).

  conv_FldType('C',ch):-!.
  conv_FldType('N',r):-!.
  conv_FldType('L',l):-!.
  conv_FldType('M',m):-!.
  conv_FldType('D',d):-!.

  
/*************************************************************
	Read Data Records
*************************************************************/

  rd_dbase3File(0,_,_,[]):-!.
  rd_dbase3File(N,MFP,FldDescL,[Rec|RecL]):-
	rd_dbase3_DataRec1(N,N2,MFP,FldDescL,Rec),
	rd_dbase3File(N2,MFP,FldDescL,RecL).

  rd_dbase3_datarec1(Ni,No,MFP,FldDescL,Rec):-
	readchar(NotDel), NotDel=' ',!,	No=Ni-1,rd_dbase3_DataRec(MFP,FldDescL,Rec).
  rd_dbase3_datarec1(Ni,No,MFP,FldDescL,Rec):-
	Ni2=Ni-1, rd_dbase3_datarec(MFP,FldDescL,_),
	rd_dbase3_DataRec1(Ni2,No,MFP,FldDescL,Rec).

  rd_dbase3_DataRec(_,[],[]):-!.
  rd_dbase3_DataRec(MFP,[FldDesc|FldDescL],[Elem|ElemL]):-
	rd_dbase3_elem(MFP,FldDesc,Elem), rd_dbase3_DataRec(MFP,FldDescL,ElemL).

  rd_dbase3_elem(_,fldDesc(ch,Len),char(Str)):-!,read_strArr(Len,Str).
  rd_dbase3_elem(_,fldDesc(l,Len),logical(Char)):-!,
	readchar(Char), ToSkip=Len-1, ignore(ToSkip).
  rd_dbase3_elem(_,fldDesc(r,Len),real(Real)):-!,
	read_strArr(Len,Str), str_real(Str,Real).
  rd_dbase3_elem(MFP,fldDesc(m,Len),memo(Memo)):-!,
	read_strArr(Len,BlkNo),
	str_int(BlkNo,P), Pos=P*512,
	readdevice(FP), readdevice(MFP),
	filepos(MFP,Pos,0), read_strCtrlZ(Memo),
	readdevice(FP).
  rd_dbase3_elem(_,fldDesc(d,Len),date(Date)):-!,read_strArr(Len,Date).


/*************************************************************
	Read data records sequentially
*************************************************************/

  rd_dbase3Rec(0,_,_,_):-!,fail.
  rd_dbase3Rec(N,MFP,FldDescL,Rec):-rd_dbase3_datarec1(N,_,MFP,FldDescL,Rec).
  rd_dbase3Rec(N,MFP,FldDescL,Rec):-N2=N-1, rd_dbase3Rec(N2,MFP,FldDescL,Rec).

