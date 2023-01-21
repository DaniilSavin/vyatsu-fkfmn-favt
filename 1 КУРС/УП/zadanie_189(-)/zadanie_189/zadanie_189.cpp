// zadanie_189.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include "pch.h"
#include <iostream>
#include <vector>
#include <set>

using namespace std;

int fact[13] = { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880, 3628800, 39916800, 479001600 };

int notUsed(vector<bool> &used, int blockNum)
{

	int j = 0, pos = 0;
	for (j = 1; j < used.size(); j++) {
		if (!used[j]) pos++;
		if (blockNum == pos)
			break;
	}
	return j;
}

int getBlockNum(vector<bool> &used, int value) {
	int blockNum = 0;
	for (int i = 1; i < used.size(); i++) {
		if (!used[i]) {
			blockNum++;
			if (i == value)
				break;
		}
	}
	return blockNum;
}

vector<int> permutation_by_num(int n, int num) {

	vector<int> res(n);
	vector<bool> used(n + 1, false);

	for (int i = 0; i < n; i++) {
		int blockNum = (num - 1) / fact[n - i - 1] + 1;
		int j = notUsed(used, blockNum);
		res[i] = j;
		used[j] = true;
		num = (num - 1) % fact[n - i - 1] + 1;
	}
	return res;
}

int num_by_permutation(vector<int> &perm) {
	int n = perm.size();
	vector<bool> used(n + 1, false);

	int num = 1;
	for (int i = 0; i < n; i++) {
		int blockNum = getBlockNum(used, perm[i]);
		num += (blockNum - 1) * fact[n - 1 - i];
		used[perm[i]] = true;
	}
	return num;
}

void output(vector<int> &perm) {
	for (int i = 0; i < perm.size(); i++)
		cout << perm[i] << ' ';
}

int main() {
	freopen("input.txt", "r", stdin);
	freopen("output.txt", "w", stdout);

	int n, num;
	cin >> n >> num;
	vector<int> perm = permutation_by_num(n, num);
	if (num_by_permutation(perm) != num)
		while (true) {};
	output(perm);
	return 0;
}