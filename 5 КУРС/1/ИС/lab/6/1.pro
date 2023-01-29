GLOBAL FACTS
	yes (symbol)
	no (symbol)

PREDICATES
nondeterm fish(symbol)
nondeterm otrajd(symbol)
nondeterm vid(symbol)
	begin
	answer
	question(symbol)
	add_to_database(symbol,char)
	otvet(char)
	clear_from_database
	priznak(symbol)

GOAL
	begin.

CLAUSES
begin :-
	write ("Otvet'te na voprosi: "),nl,nl,
	answer,
	clear_from_database,
	nl,nl,nl,nl,
	exit.
answer :-
	fish(X),!,nl,
	save("BF1.dbf"),
	write (" Otvet: ",X,"."),nl.
question(Y) :-
 	write ("Vopros: ",Y,"? "),
	otvet(X),
	write(X),nl,
	add_to_database (Y,X).
otvet(C):-
	readchar(C).
priznak (Y) :-
	yes (Y),!.
priznak (Y) :-
	not( no (Y)),
	question (Y).
add_to_database (Y,'y') :-
	assertz (yes (Y)).
add_to_database (Y,'n') :-
	assertz (no (Y)),fail.
clear_from_database :- retract (yes(_)),fail.
clear_from_database :- retract (no(_)),fail.

fish("eto sazan"):-
	otrajd("otryad karpoobraznie"),
	priznak("gubi s 4 usikami").
fish("eto plotva"):-
	otrajd("otryad karpoobraznie"),
	priznak("plavniki s rozovimi per'yami").
fish("eto lesch"):-
	otrajd("otryad karpoobraznie"),
	priznak("u ribi jelto-zolotistiy okras"),
	priznak("u ribi spinnoy plavnik uzkiy").
fish("eto electicheskiy skat"):-
	priznak("u ribi est' electricheskie organi"),
	otrajd("otryad skati").
fish("eto skat-hvostokol"):-
	priznak("u ribi na hvoste yadovitiy ship"),
	otrajd("otryad skati").
fish("eto gigantskaya akula"):-
	priznak("u ribi sero-korichneviy okras"),
	priznak("u ribi konicheskaya morda"),
	otrajd("otryad akuli").
fish("eto riba molot"):-
	otrajd("otryad akuli"),
	priznak("riba napadaet na lyudey"),
	priznak("u ribi molotoobraznaya morda").
fish("Dannoy ribi v baze znaniy ne obnarujeno").

otrajd("otryad skati"):-
	priznak("u ribi net hvostovogo plavnika"),
	priznak("u ribi tonkiy dlinniy hvost"),
	vid("hryaschevaya riba"),
	vid("morskaya riba").
otrajd("otryad akuli"):-
	vid("morskaya riba"),
	vid("hryaschevaya riba"),
	priznak("plavniki ne gibkie"),
	priznak("hvost assimetrichniy").
otrajd("otryad karpoobraznie"):-
	vid("presnovodnaya riba"),
	vid("kostnaya riba"),
	priznak("odinochniy spinnoy luchevoy plavnik"),
	priznak("u ribi net zubov").

vid("kostnaya riba"):-
	priznak("u ribi est' jabernie krishki");
	priznak("u ribi est' kostniy skelet").
vid("presnovodnaya riba"):-
	priznak("riba plavaet v rekah ili ozerah").
vid("hryaschevaya riba"):-
	priznak("u ribi net plavatel'nogo puzirya"),
	priznak("u ribi est' hryascheviy skelet").
vid("morskaya riba"):-
	priznak("riba plavaet v moryah").