
domains

 list=integer*
  
predicates

find(integer,list)
 
goal
find(A,[1,5,4,3,8,5]).

clauses
find(Head,[Head|_]):-Head=5,write(Head),fail.
find(Head,[_|Tail]):-
     find(Head,Tail),!.
  
