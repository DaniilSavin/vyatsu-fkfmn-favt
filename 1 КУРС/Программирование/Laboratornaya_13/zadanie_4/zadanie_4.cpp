// zadanie_4.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include <fstream>
#include <string>
#include <cstdio>
#include "ctime"
#include "math.h"
#include "clocale"

using namespace std;

void file_save();
//void file_input(int n);

int count_1 = 0;
int count_2 = 0;
int count_3 = 0;

int main()
{
	setlocale(LC_ALL, "rus");
	file_save();
	if (count_1 > 0)
	{
		cout << "В первом файле количество открывающихся скобок больше, чем закрывающихся." << endl;
		cout << "На " << count_1 << endl;
	}
	else
	{
		if (count_1 == 0)
		{
			cout << "В первом файле количество открывающихся скобок равно количеству закрывающихся скобок." << endl;
			
		}
		else
		{
			if (count_1 < 0)
			{
				cout << "В первом файле количество открывающихся скобок меньше, чем закрывающихся." << endl;
				cout << "На " << abs(count_1) << endl;
			}
		}
	}
	if (count_2 > 0)
	{
		cout << "Во втором файле количество открывающихся скобок больше, чем закрывающихся." << endl;
		cout << "На " << count_2 << endl;
	}
	else
	{
		if (count_2 == 0)
		{
			cout << "Во втором файле количество открывающихся скобок равно количеству закрывающихся скобок." << endl;
		}
		else
		{
			if (count_2 < 0)
			{
				cout << "Во втором файле количество открывающихся скобок меньше, чем закрывающихся." << endl;
				cout << "На " << abs(count_2) << endl;
			}
		}
	}	if (count_3 > 0)
	{
		cout << "В третьем файле количество открывающихся скобок больше, чем закрывающихся." << endl;
		cout << "На " << count_3 << endl;
	}
	else
	{
		if (count_3 == 0)
		{
			cout << "В третьем файле количество открывающихся скобок равно количеству закрывающихся скобок." << endl;
		}
		else
		{
			if (count_3 < 0)
			{
				cout << "В третьем файле количество открывающихся скобок меньше, чем закрывающихся." << endl;
				cout << "На " << abs(count_3) << endl;
			}
		}
	}
	system("pause");
	return 0;
}

void file_save()
{
	char ch;
	ifstream pin;
	pin.open("perviy.txt");
	ifstream vin;
	vin.open("vtoroy.txt");
	ifstream tin;
	tin.open("tretiy.txt");
	if (pin.is_open() && vin.is_open() && tin.is_open())
	{
		while (pin.get(ch))
		{
		    if (ch == '(')
			{
				count_1++;
			}
			else
			{
				if (ch == ')')
				{
					count_1--;
				}
			}
		}
		while (vin.get(ch))
		{
			if (ch == '(')
			{
				count_2++;
			}
			else
			{
				if (ch == ')')
				{
					count_2--;
				}
			}
		}
		while (tin.get(ch))
		{
			if (ch == '(')
			{
				count_3++;
			}
			else
			{
				if (ch == ')')
				{
					count_3--;
				}
			}
		}


	}
	else
	{
		cout << "Ошибка открытия файла." << endl;
	}
	pin.close();
	vin.close();
	tin.close();
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
