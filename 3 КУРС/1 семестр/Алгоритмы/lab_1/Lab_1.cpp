// Lab_1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//
#include <string>
#include <iostream>
using namespace std;

int main()
{
    string str = "asddsaasd";
    string substr = "dsa";
    int n = 0;
    for (int i = 0; i < str.length() - substr.length(); i++)
    {
        for (int j = 0; j < substr.length(); j++)
        {
            if (str[i] == substr[j] && str[i + 1] == substr[j + 1])
            {
              cout << i; 
              return 0;
            }
            else
            {
                i++; j--;
            }
        }
        
    }
}

