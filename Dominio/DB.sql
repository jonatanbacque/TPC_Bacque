use master
go
drop database db
go
create database DB
go
use DB
go

CREATE TABLE [dbo].[PERSONA](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[DNI] [int] NULL,
	[Nombre] [varchar](20) NULL,
	[Apellido] [varchar](20) NULL,
	[Direccion] [varchar](50) NULL,
	[Genero] [varchar](20) NULL,
	[Condicion] [int] NULL)
GO

CREATE TABLE [dbo].[USUARIO](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[IdPersona][int] FOREIGN KEY REFERENCES PERSONA(Id) NOT NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](12) NULL,
	[Nivel] [int] NULL)
GO


CREATE TABLE [dbo].[CATEGORIA](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](150) NULL)
GO


CREATE TABLE [dbo].[ARTICULO](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Producto] [varchar](50) NULL,
	[Presentacion] [varchar](100) NULL,
	[Descripcion] [varchar](200) NULL,
	[ImagenUrl] [varchar](1000) NULL,
	[Precio] numeric(18,2) NULL,
	[Marca] [varchar](20) NULL,
	[IdCategoria] [int] FOREIGN KEY REFERENCES CATEGORIA(Id) NOT NULL)
GO


CREATE TABLE [dbo].[ENVIO](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Metodo] [varchar](50) NULL,
	[Estado] [varchar](50) NULL,
	[FechaEntrega] [date] NULL,
	[Precio] numeric(17,3) NULL)
GO


CREATE TABLE [dbo].[COMPRA](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[MetodoPago] [varchar](50) NULL,
	[FechaCompra] [date] NULL,
	[Importe] numeric(17,3) NULL)
GO

CREATE TABLE [dbo].[CARRITO](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[IdUsuario] [int] FOREIGN KEY REFERENCES USUARIO(Id) NOT NULL,
	[IdEnvio] [int] FOREIGN KEY REFERENCES ENVIO(Id) NOT NULL,
	[IdCompra] [int] FOREIGN KEY REFERENCES COMPRA(Id) NOT NULL)
GO

CREATE TABLE [dbo].[ELEMENTO](
	[IdCarrito] [int] FOREIGN KEY REFERENCES CARRITO(Id) NOT NULL,
	[IdArticulo] [int] FOREIGN KEY REFERENCES ARTICULO(Id) NOT NULL,
	[Cantidad] [int] NULL,
	[Descuento] numeric(17,3) NULL,	
    PRIMARY KEY (IdCarrito, IdArticulo)
	)
GO



insert into CATEGORIA values ('Perfumería','Fragancias de primera calidad'),('Limpieza','Muy buena calidad'),('Decoración','Te queda la casa hermosa')



insert into ARTICULO values ('Difusores ambientales', 'Envases de 125ml o 1L','Fragancias disponibles: Coco, Rosas, Sandalo y Bebe', 'https://ss-static-01.esmsv.com/id/117805/productos/obtenerimagen/?id=211&useDensity=false&width=1280&height=720&tipoEscala=fit', 2350, 'Aleli Esencias', 1),
('Body splash', 'envases de 1 litro','Fragancias disponibles: Coco, Rosas, Sandalo y Bebe', 'https://ss-static-01.esmsv.com/id/117805/productos/obtenerimagen/?id=203&useDensity=false&width=1280&height=720&tipoEscala=fit', 10285, 'Aleli Esencias', 1),
('Gel de ducha', 'envases de 1 litro','Fragancias disponibles: Coco, Rosas, Sandalo y Bebe', 'https://ss-static-01.esmsv.com/id/117805/productos/obtenerimagen/?id=157&useDensity=false&width=1280&height=720&tipoEscala=fit', 9065, 'Aleli Esencias', 1),
('Desodorante Pisos', 'envases de 1 litro', 'Fragancias disponibles: Lysoform', 'https://ss-static-01.esmsv.com/id/117805/productos/obtenerimagen/?id=195&useDensity=false&width=1280&height=720&tipoEscala=fit', 485, 'Aleli Esencias', 2),
('Alcohol en Gel','envases de 1 litro' , 'Elimina el 99,9% de virus y bacterias.', 'https://ss-static-01.esmsv.com/id/117805/productos/obtenerimagen/?id=183&useDensity=false&width=1280&height=720&tipoEscala=fit', 690, 'Aleli Esencias', 2)

select a.Producto, a.Descripcion, a.Precio, c.Nombre from articulo as a
inner join categoria as c on c.id=a.IdCategoria

Select a.ID, a.Producto, a.Presentacion, a.Descripcion, a.ImagenUrl, a.Precio, a.Marca, c.Id, c.Nombre, c.Descripcion from ARTICULO as a INNER JOIN CATEGORIA as c on c.ID = a.IdCategoria