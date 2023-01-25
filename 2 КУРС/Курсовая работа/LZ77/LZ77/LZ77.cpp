#define _CRT_SECURE_NO_WARNINGS

#include "iostream"
#include <io.h>
#include <fcntl.h>
#include <sys/stat.h>
#include "string"
#include <ctime>
#include <fstream>
#include <tchar.h>

using namespace std;


// Класс для ввода/вывода
class archiving
{
	int handle;
	unsigned char buffer, mask;
public:
	void assign_read(int h); // связывание для чтения
	void assign_write(int h); // связываение для записи
	void write_zero(); // заполнение нулями

	void putbit(bool val); // запись бита
	bool getbit(); //чтение бита

	void putbits(int val, int n); // запись n битов
	int getbits(int n); // чтение n битов
};

// заполнение нулями
void archiving::write_zero()
{
	for (int i = 0; i < 7; i++) putbit(0);
}

// связываение для записи
void archiving::assign_write(int h)
{
	handle = h;
	buffer = 0;
	mask = 128;
}

// связывание для чтения
void archiving::assign_read(int h)
{
	handle = h;
	buffer = 0;
	mask = 0;
}

//чтение бита
bool archiving::getbit()
{
	if ((mask >>= 1) == 0)
	{
		_read(handle, &buffer, 1);
		mask = 128;//двоичное 10000000
	}
	return (buffer & mask) != 0;
}

// запись бита
void archiving::putbit(bool val)
{
	if (val) buffer |= mask;
	if ((mask >>= 1) == 0)
	{
		_write(handle, &buffer, 1);
		buffer = 0;
		mask = 128;//двоичное 10000000
	}
}

// запись n битов
void archiving::putbits(int val, int n)
{
	int m = 1;
	for (int i = 0; i < n; i++)
	{
		putbit((val & m) != 0);
		m <<= 1;
	}
}

// чтение n битов
int archiving::getbits(int n)
{
	int result = 0;
	for (int i = 0; i < n; i++)
		result |= getbit() << i;
	return result;
}

#define OFFS_LN 8
#define LEN_LN 4
#define BYTE_LN 8

//#define BUF_LEN 15
#define BUF_LEN ((1 << LEN_LN) - 1)
//#define DICT_LEN 256
#define DICT_LEN ((1 << OFFS_LN) - 1)

int in_file;  // входной файл
int out_file; // выходной файл
static archiving archive;

/*
	Сделаем буфер на 1 больше, т. к. в find_match
	`unmatched = buffer[match_len];` а match_len
	может достигать BUF_LEN
*/
char buffer[BUF_LEN + 1], dict[DICT_LEN];
int match_pos, match_len, unmatched;
int dict_pos = 0;


//	Возвращает позицию sub от КОНЦА src. от 1 до len
//	Если не найдено, возвращает 0

int strpos(char* src, int len, char* sub, int sub_len)
{
	for (int i = 0; i <= len - sub_len; i++)
		if (memcmp(src + i, sub, sub_len) == 0) return len - i;
	return 0;
}

// добавление в словарь символа
void add_dict(char c)
{
	if (dict_pos == (DICT_LEN - 1)) //если позиция словаря равна размеру словаря-1
	{
		memcpy(dict, dict + 1, DICT_LEN - 1); //копирование DICT_LEN-1 байтов из блока dict+1 в блок dict
		dict[dict_pos - 1] = c; //добавление символа в словарь на позицию dict_pos-1
	}
	else //иначе
	{
		dict[dict_pos] = c; //добавление символа с словарь на позицию dict_pos
		dict_pos++; //увеличение позиции
	}
}

// поиск совпадения в словаре
void find_match()
{
	match_len = 0;//длина совпадения
	match_pos = 1;//позиция совпадения
	while (match_len < BUF_LEN) //пока размер совпадения меньше размера буфера
	{
		_read(in_file, &buffer[match_len], 1); //чтение файла
		if (_eof(in_file)) break; //если файл пустой – выход
		int pos1 = strpos(dict, dict_pos, buffer, match_len + 1);
		if (pos1 == 0) break; //если позиция равна 0 - выход
		match_pos = pos1; //указывание позиции совпадения
		match_len++; //увеличение длины совпадения
		
	}
	unmatched = buffer[match_len];
}

// компрессия
void encode()
{
	while (!_eof(in_file)) //пока файл не пуст
	{
		find_match(); //ищем совпадение
		archive.putbits(match_pos, OFFS_LN); //запись в сжатый файл
		archive.putbits(match_len, LEN_LN); //запись в сжатый файл
		if (match_len < BUF_LEN) //если размер совпадение меньше размера буфера
			archive.putbits(unmatched, BYTE_LN); //запись в сжатый файл

		for (int i = 0; i < match_len; i++)
			add_dict(buffer[i]); //добавление в словарь
		if (match_len < BUF_LEN) //если размер совпадение меньше размера буфера
			add_dict(unmatched); //добавление в словарь
	}
	archive.putbits(0, BYTE_LN); //запись нулей
	archive.write_zero(); //заполнение нулями
}

// декомпрессия
void decode()
{
	char c;
	int i;
	for (;;) //пустой цикл для того чтобы потом можно было выйти
	{
		match_pos = archive.getbits(OFFS_LN); //позиция совпадения
		if (match_pos == 0) break; //если позиция совпадение равна 0 - выход
		match_len = archive.getbits(LEN_LN); //размер совпадение
		memcpy(buffer, dict + dict_pos - match_pos, match_len); //копирование  match_len байтов из блока dict + dict_pos - match_pos в блок buffer
		_write(out_file, buffer, match_len); //запись в раскодированный файл
		for (i = 0; i < match_len; i++)
			add_dict(buffer[i]); //добавление в словарь
		if (match_len < BUF_LEN) //если размер совпадение меньше размера буфера
		{
			c = archive.getbits(BYTE_LN);//получение бита
			add_dict(c);//запись бита в словарь
			_write(out_file, &c, 1); //запись в раскодированный файл
		}
	}
}
//---------------------------------------------------------
// главная процедура
int main()
{
	setlocale(LC_ALL, "rus");
	string intro = R"(Введите режим работы:
e - сжатие
d - распаковка)";
	char input_filename[100];
	char output_filename[100] = "out.lz77";
	cout << "Введите название файла:" << endl << "> ";
	cin >> input_filename;
	fstream file(input_filename);
	int size = 0;
	file.seekg(0, std::ios::end);
	size = file.tellg();
	file.close();
	double size1 = (double)size / 1048576;

	cout << intro << endl << "\n>";

	string tmp;
	cin >> tmp;
	system("cls");
	if (tmp == "d")
	{
		cout << "Введите старое название файла:" << endl << "> ";
		cin >> output_filename;
		system("cls");
	}
	
	// открытие входного и выходного файлов
	in_file = _open(input_filename, _O_BINARY | _O_RDWR, _S_IREAD | _S_IWRITE);
	out_file = _open(output_filename, _O_BINARY | _O_WRONLY | _O_CREAT | _O_TRUNC, _S_IREAD | _S_IWRITE);

	unsigned int start = clock();
	if (tmp == "e") // компрессия
	{
		archive.assign_write(out_file);
		encode();
	}
	else if (tmp == "d") // декомпрессия
	{
		archive.assign_read(in_file);
		decode();
	}
	else printf("Nothing to do\n");

	_close(in_file);
	_close(out_file);
	cout << "Имя файла: " << input_filename << endl;
	cout << "Время работы в миллисекундах: " << clock() - start << endl << endl << endl;

	fstream file1(output_filename);
	file1.seekg(0, std::ios::end);
	int size2 = file1.tellg();
	file1.close();
	double size3 = (double)size2 / 1048576;

	cout << "Входной файл весит : " << size << " байт -> ~" << size1 << " мб" << endl;
	cout << "Выходной файл весит : " << size2 << " байт -> ~" << size3 << " мб" << endl;
	double k = (double)size / size2;

	if (tmp == "e")
		cout << "Коэффициент сжатия= " << k << endl;

	system("pause");
	return 0;
}
