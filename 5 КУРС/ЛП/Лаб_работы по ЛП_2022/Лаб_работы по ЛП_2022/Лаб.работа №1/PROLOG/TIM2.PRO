/*Программа определения деревьев*/
domains
        typeblock=string
        in=integer
predicates
/*Описание предикатов*/
        vnesnprisn(integer)
        heucnp(typeblock)
        writeres(string)
goal

/*Описание цели*/

        writeres(S).

clauses
/*Описание фактов и правил*/

    vnesnprisn(Y):-
        makewindow(1,7,7,"Внешние признаки неисправности",0,0,25,80),
        gotowindow(1),
        write("Отсутствует только звук       -1"),nl,
        write("Отсутствует только свечение   -2"),nl,
        write("Отсутствует только изображение-3"),nl,
        write("Отсутствует звук и изображение-4"),nl,
        write("Отсутствует звук и свечение   -5"),nl,
        readln(KY),
        str_int(KY,Y).

     heucnp("Неисправность в УНЧ"):-
        vnesnprisn(Y),
        Y=1.
     heucnp("Неисправность в строчной развертке"):-
        vnesnprisn(Y),
        Y=2.
     writeres(S):-
        makewindow(1,7,7,"Окно результатов",1,1,10,32),
        shiftwindow(2),
        heucnp(S),
        write(S),nl.

        /*"Неисправность в строчной развертке",
        "Неисправность в кадровой развертке",
        "Неисправность в блоке питания",
        "Неисправность в видеоусилителе",
        "Неисправность в селекторе каналов"*/