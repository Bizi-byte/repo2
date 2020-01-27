#pragma once

typedef struct minstack* minstack_t;

minstack_t MinstackCreate(size_t capacity);
void MinstackDestroy(minstack_t ms);
int MinstackMin(minstack_t ms);
void MinstackPush(minstack_t ms, int* data);
void MinstackPop(minstack_t ms);

