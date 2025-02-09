USE EMPRESA
GO

/* CONVERS�O DE DADOS */

SELECT 1+ 1
GO

SELECT '1'+ '1'
GO


SELECT 'CURSO DE BANCO DE DADOS'+ ' 1'
GO

SELECT 'CURSO DE BANCO DE DADOS'+  1
GO

/* FUNCOES DE CONVERSAO DE DADOS */

SELECT CAST('1' AS INT),CAST('1' AS INT)
GO

/* CONVERSAO E CONCATENA��O */

SELECT NOME,NASCIMENTO
FROM ALUNO
GO


/*EXERCICIO*/

SELECT NOME,
DAY (NASCIMENTO)+ '/'+
MONTH(NASCIMENTO)+ '/'+
YEAR(NASCIMENTO)
FROM ALUNO
GO

/* CORRE��O */

SELECT NOME,
CAST (DAY (NASCIMENTO) AS VARCHAR) + '/'+
CAST(MONTH(NASCIMENTO)AS VARCHAR)+ '/'+
CAST(YEAR(NASCIMENTO)AS VARCHAR)
FROM ALUNO
GO

/* CHARINDEX - RETORNA UM INTEIRO */

SELECT NOME,CHARINDEX('A',NOME) AS INDICE
FROM ALUNO
GO

SELECT NOME,CHARINDEX('A',NOME,2) AS INDICE
FROM ALUNO
GO

/* BULK INSERT - IMPORTA��O DE ARQUIVOS */ 

CREATE TABLE LANCAMENTO_CONTABIL(
	CONTA INT,
	VALOR INT,
	DEB_CRED CHAR(1)
)
GO


/* EXPLICA��O BULK INSERT */

/* FROM= DE ONDE VEM 

WITH = ENTRAR COM AS ESPECIFICA��ES

FIRSTROW= LINHA QUE ELE VAI COME�AR

DATAFILETYPE= TIPO DO ARQUIVO QUE AQUI � CARACTERES

FIELDTERMINATOR= '\t' QUE SIGNIFICA A TECLA TAB
QUE � O DELIMITADOR DE CAMPOS. 

ROWTERMINATOR = TERMINA��O DA LINHA.
NO CASO '\n' QUE SIGNIFICA ENTER.
 
*/
BULK INSERT LANCAMENTO_CONTABIL
FROM 'C:\Users\marce\Downloads\CONTAS.txt'
WITH
(
	FIRSTROW = 2,
	DATAFILETYPE = 'CHAR',
	FIELDTERMINATOR = '\t',
	ROWTERMINATOR = '\n'
)
GO

SELECT * FROM LANCAMENTO_CONTABIL

/*  DESAFIO DO SALDO 
    QUERY QUE TRAGA O NUMERO DA CONTA
    SALDO - DEVEDOR OU CREDOR  */
  
  
  
  /* TRIGGERS */

  CREATE TABLE PRODUTOS(
	
	IDPRODUTO INT IDENTITY PRIMARY KEY,
	NOME VARCHAR(50) NOT NULL,
	CATEGORIA VARCHAR(30) NOT NULL,
	PRECO NUMERIC(10,2) NOT NULL
	)
  GO

    CREATE TABLE HISTORICO(
	IDOPERACAO INT IDENTITY PRIMARY KEY,
	PRODUTO VARCHAR(50)NOT NULL,
	CATEGORIA VARCHAR(30) NOT NULL,
	PRECOANTIGO NUMERIC(10,2) NOT NULL,
	PRECONOVO NUMERIC(10,2) NOT NULL,
	DATA DATETIME,
	USUARIO VARCHAR(30),
	MENSAGEM VARCHAR(100)
	)
	GO

	INSERT INTO PRODUTOS VALUES('LIVRO SQL SERVER','LIVROS',98.00)
	INSERT INTO PRODUTOS VALUES('LIVRO ORACLE','LIVROS',50.00)
	INSERT INTO PRODUTOS VALUES('LICEN�A POWERCENTER','SOFTWARES',45000.00)
	INSERT INTO PRODUTOS VALUES('NOTEBOOK 17','COMPUTADORES',3150.00)
	INSERT INTO PRODUTOS VALUES('LIVRO BUSINESS INTELIGENCE','LIVROS',90.00)

	SELECT * FROM PRODUTOS 
	GO
	SELECT * FROM HISTORICO 
	GO

	/* VERIFICANDO O USUARIO DO BANCO */

    SELECT SUSER_NAME()
	GO

	
	/* TRIGGERS DE DADOS - DATA MANIPULATION LANGUAGE */

	DROP TRIGGER TRG_ATUALIZA_PRECO
	GO

CREATE TRIGGER TRG_ATUALIZA_PRECO
ON DBO.PRODUTOS
FOR UPDATE AS

IF UPDATE (PRECO)
 BEGIN
	DECLARE @IDPRODUTO INT
	DECLARE @PRODUTO VARCHAR(30)
	DECLARE @CATEGORIA VARCHAR(10)
	DECLARE @PRECO NUMERIC(10,2) 
	DECLARE @PRECONOVO NUMERIC(10,2)
	DECLARE @DATA DATETIME
	DECLARE @USUARIO VARCHAR(30)
	DECLARE @ACAO VARCHAR(100)

	-- PRIMEIRO BLOCO
	SELECT @IDPRODUTO = IDPRODUTO FROM inserted
	SELECT @PRODUTO = NOME FROM inserted
	SELECT @CATEGORIA = CATEGORIA FROM inserted
	SELECT @PRECO = PRECO FROM deleted
	SELECT @PRECONOVO=PRECO FROM inserted

	-- SEGUNDO BLOCO
	SET @DATA=GETDATE()
	SET @USUARIO=SUSER_NAME()
	SET @ACAO =' VALOR INSERIDO PELA TRIGGER TRG_ATUALIZA_PRECO '

	INSERT INTO HISTORICO
	(PRODUTO,CATEGORIA,PRECOANTIGO,PRECONOVO,
	 DATA,USUARIO,MENSAGEM)
    VALUES
	 (@PRODUTO,@CATEGORIA,@PRECO,@PRECONOVO,@DATA,@USUARIO,@ACAO)

	PRINT 'TRIGGER EXECUTADA COM SUCESSO'
END
GO


/* EXECUTANDO UM UPDATE */

UPDATE PRODUTOS SET PRECO = 100.00
WHERE IDPRODUTO = 1
GO

SELECT * FROM PRODUTOS
SELECT * FROM HISTORICO
GO



 /* VARIAVEIS COM SELECT */


 CREATE TABLE RESULTADO(
	IDRESULTADO INT PRIMARY KEY IDENTITY,
	RESULTADO INT
 )
 GO

 INSERT INTO RESULTADO VALUES((SELECT 10+10))
 GO

 SELECT * FROM RESULTADO
 GO


 /* ATRIBUINDO SELECTS A VARIAVEIS - COME�ANDO BLOCO SEM NOME - ANONIMO  */

 DECLARE
		@RESULTADO INT
		SET @RESULTADO = (SELECT 50+10)
		INSERT INTO RESULTADO VALUES(@RESULTADO)
 GO

  DECLARE
		@RESULTADO INT
		SET @RESULTADO = (SELECT 50+50)
		INSERT INTO RESULTADO VALUES(@RESULTADO)
		PRINT ' VALOR INSERIDO NA TABELA: '+ CAST(@RESULTADO AS VARCHAR)
 GO

 /* TRIGGER UPDATE */


 CREATE TABLE EMPREGADO(
	IDEMPREGADO INT PRIMARY KEY,
	NOME VARCHAR(30),
	SALARIO MONEY,
	IDGERENTE INT
)
GO

ALTER TABLE EMPREGADO ADD CONSTRAINT FK_GERENTE
FOREIGN KEY(IDGERENTE)REFERENCES EMPREGADO(IDEMPREGADO)
GO

INSERT INTO EMPREGADO VALUES(1,'CLARA',5000.00,NULL)
INSERT INTO EMPREGADO VALUES(2,'CELIA',4000.00,1)
INSERT INTO EMPREGADO VALUES(3,'JOAO',4000.00,1)

CREATE TABLE HIST_SALARIO(
	IDEMPREGADO INT,
	ANTIGOSAL MONEY,
	NOVOSAL MONEY,
	DATA DATETIME
    )
	GO

	CREATE TRIGGER TG_SALARIO
	ON DBO.EMPREGADO
	FOR UPDATE AS
	IF UPDATE(SALARIO)
	 BEGIN
		INSERT INTO HIST_SALARIO
		(IDEMPREGADO,ANTIGOSAL,NOVOSAL,DATA)
		SELECT D.IDEMPREGADO,D.SALARIO,I.SALARIO,GETDATE()
		FROM DELETED D,inserted I
		WHERE D.IDEMPREGADO=I.IDEMPREGADO
     END
	GO

	UPDATE EMPREGADO SET SALARIO =SALARIO * 1.1
	GO

	SELECT * FROM EMPREGADO

	SELECT * FROM HIST_SALARIO
	GO

	/* INTRODU��O � TRANSA��ES */
	
	USE EMPRESA 

	/* VAI DAR ERRO POIS VAI TENTAR CONVERTER VARCHAR PARA INT */

	SELECT + 'TRIGGERS' 10

	CREATE TABLE SALARIO_RANGE(
		MINSAL MONEY,
		MAXSAL MONEY
	)
	GO

	INSERT INTO SALARIO_RANGE VALUES(3000.00,6000.00)
	GO

	CREATE TRIGGER TG_RANGE 
	ON DBO.EMPREGADO
	FOR INSERT,UPDATE
	AS
		DECLARE
		@MINSAL MONEY,
		@MAXSAL MONEY,
		@ATUALSAL MONEY

		SELECT @MINSAL=MINSAL,@MAXSAL=MAXSAL FROM SALARIO_RANGE

		SELECT @ATUALSAL=I.SALARIO
		FROM INSERTED I

		IF(@ATUALSAL<@MINSAL)
		BEGIN
			RAISERROR('SALARIO MENOR QUE O PISO',16,1 )
			ROLLBACK TRANSACTION 
		END

		IF(@ATUALSAL>@MAXSAL)
		BEGIN
			RAISERROR('SALARIO MAIOR QUE O TETO ',16,1)
			ROLLBACK TRANSACTION
		END
	  GO

	  UPDATE EMPREGADO SET SALARIO=9000.00
	  WHERE IDEMPREGADO=1
	  GO

	  
	  UPDATE EMPREGADO SET SALARIO=1000.00
	  WHERE IDEMPREGADO=1
	  GO

	  SP_HELPTEXT TG_RANGE
	  GO