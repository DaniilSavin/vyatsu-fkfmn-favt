// zadanie_2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
using namespace std;

int a(string str, string subStr)
{
    int pos = -1;
    for (int i = 0; i < str.length() - subStr.length() + 1 && pos == -1; i++)
    {
        bool flag = true;
        int tmpIndex = i;
        for (int j = 0; j < subStr.length() && flag; j++)
        {
            if (!(str[tmpIndex] == subStr[j]))
            {
                flag = false;
            }
            tmpIndex++;
        }
        if (flag) pos = i;
    }
    return pos;
}

int main()
{
    string str = "ababaabca";
    string subStr = "abc";
    cout << a(str, subStr) << endl;


}

