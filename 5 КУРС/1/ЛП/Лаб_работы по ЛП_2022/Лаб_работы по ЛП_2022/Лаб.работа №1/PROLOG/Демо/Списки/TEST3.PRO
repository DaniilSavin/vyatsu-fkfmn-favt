

domains

 list=integer*
  
predicates

find(integer,list)
 
goal
find(7,[1,7,4,3,7,5]).

clauses
find(Head,[Head|_]):- write(Head).
find(Head,[_|Tail]):-
     find(Head,Tail),fail.
  
