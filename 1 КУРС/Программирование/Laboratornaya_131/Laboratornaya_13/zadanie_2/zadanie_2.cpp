// zadanie_2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
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

void file_save(int A[], int n);
void file_input(int n);
void file_display();

int main()
{
	srand(time(NULL));
	int n, k = 0;
	cout << "Enter n(size): ";
	cin >> n;
	int *A = new int[n];
	
	for (int i = 0; i < n; i++)
	{
		*(A + i) = rand() % 101 - 50;
	}
	file_save(A, n);
	file_input(n);
	file_display();

	return 0;
}

void file_save(int A[], int n)
{
	ofstream fout;
	fout.open("file1.txt");
	if (fout.is_open())
	{
		for (int i = 0; i < n; i++)
		{
			fout << *(A + i) << endl;
		}
	}
	else
	{
		cout << "Ошибка открытия файла." << endl;
	}
	fout.close();
	
}

void file_input(int n)
{
	string str;
	int count_ = 0;
	ifstream fin("file1.txt");
	ofstream fout2;
	fout2.open("file2.txt");
	if (fin.is_open() && fout2.is_open())
	{
		while (!fin.eof())
		{
			str = " ";
			getline(fin, str);
			if (fmod(count_, 2) == 0)
			{
				fout2 << str << endl;
				count_++;
			}
			else count_++;
		}
	}
	else 
	{
		cout << "Ошибка открытия файла." << endl;
	}
	fin.close();
	fout2.close();
}

void file_display()
{
	string str2;
	ifstream fin2("file2.txt");
	{
		while (!fin2.eof())
		{
			str2 = " ";
			getline(fin2, str2);
			cout << str2 << endl;
		}
	}
}


