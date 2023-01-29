PREDICATES
nondeterm sprava(string, string).
nondeterm ryad(string, string, string, string).

CLAUSES
sprava("Yura", "Dima").
sprava("Misha", "Vitya").
sprava("Vitya", "Yura").
ryad(X, Y, Z, G):-sprava(X,Y), sprava(Y,Z), sprava(Z,G).

GOAL
ryad(X, Y, Z, G), write (X, "-",Y, "-",Z, "-",G),nl.