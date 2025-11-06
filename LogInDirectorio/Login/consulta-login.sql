USE directorio_servicios;

-- Ver usuarios en la tabla 'usuarios'
SELECT * FROM usuarios;

-- Ver datos personales en 'datos_usuario'
SELECT u.username, du.nombres, du.apellidos, du.email, du.telefono 
FROM usuarios u 
LEFT JOIN datos_usuario du ON u.ID_Usuario = du.ID_Usuario;