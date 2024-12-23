# DotNetFlix

DotNetFlix é uma API RESTful desenvolvida com ASP.NET Core e Entity Framework Core. O objetivo principal é gerenciar filmes e o processo de aluguel de filmes, permitindo funcionalidades como listar filmes, alugar filmes e associar notas a locações.

---

## **Tecnologias Utilizadas**

- **C#**
- **ASP.NET Core**
- **Entity Framework Core**
- **SQL Server**
- **Dependency Injection**
- **DTOs (Data Transfer Objects)**
- **Task-Based Asynchronous Pattern (TAP)**

---

## **Como Rodar o Projeto**

### **Pré-requisitos**

1. **.NET SDK** instalado (versão 7.0 ou superior).
2. **SQL Server** configurado.
3. Um editor de código, como Visual Studio ou Visual Studio Code.

### **Configuração do Banco de Dados**

1. Configure a string de conexão no arquivo `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SEU_SERVIDOR;Database=DotNetFlix;Trusted_Connection=True;"
  }
}
```

2. Execute as migrações para criar o banco de dados:

```bash
cd DotNetFlix
dotnet ef database update
```

### **Iniciar o Projeto**

1. Compile e execute a API:

```bash
dotnet run
```

2. A API estará acessível no endpoint: `http://localhost:5000` ou `https://localhost:5001`.

---

## **Endpoints Disponíveis**

### **Filmes**

#### **Listar todos os filmes**

- **GET** `/api/Film/ListarFilmes`
- **Descrição:** Retorna todos os filmes cadastrados.
- **Exemplo de Resposta:**

```json
{
  "status": true,
  "mensagem": "Filmes encontrados!",
  "dados": [
    {
      "id": 1,
      "titulo": "O Poderoso Chefão",
      "genero": "DRAMA",
      "ano": 1972
    }
  ]
}
```

#### **Listar filmes por gênero**

- **GET** `/api/Film/ListarFilmesPorGenero{gender}`
- **Descrição:** Retorna filmes filtrados pelo gênero especificado.

#### **Obter informações de um filme**

- **GET** `/api/Film/ListarInfoFilme{id}`
- **Descrição:** Retorna as informações detalhadas de um filme baseado no ID.

---

### **Aluguel**

#### **Alugar um filme**

- **POST** `/api/Rental/AlugarFilme{IdFilm}/{IdUser}`
- **Descrição:** Permite que um usuário alugue um filme.

#### **Associar nota a um aluguel**

- **PUT** `/api/Rental/AssociarNota`
- **Descrição:** Permite que o usuário associe uma nota ao aluguel de um filme.
- **Payload:**

```json
{
  "idRental": 1,
  "nota": 5
}
```

#### **Listar filmes alugados por um usuário**

- **GET** `/api/Rental/ListarFilmesAlugados?id={id}`
- **Descrição:** Retorna todos os filmes alugados por um usuário.

---

## **Modelos Principais**

### **FilmModel**

```csharp
public class FilmModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Gender { get; set; }
    public int Year { get; set; }
}
```

### **RentalModel**

```csharp
public class RentalModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int FilmId { get; set; }
    public DateTime RentalDate { get; set; }
    public int? Rating { get; set; }
}
```

---

## **Erros Comuns**

1. **String de conexão inválida:** Verifique se o `appsettings.json` está configurado corretamente.
2. **Banco de dados não migrado:** Certifique-se de executar `dotnet ef database update` antes de iniciar a API.

---

## **Contribuição**

1. Faça um fork do repositório.
2. Crie um branch para sua feature/bugfix:

```bash
git checkout -b minha-feature
```

3. Commit suas alterações:

```bash
git commit -m "Adiciona nova funcionalidade X"
```

4. Envie o branch para o repositório remoto:

```bash
git push origin minha-feature
```

5. Abra um Pull Request.

---

## **Licença**

Este projeto está sob a licença MIT. Consulte o arquivo LICENSE para mais informações.

