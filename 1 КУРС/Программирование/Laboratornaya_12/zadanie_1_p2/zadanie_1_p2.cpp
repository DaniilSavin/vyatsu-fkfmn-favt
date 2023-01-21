// zadanie_1_p2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <string>
#include "clocale"

using namespace std;

string convert(string &str);
bool ispalindrom(string str);

int main()
{
	setlocale(0, "");
	string str;
	getline(cin, str);
	cout << (ispalindrom(str)) ? 1 : 0;
	system("pause");
	return 0;
}

bool ispalindrom(string str)
{
	convert(str);
	bool yes = true;
	for (int i = 0; i < str.length() / 2; i++)
	{
		if (str[i] != str[str.length() - i - 1]) yes = false;
		cout << str[i] << " " << str[str.length() - i - 1] << endl;
	}
	return yes;
}

string convert(string &str)
{
	for (int i = 0; i < str.length(); i++)
	{
		str[i] = tolower(str[i]);
		if (str[i] == ' ' ||
			str[i] == ',' ||
			str[i] == '?' ||
			str[i] == '.' ||
			str[i] == '!')
		{
			str.erase(i, 1);
			i--;
		}
	}
	return str;
}


