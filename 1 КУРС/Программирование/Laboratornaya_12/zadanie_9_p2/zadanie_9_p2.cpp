// zadanie_9_p2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <cctype>
#include <string>

using namespace std;

int main()
{
	string str = "abc";
	getline(cin, str);
	
	unsigned int i = 0;
	while (i < str.length())
	{
		if (isalpha(str[i]))
		{
			str.insert(i, "?");
			++i;
			while (i < str.length() && isalpha(str[i]))
				++i;
		}
		else ++i;
	}
	cout << str << endl;
	return 0;
}
