// zadanie_1178.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <stdio.h>
#include <deque>
#include <algorithm>

using namespace std;

class node 
{
public:
	int x, y, num;
}dum;

bool func(node i, node j)
{
	if (i.y > j.y)
		return true;
	return false;
}

int main()
{
	deque<node> city;
	int n;  
	cin >> n;
	for (int i = 0; i < n; i++)
	{
		cin >> dum.x >> dum.y;
		dum.num = (i + 1);
		city.push_back(dum);
	}
	if (n == 0)
	{
		cout << "0";
		return 0;
	}
	sort(city.begin(), city.end(), func);
	for (int i = 0; i < n; i += 2)
	{	
		cout << city[i].num << " " << city[i + 1].num << endl;
	}
}
