
domains

 list=integer*
  
predicates

find(integer,list)
 
goal
find(3,[1,3,4,3,8,5]).

clauses
find(Head,[Head|_]):-Head=3,write(Head),!.
find(Head,[_|Tail]):-
     find(Head,Tail).
  
