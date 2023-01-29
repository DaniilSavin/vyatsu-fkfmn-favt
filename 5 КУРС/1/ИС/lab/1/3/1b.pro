domains
name, product=symbol

predicates
nondeterm lubit(name,product).
nondeterm frukti(product).
nondeterm konfeti(product).
nondeterm lub_frukti(name).

clauses
lubit(vova,banana).
lubit(sveta,banana).
lubit(sveta,chocolate).
lubit(sveta,apple).
frukti(banana).
frukti(apple).
konfeti(chocolate).
lub_frukti(X):-lubit(X,Y),frukti(Y).

goal
lubit(X,chocolate), lubit(X,apple).