/************************************************************************
 								 	

     Turbo Prolog Toolbox
     (C) Copyright 1987 Borland International.

 			GGRAPH.PRO				 	
 								 	
 These graphics tools supplied in this file cover	 		
	1) the alternative coordinates (SCALES)				
	2) drawing axis (rulers)					
	3) drawing curves and point-graphs				
									
 These facilities rely on two database predicates, which have to	
 be declared (in the database section of your program) as: 		
 	database							
	   Scale(scaleno,x,x,y,y)					
	   ActiveScale(scaleNo)						
	   axes(integer,integer,integer,xmarker,ymarker,col,row,col,row)
									
 This file requires that the files GDOMS.PRO and GPREDS.PRO are 	
 included.								
************************************************************************/ 

predicates
  definescale(ScaleNo,x,x,y,y)
  shiftscale(ScaleNo)
  scale_virtual(x,y,vrow,vcol)
  scale_text(x,y,row,col)

  ScalePlot(x,y,color)
  ScaleLine(x,y,x,y,color)
  ScaleCursor(x,y)
  ScalePolygon(color,drawing)
  draw(drawings)

  findScale(ScaleNo,drawing,factor,factor)
  FindExtremes(drawing,x,x,y,y)
  extremes(drawing,x,x,y,y, x,x,y,y)
  nondeterm anumber(ScaleNo)

clauses
  scale_virtual(X,Y,VRow,VCol):-
	bound(X),bound(Y),
	ActiveScale(N),!,
  	scale(N,Xmin,Xmax,Ymin,Ymax),!,
	windowarea(Rows,Cols),
	getcols(TotalCols),
	/*Xcoordinate*/
	Vcol=((Cols-1)/(TotalCols))*31999*(X-Xmin)/(Xmax-Xmin),
	Vrow= (Rows-1)/25*31999*(1-(Y-Ymin)/(Ymax-Ymin))+1279.

  
  scale_text(X,Y,Row,Col):-
	scale_virtual(X,Y,X1,Y1),
	virtual_text(X1,Y1,Row,Col).

  definescale(N,Xmin,Xmax,Ymin,Ymax):-
	free(N),
	anumber(N),
	not(scale(N,_,_,_,_)),
	shiftscale(N),!,
	asserta(scale(N,Xmin,Xmax,Ymin,Ymax)).

  definescale(N,_,_,_,_):-
	bound(N),
	retract(scale(N,_,_,_,_)),fail.
  definescale(N,Xmin,Xmax,Ymin,Ymax):-
	bound(N),
	shiftscale(N),!,
	asserta(scale(N,Xmin,Xmax,Ymin,Ymax)).

  shiftscale(_):-
  	retract(activeScale(_)),fail.
  shiftscale(N):-
  	assertz(activeScale(N)).
	
  ScaleCursor(X,Y):-
	scale_text(X,Y,Row,Col),
	cursor(Row,Col).

  ScalePlot(X,Y,Color):-
	scale_virtual(X,Y,VRow,VCol),
	dot(Vrow,VCol,Color).
  
  ScaleLine(Xa,Ya,Xb,Yb,Color):-
	scale_virtual(Xa,Ya,Row_a,Col_a),
	scale_virtual(Xb,Yb,Row_b,Col_b),
  	line(Row_a,Col_a,Row_b,Col_b,Color).

  ScalePolygon(Color,[p(Xa,Ya),p(Xb,Yb)|Rest]):-!,
	ScaleLine(Xa,Ya,Xb,Yb,Color),
  	ScalePolygon(Color,[p(Xb,Yb)|Rest]).
  ScalePolygon(_,_).

  draw([]):-!.
  draw([d(Color,Drawing)|Tail]):-
   	ScalePolygon(Color,Drawing),draw(Tail).

  findscale(N,Drawing,Xfactor,Yfactor):-
	FindExtremes(Drawing,Xlow,Xhigh,Ylow,Yhigh),
	Xh=Xfactor*(Xhigh-Xlow)+Xlow,
	Yh=Yfactor*(Yhigh-Ylow)+Ylow,
	definescale(N,Xlow,Xh,Ylow,Yh).

  FindExtremes([p(X,Y)|Rest],Xlow,Xhigh,Ylow,Yhigh):-
  	extremes([p(X,Y)|Rest],X,X,Y,Y,Xlow,Xhigh,Ylow,Yhigh).

  extremes([],Xl,Xh,Yl,Yh,Xl,Xh,Yl,Yh):-!.
  extremes([p(X,Y)|Rest],Xl,Xh,Yl,Yh, Xlow,Xhigh,Ylow,Yhigh):-
  	X=X_,Xl=Xl_,Y=Y_,Yl=Yl_,
  	min(X_,Xl_,TempXlow_),min(Y_,Yl_,TempYlow_),
	Xh=Xh_,Yh=Yh_,
	max(X_,Xh_,TempXhigh_),max(Y_,Yh_,TempYhigh_),
	TempXlow=TempXlow_,
	TempXhigh=TempXhigh_,
	TempYlow=TempYlow_,
	TempYhigh=TempYhigh_,
	extremes(Rest,TempXlow,TempXhigh,TempYlow,TempYhigh,Xlow,Xhigh,Ylow,Yhigh).

  
  aNumber(0).
  aNumber(X):-anumber(BeforeX),X=BeforeX+1.


/****************************************************************
			AXES
****************************************************************/

predicates
  /*AxisNo,AxisWindow,GraphWindow,marker(Xunit,Form,Width),
  				  marker(Yunit,Form,Width),
  				  Yunit,Left,Bottom,Right,Top*/
  makeAxes(integer,integer,integer,xmarker,ymarker,col,row,col,row)
  /*AxisNo*/
  refreshAxes(integer)
  modifyAxes(integer,xmarker,ymarker)
  axisLabels(integer,string,string)


/**************************************************************
	Miscellaneous helping predicates
**************************************************************/

  DrawAxes(integer)	/* (axisno) */
  x_ruler(vcol,vrow,x,vcol,x,x,col,symbol,integer)
  y_ruler(vcol,vrow,y,vrow,y,y,symbol,integer)
  wr_if_sp(row,col,col,col,integer,string)
  removeaxesdef(integer)

clauses
  removeaxesdef(Ref):- retract(axes(Ref,_,_,_,_,_,_,_,_)),!.
  removeaxesdef(_).

  modifyAxes(Ref,Xmarker,Ymarker):-
  	retract(axes(Ref,Aw,Gw,_,_,L,B,R,T)),!,
  	asserta(axes(Ref,Aw,Gw,Xmarker,Ymarker,L,B,R,T)).

  makeAxes(Ref,AxesWindow,GraphWindow,
  	   marker(Xunit,Xformat,Xwidth),
  	   marker(Yunit,Yformat,YWidth),Left,Bottom,Right,Top):-

	removeaxesdef(Ref),
  	shiftwindow(AxesWindow),!,/*axes is drawn in the actual window*/
	GraphWindow=AxesWindow+10,
	assertz(axes(Ref,AxesWindow,GraphWindow,
		     marker(Xunit,Xformat,Xwidth),
		     marker(Yunit,Yformat,YWidth),
		     Left,Bottom,Right,Top)),
  	drawAxes(Ref),
	_Left=Left+YWidth+1,/*Space for Y-axes label and numbers*/
	max(2,Bottom,_Bottom), /*Minimum space for X-axes label and numbers*/
	makewindow(_,ScrAtt,Frame,Text,Row0,Col0,Hight,Width),/*Size of AxesWindow*/
	sign(Frame,S),
	Row1=Row0+Top+S,
	Col1=Col0+_Left+S,
	Hight1=Hight-Top-_Bottom-S-S,
	Width1=Width-_Left-Right-S-S,
	makewindow(GraphWindow,ScrAtt,0,Text,Row1,Col1,Hight1,Width1).

  refreshAxes(Ref):-
	axes(Ref,AxesWindow,_,_,_,_,_,_,_),!,
  	shiftwindow(Old),
  	shiftwindow(AxesWindow),
  	drawAxes(Ref),
  	shiftwindow(Old).

/****************************************************************
			drawaxes
****************************************************************/

  DrawAxes(Ref):-
	axes(Ref,AxesWindow,_,
	     marker(Xunit,Xform,Xw),marker(Yunit,Yform,Yw),
	     Left,Bottom,Right,Top),!,
	shiftwindow(AxesWindow),
	clearwindow,		/*clear area for axes and numbers*/
	GraphLeftEdge=Left+Yw+1,	/*Space for Y-axes label and numbers*/
	max(2,Bottom,_Bottom),	/*Space for  X-axes label and numbers*/
	windowarea(Rows,Cols),	/*the drawing size of current window*/
	GraphLowerEdge = Rows-_Bottom,

	/*virtual coordinates for lines defining left and bottom 
	border of the drawing area:*/
	virtual_text(Y0,X0,GraphLowerEdge,GraphLeftEdge),

	GraphRightEdge = Cols-Right+1,
	virtual_text(Ytop,X1,Top,GraphRightEdge),
	Y1=Ytop-100,
	virtual_text(_,CharWidth,0,1), 
	Y_l=Y0+640,X_l=X0-Charwidth/2,

	/* Draw the axes just outside the graph area */
	line(Y_l,X_l,Y_l,X1,1),		/* X-axes */ 
	line(Y_l,X_l,Y1,X_l,1),		/* Y-axes */

	/* Draw lines above and to the right */
	line(Y1,X_l,Y1,X1,1),		/* X-axes */ 
	line(Y_l,X1,Y1,X1,1),		/* Y-axes */

	/*Calculate intervals on axes*/
	DrawingWidth=Cols-GraphLeftEdge-Right-2,
	DrawingHight=GraphLowerEdge-Top-1,
	virtual_text(VirHight,VirWidth,DrawingHight,DrawingWidth),

	activeScale(N),
	scale(N,Xmin,Xmax,Ymin,Ymax),!,

	Add_to_vir_X=Xunit/(Xmax-Xmin)*VirWidth,
	Add_to_vir_Y=Yunit/(Ymax-Ymin)*VirHight,

	/*Write rulers*/
	x_ruler(X0,Y_l,Xmin,Add_to_vir_X,Xunit,Xmax,0,Xform,Xw),
	y_ruler(X_l,Y0,Ymin,Add_to_vir_Y,Yunit,Ymax,Yform,Yw).

  AxisLabels(AxesNo,Xlabel,YLabel):-
	axes(AxesNo,AxesWindow,_,_,marker(_,_,Yw),Left,Bottom,Right,Top),!,
	shiftwindow(Old),
	shiftwindow(AxesWindow),
	GraphLeftEdge=Left+Yw+1,/*Space for Y-axes label and numbers*/
	max(2,Bottom,_Bottom),	/*Space for  X-axes label and numbers*/
	windowarea(Rows,Cols),	/*the drawing size of current window*/

	/*Label the X-axes:*/ 
	XlabelLine = Rows-_Bottom+2,
	Xlength=Cols-Left-Right-6,
	field_str(XLabelLine,GraphLeftEdge,XLength,Xlabel),

	/*Label the Y-axes*/
	Left1=Left-2,
	max(Left1,0,_Left),
	YHight=XlabelLine-Top,
	concat(Ylabel,"                         ",Ylbl),
	frontstr(YHight,Ylbl,YL,_),
	attribute(A),
	gwrite(Top,_Left,YL,A,1), /*horizontal*/
	shiftwindow(Old).


  x_ruler(X,Y0,Value,DeltaX,Xunit,Max,ColLastTime,Xformat,Width):-
  	Value <= Max,!,
  	Y00=Y0+1280,line(Y0,X,Y00,X,1),
	virtual_text(Y0,X,Row,Col),R=Row+1,C=Col-1,
	V=Value,format_string(V,Xformat,Width,String),
	wr_if_sp(R,C,ColLastTime,ColThisTime,Width,String),
	NextValue=Value+Xunit,
	NextX=X+DeltaX,
	x_ruler(NextX,Y0,NextValue,DeltaX,Xunit,Max,ColThisTime,Xformat,Width).
  x_ruler(_,_,_,_,_,_,_,_,_).

  y_ruler(X0,Y,Value,DeltaY,Yunit,Max,Yformat,Width):-
  	Value <= Max,!,
	virtual_text(_,Delta,0,1),
  	X00=X0-Delta,
  	line(Y,X00,Y,X0,1),
	virtual_text(Y,X0,Row,Col),
	C=Col-Width, max(0,C,CC), cursor(Row,CC),

	V=Value,format_string(V,Yformat,Width,String),
	write(String),
	NextValue=Value+Yunit,
	NextY=Y-DeltaY,
	y_ruler(X0,NextY,NextValue,DeltaY,Yunit,Max,Yformat,Width).
  y_ruler(_,_,_,_,_,_,_,_).


  wr_if_sp(Row,Col,PreviousCol,UpdatedCol,Width,String):-
  	Col>PreviousCol+Width,!,
	field_str(Row,Col,Width,String),
	UpdatedCol=Col.
  wr_if_sp(_,_,PreviousCol,PreviousCol,_,_).
