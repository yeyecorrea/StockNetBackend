DELETE FROM Negocios;
DBCC CHECKIDENT ('Negocios', RESEED, 0);
DELETE FROM AspNetUsers;
DBCC CHECKIDENT ('AspNetUsers', RESEED, 0);
select * from dbo.AspNetUsers
select * from dbo.Negocios

INSERT INTO Negocios (Nombre, FotoUrl, Nit, Direccion, Telefono, Correo, ApplicationUserId)
VALUES (
    'La Casa del Software S.A.S',
    'https://example.com/logo.png',
    '901234567-8',
    'Cra. 45 #10-34, Medellín, Antioquia',
    '+57 304 123 4567',
    'contacto@lacasadelsoftware.com',
    'c9aba881-446e-4fc7-a41c-3b4e7d1180c1' -- <-- Reemplaza por un ApplicationUser.Id válido
);

SELECT 
    u.Id AS UsuarioId,
    u.UserName,
    u.Email,
    n.Id AS NegocioId,
    n.Nombre AS NombreNegocio,
    n.Nit,
    n.Direccion,
    n.Telefono,
    n.Correo
FROM AspNetUsers u
INNER JOIN Negocios n ON u.Id = n.ApplicationUserId;

