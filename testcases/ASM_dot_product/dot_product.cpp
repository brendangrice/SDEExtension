#include <iostream>
#include <stdio.h>

union mmx_word {
    unsigned __int16 word[4];
    unsigned __int64 value;
};

void dot_product(mmx_word* in, mmx_word* ans);

int main()
{
    mmx_word ANS;
    mmx_word IN[] = {
        { 1, -1, 5, -5 },
        { 2, -2, 6, -6 },
        { 3, -3, 7, -7 },
        { 4, -4, 8, -8 },
    };

    dot_product(IN, &ANS);
    for (int i = 0; i < 4; i++) printf("%d, ", (int)(ANS.word[i]));

    return 0;
}

void dot_product(mmx_word* IN, mmx_word* ANS)
{// (x1*x2) + (y1*y2)
    mmx_word NUM1; // Result
    mmx_word NUM1X = IN[0];    // 4 different Words to hold X1, X2, Y1 and Y2
    mmx_word NUM2X = IN[1];
    mmx_word NUM1Y = IN[2];
    mmx_word NUM2Y = IN[3];

    __asm
    {
        movq  mm0, NUM1X;  load with words
        movq  mm1, NUM2X
        movq  mm2, NUM1Y
        movq  mm3, NUM2Y
        pmullw mm0, mm1;    multiply
        pmullw mm2, mm3
        paddw mm0, mm2
        movq  NUM1, mm0
    }

    *ANS = NUM1;
}