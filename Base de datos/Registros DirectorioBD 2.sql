-- Insertar 5 usuarios con rol CLIENTE (ID_Rol = 4)
INSERT INTO usuarios (username, password_hash, ID_Rol, activo) VALUES 
('maria_gonzalez', '$2b$10$cliente1hash123456789012', 4, TRUE),
('carlos_rodriguez', '$2b$10$cliente2hash123456789012', 4, TRUE),
('ana_martinez', '$2b$10$cliente3hash123456789012', 4, TRUE),
('luis_hernandez', '$2b$10$cliente4hash123456789012', 4, TRUE),
('elena_torres', '$2b$10$cliente5hash123456789012', 4, TRUE);

-- Insertar datos personales para los clientes
INSERT INTO datos_usuario (ID_Usuario, nombres, apellidos, ciudad, direccion_aproximada, email, telefono, whatsapp, otro_contacto) VALUES 
(1, 'María', 'González López', 'Ciudad Central', 'Zona Norte, Av. Principal #123', 'maria.gonzalez@email.com', '+1234567891', '+1234567891', '@maria.gonzalez'),
(2, 'Carlos', 'Rodríguez Pérez', 'Ciudad Central', 'Zona Sur, Calle Secundaria #456', 'carlos.rodriguez@email.com', '+1234567892', '+1234567892', '@carlos.r'),
(3, 'Ana', 'Martínez Sánchez', 'Ciudad Este', 'Barrio Centro, Plaza Central #789', 'ana.martinez@email.com', '+1234567893', '+1234567893', '@ana.martinez'),
(4, 'Luis', 'Hernández Díaz', 'Ciudad Oeste', 'Colonia Jardines, Calle Flores #321', 'luis.hernandez@email.com', '+1234567894', '+1234567894', '@luis.hdz'),
(5, 'Elena', 'Torres Ramírez', 'Ciudad Central', 'Urbanización Miraflores, Av. Libertad #654', 'elena.torres@email.com', '+1234567895', '+1234567895', '@elena.torres');