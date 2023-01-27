/****************************************************************

     Turbo Prolog Toolbox
     (C) Copyright 1987 Borland International.

			Report generation

****************************************************************/


DOMAINS
  FNAME=SYMBOL
  TYPE = int(); str(); real()
  VALUE	= int(INTEGER); str(STRING); real(REAL)
  FIELD = field(STRING,COL)
  FIELDLIST = FIELD*

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



/****************************************************************
		USER DEFINED PREDICATE
****************************************************************/

PREDICATES
  field_value(FNAME,STRING)


/****************************************************************
			INTERMEDIATE PREDICATES
****************************************************************/

PREDICATES
  nondeterm for(ROW,ROW,ROW)
  nondeterm txtfields(ROW,FIELD)
  nondeterm valuefields(ROW,FIELD)
  getline(ROW,STRING)
  append(FIELDLIST,FIELDLIST,FIELDLIST)
  sort(FIELDLIST,FIELDLIST,FIELDLIST)
  split(FIELDLIST,FIELD,FIELDLIST,FIELDLIST)
  list_string(FIELDLIST,STRING,STRING)

CLAUSES
  for(X,X,_).
  for(I,A,B):-B>A,A1=A+1,for(I,A1,B).

  getline(LNO,STRING):-
	findall(X1,valuefields(LNO,X1),FIELDSLIST),
	findall(X1,txtfields(LNO,X1),TXTFIELDSLIST),
	append(FIELDSLIST,TXTFIELDSLIST,LIST),
	sort(LIST,[],LIST1),
	list_string(LIST1,"",STRING).

  txtfields(LNO,field(S,COL)):-txtfield(LNO,COL,_,S).

  valuefields(LNO,field(S,COL)):-
	field(FNAME,_,LNO,COL,_),
	field_value(FNAME,S).

  append([],L,L).
  append([X|L1],L2,[X|L3]):-append(L1,L2,L3).  

  sort( [HEAD|TAIL], SORTEDBIGGER, RESULT )	:-
	split( TAIL, HEAD, LESSLIST, BIGGERLIST ),
	sort( BIGGERLIST, SORTEDBIGGER, NEWSORTEDBIGGER ),
	sort( LESSLIST, [HEAD|NEWSORTEDBIGGER], RESULT ).
  sort( [], SORTED, SORTED ).
    
  split([],_,[],[]).
  split([field(S,Y)|L],field(S1,X),[field(S,Y)|L1],L2):-
		Y<X,!,split(L,field(S1,X),L1,L2).
  split([field(S,Y)|L],field(S1,X),L1,[field(S,Y)|L2]):-
	split(L,field(S1,X),L1,L2).

  list_string([field(S,COL)|T],IN,OUT):-
	str_len(IN,LEN),LEN<=COL,!,
	ADD=COL-LEN,
	str_len(ADDS,ADD),
	concat(IN,ADDS,IN1),
	concat(IN1,S,IN2),
	list_string(T,IN2,OUT).
  list_string([field(S,COL)|T],IN,OUT):-
	frontstr(COL,IN,IN1,_),
	concat(IN1,S,IN2),
	list_string(T,IN2,OUT).
  list_string([],S,S).

PREDICATES
  report(ROW)

CLAUSES
  report(LINES):-
	for(NO,1,LINES),getline(NO,STR),write(STR),nl,fail.
  report(_).
