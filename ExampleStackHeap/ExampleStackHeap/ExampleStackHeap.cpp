#include <stdio.h>
#include <stdlib.h>

/*
Exemplo de memoria Stack e Heap
*/
//int main()
//{
//	int x = 8;//stack
//	int z = 4;
//	int z = 4;
//	int* y = new int(8);
//}

int main()
{
    //Game of Life
    //Grid: 1000x1000
    int const gridSize = 1000 * 1000;//stack e fixo (2mb, 4mb)
    //int grid[gridSize]; ---> Errado, stack overflow
    int* grid = (int*) malloc(gridSize * sizeof(int));// Correto -> Aloca no Heap

    for (int i = 0; i < gridSize; ++i)
    {
        //executando a logica do game of life
        printf("---> %d", i);
    }
}
