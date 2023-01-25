// zadanie_1718.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <stdio.h>
#include <string.h>
char rm[10000][100], s[10000] = { 0 };
int main() {
	int c1 = 0, c2 = 0, n, j, i, in, rs = 0, i1, i2;
	char a[100], b[10];
	scanf("%d", &n);
	for (i = 0; i < n; i++) {
		scanf("%s %s", a, b);
		i1 = i2 = 0;
		if (b[0] == 'A')i2 = 1;
		else if (b[0] == 'C')goto nxt;
		else {
			scanf("%d", &in);
			if (in < 6)goto nxt;
			else if (in == 6)i2 = 1;
			else {
				i1 = 1;
				i2 = 1;
			}
		}
		for (j = 0; j < rs; j++)if (strcmp(a, rm[j]) == 0) {
			if (i1 == 1 && s[j] == 0) {
				s[j] = 1;
				c1++;
				goto nxt;
			}
			goto nxt;
		}
		strcpy(rm[rs], a);
		s[rs] = i1;
		rs++;
	ok:
		c1 += i1;
		c2 += i2;
	nxt:;
	}
	printf("%d %d\n", c1, c2);
}


