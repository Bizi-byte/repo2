#include <stdlib.h>
#include <stdio.h>

#include "stack.h"
#include "minstack.h"

struct minstack
{
	stack_t s;
	stack_t min;
};
minstack_t MinstackCreate(size_t capacity)
{
	minstack_t ms = (minstack_t)malloc(sizeof(struct minstack));
	if (NULL == ms)
	{
		return NULL;
	}
	ms->s = StackCreate(capacity, sizeof(int));
	if (NULL == ms->s)
	{
		free (ms);
		return NULL;
	}

	ms->min = StackCreate(capacity, sizeof(int));
	if (NULL == ms->min)
	{
		free(ms);
		free(ms->s);
		return NULL;
	}

	return ms;
}
void MinstackDestroy(minstack_t ms)
{
	StackDestroy(ms->s);
	StackDestroy(ms->min);
	free(ms);
}
int MinstackMin(minstack_t ms)
{
	return (*(int*)StackPeek(ms->min));
}
void MinstackPush(minstack_t ms, int* data)
{
	if (StackIsEmpty(ms->s) || (*data <= *(int*)StackPeek(ms->min)))
	{
		StackPush(ms->min, data);
	}
	else
	{
		StackPush(ms->min, StackPeek(ms->min));
	}
	StackPush(ms->s, data);


}
void MinstackPop(minstack_t ms)
{
	StackPop(ms->min);
	StackPop(ms->s);
}