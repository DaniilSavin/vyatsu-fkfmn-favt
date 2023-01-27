#include "pch.h"
#include <locale>
#include <iostream>
#include <fstream>
#include <string>
#include <algorithm>
//#ifdef _DEBUG
#include <crtdbg.h>
//#endif

//using namespace std;

enum type
{
	operation,
	number
};
enum operation
{
	plus_ = 0,
	minus_,
	mult_
};
class TreeNode
{
public:
	TreeNode(type type = number, int value = 0, TreeNode* left = 0, TreeNode* right = 0);
	TreeNode(const TreeNode& node);
	virtual ~TreeNode(void);
	// Возвращает указатель на левую ветвь
	TreeNode* const Left(void) const;
	// Возвращает указатель на правую ветвь
	TreeNode* const Right(void) const;
	type Type(void) const;
	int Value(void) const;
	bool Brackets(void) const;
	// Оператор присваивания
	TreeNode& operator=(const TreeNode& node);
protected:
	// Ветвь дерева
	TreeNode* _left;
	// Ветвь дерева
	TreeNode* _right;
	// Значение
	int _value;
	// Тип(операция/число)
	type _type;
	bool _brackets;
	friend TreeNode* term(std::wstring& str);
	friend bool nextOp(TreeNode& tree);
};
std::wstring process(std::wstring& str);
int main()
{
//#ifdef _DEBUG
	_CrtSetDbgFlag(_CrtSetDbgFlag(_CRTDBG_REPORT_FLAG) | _CRTDBG_LEAK_CHECK_DF);
//#endif
	std::locale::global(std::locale("Russian"));
	std::wstring ifname;
	std::wcout << L"Введите имя входного файла:";
	std::getline(std::wcin, ifname);
	std::wifstream in(ifname.c_str());
	if (in)
	{
		std::wstring ofname;
		std::wcout << L"Введите имя выходного файла:";
		std::getline(std::wcin, ofname);
		std::wofstream out(ofname.c_str());
		if (out)
		{
			while (!in.eof())
			{
				std::wstring str;
				std::getline(in, str);
				std::wstring res = process(str);
				std::wcout << res << std::endl;
				out << res << std::endl;
			}
			out.close();
		}
		else std::wcout << L"Не могу открыть файл: " << ofname;
		in.close();
	}
	else std::wcout << L"Не могу открыть файл: " << ifname;
	
	return 0;
}
// Удаляет лишние whitespaces
void trim(std::wstring& str)
{
	while (str.length() && iswspace(str[0]))str.erase(0, 1);
	while (str.length() && iswspace(str[str.length() - 1]))str.resize(str.length() - 1);
	for (int i = 0; i < static_cast<int>(str.length()) - 1;)
	{
		if (iswspace(str[i]) && iswspace(str[i + 1]))
		{
			str[i] = L' ';
			str.erase(i + 1, 1);
		}
		else i++;
	}
}
// Извлекает подстроку в скобках
std::wstring extract(std::wstring& str)
{
	int numL = 0;
	std::wstring::iterator it = str.begin();
	while (it != str.end())
	{
		switch (*it)
		{
		case L'(':
			numL++;
			break;
		case L')':
			numL--;
			if (!numL)
			{
				std::wstring res = str.substr(1, it - str.begin() - 1);
				str.erase(str.begin(), it + 1);
				return res;
			}
		}
		it++;
	}
	return L"";
}
TreeNode* parsestr(std::wstring& str);
// Возвращает следующий элемент дерева
TreeNode* term(std::wstring& str)
{
	trim(str);
	if (str[0] == L'(')
	{
		std::wstring tmp = extract(str);
		if (tmp.length())
		{
			TreeNode* tree = parsestr(tmp);
			if (tree)tree->_brackets = true;
			return tree;
		}
		else return 0;
	}
	if (str.length() && iswdigit(str[0]))
	{
		int value = 0;
		while (str.length() && iswdigit(str[0]))
		{
			std::wstring digit = str.substr(0, 1);
			value = value * 10 + _wtoi(digit.c_str());
			str.erase(0, 1);
		}
		return new TreeNode(number, value);
	}
	else return 0;
}
// Преобразует строку в бинарное дерево
TreeNode* parsestr(std::wstring& str)
{
	if (TreeNode* l = term(str))
	{
		while (str.length())
		{
			if (str[0] == L' ')
			{
				str.erase(0, 1);
				if (TreeNode* r = term(str))
				{
					l = new TreeNode(operation, 0, l, r);
				}
				else
				{
					delete l;
					return 0;
				}
			}
			else return 0;
		}
		return l;
	}
	else return 0;
}
// Вычисляет значение выражения сохраненного в дереве
int calc(const TreeNode& tree)
{
	switch (tree.Type())
	{
	case number:
		return tree.Value();
	case operation:
		switch (tree.Value())
		{
		case plus_:
			return calc(*tree.Left()) + calc(*tree.Right());
		case minus_:
			return calc(*tree.Left()) - calc(*tree.Right());
		case mult_:
			return calc(*tree.Left())*calc(*tree.Right());
		}
	}
	return 0;
}
// Изменить порядок опрераций
bool nextOp(TreeNode& tree)
{
	if (tree.Type() == operation)
	{
		++tree._value %= 3;
		if (!tree._value)
		{
			return nextOp(*tree._left) || nextOp(*tree._right);
		}
		else return true;
	}
	else return false;
}
// Обратное преобразование дерева в строку
std::wstring format(const TreeNode& tree)
{
	wchar_t num[10];
	std::wstring res;
	switch (tree.Type())
	{
	case number:
		_itow_s(tree.Value(), num, 10, 10);
		res = num;
		break;
	case operation:
		switch (tree.Value())
		{
		case plus_:
			res = format(*tree.Left()) + L'+' + format(*tree.Right());
			break;
		case minus_:
			res = format(*tree.Left()) + L'-' + format(*tree.Right());
			break;
		case mult_:
			res = format(*tree.Left()) + L'*' + format(*tree.Right());
			break;
		}
	}
	if (tree.Brackets())res = L'(' + res + L')';
	return res;
}
// Делает всю работу
std::wstring process(std::wstring& str)
{
	trim(str);
	std::wstring::iterator it = find(str.begin(), str.end(), L'=');
	if (it != str.end())
	{
		std::wstring resultStr = str.substr(0, it - str.begin());
		trim(resultStr);
		int result = _wtoi(resultStr.c_str());
		str.erase(str.begin(), it + 1);
		TreeNode *tree = parsestr(str);
		if (tree)
		{
			do
			{
				if (calc(*tree) == result)
				{
					std::wstring res = resultStr + L'=' + format(*tree);
					delete tree;
					return res;
				}
			} while (nextOp(*tree));
			delete tree;
			return L"-1";
		}
		else return L"Неверное выражение";
	}
	else return L"Неверный формат входных данных";
}
TreeNode::TreeNode(type type, int value, TreeNode* left, TreeNode* right)
	: _left(left)
	, _right(right)
	, _value(value)
	, _type(type)
	, _brackets(false)
{
}
TreeNode::~TreeNode(void)
{
	if (_left)
	{
		delete _left;
		_left = 0;
	}
	if (_right)
	{
		delete _right;
		_right = 0;
	}
}
TreeNode::TreeNode(const TreeNode& node)
	: _left(0)
	, _right(0)
	, _value(node._value)
	, _type(node._type)
	, _brackets(node._brackets)
{
	if (node._left)_left = new TreeNode(*node._left);
	if (node._right)_right = new TreeNode(*node._right);
}
// Оператор присваивания
TreeNode& TreeNode::operator=(const TreeNode& node)
{
	if (&node != this)
	{
		if (_left)delete _left;
		if (_right)delete _right;
		if (node._left)_left = new TreeNode(*node._left);
		else _left = 0;
		if (node._right)_right = new TreeNode(*node._right);
		else _right = 0;
		_value = node._value;
		_type = node._type;
		_brackets = node._brackets;
	}
	return *this;
}
// Возвращает указатель на левую ветвь
TreeNode* const TreeNode::Left(void) const
{
	return _left;
}
// Возвращает указатель на правую ветвь
TreeNode* const TreeNode::Right(void) const
{
	return _right;
}
type TreeNode::Type(void) const
{
	return _type;
}
int TreeNode::Value(void) const
{
	return _value;
}
bool TreeNode::Brackets(void) const
{
	return _brackets;
}