// zadanie_1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <array>
#include <algorithm>

using namespace std;

int main()
{
    int* arr = new int[10];
    for (int i=0; i<size.arr)
}

int find(int arr[], int value)
{

    


    if (arr.length() size != 0)
    {
        int last = arr[size - 1];//Сохраним прежний элемент массива
        arr[size - 1] = value;//Гарантируем, что value есть в массиве
        //Есть гарантия того, что элемент есть в массиве, значит индекс можно не проверять
        size_t i = 0;
        for (i = 0; arr[i] != value; ++i)
        {
            //Одно условие в цикле
        }
        arr[size - 1] = last;//Восстанавливаем последний элемент
        if (i != (size - 1) || value == last)
        {//Не уткнулись в барьер или последний элемент был искомым
            return i;
        }
    }
}