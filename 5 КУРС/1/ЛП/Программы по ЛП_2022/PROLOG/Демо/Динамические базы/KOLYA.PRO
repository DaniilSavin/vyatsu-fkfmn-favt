
predicates
futbolist(symbol,integer,integer,integer,symbol)
showfut


goal
makewindow(1,23,7,"Нападающие старше 25лет",0,0,7,30),
makewindow(2,23,7,"Защитники старше 23лет",6,0,7,30),
makewindow(3,23,7,"Полузащитники старше 22лет",10,0,7,30),
showfut.

clauses

futbolist("Сорокин",1,180,26,"Нападающий").
futbolist("Мышкин",2,150,20,"Защитник").
futbolist("Щукин",3,195,32,"Полузащитник").
futbolist("Орлов",4,210,27,"Нападающий").
futbolist("Быков",5,173,29,"Защитник").
futbolist("Воронин",6,183,22,"Полузащитник").
futbolist("Мышкин",7,188,27,"Полузащитник").
futbolist("Воробьев",8,169,29,"Нападающий").
futbolist("Пчела",9,179,31,"Нападающий").
futbolist("Синицин",10,192,25,"Полузащитник").


showfut:-
		shiftwindow(1),
		futbolist(B1,Number,Rost,B2,B3),
		B1="Мышкин",
		write(B1,B3),nl.
		
showfut:-
		shiftwindow(2),		
		futbolist(Fam,Number,Rost,Old,Place),
		Old>23,
		Place="Защитник",
		write(Fam,"  ",Old,"  ",Place),nl,
		fail.
		
showfut:-
		shiftwindow(3),
		futbolist(Fam,Number,Rost,Old,Place),
		Old>22,
		Place="Полузащитник",
		write(Fam,"  ",Old,"  ",Place),nl,
		fail.
	
		
