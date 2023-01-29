predicates
likes(symbol,symbol)
color(symbol,symbol)
fruit(symbol)


/* goal
likes(beth,X),write(X).*/
clauses

likes(mary,pears).
likes(mary,popcorn).
likes(mary,apples).
 likes(beth,X):-
                   likes(mary,X),
                   fruit(X),
                   Color(X,red).
  
 likes(beth,X):-
                   likes(mary,X),
                   X=popcorn.
fruit(pears).
fruit(apples).
color(peras,yellow).
color(oranges,orange).
color(apples,yellow).
color(peras,yellow).
color(apples,red).
