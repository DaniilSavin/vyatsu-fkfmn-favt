/****************************************************************

     Turbo Prolog Toolbox
     (C) Copyright 1987 Borland International.

		PULL DOWN MENU

  This module implements a pulldown menu.
  
  The parameters are:
	pulldown(ATTRIBUTE,MENULIST,CHOICE,SUBCHOICE)

  where 
	Attribute is used in all the windows
	Menulist is the text for the menus
	CHOICE is the selection from the horizontal menu
	SUBCHOICE is the selection from the vertical menu
	       (or zero if there is no vertical menu for
	        the CHOICE horizontal item)
****************************************************************/

/* ----- Include this database in your program ----
DATABASE
	pdwstate(ROW,COL,SYMBOL,ROW,COL)

include tooldom and toolpred

And give some clauses for the pdwaction predicate

*/


DOMAINS
 MENUELEM =  curtain(COL,STRING,STRINGLIST)
 MENULIST =  MENUELEM*
 ALEXMENUELEM =  alexcurtain(STRING,STRINGLIST)
 ALEXMENULIST =  ALEXMENUELEM*
 STOP	 =  stop(); cont()


PREDICATES
  alexpulldown(ATTR,ALEXMENULIST,INTEGER,INTEGER)
  getlist(ALEXMENULIST,STRINGLIST)
  transform(BGI_ILIST,ALEXMENULIST,MENULIST)
  
    /* Œ¥å ­¨§¬ p á¯p¥¤¥«¥­¨ï ª®®p¤¨­ â */
  tracemenu(STRINGLIST,BGI_ILIST)
  wordlen(INTEGER,STRINGLIST,INTEGER)
  create(INTEGER,INTEGER,STRINGLIST,BGI_ILIST)
  
  pulldown(ATTR,MENULIST,INTEGER,INTEGER)
  pdwaction(INTEGER,INTEGER)
  
  pdwkeyact(KEY,ROW,COL,SYMBOL,ROW,COL,COL,ATTR,MENULIST,STOP)
  pdwmovevert(COL,COL,ATTR,MENULIST)
  pdwindex(COL,MENULIST,MENUELEM)
  pdwindex(ROW,STRINGLIST,STRING)
  makepdwwindow1(ROW,COL,ROW,COL,ATTR,STRINGLIST,ROW)
  makepdwwindow(COL,ATTR,MENULIST,ROW,COL,ROW)
  writelistp(ROW,COL,ATTR,STRINGLIST)
  line_ver(ROW,ROW,COL)
  line_hor(COL,COL,ROW)
  lcorn(COL,CHAR)
  rcorn(COL,CHAR)
  pdwlistlen(MENULIST,COL)
  writepdwlist(ATTR,MENULIST)
  changepdwstate(DBASEDOM)
  check_removewindow(ROW)
  is_up(SYMBOL,ROW)
  nextcol(COL,COL,COL,COL)
  intense(ATTR,ATTR)
  intensefirstupper(ROW,COL,ATTR,STRING)
  intenseletter(ROW,COL,ATTR,STRING)
  pdwlist_strlist(MENULIST,STRINGLIST)

CLAUSES
  alexpulldown(Attr,MenuList,X,Y):-
    getlist(MenuList,List),
    tracemenu(List,XList),
    transform(Xlist,MenuList,PullDownList),
    pulldown(Attr,PullDownList,X,Y).
    
  transform([],[],[]):-!.
  transform([X|T1],[alexcurtain(Str,List)|T2],[curtain(X,Str,List)|T3]):-
    transform(T1,T2,T3).

  getlist([],[]):-!.
  getlist([alexcurtain(H,_)|T1],[H|T2]):-
    getlist(T1,T2).

  create(_,_,[],[]):-!.
  create(Delta,Cur,[H|T1],[Cur|T]):-
    str_len(H,Len),
    Cur1 = Delta + Len + Cur, 
    create(Delta,Cur1,T1,T).

  tracemenu(List,IList):-
    textmode(_,Max),
    wordlen(Len,List,Col),
    Delta = (Max - Len) div Col,
    Start = Delta div 2,
    create(Delta,Start,List,IList).

  wordlen(0,[],0):-!.
  wordlen(Len,[H|T],Int):-
    str_len(H,L),
    wordlen(Work,T,Time),
    Len = L + Work,
    Int = Time + 1.

/* draw pulldown window */
  line_ver(R1,R2,C):-
	R2>R1,!, R=R1+1,
	scr_char(R1,C,'³'),
	line_ver(R,R2,C).
  line_ver(_,_,_).

  line_hor(C1,C2,R):-
	C2>C1,!, C=C1+1,
	scr_char(R,C1,'Ä'),
	line_hor(C,C2,R).
  line_hor(_,_,_).

/* Make the pulldown window */
  makepdwwindow(NO,ATTR,MENULIST,LISTLEN,MAXLEN,FIRSTROW):-
	pdwindex(NO,MENULIST,curtain(CCOL,_,LIST)),COL=CCOL,
	ROW=2,
	listlen(LIST,LISTLEN1),LISTLEN=LISTLEN1,
	maxlen(LIST,0,MAXLEN),
	makepdwwindow1(ROW,COL,LISTLEN,MAXLEN,ATTR,LIST,FIRSTROW).

/*  makepdwwindow1(_,_,_,_,_,_,0):-keypressed,!. */
  makepdwwindow1(_,_,0,_,_,_,0):-!.
  makepdwwindow1(ROW,COL,LISTLEN,MAXLEN,ATTR,LIST,1):-
	NOOFROWS=LISTLEN+2, NOOFCOLS=MAXLEN+2,
	adjustwindow(ROW,COL,NOOFROWS,NOOFCOLS,AROW,ACOL),
	makewindow(81,ATTR,0,"",AROW,ACOL,NOOFROWS,NOOFCOLS),
	writelistp(1,MAXLEN,ATTR,LIST),
	cursor(1,1),reverseattr(ATTR,REV), field_attr(1,1,MAXLEN,REV),
	ENDROW=NOOFROWS-1,
	ENDCOL=NOOFCOLS-1,
	line_hor(1,ENDCOL,0),
	line_hor(1,ENDCOL,ENDROW),
	line_ver(1,ENDROW,0),
	line_ver(1,ENDROW,ENDCOL),
	scr_char(ENDROW,0,'À'),
	scr_char(ENDROW,ENDCOL,'Ù'),
	lcorn(COL,LCORN), scr_char(0,0,LCORN),
	RCOL=ACOL+ENDCOL,
	rcorn(RCOL,RCORN), scr_char(0,ENDCOL,RCORN).

/* draw pulldown window corners */
  lcorn(0,'Ã') :- !.
  lcorn(_,'Â').
 
  rcorn(79,'´') :- !.
  rcorn(_,'Â').

  check_removewindow(0):-!.
  check_removewindow(_):-removewindow.

  is_up(up,_):-!.
  is_up(_,0).

  intense(ATTR,ATTR1):-
	bitxor(ATTR,$08,ATTR1).

  intensefirstupper(ROW,COL,ATTR,WORD):-
	frontchar(WORD,CH,_),
	CH>='A', CH<='Z',!,scr_attr(ROW,COL,ATTR).
  intensefirstupper(ROW,COL,ATTR,WORD):-
	frontchar(WORD,_,REST),COL1=COL+1,
	intensefirstupper(ROW,COL1,ATTR,REST).

  intenseletter(ROW,COL,ATTR,WORD):-
	intense(ATTR,INTENS),
	intensefirstupper(ROW,COL,INTENS,WORD),!.
  intenseletter(ROW,COL,ATTR,_):-
	intense(ATTR,INTENS),
	scr_attr(ROW,COL,INTENS).

  pdwlist_strlist([],[]).
  pdwlist_strlist([curtain(_,H,_)|RESTPDW],[H|RESTSTR]):-
	pdwlist_strlist(RESTPDW,RESTSTR).

  pdwmovevert(COL1,COL2,ATTR,LIST):-
	pdwindex(COL1,LIST,curtain(POS1,WORD1,_)),str_len(WORD1,LEN1),
	pdwindex(COL2,LIST,curtain(POS2,WORD2,_)),str_len(WORD2,LEN2),
	field_attr(0,POS1,LEN1,ATTR),
	intenseletter(0,POS1,ATTR,WORD1),
	reverseattr(ATTR,REV),
	field_attr(0,POS2,LEN2,REV),
	intenseletter(0,POS2,REV,WORD2),
	cursor(0,POS2).

  pdwlistlen([],0).
  pdwlistlen([_|T],N):-
	pdwlistlen(T,X),
	N=X+1.

  writepdwlist(_,[]).
  writepdwlist(ATTR,[curtain(POS,WORD,_)|T]):-
	str_len(WORD,LEN),
	field_str(0,POS,LEN,WORD),
	intenseletter(0,POS,ATTR,WORD),
	writepdwlist(ATTR,T).

  writelistp(_,_,_,[]).
  writelistp(ROW,LEN,ATTR,[H|T]):-
	field_str(ROW,1,LEN,H),
	intenseletter(ROW,1,ATTR,H),
	ROW1=ROW+1,
	writelistp(ROW1,LEN,ATTR,T).

  pdwindex(0,[H|_],H):-!.
  pdwindex(N,[_|T],X):-N1=N-1,pdwindex(N1,T,X).

  changepdwstate(_):-retract(pdwstate(_,_,_,_,_)),fail.
  changepdwstate(T):-assert(T).

  nextcol(0,-1,COL1,MAX):-COL1=MAX-1,!.
  nextcol(COL,1,0,MAX):-COL=MAX-1,!.
  nextcol(COL,DD,COL1,_):-COL1=COL+DD.

  pulldown(ATTR,LIST,CH1,CH2):-
	makewindow(81,ATTR,ATTR,"",0,0,3,80),
	pdwlistlen(LIST,MAXCOL),
	writepdwlist(ATTR,LIST),
	pdwmovevert(0,0,ATTR,LIST),
	changepdwstate(pdwstate(0,0,up,0,0)),
	repeat,
	pdwstate(ROW,COL,DOWN,MAXROW,LEN),
	readkey(KEY),
	pdwkeyact(KEY,ROW,COL,DOWN,MAXROW,MAXCOL,LEN,ATTR,LIST,CONTINUE),
	CONTINUE=stop,removewindow,
	pdwstate(ROW1,COL1,_,_,_),!,
	CH1=COL1+1,
	CH2=ROW1.

/*  Pulldown window action corresponding to input key and Pulldown window
    state */
  pdwkeyact(right,ROW,COL,up,MAXROW,MAXCOL,LEN,ATTR,LIST,cont):-
	nextcol(COL,1,COL1,MAXCOL),
	pdwmovevert(COL,COL1,ATTR,LIST), 
	changepdwstate(pdwstate(ROW,COL1,up,MAXROW,LEN)).

  pdwkeyact(right,ROW,COL,down,_,MAXCOL,_,ATTR,LIST,cont):-
	nextcol(COL,1,COL1,MAXCOL),
	check_removewindow(ROW),
	pdwmovevert(COL,COL1,ATTR,LIST),
	makepdwwindow(COL1,ATTR,LIST,MAXROW1,LEN1,FIRSTROW),
	changepdwstate(pdwstate(FIRSTROW,COL1,down,MAXROW1,LEN1)).

  pdwkeyact(left,ROW,COL,up,MAXROW,MAXCOL,LEN,ATTR,LIST,cont):-
	nextcol(COL,-1,COL1,MAXCOL),
	pdwmovevert(COL,COL1,ATTR,LIST),
	changepdwstate(pdwstate(ROW,COL1,up,MAXROW,LEN)).

  pdwkeyact(left,ROW,COL,down,_,MAXCOL,_,ATTR,LIST,cont):-
	nextcol(COL,-1,COL1,MAXCOL),
	check_removewindow(ROW),
	pdwmovevert(COL,COL1,ATTR,LIST),
	makepdwwindow(COL1,ATTR,LIST,MAXROW1,LEN1,FIRSTROW),
	changepdwstate(pdwstate(FIRSTROW,COL1,down,MAXROW1,LEN1)).

  pdwkeyact(up,ROW,COL,down,MAXROW,_,LEN,ATTR,PDWLIST,cont):-
	ROW>1,!,
	ROW1=ROW-1,
	field_attr(ROW,1,LEN,ATTR),
	pdwindex(COL,PDWLIST,curtain(_,_,LIST)),
	pdwindex(ROW1,LIST,WORD),
	intenseletter(ROW,1,ATTR,WORD),
	reverseattr(ATTR,REV),field_attr(ROW1,1,LEN,REV),
	cursor(ROW1,1),
	changepdwstate(pdwstate(ROW1,COL,down,MAXROW,LEN)).

  pdwkeyact(down,ROW,COL,down,MAXROW,_,LEN,ATTR,PDWLIST,cont):-
	ROW<MAXROW,!,
	ROW1=ROW+1,
	field_attr(ROW,1,LEN,ATTR),
	pdwindex(COL,PDWLIST,curtain(_,_,LIST)),
	INDX=ROW-1,pdwindex(INDX,LIST,WORD),
	intenseletter(ROW,1,ATTR,WORD),
	reverseattr(ATTR,REV),field_attr(ROW1,1,LEN,REV),
	cursor(ROW1,1),
	changepdwstate(pdwstate(ROW1,COL,down,MAXROW,LEN)).

  pdwkeyact(down,_,COL,up,_,_,_,ATTR,LIST,cont):-
	makepdwwindow(COL,ATTR,LIST,MAXROW1,LEN1,FIRSTROW),
	changepdwstate(pdwstate(FIRSTROW,COL,down,MAXROW1,LEN1)).

  pdwkeyact(cr,_,COL,up,_,_,_,ATTR,LIST,stop):-
	makepdwwindow(COL,ATTR,LIST,MAXROW1,LEN1,FIRSTROW),
	changepdwstate(pdwstate(FIRSTROW,COL,down,MAXROW1,LEN1)),
	FIRSTROW=0,
	CH=COL+1, SUBCH=0,
	not(pdwaction(CH,SUBCH)).

  pdwkeyact(cr,ROW,COL,down,_,_,_,_,_,stop):-
	CH=COL+1, SUBCH=ROW,
	not(pdwaction(CH,SUBCH)),
	check_removewindow(ROW).

  pdwkeyact(char(CHAR),ROW,COL,UP,_,_,_,ATTR,PDWLIST,stop):-
	is_up(UP,ROW),!,
	pdwlist_strlist(PDWLIST,STRLIST),
	tryletter(CHAR,STRLIST,SEL),NEWCOL=SEL,
	pdwmovevert(COL,NEWCOL,ATTR,PDWLIST),
	makepdwwindow(NEWCOL,ATTR,PDWLIST,MAXROW1,LEN1,FIRSTROW),
	changepdwstate(pdwstate(FIRSTROW,NEWCOL,down,MAXROW1,LEN1)),
	FIRSTROW=0,
	CH=NEWCOL+1, SUBCH=0,
	not(pdwaction(CH,SUBCH)).

  pdwkeyact(char(CHAR),ROW,COL,down,MAXROW,_,LEN,ATTR,PDWLIST,stop):-
	ROW><0,
	pdwindex(COL,PDWLIST,curtain(_,_,LIST)),
	tryletter(CHAR,LIST,SEL),ROW1=SEL+1,
	field_attr(ROW,1,LEN,ATTR),
	R=ROW-1,
	pdwindex(R,LIST,OLDWORD),
	intenseletter(ROW,1,ATTR,OLDWORD),
	reverseattr(ATTR,REV),field_attr(ROW1,1,LEN,REV),
	cursor(ROW1,1),
	CH=COL+1, SUBCH=ROW1,
	changepdwstate(pdwstate(ROW1,COL,down,MAXROW,LEN)),
	not(pdwaction(CH,SUBCH)),
	removewindow.

  pdwkeyact(esc,ROW,COL,down,_,_,_,_,_,cont):-
	check_removewindow(ROW),
	changepdwstate(pdwstate(0,COL,up,0,0)).

/*pdwkeyact(fkey(1),_,_,_,_,_,_,_,_,cont):-help. If a help system is used*/
