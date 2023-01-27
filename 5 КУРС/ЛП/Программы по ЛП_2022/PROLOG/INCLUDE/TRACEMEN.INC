  DOMAINS
    STRINGLIST = SYMBOL*

  PREDICATES
    tracemenu(INTEGER,STRINGLIST,BGI_ILIST)
    wordlen(INTEGER,STRINGLIST,INTEGER)
    create(INTEGER,INTEGER,STRINGLIST,BGI_ILIST)
    
  CLAUSES
    create(_,_,[],[]):-!.
    create(Delta,Cur,[H|T1],[Cur|T]):-
      str_len(H,Len),
      Cur1 = Delta + Len + Cur, 
      create(Delta,Cur1,T1,T).
  
    tracemenu(Max,List,IList):-
      wordlen(Len,List,Col),
      Delta = (Max - Len) div Col,
      Start = Delta div 2,
      create(Delta,Start,List,IList).

    wordlen(0,[],0):-!.
    wordlen(Len,[H|T],Int):-
      str_len(H,L),
      wordlen(Work,T,Time),
      Len = L + Work,
      Int = Time + 1.
    
    