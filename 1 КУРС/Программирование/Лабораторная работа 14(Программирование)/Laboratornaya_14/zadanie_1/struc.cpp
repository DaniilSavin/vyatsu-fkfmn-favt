#include "pch.h"
#include "struc.h"

int initconsol(SiteUser *a, int n)
{
	
	for (int i = 0; i < n; i++)
	{
		cout << "Imput " << i << " element\n";
		cout << "Name: ";
		cin >> a[i].Name;
		cout << "Surname: ";
		cin >> a[i].Surname;
		cout << "Middle_name: ";
		cin >> a[i].Middle_name;
		cout << "Country: ";
		cin >> a[i].Countrym;
		cout << "City: ";
		cin >> a[i].City;
		cout << "Place_of_work: ";
		cin >> a[i].Place_of_work;
		cout << "Age: ";
		cin >> a[i].Age;
		cout << "Telephone: ";
		cin >> a[i].Telephone;
	}
	return n;
}

ostream &operator << (std::ostream & out, SiteUser & user)
{
	out << user.Name << " " << user.Surname << " " << user.Middle_name << " "
		<< user.Countrym << " " << user.City << " " << user.Place_of_work << " " << user.Age << " " << user.Telephone << "\n";
	return out;
}
void printconsol(SiteUser * a, int n)
{
	cout << "<--------------------------------------------------------------->" << endl;
	for (int i = 0; i < n; i++)
		cout << a[i];
}
void printbinfile(SiteUser * a, int n)
{
	char namefile[15];
	cout << "Imput file name: ";
	cin >> namefile;
	ofstream outfile(namefile, ios::binary | ios::out);
	if (outfile)
	{
		outfile.write(reinterpret_cast<char*> (a), sizeof(SiteUser)*n);
	}
	else cerr << "File not found." << endl;
	outfile.close();
}


istream &operator >> (std::istream &in, SiteUser &user)
{

	cout << "Name: ";
	in >> user.Name;
	cout << "Surname: ";
	in >> user.Surname;
	cout << "Middle_name: ";
	in >> user.Middle_name;
	cout << "Country: ";
	in >> user.Countrym;
	cout << "City: ";
	in >> user.City;
	cout << "Place_of_work: ";
	in >> user.Place_of_work;
	cout << "Age: ";
	in >> user.Age;
	cout << "Telephone: ";
	in >> user.Telephone;
	return in;
}

void add(vector<SiteUser> &a, string h)
{
	SiteUser x;
	cin >> x;
	a.push_back(x);
	ofstream outfile;
	outfile.open(h, ios::binary | ios::app);
	if (outfile)
	{
		/*outfile.write((char*)&a, sizeof(a) * 3);*/
		outfile.write((char*)&x, sizeof(x));
	}
	outfile.close();
}
void printconsol(vector<SiteUser> &a)
{
	for (vector<SiteUser>::iterator it = a.begin(); it < a.end(); it++)
	{
		cout << *(it);
	}
}
string initfromfile(vector<SiteUser> &a)
{
	char namefile[15];
	cout << "Imput file name: ";
	cin >> namefile;
	ifstream infile(namefile, ios::binary | ios::in);
	if (infile.is_open())
	{
		SiteUser *x = new SiteUser;
		while (infile.read((char*)(x), sizeof(SiteUser)))
		{
			a.push_back(*x);
		}
	}
	else cerr << "File not found." << endl;
	infile.close();
	return namefile;
}

void SortF(vector<SiteUser> &a)
{
	char namefile[15];
	cout << "Imput file name: ";
	cin >> namefile;
	ofstream outfile(namefile);
	char t = 'A';
	for (int i = 0; i < 26; i++)
	{
		for (vector<SiteUser>::iterator it = a.begin(); it < a.end(); it++)
		{
			string sur = it->Surname;
			if (sur[0] == t)
			{
				cout << *(it);
				outfile << *(it);
			}
		}
		t++;
	}
	outfile.close();
}

void SortRU(vector<SiteUser> &a)
{
	char namefile[15];
	cout << "imput file name: ";
	cin >> namefile;
	ofstream outfile(namefile);
	for (vector<SiteUser>::iterator it = a.begin(); it < a.end(); it++)
	{
		string sur = it->Countrym;
		if (sur != "Rus" && sur != "rus" && sur != "ru" && sur != "Russia")
		{
			cout << *(it);
			outfile << *(it);
		}
	}
	outfile.close();
}

void SortOldRU(vector<SiteUser> &a)
{
	char namefile[15];
	cout << "Imput file name: ";
	cin >> namefile;
	ofstream outfile(namefile);
	vector<SiteUser>::iterator olo;
	int Max_old = 1000;
	bool b = false;
	for (vector<SiteUser>::iterator it = a.begin(); it < a.end(); it++)
	{
		string sur = it->Countrym;
		if (sur == "Rus" || sur == "rus" || sur == "ru" || sur == "Russia")
		{
			int old = it->Age;
			if (Max_old > old)
			{
				Max_old = old;
				olo = it;
				b = true;
			}
		}
	}
	if (b)
	{
		cout << *(olo);
		outfile << *(olo);
	}
	else
	{
		cout << "Not Russians." << endl;
	}
	outfile.close();
}

void SortVy(vector<SiteUser> &a)
{
	char namefile[15];
	cout << "Imput file name: ";
	cin >> namefile;
	ofstream outfile(namefile);
	bool b = false;
	for (vector<SiteUser>::iterator it = a.begin(); it < a.end(); it++)
	{
		string old = it->Place_of_work;
		if (old == "vyatsu" || old == "Vyatsu")
		{
			cout << *(it);
			outfile << *(it);
			b = true;
		}
	}
	if (!b)
	{
		cout << "Empty." << endl;
	}
	outfile.close();
}