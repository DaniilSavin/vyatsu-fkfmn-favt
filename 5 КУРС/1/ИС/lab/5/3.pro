DOMAINS
l = integer*

PREDICATES
add(integer,l,l)
genl(integer, l)

CLAUSES
add(E,[],[E]):- !.
add(E,[H|T],[H|T1]):- add(E,T,T1).

genl(21,[]):-!.
genl(N,[N|L]):- N1=N+3, genl(N1,L).

GOAL
genl(3,L), write(L), nl,
write("add num: "),
readint(E),
add(E,L,K), nl,
write("K=",K).