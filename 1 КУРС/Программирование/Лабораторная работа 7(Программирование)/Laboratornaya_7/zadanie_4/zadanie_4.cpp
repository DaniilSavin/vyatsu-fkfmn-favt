// zadanie_4.cpp: ���������� ����� ����� ��� ����������� ����������.
//4.����������, ���� ����� ������������ ������ ����� n ��������� � ���������� �����. ���������� � ���� ����� ������ ������������

#include "stdafx.h"
#include <iostream> 

using namespace std;

int f(int n);

int main()
{
	int n, m, max = 0;
	cout << "������� ���������� �����: " << endl;
	cout << "n = ";
	cin >> n;
	cout << "������� �����: " << endl;
	for (int i = 0; i < n; i++)
	{
		cin >> m;
		if (f(m) > max)
		{
			max = f(m);
		}
	}
	cout << "������������ �����: " << max << endl;
	return 0;
}

int f(int n)
{
	while (n > 10)
	{
		n /= 10;
	}
	return n;
}