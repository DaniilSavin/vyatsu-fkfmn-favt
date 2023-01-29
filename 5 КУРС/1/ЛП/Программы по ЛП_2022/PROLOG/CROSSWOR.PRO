predicates % определение предикатов
 Summa. % Цель
  goal 					      % цель
  Summa.  
      
clauses % определение фактов и правил
Summa:-
     N1=412340,
     N2=N1+N1,
     C='м',
     D='л',
     E='я',
           
     makewindow(1,5,6,"СТУЛЬЯ+СТУЛЬЯ=МЕБЕЛЬ",5,20,20,35),
     write("   "),nl,nl,
     write("   По горизонтали:"),nl,
     
     S1=trunc(N1/1000),
     S1=S1 div 100,
    
     write(N1,' ',N2,' ',S1,"<="),write(C,D,E),nl,     
     nl.    

