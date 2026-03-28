# Projeto Minhas Compras - .NET MAUI + SQLite

## Descrição do Projeto
O **Minhas Compras** é um aplicativo desenvolvido em **.NET MAUI** que permite o gerenciamento de produtos de forma simples e prática. Ele permite cadastrar, editar, remover e consultar produtos, além de realizar filtragens por categoria e calcular totais gerais ou por categoria.  

O aplicativo é ideal para controle de estoque, lista de compras ou pequenos negócios que precisam de um registro rápido de produtos.

---

## Tecnologias Utilizadas
- **.NET MAUI**: framework para desenvolvimento multiplataforma (Android, iOS, Windows, Mac).  
- **C#**: linguagem principal do projeto.  
- **SQLite**: banco de dados local para armazenamento de produtos.  
- **MVVM simplificado**: organização em pastas `Models`, `Views` e `Helpers`.

---


## Funcionalidades

O aplicativo oferece as seguintes funcionalidades:

### 1. Cadastro de Produtos
- Campos: **Descrição, Categoria, Preço, Quantidade**.  
- Cada produto possui um **ID único** gerado automaticamente.  
- Salva os produtos diretamente no banco **SQLite**.

### 2. Edição e Remoção
- Permite **editar qualquer produto existente** selecionando na lista.  
- Permite **remover produtos** através do menu contextual.

### 3. Busca
- **Busca por ID ou descrição**: usando a `SearchBar`.  
- **Busca por categoria**: usando o `Picker` para filtrar produtos.

### 4. Relatórios
- **Total geral**: soma de todos os produtos cadastrados.  
- **Total por categoria**: soma agrupada por categoria (ex.: Lazer: R$..., Alimentos: R$...).  
- Exibe resultados em `DisplayAlert` para visualização rápida.

---
# 🛒 MauiAppMinhasCompras

Uma aplicação moderna desenvolvida em **.NET MAUI** para gerenciamento de listas de compras, permitindo o controle total de produtos, categorias e valores diretamente no seu dispositivo.

---

## 🛠️ Funcionalidades

### 🗄️ Helpers - `DbHelper.cs`
A camada de persistência utiliza SQLite para gerenciar os dados localmente:
* **`GetAll()`**: Retorna todos os produtos cadastrados.
* **`GetById(int id)`**: Busca um produto específico pelo ID.
* **`GetByCategoria(string categoria)`**: Filtra produtos por categoria.
* **`Search(string query)`**: Busca produtos por texto na descrição.
* **`Insert(Produto p)`**: Adiciona um novo produto ao banco.
* **`Update(Produto p)`**: Edita as informações de um produto existente.
* **`Delete(int id)`**: Remove um produto do sistema.

### 📱 Telas e Views

#### **ListaProduto.xaml**
* Listagem completa de produtos com `ListView`.
* Filtros dinâmicos por categoria.
* **Ações:**
    * **Adicionar**: Abre a tela de cadastro.
    * **Somar**: Exibe o valor total de todos os itens.
    * **Total por Categoria**: Soma agrupada para melhor controle financeiro.

#### **NovoProduto.xaml**
* Interface para cadastro de novos itens.
* **Campos:** Descrição, Categoria, Preço e Quantidade.

#### **EditarProduto.xaml**
* Interface intuitiva para atualizar dados de produtos já existentes no banco.

---

## 🚀 Instalação e Execução

### Pré-requisitos
* **Visual Studio 2022** (com a carga de trabalho .NET MAUI instalada).
* **SDK do .NET 7.0** ou superior.
* Emulador Android/iOS ou dispositivo físico configurado.

### Passo a Passo

1. **Clonar o projeto**
   ```bash
   git clone https://github.com/SilahtGm/MauiAppMinhasCompras.git
   
2.  **Abrir no Visual Studio**
  
Abrir a solução .sln no Visual Studio.
Restaurar pacotes NuGet. 

3. **Executar**
Selecionar plataforma (Android/iOS/Windows).
Build e run (F5 ou Ctrl+F5).
---

## Banco de Dados SQLite

O projeto utiliza SQLite para armazenamento local.  

Exemplo da classe `Produto.cs`:

```csharp
public class Produto
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Descricao { get; set; }

    public string Categoria { get; set; }

    public double Preco { get; set; }

    public int Quantidade { get; set; }

    [Ignore]
    public double Total => Preco * Quantidade;
}


