
/****************************************************************
                                                              
     Turbo Prolog Toolbox
     (C) Copyright 1987 Borland International.                
                                                              
 			linemenu				
 Implements a popup menu in a horizontal line.		
								
 The arrow keys (left and right) can be used to move the bar.	
 The RETURN or F10 keys will select an indicated item.  
 Pressing Esc aborts menu selection and returns a zero.	
****************************************************************/

PREDICATES
  linemenu(ROW,ATTR,ATTR,STRINGLIST,INTEGER)
  linemenu1(SYMBOL,ATTR,STRINGLIST,COL,COL,COL,COL)
  linemenu2(KEY,STRINGLIST,COL,COL,COL,SYMBOL)
  writelinelist(COL,COL,STRINGLIST)
  index(COL,STRINGLIST,STRING)

CLAUSES
  linemenu(ROW,WATTR,FATTR,LIST,CHOICE) :-
	listlen(LIST,N),N=LISTLEN,          /* returns number of elements in list */
	adjframe(FATTR,1,78,AR,_),          /* if FATTR not equal 0 add to window */
	JMP=78 div LISTLEN,
	makewindow(81,WATTR,FATTR,"",ROW,0,AR,80),
	writelinelist(0,JMP,LIST),
	linemenu1(cont,WATTR,LIST,0,LISTLEN,JMP,ENDCOL),
	CHOICE=ENDCOL,
	removewindow.

  linemenu1(cont,ATTR,LIST,SEL,MAX,JMP,CHOICE):-
	COL=SEL*JMP,
	cursor(0,COL),
	index(SEL,LIST,STR),str_len(STR,STRLEN),
	reverseattr(ATTR,REV),
	field_attr(0,COL,STRLEN,REV),
	readkey(KEY),          /* In TPREDS.PRO returns the tokenized input */
	field_attr(0,COL,STRLEN,ATTR),
	linemenu2(KEY,LIST,MAX,SEL,SEL1,CONT),!,
	linemenu1(CONT,ATTR,LIST,SEL1,MAX,JMP,CHOICE).
  linemenu1(_,_,_,SEL,_,_,CHOICE):-CHOICE=SEL+1.


  linemenu2(char(C),LIST,_,_,CHOICE,selection):-tryfirstletter(C,LIST,0,CH),!,CHOICE=CH.
  linemenu2(esc,_,_,_,-1,esc):-!.
  linemenu2(fkey(10),_,_,SEL,SEL,stop):-!.
/*linemenu2(fkey(1),_,_,SEL,SEL,cont):-!,help.  If helpsystem is used  */
  linemenu2(cr,_,_,SEL,SEL,selection):-!.
  linemenu2(end,_,MAX,_,SEL,cont):-!,SEL=MAX-1.
  linemenu2(home,_,_,_,0,cont):-!.
  linemenu2(right,_,MAX,SEL,0,cont):-SEL=MAX-1,!.
  linemenu2(right,_,_,SEL,SEL1,cont):-!,SEL1=SEL+1.
  linemenu2(left,_,MAX,0,SEL,cont):-SEL=MAX-1,!.
  linemenu2(left,_,_,SEL,SEL1,cont):-!,SEL1=SEL-1.
  linemenu2(_,_,_,SEL,SEL,cont).

/* writes the choice list equally spaced in window */
  writelinelist(_,_,[]).
  writelinelist(SEL,JMP,[H|T]):-
	COL=SEL*JMP, SEL1=SEL+1,
	field_str(0,COL,JMP,H),
	writelinelist(SEL1,JMP,T).


  index(0,[H|_],H):-!.
  index(N,[_|T],X):-N1=N-1,index(N1,T,X).
