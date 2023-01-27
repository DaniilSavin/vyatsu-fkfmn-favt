#include "pch.h"
#include <iostream>
using namespace std;


int main()
{
	setlocale(LC_ALL, "Russian");
	int banka1 = 10; //банки
	int player = 0; //какой ход
	int choice = 0; //выбор банки за игрока
	int del = 0; //сколько удалить огурцов
	bool check = true; //проверка на не пустоту
	
	cout << "В первой банке – " << banka1 << " огурцов. Во второй – "<< banka2 << " . Двое играют по очереди. За ход разрешается съесть любое ненулевое количество огурцов из одной банки "<< endl;

	while (player < 1 || player > 2)
	{
		cout << "Введите порядок хода пользователя. 1 - первый, 2 - второй" <<endl;
		cin >> player;
	}
	int temp = player;

	while (banka1 > 0 && banka2 > 0) // выходит из цикла если одна банка пустая
	{
		check = true;

		if (player % 2 == 1)
		{
			choice = 0;
			del = 0;
			while (choice < 1 || choice > 2)
			{
				cout << endl <<"Из какой банки съесть огурцы?" << endl << "1 - первая банка" << endl << "2 - вторая банка" << endl;
				cin >> choice;
			}

			if (choice == 1 && banka1 != 0)
			{
				while (del > banka1 || del < 1)
				{
					cout << "Введите сколько съесть огурцов из первой банки? - ";
					cin >> del;
				}
				banka1 = banka1 - del;
				cout << endl << "Огурцов в первой банке осталось: " << banka1 << endl;
			}
			if (choice == 2 && banka2 != 0)
			{
				while (del > banka2 || del < 1)
				{
					cout << "Введите сколько съесть огурцов из второй банки? - ";
					cin >> del;
				}
				banka2 = banka2 - del;
				cout << endl << "Огурцов во второй банке осталось: " << banka2 << endl;
			}
			cout << endl <<"В банках после игрока" << endl << "1 - " << banka1 << endl << "2 - " << banka2 << endl;
		}
		else
		{
			while (check == true)
			{
				if (rand() % 2 + 1 == 1 && banka1 != 0)
				{
					int i = rand() % banka1 + 1;
					banka1 = banka1 - i;
					check = false;
				}
				else if (banka2 != 0)
				{
					int i = rand() % banka2 + 1;
					banka2 = banka2 - i;
					check = false;
				}
				else check = true;
			}
			cout << endl <<"В банках после компутера" << endl << "1 - " << banka1 << endl << "2 - " << banka2 << endl;
		}
		player++;
	}
	if (banka1 == 0 && banka2 == 0)
	{
		if (player % 2 == temp - 1) cout << "Игрок победил" << endl;
		else cout << "Компьютер победил" << endl;
	}
	return 0;
}
