PREDICATES
nondeterm calc(real, real).

CLAUSES
calc(X,Y):- X<>-Y, S=2*(X*X+Y*Y)/(X+Y),
 write("S=",S)./*;
 write("Delit' na 0 nel'zya!").*/

GOAL
write("X="),readreal(X),
write("Y="),readreal(Y),
calc(X, Y),nl.