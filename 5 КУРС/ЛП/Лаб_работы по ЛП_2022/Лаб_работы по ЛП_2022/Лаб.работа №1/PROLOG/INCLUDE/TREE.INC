/****************************************************************

     Turbo Prolog Toolbox
     (C) Copyright 1987 Borland International.

		Treemenu
****************************************************************/

/*
include "tdoms.pro"

DOMAINS
  SELECTOR=INTEGER
  TREE = tree(STRING,SELECTOR,TREELIST)
  TREELIST = TREE*

DATABASE
  treewindow(ROW,COL)
  treechoice(SELECTOR)
*/

DOMAINS
  ROWLIST=ROW*
  COLLIST=COL*

PREDICATES
  treemenu(SYMBOL,TREE,SELECTOR)
  treeaction(SELECTOR)

  draw(symbol,TREE)

  writetext(ROW,COL,INTEGER,STRING,SELECTOR)
  treeline_ver(ROW,ROW,COL)
  treeline_ver1(ROW,ROW,COL)
  treeline_hor(COL,COL,ROW)
  treeline_hor1(COL,COL,ROW)
  scr_ch(ROW,COL,CHAR)  

  lastinlist(ROW,ROWLIST)
  lastinlist(COL,COLLIST)
  incrow(ROW,ROW,COL,COL)
  listsum(ROWLIST,ROW)
  listsum(COLLIST,COL)
  treekeyact(KEY)
  just(ROW,COL)
  just1(ROW,COL,ROW,COL)
  just2(ROW,COL)
  nodelistlen(ROWLIST,INTEGER)
  nodelistlen(COLLIST,INTEGER)
  remove_treechoice
  newupdate(DBASEDOM)
  treedrop(INTEGER,STRING,STRING)
  

CLAUSES
/* draw vertical lines connecting elements in the tree */
  treeline_ver(R1,R2,C):-
  	treewindow(STROW,STCOL),           /* find the starting position */
  	makewindow(_,_,_,_,_,_,ROWS,COLS), /* returns the tree windows size */
  	C>=STCOL, C<STCOL+COLS-2, R1<STROW+ROWS-2,  
  	R2>=STROW, SLROW=STROW+ROWS-2,
	max(STROW,R1,STROW1), min(R2,SLROW,SLROW1),
	CC=C-STCOL, RR1=STROW1-STROW, RR2=SLROW1-STROW,
	treeline_ver1(RR1,RR2,CC),fail.
  treeline_ver(_,_,_).

  treeline_ver1(R1,R2,C):-
	R2>R1, R=R1+1,
	scr_char(R1,C,'³'),
	treeline_ver1(R,R2,C).

/* draw horizontal lines connecting elements in the tree */
  treeline_hor(C1,C2,R):-
  	treewindow(STROW,STCOL), makewindow(_,_,_,_,_,_,ROWS,COLS),
	SLCOL=STCOL+COLS-2,
  	R>=STROW, R<STROW+ROWS-2, C1<SLCOL, C2>STCOL,
	max(STCOL,C1,STCOL1), min(C2,SLCOL,SLCOL1),
	RR=R-STROW, CC1=STCOL1-STCOL, CC2=SLCOL1-STCOL,
	treeline_hor1(CC1,CC2,RR),fail.
  treeline_hor(_,_,_).

  treeline_hor1(C1,C2,R):-
	C2>C1, C=C1+1,
	scr_char(R,C1,'Ä'),
	treeline_hor1(C,C2,R).

/* write a character in a tree window  */
  scr_ch(R,C,CH):-
  	treewindow(STROW,STCOL), makewindow(_,_,_,_,_,_,ROWS,COLS),
  	R>=STROW, R<STROW+ROWS-2, C>=STCOL, C<STCOL+COLS-2, !,
	RR=R-STROW, CC=C-STCOL,
	scr_char(RR,CC,CH).
  scr_ch(_,_,_).

  treedrop(0,TEXT,TEXT):-!.
  treedrop(N,TEXT,TEXT1):-frontstr(N,TEXT,_,TEXT1).

  writetext(ROW,COL,ATTR,TEXT,SELECT):-
  	str_len(TEXT,LEN),
  	treewindow(STROW,STCOL), makewindow(_,_,_,_,_,_,ROWS,COLS),
  	ROW>=STROW, ROW<STROW+ROWS-2, COL<STCOL+COLS-2, COL+LEN>STCOL,
  	REALROW=ROW-STROW,
  	RSTART=COL-STCOL,
  	REND=RSTART+LEN,
	VST=STCOL-STCOL, VEND=VST+COLS-2,
	max(RSTART,VST,RSTART1), min(REND,VEND,REND1),
	REALLEN=REND1-RSTART1,
	DROP=RSTART1-RSTART,
	treedrop(DROP,TEXT,TEXT1),
	field_str(REALROW,RSTART1,REALLEN,TEXT1),
	field_attr(REALROW,RSTART1,REALLEN,ATTR),
	cursor(R,C),
	R=REALROW,
	C>=RSTART1, C<RSTART1+REALLEN,!,
	field_attr(R,RSTART1,REALLEN,1),
	assert(treechoice(SELECT)).
  writetext(_,_,_,_,_).


  listsum(  [],0):-!.
  listsum([H|T],N):-listsum(T,N1),N=N1+H.

  incrow(ROW,NEW,COL,COL):-!,NEW=ROW+2.
  incrow(ROW,NEW,_,_):-NEW=ROW+2.
    
  lastinlist(RMAX,[RMAX]) :- !.
  lastinlist(RMAX,[_|T]) :- lastinlist(RMAX,T).

  nodelistlen([],0).
  nodelistlen([_|T],N):-
	nodelistlen(T,X),
	N=X+1.

  newupdate(_):-retract(treewindow(_,_)),fail.
  newupdate(X):-assert(X).

/* Cursor window control */
  just(R,C):-
	cursor(ROW,COL),       /* current cursor pos */
	RR=ROW+R, CC=COL+C,
	makewindow(_,_,_,_,_,_,ROWS,COLS),
	ROWSS=ROWS-3, COLSS=COLS-3,
	just1(RR,CC,ROWSS,COLSS).

/* move cursor and control windows */
  just1(R,C,_,_):-R<0,!,cursor(0,C),just2(R,0).
  just1(R,C,_,_):-C<0,!,cursor(R,0),just2(0,C).
  just1(R,C,ROWS,_):-R>ROWS,!,cursor(ROWS,C),DR=R-ROWS,just2(DR,0).
  just1(R,C,_,COLS):-C>COLS,!,cursor(R,COLS),DC=C-COLS,just2(0,DC).
  just1(R,C,_,_):-cursor(R,C),fail.

/* scroll tree in window with cursor and update tree position */
  just2(DR,DC):-
	scroll(DR,DC),  /* scroll is a Turbo Prolog standard predicate */
  	treewindow(R,C),!,
	CC=C+DC, RR=R+DR,
	newupdate(treewindow(RR,CC)), 
	fail.

/* Tree input key action */
  treekeyact(right)	:-just(0,1).
  treekeyact(ctrlright)	:-just(0,5).
  treekeyact(left)	:-just(0,-1).
  treekeyact(ctrlleft)	:-just(0,-5).
  treekeyact(up)	:-just(-1,0).
  treekeyact(pgup)	:-just(-5,0).
  treekeyact(down)	:-just(1,0).
  treekeyact(pgdn)	:-just(5,0).
  treekeyact(ctrlhome)	:-treewindow(R,C),!,RR=-R,CC=-C,just2(RR,CC).
  treekeyact(end)	:-cursor(_,C),makewindow(_,_,_,_,_,_,_,COLS),
			  DC=COLS-3-C,just(0,DC).
  treekeyact(home)	:-cursor(_,C),DC=-C,just(0,DC).
  treekeyact(cr)	:-treechoice(CHOICE),!,treeaction(CHOICE).
  treekeyact(esc).
  treekeyact(fkey(10)).


/*treekeyact(fkey(1)):-help.  If helpsystem is used */

  remove_treechoice:-retract(treechoice(_)),fail.
  remove_treechoice.


/****************************** DRAW RIGHT ****************************/

PREDICATES
  draw_right(TREE,ROW,ROW,COL,COL,COL,COL,ROW)
  draw_rightlist(TREELIST,ROWLIST,ROWLIST,ROW,ROW,COL,COL,COL,COL)
  connect_nodesright(ROW,COL,INTEGER,COL,ROWLIST)
  con_nodesright(ROW,COL,ROW,ROW,COL,ROWLIST)
  cornerright(ROW,ROW,ROW,ROW,CHAR)
  check_lastright(ROW,COL,ROWLIST)

CLAUSES
 
  draw_right(_,_,_,_,_,_,_,_):-keypressed,!,readkey(KEY),treekeyact(KEY),fail.
  draw_right(tree(NAME,SELECT,[]),CURROW,NEWCURROW,LASTNAMECOL,CURCOL,CURCOL,_,RESROW):-!,
	incrow(CURROW,NEWCURROW,LASTNAMECOL,CURCOL),
	RESROW=NEWCURROW,
	writetext(RESROW,CURCOL,112,NAME,SELECT).
  draw_right(tree(NAME,SELECT,TREELIST),CURROW,NEWCURROW,LASTNAMECOL,NEXTNAMECOL,CURCOL,COLSTEP,RESROW):-
	str_len(NAME,NAMELEN),
	CURCOL1=1+NAMELEN+CURCOL+COLSTEP,
	draw_rightlist(TREELIST,[],NODEROWLIST,CURROW,NEWCURROW,LASTNAMECOL,NEXTNAMECOL,CURCOL1,COLSTEP),
	nodelistlen(NODEROWLIST,LEN),
	listsum(NODEROWLIST,SUM),
	RESROW=SUM div LEN,
	COLAFTERNAME=1+CURCOL+NAMELEN,
	connect_nodesright(RESROW,COLAFTERNAME,LEN,CURCOL1,NODEROWLIST),
	writetext(RESROW,CURCOL,112,NAME,SELECT),
	COLAFTERNAME1=CURCOL+NAMELEN,
	scr_ch(RESROW,COLAFTERNAME1,'Ä'),
	check_lastright(RESROW,COLAFTERNAME,NODEROWLIST).

  draw_rightlist([],NodeRowList,NodeRowList,CurRow,CurRow,NEXTNAMECOL,NEXTNAMECOL,_,_).
  draw_rightlist([H|T],NodeRowList,ResNodeRowList,CurRow,CurRow2,LNCOL1,LNCOL3,CurCol,Colstep):-
	draw_right(H,CurRow,Currow1,LNCOL1,LNCOL2,Curcol,Colstep,Noderow),
	draw_rightlist(T,[Noderow|NodeRowList],ResNodeRowList,CurRow1,CurRow2,LNCOL2,LNCOL3,CurCol,Colstep).

  check_lastright(ROW,_,[ROW|_]):-!.
  check_lastright(ROW,COL,[_|LIST]):-!,check_lastright(ROW,COL,LIST).
  check_lastright(ROW,COL,_):-scr_ch(ROW,COL,'´').

  connect_nodesright(ROW,COL,1,COL1,_) :-!,
        treeline_hor(COL,COL1,ROW).
  connect_nodesright(ROW,COL,_,COL1,[RMAX|L]):-
        lastinlist(RMIN,[RMAX|L]),
        con_nodesright(ROW,COL,RMIN,RMAX,COL1,[RMAX|L]).

  con_nodesright(_,_,_,_,_,[]).
  con_nodesright(_,COL,_,_,_,[R1,R2|_]):-
	R22=R2+1,
	treeline_ver(R22,R1,COL), fail.
  con_nodesright(ROW,COL,RMIN,RMAX,COL1,[ROW1|T]):-
	CC=COL+1,
	treeline_hor(CC,COL1,ROW1),
	cornerright(ROW,RMIN,RMAX,ROW1,CORNCHAR),
	scr_ch(ROW1,COL,CORNCHAR),
	con_nodesright(ROW,COL,RMIN,RMAX,COL1,T).

  cornerright(RMIN,RMIN,_,RMIN,'Â') :- !.
  cornerright(RMAX,_,RMAX,RMAX,'Á') :- !.
  cornerright(_,RMIN,_,RMIN,'Ú') :- !.
  cornerright(_,_,RMAX,RMAX,'À') :- !.
  cornerright(RMIDT,_,_,RMIDT,'Å') :- !.
  cornerright(_,_,_,_,'Ã').

/************************** END DRAW RIGHT ****************************/


/************************** DRAW LEFT *********************************/

PREDICATES
  draw_left(TREE,ROW,ROW,COL,COL,COL,COL,ROW)
  draw_leftlist(TREELIST,ROWLIST,ROWLIST,ROW,ROW,COL,COL,COL,COL)
  connect_nodesleft(ROW,COL,INTEGER,COL,ROWLIST)
  con_nodesleft(ROW,COL,ROW,ROW,COL,ROWLIST)
  check_lastleft(ROW,COL,ROWLIST)
  check_lastleft1(ROW,COL,ROWLIST)
  cornerleft(ROW,ROW,ROW,ROW,CHAR)

CLAUSES
  draw_left(_,_,_,_,_,_,_,_):-keypressed,!,readkey(KEY),treekeyact(KEY),fail.
  draw_left(tree(NAME,SELECT,[]),CURROW,NEWCURROW,LASTNAMECOL,CURCOL,CURCOL,_,RESROW):-!,
	incrow(CURROW,NEWCURROW,LASTNAMECOL,CURCOL),
	RESROW=NEWCURROW,
	str_len(NAME,NAMELEN),
	COLAFTERNAME=CURCOL-NAMELEN,
	writetext(RESROW,COLAFTERNAME,112,NAME,SELECT).
  draw_left(tree(NAME,SELECT,TREELIST),CURROW,NEWCURROW,LASTNAMECOL,NEXTNAMECOL,CURCOL,COLSTEP,RESROW):-
	str_len(NAME,NAMELEN),
	CURCOL1=CURCOL-(COLSTEP+NAMELEN),
	draw_leftlist(TREELIST,[],NODEROWLIST,CURROW,NEWCURROW,LASTNAMECOL,NEXTNAMECOL,CURCOL1,COLSTEP),
	nodelistlen(NODEROWLIST,LEN),
	listsum(NODEROWLIST,SUM),
	RESROW=SUM div LEN,
	COLAFTERNAME=CURCOL-NAMELEN-2,
	COLAFTERNAME1=CURCOL-NAMELEN-1,
	COLAFTERNAME2=CURCOL-NAMELEN,
	connect_nodesleft(RESROW,COLAFTERNAME,LEN,CURCOL1,NODEROWLIST),
	writetext(RESROW,COLAFTERNAME2,112,NAME,SELECT),
	scr_ch(RESROW,COLAFTERNAME1,'Ä'),
	check_lastleft(RESROW,COLAFTERNAME,NODEROWLIST).

  draw_leftlist([],NodeRowList,NodeRowList,CurRow,CurRow,NEXTNAMECOL,NEXTNAMECOL,_,_).
  draw_leftlist([H|T],NodeRowList,ResNodeRowList,CurRow,CurRow2,LNCOL1,LNCOL3,CurCol,Colstep):-
	draw_left(H,CurRow,Currow1,LNCOL1,LNCOL2,Curcol,Colstep,Noderow),
	draw_leftlist(T,[Noderow|NodeRowList],ResNodeRowList,CurRow1,CurRow2,LNCOL2,LNCOL3,CurCol,Colstep).

  check_lastleft(ROW,COL,[_]):-!,scr_ch(ROW,COL,'Ä').
  check_lastleft(ROW,COL,LIST):-check_lastleft1(ROW,COL,LIST).

  check_lastleft1(ROW,_,[ROW|_]):-!.
  check_lastleft1(ROW,COL,[_|LIST]):-!,check_lastleft1(ROW,COL,LIST).
  check_lastleft1(ROW,COL,_):-scr_ch(ROW,COL,'Ã').

  connect_nodesleft(ROW,COL,1,COL1,_) :-!,
	treeline_hor(COL1,COL,ROW).
  connect_nodesleft(ROW,COL,_,COL1,[RMAX|L]):-
        lastinlist(RMIN,[RMAX|L]),
        RR=RMIN+1,
        treeline_ver(RR,RMAX,COL), 
        con_nodesleft(ROW,COL,RMIN,RMAX,COL1,[RMAX|L]).

  con_nodesleft(_,_,_,_,_,[]).
  con_nodesleft(ROW,COL,RMIN,RMAX,COL1,[ROW1|T]):-
	treeline_hor(COL1,COL,ROW1),
	cornerleft(ROW,RMIN,RMAX,ROW1,CORNCHAR),
	scr_ch(ROW1,COL,CORNCHAR),
	con_nodesleft(ROW,COL,RMIN,RMAX,COL1,T).

  cornerleft(RMIN,RMIN,_,RMIN,'Â') :- !.
  cornerleft(RMAX,_,RMAX,RMAX,'Á') :- !.
  cornerleft(_,RMIN,_,RMIN,'¿') :- !.
  cornerleft(_,_,RMAX,RMAX,'Ù') :- !.
  cornerleft(RMIDT,_,_,RMIDT,'Å') :- !.
  cornerleft(_,_,_,_,'´').

/************************** END DRAW LEFT ********************************/

/****************************** DRAW DOWN ****************************/

PREDICATES
  draw_down(TREE,ROW,COL,COL,COL)
  draw_downlist(TREELIST,COLLIST,COLLIST,ROW,COL,COL)
  connect_nodesdown(ROW,ROW,COL,ROW,COLLIST)
  con_nodesdown(COL,ROW,COL,COL,ROW,COLLIST)
  cornerdown(COL,COL,COL,COL,CHAR)
  check_lastdown(COL,ROW,COLLIST)

CLAUSES
  draw_down(_,_,_,_,_):-keypressed,!,readkey(KEY),treekeyact(KEY),fail.
  draw_down(tree(NAME,SELECT,[]),CURROW,MAXCOL,NEWMAXCOL,MID):-!,
	str_len(NAME,LEN),
	NEWMAXCOL=MAXCOL+LEN+1,
	MID=MAXCOL+(LEN-1) div 2,
	writetext(CURROW,MAXCOL,112,NAME,SELECT).
  draw_down(tree(NAME,SELECT,TREELIST),CURROW,MAXCOL,NEWMAXCOL,RESCOL):-
	NEXTROW=CURROW+3,
	draw_downlist(TREELIST,[],NODECOLLIST,NEXTROW,MAXCOL,NEWMAXCOL0),
	nodelistlen(NODECOLLIST,LEN),
	listsum(NODECOLLIST,SUM),
	str_len(NAME,NAMELEN),
	RESCOL=SUM div LEN,
	JUST=RESCOL-NAMELEN div 2,
	max(MAXCOL,JUST,NAMESTART),
	writetext(CURROW,NAMESTART,112,NAME,SELECT),
	ROW1=CURROW+1,LLEN=LEN,
	connect_nodesdown(ROW1,NEXTROW,RESCOL,LLEN,NODECOLLIST),
	check_lastdown(RESCOL,ROW1,NODECOLLIST),

	NEWMAXCOL1=NAMESTART+NAMELEN+1,
	max(NEWMAXCOL0,NEWMAXCOL1,NEWMAXCOL).
	

  draw_downlist([],NODECOLLIST,NODECOLLIST,_,MAXCOL,MAXCOL).
  draw_downlist([H|T],NodeColList,ResNodeColList,CURROW,MAXCOL,MAXCOL2):-
	draw_down(H,CURROW,MAXCOL,MAXCOL1,NODECOL),
	draw_downlist(T,[NODECOL|NODECOLLIST],RESNODECOLLIST,CURROW,MAXCOL1,MAXCOL2).

  check_lastdown(COL,_,[COL|_]):-!.
  check_lastdown(COL,ROW,[_|LIST]):-!,check_lastdown(COL,ROW,LIST).
  check_lastdown(COL,ROW,_):-scr_ch(ROW,COL,'Á').

  connect_nodesdown(ROW,ROW1,COL,1,_) :-!,
        treeline_ver(ROW,ROW1,COL).
  connect_nodesdown(ROW,ROW1,COL,_,[CMAX|L]):-
        lastinlist(CMIN,[CMAX|L]),
        CC=CMIN+1,
        treeline_hor(CC,CMAX,ROW),
        con_nodesdown(COL,ROW,CMIN,CMAX,ROW1,[CMAX|L]).
  
  con_nodesdown(_,_,_,_,_,[]).
  con_nodesdown(COL,ROW,CMIN,CMAX,ROW1,[COL1|T]):-
	RR=ROW+1,
	treeline_ver(RR,ROW1,COL1),
	cornerdown(COL,CMIN,CMAX,COL1,CORNCHAR),
	scr_ch(ROW,COL1,CORNCHAR),
	con_nodesdown(COL,ROW,CMIN,CMAX,ROW1,T).

  cornerdown(MIN,MIN,_,MIN,'Ã') :- !.
  cornerdown(MAX,_,MAX,MAX,'´') :- !.
  cornerdown(_,MIN,_,MIN,'Ú') :- !.
  cornerdown(_,_,MAX,MAX,'¿') :- !.
  cornerdown(MIDT,_,_,MIDT,'Å') :- !.
  cornerdown(_,_,_,_,'Â').

/************************** END DRAW DOWN ****************************/

/****************************** DRAW UP ****************************/

PREDICATES
  draw_up(TREE,ROW,COL,COL,COL)
  draw_uplist(TREELIST,COLLIST,COLLIST,ROW,COL,COL)
  connect_nodesup(ROW,ROW,COL,ROW,COLLIST)
  con_nodesup(COL,ROW,COL,COL,ROW,COLLIST)
  cornerup(COL,COL,COL,COL,CHAR)
  check_lastup(COL,ROW,COLLIST)

CLAUSES
   
  draw_up(_,_,_,_,_):-keypressed,!,readkey(KEY),treekeyact(KEY),fail.
  draw_up(tree(NAME,SELECT,[]),CURROW,MAXCOL,NEWMAXCOL,MID):-!,
	str_len(NAME,LEN),
	NEWMAXCOL=MAXCOL+LEN+1,
	MID=MAXCOL+(LEN+1) div 2,
	writetext(CURROW,MAXCOL,112,NAME,SELECT).
  draw_up(tree(NAME,SELECT,TREELIST),CURROW,MAXCOL,NEWMAXCOL,RESCOL):-
	NEXTROW=CURROW-3,
	draw_uplist(TREELIST,[],NODECOLLIST,NEXTROW,MAXCOL,NEWMAXCOL),
	nodelistlen(NODECOLLIST,LEN),
	listsum(NODECOLLIST,SUM),
	RESCOL=SUM div LEN,
	str_len(NAME,NAMELEN), JUST=RESCOL-NAMELEN div 2,
	max(MAXCOL,JUST,NAMESTART),
	writetext(CURROW,NAMESTART,112,NAME,SELECT),
	ROW1=CURROW-1,LLEN=LEN,
	ROW2=CURROW-2,
	connect_nodesup(ROW1,ROW2,RESCOL,LLEN,NODECOLLIST),
	check_lastup(RESCOL,ROW1,NODECOLLIST).

  draw_uplist([],NODECOLLIST,NODECOLLIST,_,MAXCOL,MAXCOL).
  draw_uplist([H|T],NodeColList,ResNodeColList,CURROW,MAXCOL,MAXCOL2):-
	draw_up(H,CURROW,MAXCOL,MAXCOL1,NODECOL),
	draw_uplist(T,[NODECOL|NODECOLLIST],RESNODECOLLIST,CURROW,MAXCOL1,MAXCOL2).

  check_lastup(COL,_,[COL|_]):-!.
  check_lastup(COL,ROW,[_|LIST]):-!,check_lastup(COL,ROW,LIST).
  check_lastup(COL,ROW,_):-scr_ch(ROW,COL,'Â').

  connect_nodesup(ROW,ROW1,COL,1,_) :-!,
        R2=ROW+1,
        treeline_ver(ROW1,R2,COL).
  connect_nodesup(ROW,ROW1,COL,_,[CMAX|L]):-
        lastinlist(CMIN,[CMAX|L]),
        CC=CMIN+1,
        treeline_hor(CC,CMAX,ROW),
        con_nodesup(COL,ROW,CMIN,CMAX,ROW1,[CMAX|L]).
  
  con_nodesup(_,_,_,_,_,[]).
  con_nodesup(COL,ROW,CMIN,CMAX,ROW1,[COL1|T]):-
	treeline_ver(ROW1,ROW,COL1),
	cornerup(COL,CMIN,CMAX,COL1,CORNCHAR),
	scr_ch(ROW,COL1,CORNCHAR),
	con_nodesup(COL,ROW,CMIN,CMAX,ROW1,T).

  cornerup(MIN,MIN,_,MIN,'Ã') :- !.
  cornerup(MAX,_,MAX,MAX,'´') :- !.
  cornerup(_,MIN,_,MIN,'À') :- !.
  cornerup(_,_,MAX,MAX,'Ù') :- !.
  cornerup(MIDT,_,_,MIDT,'Å') :- !.
  cornerup(_,_,_,_,'Á').

/************************** END DRAW UP ****************************/

/* treemenu construct and display a box diagram of a tree structure */

  treemenu(DIRECTION,TREE,CHOICE) :-
  	makewindow(81,66,23,"",0,0,24,80),  /* if this makewindow is commented out the tree will 
  	                                       be drawn in the currently active window */
 	makestatus(112,"F1:Help  F10:Select  Retrn:Select  Arrows:move around  Ctrl arrows: move fast"),
	newupdate(treewindow(0,0)),
	repeat,
	remove_treechoice,
	draw(DIRECTION,TREE),
	readkey(KEY),
	treekeyact(KEY),!,
	removestatus,
	removewindow,
	not(KEY=esc),
	treechoice(CHOICE),!.
	
/* draw a tree in the selected direction */
  draw(right,TREE):-draw_right(TREE,0,_,0,_,0,5,_).
  draw(left,TREE) :-draw_left(TREE,0,_,0,_,75,5,_).
  draw(down,TREE):-draw_down(TREE,0,0,_,_).
  draw(up,TREE):-draw_up(TREE,20,0,_,_).

