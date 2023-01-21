// LAB_12.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>

using namespace std;

unsigned short int a, c, d, e, f, r;

int to_digit(string s);
int to_binary(int d);

int main()
{
	setlocale(LC_ALL, "rus");
	string s, s1 = "\n15 14 13 12 11 10 9  8  7  6  5  4  3  2  1  0";
	cout << "Введите число типа short int в двоичном виде(16 знаков): ";
	cin >> s;
	cout << "\nВаше число:" << endl;
	cout << s1 << endl;
	a = to_digit(s);
	to_binary(a);
	
	__asm
	{
		MOV DX, a
		AND DX, 0000000001001001b
		MOV d, DX

		MOV AX, a
		OR AX, 0000000010010010b
		MOV c, AX

		MOV BX, a
		AND BX, 0000000100100100b
		MOV r, BX

		MOV DX, c
		XOR DX, 0000000100100100b
		AND DX, 1111111011011011b
		MOV e, DX

		NOT DX
		NOT DX
		MOV f, DX

	}
	cout << "\nСодержимое битов 0, 3, 6:" << endl;
	cout << s1 << endl;
	to_binary(d);
	cout << "\nБиты 1, 4, 7 установлены в единицу:" << endl;
	cout << s1 << endl;
	to_binary(c);
	cout << "\nСодержимое битов 2, 5, 8:" << endl;
	cout << s1 << endl;
	to_binary(r);
	cout << "\nОбнуление битов 2, 5, 8:" << endl;
	cout << s1 << endl;
	to_binary(e);
	cout << "\nДвойное отрицание:" << endl;
	cout << s1 << endl;
	to_binary(f);
	return 0;
}

int to_digit(string s)
{
	int num = 0, degree = 0;
	for (int i = 15; i >= 0; i--)
	{
		if (s[i] == '1')
		{
			num += pow(2, degree);
			degree++;
		}
		else
			degree++;
	}
	return num;
}

int to_binary(int d)
{
	int s[16] = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
	int i = 0;
	while (d > 0)
	{
		s[i] = d % 2;
		d /= 2;
		i++;
	}
	for (int j = 15; j >= 0; j--)
		cout << s[j] << "  ";
	cout << endl;
	return 0;
}