#include "pch.h"
#include <iostream>
#include <cstring>
#include <iostream>
#include <fstream>
#include <stdio.h>

using namespace std;

char* strtolower(const char* str)
{
	char* res = new char[strlen(str) + 1];
	strcpy(res, str);
	for (size_t i = 0; i < strlen(res); ++i)
		res[i] = tolower(res[i]);
	return res;
}

int main()
{
	setlocale(LC_ALL, "Russian");
	const int len = 255;
	char word[len];
	char line[len];
	char *modline;
	char* modword;

	while (1)
	{
		cout << "Введите слово для поиска: ";
		if (gets_s(word) == NULL) goto q;

		int l_word = strlen(word);
		modword = strtolower(word);
		ifstream fin("text.txt");
		if (!fin)
		{
			cout << "Ошибка открытия файла." << endl;
			return 1;
		}

		int count = 0;

		while (!fin.eof()) // заносим строку длинной len в переменную line
		{
			fin.getline(line, len);
			if (!strcmp(line, ""))
				break;
			modline = strtolower(line); //превращаем все прописные буквы в строчные
			char *p = modline; // р - для хранения позиции за найденной подстрокой
			while (p = strstr(p, modword)) // многократно ищем вхождение подстроки в строку
			{
				char *c = p; //c - для хранения адреса начала вхождения подстроки
				p += l_word; // перемещаем указатель на длину заданного слова

				if (c != modline) // слово не в начале строки?
					if (!ispunct(*(c - 1)) && !isspace(*(c - 1))) // символ перед словом не разделитель?
						continue;
				if (ispunct(*p) || isspace(*p) || (*p == '\0')) // символ после слова разделитель?
					count++;
			}
		}
		cout << endl << "Слово " << word << " встретилось в файле " << count << " раз(а). Выход <Ctrl+Z>" << endl << endl;

	}

q:;
	return 0;
}