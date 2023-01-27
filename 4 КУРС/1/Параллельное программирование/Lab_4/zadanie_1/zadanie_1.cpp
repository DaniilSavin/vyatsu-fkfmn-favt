<<<<<<< HEAD
﻿#include <iostream>
#include <queue>
#include <thread>
#include <mutex>

using namespace std;

#define queueMaxSize 10
mutex mx;
queue <int> requests;

void SecondThread()
{
    while (true)
    {
        if (!requests.empty())
        {
            mx.lock();
            int request = requests.front();
            requests.pop();
            mx.unlock();
            this_thread::sleep_for(chrono::milliseconds(request));
            cout << "запрос " << request << " обработан" << endl;
        }
    }
}


int main()
{
    setlocale(0, "");
    thread thread_ = thread(SecondThread);
    thread_.detach();
    int n = 1;
    while (n > 0)
    {
        cout << ("введите заявку: ");
        try
        {
            cin >> n;
        }
        catch (const std::exception&)
        {
            continue;
        }
        if (requests.size() >= queueMaxSize)
        {
            cout << ("очередь переполнена. заявка не добавлена.") << endl;
            continue;
        }
        mx.lock();
        requests.push(n);
        cout << "заявка " << n << " добавлена." << endl;
        mx.unlock();

    }
    cin.get();
=======
﻿#include <iostream>
#include <queue>
#include <thread>
#include <mutex>

using namespace std;

#define queueMaxSize 10
mutex mx;
queue <int> requests;

void SecondThread()
{
    while (true)
    {
        if (!requests.empty())
        {
            mx.lock();
            int request = requests.front();
            requests.pop();
            mx.unlock();
            this_thread::sleep_for(chrono::milliseconds(request));
            cout << "запрос " << request << " обработан" << endl;
        }
    }
}


int main()
{
    setlocale(0, "");
    thread thread_ = thread(SecondThread);
    thread_.detach();
    int n = 1;
    while (n > 0)
    {
        cout << ("введите заявку: ");
        try
        {
            cin >> n;
        }
        catch (const std::exception&)
        {
            continue;
        }
        if (requests.size() >= queueMaxSize)
        {
            cout << ("очередь переполнена. заявка не добавлена.") << endl;
            continue;
        }
        mx.lock();
        requests.push(n);
        cout << "заявка " << n << " добавлена." << endl;
        mx.unlock();

    }
    cin.get();
>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
}