/****************************************************************

     Turbo Prolog Toolbox
     (C) Copyright 1987 Borland International.

 			longmenu
 Implements a popup-menu with more than 23 possible choices

  The up and down arrow keys and pgup, pgdn, home, and end  can be used to
  move the bar.
  RETURN or F10 will select an indicated item.
  Pressing Esc aborts menu selection and returns a zero.

  The arguments to longmenu are:
  menu(ROW,COL,MAXROWS,WINDOWATTR,FRAMEATTR,STRINGLIST,HEADER,STARTCHOICE,SELECTION)

	ROW and COL determine the position of the window
	WATTR and FATTR determine the attributes for the window
		and its frame - if FATTR is zero there
		will be no frame around the window.
	MAXROWS determines how many rows should be displayed on the screen
	STRINGLIST is the list of items on the menu
	HEADER is the text to appear in the top of the menu window
	STARTCHOICE determines where the bar should be placed.

  Ex:	 longmenu(5,5,7,7,5,[a,b,c,d,e,f,g,h,i,j,k,l,m,n],letters,0,CHOICE)
****************************************************************/

PREDICATES
  longmenu(ROW,COL,ROW,ATTR,ATTR,STRINGLIST,STRING,INTEGER,INTEGER)
  longmenuinit(ROW,COL,ROW,ATTR,ATTR,STRINGLIST,STRING,ROW,COL,ROW,COL,ROW)
  longmenu1(SYMBOL,ROW,COL,ROW,COL,ATTR,STRINGLIST,ROW,ROW,ROW,ROW,ROW,ROW)
  longmenu2(SYMBOL,ROW,ROW,ROW,ROW,ROW,ROW,KEY) 
  longmenu3(ROW,ROW,ROW,ROW,ROW,ROW) 
  wr_part_if_changed(ROW,ROW,ROW,COL,STRINGLIST)
  write_part_list(ROW,ROW,ROW,ROW,COL,STRINGLIST)

CLAUSES
  longmenu(ROW,COL,MAXH,WATTR,FATTR,STRINGLIST,HEADER,STCHOICE,CHOICE) :-
	longmenuinit(ROW,COL,MAXH,WATTR,FATTR,STRINGLIST,HEADER,AROW,ACOL,HEIGHT,LEN,NOOFROW),
	STOFFSET=STCHOICE-1,
	longmenu3(NOOFROW,HEIGHT,0,STOFFSET,BASE,OFFSET),
	longmenu1(cont,AROW,ACOL,HEIGHT,LEN,WATTR,STRINGLIST,NOOFROW,-1,BASE,OFFSET,BASE1,OFFS1),
	CHOICE = BASE1 + OFFS1+1,
	removewindow.

  longmenuinit(ROW,COL,MAXH,WATTR,FATTR,STRINGLIST,HEADER,AROW,ACOL,HEIGHT,NOOFCOL,NOOFROW):-
	maxlen(STRINGLIST,0,MAXNOOFCOL),
	str_len(HEADER,HEADLEN),
	HEADL1=HEADLEN+4,
	max(HEADL1,MAXNOOFCOL,NOOFCOL),
	listlen(STRINGLIST,N), N > 0 , NOOFROW=N,
	min(NOOFROW,MAXH,HEIGHT),
	adjframe(FATTR,HEIGHT,NOOFCOL,HH1,HH2),
	adjustwindow(ROW,COL,HH1,HH2,AROW,ACOL),
	makewindow(81,WATTR,FATTR,HEADER,AROW,ACOL,HH1,HH2).

  longmenu1(cont,ROW,COL,H,W,ATTR,STRINGLIST,NOOFROW,OLDBASE,BASE,OFFS,BASE2,OFFS2) :-!,
	wr_part_if_changed(OLDBASE,BASE,H,W,STRINGLIST),
	reverseattr(ATTR,REV),
	field_attr(OFFS,0,W,REV),
	cursor(OFFS,0),
	readkey(KEY),
	longmenu2(STOP,H,NOOFROW,BASE,OFFS,BASE1,OFFS1,KEY),
	field_attr(OFFS,0,W,ATTR),
	longmenu1(STOP,ROW,COL,H,W,ATTR,STRINGLIST,NOOFROW,BASE,BASE1,OFFS1,BASE2,OFFS2). 
  longmenu1(esc,_,_,_,_,_,_,_,_,OB,OF,OB,OF):-!.
  longmenu1(_,_,_,_,W,ATTR,_,_,_,OB,OF,OB,OF):-
	reverseattr(ATTR,REV),
	field_attr(OF,0,W,REV).


  longmenu2(esc,_,_,_,_,0,-1,esc)		:-!.
  longmenu2(stop,_,_,B,O,B,O,fkey(10)) 	:-!.
/*longmenu2(cont,_,_,B,O,B,O,fkey(1))	:-!,help. If a help system is used */
  longmenu2(selection,_,_,B,O,B,O,cr)	:-!.
  longmenu2(cont,_,_,_,_,0,0,home)		:-!.
  longmenu2(cont,H,LEN,_,_,B1,O1,end)	:-!, O1=H-1, B1 = LEN-H. 
  longmenu2(cont,H,LEN,B,O,B1,O1,up)	:-!, OO=O-1,longmenu3(LEN,H,B,OO,B1,O1).
  longmenu2(cont,H,LEN,B,O,B1,O1,down)	:-!, OO=O+1,longmenu3(LEN,H,B,OO,B1,O1).
  longmenu2(cont,H,LEN,B,O,B1,O1,pgup)	:-!, OO=O-H+1,longmenu3(LEN,H,B,OO,B1,O1).
  longmenu2(cont,H,LEN,B,O,B1,O1,pgdn)	:-!, OO=O+H-1,longmenu3(LEN,H,B,OO,B1,O1).
  longmenu2(cont,_,_,B,O,B,O,_).

  longmenu3(_,H,B,O,B,O)		:-O>=0, O<H, !.
  longmenu3(LEN,H,B1,O1,B2,O2)	:-O1+B1>=LEN,!, O2=H-1, B2=LEN-H.
  longmenu3(_,_,B1,O1,0,0)		:-O1+B1<0,!.
  longmenu3(_,_,B1,O1,B2,0)	:-O1<0, !, B2=B1+O1.
  longmenu3(_,H,B1,O1,B2,O2)	:-O1>=H, O2=H-1, B2=B1+O1-O2.

  wr_part_if_changed(B,B,_,_,_)  :- !.
  wr_part_if_changed(OLDB,B,H,W,CL) :-
	SCROLL=B-OLDB, scroll(SCROLL,0),
	write_part_list(0,B,0,H,W,CL).
      
  write_part_list(_,_,H,H,_,_) :- !.
  write_part_list(I,B,R,H,W,[_|T]) :- I<B,!, I1=I+1,
		write_part_list(I1,B,R,H,W,T).
  write_part_list(I,B,R,H,W,[STR|T]) :-
		field_str(R,0,W,STR),
		R1=R+1,
		write_part_list(I,B,R1,H,W,T).


/****************************************************************/
/* 			longmenu_leave				*/
/* As longmenu but the window is not removed on return		*/
/****************************************************************/

PREDICATES
  longmenu_leave(ROW,COL,ROW,ATTR,ATTR,STRINGLIST,STRING,INTEGER,INTEGER)

CLAUSES
  longmenu_leave(ROW,COL,MAXH,WATTR,FATTR,STRINGLIST,HEADER,STCHOICE,CHOICE):-
	longmenuinit(ROW,COL,MAXH,WATTR,FATTR,STRINGLIST,HEADER,AROW,ACOL,HEIGHT,LEN,NOOFROW),
	STOFFSET=STCHOICE-1,
	longmenu3(NOOFROW,HEIGHT,0,STOFFSET,BASE,OFFSET),
	longmenu1(cont,AROW,ACOL,HEIGHT,LEN,WATTR,STRINGLIST,NOOFROW,-1,BASE,OFFSET,BASE1,OFFS1),
	CHOICE = BASE1 + OFFS1+1.


/****************************************************************/
/* 			longmenu_mult				*/
/* Allows a multiple number of selections.			*/
/*								*/
/* Each selection is made by pressing RETURN. All selections    */
/* then activated by pressing F10.				*/
/****************************************************************/
/*
PREDICATES
  longmenu_mult(ROW,COL,ROW,ATTR,ATTR,STRINGLIST,STRING,INTEGERLIST,INTEGERLIST)
  multlongmenu1(SYMBOL,ROW,COL,ROW,COL,ATTR,STRINGLIST,ROW,ROW,ROW,ROW,INTEGERLIST,INTEGERLIST)
  highlight_selected1(ROW,ROW,COL,INTEGERLIST,ATTR)
  handle_selection(INTEGER,INTEGERLIST,INTEGERLIST,ROW,ROW,COL,ATTR)
  try_del(INTEGER,INTEGERLIST,INTEGERLIST,ROW,ROW,COL,ATTR)
  row_attr(ROW,ROW,COL,ATTR)

CLAUSES
  longmenu_mult(ROW,COL,MAXH,WATTR,FATTR,STRINGLIST,HEADER,STARTCH,CHOOSED) :-
	longmenuinit(ROW,COL,MAXH,WATTR,FATTR,STRINGLIST,HEADER,AROW,ACOL,HEIGHT,LEN,NOOFROW),
	multlongmenu1(cont,AROW,ACOL,HEIGHT,LEN,WATTR,STRINGLIST,NOOFROW,-1,0,0,STARTCH,CHOOSED),
	removewindow.

  multlongmenu1(stop,_,_,_,_,_,_,_,_,_,_,CHOOSED,CHOOSED).
  multlongmenu1(esc,_,_,_,_,_,_,_,_,_,_,_,[]).
  multlongmenu1(selection,ROW,COL,H,W,ATTR,STRINGLIST,NOOFROW,OLDBASE,BASE,OFFS,CHIN,CHOUT) :-
	SELECTION=BASE+OFFS+1,
	handle_selection(SELECTION,CHIN,NEWCHIN,BASE,NOOFROW,W,ATTR),
	multlongmenu1(cont,ROW,COL,H,W,ATTR,STRINGLIST,NOOFROW,OLDBASE,BASE,OFFS,NEWCHIN,CHOUT).
  multlongmenu1(cont,ROW,COL,H,W,ATTR,STRINGLIST,NOOFROW,OLDBASE,BASE,OFFS,CHIN,CHOUT) :-
	wr_part_if_changed(OLDBASE,BASE,H,W,STRINGLIST),
	reverseattr(ATTR,REV),
	highlight_selected1(BASE,H,W,CHIN,REV),
	cursor(OFFS,0),
	readkey(KEY),
	longmenu2(STOP,H,NOOFROW,BASE,OFFS,BASE1,OFFS1,KEY),
	multlongmenu1(STOP,ROW,COL,H,W,ATTR,STRINGLIST,NOOFROW,BASE,BASE1,OFFS1,CHIN,CHOUT). 


  highlight_selected1(_,_,_,[],_).
  highlight_selected1(BASE,MAXROW,LEN,[H|T],ATTR):-
	ROW=H-BASE-1,
	row_attr(ROW,MAXROW,LEN,ATTR),
	highlight_selected1(BASE,MAXROW,LEN,T,ATTR).

  row_attr(ROW,MAXROW,LEN,ATTR):-
	ROW>=0, ROW<MAXROW,!,
	field_attr(ROW,0,LEN,ATTR).
  row_attr(_,_,_,_).

  try_del(SELECTION,[SELECTION|REST],REST,BASE,MAXROW,LEN,ATTR):-!,
	ROW=SELECTION-BASE-1,
	row_attr(ROW,MAXROW,LEN,ATTR).
  try_del(SELECTION,[H|REST],[H|REST1],BASE,MAXROW,LEN,ATTR):-
	try_del(SELECTION,REST,REST1,BASE,MAXROW,LEN,ATTR).

  handle_selection(SELECTION,OLDCHIN,NEWCHIN,BASE,MAXROW,LEN,ATTR):-
	try_del(SELECTION,OLDCHIN,NEWCHIN,BASE,MAXROW,LEN,ATTR),!.
  handle_selection(SELECTION,OLDCHIN,[SELECTION|OLDCHIN],_,_,_,_).
*/