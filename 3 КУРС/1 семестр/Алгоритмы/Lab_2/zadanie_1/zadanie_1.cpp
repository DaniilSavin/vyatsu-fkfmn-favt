// zadanie_1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//
#include <string>
#include <iostream>
using namespace std;

int main()
{
    string str0 = "asdasdasdasdasd";
    string str = "sdasdasda";
    int k = 1;
    for (int i = 0; i < str.length()/2; i++)
    {
        if (str[i] == str[i + k])
        {
            
            cout << "OTBET: k= " << k;
            break;
        }
        else
        {
            k++;
            i = 0;
        }
    }
}

