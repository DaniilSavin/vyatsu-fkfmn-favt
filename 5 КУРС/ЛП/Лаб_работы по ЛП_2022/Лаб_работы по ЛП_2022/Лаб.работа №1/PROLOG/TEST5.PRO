
domains

 list=integer*
  
predicates

find(integer,list)
 
goal
find(X,[1,2,3,4,5]).

clauses
find(Head,[Head|_]):-not(Head>3), write(Head),nl,fail.
find(Head,[_|Tail]):-
     find(Head,Tail).
  
