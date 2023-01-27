// 2.2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <string>
using namespace std;

// Вернуть дополнение к двоичной строке. 
string invert(string s)
{
	string invert_string;
	for (int i = 0; i < s.length(); i++)
	{
		if (s.at(i) == 'a') invert_string += 'b';
		else invert_string += 'a';
	}
	return invert_string;
}

string thuemorse(int n)
{
	string s = "a";
	for (int i = 0; i < n; i++)
		s += invert(s);
	return s;
}

int main()
{
	int n = 3;
	cout << "Stroka Thue Morse dlya N = " << n << " : " << thuemorse(n) << endl;
	return 0;
}


