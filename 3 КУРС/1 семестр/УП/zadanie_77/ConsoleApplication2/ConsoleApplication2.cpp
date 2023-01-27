// ConsoleApplication5.cpp: определяет точку входа для консольного приложения.
//

#include "pch.h"
#include "stdlib.h"
#include "math.h"
#include <fstream>

using namespace std;

ifstream in("input.txt");
ofstream out("output.txt");

int main()
{
	int N, K;
	int rezcount = 0;
	in >> N >> K;
	for (int i = 1; i <= N; i++)
	{
		int n = i;
		int count = 0;
		int c;
		int* A;
		int size = 0;
		int ndublicate = n;
		while (n != 0) {
			c = n % 2;
			n /= 2;
			size++;
		}
		A = new int[size];
		int g = 0;
		while (ndublicate != 0) {
			*(A + g) = ndublicate % 2;
			ndublicate /= 2;
			g++;
		}
		int result = 0;
		for (g = 0; g < size; g++)
		{
			result += *(A + g)*(pow(10, g));
		}
		int temp = result;
		while (temp != 0)
		{
			if (temp % 10 == 0) count++;
			temp /= 10;
		}
		if (count == K) rezcount++;
	}
	out << rezcount;
	return 0;
}
