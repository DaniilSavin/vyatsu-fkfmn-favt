domains
name=symbol

predicates
nondeterm dlinnee(name,name).
nondeterm koroche(name,name).

clauses
dlinnee(volga, amudarya).
dlinnee(lena,volga).
dlinnee(X,Y):-koroche(Y,X).
koroche(dnepr, amudarya).
/*koroche(X,Y):-dlinnee(Y,X).*/

goal
write("reka "),dlinnee(amudarya, X) , write(" dlinnee amud: "), nl. 

