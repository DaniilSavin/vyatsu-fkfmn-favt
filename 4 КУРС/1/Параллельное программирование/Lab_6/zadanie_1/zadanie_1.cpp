#include <iostream>
#include <cmath>
#include <mpi.h>
using namespace std;

int proc_rank, proc_num;

int* Create(int n)
{
	int* x = new int[n];
	for (int i = 0; i < n; i++)
	{
		x[i] = i;
	}
	return x;
}

int main(int argc, char* argv[]) 
{
	const int buf_size = 1;
	int n = 0, m = 0;
	int* x = new int[1], * y = new int[1], * z = new int[1];
	double start, end, diff;
	MPI_Init(&argc, &argv);
	MPI_Comm_rank(MPI_COMM_WORLD, &proc_rank);
	MPI_Comm_size(MPI_COMM_WORLD, &proc_num);
	if (proc_rank == 0)
	{
		cout << "Input n" << endl;
		cin >> n;
		cout << "Input m" << endl;
		cin >> m;
		if (n < 0)
			n = 0;
		if (n > 500000000)
			n = 500000000;
		if (m < 0)
			m = 0;
		if (m > 500000000)
			m = 500000000;
		x = Create(n);
		y = Create(n);
		z = Create(m);
		for (int i = 0; i < n; i++) {
			cout << x[i] << ' ';
		}
		cout << endl;
		for (int i = 0; i < n; i++) {
			cout << y[i] << ' ';
		}
		cout << endl;
		for (int i = 0; i < m; i++) {
			cout << z[i] << ' ';
		}
		cout << endl;
		start = MPI_Wtime();
	}
	MPI_Bcast(&n, 1, MPI_INTEGER, 0, MPI_COMM_WORLD);
	MPI_Bcast(&m, 1, MPI_INTEGER, 0, MPI_COMM_WORLD);
	int* countsn = new int[proc_num];
	int* countsrn1 = new int[proc_num];
	double kn = (double)n * 2 / proc_num;
	int kn1 = (int)kn;
	double km = (double)m * 2 / proc_num;
	int km1 = (int)km;
	if (n * 2 % proc_num != 0)
		kn1 = n * 2 / proc_num + 1;
	if (m * 2 % proc_num != 0)
		km1 = m * 2 / proc_num + 1;
	for (int i = 0; i < proc_num; i++)
	{
		if (i % 2 == 0)
		{
			countsn[i] = 0;
			countsrn1[i] = 0;
		}
		else
		{
			countsn[i] = min((int)((n - kn1 * (i / 2))), (int)(kn1));
			countsrn1[i] = i / 2 * kn1;
		}
	}
	int* countsm = new int[proc_num];
	int* countsrm1 = new int[proc_num];
	for (int i = 0; i < proc_num; i++)
	{
		if (i % 2 != 0)
		{
			countsm[i] = 0;
			countsrm1[i] = 0;
		}
		else
		{
			countsm[i] = min((int)((n - km1 * (i / 2))), (int)(km1));
			countsrm1[i] = i / 2 * km1;
		}
	}

	int* x1 = new int[countsn[proc_rank]];
	int* y1 = new int[countsn[proc_rank]];
	int* z1 = new int[countsm[proc_rank]];
	MPI_Scatterv(x, countsn, countsrn1, MPI_INTEGER, x1, countsn[proc_rank], MPI_INTEGER, 0, MPI_COMM_WORLD);
	MPI_Scatterv(y, countsn, countsrn1, MPI_INTEGER, y1, countsn[proc_rank], MPI_INTEGER, 0, MPI_COMM_WORLD);
	MPI_Scatterv(z, countsm, countsrm1, MPI_INTEGER, z1, countsm[proc_rank], MPI_INTEGER, 0, MPI_COMM_WORLD);
	int Min = 1000000000, sum = 0;
	if (proc_rank % 2 == 0)
	{
		for (int i = 0; i < countsm[proc_rank]; i++) {
			Min = min(z1[i], Min);
		}
	}
	else
	{
		for (int i = 0; i < countsn[proc_rank]; i++) {
			sum += x1[i] * y1[i];
		}
	}
	int Min1, sum1;
	MPI_Reduce(&Min, &Min1, 1, MPI_INTEGER, MPI_MIN, 0, MPI_COMM_WORLD);
	MPI_Reduce(&sum, &sum1, 1, MPI_INTEGER, MPI_SUM, 0, MPI_COMM_WORLD);
	if (proc_rank == 0)
	{
		cout << "SUM = " << sum1 << endl;
		cout << "MIN = " << Min1 << endl;
		end = MPI_Wtime();
		diff = end - start;
		cout << diff << endl;
	}
	MPI_Finalize();
	delete[] x;
	delete[] x1;
	delete[] y1;
	delete[] z1;
	delete[] y;
	delete[] z;
}
