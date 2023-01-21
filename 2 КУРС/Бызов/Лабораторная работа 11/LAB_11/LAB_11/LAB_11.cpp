// LAB_11.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>

using namespace std;

/*extern "C" void LAB_11(void);
extern "C" short int a, b, c, res, ost;*/

int main()
{
	//16.(2+a+2*b)/(c).
	setlocale(LC_ALL, "rus");
	short int a, b, c, res, ost;
	cout << "Поддерживаемый диапазон [-32768,32767]." << endl;
	bool fl = false;
	while (!fl)
	{
		fl = true;
		cout << endl << "Введите числа a, b, c: ";	
		cin >> a >> b >> c;
		if (a < -32768 || a > 32767)
		{
			cout << "Переменная a вне диапазона допустимых значений";
			fl = false;
		}
		if (b < -32768 || b > 32767)
		{
			cout << "Переменная b вне диапазона допустимых значений";
			fl = false;
		}
		if (c < -32768 || c > 32767)
		{
			cout << "Переменная c вне диапазона допустимых значений";
			fl = false;
		}
	}
		cout << "C++: " << (2 + a + 2 * b) / c << endl;
		cout << "Остаток (C++): " << (2 + a + 2 * b) % c << endl;
		
		__asm
		{
			mov ax, a;
			add ax, 2; //a+2
			mov bx, b;
			imul bx, 2; //b*2
			add ax, bx; //a+2+2*b
			cwd;
			mov cx, c;
			idiv cx;
			mov res, ax;
			mov ost , dx;
		}
		cout << "ASSEMBLER: " << res << endl;
		cout << "ASSEMBLER остаток: " << ost << endl;
		return 0;
}




