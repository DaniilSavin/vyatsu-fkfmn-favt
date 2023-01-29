PREDICATES
nondeterm calc(real).

CLAUSES
calc(X):-X<>2, Y=(X*X+1)/(X-2),
 write("Y=",Y)./*;
 write("Delit' na 0 nel'zya!").*/

GOAL
write("X="),readreal(X),
calc(X),nl.