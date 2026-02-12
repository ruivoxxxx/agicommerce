 *Agicommerce API* 


**API RESTful desenvolvida em .NET 8 para gerenciar o backend da plataforma de e-commerce Agicommerce. 
Este projeto serve dados para o frontend em React, implementando operações de CRUD completas com validações e persistência de dados.**



**Instalação e Execução:** 

Siga este passo a passo para rodar a API na sua máquina local.

Pré-requisitos
Ter o .NET 8 SDK instalado.

Um editor de código (VS Code ou Visual Studio).

Passo 1: Clonar e Acessar
Abra o terminal e clone o repositório (ou baixe os arquivos):


git clone https://github.com/ruivoxxxx/agicommerce



Passo 2: Restaurar Dependências
Baixe os pacotes do NuGet necessários (EF Core, Swagger, etc):

dotnet restore



Passo 3: Configurar o Banco de Dados
Como estamos usando SQLite e Migrations, precisamos criar o arquivo do banco de dados baseando-se no código atual. Execute:

dotnet ef database update
Isso criará automaticamente o arquivo ecommerce.db na raiz do projeto.



Passo 4: Executar a API
Inicie o servidor local
dotnet run



Passo 5: Testar (Swagger)
Para testar as rotas, abra o navegador no endereço mostrado no terminal adicionando /swagger ao final.

Lá você poderá testar

POST /api/produtos: Cadastrar um novo produto.
GET /api/produtos: Listar todos os produtos.
GET /api/produtos{id}:Lista produto by id.
PUT /api/produtos/{id}: Atualizar estoque ou preço.
DELETE /api/produtos/{id}: Remover um produto.




 
**Tecnologias Utilizadas**

.NET 8.0 (LTS)
ASP.NET Core Web API
Entity Framework Core 8.0
SQLite 
Swagger UI 
Data Annotations

Estrutura do Projeto
A arquitetura segue o padrão de camadas para garantir a separação de responsabilidades (SoC):



/agicommerce-api

 Controllers/     Recebem as requisições HTTP (GET, POST, etc.)
 Models/          Classes de domínio e validações (ex: Produto.cs)
 Data/            Contexto do Banco de Dados (AppDbContext)
 Services/        Regras de negócio (Intermediário entre Controller e Banco)
 Migrations/      Histórico de versionamento do Schema do banco
 appsettings.json  Configuração da ConnectionString do SQLite
 Program.cs       Configuração de Injeção de Dependência e Middleware




**Decisões Técnicas**

1- Modelagem e Validação 
Optei por utilizar Data Annotations ([Required], [MaxLength], [Range]) diretamente na classe Produto.
Centraliza a regra de negócio e a definição da tabela do banco no mesmo lugar. 

2. Camada de Services
Em vez de colocar a lógica dentro do Controller, criei uma pasta Services,
para desacoplar. O Controller fica apenas com a responsabilidade dos protocolos HTTP (status 200, 404) 
o Services ficam responsaveis pela parte da lógica.

3. Banco de Dados SQLite
Escolhido pela facilidade de criação do banco e rapidez, por conta de ser um arquivo local e não necessitar de instalação de servidor. 




**Desafios durante desenvolvimento**


1- Compreender a estrutura do Program.cs e configurar corretamente o pipeline de execução da aplicação. 
Foi necessário ajustar os Middlewares para garantir que o Swagger funcionasse corretamente para a documentação e que as rotas HTTP fossem mapeadas como esperado.

2- Garantir que o AppDbContext e o ProdutoService fossem registrados corretamente no contêiner de serviços (builder.Services.AddScoped...) para que pudessem ser injetados automaticamente nos Controllers, evitando o alto acoplamento.

3- Ajustar os tipos de dados para garantir precisão, especialmente o uso de decimal para preços, evitando erros de arredondamento comuns em bancos de dados baseados em arquivo.






