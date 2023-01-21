#include <iostream>
#include <stdlib.h>
#include <conio.h>

using namespace std;

    class B {
        int a;
    public:
        B() { };
        B(int x) { a = x; }
        void show_B() { cout << "B=   " << a << "\n"; }
    };

    class D1 : private B {
        int b;
    public:
        D1(int x, int y) : B(y) { b = x; };
        void show_D1() { cout << "D1=  " << b << "\n"; show_B(); }
    };

    class D2 : private B {
        int c;
    public:
        D2(int x, int y) : B(y) { c = x; };
        void show_D2() { cout << "D2=  " << c << "\n"; show_B(); }
    };

    class D3 : private B {
        int d;
    public:
        D3(int x, int y) : B(y) { d = x; };
        void show_D3() { cout << "D3=  " << d << "\n"; show_B(); }
    };

    class D4 : private D1, public D2  {
        int e;
    public:
        D4(int x, int y, int z, int i, int j) : D1(y, z), D2(i, j) { e = x; }
        void show_D4() { cout << "D4=  " << e << "\n"; show_D1(); show_D2(); }
    };

    class D5 : public D2, private D3 {
        int f;
    public:
        D5(int x, int y, int z, int i, int j) : D2(y, z), D3(i, j) { f = x; }
        void show_D5() { cout << "D5=  " << f << "\n"; show_D2(); show_D3();  }
    };

    int main()
    {
        setlocale(LC_ALL, "rus");
        D4 temp(1, 2, 3, 4, 5);
        D5 temp1(100, 200, 300, 400, 500);

        cout << "D4 temp(1,2,3,4,5);\n";
        cout << "D5 temp1(100,200,300,400,500);\n";
        cout << "\nСледуя иерархии класса D4: \n";
        temp.show_D4();
        cout << "\nСледуя иерархии класса D5\n";
        temp1.show_D5();
        _getch();
        return 0;
    }

