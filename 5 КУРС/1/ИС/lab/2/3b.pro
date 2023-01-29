DOMAINS
vid_tovara, name, strana=string
price,count=integer


PREDICATES
nondeterm tovar(vid_tovara, name, price, count, strana)

CLAUSES
tovar(promishlenniy, name1, 300, 20, russia).
tovar(productoviy, name2, 150, 30, usa).
tovar(promishlenniy, name3, 200, 40, russia).
tovar(productoviy, name4, 350, 20, usa).
tovar(promishlenniy, name5, 500, 60, russia).
tovar(productoviy, name6, 550, 60, usa).

GOAL
write(" ALL"), nl,
write("VID | NAME | PRICE | COUNT | STRANA"),
nl, tovar(V,N,P,C,S), C<21,write(V," | ",N," | ",P, " | ",C," | ",S),nl,fail.