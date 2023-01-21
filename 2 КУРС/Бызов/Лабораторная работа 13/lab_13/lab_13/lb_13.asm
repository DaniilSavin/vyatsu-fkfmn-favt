;Инструкции процессора Pentium
.586P
;Плоская модель памяти, соглашение о вызовах в стиле С
.MODEL FLAT,C
;Сегмент данных
DATA SEGMENT
PUBLIC a, b, rez;переменные, доступные для внешних модулей
a DW ? ;Объявление переменных
b DW ?
rez DW ?

DATA ENDS
;Сегмент кода
CODE SEGMENT
PUBLIC lb_13 ;функция, доступная для внешних модулей
lb_13 PROC ;определение функции
		mov ax, a;
		mov bx, b;
		cmp ax, bx;
		je L; 
		jl Q; 
		jg H; 
	L: mov rez, 160;
			jmp eexit;
	Q: add a, 3;
		mov ax, a;
		mov bx, b;
		sub b, 3;
		sub ax, bx;
		cwd;
		idiv b
		mov rez, ax
		jmp eexit

	H: mov ax, a
		mov bx, b
		imul ax, bx
		imul bx, 2
		add ax, bx;		
		cwd;
		idiv a;
		mov rez, ax;
		jmp eexit;
		eexit:
RET
lb_13 ENDP
CODE ENDS
END