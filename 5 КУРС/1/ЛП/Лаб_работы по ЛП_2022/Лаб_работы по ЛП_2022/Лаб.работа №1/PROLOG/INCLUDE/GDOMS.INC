/***************************************************************
     Turbo Prolog Toolbox
     (C) Copyright 1987 Borland International.
***************************************************************/

domains

  vrow,vcol,vradius,vwidth,vheigth,size= integer  /*VIRTUAL COORDINATES*/
  width,height	= integer  /* TEXT COORDINATES:  ROW, COL*/
  increment,	/*Used in arc-predicate*/
  color,	/*Any foreground or background color*/
  kind,		/*Select function. Value range 0 and upwards*/
  mode,		/*Graphics mode. 1,2,3,4 or 5*/
  fill,		/*Fill or no fill*/
  degrees,	/*Angle in degrees 0 - 359*/
  palette	= integer /*Palette number*/
  filename	= string
  bar = bar(vheigth,string,color,color)  /*value,label,Framecolor,FillColor*/
  	; space	
  barlist=bar*
  barratio,theta,factor = real /*All used in BarChart*/

  x,y=real /* SUBSTITUTE TO INTEGER TO OPTIMIZE SPEED*/
  point=p(x,y)
  drawing=point*
  d=d(color,drawing)
  drawings=d*
  ScaleNo=integer
  xmarker = marker(x,symbol,integer)
  ymarker = marker(y,symbol,integer)
