use master
go
create database DB
go
use DB
go


CREATE TABLE [dbo].[USUARIO](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](12) NULL,
	[Nivel] [int] NULL)
GO


CREATE TABLE [dbo].[PERSONA](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[IdUsuario] [int] FOREIGN KEY REFERENCES USUARIO(Id) not NULL,
	[DNI] [int] NULL,
	[Nombre] [varchar](20) NULL,
	[Apellido] [varchar](20) NULL,
	[Direccion] [varchar](50) NULL,
	[Genero] [varchar](20) NULL,
	[Condicion] [int] NULL)
GO


CREATE TABLE [dbo].[ARTICULO](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](150) NULL,
	[ImagenUrl] [varchar](1000) NULL,
	[Precio] numeric(17,3) NULL,
	[Marca] [varchar](20) NULL,
	[Categoria] [varchar](20) NULL)
GO


CREATE TABLE [dbo].[ENVIO](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Metodo] [int] NULL,
	[Estado] [int] NULL,
	[FechaEntrega] [date] NULL,
	[Precio] numeric(17,3) NULL)
GO


CREATE TABLE [dbo].[FACTURA](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Tipo] [int] NULL,
	[Metodo] [int] NULL,
	[Fecha] [date] NULL,
	[Importe] numeric(17,3) NULL)
GO


CREATE TABLE [dbo].[ELEMENTO](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[IdCarrito] [int] not null,
	[IdArticulo] [int] FOREIGN KEY REFERENCES ARTICULO(Id) not NULL,
	[Cantidad] [int] NULL,
	[Descuento] numeric(17,3) NULL)
GO


CREATE TABLE [dbo].[CARRITO](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[IdElemento] [int] FOREIGN KEY REFERENCES ELEMENTO(Id) not NULL,
	[IdUsuario] [int] FOREIGN KEY REFERENCES USUARIO(Id) not NULL,
	[IdEnvio] [int] FOREIGN KEY REFERENCES ENVIO(Id) not NULL,
	[IdFactura] [int] FOREIGN KEY REFERENCES Factura(Id) not NULL)
GO



insert into ARTICULO values ('AGUA FRESCA AZAHAR', 'Floral Fresca', 'https://perfumeriaspigmento.com.ar/media/catalog/product/cache/small_image/400x437/beff4985b56e3afdbeabfc89641a4582/a/d/adolfo-dominguez-agua-fresca-azahar-edt-60-ml.jpg', 2350, 'ADOLFO DOMINGUEZ', 'Perfume'),
('212 NYC', 'Tamaño: 100mL', 'https://perfumeriaspigmento.com.ar/media/catalog/product/cache/image/620x678/e9c3970ab036de70892d86c6d221abfe/s/c/sch-11599_8411061865408_1_.png', 10285, 'CAROLINA HERRERA', 'Perfume'),
('CH', 'Tamaño: 100mL', 'https://perfumeriaspigmento.com.ar/media/catalog/product/cache/image/620x678/e9c3970ab036de70892d86c6d221abfe/8/4/8411061607152_1.jpg', 9065, 'CAROLINA HERRERA', 'Perfume'),
('ACQUA DI GIOIA', 'Acuatica', 'https://perfumeriaspigmento.com.ar/media/catalog/product/cache/image/620x678/e9c3970ab036de70892d86c6d221abfe/6/1/61191.jpg', 10690, 'ARMANI', 'Perfume')


select *  from articulo