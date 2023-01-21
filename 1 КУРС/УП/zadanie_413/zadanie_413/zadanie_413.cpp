// zadanie_413.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <stdio.h>
char ** matrix;
unsigned int a, b;
void check(unsigned int x, unsigned int y)
{
	if (x < a - 1)
		if (matrix[x + 1][y] == '#')
		{
			matrix[x + 1][y] = '.';
			check(x + 1, y);
		}
	if (x > 0)
		if (matrix[x - 1][y] == '#')
		{
			matrix[x - 1][y] = '.';
			check(x - 1, y);
		}
	if (y < b - 1)
		if (matrix[x][y + 1] == '#')
		{
			matrix[x][y + 1] = '.';
			check(x, y + 1);
		}
	if (y > 0)
		if (matrix[x][y - 1] == '#')
		{
			matrix[x][y - 1] = '.';
			check(x, y - 1);
		}
}
int main()
{
	FILE * f = fopen("input.txt", "r");
	fscanf(f, "%d %d", &a, &b);
	matrix = new char*[a];
	for (int i = 0; i < a; i++)
	{
		matrix[i] = new char[b];
		fscanf(f, "%s", matrix[i]);
	}
	fclose(f);
	unsigned int sum = 0;
	for (int i = 0; i < a; i++)
		for (int j = 0; j < b; j++)
			if (matrix[i][j] == '#')
			{
				sum++;
				check(i, j);
			}
	f = fopen("output.txt", "wt");
	fprintf(f, "%d", sum);
	fclose(f);
	return 0;
}
