#include <stdio.h>

int main()
{
    const long x=1;
    long y=5;

    *(&y-1) = 666;

    printf("x=%lu\n",x);
    /*
    Add/Remove this line*/
    //printf("&x=%p\n",(void*)&x);

    return 0;
}