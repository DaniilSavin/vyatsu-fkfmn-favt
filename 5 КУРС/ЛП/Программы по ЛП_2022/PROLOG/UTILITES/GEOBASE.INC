/****************************************************************/
/*			Help predicates				*/
/****************************************************************/

PREDICATES
  maxlen(LIST,INTEGER,INTEGER)		/* Find the length of the longest string */
  listlen(LIST,INTEGER)			/* Find the length of a list */
  writelist(INTEGER,INTEGER,LIST)	/* Used by the menu predicate */
  write_list(INTEGER,LIST)		/* Write the list separated by spaces */
  write_list2(LIST)			/* Display an answer */
  append(LIST,LIST,LIST)		/* append two lists */
  unik(LIST,LIST)			/* Eliminate duplicates in a list */
  repeat				/* Make backtrack points */
  index(LIST,INTEGER,SYMBOL)		/* Select an element from a list */

CLAUSES
  index([X|_],1,X):- !.
  index([_|L],N,X):- N>1,N1=N-1,index(L,N1,X).

  unik([],[]).
  unik([H|T],L):-member(H,T),!,unik(T,L).
  unik([H|T],[H|L]):-unik(T,L).

  append([],L,L).
  append([Ah|At],B,[Ah|C]):-append(At,B,C).

  maxlen([H|T],MAX,MAX1):-
		str_len(H,LEN),
		LEN>MAX,!,
		maxlen(T,LEN,MAX1).
  maxlen([_|T],MAX,MAX1):-maxlen(T,MAX,MAX1).
  maxlen([],LEN,LEN).

  listlen([],0).
  listlen([_|T],N):-
		listlen(T,X),
		N=X+1.

  writelist(_,_,[]).
  writelist(LI,ANTKOL,[H|T]):-field_str(LI,0,ANTKOL,H),
		LI1=LI+1,writelist(LI1,ANTKOL,T).

  repeat. repeat:-repeat.

  write_list(_,[]).
  write_list(_,[X]):-!,write(X).
  write_list(4,[H|T]):-!,write(H),nl,write_list(0,T).
  write_list(3,[H|T]):-str_len(H,LEN),LEN>13,!,write(H),nl,write_list(0,T).
  write_list(N,[H|T]):-str_len(H,LEN),LEN>13,!,N1=N+2,writef("%-27 ",H),write_list(N1,T).
  write_list(N,[H|T]):-N1=N+1,writef("%-13 ",H),write_list(N1,T).

  write_list2([]).
  write_list2([H|T]):-write(H,' '),write_list2(T).


/************************************************************************/
/*	     READING QUERIES						*/
/************************************************************************/

DOMAINS
  /* Seven types of questions are recognized */
  QUERY	=	q_e(SYMBOL) ;
		q_eaec(SYMBOL,SYMBOL,SYMBOL,SYMBOL) ;
		q_eaq(SYMBOL,SYMBOL,SYMBOL,QUERY) ;
		q_sel(SYMBOL,SYMBOL,SYMBOL,REAL);
		q_min(SYMBOL,QUERY);
		q_max(SYMBOL,QUERY);
		q_not(SYMBOL,QUERY) ;
		q_or(QUERY,QUERY) ;
		q_and(QUERY,QUERY)

PREDICATES
  /* Input-output */
  loop(SYMBOL)			/* Main loop */
  readquery(SYMBOL)
  write_unit(SYMBOL)		/* Write the unit for an entity */
  write_solutions(INTEGER)	/* Write the number of solutions */

  /* Scanner */
  scan(SYMBOL,LIST)		/* Convert a string to a list of words */
  filter(LIST,LIST)		/* eliminate commas and periods	*/

  /* Parser */
  pars(LIST,SYMBOL,QUERY)

  /* Evaluation */
  eval(QUERY,SYMBOL)


CLAUSES
  loop(STR):-	STR >< "",
  		scan(STR,LIST),               /* Returns a list of words(symbols)           */
		filter(LIST,LIST1),           /* Removes punctuation and words to be ignored*/
		pars(LIST1,E,Q),              /* Parses querries                            */
		findall(A,eval(Q,A),L),
		unik(L,L1),
		write_list(0,L1),
		write_unit(E),
		listlen(L1,N),
		write_solutions(N),
		fail.

  loop(STR):-	STR >< "",readquery(L),loop(L).

  readquery(QUERY):-nl,nl,write("Query: "),readln(QUERY).
  

  scan(STR,[TOK|LIST]):-
		fronttoken(STR,SYMB,STR1),!,
		upper_lower(SYMB,TOK),
		scan(STR1,LIST).
  scan(_,[]).

 
  filter(["."|T],L):-	!,filter(T,L).
  filter([","|T],L):-	!,filter(T,L).
  filter(["?"|T],L):-	!,filter(T,L).
  filter([H|T],L):-	ignore(H),!,filter(T,L).
  filter([H|T],[H|L]):-	filter(T,L).
  filter([],[]).

  write_unit(E):-unit(E,UNIT),!,write(' ',UNIT).
  write_unit(_).

  write_solutions(0):-!,write("\nNo solutions").
  write_solutions(1):-!.
  write_solutions(N):-!,writef("\n% Solutions",N).


/************************************************************************/
/*	   		  ENTITY NAMES					*/
/************************************************************************/

PREDICATES
  entn(SYMBOL,SYMBOL)		/* Convert an entity to singularis */
  entity(SYMBOL)		/* Get all entities */
  ent_synonym(SYMBOL,SYMBOL)	/* Synonyms for entities */
  ent_name(SYMBOL,SYMBOL)	/* Convert between an entity 
				   name and an internal entity name */

CLAUSES
  ent_synonym(E,ENT):-synonym(E,ENT).
  ent_synonym(E,E).

  ent_name(ENT,NAVN):-entn(E,NAVN),ent_synonym(E,ENT),entity(ENT).

  entn(E,N):-concat(E,"s",N).
  entn(E,N):-free(E),bound(N),concat(X,"ies",N),concat(X,"y",E).
  entn(E,E).

  entity(name).
  entity(continent).
  entity(X):-relat(_,ATTL),member(X,ATTL).



/************************************************************************/
/*			Error detection					*/
/************************************************************************/

PREDICATES
  error(LIST)
  known_word(SYMBOL)

CLAUSES
  error(LIST):-	write(">> "),member(Y,LIST),not(known_word(Y)),!,
		write("Unknown word: ",Y),nl.

  error(_):-	write("Sorry, the sentence can't be recognized").

  known_word(X):-str_real(X,_),!.
  known_word("and"):-!.
  known_word("or"):-!.
  known_word("not"):-!.
  known_word("all"):-!.
  known_word("thousand"):-!.
  known_word("million"):-!.
  known_word(X):-min(X),!.
  known_word(X):-max(X),!.
  known_word(X):-big(_,X),!.
  known_word(X):-ignore(X),!.
  known_word(X):-unit(_,X),!.
  known_word(X):-assoc(_,AL),member(X,AL),!.
  known_word(X):-ent_name(_,X),!.
  known_word(X):-entity(X),!.
  known_word(X):-relop(L,_),member(X,L),!.
  known_word(X):-entity(E),not(unit(E,_)),ent(E,X).


/************************************************************************/
/*	     		PARSER						*/
/************************************************************************/

PREDICATES			/* Read a compound entity (new york) */
  check(LIST)
  get_ent(LIST,LIST,SYMBOL)
  get_cmpent(LIST,LIST,STRING,STRING)
  ent_end(LIST)

CLAUSES
  check([]).	/* Check that the list is empty */

  get_ent([E|S],S,E):-ent_end(S),!.
  get_ent(S1,S2,ENT):-get_cmpent(S1,S2," ",E1),frontchar(E1,_,E),ENT=E.
  
  get_cmpent([E|S],S,IND,ENT):-ent_end(S),concat(IND,E,ENT).
  get_cmpent([E|S1],S2,IND,ENT):-
		concat(IND,E,II),concat(II," ",III),
		get_cmpent(S1,S2,III,ENT).

  ent_end([]).
  ent_end(["and"|_]).
  ent_end(["or"|_]).


PREDICATES
  s_rel(LIST,LIST,SYMBOL)
  s_unit(LIST,LIST,SYMBOL)
  s_val(LIST,LIST,REAL)

CLAUSES
  s_rel(S1,S2,REL):-relop(RLIST,REL),append(RLIST,S2,S1).
    
  s_unit([UNIT|S],S,UNIT).
  s_val([X,thousand|S],S,VAL):-	!,str_real(X,XX),VAL=1000*XX.
  s_val([X,million|S],S,VAL):-	!,str_real(X,XX),VAL=1000000*XX.
  s_val([X|S],S,VAL):-		str_real(X,VAL).

 /* Here begins the parser. The first two parameters for the parsing
   predicates are the inputlist and what remains of the list
   after a part of a query is stripped off. In the last parameter, a
   structure for the query is built up.

   This method is called "parsing by difference lists." Once you understand
   how it works, you can easily add new sentence constructions to the language.
*/

PREDICATES
  s_attr(LIST,LIST,SYMBOL,QUERY)
  s_minmax(LIST,LIST,SYMBOL,QUERY)
  s_rest(LIST,LIST,SYMBOL,QUERY)
  s_or(LIST,LIST,SYMBOL,QUERY)
  s_or1(LIST,LIST,SYMBOL,QUERY,QUERY)
  s_and(LIST,LIST,SYMBOL,QUERY)
  s_and1(LIST,LIST,SYMBOL,QUERY,QUERY)
  s_elem(LIST,LIST,SYMBOL,QUERY)
  s_assoc(LIST,LIST,SYMBOL,QUERY)
  s_assoc1(LIST,LIST,SYMBOL,SYMBOL,QUERY)
  s_nest(LIST,LIST,SYMBOL,QUERY)
  get_assoc(LIST,LIST,SYMBOL) 

CLAUSES
  pars(LIST,E,Q):-s_attr(LIST,OL,E,Q),check(OL),!.
  pars(LIST,_,_):-error(LIST),fail.

  /* How big is the city new york -- BIG ENTITY CONSTANT */
  s_attr([BIG,ENAME|S1],S2,E1,q_eaec(E1,A,E2,X)):-
		big(E2,BIG),ent_name(E2,ENAME),
		entitysize(E2,E1),schema(E1,A,E2),
		get_ent(S1,S2,X),!.
  
  /* How big is new york -- BIG CONSTANT */
  s_attr([BIG|S1],S2,E1,q_eaec(E1,A,E2,X)):-
		get_ent(S1,S2,X),
		big(E2,BIG),entitysize(E2,E1),
		schema(E1,A,E2),	ent(E2,X),!.

  /* How big is the biggest city -- BIG QUERY */
  s_attr([BIG|S1],S2,E1,q_eaq(E1,A,E2,Q)):-
		big(_,BIG),!,s_minmax(S1,S2,E2,Q),
		big(E2,BIG),entitysize(E2,E1),
		schema(E1,A,E2),!.

  s_attr(S1,S2,E,Q):-s_minmax(S1,S2,E,Q).


  /* The smallest city -- MIN QUERY */
  s_minmax([MIN|S1],S2,E,q_min(E,Q)):-min(MIN),!,s_rest(S1,S2,E,Q).

  /* The biggest city -- MAX QUERY */
  s_minmax([MAX|S1],S2,E,q_max(E,Q)):-max(MAX),!,s_rest(S1,S2,E,Q).

  s_minmax(S1,S2,E,Q):-s_rest(S1,S2,E,Q).


  /* give me cities -- ENTITY */
  s_rest([ENAME],[],E,q_e(E)):-!,ent_name(E,ENAME).

  s_rest([ENAME|S1],S2,E,Q):-ent_name(E,ENAME),s_or(S1,S2,E,Q).


  /* And has higher priority than or */
  s_or(S1,S2,E,Q):-s_and(S1,S3,E,Q1),s_or1(S3,S2,E,Q1,Q).
  s_or1(["or",ENT|S1],S2,E,Q1,q_or(Q1,Q2)):-ent_name(E,ENT),!,s_or(S1,S2,E,Q2).
  s_or1(["or"|S1],S2,E,Q1,q_or(Q1,Q2)):-!,s_or(S1,S2,E,Q2).
  s_or1(S,S,_,Q,Q).

  s_and(S1,S2,E,Q):-s_elem(S1,S3,E,Q1),s_and1(S3,S2,E,Q1,Q).
  s_and1(["and",ENT|S1],S2,E,Q1,q_and(Q1,Q2)):-ent_name(E,ENT),!,s_elem(S1,S2,E,Q2).
  s_and1(["and"|S1],S2,E,Q1,q_and(Q1,Q2)):-!,s_elem(S1,S2,E,Q2).
  s_and1(S,S,_,Q,Q).


  /* not QUERY */
  s_elem(["not"|S1],S2,E,q_not(E,Q)):-!,s_assoc(S1,S2,E,Q).
  s_elem(S1,S2,E,Q):-s_assoc(S1,S2,E,Q).


  /* ... longer than 1 thousand miles -- REL VAL UNIT */
  s_assoc(S1,S4,E,q_sel(E,REL,ATTR,VAL)):-
		s_rel(S1,S2,REL),s_val(S2,S3,VAL),
		s_unit(S3,S4,UNIT),!,unit(ATTR,UNIT).

  /* ... longer than 1 thousand -- REL VAL */
  s_assoc(S1,S3,E,q_sel(E,REL,ATTR,VAL)):-
		s_rel(S1,S2,REL),s_val(S2,S3,VAL),!,
		entitysize(E,ATTR).

  s_assoc(S1,S3,E,Q):-
		get_assoc(S1,S2,A),s_assoc1(S2,S3,E,A,Q).


  /* Before s_assoc1 is called ENT ASSOC is met */

  /* ... the shortest river in texas -- MIN QUERY */
  s_assoc1([MIN|S1],S2,E1,A,q_eaq(E1,A,E2,q_min(E2,Q))):-min(MIN),!,
		s_nest(S1,S2,E2,Q),schema(E1,A,E2).

  /* ... the longest river in texas -- MAX QUERY */
  s_assoc1([MAX|S1],S2,E1,A,q_eaq(E1,A,E2,q_max(E2,Q))):-max(MAX),!,
		s_nest(S1,S2,E2,Q),schema(E1,A,E2).

  /* ... with a population that is smaller than 1 million citizens --
  							 ENT REL VAL UNIT */
  s_assoc1([ATTR|S1],S4,E,A,q_sel(E,REL,ATTR,VAL)):-
	s_rel(S1,S2,REL),s_val(S2,S3,VAL),s_unit(S3,S4,UNIT1),!,
	ent_name(E2,ATTR),schema(E,A,E2),unit(E2,UNIT),
	UNIT=UNIT1,!.

  /* ... with a population that are smaller than 1 million -- ENT REL VAL */
  s_assoc1([ATTR|S1],S3,E,A,q_sel(E,REL,ATTR,VAL)):-
	s_rel(S1,S2,REL),s_val(S2,S3,VAL),!,
	ent_name(E2,ATTR),schema(E,A,E2),unit(E2,_).

  /* ... that is smaller than 1 million citizens -- REL VAL UNIT */
  s_assoc1(S1,S4,E,A,q_sel(E,REL,E2,VAL)):-
	s_rel(S1,S2,REL),s_val(S2,S3,VAL),s_unit(S3,S4,UNIT1),!,
	schema(E,A,E2),unit(E2,UNIT),
	UNIT=UNIT1,!.

  /* ... that is smaller than 1 million -- REL VAL */
  s_assoc1(S1,S3,E,A,q_sel(E,REL,E2,VAL)):-
	s_rel(S1,S2,REL),s_val(S2,S3,VAL),!,
	schema(E,A,E2),unit(E2,_).

  /* ... with a population on 1 million citizens -- ENT VAL UNIT */
  s_assoc1([ATTR|S1],S3,E,A,q_sel(E,eq,ATTR,VAL)):-
	s_val(S1,S2,VAL),s_unit(S2,S3,UNIT1),!,
	ent_name(E2,ATTR),schema(E,A,E2),unit(E2,UNIT2),UNIT1=UNIT2,!.

  /* ... with a population on 1 million -- ENT VAL */
  s_assoc1([ATTR|S1],S2,E,A,q_sel(E,eq,ATTR,VAL)):-
	s_val(S1,S2,VAL),
	ent_name(E2,ATTR),schema(E,A,E2),unit(E2,_),!.

  /* .. the state new york -- ENT CONST */
  s_assoc1([ENAME|S1],S2,E1,A,q_eaec(E1,A,E2,X)):-
		get_ent(S1,S2,X),ent_name(E2,ENAME),
		not(unit(E2,_)),
		schema(E1,A,E2),
		ent(E2,X),!.

  s_assoc1(S1,S2,E1,A,q_eaq(E1,A,E2,Q)):-
		s_nest(S1,S2,E2,Q),schema(E1,A,E2),!.

  /* .. new york -- CONST */
  s_assoc1(S1,S2,E1,A,q_eaec(E1,A,E2,X)):-
		get_ent(S1,S2,X),schema(E1,A,E2),ent(E2,X),!.


  /* Parse a nested query */
  s_nest([ENAME|S1],S2,E,Q):-ent_name(E,ENAME),s_elem(S1,S2,E,Q).
  s_nest([ENAME|S],S,E,q_e(E)):-ent_name(E,ENAME).


  /* ... runs through texas -- ASSOC REST */
  get_assoc(IL,OL,A):-append(ASL,OL,IL),assoc(A,ASL).



/************************************************************************/
/*			EVALUATION OF QUESTIONS				*/
/************************************************************************/

PREDICATES  /* Help predicates for the parser */
  sel_min(SYMBOL,SYMBOL,REAL,SYMBOL,SYMBOL,LIST)
  sel_max(SYMBOL,SYMBOL,REAL,SYMBOL,SYMBOL,LIST)

CLAUSES
  eval(q_min(ENT,TREE),ANS):-
		findall(X,eval(TREE,X),L),
		entitysize(ENT,ATTR),
		sel_min(ENT,ATTR,99e99,"",ANS,L).

  eval(q_max(ENT,TREE),ANS):-
		findall(X,eval(TREE,X),L),
		entitysize(ENT,ATTR),
		sel_max(ENT,ATTR,-1,"",ANS,L).

  eval(q_sel(E,gt,ATTR,VAL),ANS):-
		schema(ATTR,ASSOC,E),
		db(ATTR,ASSOC,E,SVAL2,ANS),
		str_real(SVAL2,VAL2),
		VAL2>VAL.

  eval(q_sel(E,lt,ATTR,VAL),ANS):-
		schema(ATTR,ASSOC,E),
		db(ATTR,ASSOC,E,SVAL2,ANS),
		str_real(SVAL2,VAL2),
		VAL2<VAL.

  eval(q_sel(E,eq,ATTR,VAL),ANS):-
		schema(ATTR,ASSOC,E),
		db(ATTR,ASSOC,E,SVAL,ANS),
		str_real(SVAL,VAL).

  eval(q_not(E,TREE),ANS):-
		findall(X,eval(TREE,X),L),
		ent(E,ANS),
		not(member(ANS,L)).

  eval(q_eaq(E1,A,E2,TREE),ANS):-
		eval(TREE,VAL),db(E1,A,E2,ANS,VAL).

  eval(q_eaec(E1,A,E2,C),ANS):-db(E1,A,E2,ANS,C).

  eval(q_e(E),ANS):-	ent(E,ANS).

  eval(q_or(TREE,_),ANS):- eval(TREE,ANS).

  eval(q_or(_,TREE),ANS):- eval(TREE,ANS).

  eval(q_and(T1,T2),ANS):- eval(T1,ANS1),eval(T2,ANS),ANS=ANS1.


  sel_min(_,_,_,RES,RES,[]).
  sel_min(ENT,ATTR,MIN,_,RES,[H|T]):-schema(ATTR,ASSOC,ENT),
	db(ATTR,ASSOC,ENT,VAL,H),
	str_real(VAL,HH),MIN>HH,!,
	sel_min(ENT,ATTR,HH,H,RES,T).
  sel_min(ENT,ATTR,MIN,NAME,RES,[_|T]):-sel_min(ENT,ATTR,MIN,NAME,RES,T).


  sel_max(_,_,_,RES,RES,[]).
  sel_max(ENT,ATTR,MAX,_,RES,[H|T]):-
	schema(ATTR,ASSOC,ENT),
	db(ATTR,ASSOC,ENT,VAL,H),
	str_real(VAL,HH),MAX<HH,!,
	sel_max(ENT,ATTR,HH,H,RES,T).
  sel_max(ENT,ATTR,MAX,NAME,RES,[_|T]):-sel_max(ENT,ATTR,MAX,NAME,RES,T).



/******************************************************************/
/*		READING THE KEYBORD				  */
/******************************************************************/

DOMAINS
  ROW,COL,LEN = INTEGER

  KEY    = cr ; esc ; break ; tab ; btab ; del ; bdel ; ins ;
  	    end ; home ; ftast(INTEGER) ; up ; down ; left ; right ;
  	    ctrlleft; ctrlright; ctrlend; ctrlhome; pgup; pgdn; 
  	    chr(CHAR) ; otherspec

PREDICATES
  readkey(KEY)
  readkey1(KEY,CHAR,INTEGER)
  readkey2(KEY,INTEGER)

CLAUSES
  readkey(KEY):-readchar(T),char_int(T,VAL),readkey1(KEY,T,VAL).

  readkey1(KEY,_,0):-!,readchar(T),char_int(T,VAL),readkey2(KEY,VAL).
  readkey1(cr,_,13):-!.
  readkey1(esc,_,27):-!.
  readkey1(chr(T),T,_) .
  
  readkey2(up,72):-!.
  readkey2(down,80):-!.
  readkey2(ftast(N),VAL):-VAL>58,VAL<70,N=VAL-58,!.
  readkey2(otherspec,_).


/****************************************************************/
/* 			menu					*/
/* Implements a popup-menu					*/
/* menu(Line,Collum,ListOfChoices,ChoiceNr)			*/
/* The following keys can be used:				*/
/*	arrows up and down: select choice			*/
/*	cr and F10: activate choice				*/
/*	Esc: abort						*/
/****************************************************************/

PREDICATES
  menu(ROW,COL,STRING,LIST,INTEGER)
  menu1(ROW,LIST,ROW,INTEGER,INTEGER)
  menu2(ROW,LIST,ROW,INTEGER,INTEGER,KEY)

CLAUSES
  menu(LI,KOL,TXT,LIST,CHOICE):-
		shiftwindow(21),
		maxlen(LIST,0,ANTKOL),
		listlen(LIST,LEN),ANTLI=LEN,LEN>0,
		HH1=ANTLI+2,HH2=ANTKOL+2,
		makewindow(3,7,7,TXT,LI,KOL,HH1,HH2),
		HH3=ANTKOL,
		writelist(0,HH3,LIST),cursor(0,0),
		menu1(0,LIST,ANTLI,ANTKOL,CH),
		CHOICE=1+CH,
		removewindow,
		shiftwindow(22),
		shiftwindow(2).

  menu1(LI,LIST,MAXLI,ANTKOL,CHOICE):-
		field_attr(LI,0,ANTKOL,112),
		cursor(LI,0),
		readkey(KEY),
		menu2(LI,LIST,MAXLI,ANTKOL,CHOICE,KEY).

  menu2(_,_,_,_,-1,esc):-!.
  menu2(LI,_,_,_,CH,ftast(10)):-!,CH=LI.
  menu2(LI,_,_,_,CH,cr):-!,CH=LI.
  menu2(LI,LIST,MAXLI,ANTKOL,CHOICE,up):-
		LI>0,!,
		field_attr(LI,0,ANTKOL,7),
		LI1=LI-1,
		menu1(LI1,LIST,MAXLI,ANTKOL,CHOICE).

  menu2(LI,LIST,MAXLI,ANTKOL,CHOICE,down):-
		LI<MAXLI-1,!,
		field_attr(LI,0,ANTKOL,7),
		LI1=LI+1,
		menu1(LI1,LIST,MAXLI,ANTKOL,CHOICE).

  menu2(LI,LIST,MAXLI,ANTKOL,CHOICE,_):-
		menu1(LI,LIST,MAXLI,ANTKOL,CHOICE).


/************************************************************************/
/*		     MAIN MENU						*/
/************************************************************************/

PREDICATES
  /* Main loop */
  natlang
  mainmenu
  proces(INTEGER)  

  /* View and update the language */
  viewlang viewlang1(INTEGER)
  updatelang updatelang1(INTEGER)

GOAL natlang.

CLAUSES
  natlang:-
	makewindow(21,112,0,"",24,0,1,80),
	write("ESC: Quit this menu -- Use arrow keys to select and hit RETURN to activate."),
	makewindow(22,112,0,"",24,0,1,80),
	write("Esc: Quit     F8: Last line    Ctrl S: Stop output    End: End of line"),
	makewindow(2,7,7,"GEOBASE: Natural language interface to U.S. geography",0,0,24,80),
	mainmenu.

  mainmenu:-	repeat,
  		menu(8,49,"Main menu",
  		  [ "Tutorial",
  		    "Dos commands",
  		    "Editor",
  		    "",
  		    "Load the database",
		    "Save database on file",
		    "",
		    "Query the database",
		    "",
		    "View the language",
		    "Update the language"],CHOICE),
		proces(CHOICE),
		CHOICE=0,!,
		removewindow,removewindow.

  proces(0):-write("\nAre you sure you want to quit? (y/n): "),readchar(T),T='y'.
  proces(1):-file_str("geobase.hlp",TXT),display(TXT),clearwindow,!.
  proces(1):-write(">> geobase.hlp not in default directory\n").
  proces(2):-makewindow(3,7,0,"",0,0,25,80),write("Type EXIT to return\n\n"),
             system(""),!,removewindow.
  proces(2):-write(">> command.com not accessible. press any key"),readchar(_),removewindow.
  proces(3):-makewindow(3,7,112,"",9,5,15,75),edit("",_),removewindow.
  proces(4).
  proces(5):-write("Loading database file - please wait\n"),consult("geobase.dba"),!.
  proces(5):-write(">> geobase.dba not in default directory\n").
  proces(6):-deletefile("geobase.bak"),renamefile("geobase.dba","geobase.bak"),save("geobase.dba").
  proces(7).
  proces(8):-readquery(L),loop(L).
  proces(9).
  proces(10):-viewlang.
  proces(11):-updatelang.


/************************************************************************/
/*	   	View and the language					*/
/************************************************************************/

  viewlang:-	repeat,
 		menu(5,40,"Language",
  		  [ "1  Schema for relations",
  		    "2  Schema for the entity network",
  		    "3  Names of entities",
  		    "4  Synonyms for entities",
  		    "5  Alternative names for associations",
  		    "6  Words to ignore",
  		    "7  Units for attributes",
  		    "8  Alternatives for relation operators",
  		    "9  Words stating minimums",
  		    "10 Words stating maximum"
  		  ],CHOICE),
		nl,viewlang1(CHOICE),CHOICE=0,!.


  viewlang1(0).

  viewlang1(1):-
	write("Relations\n*********\n"),
	relat(REL,ATTL),
	write(REL,": "),write_list2(ATTL),nl,fail.
	
  viewlang1(1):-
        write("\n\nPress any key to continue"),
        readchar(_).

  viewlang1(2):-
	writef("%-12 %-8 %-12\n","Entity","Assoc","Entity"),
	write("************ ******** ************\n"),
	schema(E1,A,E2),writef("%-12 %-8 %-12\n",E1,A,E2),fail.
	
  viewlang1(2):-
        write("\n\nPress any key to continue"),
        readchar(_).	

  viewlang1(3):-
	write("Entities\n********\n"),
	findall(X,entity(X),L),unik(L,L1),write_list(0,L1),nl.
	
  viewlang1(3):-
        write("\n\nPress any key to continue"),
        readchar(_).	

  viewlang1(4):-
	writef("%-15 %-15\n","Synonym","Entity"),
	write("*************** ***************\n"),
	synonym(E,S),writef("%-15 %-15\n",E,S),fail.
	
  viewlang1(4):-
        write("\n\nPress any key to continue"),
        readchar(_).	

  viewlang1(5):-
	write("Associations\n************\n"),
	assoc(X,L),
	writef("%-8 ",X),write_list2(L),nl,fail.
	
  viewlang1(5):-
        write("\n\nPress any key to continue"),
        readchar(_).	

  viewlang1(6):-
	write("Ignore\n******\n"),
	findall(X,ignore(X),L),write_list(0,L),nl.
	
  viewlang1(6):-
        write("\n\nPress any key to continue"),
        readchar(_).	

  viewlang1(7):-
	writef("%-15 %-15\n","entity","unit"),
	write("*************** ***************\n"),
	unit(E,U),writef("%-15 %-15\n",E,U),fail.
	
  viewlang1(7):-
        write("\n\nPress any key to continue"),
        readchar(_).	

  viewlang1(8):-
	write("Names of relational operators\n*****************************\n"),
	relop(LIST,REL),write(REL,": "),write_list2(LIST),nl,fail.
	
  viewlang1(8):-
        write("\n\nPress any key to continue"),
        readchar(_).	

  viewlang1(9):-
	write("Minimum\n*******\n"),
	findall(X,min(X),L),write_list(0,L),nl.
	
  viewlang1(9):-
        write("\n\nPress any key to continue"),
        readchar(_).
  	
  viewlang1(10):-
	write("Maximum\n*******\n"),
	findall(X,max(X),L),write_list(0,L),nl.
	
  viewlang1(10):-
        write("\n\nPress any key to continue"),
        readchar(_).	


/************************************************************************/
/*	   	Update  the language					*/
/************************************************************************/

PREDICATES
  newignore
  newsynonym
  newassoc
  getent(SYMBOL)
  getassoc(SYMBOL)

CLAUSES
  updatelang:-	repeat,
 		menu(5,40,"Update Language",
  		  [ "New Synonyms for entities",
  		    "New Alternatives for associations",
  		    "New Words to be ignored"
  		  ],CHOICE),
		nl,updatelang1(CHOICE),CHOICE=0,!.

  updatelang1(0).
  updatelang1(1):-newsynonym.
  updatelang1(2):-newassoc.
  updatelang1(3):-newignore.


  newsynonym:-	getent(E),write("Synonym: "),
		readln(SYNONYM),SYNONYM><"",
		assert(synonym(SYNONYM,E)),newsynonym.

  newignore:-	write("Ignore:"),readln(IGNORE),IGNORE><"",
		assert(ignore(IGNORE)),newignore.

  newassoc:-
		getassoc(ASSOC),
		write("New form: "),
		readln(FORM),FORM >< "",
		scan(FORM,LIST),
		assert(assoc(ASSOC,LIST)),
		newassoc.

  getassoc(A):-
		findall(X,assoc(X,_),L),
		unik(L,L1),
		menu(11,30,"Assoc",L1,C),
		index(L1,C,A).

  getent(E):-
		findall(X,entity(X),L),
		unik(L,L1),
		menu(2,49,"Entity",L1,C),
		index(L1,C,E).
