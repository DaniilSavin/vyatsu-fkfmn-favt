          domains
file=dbase1;
     indexfile
fam,grup,zvet=string
rost,N=integer

          database
dstud(fam,grup,rost,zvet)

          predicates
menu
process(N)
repeat

          goal
menu.

          clauses

repeat.
repeat:-repeat.
menu:-
repeat,
write("Для ввода данных в базу фактов введите 1"),nl,
write("Для просмотра данных в базе фактов введите 2"),nl,
write("Для выхода введите 3"),nl,
write("Для сохранения введите 4"),nl,
write("Для загрузкия введите 5"),nl,
readint(N),
process(N),
N=3,!.




process(4):-
makewindow(3,7,7,"Сохранение",2,20,18,58),
save("dbase1.dba"),
nl,!,
write("Нажмите клавишу"),
readchar(_), 
removewindow.

process(5):-
makewindow(4,7,7,"Загрузка",2,20,20,50),
consult("dbase1.dba"),
nl,!,
write("Нажмите клавишу"),
readchar(_), 
removewindow.

process(1):-
makewindow(1,7,7,"Список",2,20,18,58),
write("Введите Фамилию"),nl,
readln(Fam),
write("Введите группу"),nl,
readln(Grup),
write("Введите рост"),nl,
readint(Rost),
write("Введите цвет волос"),nl,
readln(Zvet),
assertz(dstud(Fam,Grup,Rost,Zvet)),
write("Записано в БД"),
nl,!,
write("Нажмите клавишу"),
readchar(_), 
removewindow.

process(2):-
makewindow(2,7,7,"Просмотр_списка",1,1,20,50),
write("Введите цвет волос"),nl,
readln(Zvet),
dstud(Fam,Grup,Rost,Zvet),
write("группа",Grup),nl,
write("рост", Rost),nl,
write("фамилия",Fam),nl,
nl,fail,
readln(_),
removewindow.

process(3):-
write("Вы хотите закончить y\n"),
readln(A),
frontchar(A,'y',_),!.