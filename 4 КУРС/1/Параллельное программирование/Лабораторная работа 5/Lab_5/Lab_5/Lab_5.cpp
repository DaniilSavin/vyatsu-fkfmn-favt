#include "pch.h"
#include <iostream>

int main()
{
#ifdef _OPENMP
	printf("OpenMP is supported! %d\n", _OPENMP);
#else
	printf("OpenMP is not supported!\n");
#endif
}
