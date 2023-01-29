predicates
count2(integer)


clauses
count2(X):-
X>=0,!,
write(X),
nl,
NewX=X+1,
count2(NewX).
count2(X):-
X<0,
write(X, "отрицательно").

goal
count2(0).%не важно где стоит цель 