// minstack.cpp : This file contains the 'main' function. Program execution begins and ends there.
//


#include <stdio.h>

#include "stack.h"
#include "minstack.h"

typedef struct X
{
	int a;
	int b;
}X;

int main()
{
    stack_t s = StackCreate(10, sizeof(X));
	X x1 = { 1 , 2 };
	StackPush(s, &x1);

	X* tmp = (X*)StackPeek(s);

	printf("X val1 = %d, val2 = %d\n", tmp->a, tmp->b);

	X arr[10];
	for (int i = 0; i < 10; ++i)
	{
		arr[i] = { i + 2, i + 3 };
		StackPush(s, &arr[i]);
		tmp = (X*)StackPeek(s);
		printf("X val1 = %d, val2 = %d, size = %lu\n", tmp->a, tmp->b, StackSize(s));
	}

	printf("empty: %d\n", StackIsEmpty(s));
	for (int i = 0; i < 10; ++i)
	{
		StackPop(s);
	}
	printf("empty: %d\n", StackIsEmpty(s));

	StackDestroy(s);

	minstack_t ms = MinstackCreate(10);
	int a1 = 1;
	int a2 = 2;
	int a3 = 3;
	int a4 = 4;

	MinstackPush(ms, &a4);
	printf("after push of 4 min is: %d\n", MinstackMin(ms));
	MinstackPush(ms, &a2);
	printf("after push of 2 min is: %d\n", MinstackMin(ms));
	MinstackPush(ms, &a3);
	printf("after push of 3 min is: %d\n", MinstackMin(ms));
	MinstackPush(ms, &a1);
	printf("after push of 1 min is: %d\n", MinstackMin(ms));

	MinstackPop(ms);
	printf("after pop: %d\n", MinstackMin(ms));
	MinstackPop(ms);
	printf("after pop: %d\n", MinstackMin(ms));
	MinstackPop(ms);
	printf("after pop: %d\n", MinstackMin(ms));
	MinstackPop(ms);
	printf("after pop: %d\n", MinstackMin(ms));

	MinstackDestroy(ms);

	return 0;
	
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
