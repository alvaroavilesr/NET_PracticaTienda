-- Crear la tabla Productos
CREATE TABLE Productos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(255) NOT NULL,
    CantidadDisponible INT NOT NULL,
    ImagenAsociada NVARCHAR(500),
    Precio DECIMAL(10,2) NOT NULL
);

-- Crear la tabla Pedidos
CREATE TABLE Pedidos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Fecha DATETIME DEFAULT GETDATE(),
    PrecioTotal DECIMAL(10,2) NOT NULL,
    Usuario NVARCHAR(255) NOT NULL
);

-- Tabla intermedia para la relación N:M (muchos productos en un pedido)
CREATE TABLE PedidoProductos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PedidoId INT NOT NULL,
    ProductoId INT NOT NULL,
    Cantidad INT NOT NULL,
    Subtotal DECIMAL(10,2) NOT NULL, -- (Cantidad * Precio del producto)
    FOREIGN KEY (PedidoId) REFERENCES Pedidos(Id) ON DELETE CASCADE,
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id) ON DELETE CASCADE
);

-- Poblar tablas --

INSERT INTO Productos (Nombre, CantidadDisponible, ImagenAsociada, Precio)
VALUES 
('Portatil ASUS', 10, 'Ordenador_ASUS.png', 1500.00),
('Torre HP', 15, 'Ordenador_HP.png', 1200.00),
('Torre MAC', 20, 'Ordenador_MAC.png', 1100.00),
('MacBook Air M2', 8, 'Ordenador_MACBOOK.png', 1400.00),
('MSI Gaming PC', 12, 'Ordenador_MSI.png', 500.00);

INSERT INTO Pedidos (Fecha, PrecioTotal, Usuario)
VALUES
(GETDATE(), 2700.00, 'usuario1@example.com'),
(GETDATE(), 500.00, 'usuario2@example.com'),
(GETDATE(), 2600.00, 'usuario3@example.com');

INSERT INTO PedidoProductos (PedidoId, ProductoId, Cantidad, Subtotal)
VALUES 
(1, 1, 1, 1500.00), -- Pedido 1: 1 Portátil ASUS
(1, 2, 1, 1200.00), -- Pedido 1: 1 Torre HP
(2, 5, 1, 500.00),  -- Pedido 2: 1 MSI Gaming PC
(3, 3, 1, 1100.00), -- Pedido 3: 1 Torre MAC
(3, 4, 1, 1400.00); -- Pedido 3: 1 MacBook Air M2