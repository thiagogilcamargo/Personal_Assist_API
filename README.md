# Personal Assist API

## Integrantes do Grupo


- **Cauã Couto Basques** (RM97755)
- **Kaique Agostinho de Oliveira** (RM550815)
- **Leonardo Matheus Mariano** (RM99824)
- **Thiago Gil Camargo** (RM551211)

## Arquitetura

A API foi desenvolvida utilizando a arquitetura **Monolítica**. Essa abordagem foi escolhida devido à sua simplicidade e facilidade de integração inicial, considerando que o projeto está na fase de desenvolvimento e a complexidade dos serviços não justifica a divisão em microserviços neste momento.

### Design Patterns Utilizados

- **Singleton**: Utilizado para garantir que haja uma única instância do gerenciador de configurações.
- **Repository Pattern**: Implementado para abstrair a lógica de acesso a dados, permitindo um código mais limpo e fácil de manter.
- **Factory Pattern**: Utilizado para a criação de instâncias de objetos relacionados a diferentes tipos de serviços.

## Endpoints

### 1. Empresas

- **GET** `/api/empresas` - Obtém a lista de todas as empresas.
- **GET** `/api/empresas/{id}` - Obtém uma empresa específica por ID.
- **POST** `/api/empresas` - Cria uma nova empresa.
- **PUT** `/api/empresas/{id}` - Atualiza uma empresa existente.
- **DELETE** `/api/empresas/{id}` - Remove uma empresa.

### 2. Feedback

- **GET** `/api/feedbacks` - Obtém a lista de todos os feedbacks.
- **GET** `/api/feedbacks/{id}` - Obtém um feedback específico por ID.
- **POST** `/api/feedbacks` - Cria um novo feedback.
- **PUT** `/api/feedbacks/{id}` - Atualiza um feedback existente.
- **DELETE** `/api/feedbacks/{id}` - Remove um feedback.

### 3. Serviços

- **GET** `/api/servicos` - Obtém a lista de todos os serviços.
- **GET** `/api/servicos/{id}` - Obtém um serviço específico por ID.
- **POST** `/api/servicos` - Cria um novo serviço.
- **PUT** `/api/servicos/{id}` - Atualiza um serviço existente.
- **DELETE** `/api/servicos/{id}` - Remove um serviço.

### 4. Suporte

- **GET** `/api/suportes` - Obtém a lista de todos os suportes.
- **GET** `/api/suportes/{id}` - Obtém um suporte específico por ID.
- **POST** `/api/suportes` - Cria um novo suporte.
- **PUT** `/api/suportes/{id}` - Atualiza um suporte existente.
- **DELETE** `/api/suportes/{id}` - Remove um suporte.

## Instruções para Rodar a API

1. **Clone o repositório:**

    ```bash
    git clone https://github.com/thiagogilcamargo/Personal_Assist_API.git
    cd Personal_Assist_API
    ```

2. **Instale as dependências:**

    Certifique-se de ter o [SDK do .NET Core](https://dotnet.microsoft.com/download) instalado.

    ```bash
    dotnet restore
    ```

3. **Configure o banco de dados:**

    Certifique-se de que o banco de dados Oracle está acessível e configure a string de conexão no arquivo `appsettings.json`.

4. **Execute as migrações:**

    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```

5. **Execute a aplicação:**

    ```bash
    dotnet run
    ```

    A API estará disponível em `https://localhost:5001` (ou o URL configurado).

## Notas Adicionais

- Certifique-se de que a API está acessível no URL configurado e que o firewall permite conexões na porta apropriada.
- Para testar os endpoints, você pode usar ferramentas como [Postman](https://www.postman.com/) ou [cURL](https://curl.se/).

