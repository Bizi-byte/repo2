#include <stdio.h>

int main(void)
{
	int a = 3;
	void* x = &a;
	const void* y = &a;
	int* ptr = (int *)x;
	y = x;
	printf("hello");
}