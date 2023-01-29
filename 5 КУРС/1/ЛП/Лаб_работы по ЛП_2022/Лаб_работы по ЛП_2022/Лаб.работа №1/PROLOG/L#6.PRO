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
 max2(real,real,real)
 GetMax(list,str,real,string)
 sortMax(list,str,list,str)
 ins(real,string,list,list,str,str)
 show(list,str)
 OutResult(list,str)
 calculate(real,real,real,real,real,real,real,real,real,real,real,real)
 OutExplane(integer,real,real,real,real,real,real,real,real,real,real,real,real)
 Explane(integer,real,real,real,real,real,real,real,real,real,real,real,real,real,real,real,real,real,real,real,real,real,real,real,real)
 SubMenu(real,real,real,real,real,real,real,real,real,real,real,real,real,real,real,real,real,real,real,real,real,real,real,real)

goal
 start().

clauses

 start:-
   makewindow(1,11,11,"",0,0,25,80,11,255,"╔╗╚╝═║"),nl,
  clearwindow,
  cursor(5,0),
  write("               **********************************************"),nl,
  write("               *                                             *"),nl,
  write("               *               Автоматизация выбора          *"),nl,
  write("               *                предметов одежды             *"),nl,
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
        write("Если Е2 и Е7 и Е10 и Е11,    то С1(0.9)    "),nl,
        write("Если Е2 и Е7 и Е10 и Е12,    то С2(0.9)    "),nl,
        write("Если Е2 и Е6 и Е10 и Е11,    то С3(0.9)    "),nl,
        write("Если Е2 и Е6 и Е10 и Е12,    то С4(0.9)    "),nl,
        write("Если Е5 и Е10 и Е11,         то С5(0.9)    "),nl,
        write("Если Е5 и Е10 и Е12,         то С6(0.9)    "),nl,
        write("Если не Е2 и Е7 и Е10 и Е11, то С7(0.9)    "),nl,
        write("Если не Е2 и Е7 и Е10 и Е12, то С8(0.9)    "),nl,
        write("Если Е3 или Е4 и Е9 и Е11,   то С9(0.9)    "),nl,
        write("Если Е3 или Е4 и Е9 и Е12,   то С10(0.9)   "),nl,
        write("Если Е1 и Е9 и Е11,          то С11(0.9)   "),nl,
        write("Если Е1 и Е9 и Е12,          то С12(0.9)    "),nl,
        write("Е1- Зима           С1- Шорты и майка"),nl,
        write("Е2- Лето           С2- Сарафан"),nl,
        write("Е3- Весна          С3- Плавки"),nl,
        write("Е4- Осень          С4- Купальник"),nl,
        write("Е5- Вечерняя       С5- Смокинг и бабочка"),nl,
        write("Е6- Пляжная        С6- Вечернее платье"),nl,
        write("Е7- Повседневная   С7- Костюм и галстук"),nl,
        write("Е8- Домашняя       С8- Костюм "),nl,
        write("Е9- Верхняя        С9- Куртка  "),nl,
        write("Е10- Не верхняя    С10- Плащ"),nl,
        write("Е11- Пол-мужской   С11- Дубленка и шапка "),nl,
        write("Е12- Пол-женский   С12- Шуба и шапка"),nl,

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
        write("Е3- Весна"),nl,
        write("Коэффициент уверенности [0,1] ="),
        readreal(E3),nl,
        write("Е4- Осень"),nl,
        write("Коэффициент уверенности [0,1] ="),
        readreal(E4),nl,
        write("Е5- Вечерняя"),nl,
        write("Коэффициент уверенности [0,1] ="),
        readreal(E5),nl,
        write("Е6- Пляжная"),nl,
        write("Коэффициент уверенности [0,1] ="),
        readreal(E6),nl,
        write("Е7- Повседневная"),nl,
        write("Коэффициент уверенности [0,1] ="),
        readreal(E7),nl,
        write("Е8- Домашняя"),nl,
        write("Коэффициент уверенности [0,1] ="),
        readreal(E8),nl,
        write("Е9- Верхняя"),nl,
        write("Коэффициент уверенности [0,1] ="),
        readreal(E9),nl,
        write("Е10- Не верхняя"),nl,
        write("Коэффициент уверенности [0,1] ="),
        readreal(E10),nl,
        write("Е11- Пол мужской"),nl,
        write("Коэффициент уверенности [0,1] ="),
        readreal(E11),nl,
        write("Е12- Пол женский"),nl,
        write("Коэффициент уверенности [0,1] ="),
        readreal(E12),nl,
        removewindow,
        calculate(E1,E2,E3,E4,E5,E6,E7,E8,E9,E10,E11,E12).

 Process(3).

calculate(E1,E2,E3,E4,E5,E6,E7,E8,E9,E10,E11,E12):-
         min4(E2,E7,E10,E11,0.9,C1),
         min4(E2,E7,E10,E12,0.9,C2),
         min4(E2,E6,E10,E11,0.9,C3),
         min4(E2,E7,E10,E12,0.9,C4),
         min3(E5,E10,E11,0.9,C5),
         min3(E5,E10,E12,0.9,C6),
         X2=1-E2,
         min4(X2,E7,E10,E11,0.9,C7),
         min4(X2,E7,E10,E12,0.9,C8),
         max2(E3,E4,X1),
         min3(X1,E9,E11,0.9,C9),
         min3(X1,E9,E12,0.9,C10),
         min3(E1,E9,E11,0.9,C11),
         min3(E1,E9,E12,0.9,C12),
         L=[C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12],
         L1=["Шорты и майка","Сарафан","Плавки","Купальник",
             "Смокинг и бабочка","Вечернее платье","Костюм и галстук",
              "Костюм","Куртка","Плащ","Дубленка и шапка","Шуба и шапка"],
         OutResult(L,L1),
         makewindow(12,7,7,"Дополнительное меню",11,20,6,40),
         SubMenu(E1,E2,E3,E4,E5,E6,E7,E8,E9,E10,E11,E12,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12).


 SubMenu(E1,E2,E3,E4,E5,E6,E7,E8,E9,E10,E11,E12,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12):-
         repeat,
         shiftwindow(12),
         clearwindow,
         write("1. Объяснения"),nl,
         write("2. Выход в основное меню"),nl,
         Readint(A),nl,
         A>0,A<3,Explane(A,E1,E2,E3,E4,E5,E6,E7,E8,E9,E10,E11,E12,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12),
         A=2,removewindow,!.

  Explane(2,E1,E2,E3,E4,E5,E6,E7,E8,E9,E10,E11,E12,C1,C2,C3,
          C4,C5,C6,C7,C8,C9,C10,C11,C12).
  Explane(1,E1,E2,E3,E4,E5,E6,E7,E8,E9,E10,E11,E12,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12):-
        makewindow(2,7,7,"Объяснения",2,5,18,60),
        write("Введите номер целевой вершины: "),
        readint(S),
        write("Е1="),write(E1),write(" -Зима          "),nl,
        write("Е2="),write(E2),write(" -Лето          "),nl,
        write("Е3="),write(E3),write(" -Весна     "),nl,
        write("Е4="),write(E4),write(" -Осень     "),nl,
        write("Е5="),write(E5),write(" -Вечерняя  "),nl,
        write("Е6="),write(E6),write(" -Пляжная   "),nl,
        write("Е7="),write(E7),write(" -Повседневная  "),nl,
        write("Е8="),write(E8),write(" -Домашняя          "),nl,
        write("Е9="),write(E9),write(" -Верхняя    "),nl,
        write("Е10="),write(E10),write("-Не верхняя   "),nl,nl,
        write("Е11="),write(E11),write("-Пол мужской   "),nl,nl,
        write("Е12="),write(E12),write("-Пол женский   "),nl,nl,
        OutExplane(S,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12),
        nl,
        readchar(_),
        removewindow.

 OutExplane(1,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12):- write("C1=Min(E2,E7,E10,E11)*0.9="),write(C1).
 OutExplane(2,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12):- write("C2=Min(E2,E7,E10,Е12)*0.9="),write(C2).
 OutExplane(3,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12):- write("C3=Min(Е2,Е6,Е10,E11)*0.9="),write(C3).
 OutExplane(4,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12):- write("C4=Min(Е2,Е7,E10,E12)*0.9="),write(C4).
 OutExplane(5,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12):- write("C5=Min(Е5,Е10,E11)*0.9="),write(C5).
 OutExplane(6,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12):- write("C6=Min(Е5,Е10,E12)*0.9="),write(C6).
 OutExplane(7,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12):- write("C7=Min(Е7,Е10,E11,(1-E2))*0.9="),write(C7).
 OutExplane(8,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12):- write("C8=Min(Е7,Е10,Е12,(1-Е2)*0.9="),write(C8).
 OutExplane(9,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12):- write("C9=Min(Max(E3,E4),Е9,Е11)*0.9="),write(C9).
 OutExplane(10,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12):-write("C10=Min(Max(E3,E4),E9,E12)*0.9="),write(C1).
 OutExplane(11,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12):-write("C11=Min(Е1,E9,E11)*0.9="),write(C11).
 OutExplane(12,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12):-write("C12=Min(Е1,С9,E12)*0.9="),write(C12).
 OutExplane(N,C1,C2,C3,C4,C5,C6,C7,C8,C9,C10,C11,C12):- N<0;N>12,write("Такой гипотезы не существует !").


max2(X1,X2,X3):-X1>=X2,X3=X1.
max2(X1,X2,X3):-X2>X1,X3=X2.

min3(X1,X2,X3,V,X4):-X1<=X2,X1<=X3,X4=X1*V.
min3(X1,X2,X3,V,X4):-X2<=X1,X2<=X3,X4=X2*V.
min3(X1,X2,X3,V,X4):-X3<=X1,X3<=X2,X4=X3*V.

min4(X1,X2,X3,X4,V,X5):-X1<=X2,X1<=X3,X1<=X4,X5=X1*V.
min4(X1,X2,X3,X4,V,X5):-X2<=X1,X2<=X3,X2<=X4,X5=X2*V.
min4(X1,X2,X3,X4,V,X5):-X3<=X1,X3<=X2,X3<=X4,X5=X3*V.
min4(X1,X2,X3,X4,V,X5):-X4<=X1,X4<=X2,X4<=X3,X5=X4*V.



OutResult(L2,L3):-
     makewindow(3,7,7,"Автоматизация выбора предметов одежды",5,15,18,55),
     shiftwindow(3),
     show(L2,L3),
     SortMax(L2,L3,L2_N,L3_N),
     GetMax(L2_N,L3_N,X,Y),
     nl,write("Наибольший коэффициент уверенности: "),nl,
     write(Y),Write("="),Write(X),nl,
     readchar(_),
     removewindow.

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