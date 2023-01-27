predicates
repeat
typewriter

goal
typewriter,nl.
clauses
repeat. % точка отката 1
repeat:-repeat.

typewriter:-
repeat, % этот предикат нужен только для установки точки отката
readchar(C), 
write(C),
C='\r',!.

