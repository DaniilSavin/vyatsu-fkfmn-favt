
predicates
        derevo(string,integer,integer,integer,integer,integer,integer)
        derevo2(string,integer,integer,integer,integer,integer,integer)
goal
        derevo2(N,P,D,O,V,R,L).

clauses
        derevo2(N,P,D,O,V,R,L):-
        makewindow(1,7,7,"Дерево",0,0,25,80),
        gotowindow(1),
        makewindow(2,7,7,"Оперение",1,1,7,35),
        shiftwindow(2),
        write("     0 - Листья"),nl,
        write("     1 - Иголки"),nl,
        readint(P),
/*        str_int(C,P),*/

        makewindow(3,7,7,"Ветки",1,1,9,35),
        shiftwindow(3),
        write("     0 - вверх"),nl,
        write("     1 - вниз"),nl,
        readint(D),
        str_int(I,D),

        makewindow(4,7,7,"Хвоя",1,1,9,35),
        shiftwindow(4),
        write("     0 - короткая"),nl,
        write("     1 - длинная"),nl,
        write("     2 - нет"),nl,
        readint(O),
/*        str_int(A,O),*/

        makewindow(5,7,7,"Кора",1,1,9,35),
        shiftwindow(5),
        write("     0 - белая"),nl,
        write("     1 - черная"),nl,
        readint(V),
/*        str_int(Y,V),*/

        makewindow(6,7,7,"Толщина",1,1,9,35),
        shiftwindow(6),
        write("   Рост "),nl,
        write("     0 - тонкое"),nl,
        write("     1 - среднее"),nl,
        write("     2 - толстое"),nl,
        readint(R),
/*        str_int(Z,R),*/

        makewindow(7,7,7,"Высота",1,1,9,35),
        shiftwindow(7),
        write("     0 - среднее"),nl,
        write("     1 - высокое"),nl,
        readint(L),
/*        str_int(E,L),*/
        derevo(N,P,D,O,V,R,L),

        makewindow(8,7,7,"Дерево",1,1,9,35),
        shiftwindow(8),
        write("Это ",N,"!"),


        derevo("елка",1,1,0,1,1,1).
        derevo("сосна",1,1,1,1,1,1).
        derevo("береза",0,0,2,0,1,0).
        derevo("осина",0,1,2,1,0,0).
        derevo("дуб",0,0,2,2,1,1).
        derevo("тополь",0,0,2,1,2,1).
        derevo("кедр",0,0,2,1,1,1).


