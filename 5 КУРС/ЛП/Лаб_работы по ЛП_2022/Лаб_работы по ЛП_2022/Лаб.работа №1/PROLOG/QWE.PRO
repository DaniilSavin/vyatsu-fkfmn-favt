
domains
  list=integer*
  predicates
  split(integer,list,list,list)
print_list(list)
/*find_it(list)*/
goal
  makewindow(1,7,7,"window",7,30,16,47),
  split(1,[3,-7,9,-23,31,25,-26,12,18],L1,L2),
   makewindow(2,7,7," List 1",10,15,15,47),
print_list(L1),
print_list([Head|L1]).
clauses
    split(M,[Head|Tail],[Head|L1],L2):-
        Head<M,
        split(M,Tail,L1,L2).
  split(M,[Head|Tail],L1,[Head|L2]):-
        split(M,Tail,L1,L2),
        Head>M.
        split(_,[],[],[]).
  
 print_list([]).
 print_list([Head|Tail]):-
   write(Head),   
   print_list(Tail).
 
 
/* find_it([Head|Tail]):-
       Head < -25,
       shiftwindow(2),
      write(Head),
       find_it(Tail),!.*/

      
      
