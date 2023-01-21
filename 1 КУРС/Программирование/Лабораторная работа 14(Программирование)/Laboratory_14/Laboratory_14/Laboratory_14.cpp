
#include "stdafx.h"
#include "struc.h"
#include "clocale"

int main()
{
	setlocale(LC_ALL, "ru");
	cout << "1 - Создать таблицу 2 - Открыть таблицу" << endl;
	int tt;
	cin >> tt;
	if (tt == 1)
	{
		int n;
		cout << "Введите количество записей в таблице" << endl;
		cin >> n;
		SiteUser *a = new SiteUser[n];
		initconsol(a, n);
		cout << "Вывод таблицы:" << endl;
		printconsol(a, n);
		printbinfile(a, n);
	}
	else
	{
		vector<SiteUser> ab;
		string h = initfromfile(ab);
		int rr = 0;
		while (rr != 7)
		{
			cout << "1 - Добавить новую запись в таблицу" << endl;
			cout << "2 - Показать таблицу" << endl;
			cout << "3 - Сортировка таблицы по фамилии" << endl;
			cout << "4 - Вывести список иностранцев" << endl;
			cout << "5 - Поиск самого молодого русскиго участника" << endl;
			cout << "6 - Поиск работника Вятгу" << endl;
			cout << "7 - Выход" << endl;
			cin >> rr;
			switch (rr)
			{
			case 1:
			{
			cout << "Добавление элемента:" << endl;
			add(ab, h);
			}
				break;
			case 2:
			{
				cout << "Вывод таблицы" << endl;
				printconsol(ab);
			}
			break;
			case 3:
			{
				cout << "Сортировка таблицы по фамилии:" << endl;
				SortF(ab);
			}
			break;
			case 4:
			{
				cout << "Вывести список иностранцев:" << endl;
				SortRU(ab);
			}
			break;
			case 5:
			{
				cout << "Поиск самого молодого русскиго участника:" << endl;
				SortOldRU(ab);
			}
			break;
			case 6:
			{
				cout << "Поиск работника Вятгу:" << endl;
				SortVy(ab);
			}
			break;
			}
		}
	}
	cout << "Завершение работы." << endl;
    return 0;
}

