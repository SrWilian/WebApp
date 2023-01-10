Create database Ecociudad
go
use Ecociudad
go

create table Cliente(
	idCliente int constraint pk_idCliente primary key identity,
	razonSocial varchar(50) not null,
	dni varchar(8) not null,
	correo varchar(50),
	telefono int,
	direccion varchar(50)
)
go
create procedure spCliente(
	@razonSocial varchar(50),
	@dni varchar(8),
	@correo varchar(50),
	@telefono int,
	@direccion varchar(50)
)
as
BEGIN
	insert into CLIENTE values (@razonSocial, @dni, @correo, @telefono,@direccion);
END
GO

CREATE OR ALTER PROCEDURE spEliminarCliente(
	@idCliente int
)
AS
BEGIN
	delete CLIENTE where idCliente = @idCliente;
END
GO

CREATE OR ALTER PROCEDURE spBuscarCliente(
	@Campo varchar(50)
)
AS
BEGIN
	Select *from Cliente where razonSocial like @Campo+'%'
	or dni like @Campo+'%'
	
END
go
CREATE OR ALTER PROCEDURE spBuscarIdCliente(
	@IdCliente int
)
as
BEGIN
	Select *from Cliente where IdCliente = @IdCliente	
END
GO
CREATE OR ALTER PROCEDURE spListarCliente
as
BEGIN
	Select *from Cliente
END
GO