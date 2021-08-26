# Programa1DB
Programa que accede a una Tabla de Alumnos y permite CONSULTAR, MODIFICAR, INSERTAR y ELIMINAR registros de la misma

La estructura de la BBDD llamada 'alumnos' se creó con una única tabla con la siguiente sintaxis:

CREATE TABLE `datos` 
(`IDAlumno` int(11) NOT NULL AUTO_INCREMENT,
 `Nombre` char(50) DEFAULT NULL,
 `Apellido` char(50) DEFAULT NULL,
 `Direccion` varchar(50) DEFAULT NULL,
 PRIMARY KEY (`IDAlumno`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4

Y se cargaron datos inventados para fines de práctica
