
domains

 list=integer*
  
predicates

find(integer,list)
 
goal
find(5,[1,3,4,3,5,5]).

clauses
find(Head,[Head|_]):-write(Head),nl,fail.
find(Head,[_|Tail]):-
     find(Head,Tail).
  
