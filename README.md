🚀 API de Gestão de Funcionários
API RESTful desenvolvida em .NET 8 seguindo os princípios de DDD, Clean Architecture, Entity Framework Core e Autenticação JWT.

📌 Tecnologias utilizadas
.NET 8
Entity Framework Core
SQL Server (Docker)
MediatR
JWT (Json Web Token)
Docker & Docker Compose

-------------------------------------------------------------------------------

📦 Como Rodar o Projeto

1. Clonar o repositório
git clone https://github.com/seu-usuario/seu-repositorio.git
cd seu-repositorio

2. Configurar o Banco de Dados (SQL Server)
docker-compose up -d

3. Criar e Aplicar Migrations
dotnet ef migrations add Inicial
dotnet ef database update

4. Rodar a API
dotnet run --project ambev.Api

5. Criar a imagem no Docker
docker build --no-cache -t ambev-api .

6. Rodar o Container
docker run -d -p 5000:5000 --name ambev-container-netcore ambev-api

🛠 Endpoints Disponíveis
Método	Endpoint	Descrição
POST	/api/auth/login	Autenticação e geração do JWT
GET	/api/funcionarios	Listar funcionários
POST	/api/funcionarios	Criar um funcionário
PUT	/api/funcionarios/{id}	Atualizar funcionário
DELETE	/api/funcionarios/{id}	Deletar funcionário
Para testar os endpoints, você pode usar o Swagger, disponível em:
🔗 http://localhost:5000/swagger


--------------------------------------------------------------------------------
1. Testes
dotnet test

--------------------------------------------------------------------------------
📜 Licença
Este projeto é de código aberto e está sob a licença MIT.

Agora seu README.md está pronto para ser usado no GitHub! 🚀
