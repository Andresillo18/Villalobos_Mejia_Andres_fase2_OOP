--Query para ingresar los registros en sus respectivas tablas utilizando la base de datos del Triatlón

-- Instituto Nacional de Aprendizaje
/*
	Módulo: Gestión de Bases de Datos
	Fecha: 15 de junio, 2021
	Estudiante: Andrés Villalobos Mejía
*/

USE BD_INSTITUTO_TRIATLON_ANDRES
GO

-- **Para ingresar las fechas de inicio de los módulos se usarán fechas aproximadas, ya que en la fase 3 del proyecto se sabrán con exactitud porque se calculan automáticamente
--................................Insertar información en los registros de la tabla ENTRENADORES..................................
INSERT INTO ENTRENADORES (ID_ENTRENADOR,
							NOMBRE_ENTRENADOR, 
							APELLIDO1_ENTRENADOR, 
							APELLIDO2_ENTRENADOR, 
							TELEFONO1_ENTRENADOR,
							TELEFONO2_ENTRENADOR,
							CORREO_ENTRENADOR,
							FECHA_NACIMIENTO_ENTRENADOR,
							PROVINCIA_ENTRENADOR,
							DISTRITO_ENTRENADOR,
							CANTON_ENTRENADOR,
							ESTADO_ENTRENADOR) 
				VALUES ('228053434', 'Antonio', 'Castillo','Navarro','88804433','88538432', 'antonioCV@gmail.com', '19850503', 'Alajuela', 'Palmares', 'La Granja', '1'), -- 1 significa activo
					('228053433', 'Ruperto', 'Moll','Anaya','88585434','88804412', 'ruperMoll@gmail.com', '19900730', 'Alajuela', 'San Ramón', 'Los Parques', '1'),
					('228053445', 'Eli', 'Benavides','Padilla','89438493', NULL , 'EBenaPadi12@gmail.com', '20000203', 'Alajuela', 'San Ramón', 'Piedades Norte', '1'),
					('228053432', 'Moreno', 'Casals','Muñoz','87658874', NULL , 'MorenoCasals@gmail.com', '19981212', 'Alajuela', 'Atenas', 'Centro', '1'),
					('228053465', 'Nydia', 'de Calzado','Juarez','87465978','88803245', 'NydiaJuarez@gmail.com', '19800823', 'San José', 'Desemparados', 'Centro', '1'),
					('228067745', 'Rosaura', 'Araujo','Comas','88768594', NULL , 'rosaAraujo@gmail.com', '19950403', 'Alajuela', 'Palmares', 'Buenos Aires', '0'),
					('228053423', 'Matilde', 'Riba','Campos','81245367', NULL , 'matilde1234@hotmail.com', '19920928', 'Alajuela', 'Palmares', 'Rincón', '0'),
					('228053412', 'Juan', 'Gras','Nuñez','88803943','86579376', 'Juan12232@gmail.com', '19990922', 'Alajuela', 'San Ramón', 'Piedades Sur', '0'),
					('228053424', 'Andrés', 'Villalobos','Mejía','88807673', NULL , 'andresvm18@hotmail.com', '19981220', 'Alajuela', 'Palmares', 'Esquipulas', '0'),
					('228053427', 'Roberta', 'Figueroa','Barrantes','88760084','88343432', 'robertaFB12@gmail.com', '19930101', 'Alajuela', 'Palmares', 'Centro', '0');
					
-- SELECT * FROM ENTRENADORES;
-- DELETE FROM ENTRENADORES DBCC CHECKIDENT(ENTRENADORES, RESEED, 0); para resetear los identity y eliminar los registros de la tabla

--..............................Insertar información para los registros en la tabla CERTIFICACIONES......................................
INSERT INTO CERTIFICACIONES (COD_ENTRENADOR, GIMNASIO_ESPECIFICACION, 
							NATACION_ESPECIFICACION, 
							MARATON_ESPECIFICACION, 
							CICLISMO_ESPECIFICACION)
							VALUES (1, 1, 1, 1, 1); -- los números incrementales son fk de la tabla anterior y no se ingresa la información del primer campo porque es identity

INSERT INTO CERTIFICACIONES (COD_ENTRENADOR, GIMNASIO_ESPECIFICACION, 
							NATACION_ESPECIFICACION, 
							MARATON_ESPECIFICACION, 
							CICLISMO_ESPECIFICACION)
							VALUES (2, 1, 1, 1, 1);

INSERT INTO CERTIFICACIONES (COD_ENTRENADOR, GIMNASIO_ESPECIFICACION, 
							NATACION_ESPECIFICACION, 
							MARATON_ESPECIFICACION, 
							CICLISMO_ESPECIFICACION)
							VALUES (3, 1, 1, 2, 1);

INSERT INTO CERTIFICACIONES (COD_ENTRENADOR, GIMNASIO_ESPECIFICACION, 
							NATACION_ESPECIFICACION, 
							MARATON_ESPECIFICACION, 
							CICLISMO_ESPECIFICACION)
							VALUES (4, 1, 1, 2, 1);

INSERT INTO CERTIFICACIONES (COD_ENTRENADOR, GIMNASIO_ESPECIFICACION, 
							NATACION_ESPECIFICACION, 
							MARATON_ESPECIFICACION, 
							CICLISMO_ESPECIFICACION)
							VALUES (5, 1, 1, 0, 1);

INSERT INTO CERTIFICACIONES (COD_ENTRENADOR, GIMNASIO_ESPECIFICACION, 
							NATACION_ESPECIFICACION, 
							MARATON_ESPECIFICACION, 
							CICLISMO_ESPECIFICACION)
							VALUES (6, 1, 1, 1, 1);

INSERT INTO CERTIFICACIONES (COD_ENTRENADOR, GIMNASIO_ESPECIFICACION, 
							NATACION_ESPECIFICACION, 
							MARATON_ESPECIFICACION, 
							CICLISMO_ESPECIFICACION)
							VALUES (7, 1, 1, 1, 1);

INSERT INTO CERTIFICACIONES (COD_ENTRENADOR, GIMNASIO_ESPECIFICACION, 
							NATACION_ESPECIFICACION, 
							MARATON_ESPECIFICACION, 
							CICLISMO_ESPECIFICACION)
							VALUES (8, 1, 1, 1, 1);

INSERT INTO CERTIFICACIONES (COD_ENTRENADOR, GIMNASIO_ESPECIFICACION, 
							NATACION_ESPECIFICACION, 
							MARATON_ESPECIFICACION, 
							CICLISMO_ESPECIFICACION)
							VALUES (9, 1, 0, 0, 1);

INSERT INTO CERTIFICACIONES (COD_ENTRENADOR, GIMNASIO_ESPECIFICACION, 
							NATACION_ESPECIFICACION, 
							MARATON_ESPECIFICACION, 
							CICLISMO_ESPECIFICACION)
							VALUES (10, 1, 0, 0, 1);

--....................Insertar información para los registros en la tabla HORARIO_ENTRENADORES........................
-- NOTA: Solo se ingresarán algunos registros y no se usarán todos los entrenadores para que un entrenador no tenga varios entrenadores, solo uno
INSERT INTO HORARIO_ENTRENADORES ( COD_ENTRENADOR ,
									DIA_LUNES,
									DIA_MARTES,
									DIA_MIERCOLES,
									DIA_JUEVES,
									DIA_VIERNES,
									DIA_SABADO,
									DIA_DOMINGO,
									HORA_INICIO_HORARIO,
									HORA_FIN_HORARIO)
								VALUES (1, 1, 1,1,1, 1,0, 0, '7:00', '9:00');

INSERT INTO HORARIO_ENTRENADORES ( COD_ENTRENADOR ,
									DIA_LUNES,
									DIA_MARTES,
									DIA_MIERCOLES,
									DIA_JUEVES,
									DIA_VIERNES,
									DIA_SABADO,
									DIA_DOMINGO,
									HORA_INICIO_HORARIO,
									HORA_FIN_HORARIO)
								VALUES (2, 1, 1,1,1, 1,0, 0, '9:00', '11:00');

INSERT INTO HORARIO_ENTRENADORES ( COD_ENTRENADOR ,
									DIA_LUNES,
									DIA_MARTES,
									DIA_MIERCOLES,
									DIA_JUEVES,
									DIA_VIERNES,
									DIA_SABADO,
									DIA_DOMINGO,
									HORA_INICIO_HORARIO,
									HORA_FIN_HORARIO)
								VALUES (3, 1, 1,1,1, 1,0, 0, '11:00', '13:00');

INSERT INTO HORARIO_ENTRENADORES ( COD_ENTRENADOR ,
									DIA_LUNES,
									DIA_MARTES,
									DIA_MIERCOLES,
									DIA_JUEVES,
									DIA_VIERNES,
									DIA_SABADO,
									DIA_DOMINGO,
									HORA_INICIO_HORARIO,
									HORA_FIN_HORARIO)
								VALUES (4, 1, 1,1,1, 1,0, 0, '13:00', '15:00');

INSERT INTO HORARIO_ENTRENADORES ( COD_ENTRENADOR ,
									DIA_LUNES,
									DIA_MARTES,
									DIA_MIERCOLES,
									DIA_JUEVES,
									DIA_VIERNES,
									DIA_SABADO,
									DIA_DOMINGO,
									HORA_INICIO_HORARIO,
									HORA_FIN_HORARIO)
								VALUES (5, 1, 1,1,1, 1,0, 0, '15:00', '17:00');
								SELECT * FROM HORARIO_ENTRENADORES
--..................Insertar información para los registros en la tabla INCAPACIDADES_EVENTOS......................
--NOTA: Se ingresaron solo 5 registros que serán los horarios de los 5 que tendrán su horario y su grupo
INSERT INTO INCAPACIDADES_EVENTOS ( COD_ENTRENADOR,
									DIA_INICIO_INCAPACIDADES_EVENTOS,
									DIA_FINAL_INCAPACIDADES_EVENTOS,
									OBSERVACIONES_INCAPACIDADES_EVENTOS) -- Para los 2 primeros entrenadores, de las 5 semenas de vacaciones se ingresaron 2 en diferente fecha para ver pruebas
								VALUES (1,'2022-10-04', '2022-10-14', 'Vacaciones obligatorias escogidas desde el inicio del programa'), 
										(2,'2022-10-04', '2022-11-14', 'Vacaciones obligatorias escogidas desde el inicio del programa'),
										(3,'2022-11-01', '2022-11-26', 'Vacaciones obligatorias escogidas desde el inicio del programa'), 
										(4,'2022-12-06', '2023-01-07', 'Vacaciones obligatorias escogidas desde el inicio del programa'),
										(5,'2022-12-06', '2023-01-07', 'Vacaciones obligatorias escogidas desde el inicio del programa');
										
--.........................Insertar información para los registros en la tabla RESGISTRO_HORAS_LABORADAS...................
-- Solo se hace un ejemplos de los días que ellos trabajarian y son 5 porque solo 5 tienen horario asignado
INSERT INTO REGISTRO_HORAS_LABORADAS ( COD_ENTRENADOR, DIA_REGISTRO_HORALABO, HORA_INICIO_REGISTRO_HORALABO, HORA_FINAL_REGISTRO_HORALABO)
								VALUES (1,'2022-09-01', '07:00','09:00'),
										(2,'2022-09-01','09:00','11:00'),
										(3,'2022-09-01','11:00','13:00'),
										(4,'2022-09-03','13:00','15:00'),
										(5,'2022-09-01','15:00','17:00');

--..................Insertar información para los registros de la tabla PROGRAMAS.............
--NOTA: En está tabla solo se ingresará un registro porque por el momenyo solo existe un programa cual es el triatlón
INSERT INTO PROGRAMAS (NOMBRE_PROGRAMA,
						DESCRIPCION_PROGRAMA, 
						ESTADO,
						CUPO_PROGRAMA, 
						TELEFONO_PROGRAMA, 
						EMAIL_PROGRAMA, 
						PROVINCIA_PROGRAMA,
						FECHA_INICIO_PROGRAMA, 
						FECHA_FIN_PROGRAMA)
					VALUES ('Entrenamiento en Triatlón', 'Programa establecido de entrenamiento personal o grupal para lograr completar las 4 fases de un triatlón con gran diciplina',
							1, '60', '24523454', 'triatlonPro10@gmail.com',
							'Alajuela', '20211027', NULL);

--....................Insertar información para los registros de la tabla MODULOS.............
INSERT INTO MODULOS (NOMBRE_MODULO, -- NOTA: En está tabla solo se ingresaron 4 registros porque solo existen 4 módulos en el programa
					HORAS_DURACION_MODULO, 
					REQUESITOS_MODULO)
					VALUES('Gimnasio', '80', 'Pago de la matricula y del módulo'),  -- Aquí se establecen las fechas que el módulo debe iniciar y finalizar
						('Natación', '110', 'Pago del módulo y revisar que tenga pagado la matricula al programa anteriormente (es obligado desde el inicio)'),
						('Maratón', '120', 'Pago del módulo y revisar que tenga pagado la matricula al programa anteriormente (es obligado desde el inicio)'),
						('Ciclismo', '90', 'Pago del módulo y revisar que tenga pagado la matricula al programa anteriormente (es obligado desde el inicio)');

--..................Insertar información para los registros de la tabla MODULOS_PROGRAMA.............
INSERT INTO MODULOS_PROGRAMA (COD_PROGRAMA,COD_MODULO) --NOTA: Solo se ingresarón 4 registros por los 4 módulos anteriores y porque solo existe un programa 
							VALUES('1','1'),			-- y se puede saber que los 4 módulos anteriores pertenecen al primer programa
								('1','2'),
								('1','3'),
								('1','4');

--..................Insertar información para los registros de la tabla HORARIO_MODULOS.............
--Se crean 4 horarios para los 4 módulos y ya que las reglas del negocio se impartirá en un horario establecido para el gimnasio
-- y los entrenadores entonces será igual para los 4
INSERT INTO HORARIO_MODULOS(DIA_LUNES,
							DIA_MARTES,
							DIA_MIERCOLES,
							DIA_JUEVES,
							DIA_VIERNES,
							DIA_SABADO,
							DIA_DOMINGO,
							HORA_INICIO_HORARIO,
							HORA_FIN_HORARIO)
							VALUES(1, 1, 1, 1, 1, 0, 0, '07:00', '9:00'),
								(1, 1, 1, 1, 1, 0, 0, '9:00', '11:00'),
								(1, 1, 1, 1, 1, 0, 0, '11:00', '13:00'),
								(1, 1, 1, 1, 1, 0, 0, '13:00', '15:00'),
								(1, 1, 1, 1, 1, 0, 0, '15:00', '17:00'),
								(0, 0, 1, 1, 1, 1, 1, '07:00', '9:00'), -- 2 horarios diferentes en caso de tener que escoger algo diferente aunque afecte las reglas de negocio
								(1, 0, 1, 1, 0, 1, 0, '9:00', '11:00');
								
--..................Insertar información para los registros de la tabla MODULOS_ABIERTOS.............
-- Esta tabla se establecerá los registros cuandos se abra un nuevo módulo y programa, también que horas y días el entrenador estará impartiendo las clases según su horario
-- Sucede lo mismo que solo se observarán los 5 entrenadores en uso
BEGIN TRY
INSERT INTO MODULOS_ABIERTOS (COD_ENTRENADOR,
							COD_MODULO,
							COD_HORARIO_MODULOS,
							FECHA_INICIO_MODULO )
							VALUES('1','1', '1', '2022-09-01'); -- Ya que se incia el módulo todos los entrenadores empiezan la misma fecha, por eso todas son iguales

INSERT INTO MODULOS_ABIERTOS (COD_ENTRENADOR,
							COD_MODULO,
							COD_HORARIO_MODULOS,
							FECHA_INICIO_MODULO )
							VALUES ('2','1', '2', '2022-09-01');

INSERT INTO MODULOS_ABIERTOS (COD_ENTRENADOR,
							COD_MODULO,
							COD_HORARIO_MODULOS,
							FECHA_INICIO_MODULO )
							VALUES ('3','1', '3', '20220901');

INSERT INTO MODULOS_ABIERTOS (COD_ENTRENADOR,
							COD_MODULO,
							COD_HORARIO_MODULOS,
							FECHA_INICIO_MODULO )
							VALUES ('4','1', '4', '20220901');

INSERT INTO MODULOS_ABIERTOS (COD_ENTRENADOR,
							COD_MODULO,
							COD_HORARIO_MODULOS,
							FECHA_INICIO_MODULO )
							VALUES ('5','1', '5', '20220901');
END TRY
BEGIN CATCH
PRINT ERROR_MESSAGE()
END CATCH

SELECT * FROM MODULOS_ABIERTOS
--..................Insertar información para los registros de la tabla ATLETAS.............
INSERT INTO ATLETAS (ID_ATLETA, 
					NOMBRE_ATLETA, 
					APELLIDO1_ATLETA, 
					APELLIDO2_ATLETA, 
					TELEFONO1_ATLETA, 
					TELEFONO2_ATLETA, 
					GENERO,
					PROVINCIA_ATLETA, 
					DISTRITO_ATLETA, 
					CANTON_ATLETA, 
					FECHA_NACIMIENTO_ATLETA)
					VALUES ('222344556','Silvia','Paniagua',' Trigo','88494432', NULL ,'F','Alajuela','San Ramón','Los Parques','2000-05-12'),
							('122341736','Jose','Pereira','Castro','83443321','89232121','M','Heredia','Belén','San Antonio','1998-01-29'),
							('562234545','Alexander','Carvajal','Vargas','83432312', NULL , 'M','Alajuela','Alajuela','Turrúcares','1990-04-23'),
							('222345756','Angelica','Rocha','Garcia','89893246', NULL , 'F','Alajuela','San Ramón','San Juan','2002-03-13'),
							('122345443','Brigite','Polanco','Ruiz','89233212','24522332','F','Alajuela','San Ramón','San Rafael','1999-06-27'),
							('222345336','Fabian','Fino','Andrade','89983342', NULL ,'M','Alajuela','Palmares','Cocaleca','2001-08-08'),
							('122346556','Camilo','Jimenez','Cortes','88384312','24532117', 'M','Alajuela','Palmares','Palmares','1997-04-20'),
							('332344356','Claudia','Torres','Frias','88322143','24531321','F','Alajuela','Palmares','Palmares','1995-11-11'),
							('222345456', 'Karina', 'Herrera', 'Benavidez', '88904324', NULL ,'F','Alajuela','Palmares', 'Buenos Aires','2001-07-17'),
							('922342546','Jorge','Orozco','Dussán','89983421', NULL ,'M','Alajuela','Palmares','Candelaria','2001-12-15');

--..................Insertar información para los registros de la tabla MATRICULAS.............
-- Se ingresan 2 estudiantes en cada módulo abierto
INSERT INTO MATRICULAS (COD_ATLETA,
						COD_MODULO_ABIERTO, 
						FECHA_MATRICULA, 
						ESTADO, 
						NOTA_FINAL, 
						MONTO_CANCELADO, 
						TIPO_COBRO, 
						TIPO_PAGO) -- NOTA: Todos los estados de los atletas en la matricula serán "En curso" porque apenas se están matriculando y por eso no tendrán ninguna nota
						VALUES ('1','1', '20220824','En curso', NULL ,'140000','Curso y matricula', 'Efectivo'), 
								('2','2', '20220815','En curso', NULL ,'125000','Curso', 'Sinpe'),
								('3','3', '20220831','En curso', NULL ,'125000','Curso', 'Tarjeta'),
								('4','4', '20220831','En curso', NULL ,'140000','Curso y Matricula', 'Efectivo'),
								('5','5', '20220820','En curso', NULL ,'125000','Curso', 'Sinpe'),
								('6','1', '20220823','En curso', NULL ,'125000','Curso', 'Transferencia'),
								('7','2', '20220831','En curso', NULL ,'125000','Curso', 'Efectivo'),
								('8','3', '20220818','En curso', NULL ,'140000','Curso y Matricula', 'Tarjeta'),
								('9','4', '20220827','En curso', NULL ,'125000','Curso', 'Sinpe'),
								('10','5', '20220830','En curso', NULL ,'140000','Curso y Matricula', 'Efectivo');
