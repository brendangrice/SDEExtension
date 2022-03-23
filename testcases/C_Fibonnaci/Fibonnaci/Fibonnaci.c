#include <stdio.h>
#include <stdlib.h>

#define u64 long long

#define f_len 40

u64 f(int n);
u64 f_mem(int n, u64 *mem);
u64 f_matrix(int n);
void f_arrayset(u64 *a, int v, int n);

//#define naive
//#define memoise
#define matrix

int main()
{
#ifdef naive
    printf("%lld\n", f(f_len));
#endif
#ifdef memoise
    u64 mem[f_len+1]; // needs to be one larger to hold the result
    f_arrayset(mem, -1, f_len+1); // nil array
    mem[0] = 0;
    mem[1] = 1;

    printf("%lld\n", f_mem(f_len, mem));
#endif
#ifdef matrix
    printf("%lld\n", f_matrix(f_len));
#endif
    return 0;
}

u64 f(int n) 
{ // fibonnaci
    return (n < 2) ? n : f(n - 1) + f(n - 2);
}

u64 f_mem(int n, u64 *mem) 
{ // fibonnaci w/ mem
    return (mem[n] != -1) ? mem[n] : (mem[n] = f_mem(n - 1, mem) + f_mem(n - 2, mem));
}

void f_arrayset(u64 *a, int v, int n) 
{ // memset doesn't work with the ms compiler?
    for (int i = 0; i < n; i++)
        a[i] = v;
}

u64 f_matrix(int n)
{ // fibonnaci with matrix exponentiation https://math.stackexchange.com/questions/1859328/fibonacci-using-matrix-representation
    u64 fib[2][2] = { {1,1},{1,0} }, ret[2][2] = { {1,0},{0,1} }, tmp[2][2] = { {0,0},{0,0} };
    int i, j, k;

    while (n)
    {
        if (n & 1)
        {
            f_arrayset(tmp[0], 0, 2);
            f_arrayset(tmp[1], 0, 2);
            for (i = 0; i < 2; i++) for (j = 0; j < 2; j++) for (k = 0; k < 2; k++)
                tmp[i][j] = (tmp[i][j] + ret[i][k] * fib[k][j]);
            for (i = 0; i < 2; i++) for (j = 0; j < 2; j++) ret[i][j] = tmp[i][j];
        }
        f_arrayset(tmp[0], 0, 2);
        f_arrayset(tmp[1], 0, 2);
        for (i = 0; i < 2; i++) for (j = 0; j < 2; j++) for (k = 0; k < 2; k++)
            tmp[i][j] = (tmp[i][j] + fib[i][k] * fib[k][j]);
        for (i = 0; i < 2; i++) for (j = 0; j < 2; j++) fib[i][j] = tmp[i][j];
        n /= 2;
    }
    return (ret[0][1]);
}