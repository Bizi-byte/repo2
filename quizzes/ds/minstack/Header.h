#pragma once

/*struct stack
{
	void* array;
	size_t next_item;
	size_t capacity;
};*/
typedef struct stack* stack_t;

stack_t StackCreate(size_t capacity);
void StackDestroy(stack_t s);
int StackPush(stack_t  s, void* data);
void StackPop(stack_t s);
void* StackPeek(stack_t s);
size_t StackSize(stack_t s);
int StackIsEmpty(stack_t s);
