
 /*******************************************************************

     Turbo Prolog Toolbox
     (C) Copyright 1987 Borland International.

 			HELPDEF				    	
*******************************************************************/

code=4000

 /*******************************************************************/
 /*			Domains					    */
 /*******************************************************************/

include "tdoms.inc"

DOMAINS
  FNAME=SYMBOL
  TYPE = int(); str(); real()
  VALUE	= int(INTEGER); str(STRING); real(REAL)
  HELPUNIT	= h(STRING)
  FILEPOS	= REAL
  FILE		= helpfile ; def
  HELPDOM1	= helptext(STRING,ATTR,ATTR,STRING,ROW,COL,ROW,COL,FILEPOS)
  HELPDOM2	= h(STRING)


 /*******************************************************************/
 /*			Database				    */
 /*******************************************************************/

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
  lineinpflag

  helptext(STRING,ATTR,ATTR,STRING,ROW,COL,ROW,COL)
  helpstrings(STRING,STRING)
  helpcontext(STRING)

 /*******************************************************************/
 /*			Include tools				    */
 /*******************************************************************/

include "tpreds.pro"
include "longmenu.pro"
include "status.pro"
include "lineinp.pro"
include "filename.pro"
include "scrhnd.pro"

 /*******************************************************************/
 /*			Intermediate predicates			    */
 /*******************************************************************/

PREDICATES
  index(INTEGER,STRINGLIST,STRING)

CLAUSES
  index(1,[H|_],H):-!.
  index(N,[_|T],X):-N>1,N1=N-1,index(N1,T,X).

PREDICATES
  change(DBASEDOM)

CLAUSES
  change(value(X,_)):-retract(value(X,_)),fail.
  change(helpcontext(_)):-retract(helpcontext(_)),fail.
  change(X):-assert(X).

PREDICATES
  get_helpcontext(STRING)
  put_helpcontext
  check_retract(STRING)
  rdname(STRING)
  wr(HELPDOM1)  wr(HELPDOM2)
  makefile
  readfile
  nondeterm repfile(FILE)

CLAUSES
  get_helpcontext(_):-
	retract(value(name,_)),fail.
  get_helpcontext(NAME):-
	not(helptext(NAME,_,_,_,_,_,_,_)),!,
	assert(value(name,NAME)),
	not(helpstrings(NAME,"")),
	assert(helpstrings(NAME,"")),
	shiftwindow(OLD),
	shiftwindow(5),
	window_str(""),
	shiftwindow(OLD).
  get_helpcontext(_):-retract(value(_,_)),fail.
  get_helpcontext(NAME):-
	helptext(NAME,WATTR,FATTR,LABEL,SROW,SCOL,ROWS,COLS),!,
	assert(value(name,NAME)),
	assert(value(label,LABEL)),
	str_int(S1,WATTR),assert(value(wattr,S1)),
	str_int(S2,FATTR),assert(value(fattr,S2)),
	str_int(S3,SROW),assert(value(srow,S3)),
	str_int(S4,SCOL),assert(value(scol,S4)),
	str_int(S5,ROWS),assert(value(rows,S5)),
	str_int(S6,COLS),assert(value(cols,S6)),
	helpstrings(NAME,STRING),!,
	shiftwindow(OLD),
	shiftwindow(5),
	window_str(STRING),
	shiftwindow(OLD).

  put_helpcontext:-
	value(name,NAME),
	check_retract(NAME),
	field_value(label,LABEL),
	value(wattr,S1),str_int(S1,WATTR),
	value(fattr,S2),str_int(S2,FATTR),
	value(srow,S3),str_int(S3,SROW),
	value(scol,S4),str_int(S4,SCOL),
	value(rows,S5),str_int(S5,ROWS),
	value(cols,S6),str_int(S6,COLS),!,
	assert(helptext(NAME,WATTR,FATTR,LABEL,SROW,SCOL,ROWS,COLS)).
  put_helpcontext.

  check_retract(NAME):-
	retract(helptext(NAME,_,_,_,_,_,_,_)),fail.
  check_retract(_).

  rdname(NAME):-
	cursor(ROW,COL),
	lineinput(ROW,COL,40,7,7,"Name of help context: ","",NAME),
	NAME><"",!.
  rdname(NAME):-
	findall(X,helptext(X,_,_,_,_,_,_,_),LIST),
	cursor(ROW,COL),
	longmenu(ROW,COL,15,7,7,LIST,"Choose helpcontext",0,CHOICE),
	index(CHOICE,LIST,NAME).

 /*******************************************************************/
 /*			Field action				    */
 /*******************************************************************/

  field_action(name):-
	put_helpcontext,
	rdname(NAME),
	get_helpcontext(NAME).

  field_action(remove):-
	put_helpcontext,
	rdname(NAME),
	retract(helptext(NAME,_,_,_,_,_,_,_)),!,
	value(name,NAME),!,
	helptext(NAME1,_,_,_,_,_,_,_),!,
	get_helpcontext(NAME1).

  field_action(edit):-
	value(name,NAME),
	helpstrings(NAME,STRING),!,
	shiftwindow(OLD),
	shiftwindow(5),
	edit(STRING,STRING1),
	window_str(STRING1),
	shiftwindow(OLD),
	retract(helpstrings(NAME,_)),!,
	assert(helpstrings(NAME,STRING1)).

  field_action(edit):-
	value(name,NAME),!,
	shiftwindow(OLD),
	shiftwindow(5),
	edit("",STRING1),
	window_str(STRING1),
	shiftwindow(OLD),
	assert(helpstrings(NAME,STRING1)).

  field_action(load):-
	cursor(ROW,COL),
	readfilename(ROW,COL,7,7,def,"",DFILE),
	upper_lower(DFILE,DEFFILE),
	concat(FILENAME,".def",DEFFILE),
	concat(FILENAME,".hlp",HELPFILE),
	openread(helpfile,HELPFILE),
	openread(def,DEFFILE),
	readfile,
	closefile(def),
	closefile(helpfile),
	helptext(NAME1,_,_,_,_,_,_,_),!,
	get_helpcontext(NAME1).


  field_action(save):-
	put_helpcontext,
	cursor(ROW,COL),
	readfilename(ROW,COL,7,7,def,"",DFILE),
	upper_lower(DFILE,DEFFILE),
	concat(FILENAME,".def",DEFFILE),
	concat(FILENAME,".hlp",HELPFILE),
	openwrite(helpfile,HELPFILE),
	openwrite(def,DEFFILE),
	makefile,
	closefile(def),
	closefile(helpfile).

  readfile:-retract(helptext(_,_,_,_,_,_,_,_)),fail.
  readfile:-retract(helpstrings(_,_)),fail.
  readfile:-
	repfile(def),
	readdevice(def),
	readterm(HELPDOM1,helptext(NAME,WATTR,FATTR,LABEL,SROW,SCOL,ROWS,COLS,FILEPOS)),
	readdevice(helpfile),
	filepos(helpfile,FILEPOS,0),
	readterm(HELPDOM2,h(STRING)),
	assert(helptext(NAME,WATTR,FATTR,LABEL,SROW,SCOL,ROWS,COLS)),
	assert(helpstrings(NAME,STRING)),
	fail.
  readfile.

  makefile:-
	helptext(NAME,WATTR,FATTR,LABEL,SROW,SCOL,ROWS,COLS),
	helpstrings(NAME,STRING),
	filepos(helpfile,POS,0),
	writedevice(helpfile),
	wr(h(STRING)),
	writedevice(def),
	wr(helptext(NAME,WATTR,FATTR,LABEL,SROW,SCOL,ROWS,COLS,POS)),
	fail.
  makefile.


  wr(X):-write(X),nl.

  repfile(_).
  repfile(FILE):-not(eof(FILE)),repfile(FILE).

 /*******************************************************************/
 /*			 Field_value				    */
 /*******************************************************************/

  field_value(load,_):-!,fail.
  field_value(save,_):-!,fail.
  field_value(edit,_):-!,fail.
  field_value(remove,_):-!,fail.
  field_value(FNAME,VAL):-value(FNAME,VAL),!.
  field_value(_,"").


 /*******************************************************************/
 /*			 noinput				    */
 /*******************************************************************/

  noinput(edit).
  noinput(remove).
  noinput(name).
  noinput(load).
  noinput(save).

 /*******************************************************************/
 /*			 Screen handler call 		            */
 /*******************************************************************/

GOAL	makewindow(5,7,7,"Help text",15,0,9,80),
	consult("help.scr"),	/* Consult the screen definition */
	makewindow(11,7,7,"Definition of helpfiles",0,0,15,80),
	scrhnd(off,_).		/* Call screen handler */
