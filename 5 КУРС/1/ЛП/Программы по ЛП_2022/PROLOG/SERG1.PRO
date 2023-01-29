domains
  name_list=string*
  name,group,city=string
  gols=integer*
  gol=integer
  
predicates
  main.
  base(string,string,string).
  Insert_sort(gols,name_list,gols,name_list).
  Insert(gol,name,gols,name_list,gols,name_list).
  asc_order(integer,integer).
  insertf(gols,name_list,gols,name_list).
/*  ins1(gol,name,gols,name_list).*/
  wr(name_list,gols).
  
goal
  main.

clauses
  base("Иванов","Торпедо","Москва").
  base("Петров","Спартак","Москва").
  base("Сидоров","ЦСК","Москва").
  base("Орлов","Динамо","Киев").
  base("Быков","Молот","Москва").

  
  main:-
	clearwindow,
  	makewindow(2,7,7,"список1",5,1,10,35),
        Names=["Иванов" , "Петров" , "Сидоров" , "Орлов" , "Быков"],
        Golss=[19,17,14,19,21],
	insert_sort(Golss,Names,SG,SN),
	gotowindow(2),
	wr(SN,SG),
	makewindow(3,7,7,"список2",5,36,10,35),
	gotowindow(3),
	insertf(Golss,Names,SG1,SN1),
	wr(SN1,SG1).

  wr([],[]).
  wr([X|LN],[Y|LG]):-
	  write(" ",X,"        ",Y),
	  wr(LN,LG).
	
  insert_sort([],[],[],[]).
  insert_sort([X|TG],[Z|TN],S_LG,S_LN):-
  	insert_sort(TG,TN,S_TG,S_TN),
  	insert(X,Z,S_TG,S_TN,S_LG,S_LN).

  	
  insert(X,Z,[Y|S_LG],[Z1|S_LN],[Y|S_LG1],[Z1|S_LN1]):-
  	asc_order(X,Y),
  	insert(X,Z,S_LG,S_LN,S_LG1,S_LN1).
  	
  insert(X,Z,S_LG,S_LN,[X|S_LG],[Z|S_LN]).
  
  asc_order(X,Y):- X<Y.

  insertf([],[],[],[]).	
  insertf([X|G],[Y|N],[X|L_G],[Y|L_N]):-
  	insertf(G,N,L_G,L_N),
	X>18,!.
  insertf([X|G],[Y|N],L_G,L_N):-
  	insertf(G,N,L_G,L_N),
  	X<19.

/*  ins1(X,Y,[X|L_G],[Y|L_N]):-
  	X>18.
  ins1(X,Y,L_G,L_N).*/
	
