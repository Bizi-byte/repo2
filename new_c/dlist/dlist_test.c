#include <stdio.h>
#include "dlist.h"


static void TestCreate();
static void TestIter();


int main()
{
    TestCreate();
    TestIter();
    
    return 0;
}

static void TestCreate()
{
    dlist_t *dl = DListCreate();
    if(NULL == dl)
    {
        printf("dlist creation failed!\n");
    }
    else
    {
        printf("creation succeded\n");
    }

    DListDestroy(dl);
}

int AddOne(void* item, void* param)
{
    ++*(int*)item;
    return(0);
}

int Match7(const void* item, const void* param)
{
    return(*(int*)item == 7);
}
static void TestIter()
{
    int push_front = 0;
    int push_back = 10;

    int arr[] = {1,2,3,4,5,6,7,8,9};
    dlist_t *dl = DListCreate();
    if(NULL == dl)
    {
        printf("dlist creation failed!\n");
    }

    for(int i = 0; i < 9;++i)
    {
        DListInsert(dl, DListEnd(dl), arr + i);
        printf("size:%lu\n", DListSize(dl));
    }
    printf("printing list...");
    PrintList(dl);

    dlist_iter_t it = DListBegin(dl);
    printf("iter at end?(no):%d\n", DListIsSameIter(it, DListEnd(dl)));
    for(int i = 0; i < 9;++i)
    {
        printf("value:%lu\n", *(int*)DListGetData(it));
        it = DListNext(it);
    }
    printf("iter at end?(yes):%d\n", DListIsSameIter(it, DListEnd(dl)));

    it = DListPrev(it);
    for(int i = 0; i < 9;++i)
    {
        printf("value:%lu\n", *(int*)DListGetData(it));
        it = DListPrev(it);
    }

    PrintList(dl);
    DListPushFront(dl, &push_front);
    PrintList(dl);
    printf("size:%lu\n", DListSize(dl));
    DListPushBack(dl, &push_back);
    PrintList(dl);
    printf("size:%lu\n", DListSize(dl));
    DListPopFront(dl);
    PrintList(dl);
    DListPopBack(dl);
    PrintList(dl);


    DListForEach(DListBegin(dl), DListPrev(DListEnd(dl)), AddOne, NULL);
    PrintList(dl);

    dlist_iter_t found = DListFind(DListBegin(dl), DListEnd(dl), Match7, NULL);
    printf("Found data is(expected 7):%d\n", *(int*)DListGetData(found));

    for(int i = 0; i < 9;++i)
    {
        DListRemove(DListBegin(dl));
        printf("size:%lu\n", DListSize(dl));
    }

    DListDestroy(dl);
}

    /* dlist_t *dl = DListCreate();
    if(NULL == dl)
    {
        printf("dlist creation failed!\n");
    }

    DListDestroy(dl); */
