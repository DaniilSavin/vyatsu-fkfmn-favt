// zadanie_2_p2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <string>
#include "clocale"

using namespace std;
int countofwords(string str);

int main()
{
	setlocale(0, "");
	string str;
	getline(cin, str);
	cout << "count = " << countofwords(str) << endl;
	system("pause");
	return 0;
}

int countofwords(string str)
{
	int count = 1;
	for (int i = 0; i < str.length(); i++)
	{
		if (str[i] == ' ' && str[i + 1] != ' ') count++;
	}
	return count;
}
