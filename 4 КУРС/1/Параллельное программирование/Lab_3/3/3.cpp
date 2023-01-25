#include <iostream>
#include <thread>
#include <vector>
#include <mutex>

using namespace std;

int counT = 0;

void foo(int cnt, std::mutex& mx)
{
    std::cout << "Thread start, index= " << cnt << " counT= " << counT << std::endl;
    //std::this_thread::sleep_for(std::chrono::milliseconds(rand() % 1000));
    std::lock_guard<std::mutex> lgmx(mx);
    if (counT < 100)
    {
        counT += cnt;
    }
    else
    {
        cout << "counT > 100 | counT= " << counT << endl;
    }
    std::cout << "Thread finish! counT= "<< counT << std::endl;
    return;
}

int main()
{
    int P = 0;
    while (P < 1 || P > 10)
    {
        std::cout << "Input P: ";
        std::cin >> P;
    }
    vector <thread> Thr;
    std::mutex mx;   
    while (counT < 100)
    {
        for (int i = 0; i < P; i++)
        {
            
            Thr.push_back(thread(foo, i, ref(mx)));
            Thr[i].join();
            if (counT >= 100)
            {
                break;
            }
        }
        std::unique_lock<std::mutex> ulmx(mx);
        ulmx.unlock();
        Thr.clear();
        
    }
}