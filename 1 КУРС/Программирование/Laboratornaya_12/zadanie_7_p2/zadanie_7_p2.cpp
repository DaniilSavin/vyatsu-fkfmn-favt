// zadanie_7_p2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <string>
#include <sstream>
#include <algorithm>

using namespace std; 

int main()
{
	string str;
	getline(cin, str);
	stringstream ss(str);
	int count = 1;
	for (string word; ss >> word;)
	{
		if (count % 2 == 0)
			reverse(word.begin(), word.end());
		cout << word << " ";
		count++;
	}
}
