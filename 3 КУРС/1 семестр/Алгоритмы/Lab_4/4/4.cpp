// 4.cpp : Дана строка S длины n. Требуется найти самое короткое её "сжатое" представление
//

#include <iostream>
#include <vector>
#include <string>
#include <clocale>
using namespace std;

vector<int> findsubstring(string s)
{
	int n = (int)s.size();
	vector<int> pi(n);
	int tmpcount = 0;
	for (int i = 1; i < n; i++)
	{
		int j = pi[i - 1];
		while (j > 0 && s[i] != s[j])
		{
			j = pi[j - 1];
		}
		if (s[i] == s[j]) {
			j++;
		}

		pi[i] = j;
	}
	return pi;
}

int main()
{
	setlocale(0, "");
	cout << "Введите строку:";
	string s;
	cin >> s;
	vector <int> p = findsubstring(s);
	cout << "Минимальный размер подстроки: ";
	cout << s.size() - p.back() << endl;
	cout << "Подстрока: ";
	for (int i = 0; i < s.size() - p.back(); i++) {
		cout << s[i];
	}
	cout << "\nСтепень: " << (s.size() / (s.size() - p.back()));
	return 0;
}
