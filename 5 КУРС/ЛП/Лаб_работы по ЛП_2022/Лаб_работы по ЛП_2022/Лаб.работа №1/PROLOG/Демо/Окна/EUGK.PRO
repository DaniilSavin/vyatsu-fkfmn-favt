domains
	x_oper=string
	x_vetka=string
	x_xvoa=string
predicates
           name_like(string,string)
           testoper("Листья","Иголки")
goal
     name_like(X,Y).
     testoper("Листья","Иголки").
clauses
     name_like(X,Y):-
     makewindow(1,7,7,"Определение дерева",0,0,25,80),
     gotowindow(1),
     makewindow(2,112,7,"Введите оперение",1,1,10,32),
     shiftwindow(2),
     write("Листья или иголки"),nl,
     readln(X),
      testoper("Листья","Иголки"):-
          test(X,"Листья"),
          test(X,"Иголки")      
     makewindow(3,7,7,"Me nravitsa",12,1,10,32),
     shiftwindow(3),
     readln(Y),
     makewindow(4,240,135,"I know",9,33,5,45),
     shiftwindow(4),
     write("!  I know"),nl,
     write(X," like ",Y,"!").