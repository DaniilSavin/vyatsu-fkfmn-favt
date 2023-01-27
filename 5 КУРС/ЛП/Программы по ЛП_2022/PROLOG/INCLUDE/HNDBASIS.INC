
 /*******************************************************************
                                                                  
     Turbo Prolog Toolbox
     (C) Copyright 1987 Borland International.                    
                                                                  
 			HNDBASIS				  
  This sample shows the minimum structure of a program using the  
  screen handlers.						    
 *******************************************************************/



 /*******************************************************************/
 /*			Domains					    */
 /*******************************************************************/

include "tdoms.inc"

DOMAINS
  FNAME=SYMBOL
  TYPE = int(); str(); real()

 /*******************************************************************/
 /*			Database predicates			    */
 /*******************************************************************/

DATABASE
  /* Database declarations used in scrhnd */
  insmode			/* Global insertmode */
  actfield(FNAME)		/* Actual field */
  screen(SYMBOL,DBASEDOM)	/* Saving different screens */
  value(FNAME,STRING)		/* value of a field */
  field(FNAME,TYPE,ROW,COL,LEN) /* Screen definition */
  txtfield(ROW,COL,LEN,STRING)
  windowsize(ROW,COL).
  notopline

  /* DATABASE PREDICATES USED BY VSCRHND */
  windowstart(ROW,COL)
  mycursord(ROW,COL)

  /* Database declarations used in lineinp */
  lineinpstate(STRING,COL)
  lineinpflag


 /*******************************************************************/
 /*			Include tools				    */
 /*******************************************************************/

include "tpreds.pro"
include "menu.pro"
include "status.pro"
include "lineinp.pro"
include "scrhnd.pro"	/* Or vscrhnd.pro */

CLAUSES
/*******************************************************************
			Field action
*******************************************************************/

  field_action(_):-fail.
  
/*******************************************************************
			 Field_value
*******************************************************************/

  field_value(FNAME,VAL):-value(FNAME,VAL),!.

/*******************************************************************
			 noinput
*******************************************************************/

  noinput(_):-fail.
