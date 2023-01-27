// 3.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <string>
#include <regex>
using namespace std;

int countnews = 0;

vector<int> prefix_function(string s)
{
	cout << s;
	int len = s.length();
	vector<int> p(len);
	int k = 0; // счетчик
	reverse(s.begin(), s.end());
	for (int i = 1; i < len; i++)
	{
		if (s[k] != s[i])
		{
			// повторная проверка при k = 0
			if (s[0] != s[i]) k = 0;
			else k = 1;
		}
		else
		{
			k++; // если символы совпадают -> увеличиваем значение счетчика
		}
		p[i] = k; // значение счетчик в вектор
	}

	for (int i = 0; i < len; i++) {
		cout << " " << p[i] << " ";
		if (p[i] == 0) countnews++;
	}
	cout << endl;
	return p;
}


int main()
{

	string s = "abaca";
	string tmps = "";
	int answer = 0;
	cout << s << endl;
	for (int i = 0; i < 5; i++) {
		tmps += s[i];
		//reverse(tmps.begin(), tmps.end());
		prefix_function(tmps); //вовзращает кол-во новых
		//reverse(tmps.begin(), tmps.end());
		answer += countnews;
		countnews = 0;
	}
	cout << endl << answer << endl;
	//модификация: избавились от переворачиваний, просто префикс функция ищется с конца
}
