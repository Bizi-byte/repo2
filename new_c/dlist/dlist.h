#ifndef _DLIST_H_
#define _DLIST_H_

#include <stddef.h> //size_t


typedef struct dlist dlist_t;
typedef struct dlist_node *dlist_iter_t;

dlist_t *DListCreate(void);
void DListDestroy(dlist_t *list);
size_t DListSize(const dlist_t *list);
int DListIsEmpty(const dlist_t *list);
dlist_iter_t DListBegin(const dlist_t *list);
dlist_iter_t DListEnd(const dlist_t *list);
dlist_iter_t DListNext(dlist_iter_t cur);
dlist_iter_t DListPrev(dlist_iter_t cur);
int DListIsSameIter(dlist_iter_t it1, dlist_iter_t it2);
void *DListGetData(dlist_iter_t cur);
dlist_iter_t DListInsert(dlist_t *list, dlist_iter_t where, void *data);
dlist_iter_t DListRemove(dlist_iter_t cur);
dlist_iter_t DListPushFront(dlist_t *list, void *data);
dlist_iter_t DListPushBack(dlist_t *list, void *data);
void *DListPopFront(dlist_t *list);
void *DListPopBack(dlist_t *list);
int DListForEach(dlist_iter_t begin, dlist_iter_t end,
                 int (*do_func)(void *list_data, void *param),
                 void *param);
dlist_iter_t DListSplice(dlist_iter_t where, dlist_iter_t begin, dlist_iter_t end);
dlist_iter_t DListFind(dlist_iter_t begin, dlist_iter_t end,
                       int(*is_match)(const void *list_data,
                                      const void *param),
                       const void *param);

#endif //_DLIST_H_