predicates
factorial(integer,integer)


clauses
factorial(1,1):-!.
factorial(X,FactX):-
Y=X-1,
factorial(Y,FactY),
FactX=X*FactY.

goal
X=3, factorial(X,FactX), write(FactX).%не важно где стоит цель 