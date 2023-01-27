predicates
  base(string,string,integer,integer)
  choise
goal
  makewindow(1,1,7,"Поиск футболистов:",3,11,16,55),
  choise.

clauses
  base("Спартак" ,"Иванов   " ,42,9 ).
  base("Спартак" ,"Петров   " ,7 ,6 ).
  base("Спартак" ,"Сидоров  " ,6 ,2 ).
  base("Динамо " ,"Новиков  " ,2 ,5 ).
  base("Динамо " ,"Цылев    " ,0 ,6 ).
  base("Динамо " ,"Харитонов" ,22,8 ).
  base("Динамо " ,"Перминов " ,7 ,9 ).
  base("ЦСКА   " ,"Хлебутин " ,65,9 ).
  base("ЦСКА   " ,"Дука     " ,4 ,7 ).
  base("ЦСКА   " ,"Петухов  " ,2 ,4 ).
  base("Торпедо" ,"Топоров  " ,17,3 ).
  base("Торпедо" ,"Пархачев " ,31,7 ).

  choise:-
    shiftwindow(1),
    base(Kom,Fam,Gol1,Num1),
    Gol1>30,
    window_attr(26),
    write("|Команда: ",Kom, " |Футболист:",Fam," |","Голов: ",Gol1),nl,fail.

