/***************************************************************
     Turbo Prolog Toolbox
     (C) Copyright 1987 Borland International.
***************************************************************/
predicates
  virtual_text(vrow,vcol,row,col)  /* coordinates transformation */
  windowarea(row,col)		   /* the dimensions inside a window */
  sign(real,integer)	   	   /* -1 if negative, 0 if zero, 1 if positive*/

  screenmode(mode)		   /* return PROLOG screen mode */
  DOS_PROLOG(mode,mode)		   /* Table of corresponding screen modes */
  getcols(col)


clauses  
  virtual_text(VirRow,VirCol,R,C):-	/* virtual -> text coordinates */
	bound(VirRow),bound(VirCol),!,
/*	Cols=80,  CAN BE USED INSTED OF getcols TO INCREASE SPEED*/
  	getcols(Cols),
  	R=VirRow div 1280,
  	C=VirCol div (32000 div Cols).

  virtual_text(VirRow,VirCol,R,C):-	/* text -> virtual coordinates */
	bound(R),bound(C),
/*	Cols=80,  CAN BE USED INSTED OF getcols TO INCREASE SPEED*/
/*		  WHEN IN GRAPHICS MODE 2,4 and 5   ONLY.*/
	getcols(Cols),
  	VirRow=R * 1280,
  	VirCol=C * (32000 div Cols).

  windowarea(Hight,Width):-
  	makewindow(_,_,Frame,_,_,_,Rows,Cols),
  	sign(Frame,One),
	Hight=Rows-2*One,
	Width=Cols-2*One.

  sign(0,0):-!.
  sign(X,1):-X>0,!.
  sign(_,-1):-!.

  screenmode(Mode):-
  	bios($10,reg($0F00,0,0,0,0,0,0,0),reg(AX,_,_,_,_,_,_,_)),
  	DosMode=AX mod 256,
  	Dos_Prolog(DosMode,Mode).

  DOS_PROLOG(3,0).	/* text mode */
  DOS_PROLOG(4,1).	/* CGA 320 x 200 pixels, 2 colors */
  DOS_PROLOG(6,2).	/* CGA 640 x 200 pixels, 2 colors */
  DOS_PROLOG(11,3).	/* EGA 320 x 200 pixels, 16 colors */
  DOS_PROLOG(12,4).	/* EGA 640 x 200 pixels, 16 colors */
  DOS_PROLOG(13,5).	/* EGA 640 x 350 pixels, 16 colors */

  getcols(TotalColsOnScreen):-
  	bios($10,reg($0F00,0,0,0,0,0,0,0),reg(AX,_,_,_,_,_,_,_)),
  	TotalColsOnScreen=AX div 256.


  /******************************************************************

		format_string(Value,Notation,Field_Width)

  where the Value is written using either either d (decimal) notation
  or e (exponential) notation in a field defined by Field_Width.
  Decimal notation is (shown with Field_Width 5):
  	
  	12345
  	12.34
	-1.23

  Examples using exponential notation with Field_Width 6:

  	1.e+5
	-1e-1

  Negative numbers need a preceding minus, which takes up space for one
  of the decimal digits. When numbers in decimal notation can not fit
  the specified field width, the number is written using exponential
  notation.
  *********************************************************************/ 

predicates
    format_string(real,symbol,integer,string)
    normalize(real,real,integer)
    rightsubstring(integer,string,string)
    str_tal(string,real)
    signsize(real,integer)
    blanks(integer,string)

clauses
    format_string(Val,d,Field_Width,String):-
	normalize(Val,_,Potens),signsize(Val,SS),
	abs(Potens+1) + SS > Field_Width,!,
	format_string(Val,e,Field_Width,String).

    format_string(Val,d,Digits,Sres):-
	str_real(S,Val),!,
	rightsubstring(Digits,S,Sres).

    format_string(Val,e,Field_Width,Sres):-
	sign(Val,Sign),
	X=abs(Val),
	normalize(X,Xn,Exponent),
	X1=Sign*Xn,
	str_tal(S,X1),
	str_int(EString,Exponent),
	str_len(Estring,ESize),
	FirstWidth=Field_Width-Esize-1,
	rightsubstring(FirstWidth,S,Sf),
	concat(Sf,"e",Se),
	concat(Se,Estring,Sres),!.


    str_tal(S1,X):-
	str_int(S,X),!,
	concat(S,".0000",S1).
    str_tal(S,X):-
    	str_real(S,X).


    normalize(0,0.0,0):-!.
    normalize(X,X,0):-
    	1.0 <= X,  X < 10,!.
    normalize(X,Y,N):-
    	X >= 10,!,  X1=X/10, normalize(X1,Y,N1), N=N1+1.
    normalize(X,Y,N):-
    	X < 0,!,  X1=abs(X), normalize(X1,Y,N).
    normalize(X,Y,N):-
    	X < 1,!,  X1=X*10, normalize(X1,Y,N1), N=N1-1.

     signsize(X,1):-X<0,!.
     signsize(_,0).

     rightsubstring(NoOfChars,Si,So):-
     	str_len(Si,L),
     	L<NoOfChars,!,
     	PreceedingBlanks=NoOfChars-L,
     	blanks(PreceedingBlanks,B),concat(B,Si,So).
     rightsubstring(NoOfChars,Si,So):-
        frontstr(NoOfChars,Si,So,_).
     
     blanks(1," "):-!.
     blanks(N,S):-
     	N1=N-1,blanks(N1,S1),concat(" ",S1,S).


predicates
	gwrite(row,col,string,color,integer)
clauses
	gwrite(R,C,S,Color,0):-
		
		cursor(R,C),attribute(Color),write(S).
	gwrite(_,_,"",_,1):-!.
	gwrite(R,C,S,Color,1):-
		cursor(R,C),attribute(Color),
		frontchar(S,Ch,S1),write(Ch),
		R1=R+1,
		gwrite(R1,C,S1,Color,1).
