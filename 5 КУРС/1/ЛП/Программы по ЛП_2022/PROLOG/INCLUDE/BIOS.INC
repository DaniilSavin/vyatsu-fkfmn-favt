/************************************************************************

     Turbo Prolog Toolbox
     (C) Copyright 1987 Borland International.

			SMALL BIOS CALLS

************************************************************************/


/************************************************************************
	Dosver returns the actual dos version number in a real.
***********************************************************************/

PREDICATES
  dosver(REAL)

CLAUSES
  dosver(VERSION):-
	AX=48*256,bios($21,reg(AX,0,0,0,0,0,0,0),reg(VV,_,_,_,_,_,_,_)),
	L=VV div 256, H=VV-256*L, VERSION=H+L/100.0.


/************************************************************************

 Diskspace returns the total number of bytes and the number of free
 bytes for a given disk.

   DISK=0: Current Actual disk
   DISK=1: A
   DISK=2: B
   DISK=3: C
   DISK= ....

************************************************************************/

PREDICATES
  diskspace(INTEGER,REAL,REAL)

CLAUSES
  diskspace(DISK,TOTALBYTES,FREEBYTES):-
		AAX=54*256,
		bios($21,reg(AAX,0,0,DISK,0,0,0,0),reg(AX,BX,CX,DX,_,_,_,_)),
		FREEBYTES=1.0*BX*CX*AX,
		TOTALBYTES=1.0*DX*CX*AX.


/************************************************************************

 GetVerify returns the state of the verify switch
 SetVerify sets the state of verify switch

   Ex. GetVerify(Switch)
	Switch	=	0	Verify is off
		=	1	Verify is on

 If verify is on, every write operation will be followed by
 a read operation to ensure data is stored correctly.

************************************************************************/

Predicates
  GetVerify(Integer)
  SetVerify(Integer)

Clauses
  GetVerify(Switch) :-
  	AX=$5400, bios($21,reg(AX,0,0,0,0,0,0,0),reg(Sw1,_,_,_,_,_,_,_)),
  	bitand(Sw1,255,Switch).
  
  SetVerify(Switch) :-
  	AX=$2E00+Switch, bios($21,reg(AX,0,0,0,0,0,0,0),_).


/************************************************************************
 Creation and deletion of a subdirectory.

 Eg: mkdir("subdir") Will create a subdirectory with the name
 "subdir"
************************************************************************/

PREDICATES
  mkdir(STRING)
  rmdir(STRING)

CLAUSES
  mkdir(NAME):-
		ptr_dword(NAME,DS,DX),
		AX=256*57,
		bios($21,reg(AX,0,0,DX,0,0,DS,0),_).

  rmdir(NAME):-
  		ptr_dword(NAME,DS,DX),
		AX=256*58,
		bios($21,reg(AX,0,0,DX,0,0,DS,0),_).


/************************************************************************

	Changing the color of the border
	Works only in 80*25 Alphanumeric modes
	Eg: border(15)
************************************************************************/

Predicates
  Border(Integer)

Clauses
  Border(Color) :- bios($10, reg($0B00,Color,0,0,0,0,0,0),_).


/************************************************************************

 Returning all matching files to a file specified by backtracking.

 Ex: FindMatch("c:\\prolog\\*.PRO",SearchAttribute,MatchFileName,
		FilesAttribute,Hour,Min,Year,Month,Day, FilesSize)


  Ex: FindMatch("c:\\*.*",63,MatchFileName,FilesAttribute,Hour,Min,
					      Year,Month,Day, FilesSize)

 Range for attributes remembering it is a bitmask
 Attributes	=	0	Search for ordinary files
		=	1	File is read only
		=	2	Hidden file
		=	4	System file
		=	8	Volume label
		=	16	Subdirectory
		=	32	Archive file (used by backup & restore)

 Hour		=	0-23	Hour of day when the file was created
 Min		=	0-59	Minutes
 Year		=	1980-2099
 Month		=	1-12
 Day		=	1-31
 FilesSize	=	0-30MB	Size of file

************************************************************************/

PREDICATES
  nondeterm FindMatch(String,Integer, String,Integer,Integer,Integer,Real,Integer,Integer,Integer)
  nondeterm findfiles(STRING,INTEGER)
  nondeterm findnext
  convert_Match(String,String,Integer,Integer,Integer,Real,Integer,Integer,Integer)

  DTA_word(String,Integer,Integer)
  FrontChar2(String,Char,String)
  isolate_bits(Integer,Integer,Integer,Integer)

CLAUSES
  FindMatch(FileSpec,Attribute, FileName,FilesAttr,Hour,Min,Year,Month,Day,FilesSize) :-
	/* Allocate Default Disk buffer area */
	str_len(DTA,128),
	ptr_dword(DTA,DTA_SEG,DTA_OFF),
	AX = $1A00, DS=DTA_SEG, DX=DTA_OFF,
	bios($21, reg(AX,0,0,DX,0,0,DS,0),_),
	findfiles(FileSpec,Attribute),
	convert_Match(DTA,FileName,FilesAttr,Hour,Min,Year,Month,Day,FilesSize).

  findfiles(FileSpec,Attribute):-
	ptr_dword(FileSpec,FSPEC_SEG,FSPEC_OFF),
	bios($21, reg($4E00,0,Attribute,FSPEC_OFF,0,0,FSPEC_SEG,0),_),
	findnext.

  findnext.
  findnext:-
	bios($21, reg($4F00,0,0,0,0,0,0,0),reg(AX,_,_,_,_,_,_,_)),
	AX=0,
	findnext.

  convert_Match(DTA,FileName,FilesAttr,Hour,Min,Year,Month,Day,FilesSize) :-
	DTA_word(DTA,21,FAttr), bitand(Fattr,255,FilesAttr),
	DTA_word(DTA,22,FilesTime), bitand(FilesTime,63,Min),
	isolate_bits(FilesTime,6,31, Hour),
	DTA_word(DTA,24,FilesDate), bitand(FilesDate,31,Day),
	isolate_bits(FilesDate,5,15,Month),
	isolate_bits(FilesDate,9,127,Year1),Year=Year1+1980,
	DTA_word(DTA,26,LowSize),
	DTA_word(DTA,28,HighSize), FilesSize=LowSize+1024.0*64*HighSize,
	ptr_dword(DTA,DTA_SEG,DTA_OFF),
	NEW_OFF = DTA_OFF+30,
	ptr_dword(FileName1,DTA_SEG,NEW_OFF),
	concat(FileName1,"",FileName).	/* Create a copy */

/************************************************************************
	Return a word from the DTA area
************************************************************************/

  DTA_word(DTA,OFF,WORD):-
	ptr_dword(DTA,DTA_SEG,DTA_OFF),
	NEW_OFF = DTA_OFF+OFF,
	memword(DTA_SEG,NEW_OFF,WORD).
	

/************************************************************************
	Special version of frontchar
************************************************************************/

  FrontChar2(S,C,S2) :- FrontChar(S,C,S2),!.
  FrontChar2(S,'\000',S2) :-
	ptr_dword(S,S_SEG,S_OFF),
	S2_OFF=S_OFF+1,
	ptr_dword(S2,S_SEG,S2_OFF).

  isolate_bits(Word,ShiftFac,BitMask,V) :-
	bitright(Word,ShiftFac,V1),
	bitand(V1,BitMask,V).

