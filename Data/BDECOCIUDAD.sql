Create database Ecociudad
go
use Ecociudad
go

-----------------------CLIENTE------------
-- TABLA CLIENTE
create table Cliente(
	idCliente int constraint pk_idCliente primary key identity,
	razonSocial varchar(50) not null,
	dni varchar(8) not null,
	correo varchar(50),
	telefono int,
	direccion varchar(50),
	estCliente bit,
)
go

select * from Cliente
go
-- INSERTAR CLIENTE

create procedure spAgregarCliente(
	@razonSocial varchar(50),
	@dni varchar(8),
	@correo varchar(50),
	@telefono int,
	@direccion varchar(50),
	@estCliente bit
)
as
BEGIN
	insert into CLIENTE(razonSocial, dni, correo, telefono,direccion,estCliente )
	 values (@razonSocial, @dni, @correo, @telefono,@direccion,@estCliente);
END
GO
-- EDITAR CLIENTE
/*
--drop procedure spEditarCliente
create PROCEDURE spEditarCliente(
	@idCliente int,
	@razonSocial varchar(50),
	@dni varchar(8),
	@correo varchar(50),
	@telefono int,
	@direccion varchar(50),
	@EstadoCliente bit
	)
	as
	begin
	update Cliente set 
	--idCliente = @idCliente,
	razonSocial = @razonSocial,
	dni = @dni,
	correo = @correo,
	telefono = @telefono,
	direccion = @direccion
	--EstCliente  = @EstadoCliente
	--EstCliente  =0
	where idCliente = @idCliente
	end
*/
go
create or alter PROCEDURE spEditarCliente(
	@idCliente int,		 @razonSocial varchar(50), @dni varchar(8),
	@correo varchar(50), @telefono int,			   @direccion varchar(50),
	@EstadoCliente bit
	)
	as
	begin
	update Cliente set 
	razonSocial = @razonSocial,
	dni = @dni,
	correo = @correo,
	telefono = @telefono,
	direccion = @direccion,
	EstCliente  = @EstadoCliente
	where idCliente = @idCliente
	end
go
-- LISTAR CLIENTE
create or alter PROCEDURE spListarCliente

as
BEGIN
	Select *from Cliente
	where EstCliente = '1'
END
GO


-- INHABILITAR CLIENTE
CREATE OR ALTER PROCEDURE spDeshabilitarCliente(
@idCliente bit)
AS
BEGIN
	update Cliente set estCliente = '0'
	where idCliente = @idCliente;
END
GO


-- BUSCAR CLIENTE
CREATE PROCEDURE spBuscarCliente(
	@razonSocial varchar(50)
)
AS
BEGIN
	Select *from Cliente where razonSocial like @razonSocial+'%'
END

go









/*

CREATE PROCEDURE spBuscarCliente(
	@Campo varchar(50)
)
AS
BEGIN
	Select *from Cliente where razonSocial like @Campo+'%'
	or dni like @Campo+'%'
	
END*/
