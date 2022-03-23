-- 8/8/2021
-- Script para realizar consultas, funciones
-- Andr�s Villalobos Mej�a

USE BD_INSTITUTO_TRIATLON_ANDRES
GO

-- Script donde se realizar�n las consultas funcionales para alg�n usuario

-- ............Consultas de selecci�n simples (critirios, where, maneras de join)........... 
--1 Muestra las fechas de inicio y fin de cada m�dulo con su entrenadores
GO
CREATE OR ALTER  VIEW vistaInfoEntrenadores AS
SELECT	NOMBRE_MODULO, FECHA_INICIO_MODULO, FECHA_FINAL_MODULO, NOMBRE_ATLETA, APELLIDO1_ATLETA
FROM	MODULOS M INNER JOIN MODULOS_ABIERTOS MA 
	ON	M.COD_MODULO = MA.COD_MODULO

	INNER JOIN MATRICULAS MAT
	ON MA.COD_MODULO_ABIERTO = MAT.COD_MODULO_ABIERTO

	INNER JOIN ATLETAS A
	ON MAT.COD_ATLETA = A.COD_ATLETA
GO

--2 El nombre del entrenador del atleta 2
GO
CREATE OR ALTER  VIEW vistaProfeAtleta2 AS
SELECT	NOMBRE_ATLETA + ' '+ APELLIDO1_ATLETA + ' ' + APELLIDO2_ATLETA AS 'NOMBRE DEL ATLETA',
		NOMBRE_ENTRENADOR + ' '+ APELLIDO1_ENTRENADOR + ' ' + APELLIDO2_ENTRENADOR AS 'NOMBRE DEL ENTRENADOR ASIGNADO'
FROM	ENTRENADORES E RIGHT JOIN MODULOS_ABIERTOS MA 
		ON E.COD_ENTRENADOR = MA.COD_ENTRENADOR

		RIGHT JOIN MATRICULAS MAT
		ON MA.COD_MODULO_ABIERTO = MAT.COD_MODULO_ABIERTO

		RIGHT JOIN ATLETAS A
		ON MAT.COD_ATLETA = A.COD_ATLETA

		WHERE A.COD_ATLETA = 2
GO

--3 Muestra la info de los m�dulos con su programa pero con palabras no con c�digos
GO 
CREATE OR ALTER  VIEW vistaModulosProgramas AS
SELECT NOMBRE_PROGRAMA, NOMBRE_MODULO
FROM	PROGRAMAS P INNER JOIN MODULOS_PROGRAMA MP
		ON P.COD_PROGRAMA = MP.COD_PROGRAMA

		INNER JOIN MODULOS M
		ON MP.COD_MODULO = M.COD_MODULO
GO
SELECT * FROM vistaModulosProgramas

--4 Muestra todos los entrenadores y algunos con su m�dulo asignado y cambia a no registrado a los que no tiene segundo n�mero
GO
CREATE OR ALTER  VIEW vistaSinCelular2 AS
SELECT	NOMBRE_MODULO, NOMBRE_ENTRENADOR, APELLIDO1_ENTRENADOR, TELEFONO1_ENTRENADOR,
'SEGUNDO TELEFONO DEL ENTRENADOR' = CASE 
						WHEN TELEFONO2_ENTRENADOR IS NULL THEN 'NO REGISTRADO'
						ELSE CONVERT(varchar, TELEFONO2_ENTRENADOR, 103) -- Se convierte a VARCHAR para mostrar el n�mero sino lo elimina
						END
FROM	ENTRENADORES E LEFT JOIN MODULOS_ABIERTOS MA
	ON	E.COD_ENTRENADOR = MA.COD_ENTRENADOR

	LEFT JOIN MODULOS M
	ON	MA.COD_MODULO = M.COD_MODULO

	WHERE E.COD_ENTRENADOR = MA.COD_ENTRENADOR
GO
SELECT * FROM vistaSinCelular2

-- 5 Muestra a todos los entrenadores aunque no tengan horario asignado
GO
CREATE OR ALTER  VIEW vistaProfeConSinHorario AS
SELECT	NOMBRE_ENTRENADOR, APELLIDO1_ENTRENADOR, DIA_LUNES, DIA_MARTES, DIA_MIERCOLES, DIA_JUEVES, DIA_VIERNES 
FROM	ENTRENADORES E LEFT JOIN HORARIO_ENTRENADORES HE
		ON E.COD_ENTRENADOR = HE.COD_ENTRENADOR
GO

--6 Muestra los horarios disponibles para los m�dulos
SELECT	NOMBRE_MODULO, DIA_LUNES, DIA_MARTES, DIA_MIERCOLES, DIA_JUEVES, DIA_VIERNES, DIA_SABADO, DIA_DOMINGO
FROM	MODULOS M RIGHT JOIN MODULOS_ABIERTOS MA 
		ON M.COD_MODULO = MA.COD_MODULO

		RIGHT JOIN HORARIO_MODULOS HM
		ON MA.COD_HORARIO_MODULOS = HM.COD_HORARIO_MODULOS

		WHERE MA.COD_HORARIO_MODULOS IS NULL
GO

-- ...............Consultas de selecci�n utilizando funciones agregadas (having, group by)...........
--1 Estudiantes reclutados y dinero
GO
CREATE OR ALTER  VIEW  vistaLogros AS
SELECT	COUNT(COD_ATLETA) AS 'ESTUDIANTES INSCRIPTOS', SUM(MONTO_CANCELADO) AS 'MONTO RECLUTADO'
FROM	MATRICULAS
HAVING  SUM(MONTO_CANCELADO) > 500000
GO

--2 Nombre del estudiante, la fecha de la matricula y su estado
GO
CREATE OR ALTER  VIEW vistaInfoEstudiante AS
SELECT	UPPER(NOMBRE_ATLETA) AS 'NOMBRE ATLETA', DAY(FECHA_MATRICULA) AS 'FECHA DE MATRICULA', ESTADO
FROM	ATLETAS A INNER JOIN MATRICULAS M
		ON A.COD_ATLETA = M.COD_ATLETA

GROUP BY NOMBRE_ATLETA, FECHA_MATRICULA,ESTADO
GO

--3 Entrenadores con que cuenta con el segundo tel�fono y que su nombre empiece con R
GO
CREATE OR ALTER  VIEW vistaProfesConCelular2 AS
SELECT	LOWER(NOMBRE_ENTRENADOR) AS 'NOMBRE EN MIN�SCULA', LOWER(APELLIDO1_ENTRENADOR) AS 'APELLIDO EN MIN�SCULA', COUNT(TELEFONO2_ENTRENADOR)  AS 'ACTIVO EL SEGUNDO N�MERO'
FROM	ENTRENADORES E

WHERE E.NOMBRE_ENTRENADOR LIKE 'R%'

GROUP BY NOMBRE_ENTRENADOR, APELLIDO1_ENTRENADOR
HAVING  COUNT(TELEFONO2_ENTRENADOR) = 1
GO

--4 Total de horas del curso
GO
CREATE OR ALTER  VIEW vistaTotalHoras AS
SELECT SUBSTRING(NOMBRE_PROGRAMA,17,9) AS 'ESPECIALIDAD DEL CURSO', SUM(HORAS_DURACION_MODULO) AS 'TOTAL DE HORAS'
FROM	PROGRAMAS INNER JOIN MODULOS_PROGRAMA
		ON PROGRAMAS.COD_PROGRAMA = MODULOS_PROGRAMA.COD_PROGRAMA

		INNER JOIN MODULOS
		ON MODULOS_PROGRAMA. COD_MODULO = MODULOS.COD_MODULO

GROUP BY NOMBRE_PROGRAMA
GO

--5 Cantidad de estudiantes por m�dulo
GO
CREATE OR ALTER  VIEW vistaEstudiantesModulo AS
SELECT	COUNT(MAT.COD_ATLETA) AS 'CANTIDAD DE ATLETAS', NOMBRE_MODULO
FROM	ATLETAS A INNER JOIN MATRICULAS MAT
		ON A.COD_ATLETA = MAT.COD_ATLETA

		INNER JOIN MODULOS_ABIERTOS MA
		ON MAT.COD_MODULO_ABIERTO = MA.COD_MODULO_ABIERTO

		RIGHT JOIN MODULOS M -- Right join para que muestro todos los registros en la tabla m�dulos
		ON M.COD_MODULO = MA.COD_MODULO

GROUP BY NOMBRE_MODULO
GO

--6 Busqueda el �ltimo d�a escogido para vacaciones
GO
CREATE OR ALTER  VIEW vistaUltimoDiaVaca AS
SELECT	MAX(DIA_FINAL_INCAPACIDADES_EVENTOS) AS '�LTIMO D�A LIBRE', SUBSTRING(OBSERVACIONES_INCAPACIDADES_EVENTOS,1,10) AS EVENTO
FROM	INCAPACIDADES_EVENTOS

GROUP BY OBSERVACIONES_INCAPACIDADES_EVENTOS
GO

--7 A�o de nacimiento de cada entrenador
GO
CREATE OR ALTER  VIEW vistaAlProfe AS
SELECT	MIN(YEAR(FECHA_NACIMIENTO_ENTRENADOR)) AS 'A�O DE NACIMIENTO', NOMBRE_ENTRENADOR
FROM	ENTRENADORES

GROUP BY NOMBRE_ENTRENADOR 
HAVING MIN(YEAR(FECHA_NACIMIENTO_ENTRENADOR)) < 2000
GO

--8 Cantidad de estudiantes de sexo mujer
GO
CREATE OR ALTER  VIEW vistoAtletasMujer AS
SELECT	COUNT(DISTINCT(ID_ATLETA)) AS 'CANTIDAD DE MUJERES', 'Costarricenses' AS 'NACIONALIDAD' --Se crea una constante
FROM	ATLETAS

WHERE GENERO = 'F'
GO

-- .....................Consultas de selecci�n ordenando datos......................
--1 Muestra a los entrenadores que estan asignados a un m�dulo
SELECT	NOMBRE_ENTRENADOR + ' ' + APELLIDO1_ENTRENADOR +' ' + APELLIDO2_ENTRENADOR AS 'WORKING ON FRIDAYS'
FROM	ENTRENADORES E INNER JOIN HORARIO_ENTRENADORES HE
		ON E.COD_ENTRENADOR = HE.COD_ENTRENADOR

WHERE HE.DIA_VIERNES = 1
ORDER BY 1;

--2 Muestra los estudiantes de menor a mayor (NO SE USA VISTA POR EL ORDER BY)
SELECT	NOMBRE_ATLETA, APELLIDO1_ATLETA, FECHA_NACIMIENTO_ATLETA
FROM	ATLETAS

ORDER BY FECHA_NACIMIENTO_ATLETA DESC

--......................Consultas de selecci�n con uni�n o con subconsultas.........
--1 Cantidad de estudiantes en cada m�dulo con su respetivo programa
GO
CREATE OR ALTER  VIEW vistaCantidadEstu AS
SELECT	NOMBRE_PROGRAMA, NOMBRE_MODULO, (SELECT COUNT(MATR.COD_ATLETA)
										FROM ATLETAS A INNER JOIN MATRICULAS MATR
											ON A.COD_ATLETA = MATR.COD_ATLETA
											
											INNER JOIN MODULOS_ABIERTOS MA
											ON MATR.COD_MODULO_ABIERTO = MA.COD_MODULO_ABIERTO
											
											WHERE MA.COD_MODULO = M.COD_MODULO) AS 'CANTIDAD DE ESTUDIANTES'
FROM	PROGRAMAS P INNER JOIN MODULOS_PROGRAMA MA
		ON P.COD_PROGRAMA = MA.COD_PROGRAMA

		INNER JOIN MODULOS M
		ON MA.COD_MODULO = M.COD_MODULO
GO

--2 Muestra las fechas de vacaciones a partir del 15 de Noviembre
GO
CREATE OR ALTER  VIEW vistaFechasNoviem AS
SELECT	NOMBRE_ENTRENADOR + ' '+ APELLIDO1_ENTRENADOR +' '+ APELLIDO2_ENTRENADOR AS ENTRENADOR, DIA_INICIO_INCAPACIDADES_EVENTOS AS 'FECHAS A PARTIR DE NOV'
FROM	ENTRENADORES E INNER JOIN INCAPACIDADES_EVENTOS IE
		ON E.COD_ENTRENADOR = IE.COD_ENTRENADOR

WHERE	DIA_INICIO_INCAPACIDADES_EVENTOS BETWEEN '2021-11-15' AND (SELECT MAX(DIA_INICIO_INCAPACIDADES_EVENTOS)
																	FROM INCAPACIDADES_EVENTOS 
																	WHERE E.COD_ENTRENADOR = IE.COD_ENTRENADOR)
GO
																		
--........................Consultas del tipo que guste seleccion...............
--1 Se muestra a los atletas que deben pagar 
GO
CREATE OR ALTER  VIEW vistaFaltaPago AS
SELECT	NOMBRE_ATLETA, APELLIDO1_ATLETA, APELLIDO2_ATLETA, MONTO_CANCELADO, 'DEBE PAGO' AS COMENTRARIO -- Se hace una constante para dar informaci�n extra
FROM	ATLETAS A INNER JOIN MATRICULAS M
		ON A.COD_ATLETA = M.COD_ATLETA

WHERE TIPO_COBRO = 'CURSO'
GO

--2 Personas en el curso que viven lejos o no en Alajuela
GO
CREATE OR ALTER  VIEW vistaLargoViaje AS
SELECT	DISTINCT( NOMBRE_ENTRENADOR) + ' ' + APELLIDO1_ENTRENADOR + ' '+ APELLIDO2_ENTRENADOR AS ENTRENADOR, PROVINCIA_ENTRENADOR, 
		NOMBRE_ATLETA + ' '+ APELLIDO1_ATLETA +' '+APELLIDO2_ATLETA AS ATLETA, PROVINCIA_ATLETA
FROM	ATLETAS A INNER JOIN MATRICULAS MATR
		ON A.COD_ATLETA = MATR.COD_ATLETA

		INNER JOIN MODULOS_ABIERTOS MA
		ON MATR.COD_MODULO_ABIERTO = MA.COD_MODULO_ABIERTO

		INNER JOIN ENTRENADORES E
		ON MA.COD_ENTRENADOR = E.COD_ENTRENADOR
		
WHERE	E.PROVINCIA_ENTRENADOR <> 'ALAJUELA' OR A.PROVINCIA_ATLETA <> 'ALAJUELA'
GO
--Select * FROM vistaLargoViaje

-- ....................Procedimientos Almacenados (manejo de transacciones, l�gica).............
--1 Ingresa un nuevo Atleta a la misma tabla pero sin matricular
GO
CREATE OR ALTER PROCEDURE SP_INGRESAR_ATLETA (@cod_atleta int OUT, -- se coloca un out para usar la variable de entrada y salida m�s adelante
												@id_atleta varchar(30),
												@nombre_atleta varchar(20),
												@apellido2_atleta varchar(20),
												@apellido1_atleta varchar(20),
												@telefono1_atleta varchar(15),
												@telefono2_atleta varchar(15),
												@genero varchar(2),
												@provincia_atleta varchar(20),
												@distrito_atleta varchar(20),
												@canton_atleta varchar(20),
												@fecha_nacimiento date,
												@msj varchar(50) OUT )
AS --Sentencia del proceso almacenado
BEGIN TRY
	BEGIN TRANSACTION  	
		INSERT INTO ATLETAS (ID_ATLETA, NOMBRE_ATLETA, APELLIDO1_ATLETA , APELLIDO2_ATLETA , TELEFONO1_ATLETA , TELEFONO2_ATLETA , GENERO, 
								PROVINCIA_ATLETA , DISTRITO_ATLETA ,CANTON_ATLETA, FECHA_NACIMIENTO_ATLETA)
							VALUES(@id_atleta ,
									@nombre_atleta,
									@apellido2_atleta,
									@apellido1_atleta,
									@telefono1_atleta,
									@telefono2_atleta,
									@genero,
									@provincia_atleta,
									@distrito_atleta,
									@canton_atleta,
									@fecha_nacimiento)
					-- Los OUT de salida anteriores cuando se usaron de par�metros
					SELECT @cod_atleta = IDENT_CURRENT('ATLETAS') -- Es lo mismo que hacer un set(establecer un valor)
					SET @msj =  '�Atleta ingresado en la Base de Datos!'
					COMMIT TRANSACTION -- Se cierra correctamenta la transacci�n
END TRY
BEGIN CATCH -- Si hay un error se salta todo y el ROLLBACK desase todo lo realizado
	ROLLBACK TRANSACTION 
	PRINT ERROR_MESSAGE()
END CATCH
GO

-- ................................Prueba SP1............................
-- Se declaran las variables para su uso
DECLARE @cod_atleta int
DECLARE @id_atleta varchar(30)
DECLARE	@nombre_atleta varchar(20)
DECLARE @apellido2_atleta varchar(20)
DECLARE @apellido1_atleta varchar(20)
DECLARE	@telefono1_atleta varchar(15)
DECLARE	@telefono2_atleta varchar(15)
DECLARE @genero varchar(2)
DECLARE	@provincia_atleta varchar(20)
DECLARE	@distrito_atleta varchar(20)
DECLARE	@canton_atleta varchar(20)									
DECLARE @fecha_nacimiento date		
DECLARE @msj varchar(50)

--Se establece lo que tendr� cada variable
SET @id_atleta = '222345574'
SET	@nombre_atleta = 'Juan'
SET @apellido2_atleta = 'Vasquez'
SET @apellido1_atleta = 'Mendez'
SET	@telefono1_atleta = '89877321'
SET	@telefono2_atleta = '23214565'
SET @genero = 'M'
SET	@provincia_atleta = 'Alajuela' 
SET	@distrito_atleta = 'Palmares'
SET	@canton_atleta = 'Esquipulas'
SET @fecha_nacimiento = '2000-05-02'

-- Se ejecuta el proceso con la informaci�n de las variables
EXECUTE SP_INGRESAR_ATLETA
	@cod_atleta OUTPUT, --No se debe asignar el tipo de dato, solo si es entrada y salida con OUTPUT
	@id_atleta,
	@nombre_atleta,
	@apellido2_atleta, 
	@apellido1_atleta ,
	@telefono1_atleta,
	@telefono2_atleta ,
	@genero ,
	@provincia_atleta,
	@distrito_atleta ,
	@canton_atleta,							
	@fecha_nacimiento,
	@msj

PRINT 'Nuevo C�digo: '+ CAST(@cod_atleta AS varchar(30))
PRINT @msj

SELECT * FROM ATLETAS

--2 Proceso almacenado para saber si un estudiante tiene un m�dulo asignado
GO
CREATE OR ALTER PROCEDURE SP_ATLETA_ASIGNADO (@cod_atleta int ) --  Los par�metros ocupan el tipo de datos
AS
	BEGIN
		IF EXISTS (SELECT 1
					FROM MATRICULAS WHERE COD_ATLETA = @cod_atleta) -- Si el c�digo esta en la tabla que envie un 1

		RETURN 1
		 ELSE
		RETURN 0
	END
GO

-- ................................Prueba SP2............................
-- Se usan 2 variables, una tendr� el c�digo del profesor y otra si esta matriculado o no
DECLARE @cod_atleta int
DECLARE @matriculadoOno bit

SET @cod_atleta = 11

EXECUTE @matriculadoOno = SP_ATLETA_ASIGNADO -- se le asigna la variable lo que regrese el proceso almacenado
	@cod_atleta

--Se usan unas condiciones para mandar un mensaje si existe o no
IF @matriculadoOno = 1
	PRINT 'El Atleta est� matriculado'
ELSE
	PRINT 'El Atleta a�n no esta matriculado'

SELECT * FROM ATLETAS

--**Las funciones y triggers se crean en el script de la creaci�n de la BD para que se note cuando se ejecute el script de ingresar datos**