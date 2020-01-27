#ifndef _HASH_H_
#define _HASH_H

typedef struct hash
{
    /* data */
}hash_t;

typedef int (*)(int) match_func;
typedef int (*)(int) op_func;

hash_t* create(size_t capacity);

void destroy(hash_t* hash);

remove(hash_t* hash, size_t key);

insert(hash_t*, int data, size_t key);

size_t size(const hash_t* hash);

int is_empty(const hash_t* hash);

find(hash_t* hash, int(*)(int) match);

foreach(hash_t* hash, op_func op);

#endif