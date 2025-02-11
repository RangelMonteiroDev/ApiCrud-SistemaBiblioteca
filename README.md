# MyFirstMVC

Este projeto é uma aplicação MVC em .NET Core conectada ao SQL Server rodando em um container Docker. Ele permite operações CRUD (Create, Read, Update, Delete) em uma entidade chamada `Localizacao`.

## 🚀 Tecnologias Utilizadas

- .NET Core
- Entity Framework Core
- SQL Server (Docker)
- Docker

## 📦 Pré-requisitos

Antes de começar, você precisará ter instalado em sua máquina:

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Docker](https://www.docker.com/get-started)

## 🔧 Configuração do Banco de Dados

1. **Suba o container do SQL Server:**

   ```bash
   docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=YourPassword123" -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest
   ```

   Certifique-se de que a senha atenda aos requisitos do SQL Server.

2. **Configure a string de conexão em ****`appsettings.json`****:**

   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=SistemaBiblioteca;User Id=sa;Password=YourPassword123;TrustServerCertificate=True"
   }
   ```

3. **Aplique as migrações e atualize o banco de dados:**

   ```bash
   dotnet ef database update
   ```

## ▶️ Como Rodar o Projeto

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/MyFirstMVC.git
   cd MyFirstMVC
   ```
2. Restaure os pacotes necessários:
   ```bash
   dotnet restore
   ```
3. Execute a aplicação:
   ```bash
   dotnet run
   ```

A aplicação estará disponível em `http://localhost:5000` (ou na porta indicada pelo terminal).

## 🛠️ Endpoints Disponíveis

### Criar (Create)

- **Método:** `POST`
- **URL:** `http://localhost:5000/Localizacao/Create`
- **Body (JSON):**
  ```json
  {
    "Cidade": "São Paulo",
    "Estado": "SP",
    "Cep": "01000-000",
    "Nacionalidade": "Brasileira"
  }
  ```

### Listar (Read)

- **Método:** `GET`
- **URL:** `http://localhost:5000/Localizacao/GetAll`

### Atualizar (Update)

- **Método:** `PUT`
- **URL:** `http://localhost:5000/Localizacao/Update/{id}`
- **Body (JSON):**
  ```json
  {
    "Cidade": "Rio de Janeiro",
    "Estado": "RJ",
    "Cep": "22000-000",
    "Nacionalidade": "Brasileira"
  }
  ```

### Deletar (Delete)

- **Método:** `DELETE`
- **URL:** `http://localhost:5000/Localizacao/Delete/{id}`

## 📌 Observações

- Se você precisar alterar as configurações do banco de dados, edite o arquivo `appsettings.json`.
- Certifique-se de que o container do SQL Server está rodando antes de iniciar a aplicação.

## 📝 Licença

Este projeto é de código aberto e pode ser modificado conforme necessário. 😊

Fique a vontade para usar esse projeto, o conhecimento deve ser livre e distribuído.
