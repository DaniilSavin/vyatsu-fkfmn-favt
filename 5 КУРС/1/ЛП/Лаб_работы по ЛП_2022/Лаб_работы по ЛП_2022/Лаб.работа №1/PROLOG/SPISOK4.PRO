
domains
 
 list=integer*

predicates

 print(list)
 sp(list,list,list)
 zz(integer,integer)
/* zzz(integer,real)*/
 
goal

sp([40,20,30,80,50],L1,L2),
makewindow(1,7,7,"Spisok1", 1,1,10,30),

print(L1),nl,
makewindow(2,7,7,"Spisok2",10,10,10,30), 
print(L2).
clauses

sp([],[],[]).
sp([Head|Tail],[Head|L1],L2):-
                               zz(Head,Y),
                               
                               sp(Tail,L1,L2).

zz(Head,Y):-
Y=Head/2.

print([Head|Tail]):-
                    write(Head),nl,
                    print(Tail).

print([]).

sp([Head|Tail],L1,[Head|L2]):-
zzz(Head,Y),
sp(Tail,L1,L2).


zzz(Head,Y):-
Y=Head/2.




                           
                                                      
                           
 
