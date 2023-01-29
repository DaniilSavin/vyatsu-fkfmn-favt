/* Применение предиката    */
predicates
  base(string,string)
left(string,string)
  choise
goal
  makewindow(1,4,7,"Поиск футболистов:",7,23,13,45),
  choise.

clauses
  base("юра","миша").
  base("миша","витя").
 
  choise:-
    shiftwindow(1),
    left(Y,X),
    left(Z,Y),
    write(X,Y,Z),nl,fail.

