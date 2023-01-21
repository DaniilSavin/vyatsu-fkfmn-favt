// zadanie_7.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <cstring>
#include <iostream>
#include <fstream>
#include <stdio.h>
#include <vector>
#include <cstdlib>

using namespace std;

unsigned long long
hash(std::string const& s)
{
	unsigned long long results = 12345; //  anything but 0 is probably OK.
	for (auto current = s.begin(); current != s.end(); ++current) 
	{
		results = 127 * results + static_cast<unsigned char>(*current);
	}
	return results;
}