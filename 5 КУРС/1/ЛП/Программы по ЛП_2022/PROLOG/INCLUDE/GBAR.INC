
	/************************************************

         Turbo Prolog Toolbox
         (C) Copyright 1987 Borland International.

			GRAPHBAR.PRO			
	 Graphbar contains predicates and clauses for
	 the BARGRAPH predicate.			
	************************************************/
	
predicates
  BarGraph3d(col,row,col,row,barratio,theta,barlist,factor)
  BarGraph(col,row,col,row,barratio,barlist,factor)
  countBars(barlist,vheigth,integer,vheigth)
  drawBarl(Vrow,Vcol,Vwidth,BarRatio,theta,factor,barlist)
  drawBar(Vrow,Vcol,Vwidth,theta,factor,bar)
  threeD_box(Vrow,Vcol,Vrow,Vcol,Vwidth,theta,color,color)
  determ_fill(Color,Fill)
  place_label(Vrow,Vrow,Vcol,Vwidth,VHeigth,string,color,kind)
  to_range(integer,integer,integer,integer)

Clauses
  to_range(X,MIN,_,MIN):- X<=MIN,!.
  to_range(X,_,MAX,MAX):- X>MAX,!.
  to_range(X,_,_,X).
 	

 BarGraph3D(Left,Bottom,Right,Top,BarWidthRatio,Theta,BarList,Factor):-
	countBars(BarList,0,Number,MaxBarHigth),
	windowarea(Rows,Cols),/*The size of the current window*/
	
	/*virtual coordinates for the lower border*/
	Rl=Rows-Bottom,
	virtual_text(Rlow,Clow,Rl,Left),
	
	/*Virtual coordinates for the height and width of the graph*/
	H=Rows-Bottom-Top,
	W=Cols-Left-Right,
	virtual_text(VirHigth,VirWidth,H,W),
	
  	BarWidth=BarWidthRatio*VirWidth/(Number+2),
	Factor=VirHigth/MaxBarHigth*0.9,
  	drawBarl(Rlow,Clow,BarWidth,BarWidthRatio,Theta,Factor,BarList).

  BarGraph(Left,Bottom,Right,Top,BarWidthRatio,BarList,Factor):-
	BarGraph3D(Left,Bottom,Right,Top,BarWidthRatio,0,BarList,Factor).

  countBars([bar(H,_,_,_)|T],High,Count,Highest):-
  	H>High,!,
	countBars(T,H,N1,Highest),Count=N1+1.
  countBars([_|T],High,Count,Highest):-
	countBars(T,High,N1,Highest),Count=N1+1.
  countBars([],H,0,H).


  drawBarl(BottomRow,AtCol,BarWidth,BarRatio,Theta,Factor,[Bar|Rest]):-!,
	drawBar(BottomRow,AtCol,BarWidth,Theta,Factor,Bar),
	NextCol=AtCol+BarWidth/BarRatio,
	drawBarl(BottomRow,NextCol,BarWidth,BarRatio,Theta,Factor,Rest).
  drawBarl(_,_,_,_,_,_,[]).


  drawBar(Row1,Col1,Width,0,Factor,bar(Higth,Label,BoxColor,FillColor)):-!,
	Row2=Row1-Higth*Factor,
	Col2=Col1+Width,
	F=FillColor,sign(F,F2),Fill=F2,
	box(Row1,Col1,Row2,Col2,BoxColor,FillColor,Fill),
	LabelKind=2,
	place_label(Row1,Row2,Col1,Width,Higth,Label,BoxColor,LabelKind).
  drawBar(Row1,Col1,Width,Theta,Factor,bar(Higth,Label,BoxColor,FillColor)):-
	Row2=Row1-Higth*Factor,
	Col2=Col1+Width,
	threeD_box(Row1,Col1,Row2,Col2,Width,Theta,BoxColor,FillColor),
	LabelKind=2,
	place_label(Row1,Row2,Col1,Width,Higth,Label,BoxColor,LabelKind).
  drawBar(_,_,_,_,_,space).


  place_label(Row1,Row2,Col1,Width,Value,Label,BoxColor,LabelKind):-
	/*  (Row2,Col1)
		+-------------+   		   Labelkind:
		| <--Width--> |  Print Label only: 	0
		|             |  Label and value:	1
		+-------------+
	     (Row1,Col1) */

	str_len(Label,LblLen),
	Center=Col1+(Width+1) div 2,
	virtual_text(Row1,Center,R1,C1),
	R2=R1+1,
	C2=C1-LblLen div 2+1,
	windowarea(Rows,Cols),MaxRow=Rows-1,MaxCol=Cols-1,
	to_range(R2,0,MaxRow,Rlbl),
	to_range(C2,0,MaxCol,Clbl),
	cursor(Rlbl,Clbl),attribute(BoxColor),write(Label),
	LabelKind>0,!,
	virtual_text(Row2,Col1,R3,_),
	str_int(ValStr,Value),str_len(ValStr,ValueLen),
	C4=C1+1-round(ValueLen/2),
	R4=R3-2,
	to_range(R4,0,MaxRow,Rv),Rv1=Rv,
	to_range(C4,0,MaxCol,Cv),Cv1=Cv,
	str_real(String,Value),
	gwrite(Rv1,Cv1,String,BoxColor,0).
  place_label(_,_,_,_,_,_,_,_).

  threeD_box(Row1,Col1,Row2,Col2,Width,Theta,BoxColor,FillColor):-
	Dx=cos(Theta)*Width,Dy=sin(Theta)*Width,
	Row1Dy=Row1-Dy,Row2Dy=Row2-Dy,Col1Dx=Col1+Dx,Col2Dx=Col2+Dx,
	determ_fill(Fillcolor,Fill),
	box(Row1,Col1,Row2,Col2,BoxColor,FillColor,Fill),
	LineShade(Row2,Col1,Row2dy,Col1Dx,Col2,BoxColor,3),
	LineShade(Row2,Col2,Row2dy,Col2Dx,Col2,BoxColor,2),
	LineShade(Row1,Col2,Row1dy,Col2Dx,Row1dy,BoxColor,0),
	LineShade(Row2,Col2,Row2dy,Col2Dx,Row1dy,BoxColor,1).

  /* Fillcolor 0 gives no fill */
  determ_fill(0,0):-!.
  determ_fill(_,1).
