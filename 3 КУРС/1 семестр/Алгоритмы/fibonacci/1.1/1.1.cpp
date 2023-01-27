// 1.1.cpp : 1.	Написать программу генерации строки fn по заданному n. 
//

#include <iostream>
#include <string>
using namespace std;

string fibonachi(int n)
{
	string x = "x", y = "y", tmp;
	for (int i = 2; i <= n; i++)
	{
		tmp = x;
		x += y;
		y = tmp;
	}
	return x;
}

int main()
{
	int n = 7;
	cout << "Stroka Fibonachi dlya N = " << n << " : " << fibonachi(n) << endl;
	return 0;
}




