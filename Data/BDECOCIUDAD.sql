Create database EcoMallki
go
use EcoMallki
go

-----------------------CLIENTE------------
-- TABLA CLIENTE

----------------TABLA EMPLEADO------------------------
create table empleado(
idEmplead int  primary key identity,
nombres varchar(100),
apellidos varchar(100),
email varchar(80),
dirección varchar(200),
celular varchar(9),
Departamento int,

)
go
-----COMBOBOX DEPARTAMENTO------
create table departamento(
idDepartamento int  primary key identity,
NombreDepartamento varchar(50)
)

go
-----TABLA USUARIOS-----
ALTER procedure [dbo].[spRegistrarusuario](
@email varchar(80),
@clave varchar(25),
@registrado bit output,
@Mensaje varchar(100) output
)
as 
begin
if exists (select * FROM USUARIO where email = @email)
raiserror('EL USUARIO YA FUE REGISTRADO, POR FAVOR INGRESE UNO NUEVO',16,1 )
ELSE
insert into USUARIO 
values(@email,@clave)
set @registrado='1'
set @Mensaje='Correo Exitoso'
end
create table USUARIO(
idUsuario int primary key identity,
email varchar(80),
clave varchar(25)
)
go
create procedure spRegistrarusuario(
@email varchar(80),
@clave varchar(25),
@registrado bit output,
@Mensaje varchar(100) output
)
as 
begin
	if(@email = null)

	begin	
	set @Mensaje = 'Correo no válido'
	end
	if(not exists(select * from USUARIO where email = @email))
		begin
			insert into USUARIO(email,clave) values (@email,@clave)
			set @registrado = 1
			set @Mensaje = 'Registro exitoso'
		end
	else
		begin
			set @registrado = 0
			set @Mensaje = 'Correo Existente'
		end
end
go
Create Procedure spValidarUsuario(
@email varchar(80),
@clave varchar(25)
)
as
begin
	if(exists(select * from USUARIO where email = @email and clave = @clave))
		select idUsuario from USUARIO  where email = @email and clave = @clave
		else
			select '0'

end
go


CREATE TABLE usuarios(
	id int IDENTITY(1,1) primary key NOT NULL,
	email varchar(100) NOT NULL,
	password varchar(50) NOT NULL,
	idState int NOT NULL,
	edad int 
 )

 CREATE TABLE dbo.cstate(
	id int IDENTITY(1,1)  primary key,
	name varchar(50) NULL
 )




 
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
@idCliente int)
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