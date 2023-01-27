domains
namelist=name*
name=symbol

predicates
member(name,namelist)

goal
member("Вася",["Петя","Света","Олег","Вася"]),
write("Успех").

clauses
member(Name,[Name|_]).
member(Name,[_|Tail]):-
member(Name,Tail).

