--DML -> insere os dados nas tabelas

--definindo qual banco usar
USE  Projeto_Inicial;
GO

--inserindo os dados na tabela Escolatipo
INSERT INTO		Escola(nome, endereco, cnpj)
VALUES			('Senai Informatica', 'Av. Barão de Limeira 539', '99999998888888');
GO

--inserindo os dados na tabela Usuario
INSERT INTO		Usuario(idEscola, nome, email, senha)
VALUES			(1, 'Paulo', 'paulo@paulo.com', '1234');
GO

--inserindo os dados na tabela Sala
INSERT INTO		Sala(idEscola, nome, andar, metragem)
VALUES			(1, 'Sala de Dev', 'Primeiro andar', 113.96)
				,(1, 'Sala de Redes', 'Segundo andar', 113.96)
				,(1, 'Sala de Multimidia','Segundo andar', 113.96);
GO

--inserindo os dados na tabela TipoEquipamento
INSERT INTO		TipoEquipamento(nomeTipoEquipamento)
VALUES			('Eletrônico')
				,('Móvel');	
GO

----inserindo os dados na tabela Equipamento
INSERT INTO		Equipamento(idTipoEquipamento, idSala, nome, marca, numeroSerie, descricao, numeroPatrimonio, situacao)
VALUES			(1, 2, 'Ventilador', 'Mondial', '123456789', 'Ventilador da marca Mondial', '123456789',1)
				,(2, 1, 'Puff', 'Mobly', '9867654321', 'Puff da marca Mobly', '123456788', 0)
				,(1, 3, 'Notebook', 'Dell', '234556781', 'Notebook da marca Dell', '12345677', 1)
				,(2, 2, 'Cadeira', 'Staples', '876543299', 'Cadeira da marca Staples', '123456666', 0);
GO