DOMAINS
list = integer*

PREDICATES
nondeterm spisok(integer,list,list)
gen2(integer, list)
gen1(integer, list)
append(list,list,list).

CLAUSES
spisok(X,[X|L],L).
spisok(X,[Y|L],[Y|L1]):- spisok(X,L,L1).

gen1(12,[]):-!.
gen1(N,[N|H]):- N1=N+2, gen1(N1,H).

gen2(11,[]):-!.
gen2(N,[N|L]):- N1=N+2, gen2(N1,L).

append([],[],[]):-!.
append([A|_],[],[A]):-!.
append([],[_],[]):-!.
append([A,_|_],[_],[A]):-!.
append([],[_,B|_],[B]):-!.
append([H1|Tail1],[H2|Tail2],[H1,H2|Tail]):-append(Tail1,Tail2,Tail).

GOAL
gen1(2,L), write(L), nl,
gen2(1,H), write(H), nl,
append(H,L,K).