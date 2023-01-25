// zadanie_2015.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
using namespace std;
int main()
{
	long int Jenyas_kash,
		advantages_live_1,
		advantages_live_2,
		friends_count,
		flat_count,
		friedn_kash[256],
		advantages_live_friend[256],
		room_count[256],
		rent_cost[256],
		flat_advantages[256];

	cin >> Jenyas_kash >> advantages_live_1 >> advantages_live_2 >> friends_count;
	for (int i = 0; i < friends_count; i++)
	{
		cin >> friedn_kash[i] >> advantages_live_friend[i];
	}

	cin >> flat_count;

	for (int i = 0; i < flat_count; i++)
	{
		cin >> room_count[i] >> rent_cost[i] >> flat_advantages[i];
	}

	long int max = -1, nh = 0, nd = 0;

	for (int i = 0; i < flat_count; i++)
		if (room_count[i] == 1) {
			if (rent_cost[i] <= Jenyas_kash && (advantages_live_1 + flat_advantages[i] > max)) 
			{
				max = advantages_live_1 + flat_advantages[i];
				nh = i + 1;
				nd = 0;
			}
		}
		else {
			if (rent_cost[i] <= Jenyas_kash && (advantages_live_2 + flat_advantages[i] > max)) 
			{
				max = advantages_live_2 + flat_advantages[i];
				nh = i + 1;
				nd = 0;
			}
			for (int j = 0; j < friends_count; j++)
				if (rent_cost[i] <= int(double(Jenyas_kash) / 2.0 + double(friedn_kash[j]) / 2.0) && (flat_advantages[i] + advantages_live_friend[j] > max))
				{
					max = flat_advantages[i] + advantages_live_friend[j];
					nh = i + 1;
					nd = j + 1;
				}
		}

	if (nd == 0)
	{
		if (nh == 0)
			cout << "Forget about apartments. Live in the dormitory." << endl;
		else
			cout << "You should rent the apartment #" << nh << " alone." << endl;
	}
	else
		cout << "You should rent the apartment #" << nh
		<< " with the friend #" << nd << "."
		<< endl;

	return 0;
}
