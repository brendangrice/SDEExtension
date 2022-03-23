#include <iostream>

float newtonsMethod(float x, float y);
float Q_rsqrt(float number);

int main()
{
    printf("%f\n",newtonsMethod(10.0F, 0.01F)); // 10 iterations of newton's from a bad guess
    printf("%f\n", Q_rsqrt(10.0F)); // 1 iteration from a good guess
    //Answer is approx 0.31622776601683793319988935444327
}

float newtonsMethod(float x, float y)
{ // naive implementation of Newtons Method for square root of x to the power of -1, square root reciprocal
    for (int i = 0; i < 10; i++) 
    { // 10 iterations
        y = y * (1.5F - (0.5F * x * y * y));
    }
    return y;
}

float Q_rsqrt(float x)
{// square root reciprocal https://github.com/id-Software/Quake-III-Arena/blob/dbe4ddb10315479fc00086f08e25d968b4b43c49/code/game/q_math.c#L552
    long i;
    float x2, y;
    const float threehalfs = 1.5F;

    x2 = x * 0.5F;
    y = x;
    i = *(long*)&y;
    i = 0x5F3759DF - (i >> 1);
    y = *(float*)&i;
    y = y * (threehalfs - (x2 * y * y));

    return y;
}
