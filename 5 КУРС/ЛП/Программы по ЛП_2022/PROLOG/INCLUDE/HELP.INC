
/****************************************************************

     Turbo Prolog Toolbox
     (C) Copyright 1987 Borland International.

			HELP FACILITY

 This module contains the functions which are necessary to make
 a context sensitive help facility.

 The help texts are placed in one single helpfile, and the database
 predicate helptext allows access to each help text.

 The database predicate helpcontext implements a last in-first out
 stack mechanism. When the program moves into a new context, the
 predicate push_helpcontext can be used to push a new helpcontext
 onto the stack. When the program leaves the context, the predicate
 popcontext is used to remove the temporary helpcontext and re-
 establish the old. If there is any possibility of the program
 failing in the temporary context, the predicate temp_help_context
 should be used because it automatically removes the helpcontext 
 on backtracking.

****************************************************************/

/*
DOMAINS
  HELPUNIT	= h(STRING)
  HELPCONTEXT	= SYMBOL
  FILEPOS	= REAL
  FILE	= helpfile

DATABASE
	helptext(HELPCONTEXT,ATTR,ATTR,STRING,ROW,COL,ROW,COL,FILEPOS)
	helpcontext(HELPCONTEXT)
	helpfile(STRING)
*/


PREDICATES
  push_helpcontext(HELPCONTEXT)
  pop_helpcontext
  change_helpcontext(HELPCONTEXT)
  temp_helpcontext(HELPCONTEXT)
  displayhelp(HELPCONTEXT)
  help

CLAUSES
  push_helpcontext(HELPCONTEXT):-
	asserta(helpcontext(HELPCONTEXT)).

  pop_helpcontext:-
	retract(helpcontext(_)),!.
  pop_helpcontext.

  change_helpcontext(HELPCONTEXT):-
	pop_helpcontext,  push_helpcontext(HELPCONTEXT).

  temp_helpcontext(HELPCONTEXT):-
	push_helpcontext(HELPCONTEXT).
  temp_helpcontext(_):-
	pop_helpcontext.

  help:-helpcontext(HELPCONTEXT),!,
	displayhelp(HELPCONTEXT).


  displayhelp(HELPCONTEXT):-
	helptext(HELPCONTEXT,WATTR,FATTR,HEADER,ROW,COL,ROWS,COLS,FILEPOS),!,
	readdevice(OLD),
	helpfile(FILENAME),!,
	openread(helpfile,FILENAME),
	readdevice(helpfile),
	filepos(helpfile,FILEPOS,0),
	readterm(HELPUNIT,h(HELPTEXT)),
	closefile(helpfile),
	readdevice(OLD),
	makewindow(81,WATTR,FATTR,HEADER,ROW,COL,ROWS,COLS),
	display(HELPTEXT),
	removewindow.
