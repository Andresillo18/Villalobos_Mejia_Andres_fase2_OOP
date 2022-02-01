-- Instituto Nacional de Aprendizaje
/*
	Módulo: Gestión de Bases de Datos
	Fecha: 15 de junio, 2021
	Estudiante: Andrés Villalobos Mejía
*/

Create database BD_INSTITUTO_TRIATLON_ANDRES
GO

USE BD_INSTITUTO_TRIATLON_ANDRES
GO

--................................Creación de Tablas...........................

CREATE TABLE ENTRENADORES(
	COD_ENTRENADOR int IDENTITY,
	ID_ENTRENADOR varchar(30) NOT NULL,
	NOMBRE_ENTRENADOR varchar(20) NOT NULL,
	APELLIDO1_ENTRENADOR varchar(20) NOT NULL,
	APELLIDO2_ENTRENADOR varchar(20) NOT NULL,
	TELEFONO1_ENTRENADOR varchar(15) NOT NULL,
	TELEFONO2_ENTRENADOR varchar(15),
	CORREO_ENTRENADOR varchar(150),
	FECHA_NACIMIENTO_ENTRENADOR date NOT NULL,
	PROVINCIA_ENTRENADOR varchar(20) NOT NULL,
	DISTRITO_ENTRENADOR varchar(20) NOT NULL,
	CANTON_ENTRENADOR varchar(20) NOT NULL,
	ESTADO_ENTRENADOR bit DEFAULT 1
);

--En esta siguiente tabla solo se ingresaron 3 campos porque no se considera información mas importante sobre una certificación de un entrenador
CREATE TABLE CERTIFICACIONES(
	COD_CERTIFICACION int IDENTITY,
	COD_ENTRENADOR int NOT NULL,
	GIMNASIO_ESPECIFICACION bit,
	NATACION_ESPECIFICACION bit, 
	MARATON_ESPECIFICACION bit,
	CICLISMO_ESPECIFICACION bit
);

CREATE TABLE REGISTRO_HORAS_LABORADAS(
	COD_REGISTRO_HORALABO int IDENTITY,
	COD_ENTRENADOR int NOT NULL,
	DIA_REGISTRO_HORALABO date NOT NULL,
	HORA_INICIO_REGISTRO_HORALABO time(0) NOT NULL,
	HORA_FINAL_REGISTRO_HORALABO time(0) NOT NULL -- Al colocar el (0) eliminará los ceros de mas al mostrar los registros ingresados, solo dejando la hora, minutos y segundos
);

CREATE TABLE HORARIO_ENTRENADORES(
	COD_HORARIO_ENTRENADOR INT IDENTITY,
	COD_ENTRENADOR INT NOT NULL,
	DIA_LUNES bit,
	DIA_MARTES BIT,
	DIA_MIERCOLES BIT,
	DIA_JUEVES BIT,
	DIA_VIERNES	BIT,
	DIA_SABADO BIT,
	DIA_DOMINGO BIT,
	HORA_INICIO_HORARIO TIME(0),
	HORA_FIN_HORARIO TIME(0)
);

CREATE TABLE INCAPACIDADES_EVENTOS(
	COD_INCAPACIDADES_EVENTOS int IDENTITY,
	COD_ENTRENADOR int NOT NULL,
	DIA_INICIO_INCAPACIDADES_EVENTOS date,
	DIA_FINAL_INCAPACIDADES_EVENTOS	date,
	OBSERVACIONES_INCAPACIDADES_EVENTOS varchar(500) -- Suceso o evento
);

CREATE TABLE PROGRAMAS(
	COD_PROGRAMA int IDENTITY, -- no se escribe el NOT NULL porque es una llave primaria y le permite la misma caracteristica
	NOMBRE_PROGRAMA varchar(40) NOT NULL,
	DESCRIPCION_PROGRAMA varchar(150) NOT NULL,
	ESTADO BIT NOT NULL DEFAULT 1,	
	OBSERVACIONES_PROGRAMA varchar(500)
);

 CREATE TABLE MODULOS(
	COD_MODULO int IDENTITY,
	NOMBRE_MODULO varchar(30) NOT NULL,
	HORAS_DURACION_MODULO smallint NOT NULL,
	REQUESITOS_MODULO varchar(300) NOT NULL, -- Estas 2 fechas que se establecen aquí se refieren a la fecha que se estima a empezar y terminar
);

-- En esta tabla solo se ingresaron 2 campos porque se considera tabla de unión y para saber cuales módulos tiene un programa
CREATE TABLE MODULOS_PROGRAMA( -- es una tabla de unión y por eso tendra 2 fk y una llave compuesta para determinar la redundancia
	COD_PROGRAMA int NOT NULL, 
	COD_MODULO int NOT NULL
);

CREATE TABLE HORARIO_MODULOS(
	COD_HORARIO_MODULOS	Int IDENTITY CONSTRAINT PK_HORARIO_MODULOS PRIMARY KEY,
	DIA_LUNES BIT,
	DIA_MARTES BIT,
	DIA_MIERCOLES BIT,
	DIA_JUEVES BIT,
	DIA_VIERNES	BIT,
	DIA_SABADO BIT,
	DIA_DOMINGO BIT,
	HORA_INICIO_HORARIO TIME(0),
	HORA_FIN_HORARIO TIME(0)
	)

CREATE TABLE MODULOS_ABIERTOS(
	COD_MODULO_ABIERTO int IDENTITY,
	COD_ENTRENADOR int NOT NULL,
	COD_MODULO int NOT NULL,
	COD_HORARIO_MODULOS INT NOT NULL,
	FECHA_INICIO_MODULO date, --Estas otras 2 fechas se establecen cuando ya el módulo se haya abierto con los estudiantes y las fechas se afectarán cuando
	FECHA_FINAL_MODULO date, --  no haya podido dar la clase el día establecido, ahí es donde afecta la tabla INCAPACIDADES_EVENTOS por la relación.
	OBSERVACIONES_MODULO_ABIERTO varchar(500) -- Se puede ingresar problemas o información extra
);

CREATE TABLE ATLETAS(
	COD_ATLETA int IDENTITY,
	ID_ATLETA varchar(30) NOT NULL, -- se coloca un tipo de dato varchar porque la identificación de la persona puede tener letras
	NOMBRE_ATLETA varchar(20) NOT NULL,
	APELLIDO1_ATLETA varchar(20) NOT NULL,
	APELLIDO2_ATLETA varchar(20) NOT NULL,
	TELEFONO1_ATLETA varchar(15) NOT NULL,
	TELEFONO2_ATLETA varchar(15),
	GENERO varchar(2) NOT NULL,
	PROVINCIA_ATLETA varchar(20) NOT NULL,
	DISTRITO_ATLETA varchar(20) NOT NULL,
	CANTON_ATLETA varchar(20) NOT NULL,
	FECHA_NACIMIENTO_ATLETA date NOT NULL,
	ESTADO_ATLETA bit NOT NULL DEFAULT 1
);

CREATE TABLE MATRICULAS(
	--Cambio, se incluyó un campo IDENTITY para la facilidad de manejo
	COD_MATRICULA int IDENTITY,
	COD_ATLETA int NOT NULL,
	COD_MODULO_ABIERTO int NOT NULL,
	FECHA_MATRICULA date NOT NULL DEFAULT getDate(),
	ESTADO varchar(20) NOT NULL,
	NOTA_FINAL decimal(4,2),
	MONTO_CANCELADO int NOT NULL,
	TIPO_COBRO varchar(40) NOT NULL,
	TIPO_PAGO varchar(40) NOT NULL
);

-- ................................... MODIFICACIÓN DE TABLAS .........................................

-- _____________ Modificaciones a la tabla: ENTRENADORES

ALTER TABLE ENTRENADORES
	ADD CONSTRAINT PK_COD_ENTRENADOR PRIMARY KEY (COD_ENTRENADOR); --Es el índice de unidad de asignación 

ALTER TABLE ENTRENADORES
	ADD CONSTRAINT Unico_IDEntrenador UNIQUE (ID_ENTRENADOR);

ALTER TABLE ENTRENADORES
	ADD CONSTRAINT CHK_PROVINCIA_ENTRENADOR CHECK (PROVINCIA_ENTRENADOR= upper(PROVINCIA_ENTRENADOR) AND PROVINCIA_ENTRENADOR IN ('Alajuela', 'San José', 'Guanacaste', 'Puntarenas', 'Heredia', 'Cartago', 'Limón'));

-- creación del índice para los entrenadores por apellido:
CREATE INDEX IDX_Apellido1_ENTRENADORES ON ENTRENADORES (APELLIDO1_ENTRENADOR); -- Es un nonclostered

-- _____________ Modificaciones a la tabla: CERTIFICACIONES

ALTER TABLE CERTIFICACIONES
	ADD CONSTRAINT PK_COD_CERTIFICACION PRIMARY KEY (COD_CERTIFICACION);

ALTER TABLE CERTIFICACIONES
	ADD CONSTRAINT FK_COD_ENTRENADOR_CERTIF FOREIGN KEY (COD_ENTRENADOR)
	REFERENCES ENTRENADORES (COD_ENTRENADOR)
	ON UPDATE NO ACTION -- creación de restricciones de integridad 
	ON DELETE NO ACTION;

-- _____________ Modificaciones a la tabla: REGISTRO_HORAS_LABORADAS

ALTER TABLE REGISTRO_HORAS_LABORADAS
	ADD CONSTRAINT PK_COD_REGIS_HORALABO PRIMARY KEY (COD_REGISTRO_HORALABO);

ALTER TABLE REGISTRO_HORAS_LABORADAS
	ADD CONSTRAINT FK_CODENTRENADOR_REGIS FOREIGN KEY (COD_ENTRENADOR)
	REFERENCES ENTRENADORES (COD_ENTRENADOR)
	ON UPDATE NO ACTION
	ON DELETE NO ACTION;

ALTER TABLE REGISTRO_HORAS_LABORADAS
	ADD CONSTRAINT CHK_DIA_REGIS_HORALABO CHECK (DIA_REGISTRO_HORALABO >= CONVERT(datetime,CONVERT(varchar(10), getDate(), 103),103));


-- _____________ Modificaciones a la tabla: HORARIO_ENTRENADORES

ALTER TABLE HORARIO_ENTRENADORES
	ADD CONSTRAINT PK_COD_HORA_ENTRENADOR PRIMARY KEY (COD_HORARIO_ENTRENADOR);

ALTER TABLE HORARIO_ENTRENADORES
	ADD CONSTRAINT FK_COD_ENTRENADOR_HORARIO FOREIGN KEY (COD_ENTRENADOR) 
	REFERENCES ENTRENADORES (COD_ENTRENADOR)
	ON UPDATE NO ACTION
	ON DELETE NO ACTION; -- creación de restricciones de integridad 

-- _____________ Modificaciones a la tabla: INCAPACIDADES_EVENTOS

ALTER TABLE INCAPACIDADES_EVENTOS
	ADD CONSTRAINT PK_COD_INCAPAC_EVENTOS PRIMARY KEY (COD_INCAPACIDADES_EVENTOS);

ALTER TABLE INCAPACIDADES_EVENTOS
	ADD CONSTRAINT FK_COD_ENTRENADOR_INCAPACI FOREIGN KEY (COD_ENTRENADOR) 
	REFERENCES ENTRENADORES (COD_ENTRENADOR)
	ON UPDATE NO ACTION
	ON DELETE NO ACTION;

-- _____________ Modificaciones a la tabla: PROGRAMAS

ALTER TABLE PROGRAMAS
	ADD CONSTRAINT PK_PROGRAMAS PRIMARY KEY (COD_PROGRAMA);

--_________________Modificaciones a la tabla: MODULOS

ALTER TABLE MODULOS
	ADD CONSTRAINT PK_COD_MODULO PRIMARY KEY (COD_MODULO); -- Se usa la primary key como índice con unidad de asignación

ALTER TABLE MODULOS
	ADD CONSTRAINT CHK_HORAS_DURACION CHECK (HORAS_DURACION_MODULO IN (80, 110, 120, 90));

--creación del índice para los nombres de los modulos
CREATE INDEX IDX_NombresModulo ON MODULOS (NOMBRE_MODULO); -- Es un nonclostered

--_________________Modificaciones a la tabla: MODULOS_PROGRAMA

ALTER TABLE MODULOS_PROGRAMA
	ADD CONSTRAINT PK_MOD_PROGRAMA_COMPU PRIMARY KEY (COD_PROGRAMA, COD_MODULO); -- creación de una llave compuesta, se crea una llave primary pero se incluyo los 2 campos

ALTER TABLE MODULOS_PROGRAMA
	ADD CONSTRAINT FK_COD_PROGRAMA FOREIGN KEY (COD_PROGRAMA) 
	REFERENCES PROGRAMAS (COD_PROGRAMA) -- llave foranea que el campo COD_PROGRAMA de MODULOS_PROGRAMA se refiere al otro campo en la tabla PROGRAMAS
		ON UPDATE NO ACTION
		ON DELETE NO ACTION;

ALTER TABLE MODULOS_PROGRAMA
	ADD CONSTRAINT FK_COD_MOD_PROGRAMA FOREIGN KEY (COD_MODULO)
	REFERENCES MODULOS (COD_MODULO)
	ON UPDATE NO ACTION
	ON DELETE NO ACTION;

--_________________Modificaciones a la tabla: MODULOS_ABIERTOS
--NOTA*** en el diccionario solo se colocarón ejemplos de que se puede insertar en los campos DIASIMPARTIDO_MODULOS_ABIERTO y HORASIMPATIDO_MODULO_ABIERTO 
--porque se podrá escribir con bastante posibilidad cuales serán los días y horas que se llevará a cada ese módulo abierto

ALTER TABLE MODULOS_ABIERTOS
	ADD CONSTRAINT PK_COD_MOD_ABIERTO PRIMARY KEY (COD_MODULO_ABIERTO);

ALTER TABLE MODULOS_ABIERTOS
	ADD CONSTRAINT FK_COD_ENTRENADOR_M_ABIERTOS FOREIGN KEY (COD_ENTRENADOR)
	REFERENCES ENTRENADORES (COD_ENTRENADOR)
	ON UPDATE NO ACTION
	ON DELETE NO ACTION;

ALTER TABLE MODULOS_ABIERTOS
	ADD CONSTRAINT FK_COD_MOD_ABIERTOS FOREIGN KEY (COD_MODULO)
	REFERENCES MODULOS (COD_MODULO)
	ON UPDATE NO ACTION
	ON DELETE NO ACTION;

ALTER TABLE MODULOS_ABIERTOS
	ADD CONSTRAINT FK_COD_HORARIO_MODULOS FOREIGN KEY (COD_HORARIO_MODULOS)
	REFERENCES HORARIO_MODULOS (COD_HORARIO_MODULOS) 
	ON UPDATE NO ACTION
	ON DELETE NO ACTION;

 ALTER TABLE MODULOS_ABIERTOS
	ADD CONSTRAINT CHK_FEC_INICIO_MOD CHECK (FECHA_INICIO_MODULO >= CONVERT(datetime,CONVERT(varchar(10), getDate(), 103),103));

--_________________Modificaciones a la tabla: ATLETAS

ALTER TABLE ATLETAS
	ADD CONSTRAINT PK_COD_ATLETA PRIMARY KEY (COD_ATLETA); -- se elimina el índice de unidad de asignación del PK de ATLETAS para crear otro

ALTER TABLE ATLETAS
	ADD CONSTRAINT Unico_IDAtleta UNIQUE (ID_ATLETA);

ALTER TABLE ATLETAS
	ADD CONSTRAINT CHK_PROVINCIA_ATLETAS CHECK (PROVINCIA_ATLETA= upper(PROVINCIA_ATLETA) AND PROVINCIA_ATLETA IN ('Alajuela', 'San José', 'Guanacaste', 'Puntarenas', 'Heredia', 'Cartago', 'Limón'));

ALTER TABLE ATLETAS
	ADD CONSTRAINT CHK_GENERO CHECK (GENERO = UPPER(GENERO) AND GENERO IN ('M', 'F'));

--creación del índice para la tabla ATLETAS en el campo del primer apellido
CREATE INDEX IDX_Apellido1 ON ATLETAS (APELLIDO1_ATLETA);

--_________________Modificaciones a la tabla: MATRICULAS

ALTER TABLE MATRICULAS
	ADD CONSTRAINT PK_MATRIC_COMPUE PRIMARY KEY (COD_ATLETA, COD_MODULO_ABIERTO);

ALTER TABLE MATRICULAS
	ADD CONSTRAINT FK_COD_ATLETA FOREIGN KEY (COD_ATLETA) 
	REFERENCES ATLETAS (COD_ATLETA)
	ON UPDATE NO ACTION
	ON DELETE NO ACTION;

ALTER TABLE MATRICULAS
	ADD CONSTRAINT FK_COD_MOD_ABIERTO FOREIGN KEY (COD_MODULO_ABIERTO)
	REFERENCES MODULOS_ABIERTOS (COD_MODULO_ABIERTO)
	ON UPDATE NO ACTION
	ON DELETE NO ACTION;

ALTER TABLE MATRICULAS
	ADD CONSTRAINT CHK_FECHA_MATRICULA CHECK (FECHA_MATRICULA >= CONVERT(datetime,CONVERT(varchar(10), getDate(), 103),103));

ALTER TABLE MATRICULAS
	ADD CONSTRAINT CHK_ESTADO CHECK (ESTADO = upper(ESTADO) AND ESTADO IN ('en curso', 'abandonó', 'aprovado', 'reprobado'));

ALTER TABLE MATRICULAS
	ADD CONSTRAINT CHK_NOTA_FINAL CHECK (NOTA_FINAL >= 0 AND NOTA_FINAL <= 100);

ALTER TABLE MATRICULAS
	ADD CONSTRAINT CHK_MONTO_CANCELADO CHECK (MONTO_CANCELADO >= 0);

ALTER TABLE MATRICULAS
	ADD CONSTRAINT CHK_TIPO_COBRO CHECK (TIPO_COBRO =upper(TIPO_COBRO) AND TIPO_COBRO IN ('curso', 'curso y matricula'));

ALTER TABLE MATRICULAS
	ADD CONSTRAINT CHK_TIPO_PAGO CHECK (TIPO_PAGO =upper(TIPO_PAGO) AND TIPO_PAGO IN('transferencia', 'sinpe', 'tarjeta', 'efectivo'));


-- ..............................Funciones..................................
-- 1 Está función dice si la fecha ingresa se trabaja o no
GO
CREATE OR ALTER FUNCTION FN_VERIFICAR_DIA (@DiaEnRevision date, @cod_entrenador int, @cod_horario_modulos int)

RETURNS bit -- devuelve si el día se trabaja o no
AS
BEGIN 
	-- Se declaran las variables siempre cuales se vayan a usar
	DECLARE @resultado bit = 0
	IF EXISTS (	SELECT 1 
				FROM HORARIO_MODULOS

				WHERE	COD_HORARIO_MODULOS = @cod_horario_modulos 
						AND 
						-- Estas condiciones (al menos una por el OR) se cumplen si el día en la tabla HORARIO_MODULOS y se trabaja según las reglas de negocio 
						-- lunes = 1, domingo = 7
						-- DATEPART(DW,@variable) Muestra el número del día de la fecha ingresada
						
						(	( DATEPART(DW,@DiaEnRevision) = 1 AND HORARIO_MODULOS.DIA_LUNES = 1) OR
							( DATEPART(DW,@DiaEnRevision) = 2 AND HORARIO_MODULOS.DIA_MARTES = 1) OR
							( DATEPART(DW,@DiaEnRevision) = 3 AND HORARIO_MODULOS.DIA_MIERCOLES = 1) OR
							( DATEPART(DW,@DiaEnRevision) = 4 AND HORARIO_MODULOS.DIA_JUEVES = 1) OR
							( DATEPART(DW,@DiaEnRevision) = 5 AND HORARIO_MODULOS.DIA_VIERNES = 1) 
						 ) --Se elimino las condiciones de los domingos y lunes porque no eran necesarias ya por los horarios
						
						AND
						-- Y que regrese un 1 o algo si la fecha ingresada no existe
						(NOT EXISTS(SELECT	1
									FROM	INCAPACIDADES_EVENTOS
									WHERE	(INCAPACIDADES_EVENTOS.COD_ENTRENADOR = @cod_entrenador) 
											AND (@DiaEnRevision >= INCAPACIDADES_EVENTOS.DIA_INICIO_INCAPACIDADES_EVENTOS) 
											AND (@DiaEnRevision <= INCAPACIDADES_EVENTOS.DIA_FINAL_INCAPACIDADES_EVENTOS) ))
							) -- fin IF EXISTS
											
				--Todo lo anterior se cumple y manda un bit 1 si el día se trabaja y no estan en INCAPACIDADES_EVENTOS
				SET @resultado = 1 
			ELSE
				SET @resultado = 0
			-- FIN DEL IF

	RETURN @resultado
END
GO

--2 Devuelve el siguiete día de clases
CREATE OR ALTER FUNCTION FN_SIGUIENTE_DIA_CLASES(	@fechainicio date, 
													@cod_horario_modulos int, 
													@cod_entrenador int )
RETURNS DATE -- Duelve la fecha del siguiente día
AS
	BEGIN
		DECLARE @fechavalida date = @fechainicio -- fecha_inicio_modulo
		DECLARE @continuar bit = 1

		WHILE(@continuar = 1)
			BEGIN
			
				IF ((SELECT DBO.FN_VERIFICAR_DIA (@fechavalida, @cod_entrenador, @cod_horario_modulos )) = 1) -- se cumple si la fecha valida se trabaja
														
					BEGIN	
						SET @continuar = 0 -- Si es un dia en que hay clases, termina
					END
				ELSE 
					SET @fechavalida =  DATEADD(day, 1, @fechavalida) -- se le añade un día a la fecha
			
			END -- while
		
		RETURN @fechavalida
	END
GO

--3 Devuelve la fecha que termina el módulo
GO
CREATE OR ALTER FUNCTION FN_CALCULAR_FECHA_FIN_MODULO(	@fechainicio date, 
														@cod_horario_modulos int, 
														@cod_modulo int, 
														@cod_entrenador int )
RETURNS DATE

AS
	BEGIN
		DECLARE @FechaEnRevision date = @fechainicio -- FechaEnRevisión es UN DÍA (no un rango)
		DECLARE @horasdiarias decimal(4,2)
		DECLARE @HorasModulo int
		DECLARE @diasDuracion int
				
		--Lo que devulve la subconsulta es el valor de la varible (float) y luego se realiza la operación para saber los días
		SET @horasdiarias  = (	SELECT CAST( DATEDIFF(MINUTE, HORARIO_MODULOS.HORA_INICIO_HORARIO, HORARIO_MODULOS.HORA_FIN_HORARIO)  AS float) / CAST(60 AS float) --DATEDIFF ES LA DIFERENCIA ENTRES FECHAS
								FROM HORARIO_MODULOS
								WHERE HORARIO_MODULOS.COD_HORARIO_MODULOS = @cod_horario_modulos
								)

		SET @HorasModulo = (SELECT HORAS_DURACION_MODULO FROM MODULOS WHERE MODULOS.COD_MODULO = @cod_modulo) 

		SET @diasDuracion =	CEILING(@HorasModulo / @horasdiarias) -- Lo redondea hacia arriba
				

		DECLARE @cuentadias int = 1
		
		WHILE(@cuentadias < @diasDuracion) -- se detiene hasta que el contador sea mayor a los diasDuracion
			BEGIN
				
				IF	((SELECT DBO.FN_VERIFICAR_DIA(@FechaEnRevision, @cod_entrenador, @cod_horario_modulos)) = 1)
					
					-- Si es un día en que hay clases:
					BEGIN	
						SET @FechaEnRevision =  DATEADD(day, 1, @FechaEnRevision) -- le suma un día a la fecha
						SET @cuentadias = @cuentadias + 1 -- y aumenta el contador
					END

				ELSE 
					SET @FechaEnRevision =  DATEADD(day, 1, @FechaEnRevision)
				END -- WHILE
			
			-- Esta función revisa si el día siguiente se trabaja sino hasta uno que se trabaja para terminar de contar
			SET @FechaEnRevision = DBO.FN_SIGUIENTE_DIA_CLASES(@FechaEnRevision, @cod_modulo, @cod_entrenador)
			
		RETURN @FechaEnRevision
	END
GO


--...............................CREACIÓN DE LOS TRIGGERS............................
-- Cuando se ingrese los registros a la tabla MODULOS_ABIERTOS se ingrese la fecha de fin de módulo automaticamente
GO
CREATE OR ALTER TRIGGER CALCULAR_FIN_FECHA
	ON MODULOS_ABIERTOS FOR INSERT AS
	
	DECLARE @fechainicio date
	DECLARE @cod_horario_modulos int
	DECLARE @cod_modulo int
	DECLARE @cod_entrenador int
	DECLARE @fechafinal date
	
	SET @fechainicio =(SELECT FECHA_INICIO_MODULO FROM inserted)
	SET @cod_horario_modulos = (SELECT COD_HORARIO_MODULOS FROM inserted)
	SET @cod_modulo = (SELECT COD_MODULO FROM inserted)
	SET @cod_entrenador = (SELECT COD_ENTRENADOR FROM inserted)
	SET @fechafinal = ( SELECT DBO.FN_CALCULAR_FECHA_FIN_MODULO(@fechainicio, @cod_horario_modulos, @cod_modulo, @cod_entrenador) )

	UPDATE MODULOS_ABIERTOS
	SET FECHA_FINAL_MODULO = @fechafinal
	WHERE @cod_modulo = COD_MODULO AND @cod_entrenador = COD_ENTRENADOR AND @cod_horario_modulos = COD_HORARIO_MODULOS

GO

--Si el programa se pone inactivo, todas las personas inscriptas en el también
--GO
--CREATE OR ALTER TRIGGER TR_ESTADOS 
--	ON PROGRAMAS FOR UPDATE AS

--	IF (SELECT ESTADO FROM PROGRAMAS) = 0
--	BEGIN
--		UPDATE ENTRENADORES
--		SET ESTADO_ENTRENADOR = 0
		
--		UPDATE ATLETAS
--		SET ESTADO_ATLETA = 0
--	END	
--GO
--****Se comentó porque afecta la actualización de la tabla

/* PRUEBA DEL TRIGGER PROGRAMAS
 UPDATE PROGRAMAS
 SET ESTADO = 0 
 SELECT * FROM ATLETAS
 SELECT * FROM ENTRENADORES
 */

 -- Envia error si marca sabado o domingo para un día que se va a trabajar
 GO
 CREATE OR ALTER TRIGGER TR_NEGAR_DIA 
	ON HORARIO_ENTRENADORES INSTEAD OF INSERT AS -- cuando se inserta o se actualiza
	BEGIN TRY
	IF (SELECT INSERTED.DIA_SABADO FROM inserted  ) = 1 OR 
	(SELECT INSERTED.DIA_DOMINGO FROM inserted ) = 1
		BEGIN
			RAISERROR('MENSAJE: El día seleccionado no se permite según el gimnasio',16,1)
			ROLLBACK TRANSACTION
		END
	ELSE
		INSERT INTO HORARIO_ENTRENADORES
			SELECT  COD_ENTRENADOR, DIA_LUNES, DIA_MARTES, DIA_MIERCOLES, DIA_JUEVES, DIA_VIERNES, DIA_SABADO, DIA_DOMINGO, HORA_INICIO_HORARIO, HORA_FIN_HORARIO FROM inserted
		
		/* SELECT * FROM HORARIO_ENTRENADORES
		COD_ENTRENADOR = inserted.COD_ENTRENADOR,
		DIA_LUNES = inserted.DIA_LUNES,
		DIA_MARTES = inserted.DIA_MARTES,
		DIA_MIERCOLES = inserted.DIA_MIERCOLES,
		DIA_JUEVES = inserted.DIA_JUEVES,
		DIA_VIERNES = inserted.DIA_VIERNES,
		DIA_SABADO = inserted.DIA_SABADO,
		DIA_DOMINGO = inserted.DIA_DOMINGO,
		HORA_INICIO_HORARIO = inserted.HORA_INICIO_HORARIO,
		HORA_FIN_HORARIO = inserted.HORA_FIN_HORARIO
		
		FROM inserted INNER JOIN HORARIO_ENTRENADORES HE
			ON inserted.COD_ENTRENADOR = HE.COD_ENTRENADOR*/
	END TRY
	
	BEGIN CATCH     
		PRINT ERROR_MESSAGE();
	END CATCH
GO

--ALTER TABLE HORARIO_ENTRENADORES 
  -- DISABLE TRIGGER ALL  SELECT * FROM HORARIO_ENTRENADORES

/* --PRUEBA DEL TRIGGER DE HORARIO_ENTRENADORES
INSERT INTO HORARIO_ENTRENADORES(COD_ENTRENADOR,DIA_LUNES,DIA_MARTES, DIA_MIERCOLES, DIA_JUEVES, DIA_VIERNES, DIA_SABADO, DIA_DOMINGO,HORA_INICIO_HORARIO, HORA_FIN_HORARIO)
	VALUES (6,1,1,1,1,1,1,0,'7:00', '9:00');
*/

-- Si el entrenador no tiene el primer certificado estará inactivo
GO
CREATE OR ALTER TRIGGER ENTRENADOR_NO_VALIDO
	ON CERTIFICACIONES FOR INSERT, UPDATE AS

	IF (SELECT GIMNASIO_ESPECIFICACION FROM inserted) = 0
		BEGIN
			UPDATE ENTRENADORES
			SET ESTADO_ENTRENADOR = 0
			FROM inserted INNER JOIN CERTIFICACIONES C
				ON inserted.COD_ENTRENADOR = C.COD_ENTRENADOR

			WHERE inserted.COD_ENTRENADOR = ENTRENADORES.COD_ENTRENADOR
			PRINT 'El entrenador no está certificado para este puesto'
		END
GO
 
--**LA SENTENCIA DE ESTOS ÚLTIMOS 2 TRIGGERS FUERON ERRONEAS Y ACTUALIZAN MAL LA TABLA**

/* PRUEBA DEL TRIGGER ENTRENADOR_VALIDO
SELECT * FROM ENTRENADORES
UPDATE CERTIFICACIONES
SET GIMNASIO_ESPECIFICACION = 0 WHERE COD_ENTRENADOR = 1 */


-- No se puede actualizar un ID de un atleta
--CREATE OR ALTER TRIGGER ALTERAR_ATLETA
-- ON ATLETAS INSTEAD OF UPDATE AS
-- BEGIN TRY
--	IF UPDATE(ID_ATLETA)
--		BEGIN
--			ROLLBACK TRANSACTION
--			RAISERROR('NO ES POSIBLE CAMBIAR LA IDENTIFICACIÓN DE UN ATLETA (INFORMACIÓN PERSONAL)',16,1)
--		END
--	ELSE
--		UPDATE ATLETAS
--		SET NOMBRE_ATLETA = inserted.NOMBRE_ATLETA,
--			APELLIDO1_ATLETA = inserted.APELLIDO1_ATLETA,
--			APELLIDO2_ATLETA = inserted.APELLIDO2_ATLETA,
--			TELEFONO1_ATLETA = inserted.TELEFONO1_ATLETA,
--			TELEFONO2_ATLETA = inserted.TELEFONO2_ATLETA,
--			GENERO = inserted.GENERO,
--			PROVINCIA_ATLETA = inserted.PROVINCIA_ATLETA,
--			DISTRITO_ATLETA = inserted.DISTRITO_ATLETA,
--			CANTON_ATLETA = inserted.CANTON_ATLETA,
--			FECHA_NACIMIENTO_ATLETA = inserted.FECHA_NACIMIENTO_ATLETA,
--			ESTADO_ATLETA = inserted.ESTADO_ATLETA
--		FROM inserted
--END TRY

--BEGIN CATCH
--	PRINT ERROR_MESSAGE()
--END CATCH

/* PRUEBA DEL TRIGGER ALTERAR_ATLETA
UPDATE ATLETAS
SET ID_ATLETA = '5145141654'
WHERE COD_ATLETA =1*/

-- No se puede actualizar el nombre de un módulo
--GO
--CREATE OR ALTER TRIGGER ALTERAR_MODULO
-- ON MODULOS INSTEAD OF UPDATE AS
-- BEGIN TRY
--	IF UPDATE(NOMBRE_MODULO)
--		BEGIN
--			ROLLBACK TRANSACTION
--			RAISERROR('NO ES POSIBLE CAMBIAR EL NOMBRE DE UN MÓDULO',16,1)
--		END
--	ELSE
--		UPDATE MODULOS
--		SET HORAS_DURACION_MODULO = inserted.HORAS_DURACION_MODULO,
--			REQUESITOS_MODULO = inserted.REQUESITOS_MODULO
--			FROM inserted
--		WHERE inserted.COD_MODULO = inserted.COD_MODULO
--END TRY

--BEGIN CATCH
--	PRINT ERROR_MESSAGE()
--END CATCH
--GO

/* PRUEBA DEL TRIGGER ALTERAR_MODULO
UPDATE MODULOS
SET NOMBRE_MODULO = 'CARDIO'
WHERE COD_MODULO =1*/