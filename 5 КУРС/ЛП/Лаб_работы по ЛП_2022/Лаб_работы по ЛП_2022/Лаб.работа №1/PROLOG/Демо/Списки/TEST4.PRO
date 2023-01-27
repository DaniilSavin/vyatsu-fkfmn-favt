
domains

 list=integer*
  
predicates

find(integer,list)
 
goal
find(B,[1,7,3,3,7,5]).

clauses
find(Head,[Head|_]):-not(Head<4),write(Head),fail.
find(Head,[_|Tail]):-
     find(Head,Tail).
  
