#include <iostream>
#include <stdio.h>
#include <iostream>
using namespace std;

int main()
{
	int N, b;
	cin >> N>> b;
        short n = 0;
	for (int i = 0; i < N; i++)
		if (i * b > 100 * n)
                    {
			n++;
                        cout << "1";
                     }
		else
			cout << "0";
}