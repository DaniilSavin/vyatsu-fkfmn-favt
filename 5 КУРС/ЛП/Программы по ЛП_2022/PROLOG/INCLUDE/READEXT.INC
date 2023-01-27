/***************************************************************
     Turbo Prolog Toolbox
     (C) Copyright 1987 Borland International.
***************************************************************/

PREDICATES
  read_char(Char)
  read_int(Integer)
  read_real(Real)
  read_long(Real)
  read_str(String)
  read_str2(String,String)
  read_strArr(Integer,String)
  read_str2Arr(Integer,String,String)
  read_strCtrlZ(String)
  read_str2CtrlZ(String,String)
  readnz(STRING)
  ignore(Integer)

CLAUSES
    readnz(Str):-
      readchar(Ch),
      Ch <> '\0',!,
      str_char(Char,Ch),
      readnz(Work),
      concat(Char,Work,Str).
    readnz("").

  read_char(X):-readchar(X).

  read_int(V) :-
	readchar(Lch), readchar(Hch), char_int(Lch,Low), char_int(Hch,High),
	bitleft(High,8,Vh), V = Low + Vh.

  read_real(Real) :-
	read_int(V1), read_int(V2), read_int(V3), read_int(V4),
	real_ints(Real,V1,V2,V3,V4).

  read_long(Long) :-
	read_int(VLow), read_int(_), Long=Vlow.

  read_str(Str) :- read_str2("",Str).
  read_str2(Scur,Str) :-
	readchar(CH), CH<>'\000', !,
	str_char(S1,CH), concat(Scur,S1,Scur2),
	read_str2(Scur2,Str).
  read_str2(S,S).

  read_strArr(N,S) :- read_str2Arr(N,"",S).

  read_str2Arr(0,Str,Str)  :- !.
  read_str2Arr(N,Scur,Str) :-
	readchar(CH),
	str_char(S1,CH), concat(Scur,S1,Scur2),
	N2=N-1, read_str2Arr(N2,Scur2,Str).

  read_strCtrlZ(Str) :- read_str2CtrlZ("",Str).
  read_str2CtrlZ(Scur,Str) :-
	readchar(CH), CH<>'\026', !, /* CtrlZ => CP/M way signaling eof */
	str_char(S1,CH), concat(Scur,S1,Scur2),
	read_str2CtrlZ(Scur2,Str).
  read_str2CtrlZ(S,S).


/*************************************************************
	Ignore Characters
*************************************************************/

  ignore(0) :- !.
  ignore(N) :- readchar(_), N2=N-1, ignore(N2).
