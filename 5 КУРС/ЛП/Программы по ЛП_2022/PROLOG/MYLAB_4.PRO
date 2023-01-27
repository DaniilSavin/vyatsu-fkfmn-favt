predicates
  base(string,string,integer,integer,integer,integer)
  inc1(integer) 
  players

goal
  makewindow(1,1,7,"Они не забили голов:",0,0,10,52),
  makewindow(2,1,7,"Эти забили больше 30 ",10,0,7,52),  
  makewindow(3,1,7,"Футболисты c номера 9 ,забившие более 40 голов",17,0,7,80),  
  makewindow(4,1,7,"Список футболистов ",0,52,17,28),  
  players.

clauses
  base("Спартак" ,"Иванов   " ,180,80,1,0  ).
  base("Спартак" ,"Петров   " ,185,85,2,35 ).
  base("Спартак" ,"Сидоров  " ,186,86,3,12 ).
  base("Динамо " ,"Новиков  " ,187,87,4,0 ).
  base("Динамо " ,"Цылев    " ,188,88,5,36 ).
  base("Динамо " ,"Харитонов" ,189,89,6,34 ).
  base("Динамо " ,"Перминов " ,181,81,7,8  ).
  base("ЦСКА   " ,"Хлебутин " ,182,82,8,7  ).
  base("ЦСКА   " ,"Дука     " ,183,83,9,56 ).
  base("ЦСКА   " ,"Петухов  " ,184,84,10,5 ).
  base("Торпедо" ,"Топоров  " ,178,78,11,43).
  base("Торпедо" ,"Пархачев " ,179,79,12,3 ).

  inc1(0).
  inc1(1).
  inc1(2). 
  inc1(3).
  inc1(4). 
  inc1(5).
  inc1(6). 
  inc1(7).
  inc1(8). 
  inc1(9).
% Команды, где футболисты забили более 30 голов
   players:-
    shiftwindow(2),
    base(Kom,Fam,Rost,Wes,Number,Gols),    
    Gols>30,
    window_attr(26),
   write("|Команда: ",Kom, " |Футболист:",Fam," |","Голов: ",Gols),nl,fail.  

% Команды и футболисты, где футболисты не забили голов    
  players:-
    shiftwindow(1),
    base(Kom,Fam,Rost,Wes,Number,Gols),
    Gols<1,
    window_attr(26),
    write("|Команда: ",Kom, " |Футболист:",Fam," |","Голов: ",Gols),nl,fail.
 
% Команды и футболисты, где футболисты,с номерам > 9 забили более 40 голов    
  players:-
    shiftwindow(3),
    base(Kom,Fam,Rost,Wes,Number,Gols),
    Gols>40,
    Number>8,
    window_attr(26),
    write("|Команда: ",Kom, "|Футболист:",Fam," |","Номер: ",Number," |","Голов: ",Gols),nl,fail.
    
% Cписок из 10 футболистов
  players:-
    shiftwindow(4),
    base(Kom,Fam,Rost,Wes,Number,Gols),
    window_attr(26),
    write("  ",Kom, "      ",Fam),nl,fail.
     
    
    