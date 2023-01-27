// zadanie_2.cpp : Этот файл содержит функцию "main". Здесь начинается и заканчивается выполнение программы.
//

#include <iostream>
#include <vector>
using namespace std;
string P = "abac";

int max(vector<int> pi)
{
    int max = pi[0];
    for (int i = 0; i < pi.size(); i++)
    {
        if (max < pi[i]) max = pi[i];
    }

    return max;
}
void prefix_function(string s)
{
    int n = s.length();
    vector<int> pi(n);
    string S="";
    int k; int maxx;
    for (int j = 0; j < P.length(); j++)
    {
        
        for (int i = 0; i < j; i++)
        {
            
            int j = pi[i];
            while ((j > 0) && (s[i] != s[j]))
                j = pi[j - 1];
            if (s[i] == s[j])
                j++;
            pi[i] = j;
            maxx = max(pi);
        }
        k = S.length() + 1 - maxx;
        S += P[j];
        
    }
    
    cout << k << endl;
}

int main()
{
    prefix_function(P);
}


