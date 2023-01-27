
/*************************************************************
    Turbo Prolog Toolbox
    (C) Copyright 1987 Borland International.

    Ticks (0-32767) causes the program to wait for a specified period
    of time, measured in hundredths of seconds.
**************************************************************/
GLOBAL PREDICATES
  Ticks(Integer)-(i)

Predicates
  Ticks2(Real)
%  repeat

Clauses
/* Wait delay based on the PCs clock circuit */

ticks(Hundred) :-
  	time(_,Min,Sek,Hund),
  	Tw2 = Min*6000.0 + SEK*100.0 + Hund, Tw3 = Tw2+Hundred,
  	ticks2(Tw3).
  
ticks2(EndHundred) :-
  	repeat,
  	time(_,Min,Sek,Hund),
  	Tw2 = Min*6000.0 + SEK*100.0 + Hund,
  	Tw2>EndHundred,!.

%repeat. repeat:-repeat.
