use master
go
drop database CATALOGO_DB
go
create database CATALOGO_DB
go
use CATALOGO_DB
go

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MARCAS](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Descripcion] [varchar](50) NULL)
GO


CREATE TABLE [dbo].[CATEGORIAS](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Descripcion] [varchar](50) NULL)
GO

CREATE TABLE [dbo].[ARTICULOS](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Codigo] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](150) NULL,
	[IdMarca] [int] foreign key references marcas(id) not NULL,
	[IdCategoria] [int] foreign key references categorias(id) not NULL,
	[ImagenUrl] [varchar](1000) NULL,
	[Precio] numeric(17,3) NULL)

GO

insert into MARCAS values ('Samsung'), ('Apple'), ('Sony'), ('Huawei'), ('Motorola')
insert into CATEGORIAS values ('Celulares'),('Televisores'), ('Media'), ('Audio')
insert into ARTICULOS values ('S01', 'Galaxy S10', 'Una canoa cara', 1, 1, 'https://images.samsung.com/is/image/samsung/co-galaxy-s10-sm-g970-sm-g970fzyjcoo-frontcanaryyellow-thumb-149016542', 69.999),
('M03', 'Moto G Play 7ma Gen', 'Ya siete de estos?', 1, 4, 'https://www.motorola.cl/arquivos/moto-g7-play-img-product.png?v=636862863804700000', 15699),
('S99', 'Play 4', 'Ya no se cuantas versiones hay', 3, 3, 'https://www.euronics.cz/image/product/800x800/532620.jpg', 35000),
('S56', 'Bravia 55', 'Alta tele', 3, 2, 'https://intercompras.com/product_thumb_keepratio_2.php?img=images/product/SONY_KDL-55W950A.jpg&w=650&h=450', 49500),
('A23', 'Apple TV', 'lindo loro', 2, 3, 'https://store.storeimages.cdn-apple.com/4982/as-images.apple.com/is/apple-tv-hero-select-201709', 7850)

select *  from articulos