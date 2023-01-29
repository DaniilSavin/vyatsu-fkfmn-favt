/*
  Copyright (c) 1986, 88 by Borland International, Inc.
*/
/* SYMBOLIC DIFFERENTIATION EXAMPLE */
  DOMAINS
/*
  The input string is converted to a list of
  tokens
*/
TOKL = STRING*

/*
  Expressions are modeled via EXP
*/
EXP=
    real(REAL);
    plus(EXP,EXP);
    minus(EXP,EXP);
    mult(EXP,EXP);
    div(EXP,EXP);
    ln(EXP);
    cos(EXP); 
    sin(EXP); 
    tan(EXP); 
    sec(EXP); 
    potens(EXP,EXP)

  PREDICATES
    strPOTENS(EXP,string);
    strMULT(EXP,string);
    strMINUS(EXP,string);
    strDIV(EXP,string);
    strPAR(EXP,string);

    power(REAL,REAL,REAL)
    run
    diff
    d(EXP,REAL);
    readexp(EXP);
    readexp(EXP,string,integer)
    check(EXP,TOKL,EXP);


    tokl(STRING,TOKL);      /* Scanner */
    front(STRING,TOKL,TOKL);

    s_exp(TOKL,TOKL,EXP);   /* Parser */
    strexp(EXP,string);
    potensexp(TOKL,TOKL,EXP);
    potensexp1(TOKL,TOKL,EXP,EXP);
    multexp(TOKL,TOKL,EXP);
    multexp1(TOKL,TOKL,EXP,EXP);
    plusexp(TOKL,TOKL,EXP);
    plusexp1(TOKL,TOKL,EXP,EXP);
    elmexp(TOKL,TOKL,EXP);

    /* String Editor */
    editstr(string,string,integer,integer,integer).
    editstr(char,string,string,integer,integer,integer).
    editstr(symbol,char,string,string,integer,integer,integer).

    lstcat(TOKL,string)
    
  CLAUSES
    power(0,_,0):-!.
    power(1,_,1):-!.
    power(_,0,1):-!.
    power(Int,0.5,Res):-
      Res = sqrt(Int).
    power(Int,Pow,Res):-
      Pow1 = Pow - 1,
      power(Int,Pow1,Work),
      Res = Work * Int.    
      
    run:- 
      makewindow(1,95,47,"",1,14,10,53),
      write(" С И М В О Л И Ч Е С К И Й   К А Л Ь К У Л Я Т О Р "),
      write("   *********************************************"),nl,
      write("           Выpажение может содеpжать : "),nl,
      write(" сложение, вычитание, умножение, деление \n"),
      write(" возведение в степень, натуpальных логаpифм \n"),
      write(" косинус, синус и тангенс.\n\n"),
      write("пpимеpы :  3+6  или  9*(2+5)^2  или  ln(1+1/(1-3))"),
      makewindow(3,47,95,"",11,3,14,73),
      clearwindow,diff.

    diff:- 
      readexp(EXP),
      d(EXP,Int),
      write("\n  Результат :\n  "),
      write(Int),
      write("\n\n  Для пpодолжения нажмите пpобел"),
      readchar(Char),
      Char = ' ',!,
      diff. 

    diff:-  
      removewindow,
      removewindow.

/*
  CLAUSES FOR DIFFERENTIATION
*/


    d(real(R),R):-!.
    d(plus(U,V),Int):-
      d(U,U1),
      d(V,V1),
      Int = U1 + V1.
    d(minus(U,V),Int):-
      d(U,U1),
      d(V,V1),
      Int = U1 - V1.
    d(mult(U,V),Int):-
      d(U,U1),
      d(V,V1),
      Int = U1 * V1.
    d(div(U,V),Int):-
      d(U,U1),
      d(V,V1),
      V1 <> 0,!,
      Int = U1 / V1.
    d(div(_,_),1):-  
      write(" Деление на ноль !"),
      readchar(_),
      fail,!.
    d(ln(U),Int):-
      d(U,U1),
      U1 <> 0,!,
      Int = ln(U1).
    d(ln(_),1):-
      write(" Логаpифм нуля !"),
      readchar(_),
      fail,!.
    d(potens(E1,real(I)),Int):- 
      d(E1,Var),
      power(Var,I,Int).
    d(sin(U),Int):- 
      d(U,U1),
      Int = sin(U1).
    d(cos(U),Int):- 
      d(U,U1),
      Int = cos(U1).
    d(tan(U),Int):- 
      d(U,U1),
      Int = tan(U1).
  
/*
  CLAUSES FOR READING OF AN EXPRESSION
*/
  readexp(EXP) :-
      clearwindow,
      cursor(11,1),
      write("<?> Подсказка"),
      cursor(1,1),
      write("Ввести выpажение : "),!,
      readexp(EXP,"",0).
  readexp(real(0)):-exit(0).

  readexp(EXP1,STR,Pos) :-
      cursor(Ypos,Xpos),
      editstr(STR,STR1,Xpos,Ypos,Pos),
      cursor(2,0), write("                                            "),
      cursor(2,22),
      tokl(STR1,TOKL),
      s_exp(TOKL,OL,EXP),
      !,
      check(EXP,OL,EXP1).

  check(EXP,[],EXP):-
      cursor(2,22),
      write("                                             \n"), 
      write("                                             \n"),
      write("                                             \n"),
      write("                                             \n"),
      write("                                             \n"),
      cursor(2,0),!.
  check(EXP,Rest,NewExp):- 
      strexp(EXP,Str1),
      lstcat(Rest,Str2),
      str_len(Str1,LenStr1),
      ErrPos = 22 + LenStr1,
      cursor(2,ErrPos),
      write("^ синтаксическая ошибка"),
      cursor(1,22),
      concat(Str1,Str2,Str3),
      !,
      readexp(NewExp,Str3,LenStr1).
      

  tokl(STR,[TOK|TOKL]):-
      fronttoken(STR,TOK,STR1),!,
      tokl(STR1,TOKL).
  tokl(_,[]).


/*
  CLAUSES FOR PARSING OF AN EXPRESSION
*/

  s_exp(IL,OL,EXP):-plusexp(IL,OL,EXP).

  plusexp(IL,OL,EXP2):-
      multexp(IL,OL1,EXP1),
      plusexp1(OL1,OL,EXP1,EXP2).

  plusexp1(["+"|IL],OL,EXP1,EXP3):-!,
      multexp(IL,OL1,EXP2),
      plusexp1(OL1,OL,plus(EXP1,EXP2),EXP3).
  plusexp1(["-"|IL],OL,EXP1,EXP3):-!,
      multexp(IL,OL1,EXP2),
      plusexp1(OL1,OL,minus(EXP1,EXP2),EXP3).
  plusexp1(IL,IL,EXP,EXP).

  multexp(IL,OL,EXP2):-
      potensexp(IL,OL1,EXP1),
      multexp1(OL1,OL,EXP1,EXP2).

  multexp1(["*"|IL],OL,EXP1,EXP3):-!,
      potensexp(IL,OL1,EXP2),
      multexp1(OL1,OL,mult(EXP1,EXP2),EXP3).
  multexp1(["/"|IL],OL,EXP1,EXP3):-!,
      potensexp(IL,OL1,EXP2),
      multexp1(OL1,OL,div(EXP1,EXP2),EXP3).
  multexp1(IL,IL,EXP,EXP).

  potensexp(IL,OL,EXP2):-
      elmexp(IL,OL1,EXP1),
      potensexp1(OL1,OL,EXP1,EXP2).
  potensexp1(["^"|IL],OL,EXP1,EXP3):-!,
      elmexp(IL,OL1,EXP2),
      potensexp1(OL1,OL,potens(EXP1,EXP2),EXP3).
  potensexp1(IL,IL,EXP,EXP).

  elmexp(["("|IL],OL,EXP):-
      s_exp(IL,OL1,EXP),
      front(")",OL1,OL),!.
  elmexp(["ln","("|IL],OL,ln(EXP)):-
      s_exp(IL,OL1,EXP),
      front(")",OL1,OL),!.
  elmexp(["sin","("|IL],OL,sin(EXP)):-
      s_exp(IL,OL1,EXP),
      front(")",OL1,OL),!.
  elmexp(["cos","("|IL],OL,cos(EXP)):-
      s_exp(IL,OL1,EXP),
      front(")",OL1,OL),!.
  elmexp(["tan","("|IL],OL,tan(EXP)):-
      s_exp(IL,OL1,EXP),
      front(")",OL1,OL),!.
  elmexp(["-",TALSTR|IL],IL,real(INT)):-
      str_int(TALSTR,INTp),
      INT = -INTp.
  elmexp([TALSTR|IL],IL,real(INT)):-str_real(TALSTR,INT),!.

  front(TOK,[TOK|L],L).

/*
  CLAUSES TO EDIT A STRING
*/

  editstr(InString, OutString, Xpos, Ypos, Cpos) :-
    cursor(Ypos,Xpos),
    write(InString," "),
    NXPos = Xpos+Cpos,
    cursor(Ypos,NXpos),
    readchar(Ch),
    !,
    editstr(Ch, InString, OutString, Xpos, Ypos, Cpos).

  % Return -- Accept the current string.
  editstr('\13',InString,InString,Xpos,Ypos,_) :-
    cursor(Ypos,Xpos),
    write(InString), nl.
    
  % HELP -- Display the help message
  % taken from checkhelp.
  editstr('?',InString,OutString,Xpos,Ypos,Cpos) :- 
    makewindow(4,23,7,"",10,3,14,73),
    file_str("calc.hlp",I),
    display(I),
    removewindow,
    !,
    editstr(InString,OutString,Xpos,Ypos,Cpos).
  
  % ^S -- Move Cursor left
  editstr('\19',InString,OutString,Xpos,Ypos,Cpos) :-
    Cpos > 0,
    NewCpos = Cpos - 1,
    !,
    editstr(InString,OutString,Xpos,Ypos,NewCpos).
  editstr('\19',InString,OutString,Xpos,Ypos,Cpos) :- !,
    editstr(InString,OutString,Xpos,Ypos,Cpos).
     
  % ^D -- Move Cursor left
  editstr('\4',InString,OutString,Xpos,Ypos,Cpos) :-
    str_len(InString,InStrLen),
    Cpos < InStrLen,
    NewCpos = Cpos + 1, !,
    editstr(InString,OutString,Xpos,Ypos,NewCpos).
  editstr('\4',InString,OutString,Xpos,Ypos,Cpos) :- !,
    editstr(InString,OutString,Xpos,Ypos,Cpos).
    
  % ^H -- Backspace, Delete the previous character.
  editstr('\8',InString,OutString,Xpos,Ypos,1) :-
    frontchar(InString,_,NewString),
    !,
    editstr(NewString,OutString,Xpos,Ypos,0).
  editstr('\8',InString,OutString,Xpos,Ypos,Cpos) :-
    Cpos > 1,
    NewCpos = Cpos - 1,
    !,
    editstr('\21',InString,OutString,Xpos,Ypos,NewCpos). % Delete Char.
  editstr('\8',InString,OutString,Xpos,Ypos,Cpos) :- !,
    editstr(InString,OutString,Xpos,Ypos,Cpos).
  
  % ^U -- Delete the current character.
  editstr('\21',InString,OutString,Xpos,Ypos,Cpos) :-
    frontstr(Cpos,InString,HeadString,TailStringP),
    frontchar(TailStringP,_,TailString),
    concat(HeadString,TailString,NewString),
    !,
    editstr(NewString,OutString,Xpos,Ypos,Cpos).
  editstr('\21',InString,OutString,Xpos,Ypos,Cpos) :- !,
    editstr(InString,OutString,Xpos,Ypos,Cpos).

  % Insert a Character.
  editstr(Ch,InString,OutString,Xpos,Ypos,Cpos) :-
    makewindow(_,_,_,_,_,_,_,Width),
    str_len(InString,InStrLen),
    InStrLen < Width - 3 - Xpos,
    Ch >= ' ', Ch <= '~',
    frontstr(Cpos,InString,HeadString,TailStringP),
    frontchar(TailString,Ch,TailStringP),
    concat(HeadString,TailString,NewString),
    NewCpos = Cpos + 1,
    !,
    editstr(NewString,OutString,Xpos,Ypos,NewCpos).
    
  % Extended Key Hit.
  editstr('\0',InString,OutString,Xpos,Ypos,Cpos) :-
    readchar(Key), !,
    editstr(extended,Key,InString,OutString,Xpos,Ypos,Cpos).
    
   % Ignore All other keys pressed.
  editstr(_,InString,OutString,Xpos,Ypos,Cpos) :-
    editstr(InString,OutString,Xpos,Ypos,Cpos).

  % Process extended keys.
  % Del Key, map to the ^U key.
  editstr(extended,'\83',InString,OutString,Xpos,Ypos,Cpos) :- !,
    editstr('\21',InString,OutString,Xpos,Ypos,Cpos).
  % Left Arrow, map to the ^S key.
  editstr(extended,'\75',InString,OutString,Xpos,Ypos,Cpos) :- !,
    editstr('\19',InString,OutString,Xpos,Ypos,Cpos).
  % Right Arrow, map to the ^D key.
  editstr(extended,'\77',InString,OutString,Xpos,Ypos,Cpos) :- !,
    editstr('\4',InString,OutString,Xpos,Ypos,Cpos).
  % End.
  editstr(extended,'\79',InString,OutString,Xpos,Ypos,_) :- 
    str_len(InString,InStrLen),
    !,
    editstr(InString,OutString,Xpos,Ypos,InStrLen).
  % Home.
  editstr(extended,'\71',InString,OutString,Xpos,Ypos,_) :- !,
    editstr(InString,OutString,Xpos,Ypos,0).
  % Ignore the rest.
  editstr(extended,_,InString,OutString,Xpos,Ypos,Cpos) :- !,
    editstr(InString,OutString,Xpos,Ypos,Cpos).

/* 
  UTILITY TO TRANSFORM A TOKANIZED LIST TO A LIST
*/
  lstcat([],"").
  lstcat([X|Xs],STR) :- 
    lstcat(Xs,STR1),
    concat(X,STR1,STR).
/*
  CLAUSES FOR CONVERTING AN EXPRESSION TO A STRING
*/
% Taken from the old writeexp clauses

  strexp(real(INT),INTSTR) :-
      str_int(INTSTR,INT).
  strexp(ln(EXP),STR)  :-
      strPAR(EXP,STRp),
      concat("ln",STRp,STR).
  strexp(sin(EXP),STR) :- 
      strPAR(EXP,STRp),
      concat("sin",STRp,STR).
  strexp(cos(EXP),STR) :- 
      strPAR(EXP,STRp),
      concat("cos",STRp,STR).
  strexp(tan(EXP),STR) :- 
      strPAR(EXP,STRp),
      concat("tan",STRp,STR).
  strexp(sec(EXP),STR) :- 
      strPAR(EXP,STRp),
      concat("sec",STRp,STR).
  strexp(plus(EXP1,EXP2),STR):-
      strexp(EXP1,STR1),
      concat(STR1,"+",STR3),
      strexp(EXP2,STR2),
      concat(STR3,STR2,STR).
  strexp(minus(EXP1,EXP2),STR):-
      strexp(EXP1,STR1),
      concat(STR1,"-",STR3),
      strMINUS(EXP2,STR2),
      concat(STR3,STR2,STR).
  strexp(mult(EXP1,EXP2),STR):-
      strMINUS(EXP1,STR1),
      concat(STR1,"*",STR3),
      strMULT(EXP2,STR2),
      concat(STR3,STR2,STR).
  strexp(div(EXP1,EXP2),STR):-
      strMULT(EXP1,STR1),
      concat(STR1,"/",STR3),
      strDIV(EXP2,STR2),
      concat(STR3,STR2,STR).
  strexp(potens(EXP1,EXP2),STR):-
      strDIV(EXP1,STR1), 
      concat(STR1,"^",STR3),
      strPOTENS(EXP2,STR2),
      concat(STR3,STR2,STR).

  strPOTENS(div(X,Y),STR):-!,strPAR(div(X,Y),STR).
  strPOTENS(X,STR):-strDIV(X,STR).

  strDIV(mult(X,Y),STR):-!,strPAR(mult(X,Y),STR).
  strDIV(X,STR):-strMULT(X,STR).

  strMULT(minus(X,Y),STR):- !,strPAR(minus(X,Y),STR).
  strMULT(X,STR):-strMINUS(X,STR).

  strMINUS(plus(X,Y),STR):-!,strPAR(plus(X,Y),STR).
  strMINUS(X,STR):-strexp(X,STR).

  strPAR(EXP,STR):-
      strexp(EXP,STR1),
      concat("(",STR1,STR2),
      concat(STR2,")",STR).
    