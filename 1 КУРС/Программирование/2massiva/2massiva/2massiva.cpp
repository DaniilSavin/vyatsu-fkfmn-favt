#include "stdafx.h" 
#include "iostream" 
#include "clocale"

using namespace std;

void sravnenie(int A[], int B[], int C[], int sizea, int sizeb, int sizec);

int main()
{
	setlocale(LC_ALL, "rus");
	cout<< "¬ведите размер A: ";
	
	int sizea, sizeb;
	cin >> sizea;
	cout << "¬ведите размер B: ";
	cin >> sizeb;
	int sizec = sizea + sizeb;
	int* A = new int[sizea];
	cout << "Ёлементы A:" << endl;
	for (int i = 0; i < sizea; i++)
	{
		cin >> *(A + i);
	}
	
	int* B = new int[sizeb];
	cout << "Ёлементы B:" << endl;
	for (int i = 0; i < sizeb; i++)
	{
		cin >> *(B + i);
	}
	int* C = new int[sizec];
	sravnenie(A, B, C, sizea, sizeb, sizec);
	system("pause");
	return 0;
}

void sravnenie(int A[], int B[], int C[], int sizea, int sizeb, int sizec)
{
	for (int i = 0; i < sizea; i++)
		*(C + i) = *(A + i);
	for (int i = sizea; i < sizec; i++)
		*(C + i) = *(B + i - sizeb);

	
	for (int i = 0; i < sizea - 1; i++)
		for (int j = 0; j < sizea - i - 1; j++)
			if (*(C + j) > *(C + j + 1))
			{
				int temp = *(C + j);
				*(C + j) = *(C + j + 1);
				*(C + j + 1) = temp;
			}
	cout << " " << endl;
	cout<< "A:"<< endl;
	for (int i = 0; i < sizea; i++)
		cout << *(A + i) << endl;
	cout << " " << endl;
	cout<< "B:"<< endl;
	for (int i = 0; i < sizeb; i++) 
		cout << *(B + i) << endl;
	cout << " " << endl;
	cout<< "C:"<< endl;
	for (int i = 0; i < sizec; i++)
		cout << *(C + i) << endl;
}