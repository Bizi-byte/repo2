#include <stdlib.h> //malloc
#include <assert.h> // assert

#ifndef NDEBUG
#include <stdio.h>  //printf
#endif

#include "dlist.h"

typedef struct dlist_node
{
    void *node_data;
    struct dlist_node *next;
    struct dlist_node *prev;

}dlist_node_t;


struct dlist
{
    dlist_node_t *head;
    dlist_node_t *tail;
};

#ifndef NDEBUG
int PrintInt(void* item, void* param)
{
    printf("%d ", *(int*)item);
    return(0);
}
void PrintList(dlist_t *list, int(*PrintItem)(void *item))
{
    DListForEach(DListBegin(list), DListEnd(list), PrintInt,NULL);
    printf("\n");
}
#endif

static dlist_node_t* CreateNode(void *new_data, dlist_node_t *node_next, dlist_node_t *node_prev)
{
    dlist_node_t *new_node = (dlist_node_t *)malloc(sizeof(dlist_node_t));
    if(new_node)
    {
        new_node->node_data = new_data;
        new_node->next = node_next;
        if(NULL != node_next)
        {
            node_next->prev = new_node;

        }
        new_node->prev = node_prev;
        if(NULL != node_prev)
        {
            node_prev->next = new_node;
        }
    }

    return new_node;
}

dlist_t *DListCreate(void)
{
    dlist_t *dlist = (dlist_t*)malloc(sizeof(dlist_t));
    if(dlist)
    {
        dlist->head = CreateNode((void *)0xDEADBEEF, NULL, NULL);
        if(NULL == dlist->head)
        {
            free(dlist);
            return NULL;
        }
        
        dlist->tail = CreateNode((void *)0xDEADBEEF, NULL, NULL);
        if(NULL == dlist->tail)
        {
            free(dlist->head);
            free(dlist);
            return NULL;
        }
        dlist->head->next = dlist->tail;
        dlist->head->prev = NULL;
        dlist->tail->prev = dlist->head;
        dlist->tail->next = NULL;
    }

    return dlist;
}
void DListDestroy(dlist_t *list)
{
    dlist_node_t* tmp_current = list->head;
    dlist_node_t* tmp_next = tmp_current->next;

    while (NULL != tmp_next)
    {
        free(tmp_current);
        tmp_current = tmp_next;
        tmp_next = tmp_current->next;
    }
    free(tmp_current);
    free(list);
}
static int CountList(void* item, void *param)
{
    ++*(size_t*)param;
    return (0);
}
size_t DListSize(const dlist_t *list)
{
    size_t size = 0;
    DListForEach(DListBegin(list), DListEnd(list), CountList, &size);
    return (size);
}

int DListIsEmpty(const dlist_t *list)
{
    assert(list);
    return(DListSize(list) == 0);
}

dlist_iter_t DListBegin(const dlist_t *list)
{
    assert(list);
    return (list->head->next);
}
dlist_iter_t DListEnd(const dlist_t *list)
{
    assert(list);
    return(list->tail);
}

dlist_iter_t DListNext(dlist_iter_t cur)
{
    assert(cur);
    return(cur->next);
}

dlist_iter_t DListPrev(dlist_iter_t cur)
{
    assert(cur);
    return(cur->prev);
}

int DListIsSameIter(dlist_iter_t it1, dlist_iter_t it2)
{
    assert(it1 && it2);
    return (it1 == it2);
}
void *DListGetData(dlist_iter_t cur)
{
    assert(cur);
    return (cur->node_data);
}
dlist_iter_t DListInsert(dlist_t *list, dlist_iter_t where, void *data)
{
    assert(list);
    assert(where);

    return(CreateNode(data, where,where->prev));
}
dlist_iter_t DListRemove(dlist_iter_t cur)
{
    //dlist_node_t* tmp = cur;
    cur->prev->next = cur->next;
    cur->next->prev = cur->prev;
    cur->next = NULL;
    cur->prev = NULL;
    free(cur);
    cur = NULL; 
}
dlist_iter_t DListPushFront(dlist_t *list, void *data)
{
    return(DListInsert(list,DListBegin(list), data));
}
dlist_iter_t DListPushBack(dlist_t *list, void *data)
{
    return(DListInsert(list,DListEnd(list), data));
}
void *DListPopFront(dlist_t *list)
{
    return(DListRemove(DListBegin(list)));
}
void *DListPopBack(dlist_t *list)
{
    return(DListRemove(DListPrev(DListEnd(list))));
}
int DListForEach(dlist_iter_t begin, dlist_iter_t end,
                 int (*do_func)(void *list_data, void *param),
                 void *param)
{
    int status = 0;
    
    while((1 != status) && !DListIsSameIter(begin, end))
    {
        status = do_func(begin->node_data, param);
        begin = DListNext(begin);
    }

    return(status);
}
dlist_iter_t DListSplice(dlist_iter_t where, dlist_iter_t begin, dlist_iter_t end);
dlist_iter_t DListFind(dlist_iter_t begin, dlist_iter_t end,
                       int(*is_match)(const void *list_data,
                                      const void *param),
                       const void *param)
{

    while(!DListIsSameIter(begin, end))
    {
        if(is_match(DListGetData(begin),param))
        {
            break;
        }
        begin = DListNext(begin);
    }

    return(begin);
}