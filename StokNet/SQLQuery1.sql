INSERT INTO dbo.Negocios (Nombre, FotoUrl, NIT, Direccion, Telefono, Correo) VALUES 
('Mi Tienda Online', 'https://ejemplo.com/tienda.jpg', '123456789-0', 'Calle 123 #45-67', '3001234567', 'contacto@mitienda.com'),
('Supermercado La Economía', 'https://ejemplo.com/supermercado.jpg', '987654321-0', 'Av. Principal #100-23', '3109876543', 'info@laeconomia.com'),
('Tecnología Avanzada', 'https://ejemplo.com/tecnologia.jpg', '456789123-0', 'Carrera 50 #80-12', '3204567891', 'ventas@tecnologiaavanzada.com'),
('Moda Elegante', 'https://ejemplo.com/moda.jpg', '789123456-0', 'Calle 80 #10-45', '3157891234', 'contacto@modaelegante.com'),
('Ferretería El Constructor', 'https://ejemplo.com/ferreteria.jpg', '321654987-0', 'Av. Industrial #30-60', '3013216549', 'servicio@elconstructor.com');

INSERT INTO dbo.Clientes (Nombre, Documento, Direccion, Telefono, Correo) VALUES 
('Juan Pérez', '1234567890', 'Calle 10 #20-30', '3001112233', 'juan.perez@email.com'),
('María Gómez', '9876543210', 'Av. 30 #40-50', '3104445566', 'maria.gomez@email.com'),
('Carlos Rodríguez', '4567890123', 'Carrera 5 #15-25', '3207778899', 'carlos.rod@email.com'),
('Ana López', '7890123456', 'Calle 70 #80-90', '3152223344', 'ana.lopez@email.com'),
('Pedro Martínez', '3210987654', 'Av. Circunvalar #12-34', '3015556677', 'pedro.martinez@email.com'),
('Laura Sánchez', '6543210987', 'Carrera 45 #67-89', '3188889900', 'laura.sanchez@email.com'),
('Diego Ramírez', '2109876543', 'Calle 100 #11-22', '3173334455', 'diego.ramirez@email.com'),
('Sofía Castro', '5432109876', 'Av. Boyacá #33-44', '3146667788', 'sofia.castro@email.com'),
('Andrés Herrera', '1098765432', 'Carrera 7 #77-88', '3029990011', 'andres.herrera@email.com'),
('Valentina Rojas', '4321098765', 'Calle 40 #55-66', '3112223344', 'valentina.rojas@email.com');

INSERT INTO dbo.CategoriasProductos (Nombre) VALUES 
('Electrónicos'),
('Ropa'),
('Hogar'),
('Alimentos'),
('Bebidas'),
('Juguetes'),
('Deportes'),
('Libros'),
('Belleza'),
('Herramientas');

INSERT INTO dbo.Productos (Codigo, Nombre, CategoriaId, Costo, PrecioVenta, Margen) VALUES 
('PROD001', 'Smartphone X', 1, 500000, 750000, 50.00),
('PROD002', 'Camiseta Básica', 2, 25000, 45000, 80.00),
('PROD003', 'Sartén Antiadherente', 3, 60000, 95000, 58.33),
('PROD004', 'Arroz 5kg', 4, 15000, 22000, 46.67),
('PROD005', 'Refresco 1.5L', 5, 3000, 5000, 66.67),
('PROD006', 'Muñeca Articulada', 6, 45000, 70000, 55.56),
('PROD007', 'Balón de Fútbol', 7, 40000, 65000, 62.50),
('PROD008', 'Novela Bestseller', 8, 35000, 55000, 57.14),
('PROD009', 'Kit de Maquillaje', 9, 80000, 120000, 50.00),
('PROD010', 'Taladro Inalámbrico', 10, 180000, 250000, 38.89),
('PROD011', 'Auriculares Bluetooth', 1, 80000, 130000, 62.50),
('PROD012', 'Jeans Clásico', 2, 70000, 120000, 71.43),
('PROD013', 'Juego de Sábanas', 3, 90000, 150000, 66.67),
('PROD014', 'Aceite 1L', 4, 12000, 18000, 50.00),
('PROD015', 'Agua Mineral 500ml', 5, 1500, 2500, 66.67);

INSERT INTO dbo.inventarios(ProductoId, InventarioInicial, Entradas, Salidas, CostoUnitario) VALUES 
(1, 10, 20, 15, 500000),
(2, 50, 100, 80, 25000),
(3, 15, 30, 20, 60000),
(4, 100, 200, 180, 15000),
(5, 200, 300, 250, 3000),
(6, 30, 50, 40, 45000),
(7, 25, 40, 30, 40000),
(8, 40, 60, 50, 35000),
(9, 20, 30, 25, 80000),
(10, 10, 15, 12, 180000),
(11, 15, 25, 20, 80000),
(12, 35, 60, 50, 70000),
(13, 25, 40, 35, 90000),
(14, 80, 120, 100, 12000),
(15, 150, 200, 180, 1500);

INSERT INTO dbo.CostosFijos (Descripcion, Valor) VALUES 
('Arriendo Local', 1500000),
('Servicios Públicos', 500000),
('Salarios', 5000000),
('Internet', 150000),
('Publicidad', 800000),
('Seguros', 300000),
('Mantenimiento', 200000),
('Impuestos', 700000),
('Transporte', 400000),
('Materiales de Oficina', 100000);

INSERT INTO dbo.Proveedores(Nombre, Nit, Direccion, Telefono, Correo) VALUES 
('Distribuidora Tech', '111222333-0', 'Calle 100 #200-300', '6011112222', 'contacto@distech.com'),
('Textiles Nacionales', '444555666-0', 'Av. Industrial #400', '6023334444', 'ventas@textilesnac.com'),
('Importaciones Hogar', '777888999-0', 'Carrera 60 #70-80', '6035556666', 'info@importhogar.com'),
('Alimentos S.A.', '222333444-0', 'Zona Franca #100', '6047778888', 'pedidos@alimentossa.com'),
('Bebidas del Valle', '555666777-0', 'Autopista Norte Km 10', '6059990000', 'contacto@bebidasvalle.com'),
('Juguetes Creativos', '888999000-0', 'Calle 80 #90-100', '6061112222', 'ventas@juguetescrea.com'),
('Deportes Extremos', '333444555-0', 'Centro Comercial Plaza', '6073334444', 'servicio@deportesext.com'),
('Editorial Libros', '666777888-0', 'Av. Cultural #50', '6085556666', 'pedidos@editoriallib.com'),
('Belleza Express', '999000111-0', 'Carrera 30 #40-50', '6097778888', 'info@bellezaexp.com'),
('Ferretería Industrial', '123456789-1', 'Polígono Industrial', '6109990000', 'ventas@ferreteriaind.com');

INSERT INTO dbo.Compras (NumeroDocumento, Fecha, ProveedorId, Descripcion, Subtotal, Descuento, Envio, Total, FacturaProveedor, DatosDeEnvio) VALUES 
('COMP001', '2023-01-15', 1, 'Compra de electrónicos', 10000000, 500000, 200000, 9700000, 'FAC-001-2023', 'Envío estándar'),
('COMP002', '2023-01-20', 2, 'Compra de textiles', 5000000, 250000, 100000, 4850000, 'FAC-002-2023', 'Envío urgente'),
('COMP003', '2023-02-05', 3, 'Compra artículos hogar', 3000000, 150000, 150000, 3000000, 'FAC-003-2023', 'Envío programado'),
('COMP004', '2023-02-10', 4, 'Compra alimentos', 2000000, 100000, 50000, 1950000, 'FAC-004-2023', 'Envío refrigerado'),
('COMP005', '2023-03-01', 5, 'Compra bebidas', 1500000, 75000, 80000, 1505000, 'FAC-005-2023', 'Envío con cuidado'),
('COMP006', '2023-03-15', 6, 'Compra juguetes', 2500000, 125000, 120000, 2495000, 'FAC-006-2023', 'Envío frágil'),
('COMP007', '2023-04-02', 7, 'Compra artículos deportivos', 1800000, 90000, 90000, 1800000, 'FAC-007-2023', 'Envío estándar'),
('COMP008', '2023-04-10', 8, 'Compra libros', 1200000, 60000, 60000, 1200000, 'FAC-008-2023', 'Envío educativo'),
('COMP009', '2023-05-05', 9, 'Compra productos belleza', 2200000, 110000, 110000, 2200000, 'FAC-009-2023', 'Envío cuidado especial'),
('COMP010', '2023-05-20', 10, 'Compra herramientas', 2800000, 140000, 140000, 2800000, 'FAC-010-2023', 'Envío pesado');

INSERT INTO dbo.CategoriasMateriaPrima(Nombre) VALUES 
('Electrónica'),
('Textiles'),
('Metales'),
('Plásticos'),
('Químicos'),
('Maderas'),
('Vidrios'),
('Cerámicos'),
('Papeles'),
('Embalajes');

INSERT INTO dbo.materiaPrimas(Codigo, Nombre, CategoriaId, Costo, PrecioVenta, Margen) VALUES 
('MP001', 'Circuito Integrado', 1, 5000, 8000, 60.00),
('MP002', 'Tela Algodón', 2, 8000, 12000, 50.00),
('MP003', 'Acero Inoxidable', 3, 10000, 15000, 50.00),
('MP004', 'Poliestireno', 4, 6000, 9000, 50.00),
('MP005', 'Resina Epóxica', 5, 12000, 18000, 50.00),
('MP006', 'Madera de Pino', 6, 7000, 10500, 50.00),
('MP007', 'Vidrio Templado', 7, 9000, 13500, 50.00),
('MP008', 'Arcilla Refractaria', 8, 5000, 7500, 50.00),
('MP009', 'Papel Kraft', 9, 4000, 6000, 50.00),
('MP010', 'Cartón Corrugado', 10, 3000, 4500, 50.00),
('MP011', 'Microcontrolador', 1, 15000, 22500, 50.00),
('MP012', 'Tela Poliéster', 2, 7000, 10500, 50.00),
('MP013', 'Aluminio', 3, 8000, 12000, 50.00),
('MP014', 'PVC', 4, 5000, 7500, 50.00),
('MP015', 'Pigmentos', 5, 10000, 15000, 50.00);

INSERT INTO dbo.DetallesCompra(CompraId, MateriaPrimaId, Cantidad, PrecioUnitario, Descuento) VALUES 
(1, 1, 100, 4800, 20000),
(1, 11, 50, 14500, 25000),
(2, 2, 200, 7500, 30000),
(2, 12, 150, 6500, 22500),
(3, 3, 100, 9500, 15000),
(3, 13, 80, 7500, 12000),
(4, 4, 150, 5500, 22500),
(4, 14, 120, 4500, 18000),
(5, 5, 100, 11500, 17500),
(5, 15, 80, 9500, 14000),
(6, 6, 120, 6500, 19500),
(6, 7, 100, 8500, 17500),
(7, 8, 80, 4500, 12000),
(7, 9, 150, 3500, 15000),
(8, 10, 200, 2500, 10000),
(8, 1, 50, 4700, 5000),
(9, 2, 180, 7300, 27000),
(9, 3, 70, 9200, 10500),
(10, 4, 130, 5300, 19500),
(10, 5, 90, 11300, 15750);


INSERT INTO dbo.Ventas(NumeroDocumento, Fecha, ClienteId, Descripcion, Subtotal, Descuento, Envio, Total, FacturaProveedor, DatosDeEnvio) VALUES 
('VENT001', '2023-01-10', 1, 'Venta electrónicos', 1500000, 75000, 50000, 1475000, 'FV-001-2023', 'Envío express'),
('VENT002', '2023-01-12', 2, 'Venta ropa', 800000, 40000, 30000, 790000, 'FV-002-2023', 'Envío estándar'),
('VENT003', '2023-02-08', 3, 'Venta hogar', 950000, 47500, 45000, 947500, 'FV-003-2023', 'Envío frágil'),
('VENT004', '2023-02-15', 4, 'Venta alimentos', 450000, 22500, 20000, 447500, 'FV-004-2023', 'Envío refrigerado'),
('VENT005', '2023-03-05', 5, 'Venta bebidas', 300000, 15000, 15000, 300000, 'FV-005-2023', 'Envío cuidado'),
('VENT006', '2023-03-12', 6, 'Venta juguetes', 700000, 35000, 35000, 700000, 'FV-006-2023', 'Envío estándar'),
('VENT007', '2023-04-01', 7, 'Venta deportes', 850000, 42500, 40000, 847500, 'FV-007-2023', 'Envío urgente'),
('VENT008', '2023-04-08', 8, 'Venta libros', 550000, 27500, 25000, 547500, 'FV-008-2023', 'Envío educativo'),
('VENT009', '2023-05-10', 9, 'Venta belleza', 1200000, 60000, 60000, 1200000, 'FV-009-2023', 'Envío cuidado especial'),
('VENT010', '2023-05-15', 10, 'Venta herramientas', 1300000, 65000, 65000, 1300000, 'FV-010-2023', 'Envío pesado');

INSERT INTO dbo.DetallesVenta(VentaId, ProductoId, Cantidad, PrecioUnitario, Descuento) VALUES 
(1, 1, 2, 750000, 0),
(1, 11, 1, 130000, 0),
(2, 2, 5, 45000, 5000),
(2, 12, 2, 120000, 10000),
(3, 3, 3, 95000, 0),
(3, 13, 1, 150000, 0),
(4, 4, 10, 22000, 0),
(4, 14, 5, 18000, 0),
(5, 5, 20, 5000, 0),
(5, 15, 15, 2500, 0),
(6, 6, 3, 70000, 0),
(6, 7, 2, 65000, 0),
(7, 8, 4, 55000, 0),
(7, 9, 1, 120000, 0),
(8, 10, 2, 250000, 0),
(8, 1, 1, 750000, 0),
(9, 2, 6, 45000, 0),
(9, 3, 2, 95000, 0),
(10, 4, 8, 22000, 0),
(10, 5, 10, 5000, 0);

SELECT 
    P.Nombre AS Producto,
    C.Nombre AS Categoria,
    P.Costo,
    P.PrecioVenta,
    P.Margen
FROM dbo.Productos P
INNER JOIN dbo.CategoriasProductos C ON P.CategoriaId = C.Id;


SELECT 
    I.Id,
    P.Nombre AS Producto,
    I.InventarioInicial,
    I.Entradas,
    I.Salidas,
    I.InventarioFinal,
    I.CostoUnitario,
    I.CostoTotal
FROM dbo.Inventarios I
JOIN dbo.Productos P ON I.ProductoId = P.Id;
