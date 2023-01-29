PREDICATES
nondeterm power(real, real, real).
nondeterm calc(real).

CLAUSES
power(F,1,F):-!.
power(Y,N,X):-N1=N-1,
              power(Y,N1,X1), X=X1*Y.

calc(X):- power(2.71828182846, X, XN), Z=XN*sin(X)+3*ln(X),
 write("Z=",Z)./*;
 write("Delit' na 0 nel'zya!").*/

GOAL
write("X="),readreal(X),
calc(X),nl.