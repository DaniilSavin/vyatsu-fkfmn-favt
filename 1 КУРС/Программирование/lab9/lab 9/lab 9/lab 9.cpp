// lab 9.cpp: ���������� ����� ����� ��� ����������� ����������.
//

#include "stdafx.h"
#include "stdlib.h"
#include "clocale"
#include "iostream"

using namespace std;

int main()
{
	setlocale(0, "");
	double X = 444.555555;
	double * pDouble = &X;
	void * pVoid = &X;

	printf_s("����� ���������� X--> %p\n", &X);
	printf_s("�������� pDouble (%p) ��������� �� �������� %f\n", pDouble, *pDouble);
	printf_s("�������� pVoid (%p) ��������� �� �������� %f\n", pVoid, *(double*)pVoid);
	printf_s("*&X ����� ��� %f\n", *&X);
	system("PAUSE");
	return 0;
}


























