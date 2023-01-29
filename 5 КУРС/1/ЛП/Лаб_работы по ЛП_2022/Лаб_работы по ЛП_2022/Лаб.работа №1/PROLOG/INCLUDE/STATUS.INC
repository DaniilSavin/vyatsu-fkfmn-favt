
 /***********************************************************************
                                                                      
     Turbo Prolog Toolbox
     (C) Copyright 1987 Borland International.                        
                                                                      
   	 	     Status Line		    			
            Uses window number 83 for a status line.			
 ***********************************************************************/

PREDICATES
  makestatus(ATTR,STRING)
  nondeterm tempstatus(ATTR,STRING)
  removestatus
  refreshstatus
  changestatus(STRING)

CLAUSES
  makestatus(ATTR,TXT):-
	shiftwindow(OLD),
	makewindow(83,ATTR,0,"",24,0,1,80),
	field_str(0,0,80,TXT),
	shiftwindow(OLD).

  tempstatus(ATTR,TXT):-makestatus(ATTR,TXT).
  tempstatus(_,_):-removestatus,fail.

  removestatus:-
	shiftwindow(OLD),
	shiftwindow(83), removewindow,
	shiftwindow(OLD).

  refreshstatus:-
	shiftwindow(OLD),
	shiftwindow(83),
	shiftwindow(OLD).

  changestatus(TXT):-
	shiftwindow(OLD),
	shiftwindow(83),
	field_str(0,0,80,TXT),
	shiftwindow(OLD).
