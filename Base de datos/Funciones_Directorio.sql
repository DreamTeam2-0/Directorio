DELIMITER //

CREATE PROCEDURE RegistrarAccionSistema(
    IN p_ID_Usuario_Sistema INT,
    IN p_accion VARCHAR(100),
    IN p_tabla_afectada VARCHAR(50),
    IN p_registro_afectado_id INT,
    IN p_detalles TEXT
)
BEGIN
    INSERT INTO acciones_sistema (
        ID_Usuario_Sistema,
        accion,
        tabla_afectada,
        registro_afectado_id,
        detalles
    ) VALUES (
        p_ID_Usuario_Sistema,
        p_accion,
        p_tabla_afectada,
        p_registro_afectado_id,
        p_detalles
    );
END //

DELIMITER ;

DELIMITER //

-- confirmar_registro.sql
DELIMITER //

-- PROCEDIMIENTO: confirmar_registro
-- Versión actualizada para manejar correctamente certificados y empíricos
CREATE PROCEDURE confirmar_registro(
    IN p_id_temp INT,
    IN p_id_rol INT
)
BEGIN
    DECLARE v_id_usuario_nuevo INT;
    DECLARE v_tipo_registro ENUM('certificado', 'empirico');
    DECLARE v_username VARCHAR(50);
    DECLARE v_password_hash VARCHAR(255);
    DECLARE v_nombres VARCHAR(100);
    DECLARE v_apellidos VARCHAR(100);
    DECLARE v_email VARCHAR(255);
    DECLARE v_telefono VARCHAR(20);
    DECLARE v_ciudad VARCHAR(100);
    DECLARE v_direccion VARCHAR(255);
    DECLARE v_identificacion VARCHAR(50);
    DECLARE v_zonas_servicio TEXT;
    DECLARE v_categorias TEXT;
    DECLARE v_sub_especialidades TEXT;
    DECLARE v_herramientas TEXT;
    DECLARE v_descripcion_servicios TEXT;
    
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;
    
    START TRANSACTION;
    
   -- Obtener datos básicos del registro temporal
    SELECT 
        tipo_registro,
        username,
        password_hash,
        nombres,
        apellidos,
        email,
        telefono,
        ciudad,
        direccion_aproximada,
        identificacion_oficial,
        zonas_servicio
    INTO 
        v_tipo_registro,
        v_username,
        v_password_hash,
        v_nombres,
        v_apellidos,
        v_email,
        v_telefono,
        v_ciudad,
        v_direccion,
        v_identificacion,
        v_zonas_servicio
    FROM temp_registros 
    WHERE ID_Temp = p_id_temp;
    
    -- VALIDACIÓN CRÍTICA: Verificar que username no sea NULL
    IF v_username IS NULL OR TRIM(v_username) = '' THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'El nombre de usuario (username) no puede estar vacío o ser nulo';
    END IF;
    
    -- Verificar que el registro existe
    IF v_nombres IS NULL THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'El registro temporal no existe';
    END IF;
    
    -- Insertar en usuarios (datos básicos)
    INSERT INTO usuarios (username, password_hash, ID_Rol, activo)
    VALUES (v_username, v_password_hash, p_id_rol, TRUE);
    
    SET v_id_usuario_nuevo = LAST_INSERT_ID();
    
    -- Insertar en datos_usuario
    INSERT INTO datos_usuario (
        ID_Usuario, 
        nombres, 
        apellidos, 
        ciudad, 
        direccion_aproximada, 
        email, 
        telefono,
        identificacion_oficial,
        zonas_servicio
    ) VALUES (
        v_id_usuario_nuevo,
        v_nombres,
        v_apellidos,
        v_ciudad,
        v_direccion,
        v_email,
        v_telefono,
        v_identificacion,
        v_zonas_servicio
    );
    
    -- Insertar en experiencia_usuario según tipo
    IF v_tipo_registro = 'certificado' THEN
        INSERT INTO experiencia_usuario (
            ID_Usuario,
            tipo_registro,
            nivel_estudios,
            anos_experiencia,
            empresas_anteriores,
            proyectos_destacados,
            referencias_laborales
        )
        SELECT 
            v_id_usuario_nuevo,
            v_tipo_registro,
            nivel_estudios,
            anos_experiencia,
            empresas_anteriores,
            proyectos_destacados,
            referencias_laborales
        FROM temp_certificaciones 
        WHERE ID_Temp = p_id_temp;
        
    ELSEIF v_tipo_registro = 'empirico' THEN
        INSERT INTO experiencia_usuario (
            ID_Usuario,
            tipo_registro,
            anos_experiencia,
            tipo_experiencia,
            descripcion_otro
        )
        SELECT 
            v_id_usuario_nuevo,
            v_tipo_registro,
            anos_experiencia,
            tipo_experiencia,
            descripcion_otro
        FROM temp_experiencia_empirica 
        WHERE ID_Temp = p_id_temp;
    END IF;
    
    -- Obtener datos de especialidades para crear servicio
    SELECT 
        categorias,
        sub_especialidades,
        herramientas,
        descripcion_servicios
    INTO 
        v_categorias,
        v_sub_especialidades,
        v_herramientas,
        v_descripcion_servicios
    FROM temp_especialidades 
    WHERE ID_Temp = p_id_temp
    LIMIT 1;
    
    -- Insertar un servicio inicial
    IF v_categorias IS NOT NULL THEN
        INSERT INTO servicios (
            ID_Usuario,
            ID_Categoria,
            ID_Denominacion,
            titulo,
            descripcion,
            tipo_precio,
            moneda,
            experiencia
        ) VALUES (
            v_id_usuario_nuevo,
            (SELECT ID_Categoria FROM categorias WHERE nombre LIKE CONCAT('%', v_categorias, '%') LIMIT 1),
            (SELECT ID_Denominacion FROM denominaciones WHERE nombre LIKE CONCAT('%', v_sub_especialidades, '%') LIMIT 1),
            CONCAT('Servicios de ', v_categorias),
            COALESCE(v_descripcion_servicios, CONCAT('Servicios profesionales de ', v_categorias)),
            'consultar',
            'USD',
            CONCAT('Herramientas dominadas: ', COALESCE(v_herramientas, 'No especificado'))
        );
    END IF;
    
    -- Copiar archivos a archivos_proveedor
    INSERT INTO archivos_proveedor (
        ID_Usuario,
        nombre_archivo,
        tipo_archivo,
        contenido,
        categoria_archivo,
        obligatorio
    )
    SELECT 
        v_id_usuario_nuevo,
        nombre_archivo,
        tipo_archivo,
        contenido,
        categoria_archivo,
        obligatorio
    FROM temp_archivos 
    WHERE ID_Temp = p_id_temp;
    
    -- Marcar como confirmado en temp_registros
    UPDATE temp_registros 
    SET estado = 'confirmado' 
    WHERE ID_Temp = p_id_temp;
    
    -- Eliminar datos temporales (se eliminarán en cascada)
    DELETE FROM temp_registros 
    WHERE ID_Temp = p_id_temp;
    
    COMMIT;
    
    SELECT CONCAT('Registro confirmado exitosamente. ID Usuario: ', v_id_usuario_nuevo) as mensaje;
END //

DELIMITER ;