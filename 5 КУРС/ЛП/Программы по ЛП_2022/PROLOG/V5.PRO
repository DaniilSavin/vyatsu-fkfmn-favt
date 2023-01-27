
domains

 list=integer*
  
predicates

find(integer,list)
 
goal
find(X,[1,2,3,43,5]).

clauses
find(Head,[Head|_]):-write(Head),fail.
find(Head,[_|Tail]):-
     find(Head,Tail).
  
