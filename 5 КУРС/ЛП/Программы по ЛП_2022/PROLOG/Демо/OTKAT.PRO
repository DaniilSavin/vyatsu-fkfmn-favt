predicates
 likes(symbol,symbol)
 fruit(symbol)
 color(symbol,symbol)

goal
 likes(beth,X), write(X),nl,fail.
 /* если введен предикат fail, то пролог находит оба решения
 apples , popcorn. Если нет этого предиката, то выводится только
 apples. Но если бы первое правило оказалось неуспешным, то пролог выводит popcorn.
 */
clauses
likes(mary,pears).
likes(mary,popcorn).
likes(mary,apples).
likes(mary,orange).

 likes(beth,X):-
 likes(mary,X),
 fruit(X),
 color(X,red).
 
 likes(beth,X):-
 likes(mary,X),
 X=popcorn.
 
 fruit(pears).
 fruit(apples).
 color(pears, yellow).
 color(orange,oranges).
 color(apples, yellow).
 color(apples, red).
 