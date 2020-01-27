#pragma once

#include <stdlib.h> /* malloc */
#include <string.h> /* memcpy */
#include <stdio.h>

#include "stack.h"

struct stack
{
	size_t next_item;
	size_t capacity;
	size_t item_size;
	char array[1];
};

stack_t StackCreate(size_t capacity, size_t item_size)
{
	stack_t s = (stack_t)malloc(sizeof(struct stack) + capacity * item_size - sizeof(size_t));
	if (NULL != s)
	{
		s->next_item = 0;
		s->capacity = capacity;
		s->item_size = item_size;
	}

	return s;

}
void StackDestroy(stack_t s)
{
	free (s);
}
int StackPush(stack_t s, void* data)
{
	int status = 0;

	if (s->next_item < s->capacity)
	{
		memcpy(s->array + (s->item_size * s->next_item), data, s->item_size);
		++s->next_item;
		status = 1;
	}

	return status;
}
int StackPop(stack_t s)
{
	int status = 0;
	if (s->next_item > 0)
	{
		--s->next_item;
		status = 1;
	}

	return status;
}

void* StackPeek(stack_t s)
{
	return (s->array + (s->item_size * (s->next_item - 1)));
}
size_t StackSize(stack_t s)
{
	return s->next_item;
}
int StackIsEmpty(stack_t s)
{
	return (s->next_item == 0);
}
