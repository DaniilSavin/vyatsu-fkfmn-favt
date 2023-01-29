
/************************************************************************
                                                                      
     Turbo Prolog Toolbox
     (C) Copyright 1987 Borland International.                        
                                                                      
		           resizewindow					
 Re-sizes a given window						
									
 writescr should be defined in the program if the screen has		
 to be refreshed during resizing of the window.   	        	
									
 resizewindow updates the 'windowsize' database predicate		
									
************************************************************************/

PREDICATES
%  resizewindow
  resizewindow1(KEY,ROW,COL,ROW,COL,ROW,COL,ROW,COL)
  resizewindow3(ROW,COL,ROW,COL,ROW,COL,ROW,COL)
  resizewindow4(ROW,COL,ROW,COL,ROW,COL,ROW,COL)
  chngwindsize(ROW,COL)
  writescr

CLAUSES
/*  resizewindow:-
	makewindow(NR,WA,FA,HEAD,SR,SC,RR,CC),
	removewindow,
	makestatus(112,"  F10:End   Arrows:Resize window   Ctrl Arrows:Fast resize   Shift Arrows:Move"),
	makewindow(NR,7,112,"RESIZE WINDOW",SR,SC,RR,CC),
	repeat,
	makewindow(_,_,_,_,SR1,SC1,RR1,CC1),
	refreshstatus,	/* Updates the status line */
	writescr,	/* Updates the content of the window */
	readkey(KEY),   /* Returns a symbolic key from the KEY domain. in TPREDS.PRO */
	resizewindow1(KEY,RR1,CC1,RR2,CC2,SR1,SC1,SR2,SC2),
	removewindow,
	makewindow(NR,7,112,"RESIZE WINDOW",SR2,SC2,RR2,CC2),
	ROWS=RR2-3, COLS=CC2-3,
	chngwindsize(ROWS,COLS),
	KEY=fkey(10),
	removewindow,
	removestatus,
	makewindow(NR,WA,FA,HEAD,SR2,SC2,RR2,CC2),!.

/*  resizewindow1(KEY,RR1,CC1,RR2,CC2,SR1,SC1,SR2,SC2), */
  resizewindow1(char('7'),RR,CC,RR,CC,SR,_,SR,0).  	     /* move Home  */
  resizewindow1(char('1'),RR,CC,RR,CC,SR,_,SR,SC):-SC=80-CC. /* move End   */
  resizewindow1(char('9'),RR,CC,RR,CC,_,SC,0,SC).            /* move PgUp  */
  resizewindow1(char('3'),RR,CC,RR,CC,_,SC,SR,SC):-SR=25-RR. /* move PgDn  */

  resizewindow1(home,RR,CC1,RR,CC2,SR,SC1,SR,0):-CC2=SC1+CC1. /* enlarge to Home */ 
  resizewindow1(end,RR,_,RR,CC,SR,SC,SR,SC):-CC=80-SC.        /* enlarge to End */ 
  resizewindow1(pgup,RR1,CC,RR2,CC,SR1,SC,0,SC):-RR2=SR1+RR1. /* enlarge to top of page */ 
  resizewindow1(pgdn,_,CC,RR,CC,SR,SC,SR,SC):-RR=25-SR.       /* enlarge to bottom of page */ 

  resizewindow1(char('8'),RR,CC,RR,CC,SR1,SC1,SR2,SC2):-  /* move up  */
	resizewindow4(-1,0,RR,CC,SR1,SC1,SR2,SC2).
  resizewindow1(char('2'),RR,CC,RR,CC,SR1,SC1,SR2,SC2):-  /* move down  */
	resizewindow4(1,0,RR,CC,SR1,SC1,SR2,SC2).
  resizewindow1(char('6'),RR,CC,RR,CC,SR1,SC1,SR2,SC2):-  /* move right  */
	resizewindow4(0,1,RR,CC,SR1,SC1,SR2,SC2).
  resizewindow1(char('4'),RR,CC,RR,CC,SR1,SC1,SR2,SC2):-  /* move left  */
	resizewindow4(0,-1,RR,CC,SR1,SC1,SR2,SC2).
  resizewindow1(up,RR,CC,RR1,CC1,SR,SC,SR,SC):-           /* enlarge to up */ 
	resizewindow3(-1,0,RR,CC,RR1,CC1,SR,SC).
  resizewindow1(down,RR,CC,RR1,CC1,SR,SC,SR,SC):-         /* enlarge to down */ 
	resizewindow3(1,0,RR,CC,RR1,CC1,SR,SC).
  resizewindow1(right,RR,CC,RR1,CC1,SR,SC,SR,SC):-        /* enlarge to right */ 
	resizewindow3(0,1,RR,CC,RR1,CC1,SR,SC).
  resizewindow1(left,RR,CC,RR1,CC1,SR,SC,SR,SC):-         /* enlarge to left */ 
	resizewindow3(0,-1,RR,CC,RR1,CC1,SR,SC).
  resizewindow1(ctrlright,RR,CC,RR1,CC1,SR,SC,SR,SC):-    /* enlarge to right 5 lines */ 
	resizewindow3(0,5,RR,CC,RR1,CC1,SR,SC).
  resizewindow1(ctrlleft,RR,CC,RR1,CC1,SR,SC,SR,SC):-     /* enlarge to left 5 lines */ 
	resizewindow3(0,-5,RR,CC,RR1,CC1,SR,SC).
  resizewindow1(fkey(10),R,C,R,C,SR,SC,SR,SC).            /* explode window */
  resizewindow1(fkey(30),_,_,25,80,_,_,0,0).

  resizewindow3(DR,DC,ROW,COL,RR2,CC2,SR,SC):-
	RR=DR+ROW, CC=DC+COL,
	MAXROWS=25-SR, MAXCOLS=80-SC,
	min(MAXROWS,RR,RR1), max(3,RR1,RR2),
	min(MAXCOLS,CC,CC1), max(10,CC1,CC2).

  resizewindow4(DR,DC,RR,CC,SR1,SC1,SR2,SC2):-
	R1=DR+SR1, C1=DC+SC1,
	MAXROW=25-RR, MAXCOL=80-CC,
	min(MAXROW,R1,R11), max(0,R11,SR2),
	min(MAXCOL,C1,C11), max(0,C11,SC2).
*/
  chngwindsize(_,_):-retract(windowsize(_,_)),fail.
  chngwindsize(R,C):-assert(windowsize(R,C)).
