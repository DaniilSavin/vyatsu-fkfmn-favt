// ConsoleApplication1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <clocale>
#include <ctime>
using namespace std;

int main()
{
	srand(time(0));
	setlocale(0, "");
	int banka = 0, del;
	int player = 0, i = 0 ;
	banka = 15 + rand() % 10;
	cout << "В банке " << banka << " огурцов" << endl;

	while (player < 1 || player > 2)
	{
		cout << "Введите порядок хода пользователя. 1 - первый, 2 - второй" << endl;
		cin >> player;
	}
	int temp = player;

	while (banka > 0)
	{
		if (player % 2 == 1)
		{
			del = 0;


			while (del > 2 || del < 1)
			{
				cout << endl << "Введите сколько съесть огурцов из банки? - " ;
				cin >> del;
			}
			banka = banka - del;
			cout << endl << "Огурцов в первой банке осталось после игрока: " << banka << endl;
		}
		else
		{
			if (banka % 3 == 0)
				 i = rand() % 2 + 1;
			else
			{
				int k = banka;
				if ((k - 1) % 3 == 0)
					i = 1;
				else
					i = 2;
			}
			
			banka = banka - i;

			cout << endl << "Огурцов в банке осталось после компьютера: " << banka  << endl;
		}
		player++;
	}

	//cout << endl << player << endl;

	if (temp == 1)
	{
		if (player % 2 == temp - 1)
			cout << "Игрок победил" << endl;
		else
			cout << "Компьютер победил" << endl;
	}
	else
	{
		if (player % 2 == temp % 2)
			cout << "Игрок победил" << endl;
		else
			cout << "Компьютер победил" << endl;
	}
	return 0;
}

