
domains

 list=integer*
  
predicates

find(integer,list)
 
goal
find(X,[1,3,4,3,8,5]).

clauses
find(Head,[Head|_]):-write(Head),nl.
find(Head,[_|Tail]):-
     find(Head,Tail).
  
