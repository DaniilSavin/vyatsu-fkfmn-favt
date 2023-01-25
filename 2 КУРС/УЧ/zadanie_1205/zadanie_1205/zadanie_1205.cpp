// zadanie_1205.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <cmath>
#include <string.h>
#include <vector>

using namespace std;

struct point 
{ 
	double x; 
	double y;
};

long double foot, metro;
int N;
point F[213];
long double gr[213][213];
long double dp[213];
bool f[213];
int r[213];

double GetRasst(point a, point b)
{
	return sqrt((a.x - b.x) * (a.x - b.x) + (a.y - b.y) * (a.y - b.y));
}

void Dijkstra() //Алгори́тм Де́йкстры Находит кратчайшие пути от одной из вершин графа до всех остальных
{
	memset(r, 0, sizeof(r));
	int u = N - 1;
	r[u] = -1;
	for (int i = 1; i <= N; i++) { dp[i] = 1000000000; f[i] = true; }
	dp[u] = 0;
	for (int i = 1; i <= N; i++)
	{
		long double mn = 1000000000;
		for (int j = 1; j <= N; j++)
			if (dp[j] <= mn && f[j]) { u = j; mn = dp[j]; }
		for (int j = 1; j <= N; j++)
			if (f[j])
				if (dp[j] > dp[u] + gr[u][j]) 
				{
					r[j] = u;
					dp[j] = dp[u] + gr[u][j]; 
				}
		f[u] = false;
	}


}
int main()
{
	memset(gr, 0, sizeof(gr));
	cin >> foot >> metro;
	cin >> N;
	for (int i = 1; i <= N; i++)
		cin >> F[i].x >> F[i].y;
	int a, b;
	cin >> a >> b;
	while (a != 0 && b != 0)
	{
		gr[a][b] = GetRasst(F[a], F[b]) / metro;
		gr[b][a] = gr[a][b];
		cin >> a >> b;
	}
	cin >> F[N + 1].x >> F[N + 1].y;
	cin >> F[N + 2].x >> F[N + 2].y;
	N += 2;
	for (int i = 1; i <= N; i++)
		for (int j = 1; j <= N; j++)
			if (gr[i][j] == 0 && i != j)
			{
				gr[i][j] = GetRasst(F[i], F[j]) / foot; 
				gr[j][i] = gr[i][j];
			}
	Dijkstra();
	cout.setf(ios::fixed);
	cout.precision(7);
	if (F[N].x != F[N - 1].x || F[N].y != F[N - 1].y)
	{
		cout << dp[N] << endl;
		vector<int> rt;
		int G = N;
		while (r[G] != -1) {
                 if (r[G] != N && r[G] != N - 1)
                    rt.push_back(r[G]); G = r[G]; 
                }
		cout << rt.size() << ' ';
		for (int i = rt.size() - 1; i >= 0; i--) cout << rt[i] << ' ';
	}
	else
	{
		double a = 0;
		cout << a << endl;
		cout << 0;
	}
	return 0;
}
