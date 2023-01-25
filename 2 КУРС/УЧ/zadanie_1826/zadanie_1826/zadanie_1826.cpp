// zadanie_1826.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <algorithm>

using namespace std;

int main() {
	int n, v[101];
	cin >> n;
	for (int i = 0; i < n; i++)cin >> v[i];
	sort(v, v + n);
	if (n == 2)cout << v[1] << endl;
	else {
		int ans = 0, i;
		for (i = n - 1; i >= 4; i -= 2) ans += min(v[0] * 2 + v[i - 1] + v[i], v[0] + v[1] * 2 + v[i]);
		if (n % 2 == 1)ans += v[0] + v[i - 1] + v[i];
		else ans += min(v[0] * 2 + v[1] + v[i - 1] + v[i], v[0] + v[1] * 3 + v[i]);
		cout << ans << endl;
	}
	return 0;
}
