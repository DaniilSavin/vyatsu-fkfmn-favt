
#include <iostream>
#include <vector>
#include <string>
#include <algorithm>
#include <ctime>
#include <fstream>
#include <mutex>

using namespace std;

constexpr int base = 10;
// lenght of the long number for which naive multiplication
// will be called in the Karatsuba function
constexpr unsigned int len_f_naive = 32;
// One digit size for numbers with bases multiple of ten
constexpr int dig_size = 10;


vector<long long> naive_mul(const vector<long long>& x, const vector<long long>& y)
{
    auto len = x.size();
    vector<long long> res(2 * len);

    for (auto i = 0; i < len; ++i) {
        for (auto j = 0; j < len; ++j) {
            res[i + j] += x[i] * y[j];
        }
    }

    return res;
}


vector<long long> karatsuba_mul(const vector<long long>& x, const vector<long long>& y)
{
    auto len = x.size();
    vector<long long> res(2 * len);

    if (len <= len_f_naive)
        return naive_mul(x, y);

    auto k = len / 2;

    vector<long long> Xr{ x.begin(), x.begin() + k };
    vector<long long> Xl{ x.begin() + k, x.end() };
    vector<long long> Yr{ y.begin(), y.begin() + k };
    vector<long long> Yl{ y.begin() + k, y.end() };

    vector<long long> P1 = karatsuba_mul(Xl, Yl);
    vector<long long> P2 = karatsuba_mul(Xr, Yr);

    vector<long long> Xlr(k);
    vector<long long> Ylr(k);

    for (auto i = 0; i < k; ++i)
    {
        Xlr[i] = Xl[i] + Xr[i];
        Ylr[i] = Yl[i] + Yr[i];
    }

    vector<long long> P3 = karatsuba_mul(Xlr, Ylr);

    for (auto i = 0; i < len; ++i)
        P3[i] -= P2[i] + P1[i];

    for (auto i = 0; i < len; ++i)
        res[i] = P2[i];

    for (auto i = len; i < 2 * len; ++i)
        res[i] = P1[i - len];

    for (auto i = k; i < len + k; ++i)
        res[i] += P3[i - k];

    return res;
}


vector<long long> get_number(string& is)
{
    string snum;
    vector<long long> vnum;
    unsigned int dig = 1;
    int n = 0;

    snum = is;

    for (auto it = snum.crbegin(); it != snum.crend(); ++it) {
        n += (*it - '0') * dig;
        dig *= dig_size;

        if (dig == base) {
            vnum.push_back(n);
            n = 0;
            dig = 1;
        }
    }

    if (n != 0) {
        vnum.push_back(n);
    }

    return vnum;
}


void extend_vec(vector<long long>& v, size_t len)
{
    while (len & (len - 1)) {
        ++len;
    }
    v.resize(len);
}


void finalize(vector<long long>& res)
{
    for (auto i = 0; i < res.size() - 1; ++i)
    {
        res[i + 1] += res[i] / base;
        res[i] %= base;
    }
}


void addition(vector<long long>& first, vector<long long>& second)
{
    int carry = 0;
    for (auto i = 0; i < max(first.size(), second.size()) || carry; ++i) {
        if (i == first.size())
            first.push_back(0);
        first[i] += carry + (i < second.size() ? second[i] : 0);
        carry = first[i] >= base;
        if (carry)  first[i] -= base;
    }
}


void subtraction(vector<long long>& first, vector<long long>& second)
{
    int carry = 0;
    for (auto i = 0; i < second.size() || carry; ++i) {
        first[i] -= carry + (i < second.size() ? second[i] : 0);
        carry = first[i] < 0;
        if (carry)  first[i] += base;
    }
}


int what_a_sign(vector<long long>& first, vector<long long>& second)
{
    int k = 3;
    long long First_Size = first.size();
    long long Second_Size = second.size();
    long long length = First_Size;
    if (First_Size > Second_Size)
    {
        length = First_Size;
        k = 1;
    }
    else
        if (Second_Size > First_Size)
        {
            length = Second_Size;
            k = 2;
        }
        else
            for (int i = length - 1; i >= 0; i--)
            {
                if (first[i] > second[i])
                {
                    k = 1;
                    break;
                }

                if (second[i] > first[i])
                {
                    k = 2;
                    break;
                }
            }
    return k;
}


void what_a_flag(string& ss, string& str, long long& i, vector<bool>& signs)
{
    if (ss[0] == '-')
    {
        ss.erase(0, 1);
        str.erase(0, 1);
        i++;
        signs.push_back(false);
    }
    else signs.push_back(true);
}


void thread_work(int i, long long Second_Coeffs_Size, vector<long long> First_Coeffs, vector<vector<long long>> Second_Coeffs,
    bool Broker_flag, vector<bool>& First_Signs, vector<bool>& Second_Signs, vector<bool>& Final_Signs, vector<vector <long long>>& Final, vector<mutex>& Mutexes)
{
    //this_thread::sleep_for(chrono::seconds(10));
    for (int j = 0; j < Second_Coeffs_Size; j++)
    {
        Mutexes[i + j].lock();
        auto n = max(First_Coeffs.size(), Second_Coeffs[j].size());

        extend_vec(First_Coeffs, n);
        extend_vec(Second_Coeffs[j], n);

        vector <long long> Broker = karatsuba_mul(First_Coeffs, Second_Coeffs[j]);

        if (First_Signs[i] == Second_Signs[j])
            Broker_flag = true;
        else Broker_flag = false;

        finalize(Broker);

        while (Broker.size() > 1 && Broker.back() == 0)
            Broker.pop_back();


        if (Broker_flag == Final_Signs[i + j])
            addition(Final[i + j], Broker);
        else
        {
            switch (what_a_sign(Final[i + j], Broker))
            {
            case 1:
            {
                subtraction(Final[i + j], Broker);
                break;
            }
            case 2:
            {
                subtraction(Broker, Final[i + j]);
                Final[i + j] = Broker;
                Final_Signs[i + j] = Broker_flag;
                break;
            }
            case 3:
            {
                subtraction(Final[i + j], Broker);
                Final_Signs[i + j] = true;
                break;
            }
            }
        }

        while (Final[i + j].size() > 1 && Final[i + j].back() == 0)
            Final[i + j].pop_back();
        Mutexes[i + j].unlock();
    }
}


void tests(string path, string pathout)
{
    clock_t start;
    double duration;
    vector<vector<long long>> First_Coeffs;
    vector<bool> First_Signs;
    vector<vector<long long>> Second_Coeffs;
    vector<bool> Second_Signs;
    vector <long long> Broken_Number;

    bool flag = true;
    string str;
    ifstream ifs(path);
    getline(ifs, str);
    long long Size = str.length(), i = 0;

    while (i < Size)
    {
        string ss(str.begin(), find(str.begin(), str.end(), ' '));

        if (flag) what_a_flag(ss, str, i, First_Signs);
        else what_a_flag(ss, str, i, Second_Signs);

        Broken_Number = get_number(ss);

        str.erase(0, ss.length() + 1);
        i += ss.length() + static_cast <unsigned __int64>(1);

        if (flag)
            First_Coeffs.push_back(Broken_Number);
        else Second_Coeffs.push_back(Broken_Number);

        if ((i > Size) && (flag))
        {
            i = 0;
            getline(ifs, str);
            Size = str.length();
            flag = false;
        }
    }

    ifs.close();

    long long First_Coeffs_Size = First_Coeffs.size();
    long long Second_Coeffs_Size = Second_Coeffs.size();
    long long Final_Size = First_Coeffs_Size + Second_Coeffs_Size - 1;

    vector<vector <long long>> Final(Final_Size);
    vector<bool> Final_Signs(First_Coeffs_Size + Second_Coeffs_Size - 1, true);

    bool Broker_flag = true;

    vector<thread> Threads(First_Coeffs_Size);
    vector<mutex> Mutexes(Final_Size);

    start = clock();

    for (int i = 0; i < First_Coeffs_Size; i++)
    {
        Threads[i] = thread(thread_work, i, Second_Coeffs_Size, First_Coeffs[i], Second_Coeffs,
            Broker_flag, ref(First_Signs), ref(Second_Signs), ref(Final_Signs), ref(Final), ref(Mutexes));
    }

    for (int i = 0; i < First_Coeffs_Size; i++)
        Threads[i].join();

    ofstream ofs(pathout);

    for (int i = 0; i < Final_Size; i++)
    {
        ofs << "x^" << i << " * ";
        if (Final_Signs[i] == false)
            ofs << "-";
        for (int j = Final[i].size() - 1; j >= 0; j--)
        {
            ofs << Final[i][j];
        }
        ofs << endl;
    }
    ofs.close();

    duration = (static_cast<unsigned __int64>(clock()) - start) / (double)CLOCKS_PER_SEC;
    cout << "Время выполнения: [" << duration << "] секунд(ы)" << '\n';
}


int main()
{
    setlocale(LC_ALL, "ru");
    string pathtest("c:/tests/test");
    string pathout("c:/tests/outs/out");
    for (int i = 0; i < 10; i++)
    {
        cout << "Тест №" << i << " в процессе выполнения..." << endl;
        tests(pathtest + to_string(i) + ".txt", pathout + to_string(i) + ".txt");
        cout << "_______________________________________________" << endl;
    }
}