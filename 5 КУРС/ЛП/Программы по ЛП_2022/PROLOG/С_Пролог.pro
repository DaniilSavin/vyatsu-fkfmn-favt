domains

database
 xpositive(symbol,symbol)
 xnegative(symbol,symbol)

predicates
 do_expert_bird.
 do_consulting
 ask(symbol,symbol)
 tree_is(symbol)
 positive(symbol,symbol)
 negative(symbol,symbol)
 remember(symbol,symbol,symbol)
 clear_facts

goal
 do_expert_bird.

clauses
 do_expert_bird:-
  makewindow(1,7,7,"Expert System",1,3,22,71),
  nl,write(" ---------------------------------------------------"),
  nl,write(" A Tree Expert "),
  nl,write("   "),
 nl,write(" Please answer the questions 'yes' or 'no'."),
 nl,write(" ---------------------------------------------------"),
 nl,nl,
 do_consulting,
 write("Press space bar."),nl,
 readchar(_),
 removewindow,
 exit. 
 do_consulting:-
 tree_is(X),!,nl,
 write("Tree ",X,"."),nl,
 clear_facts.
 do_consulting:-
 nl,write("Sorry !"),
 clear_facts.
 ask(X,Y):-
 write(" expert> ",X," ",Y," ?"),
 readln(Reply),
 remember(X,Y,Reply).
 positive(X,Y):-
 xpositive(X,Y),!.
 positive(X,Y):-
 not(negative(X,Y)),!,
 ask(X,Y).
 negative(X,Y):-
 xnegative(X,Y),!.
 remember(X,Y,yes):-
 asserta(xpositive(X,Y)).
 remember(X,Y,no):-
 asserta(xnegative(X,Y)),
 fail.
 clear_facts:-
 retract(xpositive(_,_)),
 fail.
 clear_facts:-
 retract(xnegative(_,_)),
 fail.
tree_is("���"):-
 positive(tree,"����������"),
 positive(tree,"�������"),
 positive(tree,"����_����������"),
 positive(tree,"������_��������"),!.
tree_is("���"):-
 positive(tree,"����������"),
 positive(tree,"�������"),
 positive(tree,"������_�������"),
 positive(tree,"�������_��������"),!.
tree_is("�����"):-
 positive(tree,"����������"),
 positive(tree,"������"),
 positive(tree,"�������"),
 positive(tree,"������_��������"),!.
tree_is("���"):-
 positive(tree,"����������"),
 positive(tree,"�����_�������"),
 positive(tree,"������"),!.
tree_is("���"):-
 positive(tree,"�������"),
 positive(tree,"������"),
 positive(tree,"�������"),
 positive(tree,"���������"),!.
tree_is("�����"):-
 positive(tree,"�������"),
 positive(tree,"������"),
 positive(tree,"�������"),
 positive(tree,"�����_���������"),!.
tree_is("�����"):-
 positive(tree,"��_������"),
 positive(tree,"�����_�������"),!.


