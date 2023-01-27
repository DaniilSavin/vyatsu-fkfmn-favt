// zadanie_1.cpp: определяет точку входа для консольного приложения.
//

#include "stdafx.h"
#include "iostream"
#include "string"
#include "fstream"
#include "clocale"
using namespace std;

const int kT = 6;
const int n_str = 5;
const int n_ident = 20;
const int n_lex = 100;
int n_text = 0;
int nL = 0;
int nT = 0;
/*struct TS
{
	string* TS=new string [];
};*/

char *a_text = new char[n_str];
int *LL = new int[n_lex];
int *TT = new int[n_lex];
string VV[] = { "var", "begin", "end", "read", "write", "integer" };


void input()
{
	ifstream fout("prim.lex", ios::in);
	n_text = 0;
	while (fout)
	{
		fout >> a_text[n_text];
		n_text++;
	}
	fout.close();
}

void output()
{
	ofstream codeLex("code.lex", ios::out);
	ofstream identLex("ident.lex", ios::out);
	for (int i = 0; i < nL; i++)
	{
		codeLex << LL[i] << TT[i];
	}
	for (int i = 0; i < nT; i++)
	{
		identLex << VV[i];
	}
}

bool letter( char a)
{
	int k;
	k = (int)a;
	if ((k >= 64 && k <= 90) || (k>=96 && k<=122)) return 1;
	else return 0;
}

bool digit(char a)
{
	int k;
	k = (int)a;
	if (k >= 48 && k <= 57) return 1;
	else return 0;
}

int l_ident(int i)
{
	int k=i;
	while (letter(a_text[k]) == 1 || digit(a_text[k]) == 1)
	{
		k++;
	}
	k--;
	return k;
}

int l_const(int i)
{
	int k = i;
	while (digit(a_text[k]) == 1)
	{
		k++;
	}
	k--;
	return k;

}

void ttin(int kk, string str,int code ,int type)
{
	int k = 0;
	for (int i = 0; i < nT; i++)
	{
		if (str == VV[i])
		{
			k = i;
		}
		if (k <= kT)
		{
			code = k;type = kk;
		}
		if (k == 0)
		{
			nT++;
			VV[nT] = str;
			code = nT;
			type = kk;
		}
	}

}

void lexan()
{
	int code, type, k;
	char a;
	string str;
	int i, j;
	i = 0;
	int o=0;
	while (i < n_str)
	{
		i++;
		a = a_text[i];
		o = (int)a;
		if (o > 32)
		{
			if (letter(a) == 1)
			{
				k = l_ident(i);
				str = "";
				for (int j = i; j < k; str += a_text[j])
				{
					ttin(200, str, code, type);
					nL++;
					LL[nL] = code;
					TT[nL] = type;
					i = k;
				}

			}
			if (digit(a))
			{
				k = l_const(i);
				str = "";
				for (int j = i; j < k; str += a_text[j])
				{
					ttin(300, str, code, type);
					nL++;
					LL[nL] = code;
					TT[nL] = type;
					i = k;

				}
			}
			if ((letter(a) != 1) && (digit(a) != 1))
			{
				switch (a)
				{
				case '+':
					code=100;
						break;
				case '-':
					code=101;
						break;
				case '*':
					code = 102;
					break;
				case '/':
					code = 103;
					break;
				case '=':
					code = 104;
					break;
				case '(':
					code = 105;
					break;
				case ')':
					code = 106;
					break;
				case ',':
					code = 107;
					break;
				case ':':
					code = 108;
					break;
				case ';':
					code = 109;
					break;

				}

				type = 0;
				nL++;
				LL[nL] = code;
				TT[nL] = type;

			}
		}
	}

}

int main()
{
	setlocale(LC_ALL, "rus");
	input();
	lexan(); 
	ofstream prt ("prt.txt", ios::out);
	for (int i = 0; i < n_text; i++)
	{
		
		prt << a_text[i];

	}
	for (int i = 0; i < nL; i++)
	{
		prt << TT[i] << " " << LL[i] << " ";

	}
    return 0;
}

