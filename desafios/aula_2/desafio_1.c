//ALTERAÇÕES REALIZADAS::: Mudança de nomes com o Typedef e alterações na Main para ficar mais dinâmico.

#include<stdio.h>
#include <stdlib.h>

/**
 Vamos usar o prefixo ll para todas as funções que são de Lista Ligada (dois l's)
*/

typedef struct no {
    int info;
    struct no * prox;
} No;

typedef No * Celula;

typedef struct lista {
    Celula inicio;
    Celula fim;
} Lista;

typedef Lista * ListaLigada;

ListaLigada novaLista() {
    ListaLigada l = malloc(sizeof(Lista));
    if (!l) return NULL;
    l->inicio = NULL;
    l->fim = NULL;
    return l;
}

Celula novaCelula(int info) {
    Celula celula = (Celula) malloc(sizeof(No));
    celula->info = info;
    celula->prox = NULL;

    return celula;
}

void llInsereNoInicio(ListaLigada lista, int info) {
    Celula celula = novaCelula(info);
    if (lista->inicio == NULL) { // lista é vazia
        lista->inicio = celula;
        lista->fim = celula;
    }
    else {
        celula->prox = lista->inicio;
        lista->inicio = celula;
    }
}

void llInsereNoFim(ListaLigada lista, int info) {
    Celula nova = novaCelula(info);
    
    if (lista->inicio == NULL) { // ou seja, a lista está vazia
        lista->inicio = nova;
        lista->fim = nova;
        return;
    }
    lista->fim->prox = nova;
    lista->fim = nova;
}

void llPrint(ListaLigada lista) {
    for (Celula aux = lista->inicio; aux != NULL; aux = aux->prox) {
        printf("%d", aux->info);
        if (aux->prox != NULL)
            printf(" -> ");
    }
    printf("\n");
}

void llRemoveInicio(ListaLigada lista) {
    if (lista->inicio == NULL) {
        return;
    }

    Celula removido = lista->inicio;
    lista->inicio = removido->prox;
    free(removido); // liberando o ponteiro da Celula removida
}

Celula llRemove(ListaLigada lista, int alvo) {
    Celula aux = NULL;
    for (aux = lista->inicio; aux->prox != NULL && aux->prox->info != alvo; aux = aux->prox);
    if (aux != NULL) { // aux é a celula anterior ao no que quero remover
        Celula removido = aux->prox;
        aux->prox = aux->prox->prox;
        free(removido);
    }
    
    return NULL; // Não consegui fazer nada, retorna nulo...
}

//---------------------------DESAFIO AQUI----------------------------------------

void somaLista(ListaLigada lista) {
    Celula aux = lista->inicio;
    int soma = 0;
    
    while (aux != NULL) {
        soma += aux->info;
        aux = aux->prox;
    }
    printf("%d \n", soma);
}

int main() {
    int qntValoresll, valorll;
    printf("Vamos criar uma lista! Digite quantos valores quer inserir nela:");
    scanf("%d", &qntValoresll);
    
    ListaLigada lista = novaLista();
    for (int i = 1; i <= qntValoresll; i++) {
        printf("Digite um número: ");
        scanf("%d", &valorll);
        llInsereNoFim(lista, valorll);
    }
    
   printf ("\nLista original: ");
   llPrint(lista);
   
   
   printf ("\nSoma da lista: ");
   somaLista(lista);
    
    return 0;
}