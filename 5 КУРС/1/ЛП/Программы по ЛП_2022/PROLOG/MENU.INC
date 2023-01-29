/****************************************************************

     Turbo Prolog Toolbox
     (C) Copyright 1987 Borland International.

 			menu
  Implements a popup menu with at most 23 possible choices.
  For more than 23 possible choices use longmenu.

  The up and down arrow keys can be used to move the bar.
  RETURN or F10  will select an indicated item.
  Pressing Esc aborts menu selection and returns zero.

  The arguments to menu are:
  
  menu(ROW,COL,WINDOWATTR,FRAMEATTR,STRINGLIST,HEADER,STARTCHOICE,SELECTION)

	ROW and COL determines the position of the window
	WATTR and FATTR determine the attributes for the window
		and its frame - if FATTR is zero there
		will be no frame around the window.
	STRINGLIST is the list of menu items
	HEADER is the text to appear at the top of the menu window
	STARTCHOICE determines where the bar should be placed.

  Ex:	 menu(5,5,7,7,[this,is,a,test],"select word",0,CHOICE)

****************************************************************/

PREDICATES
  alexmenu(ATTR,ATTR,STRINGLIST,STRING,INTEGER,INTEGER)
  countlist(STRINGLIST,INTEGER,INTEGER)
  takemax(INTEGER,INTEGER,INTEGER)
  menu(ROW,COL,ATTR,ATTR,STRINGLIST,STRING,INTEGER,INTEGER)
  menuinit(ROW,COL,ATTR,ATTR,STRINGLIST,STRING,ROW,COL)
  menu1(SYMBOL,ROW,ATTR,STRINGLIST,ROW,COl,INTEGER)
  menu2(KEY,STRINGLIST,ROW,ROW,ROW,SYMBOL)

CLAUSES
    alexmenu(Attr1,Attr2,List,Head,St,Choice):-
      countlist([Head|List],Yd,Xd),
      textmode(Ymax,Xmax),
      Y = (Ymax - Yd - 2) div 2,
      X = (Xmax - Xd - 2) div 2,
      menu(Y,X,Attr1,Attr2,List,Head,St,Choice).

    takemax(X1,X2,X):-
      X1 > X2,!,
      X = X1.
    takemax(_,X2,X2).
  
    countlist([],0,0):-!.
    countlist([H|T],Y,X):-
      countlist(T,Yw,Xw),
      Y = Yw + 1,
      str_len(H,Len),
      takemax(Xw,Len,X).      
      
  menu(ROW,COL,WATTR,FATTR,LIST,HEADER,STARTCHOICE,CHOICE) :-
	menuinit(ROW,COL,WATTR,FATTR,LIST,HEADER,NOOFROW,LEN),
	ST1=STARTCHOICE-1,max(0,ST1,ST2),MAX=NOOFROW-1,min(ST2,MAX,STARTROW),
	menu1(cont,STARTROW,WATTR,LIST,NOOFROW,LEN,CHOICE),
	removewindow.

  menuinit(ROW,COL,WATTR,FATTR,LIST,HEADER,NOOFROW,NOOFCOL):-
	maxlen(LIST,0,MAXNOOFCOL),
	str_len(HEADER,HEADLEN),
	HEADL1=HEADLEN+4,
	max(HEADL1,MAXNOOFCOL,NOOFCOL),
	listlen(LIST,LEN), LEN>0,
	NOOFROW=LEN,
	adjframe(FATTR,NOOFROW,NOOFCOL,HH1,HH2),
	adjustwindow(ROW,COL,HH1,HH2,AROW,ACOL),
	makewindow(81,WATTR,FATTR,HEADER,AROW,ACOL,HH1,HH2),
	writelist(0,NOOFCOL,LIST).

  menu1(cont,ROW,ATTR,LIST,MAXROW,NOOFCOL,CHOICE):-!,
	reverseattr(ATTR,REV),
	field_attr(ROW,0,NOOFCOL,REV),
	cursor(ROW,0),
	readkey(KEY),
	field_attr(ROW,0,NOOFCOL,ATTR),
	menu2(KEY,LIST,MAXROW,ROW,NEXTROW,CONT),
	menu1(CONT,NEXTROW,ATTR,LIST,MAXROW,NOOFCOL,CHOICE).
  menu1(esc,ROW,_,_,_,_,CHOICE):-!,CHOICE=ROW+1.
  menu1(_,ROW,ATTR,_,_,NOOFCOL,CHOICE):-
	CHOICE=ROW+1,
	reverseattr(ATTR,REV),
	field_attr(ROW,0,NOOFCOL,REV).

  menu2(esc,_,_,_,-1,esc):-!.
  menu2(fkey(10),_,_,ROW,ROW,stop):-!.
  menu2(char(C),LIST,_,_,CH,selection):-tryletter(C,LIST,CH),!.
/*menu2(fkey(1),_,_,ROW,ROW,cont):-!,help.  If a help system is used */
  menu2(cr,_,_,ROW,CH,selection):-!,CH=ROW.
  menu2(up,_,_,ROW,NEXTROW,cont):-ROW>0,!,NEXTROW=ROW-1.
  menu2(down,_,MAXROW,ROW,NEXTROW,cont):-NEXTROW=ROW+1,NEXTROW<MAXROW,!.
  menu2(end,_,MAXROW,_,NEXT,cont):-!,NEXT=MAXROW-1.
  menu2(pgdn,_,MAXROW,_,NEXT,cont):-!,NEXT=MAXROW-1.
  menu2(home,_,_,_,0,cont):-!.
  menu2(pgup,_,_,_,0,cont):-!.
  menu2(_,_,_,ROW,ROW,cont).



/****************************************************************/
/* 			menu_leave				*/
/* As menu but the window is not removed on return.		*/
/****************************************************************/

PREDICATES
  menu_leave(ROW,COL,ATTR,ATTR,STRINGLIST,STRING,INTEGER,INTEGER)

CLAUSES
  menu_leave(ROW,COL,WATTR,FATTR,LIST,HEADER,STARTCHOICE,CHOICE) :-
	menuinit(ROW,COL,WATTR,FATTR,LIST,HEADER,NOOFROW,NOOFCOL),
	ST1=STARTCHOICE-1,max(0,ST1,ST2),MAX=NOOFROW-1,min(ST2,MAX,STARTROW),
	menu1(cont,STARTROW,WATTR,LIST,NOOFROW,NOOFCOL,CHOICE).



/****************************************************************
 			menu_mult
 Implements a popup-menu which allows a multiple number of
 selections.

 Each selection is made by pressing RETURN. All selections are
 then activated by pressing F10.

  The arguments to menu_mult are:
  
  menu(ROW,COL,WINDOWATTR,FRAMEATTR,STRINGLIST,HEADER,STARTLIST,NEWLIST)

	ROW and COL determine the position of the window
	WATTR and FATTR determine the attributes for the window
		and its frame - if FATTR is zero there
		will be no frame around the window.
	STRINGLIST is the list of menu items
	HEADER is the text to appear at the top of the menu window
	STARTLIST determines the items to be highlighted when
		  the menu is first displayed
	NEWLIST   contains the list of selections

  Ex:	 menu_mult(5,5,7,7,[this,is,a,test],"select words",[1],NEWLIST)

****************************************************************/

PREDICATES
  menu_mult(ROW,COL,ATTR,ATTR,STRINGLIST,STRING,INTEGERLIST,INTEGERLIST)
  multmenu1(SYMBOL,ROW,ATTR,STRINGLIST,ROW,COL,INTEGERLIST,INTEGERLIST)
  highlight_selected(INTEGERLIST,COL,ATTR)
  handle_selection(INTEGER,INTEGERLIST,INTEGERLIST,COL,ATTR)
  try_del(INTEGER,INTEGERLIST,INTEGERLIST,COL,ATTR)

CLAUSES
  menu_mult(ROW,COL,WATTR,FATTR,LIST,HEADER,STARTCHLIST,CHLIST) :-
	menuinit(ROW,COL,WATTR,FATTR,LIST,HEADER,NOOFROW,NOOFCOL),
	multmenu1(cont,0,WATTR,LIST,NOOFROW,NOOFCOL,STARTCHLIST,CHLIST),
	removewindow.

  multmenu1(stop,_,_,_,_,_,CHL,CHL):-!.
  multmenu1(esc,_,_,_,_,_,_,[]):-!.
  multmenu1(selection,ROW,ATTR,LIST,MAXROW,NOOFCOL,OLDCHLIN,CHLOUT):-
	CHOICE=1+ROW,
	handle_selection(CHOICE,OLDCHLIN,NEWCHLIN,NOOFCOL,ATTR),
	multmenu1(cont,ROW,ATTR,LIST,MAXROW,NOOFCOL,NEWCHLIN,CHLOUT).
  multmenu1(cont,ROW,ATTR,LIST,MAXROW,NOOFCOL,CHLIN,CHLOUT):-
	reverseattr(ATTR,REV),
	highlight_selected(CHLIN,NOOFCOL,REV),
	cursor(ROW,0),
	readkey(KEY),
	menu2(KEY,LIST,MAXROW,ROW,NEXTROW,CONT),
	multmenu1(CONT,NEXTROW,ATTR,LIST,MAXROW,NOOFCOL,CHLIN,CHLOUT).

  highlight_selected([],_,_).
  highlight_selected([H|T],L,ATTR):-
	ROW=H-1,
	field_attr(ROW,0,L,ATTR),
	highlight_selected(T,L,ATTR).

  try_del(SELECTION,[SELECTION|REST],REST,LEN,ATTR):-
	ROW=SELECTION-1,
	field_attr(ROW,0,LEN,ATTR),!.
  try_del(SELECTION,[H|REST],[H|REST1],LEN,ATTR):-
	try_del(SELECTION,REST,REST1,LEN,ATTR).

  handle_selection(SELECTION,OLDCHIN,NEWCHIN,LEN,ATTR):-
	try_del(SELECTION,OLDCHIN,NEWCHIN,LEN,ATTR),!.
  handle_selection(SELECTION,OLDCHIN,[SELECTION|OLDCHIN],_,_).
