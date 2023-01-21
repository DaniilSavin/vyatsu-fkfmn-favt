// zadanie_6_p2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <algorithm>
#include <sstream>

using namespace std;

int main()
{
	string str, symbols = "aeiouyAEIOUY";
	getline(cin, str);
	for (string::iterator it = str.begin(); it != str.end(); ++it)
	{
		if (find(symbols.begin(), symbols.end(), *it) != symbols.end())
		{
			str.erase(it);
			it = str.begin();
		}
	}
	cout << str << endl;

	return 0;
}
