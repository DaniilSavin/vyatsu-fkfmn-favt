// zadanie_5.cpp: ���������� ����� ����� ��� ����������� ����������.
//5.���� ����������� �����. ����� ��� ��� ��������. ���������� �� ����������. ����� ����� ���� ���������

#include "stdafx.h"
#include <iostream> 

using namespace std;

void func(int x, int &sum, int &k);


int main()
{
	setlocale(LC_ALL, "rus");
	int x;
	cout << "������� ���� �����: ";
	cin >> x;
	int sum = 1, k = 1;
	func(x, sum, k);
	cout << "����������= " << k << endl << "�����=" << sum << endl;
}


void func(int x, int &sum , int &k)
{
	for (int i = 2; i < x; i++)
	{
		if (fmod(x, i) == 0)
		{
			k++;
			sum += i;
		}
	}
	
}
