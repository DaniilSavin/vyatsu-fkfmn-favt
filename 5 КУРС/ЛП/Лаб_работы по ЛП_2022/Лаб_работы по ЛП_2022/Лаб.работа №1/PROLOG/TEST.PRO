domains

 list=integer*
  
predicates

find(integer,list)
 
goal
find(3,[1,3,5,7,8]).

clauses
find((Head,[Head|_]).
find(Head,[_|Tail]:-
     find(Head,[Head|Tail]).
  
