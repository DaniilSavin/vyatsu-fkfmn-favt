domains      %объявл переменных
 c=integer
 s=string
 y=string*     % указатели на массив типа стринг
 iy=integer*
 ry=real*

database      % описание баз данных
 koefe(ry)    ;
 koefc(ry)    ;
 indexc(y)    ;
 koefisk(ry)  ;
 index(y)     ;
 mainv(ry)    ;
 mainvs(y)    ;

predicates    %  Назв функций и тип аргументов
 menu
 zzz
 vivod(y,ry)
 imp(s,s,s,s,s)
 findv(y,ry,s,real)
 findv2(ry,y,real,s)
 /*base*/
 process(c)             %отклик на нажатие клавиши (6)
 disappend(s,ry,y)
 appendc(real,ry,ry)   % добавление Integer
 appends(s,y,y)        % добавление String
 appendn(ry,y)         % добавление
 aa
 new(s,real,s,ry,y,ry,y)
 sort(s,ry,y,ry,y)
 glob(real,real,real,s,s)
 count(real,real,s,real)
 min(real,real,real)
 max(real,real,real)
 nadoli(s,s,real)
 findmax(y,ry)
 sous(ry,ry)
 opa(real,ry,ry)
 viv(s)
 ujas(s)
 ujas2(s,s,s)

goal
 aa.

clauses
 aa:-
    makewindow(1,10,14,"БД",0,0,25,80),
    write("1-Ввод коэффициентов уверенности"),nl,
    write("2-Чтение коэф. уверенности из БД"),nl,
    write("3-Обьяснения"),nl,
    write("4-Определение гипотезы с наибольшим коэф. уверенности"),nl,
    write("5-Удаление коэффициентов"),nl,
    write("6-Добавление коэффициентов"),nl,
    write("7-Выход"),nl,
    consult("Anton.dat"),
    retractall(mainv(_)),
    assertz(mainv([])),
    retractall(mainvs(_)),
    assertz(mainvs([])),
    retractall(index(_)),
    assertz(index([])),
    retractall(koefisk(_)),
    assertz(koefisk([])),
    save("Anton.dat"),
    menu.

 menu:-           % вызов меню
   readint(H),    % ввод данных тип int-r (cтанд.)
   process(H),
   /*write(LL),*/
   H<7,
   H>0,
   menu.

 imp("c1","kf1","and","e1","e2").  %основная проц
 imp("c2","kf1","and","e2","e3").
 imp("c3","kf1","and","e3","e6").
 imp("c4","kf1","and","e4","e5").
 imp("c5","kf1","and","e3","e5").
 imp("c6","kf1","and","e3","e7").
 imp("g1","kf1","and","e1","c6").
 imp("g2","kf1","and","e1","c5").
 imp("g3","kf1","and","e1","c3").
 imp("g4","kf1","and","c1","e6").
 imp("g5","kf1","and","e2","e7").
 imp("g6","kf1","and","c2","c4").

 process(1):-
    makewindow(2,7,14,"Факты",0,40,10,40),
    write("E1 - Наличие атмосферы"),nl,
    write("E2 - Большое расстояние до Солнца"),nl,
    write("E3 - Земная группа"),nl,
    write("E4 - Двойная планета"),nl,
    write("E5 - Большая яркость"),nl,
    write("E6 - Средняя яркость"),nl,
    write("E7 - Малая яркость"),nl,
    makewindow(3,7,14,"Ввод коэф. уверенности",0,0,10,40),
    write("Введите E1: "),
    readreal(J1),
    write("Введите E2: "),
    readreal(J2),
    write("Введите E3: "),
    readreal(J3),
    write("Введите E4: "),
    readreal(J4),
    write("Введите E5: "),
    readreal(J5),
    write("Введите E6: "),
    readreal(J6),
    write("Введите E7: "),
    readreal(J7),
    L=[J1,J2,J3,J4,J5,J6,J7],
    retractall(koefe(_)),
    assertz(koefe(L)),
    retractall(koefisk(_)),
    assertz(koefisk(L)),
    retractall(index(_)),
    assertz(index(["e1","e2","e3","e4","e5","e6","e7"])),
    save("anton.dat"),
    removewindow,
    shiftwindow(2),
    removewindow,
    cursor(7,0),
    write(" "),
    cursor(7,0).

   process(2):-
     consult("Anton.dat"),
     koefe(L).

   process(3):-
      makewindow(2,9,14,"Обьяснения",0,0,15,40),
      write("Введите вершину: "),
      readln(V),
      ujas(V),
      readln(_),
      removewindow,
      shiftwindow(2),
      removewindow,
      cursor(7,0),
      write(" "),
      cursor(7,0).

   process(4):-
     retractall(mainv(_)),
     retractall(mainvs(_)),
     assertz(mainv([])),
     assertz(mainvs([])),
     save("Anton.dat"),
     koefe(LMN),
     retractall(koefe(_)),
     retractall(koefisk(_)),
     assertz(koefe(LMN)),
     assertz(koefisk(LMN)),
     retractall(index(_)),
     assertz(index(["e1","e2","e3","e4","e5","e6","e7"])),
     save("Anton.dat"),
     zzz,  %рассчёт вероятностей
     mainv(L),
     mainvs(L2),
     makewindow(3,10,12,"Помощь",1,40,20,40),
     write("G1-Меркурий"),nl,
     write("G2-Венера"),nl,
     write("G3-Марс"),nl,
     write("G4-Юпитер"),nl,
     write("G5-Уран"),nl,
     write("G6-Плутон"),nl,
     makewindow(2,11,12,"БД",1,1,20,40),
     vivod(L2,L),
     findmax(L2,L),
     readln(_),
     removewindow,
     shiftwindow(3),
     removewindow,
     cursor(7,0),
     write(" "),
     cursor(7,0).

   process(5):-
    makewindow(2,7,14,"Коэффициенты",0,40,10,40),
    indexc(L1),
    koefc(L2),
    vivod(L1,L2),
    makewindow(3,7,14,"Удаление коэффициентов",0,0,10,40),
    write("Введите назв. удаляемого коэф.: "),
    readln(J),
    koefc(C),
    indexc(I),
    disappend(J,C,I),
    save("anton.dat"),
    removewindow,
    shiftwindow(2),
    removewindow,
    cursor(7,0),
    write(" "),
    cursor(7,0).

   process(6):-
    makewindow(2,7,14,"Коэффициенты",0,40,10,40),
    indexc(L1),
    koefc(L2),
    vivod(L1,L2),
    makewindow(3,7,14,"Добавление коэффициентов",0,0,10,40),
    write("Введите название добавляемого коэф.: "),
    readln(J),
    write("Введите значение добав-ого коэф.: "),
    readreal(T),
    koefc(C),
    indexc(I),
    appendc(T,C,X),
    appends(J,I,X2),
    retractall(koefc(_)),
    retractall(indexc(_)),
    assertz(koefc(X)),
    assertz(indexc(X2)),
    save("anton.dat"),
    removewindow,
    shiftwindow(2),
    removewindow,
    cursor(7,0),
    write(" "),
    cursor(7,0).

  process(7):-
   retractall(koefisk(_)),
   retractall(index(_)),
   assertz(koefisk([])),
   assertz(index([])),
   retractall(mainv(_)),
   retractall(mainvs(_)),
   assertz(mainv([])),
   assertz(mainvs([])),
   save("anton.dat"),
   2=1.

  findv([STR|N1],[I|N2],STR,I).
  findv([H1|N1],[H2|N2],STR,K):-findv(N1,N2,STR,K).

  findv2([I|N2],[STR|N1],I,STR).
  findv2([H1|N1],[H2|N2],STR,K):-findv2(N1,N2,STR,K).

  findmax(S,R):-
    Sous(R,[K|R2]),
    findv2(R,S,K,CH),
    write("Максимальное значение: "),
    write(CH),
    write("="),
    write(K).


  Sous([],[]).
  Sous([A|C],B1):-Sous(C,L),opa(A,L,B1).
  opa(A,[B|B1],[B|B2]):-A<B,!,opa(A,B1,B2).
  opa(A,B1,[A|B1]).


  zzz:-
     imp(C,K,O,E1,E2),
     koefisk(L),
     Index(LM),
     findv(LM,L,E1,ER1),
     findv(LM,L,E2,ER2),
     koefc(L1),
     Indexc(LM1),
     findv(LM1,L1,K,KO),
     glob(ER1,ER2,KO,O,C),
     fail.

  zzz:-!.

  ujas(V):-
      makewindow(3,7,14,"Коэффициенты",0,40,15,20),
      indexc(L1),
      koefc(L2),
      vivod(L1,L2),
      makewindow(3,10,14,"Парам.",0,60,15,20),
      koefe(L),
      vivod(["E1","E2","E3","E4","E5","E6","E7"],L),
      shiftwindow(2),
      ujas2(V,E1,E2),
      ujas2(E1,N11,N21),
      ujas2(E2,N12,N22).

  ujas2(V,K1,K2):-
      imp(C,K,O,E1,E2),
      C=V,
      !,
      koefisk(R),
      index(S),
      write(V),write("="),findv(S,R,V,N),write(N),nl,
      write(V),write("="),viv(O),write(E1),write("*"),write(K),write(","),write(E2),write("*"),write(K),write(")"),nl,
      findv(S,R,E1,N2),findv(S,R,E2,N3),
      koefc(CC),indexc(CI),findv(CI,CC,K,KO),
      write(V),write("="),viv(O),write(N2),write("*"),write(KO),write(","),write(N3),write("*"),write(KO),write(")"),nl,
      K1=E1,K2=E2,nl.

   ujas2(V,A,B):-!.
   ujas2(V,A,B):-!.

   viv("and"):-write("min(").
   viv("or"):-write("max(").

  glob(A1,A2,KO,OP,C):-
   index(M1),
   koefisk(M2),
   I=C,
   J1=A1*KO,
   J2=A2*KO,
   count(J1,J2,OP,J),
   appends(I,M1,K),
   appendc(J,M2,K2),
   retractall(koefisk(_)),
   retractall(index(_)),
   assertz(koefisk(K2)),
   assertz(index(K)),
   frontstr(1,C,N,E),
   nadoli(N,C,J),
   save("Anton.dat").

  nadoli("g",C,J):-
   mainv(L),
   mainvs(M),
   appendc(J,L,L2),
   appends(C,M,L3),
   retractall(mainv(_)),
   retractall(mainvs(_)),
   assertz(mainv(L2)),
   assertz(mainvs(L3)).

  nadoli(N,C,J):-N<>"g".

  count(J1,J2,"and",J):-min(J1,J2,J).
  count(J1,J2,"or",J):-max(J1,J2,J).

  min(J1,J2,J):-J1>=J2,J=J2.
  min(J1,J2,J):-J1<J2,J=J1.
  max(J1,J2,J):-J1>J2,J=J1.
  max(J1,J2,J):-J1<=J2,J=J2.

  vivod([],[]).
  vivod([N1|L1],[N2|L2]):-write(N1),write(": "),write(N2),nl,vivod(L1,L2).

  disappend(J,C,I):-
    sort(J,C,I,XC,XI),
    appendn(XC,XI).

  sort(J,[],[],[],[]).
  sort(J,[N|X],[N1|X1],Y,Y1):-sort(J,X,X1,Z1,Z2),new(J,N,N1,Z1,Z2,Y,Y1).

  new(J,A,A1,E1,E2,[A|E1],[A1|E2]):-A1<>J.
  new(J,A,A1,E1,E2,E1,E2):-A1=J.

  appendn(B,D):-              % добавление элементов b d в две БД
     retractall(koefc(_)),
     assertz(koefc(B)),       % в koefc
     retractall(indexc(_)),
     assertz(indexc(D)),
     save("Anton.dat").

  %appendc([],C,C).
  appendc(A,B,C):-C=[A|B].       %appendc(A,B,C).

  %appends([],C,C).
  appends(A,B,C):-C=[A|B].       %appends(A,B,C).


  /*base:-
  assertz(dplayer("1","2","3")),
  assertz(dplayer("4","5","6")),
  save("anton.dat").*/
