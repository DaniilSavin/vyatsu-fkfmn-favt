DOMAINS
list = integer*

PREDICATES
nondeterm spisok(integer,list,list)
genl(integer, list)

CLAUSES
spisok(X,[X|L],L).
spisok(X,[Y|L],[Y|L1]):-spisok(X,L,L1).

genl(12,[]):-!.
genl(N,[N|L]):- N1=N+2, genl(N1,L).

GOAL
genl(2,L),write(L),nl,
write("X="),readint(X),
spisok(X,L,L1),!;
    write("Element otsutstvuet v spiske"),nl.