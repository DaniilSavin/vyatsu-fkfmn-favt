#pragma once
#ifndef _SITE_H
#define _SITE_H
#include <string>
#include <vector>
using namespace std;
struct  SiteUser
{
	string Name, Surname, Middle_name, Countrym, City, Place_of_work;
	int Age, Telephone;
};
int initconsol(SiteUser *, int);
void printconsol(SiteUser *, int);
void printbinfile(SiteUser *, int);
ostream &operator<<(std::ostream &, SiteUser &);
string initfromfile(vector<SiteUser> &);
void printconsol(vector<SiteUser> &);
void add(vector<SiteUser> &, string h);
istream &operator >> (std::istream &, SiteUser &);
void SortF(vector<SiteUser> &a);
void SortRU(vector<SiteUser> &a);
void SortOldRU(vector<SiteUser> &a);
void SortVy(vector<SiteUser> &a);
#endif // !_SITE_H

