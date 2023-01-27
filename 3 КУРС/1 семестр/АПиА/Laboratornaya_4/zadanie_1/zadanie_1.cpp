// zadanie_1.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <vector>
using namespace std;

string S="asdabcasdabc";
string P="abc";
void prefix_function(string s);

int main()
{
    setlocale(LC_ALL, "rus");
    string T = P + "$" + S;
    cout << T << endl;
    prefix_function(T);
}

void prefix_function(string s)
{
    int n = s.length();
    vector<int> pi(n);  
            
    for (int i = 1; i < n; i++)
    {
        int j = pi[i - 1];
        while ((j > 0) && (s[i] != s[j]))
            j = pi[j - 1];
        if (s[i] == s[j])
            j++;
        pi[i] = j;
    }
    for (int i = 0; i < n; i++)
    {
        cout << pi[i] << " ";
    }
    cout << "\nПервое вхождение: " << endl;
    bool fl = false;
    for (int i = 0; i < n; i++)
    {
        if (pi[i] == P.length() && fl==false)
        {
            cout << "Строка " << P << " входит в " << S << " c позиции " << i - P.length()*2 << endl;
            fl = true;
        }
    }
    fl = false;
    cout << "\nПоследнее вхождение: " << endl;
    for (int i = n-1; i > 0; i--)
    {
        if (pi[i] == P.length() && fl == false)
        {
            cout << "Строка " << P << " входит в " << S << " c позиции " << i - P.length() * 2 << endl;
            fl = true;
        }
    }
    cout << "\nВсе вхождения: " << endl;
    for (int i = 0; i < n; i++)
    {
        if (pi[i] == P.length())
        {
            cout << "Строка " << P << " входит в " << S << " c позиции " << i - P.length() * 2 << endl;

        }
    }
}
