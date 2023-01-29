 /***********************************************************************
                                                                     
    Turbo Prolog Toolbox
    (C) Copyright 1987 Borland International.                        
                                                                     
		Read filename		   				
									
    readfilename(ROW,COL,ATTR,EXTENSION,OLDFILENAME,NEWFILENAME)	
 ***********************************************************************/

/* These declarations and inclusions are necessary to try filename 

DOMAINS
include "c:\\prolog\\include\\tdoms.inc"

DATABASE
  insmode
  lineinpstate(STRING,COL)
  lineinpflag

include "c:\\prolog\\include\\tpreds.inc"
include "c:\\prolog\\include\\lineinp.inc"
*/

PREDICATES
  readfilename(ROW,COL,ATTR,ATTR,STRING,STRING,STRING)
  readfilename1(ROW,COL,ATTR,ATTR,STRING,STRING,STRING)
  readfilename2(ROW,COL,ATTR,ATTR,STRING,STRING)
  newext(STRING,STRING,STRING)
  extentfilename(STRING,STRING,STRING)
  splitfilename(STRING,STRING,STRING)
  search_char(CHAR,STRING,INTEGER,INTEGER)
  concatlist(STRINGLIST,STRING)

CLAUSES
  readfilename(ROW,COL,WATTR,FATTR,EXT,OLD,FILENAME):-
	concatlist(["File name (.",EXT,"): "],TXT),
	lineinput_repeat(ROW,COL,40,WATTR,FATTR,TXT,OLD,NAME),
	readfilename1(ROW,COL,WATTR,FATTR,EXT,NAME,FNAME),!,
	removewindow,
	extentfilename(FNAME,EXT,FILENAME).

  readfilename1(ROW,COL,WATTR,FATTR,EXT,"",FILENAME):-!,
	ROW2=ROW+3,
	readfilename2(ROW2,COL,WATTR,FATTR,EXT,FILENAME).
  readfilename1(_,_,_,_,_,NAME,NAME).

  readfilename2(ROW,COL,WATTR,FATTR,EXT,FILENAME):-
	adjustwindow(ROW,COL,10,50,ROW1,COL1),
	makewindow(81,WATTR,FATTR,"",ROW1,COL1,10,50),
	concat("*.",EXT,EXT1),
	dir("",EXT1,FILENAME),!,
	removewindow.
  readfilename2(_,_,_,_,_,_):-removewindow,fail.

/* replace old extension with the new extension */
  newext(OLD,EXT,NEW):-
	splitfilename(OLD,NAME,_),
	concatlist([NAME,".",EXT],NEW).

  extentfilename(OLDNAME,EXT,FILENAME):-
	splitfilename(OLDNAME,NAME,OLDEXT), OLDEXT="",!,
	concatlist([NAME,".",EXT],FILENAME).
  extentfilename(NAME,_,NAME).

/* parse file name string for name and extension */
  splitfilename(FILENAME,NAME,EXT):-
	search_char('.',FILENAME,0,N),
	frontstr(N,FILENAME,NAME,REST),
	frontchar(REST,_,EXT),!.
  splitfilename(NAME,NAME,"").

  search_char(CH,STR,N,N) :-frontchar(STR,CH,_),!.
  search_char(CH,STR,N,N2) :-
         frontchar(STR,_,STR1),
         N1=N+1,
         search_char(CH,STR1,N1,N2).

  concatlist([],"").
  concatlist([H|T],S):-
	concatlist(T,S1),
	concat(H,S1,S).


 /***********************************************************************/
 /*		SET/CHANGE DIRECTORY	   				*/
 /***********************************************************************/

PREDICATES
  setdir(ROW,COL,ATTR,ATTR)/* Make a window and prompt the user with the current
                              directory and set the new directory to the new value 
                              if possable. */
  newdisk(STRING)          /* change directory to DISK if it exists or return an error 
                              message */
CLAUSES
  setdir(ROW,COL,WATTR,FATTR):-
	disk(DISK),
	lineinput_repeat(ROW,COL,45,WATTR,FATTR,"Directory: ",DISK,NEWDISK),
	newdisk(NEWDISK),!,
	removewindow.
  setdir(_,_,_,_).

  newdisk(DISK):-disk(DISK),!.
  newdisk(_):-	makewindow(1,7,7,"",10,30,4,45),
		write(">> Error in directory name"),nl,
		write("   - Press any key"),
		readkey(_),
		removewindow,
		fail.
