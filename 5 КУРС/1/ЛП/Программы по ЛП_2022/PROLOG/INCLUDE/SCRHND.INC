/****************************************************************

     Turbo Prolog Toolbox
     (C) Copyright 1987 Borland International.

			SCRHND
			======

 This module implements a screen handler called by:
               
                 scrhnd(TOPLINE,ENDKEY)

	TOPLINE = on/off  - determines if there should be a top line
	ENDKEY            - Esc or F10 used to return values
****************************************************************/

/*
DOMAINS
  FNAME=SYMBOL
  TYPE = int(); str(); real()

DATABASE
  /* Database declarations used in scrhnd */
  insmode			/* Global insertmode */
  actfield(FNAME)		/* Actual field */
  screen(SYMBOL,DBASEDOM)	/* Saving different screens */
  value(FNAME,STRING)		/* value of a field */
  field(FNAME,TYPE,ROW,COL,LEN) /* Screen definition */
  txtfield(ROW,COL,LEN,STRING)
  windowsize(ROW,COL).
  notopline

  /* DATABASE PREDICATES USED BY VSCRHND */
  windowstart(ROW,COL)
  mycursord(ROW,COL)

  /* Database declarations used in lineinp */
  lineinpstate(STRING,COL)
*/


PREDICATES
  /* SCREEN DRIVER */
  scrhnd(SYMBOL,KEY)
  endkey(KEY)
  scr(KEY)
  writescr
  showcursor
  mkheader
  showoverwrite

  ass_val(FNAME,STRING)
  valid(FNAME,TYPE,STRING)
  typeerror
  chng_actfield(FNAME)
  field_action(FNAME)
  field_value(FNAME,STRING)
  noinput(FNAME)
  types(INTEGER,TYPE,STRING)	/* Definition of the known types */


 /***********************************************************************/
 /*		Create the window					*/
 /* This can be used to create the window automatically from the	*/
 /* windowsize predicate.						*/
 /***********************************************************************/

PREDICATES
  createwindow(SYMBOL)

CLAUSES
  createwindow(off):-
	windowsize(R,C),!,
	R1=R+3, C1=C+3,
	makewindow(81,23,66,"",0,0,R1,C1).
  createwindow(on):-
	windowsize(R,C),!,
	R1=R+3, C1=C+3,
	makewindow(85,112,0,"",0,0,1,C1),
	makewindow(81,23,66,"",1,0,R1,C1).

 /***********************************************************************/
 /*		Intermediate predicates					*/
 /***********************************************************************/

PREDICATES
  trunc_1(LEN,STRING,STRING)
  oldstr(FNAME,STRING)
  settopline(SYMBOL)

CLAUSES
  endkey(fkey(10)):-!,beep.
  endkey(esc).

  trunc_1(LEN,STR1,STR2):-str_len(STR1,L1),L1>LEN,!,frontstr(LEN,STR1,STR2,_).
  trunc_1(_,STR,STR).

  settopline(_):-retract(notopline),fail.
  settopline(off):-!,assert(notopline).
  settopline(_).

  oldstr(FNAME,S):-	value(FNAME,S),!.
  oldstr(_,"").

  ass_val(FNAME,_):- retract(value(FNAME,_)),fail.
  ass_val(FNAME,VAL):-VAL><"",assert(value(FNAME,VAL)),fail.
  ass_val(_,_).

  chng_actfield(_):-typeerror,!,fail.
  chng_actfield(_):-
	retract(actfield(_)),fail.
  chng_actfield(FNAME):-
	assert(actfield(FNAME)).

  typeerror:-
	actfield(FNAME),
	field(FNAME,TYPE,_,_,_),
	value(FNAME,VAL),
	not(valid(FNAME,TYPE,VAL)),
	beep,!.

  valid(_,str,_).
  valid(_,int,STR):-str_int(STR,_).
  valid(_,real,STR):-str_real(STR,_).

  /* The known types */
  types(1,int,"integer").
  types(2,real,"real").
  types(3,str,"string").


 /***********************************************************************/
 /*		SCREEN DRIVER		   				*/
 /* Screen definition/input is repeated until F10 is pressed		*/
 /***********************************************************************/

  scrhnd(STATUSON,KEY):-
	settopline(STATUSON),
	mkheader,
	writescr,
	field(FNAME,_,R,C,_),!,cursor(R,C),
	chng_actfield(FNAME),
	showcursor,
	repeat,
	writescr,
	keypressed,/*Continuation until keypress means that time dependent
		     user functions can be updated*/
	readkey(KEY),
	scr(KEY),
	showcursor,
	endkey(KEY),!.

 /*******************************************************************/
 /*		 	Find the next field			    */
 /*******************************************************************/

PREDICATES
  /* The predicates should be called with:
    ACTROW, ACTCOL, MAXROW, MAXCOL, NEWROW, NEWCOL   */
  best_right(ROW,COL,ROW,COL,ROW,COL)
  best_left(ROW,COL,ROW,COL,ROW,COL)
  best_down(ROW,COL,ROW,COL,LEN,ROW,COL)
  best_up(ROW,COL,ROW,COL,LEN,ROW,COL)
  better_right(ROW,COL,ROW,COL,ROW,COL)
  better_left(ROW,COL,ROW,COL,ROW,COL)
  better_field(ROW,COL,ROW,COL,LEN,ROW,COL,LEN)
  calcdist(ROW,COL,ROW,COL,LEN,LEN)
  move_left
  move_right
  nextfield(ROW,COL)
  gtfield(ROW,ROW,COL,COL)
  prevfield(ROW,COL)
  chk_found(FNAME,ROW,COL,ROW,COL)
  setlastfield

CLAUSES
  best_right(R0,C0,R1,C1,ROW,COL):-
	field(_,_,R2,C2,_), C2>C0,
	better_right(R0,C0,R1,C1,R2,C2),!,
	best_right(R0,C0,R2,C2,ROW,COL).
  best_right(_,_,R,C,R,C).

  better_right(R0,_,R1,_,R2,_):-abs(R2-R0)<abs(R1-R0),!.
  better_right(R0,_,R1,C1,R2,C2):-abs(R2-R0)=abs(R1-R0),C2<C1.

  best_left(R0,C0,R1,C1,ROW,COL):-
	field(_,_,R2,C2,_), C2<C0,
	better_left(R0,C0,R1,C1,R2,C2),!,
	best_left(R0,C0,R2,C2,ROW,COL).
  best_left(_,_,R,C,R,C).

  better_left(R0,_,R1,_,R2,_):-abs(R2-R0)<abs(R1-R0),!.
  better_left(R0,_,R1,C1,R2,C2):-abs(R2-R0)=abs(R1-R0),C2>C1.

  best_down(R0,C0,R1,C1,L1,ROW,COL):-
	field(_,_,R2,C2,L2), R2>R0,
	better_field(R0,C0,R1,C1,L1,R2,C2,L2),!,
	best_down(R0,C0,R2,C2,L2,ROW,COL).
  best_down(_,_,R,C,_,R,C).

  best_up(R0,C0,R1,C1,L1,ROW,COL):-
	field(_,_,R2,C2,L2), R2<R0,
	better_field(R0,C0,R1,C1,L1,R2,C2,L2),!,
	best_up(R0,C0,R2,C2,L2,ROW,COL).
  best_up(_,_,R,C,_,R,C).

  better_field(R0,C0,R1,C1,L1,R2,C2,L2):-
	calcdist(R0,C0,R1,C1,L1,DIST1),
	calcdist(R0,C0,R2,C2,L2,DIST2),
	DIST2<DIST1.

  calcdist(R0,C0,R1,C1,L1,DIST):-
	C11=C1+L1,
	max(C0,C1,H1),
	min(H1,C11,H2),
	DIST=3*abs(R1-R0)+abs(H2-C0).

  move_left:-
	not(typeerror),
	actfield(FNAME),
	field(FNAME,_,R,C,_),!,
	best_left(R,C,-100,-100,ROW,COL),
	field(F1,_,ROW,COL,_),
	chng_actfield(F1),!,
	cursor(ROW,COL).

  move_right:-
	not(typeerror),
	actfield(FNAME),
	field(FNAME,_,R,C,_),!,
	best_right(R,C,-100,-100,ROW,COL),
	field(F1,_,ROW,COL,_),
	chng_actfield(F1),!,
	cursor(ROW,COL).

  prevfield(_,_):-typeerror,!,fail.
  prevfield(R,C):-
	field(FNAME,_,ROW,COL,_),
	chk_found(FNAME,R,C,ROW,COL),!,
	actfield(F1),
	field(F1,_,RR,CC,_),!,
	cursor(RR,CC).

  chk_found(_,R,C,R,C):-!.
  chk_found(FNAME,_,_,_,_):-chng_actfield(FNAME),fail.


  nextfield(_,_):-typeerror,!,fail.
  nextfield(R,C):-
	field(FNAME,_,ROW,COL,_),gtfield(ROW,R,COL,C),
	chng_actfield(FNAME),!,
	cursor(ROW,COL).
  nextfield(_,_).

  gtfield(R1,R2,_,_):-R1>R2,!.
  gtfield(R,R,C1,C2):-C1>C2.

  setlastfield:-
	field(FNAME,_,_,_,_),
	chng_actfield(FNAME),
	fail.
  setlastfield.


 /***********************************************************************/
 /*		scr		   					*/
 /***********************************************************************/

  /* Insert a new character in a field */
  scr(char(T)):-actfield(FNAME),
		not(noinput(FNAME)),
		cursor(_,C),
		field(FNAME,_,ROW,COL,LEN),!,
		POS=C-COL,
		oldstr(FNAME,STR),
		lin(char(T),POS,STR,STR1),
		trunc_1(LEN,STR1,STR2),
		ass_val(FNAME,STR2),
		field_str(ROW,COL,LEN,STR2),
		scr(right).
		

  /* Delete character under cursor */
  scr(del):-	actfield(FNAME),
		not(noinput(FNAME)),
		cursor(_,C),
		field(FNAME,_,ROW,COL,LEN),!,
		POS=C-COL,
		oldstr(FNAME,STR),
		lin(del,POS,STR,STR1),
		ass_val(FNAME,STR1),
		field_str(ROW,COL,LEN,STR1).
		
  /* Delete character before cursor and move cursor to the left */
  scr(bdel):-	actfield(FNAME),
		not(noinput(FNAME)),
		cursor(_,C),
		field(FNAME,_,ROW,COL,LEN),!,
		POS=C-COL-1,
		oldstr(FNAME,STR),
		lin(del,POS,STR,STR1),
		ass_val(FNAME,STR1),
		field_str(ROW,COL,LEN,STR1),
		scr(left).

 /*If there is an action - do it. Otherwise, go to next field*/
  scr(cr):-
	actfield(FNAME),
	field_action(FNAME),
	cursor(RR,CC),cursor(RR,CC),!.
  scr(cr):-cursor(RR,CC),cursor(RR,CC),scr(tab).


  /* Change between insertmode and overwritemode */
  scr(ins):-changemode,showoverwrite.

  /* escape */
  scr( esc ).

  /* F10: end of definition */
  scr( fkey(10) ):-not(typeerror).

  scr(right):-
	actfield(FNAME),
	not(noinput(FNAME)),
	field(FNAME,_,_,C,L),
	cursor(ROW,COL), COL<C+L-1,!,
	COL1=COL+1,
	cursor(ROW,COL1).

  scr(right):-move_right.

  scr(ctrlright):-
	actfield(FNAME),
	not(noinput(FNAME)),
	field(FNAME,_,_,C,L),
	cursor(ROW,COL),
	COL1=COL+5, COL1<C+L-1,!,
	cursor(ROW,COL1).

  scr(ctrlright):-move_right.

  scr(left):-
	actfield(FNAME), field(FNAME,_,_,C,_),
	cursor(ROW,COL),
	COL>C,!,
	COL1=COL-1,
	cursor(ROW,COL1).

  scr(left):-move_left.

  scr(ctrlleft):-
	actfield(FNAME), field(FNAME,_,_,C,_),
	cursor(ROW,COL),
	COL1=COL-5, COL1>C,!,
	cursor(ROW,COL1).

  scr(ctrlleft):-move_left.

  scr(tab):-
	cursor(R,C),
	nextfield(R,C).

  scr(btab):-
	cursor(R,C),
	prevfield(R,C).

  scr(up):-
	not(typeerror),
	cursor(R,C),
	best_up(R,C,-100,-100,1,ROW,COL),
	field(F1,_,ROW,COL,_),
	chng_actfield(F1),!,
	cursor(ROW,COL).

  scr(down):-
	not(typeerror),
	cursor(R,C),
	best_down(R,C,100,100,1,ROW,COL),
	field(F1,_,ROW,COL,_),
	chng_actfield(F1),!,
	cursor(ROW,COL).

  scr(home):-
	not(typeerror),
	field(F1,_,ROW,COL,_),
	chng_actfield(F1),!,
	cursor(ROW,COL).

  scr(end):-
	not(typeerror),
	setlastfield,
	actfield(FNAME),
	field(FNAME,_,ROW,COL,_),!,
	cursor(ROW,COL).

/* scr(fkey(1)):-help.  If helpsystem is used. */


 /***********************************************************************/
 /*	Predicates maintaining the top messages line	    		*/
 /***********************************************************************/

  mkheader:-notopline,!.
  mkheader:-
  	shiftwindow(OLD),
	gotowindow(85),
	field_str(0,0,30,"ROW:      COL:"),
	gotowindow(OLD).

PREDICATES
  get_overwritestatus(STRING)
  show_str(COL,LEN,STRING)
  showfield(ROW,COL)

CLAUSES
  get_overwritestatus(insert):-insmode,!.
  get_overwritestatus(overwrite).

  show_str(C,L,STR):-
	windowsize(_,COLS),
	C<COLS,!,
	MAXL=COLS-C,
	min(L,MAXL,LL),
	field_str(0,C,LL,STR).
  show_str(_,_,_).

  showoverwrite:-notopline,!.
  showoverwrite:-
	shiftwindow(OLD),
	gotowindow(85),
	get_overwritestatus(OV),
	show_str(20,9,OV),
	gotowindow(OLD).

  showfield(_,_):-keypressed,!.
  showfield(R,C):-
	field(FNAME,TYP,ROW,COL,LEN),
	ROW=R, COL<=C, C<COL+LEN,
	types(_,TYP,TYPE),!,
	show_str(30,8,TYPE),
	STR=FNAME, show_str(38,42,STR).
  showfield(_,_):-keypressed,!.
  showfield(R,C):-
	txtfield(ROW,COL,LEN,TXT),
	ROW=R, COL<=C, C<=COL+LEN,!,
	show_str(30,1,"\""),
	show_str(31,49,TXT).
  showfield(_,_):-show_str(30,50,"").

  showcursor:-keypressed,!.
  showcursor:-notopline,!.
  showcursor:-
	shiftwindow(OLD),
	cursor(R,C),
	str_int(RSTR,R), str_int(CSTR,C), 
	gotowindow(85),
	show_str(4,4,RSTR), show_str(14,4,CSTR),
	showfield(R,C),
	gotowindow(OLD),
	cursor(R,C).


 /***********************************************************************/
 /*	update all fields on the screen			    		*/
 /***********************************************************************/

  writescr:-
	field(FNAME,_,ROW,COL,LEN),
	field_attr(ROW,COL,LEN,112),
	field_value(FNAME,STR),
	field_str(ROW,COL,LEN,STR),
	keypressed,!.
  writescr:-
	txtfield(ROW,COL,LEN,STR),
	field_str(ROW,COL,LEN,STR),
	keypressed,!.
  writescr.


 /***********************************************************************/
 /*		Shift screen		   				*/
 /*         Can be used if needed						*/
 /***********************************************************************/
/*
PREDICATES
  shiftscreen(SYMBOL)

CLAUSES
  shiftscreen(_):-retract(field(_,_,_,_,_)),fail.
  shiftscreen(_):-retract(txtfield(_,_,_,_)),fail.
  shiftscreen(_):-retract(windowsize(_,_)),fail.
  shiftscreen(NAME):-screen(NAME,TERM),assert(TERM),fail.
  shiftscreen(_).
*/

