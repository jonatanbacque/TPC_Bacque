use master
go
drop database db
go
create database DB
go
use DB
go

CREATE TABLE [dbo].[CATEGORIA](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Nombre] [varchar](200) NULL,
	[Descripcion] [varchar](600) NULL
	)
GO

CREATE TABLE [dbo].[ARTICULO](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Producto] [varchar](50) NULL,
	[Presentacion] [varchar](500) NULL,
	[Descripcion] [varchar](2000) NULL,
	[ImagenUrl] [varchar](2000) NULL,
	[Precio] numeric(18,2) NULL,
	[Marca] [varchar](20) NULL,
	[IdCategoria] [int] FOREIGN KEY REFERENCES CATEGORIA(Id) NOT NULL
	)
GO

CREATE TABLE [dbo].[PERSONA](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Nombre] [varchar](120) NULL,
	[Apellido] [varchar](120) NULL,
	[Direccion] [varchar](600) NULL,
	[DNI] [int] NULL,
	[Email] [varchar](600) NULL,
	[Telefono] [int] NULL,
	[Condicion] [int] NULL
	)
GO

CREATE TABLE [dbo].[USUARIO](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[IdPersona][int] FOREIGN KEY REFERENCES PERSONA(Id) NOT NULL,
	[Nombre] [varchar](200) NOT NULL,
	[Password] [varchar](50) NULL,
	[Nivel] [int] NULL
	)
GO

CREATE TABLE [dbo].[CARRITO](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Importe] numeric(17,2) NULL
	)
GO

CREATE TABLE [dbo].[ELEMENTO](
	[IdCarrito] [int] FOREIGN KEY REFERENCES CARRITO(Id) NOT NULL,
	[IdArticulo] [int] FOREIGN KEY REFERENCES ARTICULO(Id) NOT NULL,
	[Cantidad] [int] NULL,
	[Descuento] numeric(17,2) NULL,	
    PRIMARY KEY (IdCarrito, IdArticulo)
	)
GO

CREATE TABLE [dbo].[METODOENVIO](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Nombre] [varchar](200) NULL,
	[Detalle] [varchar](200) NULL
	)
GO

CREATE TABLE [dbo].[ENVIO](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[IdMetodo] [int] FOREIGN KEY REFERENCES METODOENVIO(Id) NOT NULL,
	[Estado] [varchar](200) NULL,
	[FechaEntrega] [date] NULL,
	[Precio] numeric(17,2) NULL
	)
GO


CREATE TABLE [dbo].[COMPRA](
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[IdUsuario] [int] FOREIGN KEY REFERENCES USUARIO(Id) NOT NULL,
	[IdCarrito] [int] FOREIGN KEY REFERENCES CARRITO(Id) NOT NULL,
	[IdEnvio] [int] FOREIGN KEY REFERENCES ENVIO(Id) NOT NULL,
	[MetodoPago] [varchar](200) NULL,
	[FechaCompra] [date] NULL,
	[ImporteFinal] numeric(17,2) NULL
	)
GO



insert into CATEGORIA values ('Perfumería','Fragancias de primera calidad'),('Limpieza','Muy buena calidad'),('Decoración','Te queda la casa hermosa')



insert into ARTICULO values ('Difusores ambientales', 'Envases de 125ml o 1L','Fragancias disponibles: Coco, Rosas, Sandalo y Bebe', 'https://ss-static-01.esmsv.com/id/117805/productos/obtenerimagen/?id=211&useDensity=false&width=1280&height=720&tipoEscala=fit', 645, 'Aleli Esencias', 1),
('Body splash', 'envases de 1 litro','Fragancias disponibles: Coco, Rosas, Sandalo y Bebe', 'https://ss-static-01.esmsv.com/id/117805/productos/obtenerimagen/?id=203&useDensity=false&width=1280&height=720&tipoEscala=fit', 750, 'Aleli Esencias', 1),
('Gel de ducha', 'envases de 1 litro','Fragancias disponibles: Coco, Rosas, Sandalo y Bebe', 'https://ss-static-01.esmsv.com/id/117805/productos/obtenerimagen/?id=157&useDensity=false&width=1280&height=720&tipoEscala=fit', 280, 'Aleli Esencias', 1),
('Desodorante Pisos', 'envases de 1 litro', 'Fragancias disponibles: Lysoform', 'https://ss-static-01.esmsv.com/id/117805/productos/obtenerimagen/?id=195&useDensity=false&width=1280&height=720&tipoEscala=fit', 720, 'Aleli Esencias', 2),
('Alcohol en Gel','envases de 5 litro' , 'Elimina el 99,9% de virus y bacterias.', 'https://ss-static-01.esmsv.com/id/117805/productos/obtenerimagen/?id=183&useDensity=false&width=1280&height=720&tipoEscala=fit', 1200, 'Aleli Esencias', 2)

insert into CARRITO values (25.5)

select a.Producto, a.Descripcion, a.Precio, c.Nombre from articulo as a
inner join categoria as c on c.id=a.IdCategoria

declare @idCarrito int
declare @idArticulo int
declare @cantidad int
declare @descuento int

set @idCarrito = 1
set @idArticulo = 1
set @cantidad = 1
set @descuento = 1

IF (EXISTS (SELECT * from ELEMENTO WHERE IdCarrito=@idCarrito and IdArticulo=@idArticulo))
BEGIN update ELEMENTO set Cantidad = (select SUM(cantidad) FROM ELEMENTO WHERE  IdCarrito=@idCarrito and IdArticulo=@idArticulo) + @cantidad
WHERE IdCarrito=@idCarrito and IdArticulo=@idArticulo END
ELSE 
BEGIN INSERT into ELEMENTO(IdCarrito, IdArticulo, Cantidad, Descuento) VALUES(@idCarrito, @idArticulo, @cantidad, @descuento) END

select * from CARRITO

Select ca.Id as IdCarrito, ca.Importe, a.ID as IdArticulo, a.Producto, a.Precio, c.Nombre, e.cantidad, e.Descuento from Elemento as e 
INNER JOIN ARTICULO as a on a.id = e.idArticulo 
INNER JOIN CATEGORIA as c on c.ID = a.IdCategoria  
INNER JOIN CARRITO as ca on ca.id = e.idCarrito

declare @nombre varchar(120)
declare @apellido varchar(120)
declare @dNI int
declare @direccion varchar(600)
declare @email varchar(600)
declare @telefono int
declare @condicion int

set @nombre = 'Jorge'
set @apellido = 'Bacque'
set @dNI= 33119411
set @direccion = 'Olazabal 479'
set @email = 'jonatanbacque@hotmail.com'
set @telefono = 1135228893
set @condicion = 1

INSERT into PERSONA(Nombre, Apellido, DNI, Direccion, Email, Telefono, condicion) VALUES(@nombre, @apellido, @dNI, @direccion, @email, @telefono, @condicion)

select * from Persona

INSERT into Usuario(IdPersona, Nombre, Password, Nivel) VALUES(1, 'jorgito', 'klapaus1', 1)

Select u.ID, p.ID, p.Nombre, p.Apellido, p.DNI, p.Direccion, p.Email, p.Telefono, p.condicion , u.nombre, u.password, u.nivel from USUARIO as u
INNER JOIN PERSONA as p on p.id=u.idPersona
Where  p.condicion =1

INSERT into METODOENVIO(Nombre, Detalle) VALUES ('Retiro en Sucursal','Coordinar finalizada la compra con el vendedor'),
('Envio por Correo','Coordinar finalizada la compra con el vendedor'),
('Envio por Encomienda','Coordinar finalizada la compra con el vendedor'),
('Envio por Moto','Coordinar finalizada la compra con el vendedor')

select * from METODOENVIO