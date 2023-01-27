// zadanie_693.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

//#include "pch.h"
#include <iostream>

bool is_cmp(const char* s1, const char* s2) 
{
	const int  N = 26;
	int c, cs[N] = { 0 };

	while (*s1) {
		c = *s1++;
		if (c >= 'A' && c <= 'Z')
			++cs[c - 'A'];
		else if (c >= 'a' && c <= 'z')
			++cs[c - 'a'];
	}

	while (*s2) {
		c = *s2++;
		if (c >= 'A' && c <= 'Z')
			--cs[c - 'A'];
		else if (c >= 'a' && c <= 'z')
			--cs[c - 'a'];
	}

	for (int i = 0; i < N; ++i) {
		if (cs[i] != 0)
			return false;
	}
	return true;
}

int main(void) 
{
	
	char s1[] = "TomMarvoloRiddle";
	char s2[] = "IamLordVoldemort";
	std::cin >> s1>>s2;
	if (is_cmp(s1, s2))
		std::cout << "Yes";
	else
		std::cout << "No";
	std::cout << std::endl;
	return 0;
}
