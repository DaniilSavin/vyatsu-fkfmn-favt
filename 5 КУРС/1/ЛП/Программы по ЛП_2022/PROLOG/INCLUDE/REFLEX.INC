/************************************************************

     Turbo Prolog Toolbox
     (C) Copyright 1987 Borland International.

  	Access a Reflex(R) compatible data base file
  	from Prolog

*************************************************************/

Domains
/*************************************************************
  	Prolog data base
*************************************************************/

  ReflexBase	= reflex(FldNames,ReflexRecL)
  FldNames	= String*		/* Field names */
  ReflexRecL	= ReflexRec*		/* Record list */
  ReflexRec	= ReflexElem*		/* A record is a list of elements */
  ReflexElem	= date(Integer);	/* 16-bit int. representing number of
  					   days since December 31, 1899 */
  		  real(Real);		/* 64-bit IEEE floating point */
  		  int(Integer);		/* 16-bit signed integer */
  		  text(String);		/* A string representing a text */
  		  untyped;		/* No data stored */
  		  error

  ReflexTypeL	= ReflexType*
  ReflexType	= u; t; rt; d; r; i
  TxtPools	= Txtpool*
  TxtPool	= RepTxt*
  RepTxt	= txt(Integer,String)
  IntegerL	= Integer*
  FilePos	= Real

PREDICATES
/* Initialize access */
  Init_Reflex(Integer,FldNames,ReflexTypeL,TxtPools)

/* Header of reflex file */
  rd_ReflexHeader

/* Global sort declaration */
  rd_GlobalSort

/* Read Field Directory Table */
  rd_FldDirTable(FldNames,ReflexTypeL,TxtPools)
  rd_FldNames(FldNames,Integer)
  rd_FldNames2(Integer,FldNames).
  rd_indxL(Integer,IntegerL)

  rd_fldTypes(Integer,ReflexTypeL,Integer)
  rd_fldDesc(Integer,ReflexTypeL,Integer,Integer)
  convert_type(Char,ReflexType)
  chk_RepTxt(CHAR,Integer,Integer)

  rd_RepTxt(Integer,TxtPools)
  rd_TxtPools(Integer,TxtPools)
  rd_TxtPool(Integer,Integer,Integer,IntegerL,TxtPool)

/* Read Data record sections */
  rd_ReflexFile(Integer,ReflexTypeL,TxtPools,ReflexRecL)
  rd_ReflexRecs2(Integer,ReflexTypeL,TxtPools,ReflexRecL)
  rd_ReflexRec1(ReflexTypeL,TxtPools,FilePos,ReflexRec)
  rd_Reflexelem(ReflexType,TxtPools,TxtPools,FilePos,ReflexElem)
  lookup_indx(Integer,TxtPool,String)
  get_newindx(Integer,Integer,Integer,IntegerL)

/* Sequential access */
  rd_ReflexRec(Integer,ReflexTypeL,TxtPools,ReflexRec)
  reverse(TxtPools,TxtPools,TxtPools)

CLAUSES
  Init_Reflex(TotRecs,FldNames,TypeL,TxtPools) :-
  	rd_ReflexHeader, Rd_GlobalSort,
        rd_FldDirTable(FldNames,TypeL,TxtPools),
        read_int(TotRecs),ignore(4).
  	

/*************************************************************
  	Read header of a Reflex(R) file
  	 (We actually ignore it)
*************************************************************/

  rd_ReflexHeader :-
  	read_int(HdrSz), Size=HdrSz-2,
  	ignore(Size).

/*************************************************************
  	Read Global Sort Declarations
  	 (We actually ignore it)
*************************************************************/

  rd_GlobalSort :- ignore(12).

/*************************************************************
  	Read Field Directory Table
*************************************************************/

  rd_FldDirTable(FldNames,TypeL,Reptxt) :-
  	rd_FldNames(FldNames,NoofFld),
  	rd_FldTypes(NoofFld,TypeL,NoofRepTxt),
  	rd_RepTxt(NoofReptxt,RepTxt).

  rd_FldNames(FldNames,NoofIndx) :-
  	read_int(IndxLen), NoofIndx=IndxLen/2,
  	rd_indxL(NoofIndx,_/*IndxL*/),
  	ignore(2),	/* Field Name pool length */
  	rd_FldNames2(NoofIndx,FldNames).

  rd_FldNames2(0,[]) :- !.
  rd_FldNames2(Indx,[FldName|Tail]) :-
  	read_str(FldName), Indx2=Indx-1,
  	rd_FldNames2(Indx2,Tail).

  rd_fldTypes(NoofFld,TypeL,NoofRepTxt) :-
  	ignore(2), /* Filed descriptor table len */
  	rd_fldDesc(NoofFld,TypeL, 0,NoofRepTxt).

  rd_fldDesc(0,[],NoofRepTxt,NoofRepTxt) :-!.
  rd_fldDesc(N,[Type|TypeL],CurNoofRepTxt,NoofRepTxt) :-
  	ignore(2),	/* Name indx */
  	read_char(T), chk_RepTxt(T,CurNoofRepTxt,RepTxt2),
  	convert_Type(T,Type),
  	ignore(13), /* Format,FldOffset, ETREC, Sort position */
  	N2 = N-1,
  	rd_fldDesc(N2,TypeL,RepTxt2,NoofRepTxt).

  chk_RepTxt('\002',N,N2) :- !,N2=N+1.
  chk_RepTxt(_,N,N).

  convert_type('\000',u).
  convert_type('\001',t).
  convert_type('\002',rt).
  convert_type('\003',d).
  convert_type('\004',r).
  convert_type('\005',i).

  rd_RepTxt(NoofReptxt,RepTxt) :-
  	ignore(6),	/* Default formats */
  	rd_TxtPools(NoofReptxt,RepTxt1),
  	reverse(RepTxt1,[],RepTxt).

  rd_TxtPools(0,[]) :-!.
  rd_TxtPools(N,[TxtPool|Tail]) :-
  	read_int(IndxLen), NoofIndx=IndxLen/2,
  	rd_indxL(NoofIndx,IndxL),
  	read_int(TxtPoolLen), PoolLen=TxtPoolLen-3,
  	ignore(3),	/* freelist hdr */
  	rd_TxtPool(PoolLen,ToSkip, 5, IndxL,TxtPool),
  	ignore(ToSkip), N2=N-1,
  	rd_TxtPools(N2,Tail).

  rd_TxtPool(PoolLen,ToSkip,CurIndx,IndxL,[txt(Indx,Txt)|TxtPool]) :-
  	get_newindx(CurIndx,32767,Indx,IndxL),!,
  	IndxDiff=Indx-CurIndx, ignore(IndxDiff),
  	ignore(2),	/* Reference count */
  	read_str(Txt),
  	str_len(Txt,Slen), ToSkip2=PoolLen-IndxDiff-Slen-3,
  	Indx2 = Indx + 2 + Slen+1,
  	rd_TxtPool(ToSkip2,ToSkip,Indx2,IndxL,TxtPool).

  rd_TxtPool(ToSkip,ToSkip,_,_,[]) :-!.

  get_newindx(_,Newindx,NewIndx,[]) :- NewIndx<>32767.
  get_newindx(CurIndx,CurNewindx,NewIndx,[CI2|Tail]) :-
  	CI2<CurNewIndx, CI2>=CurIndx,!,
  	get_newIndx(CurIndx,CI2,NewIndx,Tail).

  get_newindx(CurIndx,CurNewindx,NewIndx,[_|Tail]) :-
  	get_newIndx(CurIndx,CurNewindx,NewIndx,Tail).
  	

/*************************************************************
  	Read Data record sections
*************************************************************/

  rd_ReflexFile(TotRecs,TypeL,TxtPools,ReflexRecs):-
  	/* Master Record section */
  	rd_ReflexRecs2(TotRecs,TypeL,TxtPools,ReflexRecs).

  rd_ReflexRecs2(0,_,_,[]) :-!.
  rd_ReflexRecs2(N,TypeL,TxtPools,[ReflexRec|Tail]) :-
  	read_int(RecLen),
  	readdevice(FP),
  	filepos(FP,StartPos,0),
  	ignore(4),	/* Skip Record hdr. */
  	rd_ReflexRec1(TypeL,TxtPools,StartPos,ReflexRec),
  	N2 = N-1, FilePos2=StartPos+RecLen,
  	filepos(FP,FilePos2,0),
  	rd_ReflexRecs2(N2,TypeL,TxtPools,Tail).

  rd_ReflexRec1([],_,_,[]) :-!.
  rd_ReflexRec1([Type|TypeL],TxtPools,StartPos,[Elem|ElemL]) :-
  	rd_Reflexelem(Type,TxtPools,TxtPools2,StartPos,Elem),
  	rd_ReflexRec1(TypeL,TxtPools2,StartPos,ElemL).

  rd_Reflexelem(u,TxtPools,TxtPools,_,untyped).
  rd_Reflexelem(t,Txtpools,TxtPools,StartPos,text(Str)) :-
  	readdevice(FP),
  	read_int(TxtIndx),
  	filepos(FP,CurPos,0), 
  	NewPos=StartPos+TxtIndx, filepos(Fp,NewPos,0),
  	read_str(Str), filepos(Fp,CurPos,0).

  rd_Reflexelem(rt,[TxtPool|Txtpools],TxtPools,_,text(Str)) :-
  	read_int(TxtIndx), lookup_indx(TxtIndx,TxtPool,Str).

  rd_Reflexelem(d,Txtpools,TxtPools,_,date(Date)) :- read_int(Date).
  rd_Reflexelem(r,Txtpools,TxtPools,_,real(Real)) :- read_real(Real).
  rd_Reflexelem(i,Txtpools,TxtPools,_,int(Int))   :- read_int(Int).

  lookup_indx(Indx,[txt(Indx,Str)|_],Str) :- !.
  lookup_indx(Indx,[_|Txts],Str) :- lookup_indx(Indx,Txts,Str).

/*************************************************************
  	Read data record sequentially
*************************************************************/

  rd_ReflexRec(0,_,_,_) :-!,fail.
  rd_ReflexRec(_,TypeL,TxtPools,ReflexRec) :-
  	read_int(RecLen),
  	readdevice(FP),
  	filepos(FP,StartPos,0),
  	ignore(4),	/* Skip Record hdr. */
  	rd_ReflexRec1(TypeL,TxtPools,StartPos,ReflexRec),
  	FilePos2=StartPos+RecLen,
  	filepos(FP,FilePos2,0).
  rd_ReflexRec(N,TypeL,TxtPools,ReflexRec) :-
  	N2 = N-1, rd_ReflexRec(N2,TypeL,TxtPools,ReflexRec).

  reverse([],L,L) :- !.
  reverse([H|T],OldL,NewL) :-	reverse(T,[H|OldL],NewL).

  rd_indxL(0,[]) :- !.
  rd_indxL(N,[V|Tail]) :-	read_int(V), N2=N-1, rd_indxL(N2,Tail).
