/* Применение предиката fail   */
predicates
  base(string,string,integer,integer)
  choise
goal
  makewindow(1,4,7,"Поиск футболистов:",7,23,13,45),
  choise.

clauses
  base("Спартак","Иванов"   ,42,9 ).
  base("Спартак","Петров"   ,57,6 ).
  base("Спартак","Сидоров"  ,6 ,2 ).
  base("Динамо" ,"Новиков"  ,2 ,5 ).
  base("Динамо" ,"Цылев"    ,0 ,6 ).
  base("Динамо" ,"Харитонов",52,8 ).
  base("Динамо" ,"Перминов" ,7 ,9 ).
  base("ЦСКА"   ,"Хлебутин" ,5 ,9 ).
  base("ЦСКА"   ,"Дука"     ,4 ,7 ).
  base("ЦСКА"   ,"Петухов"  ,2 ,4 ).
  base("Торпедо","Топоров"  ,17,3 ).
  base("Торпедо","Пархачев" ,12,7 ).

  choise:-
    shiftwindow(1),
    base(Kom,Fam,Gol1,Num1),
    Gol1>30,
    write(Kom," Футболист:",Fam),nl,fail.

