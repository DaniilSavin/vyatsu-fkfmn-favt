domains
  Q=char

predicates
go_ring(integer,integer,integer,integer)
goal
	
	clearwindow,
	makewindow (1,7,7,"Input parametr",0,0,20,20),
	makewindow(2,7,7,"1",0,21,8,10),
	makewindow(3,7,7,"2",0,31,8,10),
	makewindow(4,7,7,"3",0,41,8,10),
	gotowindow (1),
	write ("Количество колец : "),
	readint (N),
	write("Из            В"),nl,
	write("---------------"),nl,
	N>0,
	go_ring(1,3,2,N).
	
clauses
	go_ring(X,Y,Z,0):-write("колеца кончились").
	go_ring(X,Y,Z,1):-
	W=Y+1,
	gotowindow(1),
	write(X),write("     ->      "),write(Y),nl,
	readchar(Q),
	gotowindow(W),write(Y),nl.
	go_ring(X,Y,Z,N):-
	M=N-1,
	go_ring(X,Z,Y,M),
	gotowindow(2),
	go_ring(X,Y,Z,1),
	go_ring(Z,Y,X,M).
	
	