  CONSTANTS
    MAXLENERROR = 148
    
  DATABASE-edit
    choice(INTEGER)
    pick(STRINGLIST)
    memory1(STRING,STRING,INTEGER)
      
/*
  DOMAINS
    NAME = SYMBOL
    COLOR = C(INTEGER,INTEGER)

  DATABASE
    choice(INTEGER)
    pick(STRINGLIST)
    memory1(STRING,STRING,INTEGER)
    pdwstate(ROW,COL,SYMBOL,ROW,COL)
    insmode
    lineinpstate(STRING,COL)
    lineinpflag
*/
%  include "c:\\prolog\\include\\menu.inc"
%  include "c:\\prolog\\include\\lineinp.inc"

  PREDICATES
    editor(INTEGER,INTEGER)
    ask_file
    ask_exit(INTEGER)
    putpick(STRING)
    clear(STRINGLIST,STRING,STRINGLIST)
    makechoice(INTEGER)
    takelist(STRINGLIST,INTEGER,STRING)
    takespace(STRING,STRING)
    cutextended(STRING,STRING)
    listnum_2(STRINGLIST,INTEGER,STRING)
    act(integer)
        
  CLAUSES
    editor(Y,X):-
      assert(choice(1)),!,
      repeat,
        choice(Ch),
        List = ["Загpузить",
              "Редактиpовать",
   	      "Память",
              "Hовый файл",
    	      "Записать",
    	      "Имя файла",
    	      "Каталог",
    	      "Сменить каталог ",
    	      "Cистема",
       	      "Выход"],
        menu(Y,X,31,47,List,"Редактиpование ",Ch,Selection),
        retractall(choice(_)),
        assert(choice(Selection)),
        act(Selection),
      Selection = 10,
      ask_file,!.
       
    
    act(9):-  % OS shell
      system("").

    act(8):-  % Change dir
      disk(Current),
      lineinput(4,1,34,31,47," Имя каталога : ",Current,Dname),
      Dname <> "",
      disk(Dname).
    act(8).  % Change dir
    
    act(7):-  % Directory
      makewindow(2,31,47,"",8,9,10,62),
      dir("","*.*",_,1,1,1),!,
      removewindow.

    act(6):-  % Write to
      memory1(_,Str,Pos),!,
      lineinput(4,1,26,31,47," Имя файла : ","",Fname),
      file_str(Fname,Str),
      retractall(memory1(_,_,_)),
      assert(memory1(Fname,Str,Pos)).
    act(6).  % Write to
    
    act(5):-  % Save file
      memory1(Fname,Str,_),
      file_str(Fname,Str).
    act(5).   % Save file

    act(4):-  % New file
      ask_file,
      lineinput(4,1,26,31,47," Имя файла : ","",Fname),
      assertz(memory1(Fname,"",0)),
      act(2),!.
      
    act(3):-  % Pick
      pick(List),
      menu(4,1,31,47,["   -- Загpузить файл --   "|List]," Вызванные файлы ",1,Choice),
      makechoice(Choice).       
  
    act(1):- % Загpузить файл
      lineinput(4,1,26,31,47," Имя файла : ","*.*",Mask),
      makewindow(2,31,47,"",8,9,10,62),
      dir("",Mask,Fname,1,1,1),
      file_str(Fname,Str),
      removewindow,
      putpick(Fname),
      ask_file,
      assert(memory1(Fname,Str,0)),
      act(2),!.
    
    act(2):- % Редактиpовать
      memory1(Fname,Str,Pos),!,
      makewindow(1,31,47,"",0,0,25,80),
      edit(Str,OutStr,"",Fname,"",Pos,"",1,1,1,1,RetPos,RetCode),
      ask_exit(RetCode),
      retractall(memory1(_,_,_)),!,
      assert(memory1(Fname,OutStr,RetPos)),
      removewindow.

    act(2):- % Редактиpовать
      makewindow(1,31,47,"",0,0,25,80),
      edit("",OutStr,"","work.txt","",0,"",1,1,1,1,RetPos,RetCode),
      assertz(memory1("work.txt",OutStr,RetPos)),
      ask_exit(RetCode),
      removewindow.
  
    act(_).
    
    ask_file:-
      memory1(Fname,OldStr,_),
      lineinput(4,1,37,31,47," Записать текущий текст ? (д/н) : ","д",Answ),
      Answ = "д",!,
      file_str(Fname,OldStr),
      retractall(memory1(_,_,_)).
    ask_file:-
      retractall(memory1(_,_,_)).
    ask_file.
    
    ask_exit(0):-    
      act(10).
    ask_exit(_).

    takespace("",""):-!.
    takespace(Str,NewStr):-
      frontstr(1,Str,Char,Rest),
      takespace(Rest,Work),
      Char <> " ",!,
      concat(Char,Work,NewStr).
    takespace(Str,NewStr):-
      frontchar(Str,_,Rest),
      takespace(Rest,NewStr).

    takelist([],_,""):-!.
    takelist([H|_],1,H):-!.
    takelist([_|T],Int,Str):-
      Int1 = Int - 1,
      takelist(T,Int1,Str).

    makechoice(1):-!,
      act(1). % Загpузить файл
    makechoice(Ch):-
      Choice = Ch - 1,
      pick(List),
      takelist(List,Choice,Fn),
      Choice <> -1,!,
      takespace(Fn,Fname),
      file_str(Fname,Str),
      putpick(Fname),
      ask_file,
      assertz(memory1(Fname,Str,0)),
      act(2),!.
    makechoice(_).
  
    putpick(Fn):-
      concat(Fn," ",Fname),
      pick(List),
      retractall(pick(_)),
      clear(List,Fname,NewList),
      assertz(pick([Fname|NewList])).
    putpick(Fn):-
      concat(Fn," ",Fname),
      assertz(pick([Fname])).

    clear([],_,[]):-!.
    clear([H|T],H,T):-!.
    clear([H|T1],X,[H|T2]):-
      clear(T1,X,T2).    

    cutextended("",""):-!.
    cutextended(Str,""):-
      frontchar(Str,Char,_),
      Char = '.',!.
    cutextended(Str,NewStr):-
      frontstr(1,Str,Char,Rest),
      cutextended(Rest,Work),
      concat(Char,Work,NewStr).
    
    listnum_2([],_,""):-!.
    listnum_2([H|_],1,H):-!.
    listnum_2([_|T],Num,Str):-
      Num1 = Num - 1,
      listnum_2(T,Num1,Str).
    
