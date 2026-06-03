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
        printf("%d ", curr -> info);
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

struct no * remove_value(struct no *lista, int value) {
    struct no *curr = lista;
    
    //CASO O VALOR A SER REMOVIDO SEJA O PRIMEIRO
    if (lista->info == value) {
    struct no* removePrimeiro = lista->prox;
    return removePrimeiro;
    }

    //RESTANTE
    while (curr->prox != NULL) {

        if (curr->prox->info == value) {
            struct no *temporario = curr->prox; 
            curr->prox = temporario->prox;
            free(temporario);
            return lista;
        }
        curr = curr->prox;
    }
     return lista;
}

//---------------------------DESAFIO AQUI----------------------------------------

struct no* reverse_list (struct no* lista) {
    struct no* novaLista_invertida = NULL; //cria uma nova lista com valor inicial nulo
    struct no* curr = lista; //Cria o curr e o atribui no início da lista
    
    while (curr != NULL) {
        novaLista_invertida = insert_first (novaLista_invertida, curr->info); //Vai construindo uma nova lista sempre pegando
        curr = curr->prox;                                                    // o próximo valor da original com o curr->info e inserindo  
    }                                                                         //no início da invertida utilizando a função já criada "insert_first". :D
    return novaLista_invertida;                              
}

int main() {
    struct no * lista = novoNo(1);
    insert_last(lista, 2);
    insert_last(lista, 3);

    int valorRemover;
   // printf("Digite um valor da lista que deseja remover:");
   // scanf("%d", &valorRemover);
   // lista = remove_value(lista, valorRemover);
   // print_list(lista);
   
   printf ("Lista original: ");
   print_list (lista);

    lista = reverse_list(lista);
   printf ("\nLista reversa: ");
   print_list (lista);
  
    return 0;
}