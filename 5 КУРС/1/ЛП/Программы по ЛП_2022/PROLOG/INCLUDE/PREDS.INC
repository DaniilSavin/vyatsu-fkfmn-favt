/****************************************************************************/
/* ...                                                             199O.(A).*/
/* Модуль (C)Predicates содержит :					    */	
/* tab(INTEGER) ..........  - вывод на поток указанного количества пробелов.*/
/* writeln(SYMBOL) .......  - вывод на поток переменной с переводом строки. */
/* power(REAL,INTEGER,REAL) - возведение в указанную степень.               */
/* bwrite(SYMBOL) ........  - подключение звукового сигнала к выводу строки.*/
/* integer(REAL) .........  - согласуется с базой данный, если число целое. */									    
/* even(REAL) ............  - "------" , если число четное.		    */
/* ...									    */	
/****************************************************************************/
  include "e:\\prolog\\include\\tickfile.inc"
  PREDICATES
    tab(integer)
    writeln(symbol)
    sqr(real,real)
    power(real,integer,real)
    bwrite(symbol)
    integer(real)
    even(real)
    timer(symbol)
  CLAUSES
    even(X_VAR):-
      X1 = X_VAR / 2,
      integer(X1),!.
    integer(X_VAR):-
      X1 = round(X_VAR),
      X1 = X_VAR,!.
    timer(Char):-
      Char <> " ",
      sound(5,30000).
    timer(Char):-
      Char = " ",
      ticks(4).
    bwrite(""):-
      write(" "),!.
    bwrite(List):-
      frontstr(1,List,Work,Rest),
      timer(Work),
      write(Work,"█"),
      cursor(Y,X),
      X1 = X - 1,
      cursor(Y,X1),
      bwrite(Rest).
    sqr(0,0):-!.
    sqr(1,1):-!.
    sqr(Start,Finish):-
      Finish = Start * Start.
    power(0,_,0).
    power(1,_,1).
    power(_,0,1).
    power(Start,1,Start).
    power(Start,Hight,Finish):-
      Hight > 0,!,
      H1 = Hight - 1, 
      power(Start,H1,Timer),
      Finish = Start * Timer.
    power(Start,Hight,Finish):-
      H1 = Hight + 1,
      power(Start,H1,Timer),
      Finish = 1 / Start * Timer.

    writeln(List):-
      write(List),
      nl.
    tab(0):-!.
    tab(Space):-
      write(" "),
      S1 = Space - 1,
      tab(S1).
      
      
      