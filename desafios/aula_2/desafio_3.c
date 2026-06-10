
#include<stdio.h>
#include <stdlib.h>
#include <stdbool.h>

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

void somaLista(ListaLigada lista) {
    Celula aux = lista->inicio;
    int soma = 0;
    
    while (aux != NULL) {
        soma += aux->info;
        aux = aux->prox;
    }
    printf("%d \n", soma);
}

void bubbleSort(ListaLigada lista) {
    int temporario = 0;
    bool trocou = true;
    
    while(trocou) {
        trocou = false;
        Celula j = lista->inicio;
        while (j->prox != NULL) {
            if (j->info > j->prox->info) {
                temporario = j->info;
                j->info = j->prox->info;
                j->prox->info = temporario;
                trocou = true;
            }
            j = j->prox;
        }
    }
}

//---------------------------DESAFIO AQUI----------------------------------------

ListaLigada insereOrdenado (ListaLigada lista, int alvo) {
    Celula aux = lista->inicio;
    Celula nova = novaCelula(alvo);
    
    //Caso o valor seja o primeiro:
        if (alvo < lista->inicio->info || lista->inicio == NULL){
            llInsereNoInicio(lista, alvo);
            return lista;
        }
    //Caso o valor seja o ultimo:   
    
        if (alvo > lista->fim->info){
            llInsereNoFim(lista, alvo);
            return lista;
        }
    
    //Restante:
    while (aux != NULL) {
        
        if (alvo < aux->prox->info) {
            nova->prox = aux->prox; //a nova célula com o alvo aponta para a próxima celula do aux;
            aux->prox = nova; // O aux aponta para a nova celula;
            return lista;
        }
        aux = aux->prox;
    }
    return lista;
}

int main() {
    int qntValoresll, valoresll, valorll ;
    printf("Vamos criar uma lista! Digite quantos valores quer inserir nela:");
    scanf("%d", &qntValoresll);
    
    ListaLigada lista = novaLista();
    for (int i = 1; i <= qntValoresll; i++) {
        printf("Digite um número: ");
        scanf("%d", &valoresll);
        llInsereNoFim(lista, valoresll);
    }
    
   printf ("\nLista original: ");
   llPrint(lista);
   
   printf ("\nSoma da lista: ");
   somaLista(lista);
   
   printf ("\nLista Ordenada: ");
   bubbleSort(lista);
   llPrint(lista);
   
   printf("\nDigite um número para inserir na lista: ");
   scanf("%d", &valorll);
   insereOrdenado(lista, valorll);
   llPrint(lista);
    
    return 0;
}