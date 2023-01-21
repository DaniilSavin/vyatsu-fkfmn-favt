#include "iostream"
#include "stdlib.h"
#include <string> 
 
using namespace std;
 
string qweqwe123123(unsigned int n)
{
    string result = "";
    bool first1 = false;
    for (long long int i = 31; i >= 0; i--)
    {
        if ((1 << i) & n)
        {
            result += "1";
            first1 = true;
        }
        else
        {
            if (first1)
            result += "0";
        }
    }
    int i = 0;
    return result;
}
 
int main()
{
    int n, k;
    cin >> n >> k;
    int count = 0;
    for (int i = 1; i <= n; i++)
    {
        string str = qweqwe123123(i);
        int counter = 0;
        //cout << str;
        for (int g = 0; g < str.length(); g++)
        {
            if (str[g] == '0') counter++;
        }
        if (counter == k)
        {
            count++;
            //cout << " <<" << endl;
        } //else cout<< endl;
    }
    cout << count;
    //system("pause");
    return 0;
}