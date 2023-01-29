domains

person=symbol

predicates

child(person)
start
make_cut(person)

goal

write("Дети"),nl,nl,
start.

clauses

child("Петр").
child("Дмитрий").
child("Андрей").
child("Василий").
child("Артем").
child("Николай").

start:-
     child(Name),
     write("  ",Name),nl,
     make_cut(Name),!.
     make_cut(Name):-
     Name="Артем".
     