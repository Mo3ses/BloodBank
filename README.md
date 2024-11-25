# 🩸 BloodBank - Web API

Bem-vindo ao **BloodBank**, um projeto desenvolvido em **ASP.NET Core (.NET 8)** com foco em boas práticas, organização e escalabilidade. Esta API foi projetada para gerenciar bancos de sangue, possibilitando o cadastro de doadores, consultas e controle de estoques de forma eficiente e segura.

---

## 🚀 **Funcionalidades**

- 📝 **Cadastro e consulta de doadores** com dados armazenados diretamente no SQL Server.
- 🎯 **Migrations automáticas** usando o estilo **Code First**, garantindo flexibilidade para evoluir o esquema do banco de dados.
- 📦 **Result Pattern** implementado para padronizar as respostas da API.

---

## 🛠️ **Tecnologias Utilizadas**

- **ASP.NET Core (.NET 8)**: Para criação da API.
- **Entity Framework Core**: Para mapeamento objeto-relacional (ORM) e migrações.
- **SQL Server**: Banco de dados utilizado no projeto.
- **FluentValidation** (planejado): Para validações consistentes.
- **Clean Architecture**: Organização das camadas para melhor manutenção e escalabilidade.
- **Padrões de Projeto**: Result Pattern, com outros padrões planejados como Unit of Work e CQRS.

---

## 📂 **Estrutura do Projeto**

O projeto segue os princípios da **Clean Architecture**, com as seguintes camadas:

1. **Domain**: Contém as regras de negócio e entidades principais.
2. **Application**: Camada de lógica de aplicação, incluindo DTOs e validações (com FluentValidation planejado).
3. **Infrastructure**: Implementação de acesso a dados com o Entity Framework Core.
4. **API**: A interface pública para consumidores da aplicação.

---

## 🚀 **Como Rodar o Projeto**

### Pré-requisitos

- **.NET SDK 8** instalado.
- **SQL Server** configurado.
- Ferramenta como **Postman** ou **Swagger** para testar a API.

### Passos

1. **Clone o repositório**:

   ```bash
   git clone https://github.com/seu-usuario/bloodbank.git
   cd bloodbank
   ```

2. **Configure o banco de dados**:
   Edite o arquivo `appsettings.json` com sua string de conexão:

   ```json
   "ConnectionStrings": {
       "BloodBankCs": "Server=.;Database=BloodBank;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```

3. **Aplique as migrations**:

   ```bash
   dotnet ef database update
   ```

4. **Execute a aplicação**:

   ```bash
   dotnet run
   ```

5. **Acesse a API**:
   - Use o **Swagger UI** em: `http://localhost:{porta}/swagger`
   - Ou teste via Postman.

---

## 🧩 **Próximos Passos**

- [ ] Implementar validações com **FluentValidation**.
- [ ] Adicionar suporte ao padrão **Unit of Work**.
- [ ] Implementar **CQRS** para separar consultas e comandos.
- [ ] Criar **testes unitários** para aumentar a confiabilidade do código.
- [ ] Melhorar autenticação com **JWT**.

---

## 🤝 **Contribuição**

Contribuições são bem-vindas! Se você tiver sugestões ou encontrar problemas, sinta-se à vontade para abrir uma _issue_ ou enviar um _pull request_.

---

## 📝 **Licença**

Este projeto está licenciado sob a **MIT License**. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
