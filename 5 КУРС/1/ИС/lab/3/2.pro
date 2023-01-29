database
    color(string)
clauses
    color("brunet").
    color("rijiy").
    color("blondin").

predicates
    nondeterm solve(string,string,string)
    nondeterm cond(string,string)
clauses
    cond("Belokurov",Color):-
        Color<>"brunet",
        Color<>"blondin".
    cond("Rijov",Color):-
        Color<>"rijiy".
    cond("Chernov",Color):-
        Color<>"brunet".
    
    solve(Color1,Color2,Color3):-
        color(Color1),
        cond("Belokurov",Color1),
        color(Color2),Color2<>Color1,
        cond("Rijov",Color2),
        color(Color3),Color3<>Color1,Color3<>Color2,
        cond("Chernov",Color3).

goal
solve(Color1,Color2,Color3),
writef("Belokurov - %, Rijov - %, Chernov - %\n",
    Color1,Color2,Color3),
fail;
true.