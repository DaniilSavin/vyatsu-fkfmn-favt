// zadanie_1259.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
using namespace std;
int GCD(int a, int b)
{
	while (b)
	{
		int tmp = a % b;
		a = b;
		b = tmp;
	}
	return (a);
}
int main()
{
	int s = 0, n, i;
	cin >> n;
	for (i = 1; i <= n / 2; i++)
        {
		if (GCD(n, i) % n == 1)
                { 
			s++;
                }
        }
	cout << s;
	return 0;
}
