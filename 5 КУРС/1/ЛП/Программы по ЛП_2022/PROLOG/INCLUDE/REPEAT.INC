  PREDICATES
    nondeterm for(integer,integer,integer)
    nondeterm for_step(real,real,real,real)
    nondeterm repeat

  CLAUSES
    for_step(X,X,_,_).
    for_step(I,A,B,S):-
      B > A,
      A1 = A + S,
      for_step(I,A1,B,S).
 

    repeat.
    repeat:-
      repeat.

    for(X,X,_).
    for(I,A,B):-
      B > A,
      A1 = A + 1,
      for(I,A1,B).
