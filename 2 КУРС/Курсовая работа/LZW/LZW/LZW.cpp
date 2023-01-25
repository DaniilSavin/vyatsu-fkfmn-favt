#define _CRT_SECURE_NO_WARNINGS
#include "iostream"
#include <io.h>
#include <fcntl.h>
#include <sys/stat.h>
#include <ctime>
#include <fstream>
#include <cstdlib>
#include <string>

using namespace std;

#define BITS 12                      //Установка длины кода равной 12, 13, 14
#define HASHING_SHIFT BITS-8         
#define MAX_VALUE (1 << BITS) - 1    
#define MAX_CODE MAX_VALUE - 1       

#if BITS == 14
#define TABLE_SIZE 18041             // Размер таблицы строк должен быть    
#endif                               // простым числом, несколько большим,   
#if BITS == 13                       // чем 2*BITS.                        
#define TABLE_SIZE 9029
#endif
#if BITS <= 12
#define TABLE_SIZE 5021
#endif

int* code_value;                  // Это массив для значений кодов
unsigned int* prefix_code;        // Этот массив содержит префиксы кодов
unsigned char* append_character;  // Этот массив содержит добавочные символы
unsigned char decode_stack[4000]; // Этот массив содержит декодируемые строки


void decode(FILE* input, FILE* output);
void compress(FILE* input, FILE* output);
int find_match(int hash_prefix, unsigned int hash_character);
unsigned char* decode_string(unsigned char* buffer, unsigned int code);
int input_code(FILE* input);
void output_code(FILE* output, unsigned int code);


void compress(FILE* input, FILE* output) // Процедура сжатия.
{
    unsigned int next_code;
    unsigned int character;
    unsigned int string_code;
    unsigned int index;
    int i;
    next_code = 256;         // Next_code - следующий доступный код строки 
    for (i = 0; i < TABLE_SIZE; i++) // Очистка таблицы строк перед стартом   
        code_value[i] = -1;
    i = 0;

    string_code = getc(input);


    // Основной цикл. Он выполняется до тех пор, пока возможно чтение
    // входного потока.  Отметим, что он прекращает заполнение таблицы
    // строк после того, как все возможные коды были использованы.

    while ((character = getc(input)) != (unsigned)EOF)
    {
        index = find_match(string_code, character); // Смотрит, есть ли строка 
        if (code_value[index] != -1)                // в таблице.  Если есть,  
            string_code = code_value[index];        // получает значение кода. 
        else                                        // Если нет, добавляет ее  
        {                                           // в таблицу.              
            if (next_code <= MAX_CODE)
            {
                code_value[index] = next_code++;
                prefix_code[index] = string_code;
                append_character[index] = character;
            }
            output_code(output, string_code); // Когда обнаруживается, что  строки нет в таблице,выводится последняя строка перед добавлением новой
            string_code = character;          // 
        }                                     //  
    }                                         //     


    output_code(output, string_code);  // Вывод последнего кода
    output_code(output, MAX_VALUE);    // Вывод признака конца потока
    output_code(output, 0);            // Очистка буфера вывода
    printf("\n");
}

// Процедура хэширования.  Она пытается найти сопоставление для строки
// префикс+символ в таблице строк. Если найдено, возвращается индекс.
// Если нет, то возвращается первый доступный индекс.

int find_match(int hash_prefix, unsigned int hash_character)
{
    int index;
    int offset;

    index = (hash_character << HASHING_SHIFT) ^ hash_prefix;
    if (index == 0)
        offset = 1;
    else
        offset = TABLE_SIZE - index;
    while (1)
    {
        if (code_value[index] == -1)
            return(index);
        if (prefix_code[index] == hash_prefix && append_character[index] == hash_character)
            return(index);
        index -= offset;
        if (index < 0)
            index += TABLE_SIZE;
    }
}


// Процедура распаковки.

void decode(FILE* input, FILE* output)
{
    unsigned int next_code;
    unsigned int new_code;
    unsigned int old_code;
    int character;
    int counter;
    unsigned char* stringg;

    next_code = 256;            // Следующий доступный код.
    counter = 0;                // Используется при выводе на экран.


    old_code = input_code(input); // Читается первый код, инициализируется 
    character = old_code;         // переменная character и посылается первый 
    putc(old_code, output);       // код в выходной файл.

  // Основной цикл распаковки.  Читаются коды из файла до тех пор,
  // пока не встретится специальный код, указывающий на конец данных.

    while ((new_code = input_code(input)) != (MAX_VALUE))
    {

        // Проверка кода для специального случая STRING+CHARACTER+STRING+CHARACTER+
        // STRING, когда генерируется неопределенный код. Это заставляет его
        // декодировать последний код, добавив CHARACTER в конец декод. строки.

        if (new_code >= next_code)
        {
            *decode_stack = character;
            stringg = decode_string(decode_stack + 1, old_code);
        }

        // Иначе декодируется новый код.

        else
            stringg = decode_string(decode_stack, new_code);

        // Выводится декодируемая строка в обратном порядке.

        character = *stringg;
        while ((unsigned char*)stringg >= decode_stack)
            putc(*stringg--, output);

        // Наконец, если возможно, добавляется новый код в таблицу строк.

        if (next_code <= MAX_CODE)
        {
            prefix_code[next_code] = old_code;
            append_character[next_code] = character;
            next_code++;
        }
        old_code = new_code;
    }
    cout << endl;
}


// Процедура простого декодирования строки из таблицы строк, сохраняющая
// результат в буфер.  Этот буфер потом может быть выведен в обратном
// порядке программой распаковки.

unsigned char* decode_string(unsigned char* buffer, unsigned int code)
{
    int i;
    i = 0;
    while (code > 255)
    {
        *buffer++ = append_character[code];
        code = prefix_code[code];
        if (i++ >= 4094)
        {
            cout << "Fatal error during code expansion." << endl;
            exit(0);
        }
    }
    *buffer = code;
    return buffer;
}

// Следующие две процедуры управляют вводом/выводом кодов переменной длины.

int input_code(FILE* input)
{
    unsigned int return_value;
    static int input_bit_count = 0;
    static unsigned long input_bit_buffer = 0L;
    while (input_bit_count <= 24)
    {
        input_bit_buffer |= (unsigned long)getc(input) << (24 - input_bit_count);
        input_bit_count += 8;
    }
    return_value = input_bit_buffer >> (32 - BITS);
    input_bit_buffer <<= BITS;
    input_bit_count -= BITS;
    return(return_value);
}

void output_code(FILE* output, unsigned int code)
{
    static int output_bit_count = 0;
    static unsigned long output_bit_buffer = 0L;
    output_bit_buffer |= (unsigned long)code << (32 - BITS - output_bit_count);
    output_bit_count += BITS;
    while (output_bit_count >= 8)
    {
        putc(output_bit_buffer >> 24, output);
        output_bit_buffer <<= 8;
        output_bit_count -= 8;
    }
}

int main()
{
    setlocale(LC_ALL, "rus");
    FILE* input_file;
    FILE* output_file;
    char input_filename[100];
    char output_filename[100] = "out.lzw";
    cout << "Введите название файла:" << endl << "> ";
    cin >> input_filename;
    fstream file(input_filename);
    int size = 0;
    file.seekg(0, std::ios::end);
    size = file.tellg();
    file.close();
    double size1 = (double)size / 1048576;

    // Эти три буфера необходимы на стадии упаковки.
    code_value = (int*)malloc(TABLE_SIZE * sizeof(unsigned int));
    prefix_code = (unsigned int*)malloc(TABLE_SIZE * sizeof(unsigned int));
    append_character = (unsigned char*)malloc(TABLE_SIZE * sizeof(unsigned char));
    if (code_value == NULL || prefix_code == NULL || append_character == NULL)
    {
        cout << "Fatal error allocating table space!" << endl;
        exit(0);
    }



    string intro = R"(Введите режим работы:
e - сжатие
d - распаковка)";

    cout << intro << endl << "\n>";

    string tmp;
    cin >> tmp;
    system("cls");
    if (tmp == "d")
    {
        cout << "Введите старое название файла:" << endl << "> ";
        cin >> output_filename;
    }
    input_file = fopen(input_filename, "rb");
    output_file = fopen(output_filename, "wb");
    if (input_file == NULL || output_file == NULL)
    {
        printf("Fatal error opening files.\n");
        exit(0);
    }
    unsigned int start = clock();
    if (tmp == "e") //compress
    {
        compress(input_file, output_file);
        fclose(input_file);
        fclose(output_file);
        free(code_value);
    }
    else
    {
        if (tmp == "d")//decompress
        {
            input_file = fopen(input_filename, "rb");
            output_file = fopen(output_filename, "wb");
            if (input_file == NULL || output_file == NULL)
            {
                cout << "Fatal error opening files." << endl;
                exit(0);
            };

            decode(input_file, output_file);
            fclose(input_file);
            fclose(output_file);
            free(prefix_code);
            free(append_character);
        }
        else
        {
            cout << "Выход." << endl;
            exit(0);
        }
    }
    cout << "Имя файла: " << input_filename << endl;
    cout << "Время работы в миллисекундах: " << clock() - start << endl << endl << endl;
    fstream file1(output_filename);
    file1.seekg(0, std::ios::end);
    int size2 = file1.tellg();
    file1.close();
    double size3 = (double)size2 / 1048576;

    cout << "Входной фаил весит: " << size << " байт -> ~" << size1 << " мб" << endl;
    cout << "Выходной фаил весит: " << size2 << " байт -> ~" << size3 << " мб" << endl << endl;
    double k = (double)size / size2;

    if (tmp == "e")
        cout << "Коэффициент сжатия= " << k << endl;
    system("pause");
    return 0;
}
