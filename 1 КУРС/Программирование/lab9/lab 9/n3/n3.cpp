// n3.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include <iostream>
using namespace std;
int main()
{
	int n1; cin >> n1;
	int L = 2;
	int n = n1;
	while (n /= 10)
		L++;
	char* str = new char[L];
	char* p = str + L - 1;
	*p = 0;
	while (p>str)
	{
		p--;
		*p = n1 % 10 + '0';
		n1 /= 10;
	}
	cout << str;
	system("pause");
	return 0;
}
