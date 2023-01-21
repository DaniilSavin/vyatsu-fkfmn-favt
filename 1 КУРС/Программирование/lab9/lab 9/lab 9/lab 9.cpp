// lab 9.cpp: определяет точку входа для консольного приложения.
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

	printf_s("Адрес переменной X--> %p\n", &X);
	printf_s("Значение pDouble (%p) указывает на значение %f\n", pDouble, *pDouble);
	printf_s("Значение pVoid (%p) указывает на значение %f\n", pVoid, *(double*)pVoid);
	printf_s("*&X имеет вид %f\n", *&X);
	system("PAUSE");
	return 0;
}


























