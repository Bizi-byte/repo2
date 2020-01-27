#pragma once

typedef struct stack* stack_t;

stack_t StackCreate(size_t capacity, size_t item_size);
void StackDestroy(stack_t s);
int StackPush(stack_t  s, void* data);
int StackPop(stack_t s);
void* StackPeek(stack_t s);
size_t StackSize(stack_t s);
int StackIsEmpty(stack_t s);