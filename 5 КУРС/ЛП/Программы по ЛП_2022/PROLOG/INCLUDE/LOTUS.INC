/************************************************************

     Turbo Prolog Toolbox
     (C) Copyright 1987 Borland International.

	Access a Lotus 1-2-3 (TM) & Symphony (TM) compatible file
	from Prolog

*************************************************************/

Domains
/*************************************************************
	Prolog data base
*************************************************************/

  LotusRecL	= LotusRec*
  LotusRec	= version(Integer);	/* Version number */
  		  elem(Integer,Integer,Value);
  		  endFile
  Value		= int(Integer);		/* Integer number cell */
  		  real(Real);		/* Real number cell */
  		  formula(Real);	/* Defines a formula cell */
  		  label(String);	/* Defines a label cell */
  		  endFile
  
PREDICATES
  /* Read predicates */
  rd_LotusFile(LotusRecL)
  rd_LotusFile2(LotusRec,LotusRecL)
  rd_LotusRec(LotusRec)
  rd_LotusRec2(Integer,LotusRec)
  rd_Lotuscell(LotusRec)

CLAUSES
/*************************************************************
	Read data records
*************************************************************/

  rd_LotusFile(RecL):-rd_LotusRec(Rec), !, rd_LotusFile2(Rec,RecL).
  rd_LotusFile(RecL):-readdevice(FP),not(eof(FP)), !, rd_LotusFile(RecL).
  rd_LotusFile([]).

  rd_LotusFile2(endFile,[]):-!.
  rd_LotusFile2(Rec,[Rec|RecL]):-rd_LotusFile(RecL).
	
/*************************************************************
	Read a single record
*************************************************************/

  rd_LotusRec(Rec):-read_int(Opcode), rd_LotusRec2(Opcode,Rec).

  rd_LotusRec2(0,version(Ver)):-!,ignore(2), read_int(Ver).
  rd_LotusRec2(1,endFile):-!,ignore(2).
  rd_LotusRec2(13,elem(Row,Col,int(Int))):-!,
	ignore(3), read_int(Col), read_int(Row), read_int(Int).
  rd_LotusRec2(14,elem(Row,Col,real(Real))):-!,
	ignore(3), read_int(Col), read_int(Row), read_real(Real).
  rd_LotusRec2(16,elem(Row,Col,formula(Real))):-!,
	ignore(3), read_int(Col), read_int(Row), read_real(Real),
	read_int(FormulaLen), ignore(FormulaLen).
  rd_LotusRec2(15,elem(Row,Col,label(Str))):-!,
	ignore(3), read_int(Col), read_int(Row), ignore(1), /* alignment */
	read_str(Str).
  rd_LotusRec2(_,_):-read_int(Len), ignore(Len), fail.


/*************************************************************
	Read a record placed in a certain position
	Samples : 
	-	rd_Lotuscell(Rec)	- (i),(o)
	-	rd_Lotuscell(elem(Row,Col,Value)) - (i,i,i),
		(i,i,o), ... , (o,o,o)
*************************************************************/

  rd_Lotuscell(Rec):-
	rd_LotusRec(Rec2),Rec=Rec2.
  rd_Lotuscell(Rec):-
	readdevice(FP), not(eof(FP)), rd_Lotuscell(Rec).
