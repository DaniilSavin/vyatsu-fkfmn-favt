database
    pet(string)
clauses
    pet("dog").
    pet("cat").
    pet("hamster").

predicates
    nondeterm solve(string,string,string)
    nondeterm cond(string,string)
clauses
    cond("Peter",Pet):-
        Pet<>"hamster",
        Pet<>"cat".
    cond("Lena",Pet):-
        Pet<>"cat".
    cond("Tania",Pet):-
        Pet="cat".
    
    solve(Pet1,Pet2,Pet3):-
        pet(Pet1),
        cond("Peter",Pet1),
        pet(Pet2),Pet2<>Pet1,
        cond("Lena",Pet2),
        pet(Pet3),Pet3<>Pet1,Pet3<>Pet2,
        cond("Tania",Pet3).

goal
solve(Pet1,Pet2,Pet3),
writef("Peter - %, Lena - %, Tania - %\n",
    Pet1,Pet2,Pet3),
fail;
true.