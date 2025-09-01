# 🚀 Misoso API

![.NET](https://img.shields.io/badge/.NET%208-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-336791?style=for-the-badge&logo=postgresql&logoColor=white)
![License](https://img.shields.io/badge/License-MIT-green?style=for-the-badge)

**Misoso API** é uma aplicação backend desenvolvida com **ASP.NET Core 8** e **Entity Framework Core**, projetada para gestão de tarefas e autenticação segura.  
Este projeto pode ser executado tanto **localmente** quanto via **Docker**.

---

## 📦 Pré-requisitos

Antes de começar, certifique-se de ter instalado:

- [Git](https://git-scm.com/)
- [.NET SDK 8+](https://dotnet.microsoft.com/en-us/download)
- [Docker](https://www.docker.com/) *(opcional, para rodar via container)*
- [PostgreSQL](https://www.postgresql.org/) *(caso queira rodar o banco localmente)*

---

## 🔹 Clonar o repositório

```bash
git clone https://github.com/KatakiCodes/Misoso-api.git
cd Misoso-api
```
## 🔹 Restaurar dependências

```bash
dotnet restore
```

## 🔹 Executar as migrations

```bash
dotnet ef database update
```

## 🔹 Executar o projeto

```bash
dotnet run --project Misoso.Api.csproj
```

## 🔹 Executar o projeto (https)

```bash
dotnet run --project Misoso.Api.csproj --launch-profile https
```

## 🔹 A api estará rodando em:

```bash
[dotnet run --project Misoso.Api.csproj --launch-profile https](https://localhost:7247
http://localhost:5160
)
```
