word(ямал, [я,м,а,л]).
word(ягода, [я,г,о,д,а]).
word(автор, [а,в,т,о,р]).
word(атас, [а,т,а,с]).
word(вор, [в,о,р]).
word(вот, [в,о,т]).


 % include this new word!

crossword(H1,H2,H3,H4,V1,V2,V3,V4):-
    word(H1, [_,H1V1,_,H1V2,_,H1V3,_,H1V4,_]),
    word(H2, [_,H2V1,_,H2V2,_,H2V3,_,H2V4,_]),
    word(H3, [_,H3V1,_,H3V2,_,H3V3,_,H3V4,_]),
    word(H4, [_,H4V1,_,H4V2,_,H4V3,_,H4V4,_]),
    word(V1, [_,H1V1,_,H2V1,_,H3V1,_,H4V1,_]),
    word(V2, [_,H1V2,_,H2V2,_,H3V2,_,H4V2,_]),
    word(V3, [_,H1V3,_,H2V3,_,H3V3,_,H4V3,_]),
    word(V4, [_,H1V4,_,H2V4,_,H3V4,_,H4V4,_]),
    H1 \= V1,
    H2 \= V2,
    H3 \= V3,
    H4 \= V4.