---

# 🚀 **API de Cadastro de Usuários (CRUD)**

## 🎯 **Objetivo do Projeto**
A **API de Cadastro de Usuários** tem como objetivo permitir a criação, listagem, atualização e exclusão de usuários. O projeto foi desenvolvido com foco no aprendizado e no uso de **listagem em memória** para armazenar os dados, sem o uso de banco de dados real ou ORM como o **Entity Framework**. Ao invés disso, a **classe Banco de Dados** foi criada para simular o armazenamento de dados em listas, oferecendo uma abordagem simples e eficaz para fins de estudo.

## 💻 **Funcionalidades**
Esta API oferece as seguintes operações para gerenciamento de usuários:

- **Criar Usuário** ✍️
- **Listagem de Usuários** 📜
- **Atualizar Usuário** 🔄
- **Buscar Usuário** 🔍
- **Deletar Usuário** ❌

## 📦 **Estrutura de Dados**
A **Entidade Usuário** foi definida com os seguintes atributos:

- `Nome`: string
- `CPF`: string
- `Email`: string
- `Senha`: string

### **Classe Banco de Dados** 🗃️
Para simular o armazenamento de dados, a classe **Banco de Dados** foi criada para armazenar os objetos de **usuário** em uma lista simples, sem a necessidade de um banco de dados real.

## 🔧 **Comportamentos da API**

A **API de Cadastro de Usuários** implementa os seguintes comportamentos de operação:

### **Usuários**
- **Adicionar Usuários**: Adiciona um novo usuário à lista.
- **Obter Usuários**: Retorna a lista de todos os usuários cadastrados.
- **Obter Usuário por ID**: Retorna um usuário específico com base no ID.
- **Deletar Usuário por ID**: Remove um usuário específico pela sua ID.

### **Operações da API**:
- **Criar Usuário**: Endpoint para criar um novo usuário.
- **Listagem de Usuários**: Endpoint que retorna todos os usuários cadastrados.
- **Atualizar Usuário**: Endpoint para atualizar os dados de um usuário existente.
- **Buscar Usuário**: Endpoint para buscar um usuário específico pelo ID.
- **Deletar Usuário**: Endpoint para remover um usuário do sistema.

## ⚙️ **Tecnologias Usadas**
- **ASP.NET Core** 🖥️
- **C#** 💻
- **Listas em Memória** 🗂️ (para simulação de banco de dados)

## 🛠️ **Ferramentas Utilizadas**
- **Postman** 🔧 (para testes de API)
- **Swagger** 🌐 (para documentação e envio de requisições)

## 📥 **Como Executar o Projeto**
1. Clone o repositório:  
   `git clone https://github.com/Ti7801/UserRegisterApi.git`
   
2. Abra o projeto no Visual Studio ou no editor de sua preferência.

3. Compile e execute o projeto.

4. Utilize o **Postman** ou o **Swagger** para enviar as requisições.

---

Esse `README.md` proporciona uma explicação clara e organizada sobre o seu projeto, destacando suas funcionalidades, tecnologias e como utilizá-lo. Sinta-se à vontade para adaptar conforme necessário!
