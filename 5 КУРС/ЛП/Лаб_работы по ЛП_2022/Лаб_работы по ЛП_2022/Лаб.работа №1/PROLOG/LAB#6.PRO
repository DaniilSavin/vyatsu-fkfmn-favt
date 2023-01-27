domains

 C,N=integer
 R=real
 Slist=string*
 Rlist=real*

predicates
 start

goal
 start().

clauses

 start:-
        makewindow(1,7,7,"Определение неисправности PC",0,0,10,80),
        InitRule1(C1),
	InitRule2(C2),
	InitRule3(C3),
	InitRule4(C4),
	InitRule5(C5),
	InitRule6(C6),
	InitRule7(C7),
	InitRule8(C8),
	InitRule9(C9),
	InitRule10(C10),
	InitRule11(C11),
	InitVes(Ves),
	InitFacts(Facts),
        menu.

 Rule (a, pos, e1, pos, e9,   _,  _,   _,  _,   _,  _,   _,   _,0.9).
 Rule (a, neg, e3, pos, e4,   _,  _,   _,  _,   _,  _,   _,   _,0.8).
 Rule (a, pos, e4, pos, e6, neg, e7,   _,  _,   _,  _,   _,   _,0.9).
 Rule (o, pos, c2, pos, e5, pos, e8,   _,  _,   _,  _,   _,   _,0.7).
 Rule (o, pos, e2, pos, e7,   _,  _,   _,  _,   _,  _,   _,   _,0.6).
 Rule (a, pos, e5, pos, e10,  _,  _,   _,  _,   _,  _,   _,   _,0.8).
 Rule (a, pos, e3, pos, e8,   _,  _,   _,  _,   _,  _,   _,   _,0.8).
 Rule (a, neg, e4, neg, e5, neg, e6, neg, e8, neg, e9, neg, e10,0.9).
 Rule (a, pos, c5, pos, e8,   _,  _,   _,  _,   _,  _,   _,   _,0.9).
 Rule (o, pos, c1, pos, e4,   _,  _,   _,  _,   _,  _,   _,   _,0.6).
 Rule (o, pos, c6, pos, e6,   _,  _,   _,  _,   _,  _,   _,   _,0.6).
 
 hypotes(c3).
 hypotes(c4).
 hypotes(c7).
 hypotes(c8).
 hypotes(c9).
 hypotes(c10).
 hypotes(c11).
 
 InitFactsHead ([]).
 InitFactsValue([]).
 InitFactsHead ([]).
 InitFactsValue([]).

 repeat.
 repeat:-repeat.

 menu:-
         repeat,
         shiftwindow(1),
         clearwindow,
         write("1) Просмотр БЗ"),nl,
         write("2) Запуск БЗ"),nl,
         write("3) Объяснения"),nl,
         write("4) Выход"),nl,nl,
         Readint(A),nl,
         A<5,A>0,process(A),
         A=4,!.

 Process(2):-
        makewindow(2,7,7,"Запуск базы знаний",0,0,25,80),
        AskForFacts(Facts).

 Process(4):-
         write("Выйти ? [Y/N] :"),
         readln(A),
         frontchar(A,'y',_),!.


 AskForFacts(Facts):-
        repeat,
        Shiftwindow(2),
        clearwindow,
        write("0) Запуск экспертной системы"),
        write("1) Частое зависание ПО="),
        GetReal(1,X,Facts),
        write(X),nl,
        write("2) Часто переносился винчестер="),
        GetReal(2,X,Facts),
        write(X),nl,
        write("3) Нет реакции на клавиатуру="),
        GetReal(3,X,Facts),
        write(X),nl,
        write("4) Нет загрузки ОС="),
        GetReal(4,X,Facts),
        write(X),nl,
        write("5) Звуковой сигнал при загрузке="),
        GetReal(5,X,Facts),
        write(X),nl,
        write("6) Черный экран при загрузке="),
        GetReal(6,X,Facts),
        write(X),nl,
        write("7) Эксплуатация более 3х лет="),
        GetReal(7,X,Facts),
        write(X),nl,
        write("8) Сообщения при загрузке="),
        GetReal(8,X,Facts),
        write(X),nl,
        write("9) Температура CPU больше комнатной="),
        GetReal(9,X,Facts),
        write(X),nl,
        write("10) Мигает индикатор на мониторе="),
        GetReal(10,X,Facts),
        write(X),nl,nl,
        write("Введите номер факта:"),
        readint(N),nl,
        N<11,N>0,
        write("Введите коэффициент уверенности:"),
        readreal(R),nl,
        Setreal(N,R,Facts),nl;
        N=0,!.

