CREATE DATABASE IF NOT EXISTS directorio_servicios CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE directorio_servicios;

-- 1. TABLA: roles
CREATE TABLE roles (
    ID_Rol INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(50) NOT NULL UNIQUE,
    descripcion TEXT,
    fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    fecha_modificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- 2. TABLA: usuarios_sistema
CREATE TABLE usuarios_sistema (
    ID_Usuario_Sistema INT PRIMARY KEY AUTO_INCREMENT,
    username VARCHAR(50) UNIQUE NOT NULL,
    email VARCHAR(255) UNIQUE NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    ID_Rol INT,
    nombres VARCHAR(100) NOT NULL,
    apellidos VARCHAR(100) NOT NULL,
    telefono VARCHAR(20),
    fecha_registro TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    ultimo_login TIMESTAMP NULL,
    activo BOOLEAN DEFAULT TRUE,
    fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    fecha_modificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (ID_Rol) REFERENCES roles(ID_Rol)
);

-- 3. TABLA: usuarios
CREATE TABLE usuarios (
    ID_Usuario INT PRIMARY KEY AUTO_INCREMENT,
    username VARCHAR(50) UNIQUE NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    ID_Rol INT, -- Relación con tabla roles
    fecha_registro TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    activo BOOLEAN DEFAULT TRUE,
    fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    fecha_modificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (ID_Rol) REFERENCES roles(ID_Rol)
);

-- 4. TABLA: categorias
CREATE TABLE categorias (
    ID_Categoria INT PRIMARY KEY AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL UNIQUE,
    descripcion TEXT,
    icono VARCHAR(50),
    color VARCHAR(7),
    visitas INT DEFAULT 0,
    activa BOOLEAN DEFAULT TRUE,
    fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    fecha_modificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- 5. TABLA: denominaciones
-- Especializaciones dentro de cada categoría.
CREATE TABLE denominaciones (
    ID_Denominacion INT PRIMARY KEY AUTO_INCREMENT,
    ID_Categoria INT,
    nombre VARCHAR(100) NOT NULL,
    descripcion TEXT,
    visitas INT DEFAULT 0,
    fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    fecha_modificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (ID_Categoria) REFERENCES categorias(ID_Categoria),
    UNIQUE KEY unique_denominacion_categoria (ID_Categoria, nombre)
);

-- 6. TABLA: datos_usuario
-- Información personal y de contacto de los usuarios.
CREATE TABLE datos_usuario (
    ID_Datos_Usuario INT PRIMARY KEY AUTO_INCREMENT,
    ID_Usuario INT UNIQUE NOT NULL, 
    nombres VARCHAR(100) NOT NULL,
    apellidos VARCHAR(100) NOT NULL,
    ciudad VARCHAR(100) NOT NULL,
    direccion_aproximada VARCHAR(255), -- Zona/barrio para búsquedas geográficas
    email VARCHAR(255) UNIQUE NOT NULL, -- Email de contacto
    telefono VARCHAR(20) NOT NULL, -- Teléfono principal de contacto
    whatsapp VARCHAR(20), -- WhatsApp para comunicación directa
    otro_contacto VARCHAR(255), -- Instagram, Facebook, Telegram, etc.
    identificacion_oficial VARCHAR(50) NULL, -- NULLable para usuarios clientes
    zonas_servicio TEXT NULL, -- NULLable para usuarios clientes
    fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    fecha_modificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (ID_Usuario) REFERENCES usuarios(ID_Usuario)
);

-- 7. TABLA: servicios
-- Servicios ofrecidos por los empleados. Cada servicio pertenece a una categoría y denominación específica
CREATE TABLE servicios (
    ID_Servicio INT PRIMARY KEY AUTO_INCREMENT,
    ID_Usuario INT NOT NULL,
    ID_Categoria INT NOT NULL,
    ID_Denominacion INT,
    titulo VARCHAR(200) NOT NULL,
    descripcion TEXT NOT NULL, -- Descripción detallada del servicio
    tipo_precio ENUM('fijo', 'por_hora', 'presupuesto', 'consultar') NOT NULL, -- Modalidad de precio
    moneda VARCHAR(3) DEFAULT 'USD', -- Moneda para el precio
    disponibilidad VARCHAR(100), -- Horarios y días de disponibilidad
    radio_cobertura VARCHAR(100), -- Área geográfica de cobertura
    experiencia TEXT, -- Descripción de experiencia y antecedentes
    fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    fecha_modificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    visitas INT DEFAULT 0, -- Contador de visualizaciones del servicio
    FOREIGN KEY (ID_Usuario) REFERENCES usuarios(ID_Usuario),
    FOREIGN KEY (ID_Categoria) REFERENCES categorias(ID_Categoria),
    FOREIGN KEY (ID_Denominacion) REFERENCES denominaciones(ID_Denominacion)
);

-- 8. TABLA: sistema_calificacion
-- Sistema de reseñas y calificaciones donde los clientes evalúan a los empleados
CREATE TABLE sistema_calificacion (
    ID_Calificacion INT PRIMARY KEY AUTO_INCREMENT,
    ID_Empleado INT NOT NULL, 
    ID_Cliente INT NOT NULL,
    ID_Servicio INT NOT NULL,
    puntuacion TINYINT NOT NULL CHECK (puntuacion >= 1 AND puntuacion <= 5), -- Puntuación de 1 a 5 estrellas
    comentario TEXT NOT NULL, -- Comentario detallado de la experiencia
    fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    fecha_modificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (ID_Empleado) REFERENCES usuarios(ID_Usuario),
    FOREIGN KEY (ID_Cliente) REFERENCES usuarios(ID_Usuario),
    FOREIGN KEY (ID_Servicio) REFERENCES servicios(ID_Servicio)
);

-- 9. TABLA: acciones_sistema
-- Log de auditoría para registrar todas las acciones realizadas por usuarios del sistema
CREATE TABLE acciones_sistema (
    ID_Accion INT PRIMARY KEY AUTO_INCREMENT,
    ID_Usuario_Sistema INT NOT NULL, 
    accion VARCHAR(100) NOT NULL, -- Tipo de acción
    tabla_afectada VARCHAR(50), -- Tabla donde se realizó la modificación
    registro_afectado_id INT, -- ID del registro afectado
    detalles TEXT, -- Información adicional sobre la acción
    fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    fecha_modificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (ID_Usuario_Sistema) REFERENCES usuarios_sistema(ID_Usuario_Sistema)
);

-- NUEVA TABLA PERMANENTE: experiencia_usuario (unificada para Certificado y Empírico)
CREATE TABLE experiencia_usuario (
    ID_Experiencia INT PRIMARY KEY AUTO_INCREMENT,
    ID_Usuario INT NOT NULL,
    tipo_registro ENUM('certificado', 'empirico') NOT NULL,
    nivel_estudios ENUM('tecnico', 'tecnologo', 'profesional', 'especializacion', 'maestria', 'doctorado') DEFAULT NULL, -- NULL para Empírico
    anos_experiencia VARCHAR(20) NOT NULL, -- INT para Certificado, ENUM texto para Empírico (ej: '1-3')
    empresas_anteriores TEXT DEFAULT NULL,
    proyectos_destacados TEXT DEFAULT NULL,
    referencias_laborales TEXT DEFAULT NULL,
    tipo_experiencia TEXT DEFAULT NULL, -- Para Empírico
    descripcion_otro TEXT DEFAULT NULL, -- Para Empírico
    fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    fecha_modificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (ID_Usuario) REFERENCES usuarios(ID_Usuario) ON DELETE CASCADE
);

-- NUEVA TABLA PERMANENTE: archivos_proveedor (para archivos, incluyendo imágenes)
CREATE TABLE archivos_proveedor (
    ID_Archivo INT PRIMARY KEY AUTO_INCREMENT,
    ID_Usuario INT NOT NULL,
    nombre_archivo VARCHAR(255) NOT NULL,
    tipo_archivo VARCHAR(50) NOT NULL, -- ej: 'image/jpeg' para imágenes, 'application/pdf' para docs
    contenido LONGBLOB NOT NULL, -- Datos binarios
    categoria_archivo ENUM('certificado', 'titulo', 'licencia', 'internacional', 'foto_trabajo', 'testimonio', 'referencia') NOT NULL,
    obligatorio BOOLEAN DEFAULT FALSE,
    fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    fecha_modificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (ID_Usuario) REFERENCES usuarios(ID_Usuario) ON DELETE CASCADE
);

-- NUEVA TABLA: archivos_generales (para archivos no vinculados a usuarios, como logos, iconos, etc.)
CREATE TABLE archivos_generales (
    ID_Archivo INT PRIMARY KEY AUTO_INCREMENT,
    nombre_archivo VARCHAR(255) NOT NULL,
    tipo_archivo VARCHAR(50) NOT NULL, -- ej: 'image/jpeg', 'image/png'
    contenido LONGBLOB NOT NULL, -- Datos binarios del archivo
    categoria_archivo VARCHAR(100), -- Opcional: 'logo', 'icono', 'banner', etc.
    descripcion TEXT, -- Opcional: descripción del archivo
    fecha_creacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    fecha_modificacion TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);
