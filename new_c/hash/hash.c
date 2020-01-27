
#include "/home/ishay/ishay-peleg/new_c/dlist/dlist.h"
#include "hash.h"

size_t HashFunc(size_t key)
{
    return(key);
}

size_t GetKey(size_t hash, size_t capacity)
{
    return(hash % capacity);
}
typedef struct hash
{
    dlist_t** lists;
    size_t capacity;
}hash_t;

hash_t* create(size_t capacity)
{
    hash_t *table = (hash_t*)malloc(sizeof(hash_t));
    if(table)
    {
        table->capacity = capacity;
        dlist_t **runner = table->lists;
        for(int i = 0; i < capacity; ++i)
        {
            runner[i] = DListCreate();
            if(!runner[i])
            {
                // free all
            }
        }
    }
}

void destroy(hash_t* hash)
{

}

remove(hash_t* hash, size_t key)
{

}

insert(hash_t*, int data, size_t key)
{

}

size_t size(const hash_t* hash)
{

}

int is_empty(const hash_t* hash)
{

}

find(hash_t*)

foreach(hash_t* hash)