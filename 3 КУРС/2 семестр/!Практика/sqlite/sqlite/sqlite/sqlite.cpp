#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include "lib/sqlite3.h"
#include <string> 
#include "windows.h"
#include <iostream>
#include <fstream>


using namespace std;

sqlite3* db;
char* zErrMsg = 0;
int rc;
string text="";
const char* data1 = "Callback function called";

struct dataa
{
    string ind;
    string name;
    string meas_hash;
    string value;
    string meas_name;
    string date;
};

struct ns
{
    string ind;
    string name;
};

static int callback(void* data, int argc, char** argv, char** azColName)
{
    int i;
    setlocale(0, ".65001");
    string zxc;
    for (i = 0; i < argc; i++) {
        //printf("%s = %s\n", azColName[i], argv[i] ? argv[i] : "NULL");
        
        cout << azColName[i] << " = " << (argv[i] ? argv[i] : "NULL") << endl;
 
        text = text + azColName[i] + " = " + (argv[i] ? argv[i] : "NULL") + "\n";
    }
    printf("\n");
    setlocale(0, ".1251");
    return 0;
}

bool open_db(char name[])
{
    rc = sqlite3_open(name, &db);

    if (rc)
    {
        fprintf(stderr, "Can't open database: %s\n", sqlite3_errmsg(db));
        return false;
    }
    else
    {
        fprintf(stderr, "\nOpening the database successfully.\n");
        cout << "_____________________________________________________" << endl << endl << endl;
    }
    return true;
}

void insert_db() //вставка значений !не проверено!
{
    const int size = 1000;
    dataa input[size];
    ns inp[size];
    string sql;

    for (int i = 0; i < size && inp[i].ind!=""; i++)
    {
        sql = "INSERT INTO ns(ind, name)"\
            "VALUES('" + inp[i].ind + "', '" + inp[i].name + "')"\
            "INSERT INTO data (ind, meas_hash, value, meas_name, date)"\
            "VALUES ('" + input[i].ind + "', '" + input[i].meas_hash + "', '" + input[i].value + "', '" + input[i].meas_name + "', '" + input[i].date + "'); ";

        rc = sqlite3_exec(db, sql.c_str(), callback, (void*)data1, &zErrMsg);

        if (rc != SQLITE_OK) {
            fprintf(stderr, "SQL error: %s\n", zErrMsg);
            sqlite3_free(zErrMsg);
        }
        else {
            fprintf(stdout, "Records created successfully\n");
        }
    }
}

void display_valOfTable(string table) //выводит значения указанной таблицы
{
    string sql;
    string table_name = table;

    if (table_name != "")
    {
        sql = "SELECT * FROM " + table_name + ";";
    }
    else
    {
        while (table_name == "")
        {
            cout << "input table name: ";
            cin >> table_name;
        }
        sql = "SELECT * FROM " + table_name + ";";
    }

    rc = sqlite3_exec(db, sql.c_str(), callback, (void*)data1, &zErrMsg);

    if (rc != SQLITE_OK) {
        fprintf(stderr, "SQL error: %s\n", zErrMsg);
        sqlite3_free(zErrMsg);
    }
}

void display_tables() //выводит структуру всех таблиц
{
    string sql;
 
    sql = "select * from sqlite_master where type = 'table'";
    rc = sqlite3_exec(db, sql.c_str(), callback, (void*)data1, &zErrMsg);

    if (rc != SQLITE_OK) {
        fprintf(stderr, "SQL error: %s\n", zErrMsg);
        sqlite3_free(zErrMsg);
    }
   /*else {
        fprintf(stdout, "Records created successfully\n");
    }*/
}

void display_values_of_all_tables() //выводит все таблицы
{
    string sql;
    sql = "SELECT * FROM ns;";

    cout << "table ns: " << endl;
    rc = sqlite3_exec(db, sql.c_str(), callback, (void*)data1, &zErrMsg);
    cout << "table data: " << endl;
    sql = "SELECT * FROM data;";
    rc = sqlite3_exec(db, sql.c_str(), callback, (void*)data1, &zErrMsg);
    if (rc != SQLITE_OK) {
        fprintf(stderr, "SQL error: %s\n", zErrMsg);
        sqlite3_free(zErrMsg);
    }

}

void update_db() //обновление указанной таблицы
{
    string sql; string req = "";  string v = ""; string wh = ""; string table = ""; string whv = "";

    display_values_of_all_tables();

    while (table == "")
    {
        cout << "Введите название таблицы, в которой хотите изменить значение: " << endl;
        cin >> table;
    }
    while (req == "")
    {
        cout << "Введите название переменной, значение которой хотите изменить: " << endl;
        cin >> req;
    }
    while (v == "")
    {
        cout << "Введите значение переменной, которое хотите записать: " << endl;
        cin >> v;
    }
    while (wh == "")
    {
        cout << "Введите название переменной, по которому можно найти изменяемую переменную: " << endl;
        cin >> wh;
    }
    while (whv == "")
    {
        cout << "Введите значение этой переменной: " << endl;
        cin >> whv;
    }

    {
        sql = "update "+ table+" set " + req +"="+ v+" where "+wh+" = '"+whv+"'; ";
       
        rc = sqlite3_exec(db, sql.c_str(), callback, (void*)data1, &zErrMsg);

        if (rc != SQLITE_OK) {
            fprintf(stderr, "SQL error: %s\n", zErrMsg);
            sqlite3_free(zErrMsg);
        }
        else {
            fprintf(stdout, "\nUpdate successfully\n");
        }
        display_values_of_all_tables();
    }
}

void pragma()
{
    rc = sqlite3_exec(db, "pragma foreign_keys=ON", callback, (void*)data1, &zErrMsg);
    if (rc != SQLITE_OK)
    {
        fprintf(stderr, "SQL error: %s\n", zErrMsg);
        sqlite3_free(zErrMsg);
    }
}

void close_db()
{
    rc = sqlite3_close(db);
    if (rc != SQLITE_OK)
    {
        fprintf(stderr, "SQL error: %s\n", zErrMsg);
        sqlite3_free(zErrMsg);
    }
    else
    {
        cout << "_____________________________________________________" << endl;
        cout << "Closing the database successfully." << endl;
    }
}


void saveToFile(string name)
{
    //setlocale(0, ".65001");
    std::ofstream out;          // поток для записи
    out.open(name); // окрываем файл для записи
    if (out.is_open())
    {
        out << text;
    }

    std::cout << "End of program" << std::endl;
    
}


int main()
{
    setlocale(LC_ALL, "rus");
    string sql;
    char name[] = "wd.db"; //название бд
    int intro = -1;
    string table_name = "";

    string menu = "\n\t\t\t\tМеню: "\
        "\n\t|\t1 - Вывод на экран названия БД.                \t|"\
        "\n\t|\t2 - Вывод на экран БД.                         \t|"\
        "\n\t|\t3 - Вывод на экран структуры таблиц из БД.     \t|"\
        "\n\t|\t4 - Вывод на экран определенной таблицы из БД. \t|"\
        "\n\t|\t5 - Изменить название БД.                      \t|"\
        "\n\t|\t6 - Обновление данных БД.                      \t|"\
        "\n\t|\t7 - Добавление данных в БД.                    \t|"\
        "\n\t|\t8 - Сохранение значений таблицы в файл.        \t|"\
        "\n\t|\t0 - Выход.                                     \t|"\
        ;

    while (intro!=0)
    {
        system("cls");
        cout << menu << endl << ">> ";
        cin >> intro;

        switch (intro)
        {
        case 1:
            system("cls");
            cout << "\n\t " << name << endl;
            system("pause");
            break;
        case 2:
            system("cls");
            if (open_db(name))
            {
                pragma();
                display_values_of_all_tables();               
                close_db();
            }
            else
            {
                cout << "Ошибка открытия." << endl;
            }
            system("pause");
            break;
        case 3:
            system("cls");
            if (open_db(name))
            {
                pragma();
                display_tables();
                close_db();
            }
            else
            {
                cout << "Ошибка открытия." << endl;
            }
            system("pause");
            break;
        case 4:
            system("cls");
            if (open_db(name))
            {
                pragma();
                cout << "Введите название таблицы: \n>> ";
                cin >> table_name;
                display_valOfTable(table_name);
                close_db();
            }
            else
            {
                cout << "Ошибка открытия." << endl;
            }
            system("pause");
            break;
        case 5:
            system("cls");
            cout << "Введите новое название БД (не переименовывает БД):\n>> ";
            cin >> name;
            system("pause");
            break;
        case 6:
            system("cls");
            if (open_db(name))
            {
                pragma();
                update_db();
                close_db();
            }
            else
            {
                cout << "Ошибка открытия." << endl;
            }
            system("pause");
            break;
        case 7:
            system("cls");
            if (open_db(name))
            {
                pragma();
                insert_db();
                close_db();
            }
            else
            {
                cout << "Ошибка открытия." << endl;
            }
            system("pause");
            break;
        case 8:
            system("cls");
            if (open_db(name))
            {
                pragma();
                display_values_of_all_tables();
                close_db();
            }
            else
            {
                cout << "Ошибка открытия." << endl;
            }
            saveToFile("print.pdf");
            
            
            //system("print print.txt");

            system("pause");
            break;
        case 0:
            break;
        }
    }

    return 0;
}


