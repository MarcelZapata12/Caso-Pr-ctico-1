--Cambiar el tipo de descripcion para mas facilidad de informacion
ALTER TABLE dbo.Parametros
ALTER COLUMN Descripcion VARCHAR(50) NOT NULL;



--Inserts para parametros
INSERT INTO dbo.Parametros (Descripcion)
VALUES
('Película'),
('Serie'),
('Documental'),
('Acción'),
('Comedia'),
('Terror');


--scaffold
Scaffold-DbContext "Server=Marcel\MSSQLSERVER01;Database=Peliculas;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entities -Force

--Procesos 
CREATE PROCEDURE [dbo].[sp_GetAllProgramas]
AS
BEGIN

    SET NOCOUNT ON;

    SELECT 
        ProgramaId,
        Nombre,
        Tipo,
        Categoria
    FROM 
        dbo.Programas
    ORDER BY 
        ProgramaId DESC;
END


----

CREATE PROCEDURE [dbo].[sp_AddPrograma]
    -- Parámetros del procedimiento
    @Nombre NVARCHAR(50),
    @Tipo INT,
    @Categoria INT
AS
BEGIN
    -- Evita que se devuelva el número de filas afectadas
    SET NOCOUNT ON;

    -- Inserta un nuevo registro en la tabla Programas
    INSERT INTO dbo.Programas (Nombre, Tipo, Categoria)
    VALUES (@Nombre, @Tipo, @Categoria);
END
GO