/***************************************************************
     Turbo Prolog Toolbox
     (C) Copyright 1987 Borland International.
***************************************************************/

global Predicates

  determ loadPic(fileName,integer,integer,integer,integer,integer,integer) 
	- (i,i,i,i,i,i,i) language c
   /* load_pic(FileName,StartRowPicFile,StartColPicFile,
		StartRowScreen,StartColScreen,NoofRows,NoofCols)
   Range for Rows	: 0-199
   Range for Coloumns	: 0-319  */

 determ SavePic(filename) - (i) language c

 determ plot(vrow,vcol,color,size,kind) - (i,i,i,i,i) language c
 /*	Range for Row	: 0-31999
	Range for Col	: 0-31999
	Range for Size  : 0-31999
	Kind		= 0 -> One pixel
	 		= 1 -> A dot will be drawn inside a box
  			= 2 -> A box will be drawn and filled
	 		= 3 -> An X will be drawn		*/

  determ box(vrow,vcol,vrow,vcol,color,color,fill) - (i,i,i,i,i,i,i) language c
  /* (Row1,Col1,Row2,Col2,LineColor,FillColor,Fill)
  Range for Rows	: 0-31999
  Range for Columns	: 0-31999
  Fill			= 0  A box will be drawn with color LineColor
  			     but not filled
  			= 1  A box will be drawn with color LineColor
  			     and filled with color LineColor	*/

  determ ellipse_1(vrow,vcol,vradius,real,color,color,fill) - (i,i,i,i,i,i,i) language c
  /*  (Row, Coloumn, Radius1, Ratio, FrameColor, Color, Fill )
  Range for Rows	: 0-31999
  Range for Columns	: 0-31999
  Range for Radius  	: 0-31999
  Range for Ratio  	: 0-1
  kind			= 0  An ellipse will be drawn
  			= 1  An ellipse will be drawn and filled  */

  determ sector(vrow,vcol,vradius,increment,degrees,degrees,color,color,fill) 
  	- (i,i,i,i,i,i,i,i,i) language c
  /* (Row,Col,Radius,Increment,StartAng,EndAng,FrameColor,FillColor,Fill)
  Range for Rows	: 0-31999
  Range for Coloumns	: 0-31999
  Range for Increment  	: 1-360
  Range for Angles 	: 0-360
  Fill			= 0  No fill
  			= 1  Fill
  */

  determ LineShade(vrow,vcol,vrow,vcol,vcol,color,kind) - (i,i,i,i,i,i,i) language c
  /* (Row1,Col1,Row2,Col2,EndLine,FillColor,Kind)
			(Endline: SEE NOTE BELOW)
  Notice, when Endline is represented by a ROW (when shading up or down),
  coercing between the domains VROW and VCOL is needed; this is done by:
	  ...CoerceVariable=Vrow, lineshade(........,CoerceVariable,..),
  Range for Rows	: 0-31999
  Range for Coloumns	: 0-31999
  Range for EndLineCol	: 0-31999
  Kind			= 0  Shade up to EndLine(Col)	/*Coerce to vcol*/
  			= 1  Shade down to EndLine(Col)	/*Coerce to vcol*/
  			= 2  Shade left to End(Line)Col
  			= 3  Shade right to End(Line)Col */
