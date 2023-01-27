<<<<<<< HEAD
﻿#include "pch.h"
#include <iostream>

int main()
{
#ifdef _OPENMP
	printf("OpenMP is supported! %d\n", _OPENMP);
#else
	printf("OpenMP is not supported!\n");
#endif
}
=======
﻿#include "pch.h"
#include <iostream>

int main()
{
#ifdef _OPENMP
	printf("OpenMP is supported! %d\n", _OPENMP);
#else
	printf("OpenMP is not supported!\n");
#endif
}
>>>>>>> ad22ee082dac6ece8d23d5999a86f8d8c86438df
