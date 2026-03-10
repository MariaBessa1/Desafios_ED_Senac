
#include<stdio.h>
#include<stdlib.h>

struct no {
    int info;         
    struct no * prox;
};

struct no * novoNo(int info) {
    struct no * novo = malloc(sizeof(struct no));
    novo->info = info;
    return novo;
}

struct no * insert_first(struct no * lista, int info) {
    struct no *novo = novoNo(info);
    if (!novo) return lista;   // se falhar, mantém a lista como estava
    novo->prox = lista;        // novo aponta para a antiga cabeça
    return novo;               // novo vira a cabeça
}

void insert_last(struct no * lista, int info) {
    struct no *novo = novoNo(info);
    // Precisamos encontrar o último elemento da lista. Quando encontramos, adicionamos o novo!
    struct no *curr = lista;
    while (curr->prox != NULL) {
        curr = curr->prox;
    }
    curr->prox = novo;
}

void print_list (struct no * lista){
    struct no *curr = lista;
    while (curr != NULL) {
        printf("%d \n", curr -> info);
        curr = curr->prox;
    }
}

struct no * remove_first(struct no * lista) {
    if (lista == NULL) return NULL; // lista vazia

    struct no *novo_inicio = lista->prox;
    return novo_inicio;
}

struct no * remove_last(struct no * lista) {
    if (lista == NULL) return NULL; // lista vazia

    struct no *curr = lista;
    while (curr->prox->prox != NULL) { 
        curr = curr->prox;
    }
      curr->prox = NULL; 
      return lista;
}

//---------------------------DESAFIO AQUI----------------------------------------

struct no * remove_value(struct no *lista, int value) {
    struct no *curr = lista; //Cria o curr e o atribui no início da lista
    
    //CASO O VALOR A SER REMOVIDO SEJA O PRIMEIRO
    if (lista->info == value) { //se o primeiro valor da lista já for o que vai ser removido...
    struct no* removePrimeiro = lista->prox; //A lista recebe o próximo nó, "desconectando" com o anterior e o removendo
    return removePrimeiro;
    }

    //RESTANTE
    while (curr != NULL) {

        if (curr->prox->info == value) { //Se o valor do próximo nó for o valor que vai ser removido...
            struct no *temporario = curr->prox; //"Temporário" aponta para esse próximo nó
            curr->prox = temporario->prox; // o próximo nó do curr será o próximo do temporário
            free(temporario); // o nó com o valor removido é apagado
            return lista;
        }
        curr = curr->prox;
    }
     return lista;
}


int main() {
    struct no * lista = novoNo(1);
    insert_last(lista, 2);
    insert_last(lista, 3);

    int valorRemover;
    printf("Digite um valor da lista que deseja remover:");
    scanf("%d", &valorRemover);
    lista = remove_value(lista, valorRemover);
    print_list(lista);
    return 0;
}