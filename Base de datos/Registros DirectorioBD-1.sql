-- Inserción de datos básicos para inicializar el sistema
INSERT INTO roles (nombre, descripcion) VALUES 
('admin', 'Administrador total del sistema con todos los permisos'),
('usuarioA1', 'Usuario con Nivel de acceso 1'),
('moderador', 'Modera contenido, servicios y calificaciones'),
('cliente', 'Usuario que busca y contrata servicios'),
('empleado', 'Usuario que ofrece servicios profesionales');

-- Insertar usuario administrador por defecto
INSERT INTO usuarios_sistema (username, email, password_hash, ID_Rol, nombres, apellidos, telefono) VALUES 
('admin', 'admin@directorio.com', 'admin1', 1, 'Administrador', 'Sistema', '+1234567890'),
('user1', 'user1@directorio.com', 'user1', 2, 'user', 'A1', '+1234567890');

-- Insertar categorías básicas de servicios
INSERT INTO categorias (nombre, descripcion, icono, color) VALUES 
('Transporte', 'Servicios de transporte de personas y carga', 'car', '#FF6B35'),
('Jardinería', 'Cuidado y mantenimiento de jardines', 'tree', '#4CB963'),
('Albañilería', 'Construcción y reparaciones estructurales', 'hammer', '#8B4513'),
('Electricidad', 'Instalación y reparación eléctrica', 'bolt', '#FFD700'),
('Plomería', 'Reparación e instalación de tuberías', 'droplet', '#1E90FF'),
('Limpieza', 'Servicios de limpieza residencial y comercial', 'home', '#32CD32'),
('Carpintería', 'Trabajos en madera y muebles', 'package', '#8B4513'),
('Tecnología', 'Reparación y soporte técnico', 'monitor', '#4169E1');

-- Insertar denominaciones de ejemplo para las categorías
INSERT INTO denominaciones (ID_Categoria, nombre, descripcion) VALUES 
(1, 'Transporte de personas', 'Servicio de taxi y transporte privado'),
(1, 'Mudanzas', 'Transporte de muebles y enseres'),
(2, 'Diseño de jardines', 'Diseño y planificación de áreas verdes'),
(2, 'Mantenimiento de jardines', 'Podado, riego y cuidado de plantas'),
(3, 'Construcción', 'Construcción de obras nuevas'),
(3, 'Reparaciones', 'Reparación de estructuras existentes');
