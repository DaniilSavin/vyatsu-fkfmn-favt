// zadanie_6.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <string.h>
#include <conio.h>
#include <string> 

using namespace std;

int length(char s[]);
int numbers(char str[]);
int punct(char str[]);
int prob(char str[]);
int abc(char str[]);
int other(char str[]);

using namespace std;

int lengthofstr = 0;

int main()
{
	char s[80] = { 0 };
	int count;
	cout << "Введите строку: ";
	gets_s(s);

	cout << "length=" << length(s) << endl;
	if (numbers(s) > 0)
		cout << "numbers =" << numbers(s) << " " << numbers(s) * 100 / lengthofstr << "%" << endl;
	else
		cout << "numbers = 0 %0" << endl;
	if (punct(s) > 0)
		cout << "punct =" << punct(s) << " " << punct(s) * 100 / lengthofstr << "%" << endl;
	else
		cout << "punct = 0 %0" << endl;
	if (punct(s) > 0)
		cout << "prob =" << prob(s) << " " << prob(s) * 100 / lengthofstr << "%" << endl;
	else
		cout << "prob = 0 %0" << endl;

	if (abc(s) > 0)
		cout << "abc =" << abc(s) << " " << abc(s) * 100 / lengthofstr << "%" << endl;
	else
		cout << "abc = 0 %0" << endl;
	if (other(s) > 0)
		cout << "other =" << other(s) << " " << other(s) * 100 / lengthofstr << "%" << endl;
	else
		cout << "other = 0 %0" << endl;

	system("pause");
	return 0;
}

int length(char s[])
{
	for (int i = 0; i < 70 && (int)*(s + i) != 0 && (int)*(s + i) != -2; i++)
	{
		lengthofstr++;
	}
	return lengthofstr;
}

int abc(char str[])
{
	int count = 0;
	int i = 0;
	for (int i = 0; i < lengthofstr; i++)
		if (isupper(str[i]) || islower(str[i]))count++;
	return count;
}

int other(char str[])
{
	int count = 0;
	int i = 0;
	for (int i = 0; i < lengthofstr; i++)
		if (!isdigit(str[i]) &&
			!isalpha(str[i]) &&
			!isspace(str[i]) &&
			!isalnum(str[i]) &&
			!ispunct(str[i]) &&
			!isupper(str[i]) &&
			!islower(str[i]))count++;
	return count;
}

int prob(char str[])
{
	int count = 0;
	int i = 0;
	for (int i = 0; i < lengthofstr; i++)
		if (str[i] == ' ')count++;
	return count;
}

int punct(char str[])
{
	int count = 0;
	int i = 0;
	for (int i = 0; i < lengthofstr; i++)
		if (ispunct(str[i]))count++;
	return count;
}

int numbers(char str[])
{
	int count = 0;
	int i = 0;
	for (int i = 0; i < lengthofstr; i++)
		if (isdigit(str[i]))count++;
	return count;
}


