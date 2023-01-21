// zadanie_3.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <fstream>
#include <string>
#include <cstdio>
#include "ctime"

using namespace std;

void file_save(int A[], int B[], int n);
void file_input(int n);

int main()
{
	//setlocale(LC_ALL, "rus");
	srand(time(NULL));
	int n, k = 0;
	cout << "Сколько чисел записать? : ";
	cin >> n;
	int *A = new int[n];
	int *B = new int[n];
	for (int i = 0; i < n; i++)
	{
		*(A + i) = rand() % 101 - 50;
		*(B + i) = rand() % 1000;
	}

	file_save(A, B, n);
	file_input(n);

	return 0;
}

void file_save(int A[], int B[], int n)
{
	ofstream fout;
	ofstream gout;
	fout.open("f.txt");
	gout.open("g.txt");
	if (fout.is_open() && gout.is_open())
	{
		for (int i = 0; i < n; i++)
		{
			fout << *(A + i) << endl;
			gout << *(B + i) << endl;
		}
	}
	else
	{
		cout << "Ошибка открытия файла." << endl;
	}
	fout.close();
	gout.close();

}

void file_input(int n)
{
	string str;
	int count_ = 0;
	ifstream fin("f.txt");
	ifstream gin("g.txt");
	ofstream hout;
	hout.open("h.txt", ofstream::app);
	if (fin.is_open() && gin.is_open())
	{
        while (!fin.eof())
		{
            str = " ";
			getline(fin, str);
			hout << str << endl;
		}
		while (!gin.eof())
		{
			str = " ";
			getline(gin, str);
			hout << str << endl;
		}

	}
	else
	{
		cout << "Ошибка открытия файла." << endl;
	}
	fin.close();
	gin.close();
	hout.close();
}


