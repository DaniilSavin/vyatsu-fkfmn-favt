// 2.1.cpp :Написать программу генерации строки Tn по заданному n на основе 
//

#include <iostream>
#include <string>
using namespace std;

// вернуть дополнение строки
string complement(string s)
{
	string comps;
	// найти дополнение строки
	for (int i = 0; i < s.length(); i++) 
	{
		// если 0, добавить 1
		if (s.at(i) == '0')
			comps += '1';
		// если 1, добавить 0
		else
			comps += '0';
	}
	return comps;
}

//вернуть n номер последовательности 
string nthTerm(int n)
{
	string s = "0";
	for (int i = 1; i < n; i++)
		// добавление добавления к строки
		s += complement(s);


	return s;
}

int main()
{
	int n = 4;
	cout << nthTerm(n) << endl;
	return 0;
}

