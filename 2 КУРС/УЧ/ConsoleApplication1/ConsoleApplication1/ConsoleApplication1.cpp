// ConsoleApplication1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <stdio.h>
int a[100001], b[100001];

int max(int a, int b) {
	return a >= b ? a : b;
}
int min(int a, int b) {
	return a <= b ? a : b;
}
int main() {
	int bv = 0;
	int n, m, i;
	scanf("%d%d", &n, &m);
	for (i = 0; i < n; i++)scanf("%d", a + i);
	for (i = 0; i < m; i++)scanf("%d", b + i);
	bv = max(min(a[0], b[m - 1]), min(a[n - 1], b[0]));
	for (i = 1; i < n - 1; i++)bv = max(bv, min(min(a[i], b[0]), b[m - 1]));
	for (i = 1; i < m - 1; i++)bv = max(bv, min(min(b[i], a[0]), a[n - 1]));
	printf("%d\n", bv);
	return 0;
}

