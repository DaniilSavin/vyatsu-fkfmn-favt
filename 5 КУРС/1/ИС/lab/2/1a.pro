domains
name, vid_sport, instrument=symbol

predicates
nondeterm uvlekaetsya(name,vid_sport).
nondeterm uvlekaetsya(name,instrument).
nondeterm sport(vid_sport).
nondeterm mus_instr(instrument).
nondeterm sportsman(name).

clauses
uvlekaetsya(kolya,guitar).
uvlekaetsya(olya,scripka).
uvlekaetsya(dima,plavanie).
uvlekaetsya(tanya,tennis).
sport(plavanie).
sport(tennis).
mus_instr(scripka).
mus_instr(guitar).
sportsman(X):-uvlekaetsya(X,Y),sport(Y).

goal
sportsman(X).