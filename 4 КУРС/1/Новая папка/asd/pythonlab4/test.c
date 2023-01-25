#include <locale.h>
#include <stdlib.h>
#include "test.h"
#include <stdio.h>

int counter = 0;


void CountNumbers(char* s)
{
    setlocale(LC_ALL, "Russian");
    counter = 0;
    FILE* fin;
    fin = fopen(s, "r");

    int c;

    if (fin == NULL) exit;
    else
    {
        do
        {
            c = fgetc(fin);
            if ((c == '0') || (c == '1') || (c == '2') || (c == '3') || (c == '4') || (c == '5') || (c == '6') || (c == '7') || (c == '8') || (c == '9')) counter++;
        } while (c != EOF);

        fclose(fin);
    }
}