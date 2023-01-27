// GradientC++.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <cmath>
#include <vector>
#include <algorithm>
#include <functional>
//#include <fstream>
//#include <ostream>

#define METHOD (1)
//выбор метода определения длины шага
//1 - метод градиентного спуска с постоянным шагом
//2 - Градиентный метод с дроблением шага
//3 - Метод наискорейшего спуска

//константа для метода градиентного спуска с постоянным шагом
//начальное значение eps для метода с дроблением шага
#define LAMBDA_CONSTANT (0.01)

//параметры для метода с дроблением шага
#define DELTA_FOR_METHOD2 (0.95)
#define EPS_FOR_METHOD2 (0.0001)

//максимально возможное число итераций
#define NUMBER_OF_ITERATIONS (100000)

//eps для критерия останова
#define EPS (0.000001) //0.9 0.07 0.6

//критерий останова
#define OSTANOV (2)

using namespace std;

double f(vector<double> x);
//ofstream o;



double f(vector<double> x)
//функция минимум которой ищут
{
	return 9 * x[0] * x[0] - 9 * x[0] - 6 * x[0] * x[1] + 4 * x[1] * x[1] - 6 * x[1];
}

vector<double> GradientF(vector<double> x)
//градиент исследуемой функции
{
	vector<double> tmp;
	tmp.push_back(18 * x[0] - 6 * x[1] - 9);
	tmp.push_back(-6 * x[0] + 8 * x[1] - 6);
	return tmp;
}


vector<double> GradientDescent(vector<double> x0, int& Iterations)
//minimizes N-dimensional function f; x0 - start point
{
	vector <double> old, cur_x = x0, gr;
	double s, Lambda;
	int j, i;

	Lambda = LAMBDA_CONSTANT;

	for (Iterations = 1; Iterations <= NUMBER_OF_ITERATIONS; Iterations++)
	{

		//save old value
		old = cur_x;
		//compute gradient
		gr = GradientF(cur_x);

		Lambda = LAMBDA_CONSTANT;
		//вычисляем новое значение
		for (j = 0; j < old.size(); j++)
			cur_x[j] = cur_x[j] - Lambda * gr[j];



		//o<<cur_x[0]<<","<<cur_x[1]<<","<<f(cur_x)<<"\n";
		if (OSTANOV == 1)
		{
			//условие останова 1
			s = 0;
			for (j = 0; j < old.size(); j++)
				s += (old[j] - cur_x[j]) * (old[j] - cur_x[j]);
			s = sqrt(s);
			if (s < EPS)
				return cur_x;
		}

		if (OSTANOV == 2)
		{
			//условие останова 2
			s = fabs(f(cur_x) - f(old));
			if (s < EPS)
				return	cur_x;
		}

	}

	return cur_x;
}

int main()
{
	vector<double> x;
	x.push_back(2);
	x.push_back(4);
	int i, Iteration;
	// o.open("grad.txt");
	vector<double> ans = GradientDescent(x, Iteration);
	cout << "Value: " << f(ans) << endl;
	cout << "Point: ";
	for (i = 0; i < ans.size(); i++)
		cout << ans[i] << ' ';
	cout << endl << "Number of iterations:" << Iteration << endl;
	//o.close();
	return 0;
}
