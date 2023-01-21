﻿// zadanie_1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <fstream>
#include <string>
#include <cstdio>
#include "ctime"
#include "clocale"

using namespace std;

void display(int** A, int DIM1, int DIM2);
void init(int** A, int DIM1, int DIM2);
void file(int** A, int DIM1, int DIM2);

int main()
{
	setlocale(LC_ALL, "rus");
	int DIM1, DIM2;
	cout << "Imput DIM1 and DIM2 numbers: ";
	cin >> DIM1 >> DIM2;
	if (DIM1 > 1 && DIM2 > 1)
	{
		int** A;
		A = new int*[DIM1];
		for (int i = 0; i < DIM1; i++)
			*(A + i) = new int[DIM2];
		init(A, DIM1, DIM2);
		display(A, DIM1, DIM2);
		file(A, DIM1, DIM2);
	}
	else cout << "Incorrect values!" << endl;
	system("pause");
	return 0;
}

void init(int** A, int DIM1, int DIM2)
{
	srand(time(NULL));
	for (int k = 0; k < DIM1; k++)
		for (int i = 0; i < DIM2; i++)
			*(*(A + k) + i) = rand() / 100;
}

void display(int** A, int DIM1, int DIM2)
{

	for (int k = 0; k < DIM1; k++)
	{
		for (int i = 0; i < DIM2; i++)
		{
			cout << *(*(A + k) + i) << "\t";
			
		}
		cout << endl;
	}
	
}


void file(int** A, int DIM1, int DIM2)
{
	string name;
	cout << "Введите имя файла: ";
	cin >> name;
	ofstream fout;
	fout.open(name);
	if (fout.is_open())
	{
		for (int k = 0; k < DIM1; k++)
		{
			for (int i = 0; i < DIM2; i++)
			{
				fout << *(*(A + k) + i) << "\t";
			}
			fout << endl;
		}
	}
	else
	{
		cout << "Ошибка открытия файла." << endl;
	}
	fout.close();
		

}