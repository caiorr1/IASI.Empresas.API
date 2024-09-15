
# Empresas.API

## Integrantes do Grupo

- **Caio Ribeiro Rodrigues** - RM: 99759
- **Guilherme Riofrio Quaglio** - RM: 550137
- **Elen Cabral** - RM: 98790
- **Mary Speranzini** - RM: 550242
- **Eduardo Jablinski** - RM: 550975

## Visão Geral do Projeto

A `Empresas.API` é uma aplicação de backend que gerencia dados de empresas, contatos, documentos, endereços, relatórios, tipos de relatórios, setores e usuários. A API é construída utilizando a arquitetura Onion (Cebola), garantindo uma separação clara de responsabilidades, além de facilitar a manutenção e a escalabilidade do sistema.

## Arquitetura

### Onion Architecture (Arquitetura em Camadas)

A `Empresas.API` segue a Onion Architecture, que é organizada em camadas concêntricas, onde cada camada é responsável por um conjunto específico de funcionalidades. As camadas são as seguintes:

1. **Domain**:
   - Contém todas as entidades, interfaces de repositório, e lógica de domínio. Esta camada é independente de qualquer outra, focando exclusivamente na lógica de negócio.

2. **Application**:
   - Define os serviços de aplicação e as classes de manipulação de dados (DTOs). Essa camada coordena as operações de negócios (como criação e atualização de dados) sem conhecer detalhes de como os dados são armazenados.

3. **Infrastructure**:
   - Implementa a persistência de dados (repositórios), configuração de contexto do banco de dados (`AppDbContext`), e qualquer interação com recursos externos (como serviços de terceiros). É a camada que depende das tecnologias específicas.

4. **Presentation**:
   - Contém as APIs e controladores que expõem as funcionalidades da aplicação. Esta camada é responsável pela comunicação com o mundo externo (requisições HTTP).

### Design Patterns Utilizados

- **Repository Pattern**: Utilizado para separar a lógica de acesso a dados e permitir uma interação consistente com a base de dados.
- **Dependency Injection (IoC)**: Utilizado para gerenciar dependências entre as camadas e facilitar testes e manutenção.
- **DTO (Data Transfer Object)**: Usado para transportar dados entre as camadas de aplicação e apresentação, evitando o vazamento de entidades de domínio para o mundo externo.

## Instruções para Rodar a API

### Pré-requisitos

- .NET 8 SDK
- Visual Studio 2022 (ou mais recente) ou Visual Studio Code
- Banco de Dados Oracle (com as credenciais configuradas)

### Instalação

1. Clone o repositório para sua máquina local:

   ```bash
   git clone https://github.com/seu-usuario/Empresas.API.git
   cd Empresas.API
   ```

2. Navegue até o diretório da solução e restaure as dependências:

   ```bash
   dotnet restore
   ```

3. Configure o banco de dados Oracle:

   - Edite o arquivo `appsettings.json` na camada `Presentation` e configure a `ConnectionString`:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "User Id=RM99759;Password=260404;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=oracle.fiap.com.br)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ORCL)));"
     }
   }
   ```

   - **Importante**: Lembre-se de substituir as credenciais com as suas próprias credenciais do banco de dados.

4. Realize as Migrations do banco de dados:

   ```bash
   dotnet ef migrations add InitialMigration
   dotnet ef database update
   ```

5. Compile e execute a aplicação:

   ```bash
   dotnet run --project IASI.Empresas.API
   ```

### Acessando a API

Após executar o comando `dotnet run`, a API estará disponível em:

```
http://localhost:{porta}/swagger/index.html
```

Acesse o endereço acima em seu navegador para utilizar a documentação interativa (Swagger UI) e testar os endpoints da API.

### Testando a API

A `Empresas.API` utiliza o Swagger para expor os endpoints de forma interativa. Abra a URL fornecida após executar a API e você verá a documentação da API com opções para testar cada endpoint.

## Contato

Para qualquer dúvida ou sugestão, entre em contato com [seu-email@exemplo.com](mailto:caiorrodrigues2004@gmail.com).
