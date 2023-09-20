insert into Usuario(IdRol, Nombre, Apellido, [Login], [Password], Estatus, FechaRegistro) 
values(1, 'Juan', 'Pérez', 'jp', '81ce825ec1ace3ee7cf7e92df2cc9905', 1, SYSDATETIME());

insert into Rol(Nombre) 
values('Administrador');

select*from Usuario