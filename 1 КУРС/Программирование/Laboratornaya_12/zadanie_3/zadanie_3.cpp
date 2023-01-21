// zadanie_3.cpp: ���������� ����� ����� ��� ����������� ����������.
//

#include "stdafx.h"
#include <iostream>
#include <string.h>
#include <conio.h>

using namespace std;


int main()
{
	int count = 1;
	cout << "A) ";
	for (char i = 'Z'; i >='A'; i--)
	{
		cout << i;
	}
	cout << endl;
	cout << "B) ";
	for (char i = 'Z'; i >= 'A'; i--)
	{
		for (int z = 0; z < count; z++)
		{
			cout << i;
		}
		count++;
	}
	cout << endl;

    return 0;
}
