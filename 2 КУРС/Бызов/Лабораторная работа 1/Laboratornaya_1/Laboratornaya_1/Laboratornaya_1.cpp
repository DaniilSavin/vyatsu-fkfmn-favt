// Laboratornaya_1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "iostream"
#include "stdlib.h"
#include <string>
#include "math.h"
#include "windows.h"

using namespace std;

string to_binary(long long int n);
string inversion(string n);
string add_null(string n, int power);
string add_one(string n);

int main()
{
	setlocale(LC_ALL, "rus");
	long long int n;
	int view;
	int power;
	cout << "Введите число: ";
	cin >> n;
	cout << "Введите число двоичных разрядов: ";
	cin >> power;
	cout << "Введите его вид: ";
	cin >> view;
	cout << "*" << endl; Sleep(250); cout << "*" << endl; Sleep(250); cout << "*" << endl;
	if (view != 0 && view != 1)
	{
		cout << "Вы ввели неверный вид числа." << endl;
	}
	else
		if (view == 0 && n < 0)
		{
			cout << "Отрицательное число не может находиться в беззнаковом типе." << endl;
		}
		else
			if (power <= 0)
			{
				cout << "Разрядность не может <= 0." << endl;
			}
			else
			{
				long long int min = -pow(2, power - 1), max;
				if (view == 1)
				{
					max = pow(2, power - 1) - 1;
				}
				else
				{
					max = pow(2, power - 1) - 1 + min * -1;
					min = 0;
				}
				cout << "Интервал от " << min << " до " << max <<";"<< endl;
				if (min > n || n > max)
				{
					cout << "Число не войдет в интервал." << endl;
				}
				else
				{
					bool check = false;
					if (n < 0)
					{
						n *= -1;
						check = true;
					}
					cout << n << " переведено в " << to_binary(n)<<";" << endl;
					string dvoi4niy_vid = to_binary(n);
					dvoi4niy_vid = add_null(dvoi4niy_vid, power);
					cout << "Полный код: " << dvoi4niy_vid <<";"<< endl;
					if (check)
					{
						cout << "Обратный код: " << inversion(dvoi4niy_vid) << ";" << endl;
						cout << "Дополнительный код: " << add_one(inversion(dvoi4niy_vid))<<";" << endl;
					}
				}
			}
	
}

string to_binary(long long int n)
{
	string dvoi4niy_vid;
	if (n == 0)
	{
		return "0";
	}
	dvoi4niy_vid += to_string(n % 2);
	while (n > 1)
	{
		n /= 2;
		dvoi4niy_vid += to_string(n % 2);
	}

	for (int i = 0; i < dvoi4niy_vid.length() / 2; i++)
	{
		dvoi4niy_vid[i] = dvoi4niy_vid[i] + dvoi4niy_vid[dvoi4niy_vid.length() - i - 1];
		dvoi4niy_vid[dvoi4niy_vid.length() - i - 1] = dvoi4niy_vid[i] - dvoi4niy_vid[dvoi4niy_vid.length() - i - 1];
		dvoi4niy_vid[i] = dvoi4niy_vid[i] - dvoi4niy_vid[dvoi4niy_vid.length() - i - 1];
	}
	return dvoi4niy_vid;
}

string inversion(string n)
{
	string dvoi4niy_vid = n;
	for (int i = 0; i < dvoi4niy_vid.length(); i++)
	{
		if (dvoi4niy_vid[i] == '0')
		{
			dvoi4niy_vid[i] = '1';
		}
		else
		{
			dvoi4niy_vid[i] = '0';
		}
	}
	return dvoi4niy_vid;
}

string add_one(string n)
{
	string dvoi4niy_vid = n;
	bool check = false;
	int count = n.length();
	while (!check)
	{
		if (dvoi4niy_vid[count] == '0')
		{
			dvoi4niy_vid[count] = '1';
			check = true;
		}
		else
		{
			dvoi4niy_vid[count] = '0';
		}
		count--;
	}
	return dvoi4niy_vid;
}

string add_null(string n, int power)
{
	string dvoi4niy_vid = n;
	while (dvoi4niy_vid.length() < power)
	{
		dvoi4niy_vid.insert(0, 1, '0');
	}
	return dvoi4niy_vid;
}

