/***************************************************************
     Turbo Prolog Toolbox
     (C) Copyright 1987 Borland International.
***************************************************************/

predicates
  setEGApalette(integerlist)
  putinlist(integerlist,integer,integer)
  setEGAregister(integer,integer)
clauses
  setEGApalette(L):-
  	X="012345678901234567",
  	ptr_dword(X,Segment,Offset),
  	putinlist(L,Segment,Offset),
	bios($10,reg($1002,0,0,Offset,0,0,0,Segment),_).

  putinlist([],_,_):-!.
  putinlist([Byte|T],Segment,Offset):-
  	membyte(Segment,Offset,Byte),
  	Offset2=Offset+1,
	putinlist(T,Segment,Offset2).

  setEGAregister(16,Color):-!,/* EGA Reg16 defines border color*/
	BX=Color*256,
  	bios($10,reg($1001,BX,0,0,0,0,0,0),_).

  setEGAregister(RegNo,Color):-
	BX=Color*256+Regno,
  	bios($10,reg($1000,BX,0,0,0,0,0,0),_).
