// Shift-or-and.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <string.h>
#include <limits.h>
#include <clocale>
using namespace std;

bool BitapSearch(string text, string pattern)
{
	int m = pattern.size();
	unsigned long R;
	unsigned long patternMask[CHAR_MAX + 1];
	int i;
	//~Побитовый оператор НЕ зменяет каждый бит на противоположный: 0 становится 1, а 1 становится 0.
	// инициализировать битовый массив R 
	R = ~1;

	//Инициализировать битовые маски шаблона 
	for (i = 0; i <= CHAR_MAX; ++i)
		patternMask[i] = ~0;
	for (i = 0; i < m; ++i)
		patternMask[pattern[i]] &= ~(1UL << i);

	for (i = 0; text[i] != '\0'; ++i)
	{
		// Обновить битовый массив 
		//Теперь результат r после вышеуказанной операции мы сдвигаем влево на 1 раз
		R |= patternMask[text[i]];
		R <<= 1;
		if (0 == (R & (1UL << m)))
			return true;
	}

	return false;
}

int main()
{
	setlocale(0, "");
	string text = "AABAACAADAABAABA";
	string pattern = "AABA";
	BitapSearch(text, pattern) ? cout << "Подстрока найдена" : cout << "Подстрока НЕ найдена";
}

