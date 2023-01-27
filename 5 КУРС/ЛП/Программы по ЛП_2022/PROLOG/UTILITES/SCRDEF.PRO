/****************************************************************

     Turbo Prolog Toolbox
     (C) Copyright 1987 Borland International.

	   Utility Program for screen layout
****************************************************************/
code=2700
include "e:\\prolog\\include\\tdoms.inc"

DOMAINS
  FNAME=SYMBOL
  FNAMELIST = FNAME*
  TYPE = int(); str(); real()
  TYPELIST = TYPE*
  VALUE	= int(INTEGER); str(STRING); real(REAL)
  VALUELIST = VALUE*
  FILE	= textfile

DATABASE
  /* Screen definition */
  field(FNAME,TYPE,ROW,COL,LEN)
  txtfield(ROW,COL,LEN,STRING)
  windowsize(ROW,COL)

  /* temporary fields under sort */
  tempfield(FNAME,TYPE,ROW,COL,LEN),
  tempminfield(FNAME,TYPE,ROW,COL,LEN),

  /* Global status */
  windowstart(ROW,COL)
  mycursord(ROW,COL)
  insmode

  /* Definition of the known types */
  types(INTEGER,TYPE,STRING)
  
  filename(STRING)
  continue

  dblineno(INTEGER)

  lineinpstate(STRING,COL)
  lineinpflag

  drawmode(KEY)


PREDICATES
  repeat
  writescr
 
  /* SCREEN DRIVER */
  scrdef
  endscrdef(KEY)
  scr(KEY)
  createwindow

  myfield_attr(ROW,COL,LEN,INTEGER)
  myfield_str(ROW,COL,LEN,STRING)
  wrscr(ROW,ROW,COL,COL)

  mycursor(ROW,COL)
  showcursor
  mkheader
  showoverwrite
  juststart(ROW,COL,ROW,COL,ROW,COL)
  newstart(ROW,COL)

  insline
  delline
  movetxtfield(ROW,ROW,COL,LEN,STRING)
  movefield(ROW,FNAME,TYPE,ROW,COL,LEN)
  delfield
  deffield
  chkfieldname(FNAME)
  gettype(TYPE)
  deffield2(COL,KEY)

include "e:\\prolog\\include\\tpreds.inc"
include "e:\\prolog\\include\\menu.inc"
include "e:\\prolog\\include\\status.inc"
include "e:\\prolog\\include\\lineinp.inc"
include "e:\\prolog\\include\\filename.inc"


CLAUSES
  repeat.
  repeat:-repeat.

 /***********************************************************************/
 /*		Initializing the database				*/
 /***********************************************************************/

  windowsize(20,77).
  windowstart(0,0).
  mycursord(0,0).
  insmode.

  /* The known types */
  types(1,int,"integer").
  types(2,real,"real").
  types(3,str,"string").


 /***********************************************************************/
 /*		Helping predicates					*/
 /***********************************************************************/

CLAUSES
  endscrdef(fkey(10)):-!.
  endscrdef(esc).

 /***********************************************************************/
 /*		create the window					*/
 /***********************************************************************/

  createwindow:-
	windowsize(R,C),!,
	R1=R+3, C1=C+3,
	makewindow(1,31,112,"Editing screen layout",1,0,R1,C1).

 
 /***********************************************************************/
 /*		SCREEN DRIVER		   				*/
 /* The screen definition/input is repeated until F10 is pressed	*/
 /***********************************************************************/

  scrdef:-
	shiftwindow(OLD),
	makewindow(85,112,0,"",0,0,1,80),
	makestatus(112," F1:Hlp F3:Del fld F4:Def fld F5:Box F7:Del line F8:Ins line F6:Resize F10:End"),
	createwindow,
	refreshstatus,
	mkheader,
	mycursor(0,0),
	repeat,
	showcursor,
	writescr,
	readkey(KEY),scr(KEY),endscrdef(KEY),!,
	removestatus,
	removewindow,
	removewindow,
	shiftwindow(OLD).


 /***********************************************************************/
 /*		scr		   					*/
 /***********************************************************************/

PREDICATES
  draw(KEY)
  getch(ROW,COL,CHAR,KEY)
  getdirch(CHAR,KEY)
  drawloop
  decide(KEY,CHAR,INTEGER)
  decidecorner(INTEGER,INTEGER,INTEGER,INTEGER,CHAR)
  fix(ROW,COL,KEY)
  tryfix(ROW,COL,KEY)

CLAUSES
  drawloop:-retract(insmode),fail.
  drawloop:-
	makestatus(112," Draw boxes       F10,Esc: End         Arrows: draw"),
	repeat,
	showcursor,
	readkey(KEY),
	draw(KEY),
	endscrdef(KEY),!,
	removestatus.
  
  draw(right):-
	mycursor(R,C),
	scr(right),
	C2=C+1,
	tryfix(R,C,right),
	mycursor(R,C2).
  draw(left):-
	mycursor(R,C),
	scr(left),
	C1=C-1,
	tryfix(R,C,left),
	C1>=0,
	mycursor(R,C1).
  draw(up):-
	mycursor(R,C),
	scr(up),
	R1=R-1,
	tryfix(R,C,up),
	R1>=0,
	mycursor(R1,C).
  draw(down):-
	mycursor(R,C),
	scr(down),
	R2=R+1,
	tryfix(R,C,down),
	mycursor(R2,C).
  draw(esc).
  draw(fkey(10)).

  getch(ROW,COL,CH,KEY):-
	mycursor(R,C),ROW=R,COL=C,
	getdirch(CH,KEY),!.
  getch(ROW,COL,CH,_):-
	txtfield(ROW,C,LEN,TXT),
	C<=COL, C+LEN>COL,!,
	DROP=COL-C,
	frontstr(DROP,TXT,_,TXT1),
	frontchar(TXT1,CH,_).
  getch(_,_,' ',_).

  getdirch('Ä',left).
  getdirch('Ä',right).
  getdirch('³',up).
  getdirch('³',down).

  tryfix(R,C,KEY):-fix(R,C,KEY),!.
  tryfix(_,_,_).

  fix(ROW,COL,KEY):-
	R1=ROW-1, R2=ROW+1,
	C1=COL-1, C2=COL+1,
	getch(ROW,COL,CH,KEY),
	getch(ROW,C1,CH1,KEY), decide(left,CH1,LEFT),
	getch(R1,COL,CH2,KEY), decide(up,CH2,UP),
	getch(R2,COL,CH3,KEY), decide(down,CH3,DOWN),
	getch(ROW,C2,CH4,KEY), decide(right,CH4,RIGHT),
	decidecorner(UP,DOWN,LEFT,RIGHT,CHOICE),
	CHOICE><CH,
	mycursor(ROW,COL),
	scr(char(CHOICE)).

  decidecorner(1,1,1,1,'Å').
  decidecorner(1,1,1,0,'´').
  decidecorner(1,1,0,1,'Ã').
  decidecorner(1,0,1,1,'Á').
  decidecorner(0,1,1,1,'Â').
  decidecorner(0,1,0,1,'Ú').
  decidecorner(0,1,1,0,'¿').
  decidecorner(1,0,1,0,'Ù').
  decidecorner(1,0,0,1,'À').
  decidecorner(0,0,0,1,'Ä').
  decidecorner(0,0,1,0,'Ä').
  decidecorner(0,0,1,1,'Ä').
  decidecorner(1,0,0,0,'³').
  decidecorner(0,1,0,0,'³').
  decidecorner(1,1,0,0,'³').

  decide(_,' ',0):-!.
  decide(_,'Å',1):-!.
  decide(DIR,'´',1):-not(DIR=left),!.
  decide(DIR,'Ã',1):-not(DIR=right),!.
  decide(DIR,'Á',1):-not(DIR=up),!.
  decide(DIR,'Â',1):-not(DIR=down),!.
  decide(DIR,'Ú',1):-DIR=left,!;DIR=up,!.
  decide(DIR,'¿',1):-DIR=right,!;DIR=up,!.
  decide(DIR,'À',1):-DIR=left,!;DIR=down,!.
  decide(DIR,'Ù',1):-DIR=right,!;DIR=down,!.
  decide(DIR,'Ä',1):-DIR=left,!;DIR=right,!.
  decide(DIR,'³',1):-DIR=up,!;DIR=down,!.
  decide(_,_,0).


PREDICATES
  hndstr(ROW,COL,LEN,STRING)

CLAUSES
  hndstr(ROW,COL,LEN,TXT):-
	txtfield(ROW,C,LEN1,TXT1),
	C=COL+LEN,!,
	retract(txtfield(ROW,C,_,_)),!,
	concat(TXT,TXT1,TXT2),LEN2=LEN1+LEN,
	assert(txtfield(ROW,COL,LEN2,TXT2)).

  hndstr(ROW,COL,LEN,TXT):-
	assert(txtfield(ROW,COL,LEN,TXT)).

  /* Insert a new character in a field */
  scr(char(T)):-
	mycursor(R,C),
	txtfield(ROW,COL,LEN,TXT),
	ROW=R, COL<=C, C<=COL+LEN,!,
	POS=C-COL,
	lin(char(T),POS,TXT,TXT1),
	retract(txtfield(ROW,COL,_,_)),!,
	str_len(TXT1,LEN1),
	hndstr(ROW,COL,LEN1,TXT1),
	str_char(TSTR,T),
	myfield_str(R,C,1,TSTR),
	scr(right).

  /* Make a new text field */
  scr(char(T)):-
	mycursor(ROW,COL), str_char(TXT,T),
	hndstr(ROW,COL,1,TXT),
	myfield_str(ROW,COL,1,TXT),
	scr(right).

  /* Delete character under cursor */
  scr(del):-
	mycursor(R,C),
	txtfield(ROW,COL,LEN,TXT),
	ROW=R, COL<=C, C<COL+LEN,!,
	POS=C-COL,
	lin(del,POS,TXT,TXT1),
	str_len(TXT1,LEN1),
	CC=COL+LEN1,
	myfield_str(ROW,CC,1," "),
	retract(txtfield(ROW,COL,LEN,TXT)),!,TXT1><"",
	assert(txtfield(ROW,COL,LEN1,TXT1)),
	myfield_str(ROW,COL,LEN1,TXT1).

  /* Delete character before cursor and move cursor to the left */
  scr(bdel):-
	mycursor(R,C),
	txtfield(ROW,COL,LEN,TXT),
	ROW=R, COL<C, C<=COL+LEN,!,
	POS=C-COL-1,
	lin(del,POS,TXT,TXT1),
	str_len(TXT1,LEN1),
	CC=COL+LEN1,
	myfield_str(ROW,CC,1," "),
	scr(left),
	retract(txtfield(ROW,COL,LEN,TXT)),!, TXT1><"",
	assert(txtfield(ROW,COL,LEN1,TXT1)),
	myfield_str(ROW,COL,LEN1,TXT1).

  scr(bdel):-scr(left).

  /* Goto next field on screen */
  scr(cr):-mycursor(R,_),R1=R+1,windowstart(_,C),!,mycursor(R1,C).

  /* Change between insertmode and overwritemode */
  scr(ins):-changemode,showoverwrite.

  /* escape */
  scr( esc ).

  /* F10: end of definition */
  scr( fkey(10) ).


  /* crtlpgup: goto 0,0 */
  scr(ctrlpgup):-mycursor(0,0).

  /* crtlhome: goto start of window */
  scr(ctrlhome):-
	windowstart(R,C),!,
	mycursor(R,C).


  /* home: goto start of actual line */
  scr(home):-
	windowstart(_,C),!,
	mycursor(R1,_),
	mycursor(R1,C).


  /* end: goto end of actual line */
  scr(end):-
	windowstart(_,C), windowsize(_,CS),!,
	mycursor(R1,_),
	COL=C+CS,
	mycursor(R1,COL).


  /* ctrlend: goto end of screen */
  scr(ctrlend):-
	windowstart(R,C), windowsize(RS,CS),!,
	ROW=R+RS,COL=C+CS,
	mycursor(ROW,COL).


  /* cursor right */
  scr(right):-
	mycursor(ROW,COL),
	COL1=COL+1,
	mycursor(ROW,COL1).


  /* cursor ctrlright */
  scr(ctrlright):-
	mycursor(ROW,COL),
	COL1=COL+5,
	mycursor(ROW,COL1).


  /* cursor left */
  scr(left):-
	mycursor(ROW,COL),
	COL>0,
	COL1=COL-1,
	mycursor(ROW,COL1).


  /* cursor ctrlleft */
  scr(ctrlleft):-
	mycursor(ROW,COL),
	COL1=COL-5, COL1>=0,!,
	mycursor(ROW,COL1).


  /* cursor ctrlleft */
  scr(ctrlleft):-
	mycursor(ROW,COL),
	COL1=COL-5, COL1<0,
	mycursor(ROW,0).


  /* cursor up */
  scr(up):-
	mycursor(ROW,COL),
	ROW>0,
	ROW1=ROW-1,
	mycursor(ROW1,COL).


  /* cursor pgup */
  scr(pgup):-
	mycursor(ROW,COL),
	windowsize(RS,_),!,
	ROW1=ROW-RS,
	max(ROW1,0,ROW2),
	mycursor(ROW2,COL).


  /* cursor down */
  scr(down):-
	mycursor(ROW,COL),
	ROW1=ROW+1,
	mycursor(ROW1,COL).


  /* cursor pgdown */
  scr(pgdn):-
	mycursor(ROW,COL),
	windowsize(RS,_),!,
	ROW1=ROW+RS,
	mycursor(ROW1,COL).

  /* Define window size */
  scr(fkey(6)):-
	resizewindow,
	makewindow(_,_,_,_,_,_,ROWS,COLS),
	RR=ROWS-3, CC=COLS-3,
	retract(windowsize(_,_)),!,assert(windowsize(RR,CC)),
	refreshstatus,
	mkheader,
	mycursor(R,C),mycursor(R,C).

  /* Help information */
  scr(fkey(1)):-
	alexwindow(9,47,31,"HELP",15,60),
	file_str("scrdef.hlp",X),
	display(X),
	mkheader,
	fail.
  scr(fkey(1)):-removewindow,refreshstatus.


/* ............... Start to define screen ................................ */

  /* Delete field */
  scr(fkey(3)):-delfield.

  /* Define field */
  scr(fkey(4)):-deffield.

  /* Delete line */
  scr(fkey(7)):-delline,cursor(R,C),clearwindow,cursor(R,C).

  /* Insert line */
  scr(fkey(8)):-insline,cursor(R,C),clearwindow,cursor(R,C).

  scr(fkey(5)):-drawloop.




 /***********************************************************************/
 /*		insert line		    				*/
 /***********************************************************************/

  insline:-
	mycursor(ROW,_),
	field(FN,TY,R,C,L),
	R>=ROW,
	movefield(1,FN,TY,R,C,L),
	fail.
  insline:-
	mycursor(ROW,_),
	txtfield(R,C,L,TXT),
	R>=ROW,
	movetxtfield(1,R,C,L,TXT),
	fail.
  insline:-mycursor(RR,CC),mycursor(RR,CC).

  delline:-
	mycursor(ROW,_),
	retract(field(_,_,ROW,_,_)),
	fail.
  delline:-
	mycursor(ROW,_),
	retract(txtfield(ROW,_,_,_)),
	fail.
  delline:-
	mycursor(ROW,_),
	field(FN,TY,R,C,L),
	R>=ROW,
	movefield(-1,FN,TY,R,C,L),
	fail.
  delline:-
	mycursor(ROW,_),
	txtfield(R,C,L,TXT),
	R>ROW,
	movetxtfield(-1,R,C,L,TXT),
	fail.
  delline:-mycursor(RR,CC),mycursor(RR,CC).

  movetxtfield(ROWS,R,C,L,TXT):-
	R1=R+ROWS,
	retract(txtfield(R,C,L,TXT)),!,
	asserta(txtfield(R1,C,L,TXT)).

  movefield(ROWS,FN,TY,R,C,L):-
	R1=R+ROWS,
	retract(field(FN,TY,R,C,L)),!,
	asserta(field(FN,TY,R1,C,L)).



 /***********************************************************************/
 /*	DEFINE NEW FIELD		    				*/
 /***********************************************************************/

  deffield:-
  	mycursor(MYROW,MYCOL),
	cursor(ROW,COL1),
	lineinput(ROW,COL1,30,23,23,"Field name: ","",TXT),TXT><"",FNAME=TXT,
	chkfieldname(FNAME),
	gettype(TYPE),
	myfield_attr(MYROW,MYCOL,1,112),
	readkey(KEY),
	deffield2(MYCOL,KEY),
	mycursor(_,MYCOL2),
	LEN=MYCOL2-MYCOL+1,
	assert(field(FNAME,TYPE,MYROW,MYCOL,LEN)).

  deffield2(_,cr):-!.
  deffield2(CMIN,esc):-!,
	mycursor(ROW,COL),
	LEN=COL-CMIN+1,
	myfield_attr(ROW,CMIN,LEN,66),
	fail.
  deffield2(CMIN,right):-!,
	mycursor(ROW,COL),
	COL1=COL+1,
	mycursor(ROW,COL1),
	myfield_attr(ROW,COL1,1,112),
	showcursor,
	readkey(KEY),
	deffield2(CMIN,KEY).
  deffield2(CMIN,left):-
	mycursor(ROW,COL), COL>CMIN,!,
	COL1=COL-1,
	mycursor(ROW,COL1),
	myfield_attr(ROW,COL,1,66),
	showcursor,
	readkey(KEY),
	deffield2(CMIN,KEY).
  deffield2(CMIN,_):-
	readkey(KEY),
	deffield2(CMIN,KEY).

  chkfieldname(FNAME):-
	field(FNAME,_,_,_,_),!,
	makewindow(6,23,66,"ERROR",5,5,4,30),
	write("Field name already exist"),
	readchar(_),
	removewindow,fail.
  chkfieldname(_).


  gettype(TYPE):-
	cursor(ROW,COL),
	findall(X,types(_,_,X),LIST),
	menu(ROW,COL,23,23,LIST,"Select type",0,CH),
	types(CH,TYPE,_),!.


 /************************************************************************/
 /*		DELETE FIELD		   				 */
 /************************************************************************/

  delfield:-
	mycursor(R,C),
	field(FNAME,_,ROW,COL,LEN),
	ROW=R, COL<=C, C<COL+LEN,
	myfield_attr(ROW,COL,LEN,66),
	myfield_str(ROW,COL,LEN,""),
	retract(field(FNAME,_,ROW,COL,_)),
	fail.

  delfield:-
	mycursor(R,C),
	txtfield(ROW,COL,LEN,_),
	ROW=R, COL<=C, C<COL+LEN,
	retract(txtfield(ROW,COL,_,_)),
	myfield_str(ROW,COL,LEN,""),
	fail.

/* ................. End define screen ................................... */



 /************************************************************************/
 /*		 MYCURSOR		   				 */
 /************************************************************************/

  mycursor(R,C):-free(R),free(C),mycursord(R,C),!.

  mycursor(R,C):-bound(R),bound(C),
	 windowstart(RR,CC),
	 R>=RR, C>=CC,
	 windowsize(RS,CS),
	 R<=RR+RS, C<=CC+CS,!,
	 retract(mycursord(_,_)),!,
	 assert(mycursord(R,C)),
	 R1=R-RR, C1=C-CC,
	 cursor(R1,C1).

  mycursor(R,C):-bound(R),bound(C),
	 windowstart(RR,CC),
	 windowsize(RS,CS),!,
	 juststart(R,C,RR,CC,RS,CS),
	 mycursor(R,C).

  /* juststart( ACTCURSOR, WINDSTART, WINDSIZE ) */
  juststart(R,_,RR,CC,_,_):-R<RR,!,newstart(R,CC).
  juststart(_,C,RR,CC,_,_):-C<CC,!,newstart(RR,C).
  juststart(R,_,RR,CC,RS,_):-R>RR+RS,!,R1=R-RS,newstart(R1,CC).
  juststart(_,C,RR,CC,_,CS):-C>CC+CS,!,C1=C-CS,newstart(RR,C1).

 PREDICATES
  check_update(ROW,ROW,COL,COL)

CLAUSES

  newstart(R,C):-retract(windowstart(OLDR,OLDC)),!,
  		assert(windowstart(R,C)),
  		SCROLLROW=R-OLDR,SCROLLCOL=C-OLDC,
  		scroll(SCROLLROW,SCROLLCOL),
  		check_update(R,SCROLLROW,C,SCROLLCOL).

  check_update(R,ROWS,C,0):-
		ROWS>0,!,
  		windowsize(NOOFROWS,NOOFCOLS),!,
  		ENDROW=R+NOOFROWS,STARTROW=ENDROW-ROWS+1,
  		ENDCOL=C+NOOFCOLS,
  		wrscr(STARTROW,ENDROW,C,ENDCOL).
  check_update(R,ROWS,C,0):-
		ROWS<0,!,
  		windowsize(_,NOOFCOLS),!,
  		STARTROW=R, ENDROW=STARTROW-ROWS-1,
  		ENDCOL=C+NOOFCOLS,
  		wrscr(STARTROW,ENDROW,C,ENDCOL).
  check_update(R,0,C,COLS):-
		COLS>0,!,
  		windowsize(NOOFROWS,NOOFCOLS),!,
  		ENDROW=R+NOOFROWS, STARTROW=R,
  		ENDCOL=C+NOOFCOLS, STARTCOL=ENDCOL-COLS,
  		wrscr(STARTROW,ENDROW,STARTCOL,ENDCOL).
  check_update(R,0,C,COLS):-
		COLS<0,!,
  		windowsize(NOOFROWS,_),!,
  		ENDROW=R+NOOFROWS, STARTROW=R,
  		ENDCOL=C, STARTCOL=C+COLS,
  		wrscr(STARTROW,ENDROW,STARTCOL,ENDCOL).
  check_update(_,_,_,_).

 /***********************************************************************/
 /*	Predicates maintaining the top messages line	    		*/
 /***********************************************************************/

  mkheader:-!,
	shiftwindow(OLD),
	gotowindow(85),
	field_str(0,0,30,"ROW:      COL:"),
	showoverwrite, showcursor,
	gotowindow(OLD).

PREDICATES
  get_overwritestatus(STRING)
  showfield
  show_str(COL,LEN,STRING)

CLAUSES
  get_overwritestatus("insert"):-insmode,!.
  get_overwritestatus("overwrite").

  show_str(C,L,STR):-
	C<80,!,
	MAXL=80-C,
	min(L,MAXL,LL),
	field_str(0,C,LL,STR).
  show_str(_,_,_).

  showoverwrite:-
	shiftwindow(OLD),
	gotowindow(85),
	get_overwritestatus(OV),
	show_str(20,9,OV),
	gotowindow(OLD).

  showfield:-keypressed,!.
  showfield:-
	mycursor(R,C),
	field(FNAME,TYP,ROW,COL,LEN),
	ROW=R, COL<=C, C<COL+LEN,
	types(_,TYP,TYPE),!,
	show_str(30,8,TYPE),
	STR=FNAME, show_str(38,42,STR).
  showfield:-keypressed,!.
  showfield:-
	mycursor(R,C),
	txtfield(ROW,COL,LEN,TXT),
	ROW=R, COL<=C, C<=COL+LEN,!,
	show_str(30,1,"\""),
	show_str(31,49,TXT),
	str_len(TXT,L),NewC=31+L,
	show_str(NewC,1,"\"").
  showfield:-show_str(30,50,"").


  showcursor:-keypressed,!.
  showcursor:-
	shiftwindow(OLD),
	gotowindow(85),
	mycursor(R,C),!,
	str_int(RSTR,R), str_int(CSTR,C), 
	show_str(4,4,RSTR), show_str(14,4,CSTR),
	showfield,
	gotowindow(OLD),
	cursor(RR,CC),
	cursor(RR,CC).
	 

 /***********************************************************************/
 /*	 myfield_attr			   				*/
 /* Sets only the attribute for fields inside the actual screen		*/
 /***********************************************************************/

  myfield_attr(R,C,LEN,ATTR):-
	windowstart(RS,CS),windowsize(RR,CC),
	R>=RS, R<=RS+RR,
	C<=CS+CC, C+LEN>CS,!,
	R1=R-RS,
	max(C,CS,C1),
	HH1=C+LEN, HH2=1+CS+CC,
	min(HH1,HH2,HH),
	L1=HH-C1,
	C2=C1-CS,
	field_attr(R1,C2,L1,ATTR).
  myfield_attr(_,_,_,_).

 /***********************************************************************/
 /*	 myfield_str			   				*/
 /* Prints only text inside the actual screen				*/
 /***********************************************************************/

PREDICATES
  check_drop(INTEGER,STRING,STRING)

CLAUSES
  check_drop(N,STR,STR):-N<=0,!.
  check_drop(N,STR,STR1):-frontstr(N,STR,_,STR1).

  myfield_str(R,C,LEN,STR):-
	windowstart(RS,CS),windowsize(RR,CC),
	R>=RS, R<=RS+RR,
	C+LEN>CS, C<=CS+CC, !,
	R1=R-RS,
	max(C,CS,C1),
	HH1=C+LEN, HH2=1+CS+CC,
	min(HH1,HH2,HH),
	L1=HH-C1,
	C2=C1-CS, MINUSLEN=CS-C,
	check_drop(MINUSLEN,STR,STR1),
	field_str(R1,C2,L1,STR1).
  myfield_str(_,_,_,_).

  
 /***********************************************************************/
 /*	update all fields on the screen			    		*/
 /***********************************************************************/

  writescr:-
	windowstart(SR,SC), windowsize(RR,CC),!,
	RS=SR+RR, CS=SC+CC,
	wrscr(SR,RS,SC,CS).

  wrscr(_,_,_,_):-keypressed,!.
  wrscr(SR,RS,SC,CS):-
	txtfield(ROW,COL,LEN,STR),
	ROW>=SR,ROW<=RS,COL<=CS,COL+LEN>SC,
	myfield_str(ROW,COL,LEN,STR),
	keypressed,!.
  wrscr(SR,RS,SC,CS):-
	field(_,_,ROW,COL,LEN),
	ROW>=SR,ROW<=RS,COL<=CS,COL+LEN>SC,
	myfield_attr(ROW,COL,LEN,112),
	keypressed,!.
  wrscr(_,_,_,_).


 /***********************************************************************/
 /*		MAIN PREDICATES						*/
 /***********************************************************************/


PREDICATES
  run
  myconsult
  proces(INTEGER)
  delete_scr
  save_scr(STRING)
  save_all
  wr(DBASEDOM)
  oldfilename(STRING)
  newfilename(STRING)

  minfield(FNAME,TYPE,ROW,COL,LEN)
  checkmin(FNAME,TYPE,ROW,COL,LEN)
  chngminfield(FNAME,TYPE,ROW,COL,LEN)
  nondeterm rep_field
  mininit
  ltfield(ROW,COL,ROW,COl)

CLAUSES
  run:-
	repeat,
	clearwindow,
	cursor(9,25),
	menu(9,25,31,47,
		["Define screen layout",
		 "Save screen layout",
		 "Load screen layout",
		 "Edit layout definition file"],
		 "Screen definition",0,Choice),
	proces(Choice),
	Choice=0,!.


  proces(0):-!.
  proces(1):-!,scrdef.
  proces(2):-
	oldfilename(OLD),
	readfilename(10,10,23,23,"scr",OLD,FILENAME),
	newfilename(FILENAME),
	save_scr(FILENAME),!.
  proces(3):-
	readfilename(10,10,23,23,"scr","",FILENAME),
	newfilename(FILENAME),
	delete_scr,
	myconsult.
  proces(4):-
	readfilename(10,10,23,23,"scr","",FILENAME),
	file_str(FILENAME,TXT),
	editmsg(TXT,TXT1,"screen definition",FILENAME,"",0,"",RET),
	RET><1,
	readfilename(10,10,23,23,"scr",FILENAME,NEW),
	file_str(NEW,TXT1).


  oldfilename(X):-filename(X),!.
  oldfilename("").

  newfilename(_):-retract(filename(_)),fail.
  newfilename(X):-assert(filename(X)).


  save_scr(FILENAME):-
	existfile(FILENAME),
	newext(FILENAME,".bak",BACKNAME),
	existfile(BACKNAME),
	deletefile(BACKNAME),
	renamefile(FILENAME,BACKNAME),fail.
  save_scr(FILENAME):-
	openwrite(textfile,FILENAME),
	writedevice(textfile),
	save_all,
	closefile(textfile),!.
  save_scr(_):-closefile(textfile),write(">> File error"),readkey(_).

  save_all:-
	rep_field,
	mininit,
	minfield(FNAME,TYPE,ROW,COL,LEN),
	wr(field(FNAME,TYPE,ROW,COL,LEN)),
	fail.
  save_all:-save("dd.dat"),fail.
  save_all:-
	retract(tempfield(FNAME,TYPE,ROW,COL,LEN)),
	assert(field(FNAME,TYPE,ROW,COL,LEN)),
	fail.
  save_all:-
	txtfield(TEXT,ROW,COL,LEN),
	wr(txtfield(TEXT,ROW,COL,LEN)),
	fail.
  save_all:-
	windowsize(R,C),
	wr(windowsize(R,C)),
	fail.
  save_all.

  wr(X):-write(X),nl.

  rep_field.
  rep_field:-field(_,_,_,_,_),!,rep_field.

  mininit:-retract(tempminfield(_,_,_,_,_)),fail.
  mininit:-
	retract(field(FNAME,TYPE,ROW,COL,LEN)),!,
	assert(tempminfield(FNAME,TYPE,ROW,COL,LEN)).

  minfield(_,_,_,_,_):-
	field(FNAME,TYPE,ROW,COL,LEN),
	checkmin(FNAME,TYPE,ROW,COL,LEN),
	fail.
  minfield(FNAME,TYPE,ROW,COL,LEN):-
	retract(tempminfield(FNAME,TYPE,ROW,COL,LEN)),!,
	assert(tempfield(FNAME,TYPE,ROW,COL,LEN)).

  checkmin(FNAME,TYPE,ROW,COL,LEN):-
	tempminfield(_,_,ROW1,COL1,_),!,
	ltfield(ROW,COL,ROW1,COL1),
	chngminfield(FNAME,TYPE,ROW,COL,LEN).

  ltfield(ROW,_,ROW1,_):-ROW<ROW1,!.
  ltfield(ROW,COL,ROW,COL1):-COL<COL1.

  chngminfield(FNAME,TYPE,ROW,COL,LEN):-
	retract(tempminfield(FNAME1,TYPE1,ROW1,COL1,LEN1)),!,
	asserta(field(FNAME1,TYPE1,ROW1,COL1,LEN1)),
	retract(field(FNAME,TYPE,ROW,COL,LEN)),!,
	assert(tempminfield(FNAME,TYPE,ROW,COL,LEN)).

  delete_scr:-retract(windowsize(_,_)),fail.
  delete_scr:-retract(field(_,_,_,_,_)),fail.
  delete_scr:-retract(txtfield(_,_,_,_)),fail.
  delete_scr.


PREDICATES
  openrd(STRING)
  nondeterm repfile(FILE)
  myconsult1
  editfile(STRING,INTEGER)
  inconsistent(DBASEDOM,STRING)
  inconsistentline(STRING)
  lineno(INTEGER)

CLAUSES

  openrd(FILE):-
	openread(textfile,FILE),readdevice(textfile),!.
  openrd(_):-closefile(textfile),write(">> File error"),readkey(_).

  myconsult:-retract(continue),fail.
  myconsult:-retract(dblineno(_)),fail.
  myconsult:-
	assert(continue),
	assert(dblineno(0)),
	filename(FILE),
	openrd(FILE),
	myconsult1,!.
  myconsult.

  repfile(_).
  repfile(F):-continue,!,not(eof(F)),repfile(F).

  lineno(X):-retract(dblineno(X)),!,X1=X+1,assert(dblineno(X1)).

  myconsult1:-
	repfile(textfile),
	filepos(textfile,POS,0),
	lineno(LINENO),
	inconsistentline(TXT),
	ERRORPOS=POS-LINENO,
	editfile(TXT,ERRORPOS),
	fail.
  myconsult1:-closefile(textfile),retract(continue),!.

  inconsistentline(TXT):-
	readterm(DBASEDOM,X),!,inconsistent(X,TXT).
  inconsistentline("Syntax error in line").


  inconsistent(field(N,_,_,_,_),"This fieldname is previously defined"):-
    	field(N,_,_,_,_),!.
  inconsistent(field(_,_,R,C1,L1),MSG):-
  	field(F2,_,R,C2,L2),
  	C1<=C2+L2,C1+L1>=C2,
  	concat("This field overlaps with ",F2,MSG),!.
  inconsistent(txtfield(Row,Col,Len,_),"Overlapping textfields"):-
  	txtfield(Row,C2,Len2,_),
  	Col<C2+Len2,C2<Col+Len,!.
  inconsistent(txtfield(R,L,_,Str),""):-
	str_len(Str,Len),
  	assertz(txtfield(R,L,Len,Str)),!,fail.
  inconsistent(Fact,""):-
  	assertz(Fact),!,fail.

  editfile(_,_):-closefile(textfile),retract(continue),fail.
  editfile(MSG,POS):-
	filename(FILE),!,
	file_str(FILE,TXT),
	editmsg(TXT,TXT1,"screen definition",FILE,MSG,POS,"",RET),
	RET><1,
	file_str(FILE,TXT1),
	openread(textfile,FILE),
	readdevice(textfile),
	assert(continue),
	retract(dblineno(_)),!,
	assert(dblineno(0)),
	delete_scr.

GOAL
  makewindow(11,7,0,"",0,0,25,80),
  run.
