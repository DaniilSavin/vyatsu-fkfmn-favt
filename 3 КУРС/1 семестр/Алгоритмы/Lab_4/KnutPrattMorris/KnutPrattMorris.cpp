// KnutPrattMorris.cpp : Дана цепочка S и образец P. Требуется, используя алгоритм Кнута-Морриса-Пратта,  
//А) найти первое вхождение P в S; 
//Б) найти последнее вхождение P в S;
//С) найти все позиции, начиная с которых P входит в S;

//

#include <iostream>
#include <clocale>
#include <string>
using namespace std;
void prefix(char* pat, int M, int* lps);

// Печатает вхождения txt [] в pat []
void KMPSearch(char* pat, char* txt)
{
	int M = strlen(pat);
	int N = strlen(txt);

	// создать lps [], и заполнить префикс функцией
	int lps[1000];
	prefix(pat, M, lps);

	int i = 0; // индекс для txt []
	int j = 0; // индекс для pat []
	while (i < N) {
		if (pat[j] == txt[i]) {
			j++;
			i++;
		}
		if (j == M) {
			cout << "Подстрока найдена с индексом " << i - j << endl;
			j = lps[j - 1];
		}

		// несоответствие после j совпадений
		else if (i < N && pat[j] != txt[i]) {
			if (j != 0)
				j = lps[j - 1];
			else
				i = i + 1;
		}
	}
}

// префикс функция
void prefix(char* pat, int M, int* lps)
{
	int len = 0;
	lps[0] = 0;
	int i = 1;
	while (i < M) {
		if (pat[i] == pat[len]) {
			len++;
			lps[i] = len;
			i++;
		}
		else
		{
			if (len != 0) {
				len = lps[len - 1];
			}
			else
			{
				lps[i] = 0;
				i++;
			}
		}
	}
}

int main()
{
	setlocale(0, "");
	char txt[] = "AABAACAADAABAABA";
	char pat[] = "AABA";
	KMPSearch(pat, txt);
	return 0;
}

