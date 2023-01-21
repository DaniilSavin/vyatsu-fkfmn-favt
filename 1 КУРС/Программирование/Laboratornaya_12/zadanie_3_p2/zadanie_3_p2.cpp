// zadanie_3_p2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <string>

using namespace std;

string maxsesion(string str);

int main()
{
	setlocale(0, "");
	string str;
	getline(cin, str);
	cout << "result = " << maxsesion(str) << endl;
	system("pause");
	return 0;
}

string maxsesion(string str)
{
	int max = 0; char maxchar = '*'; int current = 0;
	for (int i = 0; i < str.length(); i++)
	{
		if (str[i] == str[i + 1])
		{
			current++;
		}
		if (current > max)
		{
			max = current;
			maxchar = str[i];
		}
	}
	str = "";
	for (int i = 0; i <= max; i++) str += maxchar;
	if (max > 0)return str; else return "ERROR!!!";
}

