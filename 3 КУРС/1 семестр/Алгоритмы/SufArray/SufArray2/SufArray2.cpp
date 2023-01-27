// SufArray2.cpp : O(nlogn).
//

#include <iostream>
#include <cstring> 
#include <algorithm> 
using namespace std;

// Структура для cуффиксного массива
struct suffix
{
	int index; // Чтобы хранить исходный индекс
	int rank[2]; // Чтобы хранить следующую пары рангов
};

// Функция сравнения, для сравнения двух суффиксов
// Сравнивает две пары, возвращает 1, если первая пара меньше
int sravnenie(struct suffix a, struct suffix b)
{
	return (a.rank[0] == b.rank[0]) ? (a.rank[1] < b.rank[1] ? 1 : 0) :
		(a.rank[0] < b.rank[0] ? 1 : 0);
}

// построение суфиксного массива
int* buildSuffixArray(char* txt, int n)
{
	//Структура для хранения суффиксов и их индексов
	struct suffix suffixes[16];

	// Сохраняем суффиксы и их индексы в массиве структур, что бы потом отсортировать суффиксы по алфавиту 
	//и сохранить их старые индексы при сортировке
	for (int i = 0; i < n; i++)
	{
		suffixes[i].index = i;
		suffixes[i].rank[0] = txt[i] - 'a';
		suffixes[i].rank[1] = ((i + 1) < n) ? (txt[i + 1] - 'a') : -1;
	}
	sort(suffixes, suffixes + n, sravnenie);

	// На этом этапе все суффиксы отсортированы по первым двум символам.
	//Затем оритурем суффиксы по первым 4 символам,по 8 символам и д
	int ind[16];    // Этот массив нужен для получения индекса в суффиксах из исходного индекса.нужно для получения следующего суффикса.
	for (int k = 4; k < 2 * n; k = k * 2)
	{
		// Присвоение значений ранга и индекса первому суффиксу
		int rank = 0;
		int prev_rank = suffixes[0].rank[0];
		suffixes[0].rank[0] = rank;
		ind[suffixes[0].index] = 0;

		// Присвоение ранга суффиксам
		for (int i = 1; i < n; i++)
		{
			// Если первый и следующий ранги совпадают с рангом предыдущего суффикса в массиве, 
			//присваиваем этому суффиксу тот же новый ранг либо наоборот увеличиваем ранг
			if (suffixes[i].rank[0] == prev_rank &&
				suffixes[i].rank[1] == suffixes[i - 1].rank[1])
			{
				prev_rank = suffixes[i].rank[0];
				suffixes[i].rank[0] = rank;
			}
			else
			{
				prev_rank = suffixes[i].rank[0];
				suffixes[i].rank[0] = ++rank;
			}
			ind[suffixes[i].index] = i;
		}

		// назначение следующиго ранг каждому суффиксу
		for (int i = 0; i < n; i++)
		{
			int nextindex = suffixes[i].index + k / 2;
			suffixes[i].rank[1] = (nextindex < n) ?
				suffixes[ind[nextindex]].rank[0] : -1;
		}

		// сортируем суффиксы по первым k символам
		sort(suffixes, suffixes + n, sravnenie);
	}

	// храним индексы всех отсортированных суффиксов в массиве суффиксов
	int* suffixArr = new int[n];
	for (int i = 0; i < n; i++)
		suffixArr[i] = suffixes[i].index;

	return  suffixArr;
}

void printArr(int arr[], int n, char* txt)
{
	for (int i = 0; i < n; i++)
		cout << txt[i] << "\t";
	cout << endl;
	for (int i = 0; i < n; i++)
		cout << arr[i] << "\t";

	cout << endl;
	cout << endl;
}

int main()
{
	setlocale(0, "");
	char txt[] = "abaaaabaaaabaaba";
	int n = strlen(txt);
	int* suffixArr = buildSuffixArray(txt, n);
	cout << "Суффиксный массив построенный за NlogN для " << txt << endl;
	printArr(suffixArr, n, txt);
	return 0;
}

