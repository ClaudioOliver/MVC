📟Criação do banco de dados automatomatica atraves do Entity Framework (Models): Via Migrations
    
    Para adicionar a Migrations : dotnet ef migrations add AdcionaTabelas    
    Para Executar a Migrations : dotnet ef database update   

📟Criação do Banco de Dados:

📘Criação via Script Banco de dados:

    CREATE DATABASE EnderecoDB;
    USE EnderecoDB;



📘Criar Tabela Usuario:

    CREATE TABLE Usuarios (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(255) NOT NULL,
    login VARCHAR(255) UNIQUE NOT NULL,
    senha VARCHAR(255) NOT NULL
);



📘Criar Tabela Endereços

    CREATE TABLE Enderecos (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Cep VARCHAR(8) NOT NULL,
    Logradouro VARCHAR(255) NOT NULL,
    Bairro VARCHAR(255) NOT NULL,
    Cidade VARCHAR(255) NOT NULL,
    Uf VARCHAR(2) NOT NULL,
    Numero INT NOT NULL,
    usuario_id INT NOT NULL,
    FOREIGN KEY (LoginID) REFERENCES Usuarios(Id)
);



🎯TELAS DO SISTEMA MVC:🎯

📘TELA DE LOGIN:

![image](https://github.com/ClaudioOliver/MVC/assets/115963003/0096295a-6635-40fa-a35b-a4d134f14057)


📘REGISTRAR NOVO USÚARIO:

![image](https://github.com/ClaudioOliver/MVC/assets/115963003/cc3e6403-74e0-46c5-94bf-3c8773e676f8)


📘LISTAGEM DE ENDEREÇOS:

![image](https://github.com/ClaudioOliver/MVC/assets/115963003/0eb315ab-ab32-42a9-8a9f-74b8fbd63475)


📘EDITAR ENDEREÇO:

![image](https://github.com/ClaudioOliver/MVC/assets/115963003/caf76be6-8a9d-4fde-962a-4f858781c4a5)


📘DELETAR ENDEREÇO:

![image](https://github.com/ClaudioOliver/MVC/assets/115963003/3304075e-ef38-4cfe-addc-3c799be932a3)


📘EXPORTA PARA ARQUIVO CSV:

![image](https://github.com/ClaudioOliver/MVC/assets/115963003/3abd5526-f642-48da-ae3c-2e2fc2fcfa20)



