// zadanie_1.cpp: определ€ет точку входа дл€ консольного приложени€.
//

#include "stdafx.h"
#include "clocale"

void func (int &a, int &b, int &c);
void obmen(int &a, int &b);
int main ()
{
	setlocale(LC_ALL, "rus");
	int a, b, c, cur=0;
	printf_s("¬ведите числа a, b, c:");
	scanf_s("%d%d%d", &a, &b, &c);
	func(a, b, c);
	printf_s("%d %d %d\n", a, b, c);

}


void obmen(int &a, int &b)
{
	int cur = a;
	a = b;
	b = cur;
}

void func (int &a, int &b, int &c)
{
	int cur=0;
	if (a > b && b > c) { // a>b>c \\ c<b<a
		obmen(a, c);
	}
	/*if (a < b && b < c) { // c>b>a \\ a<b<c
        
	}*/
	if (a<b && b>c && a<c) { // b>c>a \\ a<c<b
		obmen(b, c);
	}
	if (a<b && b>c && a>c) { // b>a>c \\ c<a<b
		cur = b;
		b = a;
		a = c;
		c = cur;
	}
	if (a > b && b<c && a>c) { // a>c>b \\ b<c<a
		cur = a;
		a = b;
		b = c;
		c = cur;
	}
	if (a > b && b < c) { // c>a>b \\ b<a<c
		obmen(a, b);
	}
}

