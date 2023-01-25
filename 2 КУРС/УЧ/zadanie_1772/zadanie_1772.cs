using System;
using System.Collections.Generic;

// zadanie_1772.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
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



public class SegmentTree
{
	// Первая запись в {-1, 1} обозначает возрастающую или убывающую последовательность ширины
	// этот узел и вторая запись обозначают крайнее левое значение диапазона
	private List<Tuple<char, long>> A = new List<Tuple<char, long>>();
	private int size;

	public SegmentTree(int n = 1)
	{
		this.size = n;
		int pow2 = 1;
//C++ TO C# CONVERTER TODO TASK: Variables cannot be declared in if/while/switch conditions in C#:
		while ((pow2 *= 2) < n)
		{
			;
		}
		pow2 *= 2;
		A.Resize(pow2);
	}

//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int d>
	public void set<int d>(int node, int left, int right, int i, int j, long n)
	{
		// Диапазон обновления находится в пределах диапазона, который представляет этот узел
		if (i <= left && j >= right)
		{
			A[node] = new Tuple<char, long>(d, n + d * (left - i));
			return;
		}
		int mid = (right + left) / 2;
		// Мы обновляем подмножество диапазона этого узла, поэтому нам нужно пометить этот узел как
		// не репрезентативно и вместо этого отправляем его значение детям
		if (A[node].Item2 >= 0)
		{
			A[node * 2] = A[node];
			A[node * 2 + 1] = A[node];
			A[node * 2 + 1].Item2 += A[node].Item1 * (1 + mid - left);
		}
		A[node].Item2 = -1;

		// Recurse to the children and update their ranges
		if (j > mid)
		{
			set<d>(node * 2 + 1, mid + 1, right, i, j, n);
		}
		if (i <= mid)
		{
			set<d>(node * 2, left, mid, i, j, n);
		}
	}

	public long query(int node, int left, int right, int i)
	{
		if (i >= left && i <= right && A[node].Item2 >= 0)
		{
			return A[node].Item2 + A[node].Item1 * (i - left);
		}
		int mid = (right + left) / 2;
		if (i > mid)
		{
			return query(node * 2 + 1, mid + 1, right, i);
		}
		else if (i <= mid)
		{
			return query(node * 2, left, mid, i);
		}
	}

	public long query(int i)
	{
		return query(1, 1, A.Count / 2, i);
	}

//C++ TO C# CONVERTER TODO TASK: C++ template specifiers with non-type parameters cannot be converted to C#:
//ORIGINAL LINE: template<int dir>
	public void set<int dir>(int i, int j, long n)
	{
		set<dir>(1, 1, A.Count / 2, i, j, n);
	}
}