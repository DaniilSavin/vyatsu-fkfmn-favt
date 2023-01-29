
domains

 list=integer*
  
predicates

find(integer,list)
 
goal
find(Y,[1,2,3,4,5]).

clauses
find(Head,[Head|_]):- Head=3,write(Head),!.
find(Head,[_|Tail]):-
     find(Head,Tail),fail.
  
