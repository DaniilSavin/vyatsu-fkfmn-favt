domains
  base=d(int,int,int)
  top_l=base*
  top_list=integer*
  int=integer
  top_code=integer*
   

predicates
  start
  
  d(int,int,int)
  
  path(top_list)
  choice(int)
  comp(int,int)
  prov(int,int)
  append(top_list,top_list)
goal
  start.
    
  


clauses
  d(1,2,1).
  d(1,3,4).
  d(2,3,2).
  d(2,4,5).
  d(3,4,3).
  d(3,6,6).
  d(4,5,2).
  d(5,6,1).
  d(2,5,5).
  d(5,5,5).
  Start:-
     makewindow(1,1,7,"aaa",3,11,16,55),
     Top=[2,3,4,5,6,7],
     path(Top),


     shiftwindow(1),
     write("результат"),nl,
     write(MainSum).
  

     prov(X,P1):-
       X<>0,
       Temp=Sum+P1,
       Sum=Temp,
       T2=Sum1,
       Temp=T2+P1,
       Sum1=Temp,
       comp(Sum,Sum1).
     prov(X1,P):-
        A=0.
    
     comp(X,Y):-
     	X>Y,
     	T3=MainSum,
     	T=Y+T3,
     	MainSum=T.
     comp(X1,Y1):-
     	T3=MainSum,
     	T=T3+Y1,
     	MainSum=T.	     

     choice(7).
     choice(H1):-
        M=H1,
        d(N,M,P),
        prov(1,P),
        prov(0,P),        
     choice(H),fail.

      path([]).
      path([X|Y]):-
         choice(X),!,
      path(Y).
     	



      append([],L).
      append([N|L0],[N|L3]):-
      		append(L1,L3).	


