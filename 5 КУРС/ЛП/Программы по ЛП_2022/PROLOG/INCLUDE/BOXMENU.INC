/****************************************************************

     Turbo Prolog Toolbox
     (C) Copyright 1987 Borland International.

 			boxmenu
  boxmenu(ROW,COL,NOOFROWS,NOOFCOLS,WATTR,FATTR,STRINGLIST,HEADER,STCHOICE,CHOICE)
	ROW and COL determine the position of the window
	WATTR and FATTR determine the attributes for the window
		and its frame - if FATTR is zero there
		will be no frame around the window.
	NOOFROWS determines the number of rows in the window
	NOOFCOLS determines the number of columns in the window
	STRINGLIST is a list of items on the menu
	HEADER is the text to be displayed at the top of the menu window
	STARTCHOICE determines where the bar should be placed.

  Ex:	 boxmenu(5,5,7,40,7,5,[a,b,c,d,e,f,g,h,i,j,k,l,m,n],letters,0,CHOICE)

****************************************************************/

DOMAINS
  BASE = INTEGER
PREDICATES
  boxmenu(ROW,COL,ROW,COL,ATTR,ATTR,STRINGLIST,STRING,INTEGER,INTEGER)
  boxmenuinit(ROW,COL,ROW,COL,ATTR,ATTR,STRINGLIST,STRING,COL,COL,BASE)
  boxmenu1(SYMBOL,BASE,BASE,ROW,COL,ROW,COL,COL,BASE,ATTR,STRINGLIST,BASE,ROW,COL)
  boxmenu2(KEY,BASE,ROW,COL,BASE,ROW,COL,BASE,ROW,COL,SYMBOL)
  boxmenu3(BASE,ROW,COL,BASE,ROW,COL,BASE,ROW,COL)
  wr_boxpart_if_changed(BASE,BASE,ROW,COL,COL,STRINGLIST)
  write_boxpart_list(BASE,BASE,ROW,COL,COL,STRINGLIST)

CLAUSES
  boxmenu(ROW,COL,DROW,DCOL,WATTR,FATTR,STRINGLIST,HEADER,STCHOICE,CHOICE) :-
	boxmenuinit(ROW,COL,DROW,DCOL,WATTR,FATTR,STRINGLIST,HEADER,NOOFCOLS,STRLEN,LISTLEN),
	MB=LISTLEN,ST1=STCHOICE-1,max(0,ST1,ST2),min(MB,ST2,ST3),
	STBASE=ST3-ST3 mod(DROW*NOOFCOLS), STROW=(ST3-STBASE) div NOOFCOLS, STCOL=ST3-STBASE-STROW*NOOFCOLS,
	boxmenu1(cont,-1,STBASE,STROW,STCOL,DROW,NOOFCOLS,STRLEN,LISTLEN,WATTR,STRINGLIST,BASE1,ROW1,COL1),
	CHOICE = BASE1 + ROW1*NOOFCOLS + COL1 +1,
	removewindow.

  boxmenuinit(ROW,COL,DROW,DCOL,WATTR,FATTR,STRINGLIST,HEADER,NOOFCOLS,MAXLEN,LISTLEN):-
	listlen(STRINGLIST,N), N > 0, LISTLEN=N,
	maxlen(STRINGLIST,0,STRLEN),MAXLEN=STRLEN+1,
	NOOFCOLS=DCOL div MAXLEN,
	adjframe(FATTR,DROW,DCOL,HH1,HH2),
	adjustwindow(ROW,COL,HH1,HH2,AROW,ACOL),
	makewindow(81,WATTR,FATTR,HEADER,AROW,ACOL,HH1,HH2).

  /* STOP,OLDBASE,BASE,ROW,COL,NOOFROWS,NOOFCOLS,STRLEN,LISTLEN,ATTR,STRINGLIST,BASE1,ROW1,COL1 */
  boxmenu1(cont,OLDBASE,BASE,ROW,COL,DROW,DCOL,STRLEN,LISTLEN,ATTR,STRINGLIST,BASE2,ROW2,COL2):-!,
	wr_boxpart_if_changed(OLDBASE,BASE,DROW,DCOL,STRLEN,STRINGLIST),
	reverseattr(ATTR,REV),
	CC=COL*STRLEN,
	LEN=STRLEN-1,
	field_attr(ROW,CC,LEN,REV),
	cursor(ROW,CC),
	readkey(KEY),
	boxmenu2(KEY,LISTLEN,DROW,DCOL,BASE,ROW,COL,BASE1,ROW1,COL1,STOP),
	field_attr(ROW,CC,LEN,ATTR),
	boxmenu1(STOP,BASE,BASE1,ROW1,COL1,DROW,DCOL,STRLEN,LISTLEN,ATTR,STRINGLIST,BASE2,ROW2,COL2).
  boxmenu1(esc,_,BASE,ROW,COL,_,_,_,_,_,_,BASE,ROW,COL):-!.
  boxmenu1(_,_,BASE,ROW,COL,_,_,STRLEN,_,ATTR,_,BASE,ROW,COL):-
	CC=COL*STRLEN,
	reverseattr(ATTR,REV),
	field_attr(ROW,CC,STRLEN,REV).

/* KEY,LISTLEN,DROW,DCOL,BASE,ROW,COL,BASE1,ROW1,COL1,STOP */
  boxmenu2(esc,_,_,_,_,_,_,0,0,-1,esc):-!.
  boxmenu2(fkey(10),_,_,_,B,R,C,B,R,C,stop):-!.
/*boxmenu2(fkey(1),_,_,_,B,R,C,B,R,C,cont):-!,help. If helpsystem is used  */
  boxmenu2(cr,_,_,_,B,R,C,B,R,C,boxselection):-!.
  boxmenu2(home,_,_,_,B,R,_,B,R,0,cont):-!.
  boxmenu2(end,LISTLEN,DROW,DCOL,B,R,_,B1,R1,C1,cont):-!,
	CC=DCOL-1,boxmenu3(LISTLEN,DROW,DCOL,B,R,CC,B1,R1,C1).
  boxmenu2(left,LISTLEN,DROW,DCOL,B,R,C,B1,R1,C1,cont):-!,
	CC=C-1,boxmenu3(LISTLEN,DROW,DCOL,B,R,CC,B1,R1,C1).
  boxmenu2(right,LISTLEN,DROW,DCOL,B,R,C,B1,R1,C1,cont):-!,
	CC=C+1,boxmenu3(LISTLEN,DROW,DCOL,B,R,CC,B1,R1,C1).
  boxmenu2(up,LISTLEN,DROW,DCOL,B,R,C,B1,R1,C1,cont):-!,
	RR=R-1,boxmenu3(LISTLEN,DROW,DCOL,B,RR,C,B1,R1,C1).
  boxmenu2(down,LISTLEN,DROW,DCOL,B,R,C,B1,R1,C1,cont):-!,
	RR=R+1,boxmenu3(LISTLEN,DROW,DCOL,B,RR,C,B1,R1,C1).
  boxmenu2(pgup,LISTLEN,DROW,DCOL,B,R,C,B1,R1,C1,cont):-!,
	RR=R-DROW+1,boxmenu3(LISTLEN,DROW,DCOL,B,RR,C,B1,R1,C1).
  boxmenu2(pgdn,LISTLEN,DROW,DCOL,B,R,C,B1,R1,C1,cont):-!,
	RR=R+DROW-1,boxmenu3(LISTLEN,DROW,DCOL,B,RR,C,B1,R1,C1).
  boxmenu2(_,_,_,_,B,R,C,B,R,C,cont).

  /* LISTLEN,NOOFROWS,NOOFCOLS,OLDBASE,OLDROW,OLDCOL,NEWBASE,NEWROW,NEWCOL */
  boxmenu3(LISTLEN,DROW,DCOL,B,R,C,B1,R1,C1):-
	B+R*DCOL+C>=LISTLEN,!,
	LL=LISTLEN-1,
	C1=LL mod DCOL,
	MAXROW=LL div DCOL, DR=DROW-1,
	min(MAXROW,DR,R1),
	B1=LL-C1-R1*DCOL.
  boxmenu3(LISTLEN,DROW,DCOL,B,R,C,B1,R1,C1):-
	C>=DCOL, !, RR=R+1,
	boxmenu3(LISTLEN,DROW,DCOL,B,RR,0,B1,R1,C1).
  boxmenu3(LISTLEN,DROW,DCOL,B,R,C,B1,R1,C1):-
	C<0, !, RR=R-1, CC=DCOL-1,
	boxmenu3(LISTLEN,DROW,DCOL,B,RR,CC,B1,R1,C1).
  boxmenu3(LISTLEN,DROW,DCOL,B,R,C,B1,R1,C1):-
	R>=DROW,!,
	RR=DROW-1,
	BB=B+DCOL*(R-RR),
	boxmenu3(LISTLEN,DROW,DCOL,BB,RR,C,B1,R1,C1).
  boxmenu3(LISTLEN,DROW,DCOL,B,R,C,B1,R1,C1):-
	R<0,!,
	BB=B+DCOL*R,
	boxmenu3(LISTLEN,DROW,DCOL,BB,0,C,B1,R1,C1).
  boxmenu3(_,_,_,B,_,_,0,0,0):-
	B<0,!.
  boxmenu3(_,_,_,B,R,C,B,R,C).


  /* OLDBASE,BASE,NOOFROWS,NOOFCOLS,WITH,LIST */  
  wr_boxpart_if_changed(B,B,_,_,_,_)  :- !.
  wr_boxpart_if_changed(OLDB,B,R,C,W,L) :-
	RR=(B-OLDB) div C,scroll(RR,0),
	write_boxpart_list(0,B,R,C,W,L).
      

  /* INDEX,BASE,NOOFROWS,NOOFCOLS,WITH,LIST */  
  write_boxpart_list(I,B,R,C,W,[_|T]) :- I<B,!, I1=I+1,
		write_boxpart_list(I1,B,R,C,W,T).
  write_boxpart_list(I,B,R,C,W,[STR|T]) :-
		ROW=(I-B) div C, ROW<R, !,
		COL= W*(I-B-ROW*C),
		field_str(ROW,COL,W,STR),
		I1=I+1,
		write_boxpart_list(I1,B,R,C,W,T).
  write_boxpart_list(I,B,R,C,W,[]) :-
		ROW=(I-B) div C, ROW<R, !,
		COL= W*(I-B-ROW*C),
		field_str(ROW,COL,W,""),
		I1=I+1,
		write_boxpart_list(I1,B,R,C,W,[]).
  write_boxpart_list(_,_,_,_,_,_) :- !.



/****************************************************************
 			boxmenu_leave
    (as boxmenu but the window is not removed on return)
****************************************************************/


PREDICATES
  boxmenu_leave(ROW,COL,ROW,COL,ATTR,ATTR,STRINGLIST,STRING,INTEGER,INTEGER)

CLAUSES
  boxmenu_leave(ROW,COL,DROW,DCOL,WATTR,FATTR,STRINGLIST,HEADER,STCHOICE,CHOICE) :-
	boxmenuinit(ROW,COL,DROW,DCOL,WATTR,FATTR,STRINGLIST,HEADER,NOOFCOLS,STRLEN,LISTLEN),
	MB=LISTLEN,ST1=STCHOICE-1,max(0,ST1,ST2),min(MB,ST2,ST3),
	STBASE=ST3-ST3 mod(DROW*NOOFCOLS), STROW=(ST3-STBASE) div NOOFCOLS, STCOL=ST3-STBASE-STROW*NOOFCOLS,
	boxmenu1(cont,-1,STBASE,STROW,STCOL,DROW,NOOFCOLS,STRLEN,LISTLEN,WATTR,STRINGLIST,BASE1,ROW1,COL1),
	CHOICE = BASE1 + ROW1*NOOFCOLS + COL1 +1.


/*******************************************************************/
/* 			boxmenu_mult				   */
/* Allows a multiple number of boxselections.			   */
/*								   */
/* Each boxselection is made by pressing RETURN. All boxselections */
/* are then activated by pressing F10.	                           */
/*******************************************************************/

PREDICATES
  boxmenu_mult(ROW,COL,ROW,COL,ATTR,ATTR,STRINGLIST,STRING,INTEGERLIST,INTEGERLIST)
  multboxmenu1(SYMBOL,BASE,BASE,ROW,COL,ROW,COL,COL,BASE,ATTR,STRINGLIST,INTEGERLIST,INTEGERLIST)
  highlight_boxselected(INTEGERLIST,BASE,ROW,COL,COL,ATTR)
  handle_boxselection(INTEGER,INTEGERLIST,INTEGERLIST,BASE,ROW,COL,COL,ATTR)
  try_boxdel(INTEGER,INTEGERLIST,INTEGERLIST,BASE,ROW,COL,COL,ATTR)
  w_attr(INTEGER,BASE,ROW,COL,COL,ATTR)

CLAUSES
  boxmenu_mult(ROW,COL,DROW,DCOL,WATTR,FATTR,STRINGLIST,HEADER,STARTCH,CHOOSED) :-
	boxmenuinit(ROW,COL,DROW,DCOL,WATTR,FATTR,STRINGLIST,HEADER,NOOFCOLS,STRLEN,LISTLEN),
	multboxmenu1(cont,-1,0,0,0,DROW,NOOFCOLS,STRLEN,LISTLEN,WATTR,STRINGLIST,STARTCH,CHOOSED),
	removewindow.

  /* STOP,OLDBASE,BASE,ROW,COL,NOOFROWS,NOOFCOLS,STRLEN,LISTLEN,ATTR,STRINGLIST,BASE1,ROW1,COL1 */
  multboxmenu1(stop,_,_,_,_,_,_,_,_,_,_,CHOOSED,CHOOSED).
  multboxmenu1(esc,_,_,_,_,_,_,_,_,_,_,_,[]).
  multboxmenu1(boxselection,OLDBASE,BASE,ROW,COL,NOOFROWS,NOOFCOLS,STRLEN,LISTLEN,ATTR,STRINGLIST,CHIN,CHOUT):-
	SELECTION = BASE + ROW*NOOFCOLS + COL +1,
	handle_boxselection(SELECTION,CHIN,NEWCHIN,BASE,NOOFROWS,NOOFCOLS,STRLEN,ATTR),
	multboxmenu1(cont,OLDBASE,BASE,ROW,COL,NOOFROWS,NOOFCOLS,STRLEN,LISTLEN,ATTR,STRINGLIST,NEWCHIN,CHOUT).
  multboxmenu1(cont,OLDBASE,BASE,ROW,COL,NOOFROWS,NOOFCOLS,STRLEN,LISTLEN,ATTR,STRINGLIST,CHIN,CHOUT):-
	wr_boxpart_if_changed(OLDBASE,BASE,NOOFROWS,NOOFCOLS,STRLEN,STRINGLIST),
	reverseattr(ATTR,REV),
	highlight_boxselected(CHIN,BASE,NOOFROWS,NOOFCOLS,STRLEN,REV),
	CC=COL*STRLEN,
	cursor(ROW,CC),
	readkey(KEY),
	boxmenu2(KEY,LISTLEN,NOOFROWS,NOOFCOLS,BASE,ROW,COL,BASE1,ROW1,COL1,STOP),
	multboxmenu1(STOP,BASE,BASE1,ROW1,COL1,NOOFROWS,NOOFCOLS,STRLEN,LISTLEN,ATTR,STRINGLIST,CHIN,CHOUT).


  /* SELECTED,BASE,NOOFROWS,NOOFCOLS,STRLEN,REVATTR */
  highlight_boxselected([],_,_,_,_,_).
  highlight_boxselected([H|T],BASE,NOOFROWS,NOOFCOLS,STRLEN,ATTR):-
	w_attr(H,BASE,NOOFROWS,NOOFCOLS,STRLEN,ATTR),
	highlight_boxselected(T,BASE,NOOFROWS,NOOFCOLS,STRLEN,ATTR).

  w_attr(CHOICE,BASE,NOOFROWS,NOOFCOLS,STRLEN,ATTR):-
	CHOICE>BASE, CHOICE<=BASE+NOOFROWS*NOOFCOLS,!,
	CH=CHOICE-1,
	RR=(CH-BASE) div NOOFCOLS,
	CC=STRLEN*(CH mod NOOFCOLS),
	field_attr(RR,CC,STRLEN,ATTR).
  w_attr(_,_,_,_,_,_).

  try_boxdel(SELECTION,[SELECTION|REST],REST,BASE,NOOFROWS,NOOFCOLS,STRLEN,ATTR):-!,
	w_attr(SELECTION,BASE,NOOFROWS,NOOFCOLS,STRLEN,ATTR).
  try_boxdel(SELECTION,[H|REST],[H|REST1],BASE,NOOFROWS,NOOFCOLS,STRLEN,ATTR):-
	try_boxdel(SELECTION,REST,REST1,BASE,NOOFROWS,NOOFCOLS,STRLEN,ATTR).

  handle_boxselection(SELECTION,OLDCHIN,NEWCHIN,BASE,NOOFROWS,NOOFCOLS,STRLEN,ATTR):-
	try_boxdel(SELECTION,OLDCHIN,NEWCHIN,BASE,NOOFROWS,NOOFCOLS,STRLEN,ATTR),!.
  handle_boxselection(SELECTION,OLDCHIN,[SELECTION|OLDCHIN],_,_,_,_,_).
