#include <stdio.h>
#include <conio.h>
#include <iostream>

using namespace std;

extern "C" void lb_13(void);
extern "C" short int a, b, rez;
 
void main()
{
	cin >> a >> b;
	cout << "\nc++: " << endl;
	if (a > b)
	{
		cout << (2 * b + a * b) / a << endl;
	}
	else
	{
		if (a == b)
		{
			cout << 160 << endl;
		}
		else
		{
			cout << (a + 3 - b) / (b - 3) << endl;
		}
	}
	cout << "\nasm: " << endl;
	lb_13();
	cout << "result= " << rez << endl;
}