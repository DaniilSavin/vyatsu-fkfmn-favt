// zadanie_3.cpp: определ€ет точку входа дл€ консольного приложени€.
//

#include "stdafx.h"
#include "iostream"
#include "clocale"

using namespace std;

void func(int n);
int sum(int x);

int main()
{
	int n;
ch:
    cout << "¬ведите n: ";
	cin >> n;
	if (n>9)
	{
	 func(n);
	}
	else goto ch;
}


int sum(int x)
{
	int s = 0;
	while (x > 0)
	{
		s += x % 10;
		x /= 10;
	}
	return s;
}

void func(int n)
{
	for (int i = 1;i <= n; i++)
	{
		if (sum(i) % 2 == 0)
			cout << i<<" ";
	}

	 /*int i1=0,  i2=0,  i3=0, sum=0;
	 if (n<=99)
	 {
		 for (int i=10; i<n+1; i++)
		 {
	         i1=floor(i/10);
	         i2=fmod(i,10);
	         sum=i1+i2;
	         if (fmod(sum, 2)==0)
	         {
				 cout << i << "\t";
	         }
		 }
	 }
		 if (n<1000)
		 {
			 for (int i=10; i<n+1; i++)
		 {
			 i1=floor(i/10);
	         i2=fmod(i,10);
	         sum=i1+i2;
	         if (fmod(sum, 2)==0)
	         {
				 cout << i << "\t";
	         }
		 }
		 for (int i=100; i<n+1; i++)
		 {
          i1=floor(i/100);
		  i2=fmod(i, 100)/10;
		  i3=fmod(i, 10);
		  sum=i1+i2+i3;
		  if (fmod(sum, 2)==0)
		  {
			  cout << i << "\t";
		  }
		 }
		 cout << "          " << endl;
		 }
	 return 0;*/

}