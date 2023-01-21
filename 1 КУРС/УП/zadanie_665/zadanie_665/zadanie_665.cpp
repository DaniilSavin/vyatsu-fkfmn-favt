//#include "pch.h"
#include <iostream>

int main()
{
    char a; 
	int h, m;
	std::cin >> h >> a >> m;
	
	if (h == 23 && m <= 31)
	{
		std::cout << "23:32";
		return 0;
	}
	if (h == 23 && m >= 32) 
	{
		std::cout << "00:00";
		return 0;
	}
	m++;
	while (h / 10 != m % 10 || h % 10 != m / 10)
	{
		m++;
		if (m == 60)
		{
			m = 0;
			h++;
		}
		if (h == 24)
		{
			h = 0;
		}
	}

	if (h < 10) std::cout << '0';
	std::cout << h << ':';
	if (m < 10) std::cout << '0';
	std::cout << m;
}


