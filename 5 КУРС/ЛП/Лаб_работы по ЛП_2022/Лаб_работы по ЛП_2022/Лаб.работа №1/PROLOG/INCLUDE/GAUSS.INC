%  Модуль для pешения системы линейных уpавнений методом Гаусса
%  Пpимеp вызова:
/*
  GOAL
    makewindow(1,47,47,"",0,0,25,80),
    Amatrix = [[2,1,1],[1,-1,1],[1,1,-1]],
    Bmatrix = [7,2,0],
    gauss(Amatrix,Bmatrix,X),
    write(X,"\nOk...").
*/
%   Результат : x = 1 , y = 2, z = 3.   

   DOMAINS
    element = real
    list = real*
    matrix = list*
    
  PREDICATES
    sub(list,list,list)
    gauss(matrix,list,list)
    reform_matrix(list,matrix,element,list,matrix,list)
    logic(list,element,list,element)
    mul(list,list,element)
    mul_matrix(element,list,list)

  CLAUSES
    gauss([[HA|_]|_],[HB|[]],[HX|[]]):-!,
      HX = HB / HA.
    gauss([HA|TA],[HB|TB],[HX|TX]):-  
      reform_matrix(HA,TA,HB,TB,NA,NB),
      gauss(NA,NB,TX),
      logic(TX,HB,Ha,HX).
    
    reform_matrix(_,[],_,_,[],[]):-!.
    reform_matrix([HA|TA],[[H1|T1]|TAA],B,[HB|TB],[NAH|NAT],[NHB|NTB]):-  
      Factor = H1 / HA,
      mul_matrix(Factor,TA,MulTA),
      sub(T1,MulTA,NAH),
      NHB = HB - B * Factor,
      reform_matrix([HA|TA],TAA,B,TB,NAT,NTB).
          
    logic(Xlist,B,[HA|TA],X):-  
      mul(Xlist,TA,Value),
      X = (B - Value) / HA.
    
    mul([],_,0):-!.
    mul([HX|TX],[HA|TA],Val):-
      mul(TX,TA,Work),
      Val = HX * HA + Work.
      
    sub([],_,[]):-!.
    sub([H1|T1],[H2|T2],[H|T]):-
      H = H1 - H2,
      sub(T1,T2,T).

    mul_matrix(_,[],[]):-!.
    mul_matrix(Factor,[H1|T1],[H2|T2]):-  
      H2 = H1 * Factor,
      mul_matrix(Factor,T1,T2).
