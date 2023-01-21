// zadanie_5.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
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

void file_save(char str[]);
void newmass(char str[], int z);
//void file_input(int n);

int main()
{
	setlocale(LC_ALL, "rus");
	char *str = new char [100] ;
	cout << "Введите ваш текст: ";
	cin >> str;
	file_save(str);
	system("pause");
	return 0;
}

void file_save(char str[])
{
	
	int z = 0;
	ofstream fout;
	fout.open("f.txt");
	
	if (fout.is_open())
	{
		for (int i = 0; i < 100; i++)
		{
			if (*(str + i) == ' ' && i>0)
			{
				z = i;
				newmass(str, z);
			}
		}
	}
	else
	{
		cout << "Ошибка открытия файла." << endl;
	}
	fout.close();
	

}

/*void file_input(int n)
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
}*/


void newmass(char str[], int z)
{
	char *words = new char[100];
	for (int h = 0; h < z; h++)
	{
		*(words + h) = *(str + h);
	}
}