-- TABLA TEMPORAL: temp_registros (datos comunes de Sección A)
CREATE TABLE temp_registros (
    ID_Temp INT PRIMARY KEY AUTO_INCREMENT,
    tipo_registro ENUM('certificado', 'empirico') NOT NULL,
    username VARCHAR(50) UNIQUE NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    nombres VARCHAR(100) NOT NULL,
    apellidos VARCHAR(100) NOT NULL,
    identificacion_oficial VARCHAR(50), -- Campo adicional para ID oficial (común, pero obligatorio en Certificado)
    email VARCHAR(255) UNIQUE NOT NULL, -- 'profesional' para Certificado, normal para Empírico
    telefono VARCHAR(20) NOT NULL,
    ciudad VARCHAR(100) NOT NULL,
    direccion_aproximada VARCHAR(255),
    zonas_servicio TEXT, -- Zonas de servicio (puede ser JSON o texto separado por comas)
    estado ENUM('pendiente', 'confirmado', 'rechazado') DEFAULT 'pendiente',
    fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    fecha_modificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- TABLA TEMPORAL: temp_certificaciones (específico de Certificado: Sección B y C)
CREATE TABLE temp_certificaciones (
    ID_Temp_Cert INT PRIMARY KEY AUTO_INCREMENT,
    ID_Temp INT NOT NULL,
    nivel_estudios ENUM('tecnico', 'tecnologo', 'profesional', 'especializacion', 'maestria', 'doctorado') NOT NULL,
    anos_experiencia INT NOT NULL,
    empresas_anteriores TEXT,
    proyectos_destacados TEXT,
    referencias_laborales TEXT,
    fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    fecha_modificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (ID_Temp) REFERENCES temp_registros(ID_Temp) ON DELETE CASCADE
);

-- TABLA TEMPORAL: temp_experiencia_empirica (específico de Empírico: Sección B y C)
CREATE TABLE temp_experiencia_empirica (
    ID_Temp_Exp INT PRIMARY KEY AUTO_INCREMENT,
    ID_Temp INT NOT NULL,
    anos_experiencia ENUM('menos_1', '1_3', '3_5', 'mas_5') NOT NULL,
    tipo_experiencia TEXT, -- JSON o texto con checkboxes (ej: 'independiente,empresa')
    descripcion_otro TEXT, -- Si selecciona 'Otro'
    fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    fecha_modificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (ID_Temp) REFERENCES temp_registros(ID_Temp) ON DELETE CASCADE
);

-- TABLA TEMPORAL: temp_especialidades (Sección D de ambos: especialidades y herramientas)
CREATE TABLE temp_especialidades (
    ID_Temp_Esp INT PRIMARY KEY AUTO_INCREMENT,
    ID_Temp INT NOT NULL,
    categorias TEXT NOT NULL, -- IDs o nombres de categorías (separados por comas o JSON)
    sub_especialidades TEXT, -- IDs o nombres de denominaciones
    herramientas TEXT, -- Herramientas/tecnologías dominadas
    descripcion_servicios TEXT, -- Para Empírico: descripción detallada
    fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    fecha_modificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (ID_Temp) REFERENCES temp_registros(ID_Temp) ON DELETE CASCADE
);

-- TABLA TEMPORAL: temp_archivos (archivos subidos temporalmente, como certificados, títulos, fotos, etc.)
CREATE TABLE temp_archivos (
    ID_Temp_Archivo INT PRIMARY KEY AUTO_INCREMENT,
    ID_Temp INT NOT NULL,
    nombre_archivo VARCHAR(255) NOT NULL,
    tipo_archivo VARCHAR(50) NOT NULL, -- ej: 'application/pdf', 'image/jpeg'
    contenido LONGBLOB NOT NULL, -- Datos binarios del archivo
    categoria_archivo ENUM('certificado', 'titulo', 'licencia', 'internacional', 'foto_trabajo', 'testimonio', 'referencia') NOT NULL, -- Para clasificar
    obligatorio BOOLEAN DEFAULT FALSE,
    fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    fecha_modificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (ID_Temp) REFERENCES temp_registros(ID_Temp) ON DELETE CASCADE
);