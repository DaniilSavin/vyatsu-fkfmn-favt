predicates
factorial(integer,integer)

goal
X=3, factorial(X,FactX), write(FactX).

clauses
factorial(1,1):-!.
factorial(X,FactX):-
Y=X-1,
factorial(Y,FactY),
FactX=X*FactY.