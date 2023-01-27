// Prefix_func.cpp : Дана строка S длины n. Требуется посчитать количество её различных подстрок. 
//

#include <iostream>
#include <string>
#include <regex>
using namespace std;

int countnews = 0;

vector<int> prefix_function(const string& s)
{
	cout << s;
	int len = s.length();
	vector<int> p(len);
	int k = 0; // счетчик
	for (int i = 1; i < len; i++)
	{
		if (s[k] != s[i])
		{
			// повторная проверка при k = 0
			if (s[0] != s[i])
				k = 0;
			else 
				k = 1;
		}
		else
		{
			k++; // если символы совпадают -> увеличиваем значение счетчика
		}
		p[i] = k; // значение счетчик в вектор
	}

	for (int i = 0; i < len; i++)
	{
		cout << " " << p[i] << " ";
		if (p[i] == 0) countnews++;
	}
	cout << endl;
	return p;
}


int main()
{

	string s = "abcabcd";
	string tmps = "";
	int answer = 0;
	cout << s << endl;
	for (int i = 0; i < s.size()-1; i++) 
	{
		tmps += s[i];
		reverse(tmps.begin(), tmps.end());
		prefix_function(tmps); //вовзращает кол-во новых
		reverse(tmps.begin(), tmps.end());
		answer += countnews;
		countnews = 0;
	}
	cout << endl << answer << endl;

}
//a 0
//ab 0
//abc 0
//abca 1
//abcab 2
//abcabc 3
//abcabcd 0

///
//
//
///
//
//


