-- Autor: David Alejandro López Benjumea.
-- Objetivo: Creación de un esquema de Base de Datos para objetos de base de datos, si no existen previamente.
-- Fecha: 28-02-2024.
-- Comentarios: Esquema para el uso de la aplicación
IF NOT EXISTS( SELECT 1 FROM sys.databases WHERE ([name] = N'Aranda') )
	CREATE DATABASE Aranda
GO 

USE Aranda
GO

IF NOT EXISTS( SELECT 1 FROM sys.schemas WHERE ([name] = N'aranda') )
	EXEC( 'CREATE SCHEMA [aranda] AUTHORIZATION [dbo]')
GO

IF NOT EXISTS( SELECT 1 FROM sys.tables WHERE ([name] = N'tbUsers') )
BEGIN 
	CREATE TABLE aranda.tbUsers (
		id				INT IDENTITY(1, 1) PRIMARY KEY,
		name_user		VARCHAR(200)	NOT NULL,
		email_user		VARCHAR(100)	NOT NULL,
		password_user	VARCHAR(300)	NOT NULL,
		created			DATETIME		NOT NULL DEFAULT GETDATE(), 
		createdBy		INT				NULL,
		lastModified	DATETIME		NULL,
		lastModifiedBy	INT				NULL,
		deleted			BIT				NOT NULL DEFAULT 0
	)

	CREATE UNIQUE INDEX UIDX_USER_EMAILUSER ON aranda.tbUsers(email_user) 

	INSERT INTO aranda.tbUsers (name_user, email_user, password_user, createdBy) VALUES 
	('Aranda User', 'correo@correo.com', '9abddae2d7e0c17431a74dd14a42c9b6b9d6db7c', 0)

END
GO

IF NOT EXISTS( SELECT 1 FROM sys.schemas WHERE ([name] = N'aranda') )
	EXEC( 'CREATE SCHEMA [aranda] AUTHORIZATION [dbo]')
GO

IF NOT EXISTS( SELECT 1 FROM sys.tables WHERE ([name] = N'tbCategory') )
BEGIN 
	CREATE TABLE aranda.tbCategory (
		id				INT IDENTITY(1, 1) PRIMARY KEY, 
		name_category	VARCHAR(100)	NOT NULL, 
		created			DATETIME		NOT NULL DEFAULT GETDATE(), 
		createdBy		INT				NULL,
		lastModified	DATETIME		NULL,
		lastModifiedBy	INT				NULL,
		CONSTRAINT [FK_CATEGORY_CREATEDBY] FOREIGN KEY (createdBy) REFERENCES aranda.tbUsers(id),
		CONSTRAINT [FK_CATEGORY_MODIFIEDBY] FOREIGN KEY (lastModifiedBy) REFERENCES aranda.tbUsers(id)
	)

	CREATE UNIQUE INDEX UIDX_CATEGORY_NAMECATEGORY ON aranda.tbCategory(name_category) 

	INSERT INTO aranda.tbCategory (name_category, createdBy) VALUES 
		('Zapatos', 1),
		('Blusa mujer', 1), 
		('Camisa hombre', 1), 
		('Camisetas niño', 1), 
		('Chaquetas', 1), 
		('Pantalones', 1)
END

IF NOT EXISTS( SELECT 1 FROM sys.tables WHERE ([name] = N'tbProducts') )
BEGIN 
	CREATE TABLE aranda.tbProduct (
		id				INT IDENTITY(1, 1) PRIMARY KEY,
		name_product	VARCHAR(200)	NOT NULL,
		category_id		INT				NOT NULL,
		[description]	VARCHAR(200)	NULL,
		photo			NVARCHAR(MAX)	NULL,
		created			DATETIME		NOT NULL DEFAULT GETDATE(), 
		createdBy		INT				NULL,
		lastModified	DATETIME		NULL,
		lastModifiedBy	INT				NULL,
		deleted			BIT				NOT NULL DEFAULT 0,
		CONSTRAINT [FK_PRODUCT_CATEGORYID] FOREIGN KEY (category_id) REFERENCES aranda.tbCategory (id),
		CONSTRAINT [FK_PRODUCT_CREATEDBY] FOREIGN KEY (createdBy) REFERENCES aranda.tbUsers(id),
		CONSTRAINT [FK_PRODUCT_MODIFIEDBY] FOREIGN KEY (lastModifiedBy) REFERENCES aranda.tbUsers(id)
	)

	CREATE UNIQUE INDEX UIDX_PRODUCT_NAMEPRODUCT ON aranda.tbProduct(name_product) 

	INSERT INTO aranda.tbProduct (name_product, category_id, [description], createdBy) VALUES 
	('Camisa de rayas rojas Talla L', 3, 'Camisa de hombre talla L', 1),
	('Zapato de charol Talla 35', 1, 'Zapato de mujer talla 35', 1),
	('Tenis deportivos Talla 40', 1, 'Tenis deportivos de hombre talla 40', 1),
	('Chaqueta de cuero cafe Talla L', 5, 'Chaqueta de cuero de hombre talla L', 1),
	('Blusa verde con decorados blanco Talla S', 2, 'Blusa de mujer talla S', 1)
END
GO

