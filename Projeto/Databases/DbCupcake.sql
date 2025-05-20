/*------------------------------------------------------------*/
/*   Esquema para a criação do banco de dados da aplicação    */
/*                          DbCupcake                         */
/*------------------------------------------------------------*/

/*------------------------------------------------------------*/
/*                     Exclusão de Triggers                   */
/*------------------------------------------------------------*/

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_LOGIN_GROUP_USER') AND sysstat & 0xf = 11)
ALTER TABLE [TB_LOGIN_USER]
DROP CONSTRAINT [TB_LOGIN_GROUP_USER]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('FK_TB_LOGIN_USER') AND sysstat & 0xf = 11)
ALTER TABLE [TB_CR]
DROP CONSTRAINT [FK_TB_LOGIN_USER]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('FK_TB_LOGIN_USER1') AND sysstat & 0xf = 11)
ALTER TABLE [TB_VENDA]
DROP CONSTRAINT [FK_TB_LOGIN_USER1]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('FK_TB_PRODUTO') AND sysstat & 0xf = 11)
ALTER TABLE [TB_VENDA_ITEM]
DROP CONSTRAINT [FK_TB_PRODUTO]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('FK_TB_VENDA') AND sysstat & 0xf = 11)
ALTER TABLE [TB_VENDA_ITEM]
DROP CONSTRAINT [FK_TB_VENDA]
GO

/*------------------------------------------------------------*/
/*                     Exclusão de Views                      */
/*------------------------------------------------------------*/

/*------------------------------------------------------------*/
/*                     Exclusão de tabelas                    */
/*------------------------------------------------------------*/

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_CR') AND sysstat & 0xf = 3)
DROP TABLE [TB_CR]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_LOGIN_GROUP') AND sysstat & 0xf = 3)
DROP TABLE [TB_LOGIN_GROUP]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_LOGIN_USER') AND sysstat & 0xf = 3)
DROP TABLE [TB_LOGIN_USER]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_PRODUTO') AND sysstat & 0xf = 3)
DROP TABLE [TB_PRODUTO]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_VENDA') AND sysstat & 0xf = 3)
DROP TABLE [TB_VENDA]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id('TB_VENDA_ITEM') AND sysstat & 0xf = 3)
DROP TABLE [TB_VENDA_ITEM]
GO

/*------------------------------------------------------------*/
/*                     Criação das tabelas                    */
/*------------------------------------------------------------*/

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*  TB_CR  */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_CR](
	[ID_CR]                                bigint               IDENTITY(1,1) NOT NULL,
	[LOGIN_USER_LOGIN]                     varchar (14)         NOT NULL,
	[DATA_CR]                              date                 NOT NULL,
	[TPGTO_CR]                             varchar (10)         NOT NULL,
	[ID_VENDA]                             bigint               NOT NULL,
	[VALOR_CR]                             varchar (10)         NOT NULL,
	[REC_CR]                               bit                  DEFAULT 0 NOT NULL
		CONSTRAINT [PK_TB_CR] PRIMARY KEY CLUSTERED
		(
			[ID_CR]
		) WITH FILLFACTOR = 90
)
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*       TB_LOGIN_GROUP       */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_LOGIN_GROUP](
	[LOGIN_GROUP_NAME]                     varchar (60)         NOT NULL,
	[LOGIN_GROUP_IS_ADMIN]                 bit                  NOT NULL
		CONSTRAINT [LOGIN_GROUP_PK] PRIMARY KEY CLUSTERED
		(
			[LOGIN_GROUP_NAME]
		) WITH FILLFACTOR = 90
)
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*      TB_LOGIN_USER      */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_LOGIN_USER](
	[LOGIN_GROUP_NAME]                     varchar (60)         NOT NULL,
	[LOGIN_USER_LOGIN]                     varchar (14)         NOT NULL,
	[LOGIN_USER_PASSWORD]                  varchar (40)         NOT NULL,
	[LOGIN_USER_NAME]                      varchar (60)         NOT NULL,
	[LOGIN_USER_ENDERECO]                  varchar (60)         NULL,
	[LOGIN_USER_NUM]                       varchar (10)         NULL,
	[LOGIN_USER_COMPL]                     varchar (60)         NULL,
	[LOGIN_USER_BAIRRO]                    varchar (60)         NULL,
	[LOGIN_USER_CIDADE]                    varchar (60)         NULL,
	[LOGIN_USER_CEP]                       varchar (9)          NULL,
	[LOGIN_USER_CEL]                       varchar (14)         NULL,
	[LOGIN_USER_OBS]                       text                 NULL,
	[LOGIN_USER_EMAIL]                     varchar (60)         NULL
		CONSTRAINT [LOGIN_USER_PK] PRIMARY KEY CLUSTERED
		(
			[LOGIN_USER_LOGIN]
		) WITH FILLFACTOR = 90
)
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*     TB_PRODUTO     */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_PRODUTO](
	[ID_PRODUTO]                           bigint               IDENTITY(1,1) NOT NULL,
	[NOME_PRODUTO]                         varchar (60)         NOT NULL,
	[VALOR_PRODUTO]                        decimal (10,2)       DEFAULT 0 NOT NULL,
	[FOTO1_PRODUTO]                        varbinary(MAX)       NULL,
	[FOTO2_PRODUTO]                        varbinary(MAX)       NULL,
	[OBS_PRODUTO]                          text                 NULL
		CONSTRAINT [PK_TB_PRODUTO] PRIMARY KEY CLUSTERED
		(
			[ID_PRODUTO]
		) WITH FILLFACTOR = 90
)
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*    TB_VENDA    */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_VENDA](
	[ID_VENDA]                             bigint               IDENTITY(1,1) NOT NULL,
	[LOGIN_USER_LOGIN]                     varchar (14)         NOT NULL,
	[DATA_VENDA]                           datetime             NOT NULL,
	[OBS_VENDA]                            text                 NULL,
	[TOTAL_VENDA]                          decimal (10,2)       DEFAULT 0 NULL,
	[ENTREGA_VENDA]                        varchar (10)         NOT NULL,
	[PENDENTE_VENDA]                       bit                  NULL
		CONSTRAINT [PK_TB_VENDA] PRIMARY KEY CLUSTERED
		(
			[ID_VENDA]
		) WITH FILLFACTOR = 90
)
GO

/*------------------------------------------------------------*/
/*    Criação de Tabelas, Indices e Atribuição de Default    */
/*      TB_VENDA_ITEM      */
/*------------------------------------------------------------*/

 CREATE TABLE [TB_VENDA_ITEM](
	[ID_VENDA_ITEM]                        bigint               IDENTITY(1,1) NOT NULL,
	[ID_VENDA]                             bigint               NULL,
	[ID_PRODUTO]                           bigint               NOT NULL,
	[QTDE_VENDA_ITEM]                      bigint               DEFAULT 0 NOT NULL,
	[VALOR_VENDA_ITEM]                     decimal (10,2)       DEFAULT 0 NOT NULL
		CONSTRAINT [PK_TB_VENDA_ITEM] PRIMARY KEY CLUSTERED
		(
			[ID_VENDA_ITEM]
		) WITH FILLFACTOR = 90
)
GO

ALTER TABLE [TB_LOGIN_USER] ADD CONSTRAINT [TB_LOGIN_GROUP_USER]
	FOREIGN KEY
		([LOGIN_GROUP_NAME])
	REFERENCES [TB_LOGIN_GROUP]
		([LOGIN_GROUP_NAME])
	ON DELETE CASCADE
GO

ALTER TABLE [TB_CR] ADD CONSTRAINT [FK_TB_LOGIN_USER]
	FOREIGN KEY
		([LOGIN_USER_LOGIN])
	REFERENCES [TB_LOGIN_USER]
		([LOGIN_USER_LOGIN])
	ON DELETE CASCADE
	ON UPDATE CASCADE
GO

ALTER TABLE [TB_VENDA] ADD CONSTRAINT [FK_TB_LOGIN_USER1]
	FOREIGN KEY
		([LOGIN_USER_LOGIN])
	REFERENCES [TB_LOGIN_USER]
		([LOGIN_USER_LOGIN])
	ON DELETE CASCADE
	ON UPDATE CASCADE
GO

ALTER TABLE [TB_VENDA_ITEM] ADD CONSTRAINT [FK_TB_PRODUTO]
	FOREIGN KEY
		([ID_PRODUTO])
	REFERENCES [TB_PRODUTO]
		([ID_PRODUTO])
	ON DELETE CASCADE
	ON UPDATE CASCADE
GO

ALTER TABLE [TB_VENDA_ITEM] ADD CONSTRAINT [FK_TB_VENDA]
	FOREIGN KEY
		([ID_VENDA])
	REFERENCES [TB_VENDA]
		([ID_VENDA])
	ON DELETE CASCADE
	ON UPDATE CASCADE
GO

