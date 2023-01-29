domains
 n,par1,par2=integer
 list=integer*

predicates

 l(list)
 win(list,list,list,list)
 sp(par1,par2,list,list,list,list)
 sort(list,list)
 insert(n,list,list)
 print_list(list,list)

goal
 l(L),
 sp(30,50,L,L1,L2,L3),
 sort(L1,S1),
 sort(L2,S2),
 sort(L3,S3),
 win(L,S1,S2,S3),
 print_list(S3,S3).
 
clauses

l([45,20,30,80,11,60,60,25,90,10,5,50,3,51]).

sp(Par1,Par2,[Head|Tail],[Head|L1],L2,L3):-
 Head<Par1,
 sp(Par1,Par2,Tail,L1,L2,L3).

sp(Par1,Par2,[Head|Tail],L1,[Head|L2],L3):-
 Head>=Par1,
 Head<=Par2,
 sp(Par1,Par2,Tail,L1,L2,L3).

sp(Par1,Par2,[Head|Tail],L1,L2,[Head|L3]):-
 Head>Par2,
 sp(Par1,Par2,Tail,L1,L2,L3).

sp(_,_,[],[],[],[]).

sort([],[]).
sort([X|Tail],Sorted_list):-
 sort(Tail,Sorted_Tail),
 insert(X,Sorted_Tail,Sorted_list).

insert(X,[Y|Sorted_list],[Y|Sorted_list1]):-
 X<Y, 
 insert(X,Sorted_list,Sorted_list1).

insert(X,Sorted_list,[X|Sorted_list]).

win(L,S1,S2,S3):-
  makewindow(1,7,7,"Исходный список",0,0,5,80),
  write(L),
  makewindow(2,7,7,"Список1 <30",5,0,5,80),
  write(S1),
  makewindow(3,7,7,"Список2 >=30 и <=50",10,0,5,34),
  write(S2) ,
  makewindow(4,7,7,"Список3",15,1,10,30).


  print_list([],[]).
  
   print_list([X|Tail],[Y|Tail1]):-
                          str_int(A,
                          write(X),nl,
                           makewindow(5,7,7, "Список4",15,30,10,30),                                 
                           write(Y),nl,
                           print_list(Tail,Tail1).
                           
                           
 
