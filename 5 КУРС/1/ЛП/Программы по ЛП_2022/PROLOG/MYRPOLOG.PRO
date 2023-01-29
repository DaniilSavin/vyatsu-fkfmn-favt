domains
 list=real*
 str=string*

predicates
 start
 repeat
 menu
 Process(integer)
 min3(real,real,real,real,real)
 min4(real,real,real,real,real,real)
 GetMax(list,str,real,string)
 sortMax(list,str,list,str)
 ins(real,string,list,list,str,str)
 show(list,str)
 OutResult(list,str)
 calculate(real,real,real,real,real,real,real,real,real,real,real)
 OutExplane(integer,real,real,real,real,real,real,real,real,real,real,real)
 Explane(integer,real,real,real,real,real,real,real,real,real,real,real,real,real,real,real)
% SubMenu(real,real,real,real,real,real,real,real,real,real,real,real,real,real,real)

goal
 start().

clauses

 start:-
   makewindow(1,11,11,"",0,0,25,80,11,255,"╔╗╚╝═║"),nl,
  clearwindow,
  cursor(5,0),
  write("               **********************************************"),nl,
  write("               *                                             *"),nl,
  write("               *               Автоматизация                 *"),nl,
  write("               *            предсказания погоды              *"),nl,
  write("               *                                             *"),nl,
  write("               *                                             *"),nl,
  write("               **********************************************"),nl,
  cursor(0,0),
  readchar(DS),
        menu.
 repeat.
 repeat:-repeat.

 menu:-
         repeat,
         shiftwindow(1),
         clearwindow,
         write("1) Просмотр БЗ"),nl,
         write("2) Запуск БЗ"),nl,
         write("3) Выход"),nl,nl,
         Readint(A),nl,
         A<4,A>0,process(A),
         A=3,!.

 Process(1):-
        makewindow(2,7,7,"Просмотр базы знаний",0,0,25,80),
        write("Если Е1 и Е4 и Е8 и Е10,    то С1(0.9)    "),nl,
        write("Если Е2 и Е5 и Е6,          то С2(0.9)    "),nl,
        write("Если Е3 и Е7 и Е8 и Е11,    то С3(0.9)    "),nl,
        write("Если Е2 и Е5 и Е6 и Е11,    то С4(0.9)    "),nl,
        write("Е1- зима                 С1- Холодно"),nl,
        write("Е2- лето                 С2- Оптимально"),nl,
        write("Е3- Межсезонье           С3- Дождливо"),nl,
        write("Е4- Ветер                С4- Жарко"),nl,
        write("Е5- Нет ветра      "),nl,
        write("Е6- Небо ясное     "),nl,
        write("Е7- Небо пасмурное "),nl,
        write("Е8- Влажность большая  "),nl,
        write("Е9- Влажность маленткая "),nl,
        write("Е10- температура < -10  "),nl,
        write("Е11- Температура > +10  "),nl,

        readchar(_),
        removewindow.

 Process(2):-
        makewindow(2,7,7,"Запуск базы знаний",0,0,25,80),
        shiftwindow(2),
        write("Е1-Зима "),nl,
        write("Коэффициент уверенности [0,1] ="),
        readreal(E1),nl,
        write("Е2- Лето"),nl,
        write("Коэффициент уверенности [0,1] ="),
        readreal(E2),nl,
        write("Е3- Межсезонье"),nl,
        write("Коэффициент уверенности [0,1] ="),
        readreal(E3),nl,
        write("Е4- Ветер"),nl,
        write("Коэффициент уверенности [0,1] ="),
        readreal(E4),nl,
        write("Е5- Нет ветра"),nl,
        write("Коэффициент уверенности [0,1] ="),
        readreal(E5),nl,
        write("Е6- Небо ясное"),nl,
        write("Коэффициент уверенности [0,1] ="),
        readreal(E6),nl,
        write("Е7- Небо пасмурное"),nl,
        write("Коэффициент уверенности [0,1] ="),
        readreal(E7),nl,
        write("Е8- Влажность большая"),nl,
        write("Коэффициент уверенности [0,1] ="),
        readreal(E8),nl,
        write("Е9- Влажность маленькая"),nl,
        write("Коэффициент уверенности [0,1] ="),
        readreal(E9),nl,
        write("Е10- Температура < -10"),nl,
        write("Коэффициент уверенности [0,1] ="),
        readreal(E10),nl,
        write("Е11- Температура > +10"),nl,
        write("Коэффициент уверенности [0,1] ="),
        readreal(E11),nl,
        removewindow,
        calculate(E1,E2,E3,E4,E5,E6,E7,E8,E9,E10,E11).

 Process(3).

calculate(E1,E2,E3,E4,E5,E6,E7,E8,E9,E10,E11):-
         min4(E1,E4,E8,E10,0.9,C1),
         min3(E2,E5,E6,0.9,C2),
         min4(E3,E7,E8,E11,0.9,C3),
         min4(E2,E5,E6,E11,0.9,C4),
         L=[C1,C2,C3,C4],
         L1=["Очень холодно","Оптимально","Дождливо","Жарко"],
         OutResult(L,L1).
%         makewindow(12,7,7,"Дополнительное меню",11,20,6,40),
%         SubMenu(E1,E2,E3,E4,E5,E6,E7,E8,E9,E10,E11,C1,C2,C3,C4).


% SubMenu(E1,E2,E3,E4,E5,E6,E7,E8,E9,E10,E11,C1,C2,C3,C4):-
%         repeat,
%         shiftwindow(12),
%         clearwindow,
%         write("1. Объяснения"),nl,
%         write("2. Выход в основное меню"),nl,
%         Readint(A),nl,
%         A>0,A<3,Explane(A,E1,E2,E3,E4,E5,E6,E7,E8,E9,E10,E11,C1,C2,C3,C4),
%         A=2,removewindow,!.
%
%  Explane(2,E1,E2,E3,E4,E5,E6,E7,E8,E9,E10,E11,C1,C2,C3,C4).
  Explane(1,E1,E2,E3,E4,E5,E6,E7,E8,E9,E10,E11,C1,C2,C3,C4):-
        makewindow(2,7,7,"Объяснения",2,5,18,60),
        write("Введите номер целевой вершины: "),
        readint(S),
        write("Е1="),write(E1),write(" -Зима          "),nl,
        write("Е2="),write(E2),write(" -Лето          "),nl,
        write("Е3="),write(E3),write(" -Межсезонье    "),nl,
        write("Е4="),write(E4),write(" -Ветер         "),nl,
        write("Е5="),write(E5),write(" -Нет ветра     "),nl,
        write("Е6="),write(E6),write(" -Небо ясное   "),nl,
        write("Е7="),write(E7),write(" -Небо пасмурное"),nl,
        write("Е8="),write(E8),write(" -Влажность большая   "),nl,
        write("Е9="),write(E9),write(" -Влажность маленькая"),nl,
        write("Е10="),write(E10),write("-Температура <-10   "),nl,nl,
        write("Е11="),write(E11),write("-Температура >+10   "),nl,nl,
        OutExplane(S,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11),nl,
        readchar(_),
        removewindow,!.

 OutExplane(1,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11):- write("C1=Min(E1,E4,E8,E10)*0.9="),write(C1).
 OutExplane(2,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11):- write("C2=Min(E2,E5,E6)*0.9="),write(C2).
 OutExplane(3,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11):- write("C3=Min(Е3,Е7,Е8,E11)*0.9="),write(C3).
 OutExplane(4,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11):- write("C4=Min(Е2,Е5,E6,E11)*0.9="),write(C4).
 OutExplane(N,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11):- N<0;N>12,write("Такой гипотезы не существует !").

min3(X1,X2,X3,V,X4):-X1<=X2,X1<=X3,X4=X1*V.
min3(X1,X2,X3,V,X4):-X2<=X1,X2<=X3,X4=X2*V.
min3(X1,X2,X3,V,X4):-X3<=X1,X3<=X2,X4=X3*V.

min4(X1,X2,X3,X4,V,X5):-X1<=X2,X1<=X3,X1<=X4,X5=X1*V.
min4(X1,X2,X3,X4,V,X5):-X2<=X1,X2<=X3,X2<=X4,X5=X2*V.
min4(X1,X2,X3,X4,V,X5):-X3<=X1,X3<=X2,X3<=X4,X5=X3*V.
min4(X1,X2,X3,X4,V,X5):-X4<=X1,X4<=X2,X4<=X3,X5=X4*V.



OutResult(L2,L3):-
     makewindow(3,7,7,"Автоматизация предсказания погоды",5,15,18,55),
     shiftwindow(3),
     show(L2,L3),
     SortMax(L2,L3,L2_N,L3_N),
     GetMax(L2_N,L3_N,X,Y),
     nl,write("Наибольший коэффициент уверенности: "),nl,
     write(Y),Write("="),Write(X),nl,
     readchar(_),
     removewindow,!.

show([],[]).
show([X|T],[Y|H]):-
     write("  ",X," ",Y),nl,
     show(T,H).

GetMax([H|T],[H1|T1],X,Y):-X=H,Y=H1.

SortMax([],[],[],[]).
SortMax([X|T],[Y|R],SL,SH):-
     SortMax(T,R,ST,SR),
     ins(X,Y,ST,SL,SR,SH).

ins(X,Y,[I|SL],[I|SL1],[J|SR],[J|SR1]):-
     X<I,!,
     ins(X,Y,SL,SL1,SR,SR1).

ins(X,Y,SL,[X|SL],SR,[Y|SR]).