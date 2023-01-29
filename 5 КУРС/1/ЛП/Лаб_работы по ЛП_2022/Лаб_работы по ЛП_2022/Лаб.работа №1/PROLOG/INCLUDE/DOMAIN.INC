  DOMAINS
    db_selector = dba
    fields = field(inicials,
                   adress,
                   kinds,
                   characteristics,
                   belongings,    
	           informations,
                   dates,
                   number_of_turns,
                   first_numbers,
                   places,
                   solutions,
                   boolean)

    
    inicials = inicial(string,string,string)   % фамилия имя отчество
    adress = adres(string)                     % адрес   
    kinds = kind_of_turn(string)               % вид очереди
    characteristics = characteristic(string)   % характеристика занимаемой 
    					       % площади
    belongings = belonging(string)	       % принадлежность площади				       
    informations = information(string)         % справка о составе семьи
    dates = date(string)                       % дата постановки на учет
    number_of_turns = number_of_turn(real)     % номер очереди
    first_numbers = first_number(real)         % первоначальный номер очереди 
    places = place(string)  		       % место работы	
    solutions = solution(string)               % контрольные решения
    boolean = true;false		       % след обработки	
