// zadanie_8_p2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <regex>
#include <string>

int main()
{
	std::string str;
	std::getline(std::cin, str);
	std::regex r("AEYUIOeyuioa");
	std::cout << std::regex_replace(str, r, " ");
	return 0;
}
