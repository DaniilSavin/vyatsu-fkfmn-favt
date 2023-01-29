domains
name, vid_sport, instrument=symbol

predicates
nondeterm uvlekaetsya(name,vid_sport).
nondeterm uvlekaetsya(name,instrument).
nondeterm sport(vid_sport).
nondeterm mus_instr(instrument).
nondeterm musicman(name).

clauses
uvlekaetsya(kolya,guitar).
uvlekaetsya(olya,scripka).
uvlekaetsya(dima,plavanie).
uvlekaetsya(tanya,tennis).
sport(plavanie).
sport(tennis).
mus_instr(scripka).
mus_instr(guitar).
musicman(X):-uvlekaetsya(X,Y),mus_instr(Y).

goal
musicman(X).