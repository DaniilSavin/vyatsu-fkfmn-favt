﻿// zadanie_1772.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

/*Стратегия:
 * Если мы допустим, чтобы массив A обозначал оптимальный результат для набора дорожек после некоторого препятствия,
 * всякий раз, когда мы добавляем препятствие, значения результата рядом с препятствием увеличиваются в линейном
 * мода от внешних ценностей к некоторому максимальному значению в середине.
 *
 * A_k A_ {k + 1}
 * 5 5
 * 4 4
* 3 | 5
* 2 | 6
* 3 | 7
* 4 | 6
 * 5 5
 * 
 * Для быстрого расчета этих значений используется структура точечного запроса обновления диапазона, построенная на
 * типичная структура кучи дерева сегментов, которая обновляется аналогичным образом.
 *
 * Представление:
 * O (klog n), запускает тесты за 0,14 с, используя 4296 КБ памяти.
 */


#include <iostream>
#include <stdio.h>
#include <vector>
#include <algorithm>

class SegmentTree
{
	// Первая запись в {-1, 1} обозначает возрастающую или убывающую последовательность ширины
	// этот узел и вторая запись обозначают крайнее левое значение диапазона
	std::vector<std::pair<char, long long>> A;
	int size;

public:
	SegmentTree(int n = 1) : size(n)
	{
		int pow2 = 1;
		while ((pow2 *= 2) < n);
		pow2 *= 2;
		A.resize(pow2);
	}

	template<int d> void set(int node, int left, int right, int i, int j, long long n)
	{
		// Диапазон обновления находится в пределах диапазона, который представляет этот узел
		if (i <= left && j >= right)
		{
			A[node] = { d, n + d * (left - i) };
			return;
		}
		int mid = (right + left) / 2;
		// Мы обновляем подмножество диапазона этого узла, поэтому нам нужно пометить этот узел как
		// не репрезентативно и вместо этого отправляем его значение детям
		if (A[node].second >= 0)
		{
			A[node * 2] = A[node];
			A[node * 2 + 1] = A[node];
			A[node * 2 + 1].second += A[node].first * (1 + mid - left);
		}
		A[node].second = -1;

		// Recurse to the children and update their ranges
		if (j > mid)
			set<d>(node * 2 + 1, mid + 1, right, i, j, n);
		if (i <= mid)
			set<d>(node * 2, left, mid, i, j, n);
	}

	long long query(int node, int left, int right, int i)
	{
		if (i >= left && i <= right && A[node].second >= 0)
			return A[node].second + A[node].first * (i - left);
		int mid = (right + left) / 2;
		if (i > mid)
			return query(node * 2 + 1, mid + 1, right, i);
		else if (i <= mid)
			return query(node * 2, left, mid, i);
	}

	long long query(int i)
	{
		return query(1, 1, A.size() / 2, i);
	}

	template<int dir> void set(int i, int j, long long n)
	{
		set<dir>(1, 1, A.size() / 2, i, j, n);
	}
};

int main()
{
	long long n, s, k, l, r;
	scanf("%lld %lld %lld", &n, &s, &k);
	SegmentTree st(n);
	st.set<-1>(1, s, s - 1);
	st.set<1>(s, n, 0);

	while (k--)
	{
		scanf("%lld %lld", &l, &r);
		// Мы обновляем диапазон, как показано в заголовке комментария
		long long a = l > 1 ? st.query(l - 1) : -1, b = r < n ? st.query(r + 1) : -1;
		long long t = (b - a + l + r) / 2;
		if (l > 1 && r < n)
		{
			st.set<1>(l - 1, t, a);
			st.set<-1>(t, r + 1, a + t - l + 1);
		}
		else if (l == 1)
			st.set<-1>(l, r, r + 1 - l + b);
		else if (r == n)
			st.set<1>(l, r, a + 1);
	}
	long long min = std::numeric_limits<long long>::max();
	for (int i = 1; i <= n; i++)
		min = std::min(min, st.query(i));
	printf("%lld", min);
}
