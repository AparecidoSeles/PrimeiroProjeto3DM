--DDL -> criação de tabelas 

--criando o banco de dados chamado Projeto_Inicial
CREATE DATABASE Projeto_Inicial
GO

--definindo qual banco usar
USE Projeto_Inicial
GO

--criando tabela com o nome Escola
CREATE TABLE Escola
(
	idEscola		INT PRIMARY KEY IDENTITY
	,nome			VARCHAR (50) NOT NULL
	,endereco		VARCHAR (50) NOT NULL
	,cnpj			CHAR	(14) NOT NULL
);
GO

--criando tabela com o nome Usuario
CREATE TABLE Usuario
(
	idUsuario			INT PRIMARY KEY IDENTITY
	,idEscola			INT FOREIGN KEY REFERENCES Escola(idEscola)
	,nome				VARCHAR (100) NOT NULL
	,email				VARCHAR (100) NOT NULL
	,senha				VARCHAR (100) NOT NULL
); 
GO

--criando tabela com o nome Sala
CREATE TABLE Sala
(
	idSala				INT PRIMARY KEY IDENTITY
	,idEscola			INT FOREIGN KEY REFERENCES Escola(idEscola)
	,nome				VARCHAR (100)   NOT NULL 
	,andar				VARCHAR (50)    NOT NULL
	,metragem			DECIMAL (18, 2) NOT NULL
);
GO

--criando tabela com o nome  TipoEquipamento
CREATE TABLE TipoEquipamento
(
	idTipoEquipamento	 INT PRIMARY KEY IDENTITY
	,nomeTipoEquipamento VARCHAR (100) NOT NULL
);
GO

--criando tabela com o nome Equipamento
CREATE TABLE Equipamento
(
	idEquipamento		INT PRIMARY KEY IDENTITY
	,idTipoEquipamento	INT FOREIGN KEY REFERENCES TipoEquipamento(idTipoEquipamento)
	,idSala				INT FOREIGN KEY REFERENCES Sala (idSala)
	,nome				VARCHAR (50)  NOT NULL
	,marca				VARCHAR (50)  NOT NULL
	,numeroSerie		VARCHAR (50)  NOT NULL
	,descricao			VARCHAR (250) NOT NULL
	,numeroPatrimonio	VARCHAR (50)  NOT NULL
	,situacao			BIT DEFAULT (1) 
);
GO


--DROP DATABASE Projeto_Inicial