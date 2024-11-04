
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

A `Empresas.API` segue a Onion Architecture, organizada em camadas concêntricas, onde cada camada é responsável por um conjunto específico de funcionalidades:

1. **Domain**: Contém todas as entidades, interfaces de repositório e lógica de domínio, independente de outras camadas, focando exclusivamente na lógica de negócio.
2. **Application**: Define os serviços de aplicação e as classes de manipulação de dados (DTOs), coordenando operações de negócios.
3. **Infrastructure**: Implementa persistência de dados (repositórios), configuração de contexto de banco de dados (`AppDbContext`) e integração com recursos externos.
4. **Presentation**: Contém APIs e controladores que expõem funcionalidades da aplicação, responsáveis pela comunicação com o mundo externo (requisições HTTP).

### Design Patterns Utilizados

- **Repository Pattern**: Separa a lógica de acesso a dados, facilitando a interação consistente com a base de dados.
- **Dependency Injection (IoC)**: Gerencia dependências entre camadas, facilitando testes e manutenção.
- **DTO (Data Transfer Object)**: Transporta dados entre as camadas, evitando o vazamento de entidades de domínio.

## Princípios de Clean Code e SOLID

### Clean Code
O projeto segue princípios de Clean Code, garantindo um código legível, bem organizado e de fácil manutenção. As convenções incluem nomes significativos para classes, métodos e variáveis, além de comentários concisos e clareza nos fluxos de lógica. Estas práticas facilitam a compreensão e a colaboração entre os desenvolvedores.

### SOLID

A aplicação adota os princípios SOLID para aprimorar a estrutura e manutenção do código:

1. **Single Responsibility Principle (SRP)**: Cada classe possui uma única responsabilidade, como as entidades do domínio (`Empresa`, `Endereco`) e os serviços de aplicação, que são focados em uma única tarefa.
2. **Open/Closed Principle (OCP)**: As classes estão abertas para extensão e fechadas para modificação. Por exemplo, novos serviços podem ser adicionados sem alterar a estrutura central.
3. **Liskov Substitution Principle (LSP)**: Classes derivadas substituem suas classes base sem alterar o comportamento do sistema.
4. **Interface Segregation Principle (ISP)**: Interfaces específicas são criadas para diferentes necessidades, evitando interfaces "infladas".
5. **Dependency Inversion Principle (DIP)**: A injeção de dependência gerencia as interações entre classes, desacoplando as camadas e facilitando a testabilidade.

## Integração com API Externa ViaCEP

O projeto integra-se com a API ViaCEP para busca de endereços por CEP. Essa integração permite que o `EnderecoService` obtenha dados de endereço automaticamente, oferecendo uma experiência de usuário mais prática.

### Exemplo de Utilização da API ViaCEP

Ao cadastrar ou atualizar um endereço, o sistema consulta a API ViaCEP:

1. O `EnderecoService` faz uma chamada HTTP à ViaCEP com o CEP fornecido.
2. A API retorna informações detalhadas (logradouro, bairro, cidade, etc.).
3. Esses dados são salvos no sistema, evitando a entrada manual de dados e reduzindo possíveis erros.

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

   - **Importante**: Substitua as credenciais com suas próprias credenciais do banco de dados.

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

## Testes

A `Empresas.API` utiliza uma suite de testes automatizados para validar as funcionalidades principais, garantindo a consistência e confiabilidade do sistema. Os testes cobrem:

- **`EnderecoService`**: Testa a integração com a API ViaCEP, garantindo que os dados retornados estão corretos e são salvos adequadamente.
- **`UsuarioService`**: Realiza testes de criação, atualização e deleção de usuários, verificando as regras de negócios aplicadas e a integridade dos dados.

Os testes podem ser executados com o comando:

```bash
dotnet test
```

Este comando executará todos os testes definidos no projeto de teste, exibindo um relatório detalhado sobre o sucesso ou falha de cada caso.

## Contato

Para qualquer dúvida ou sugestão, entre em contato com [caiorrodrigues2004@gmail.com](mailto:caiorrodrigues2004@gmail.com).
