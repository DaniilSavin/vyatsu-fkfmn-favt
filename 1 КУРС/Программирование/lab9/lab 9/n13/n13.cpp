// n6.cpp: ���������� ����� ����� ��� ����������� ����������.
//

#include "stdafx.h"
#include "stdlib.h"
#include "iostream"
#include "ctime"
using namespace std;
void display(int num[10]);

int main()
{
	srand(time(NULL));
	int A[10] = { 0 };
	for (int i = 0; i < 10; i++)
	{
		*(A + i) = rand() % 100 - 50;
	}
	cout << "������ ������: " << endl;
	display(A);
	
	int B[10] = { 0 };
	for (int i = 0; i < 10; i++)
	{
		*(B + i) = rand() % 100 - 50;
	}
	cout << "������ ������: " << endl;
	display(B);
	int C[10] = {0};
	for (int i = 0; i <= 9; i++)
	*(C+i) = *(A+i) + *(B+i);
	cout << "���������: " << endl;
	display(C);
	system("pause");
	return 0;
}

void display(int num[10])
{
	for (int i = 0; i <= 9; i++) printf("%d = %d\n", i, *(num + i));
}