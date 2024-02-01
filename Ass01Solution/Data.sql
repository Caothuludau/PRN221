insert into Category values 
(1, 'Quan ao'),
(2, 'Giay dep'),
(3, 'Phu kien')


insert into Product values 
	(1, 'Ao bong co lo', '1 kg', 500000, 12),
    (1, 'Ao thun den', '0.5 kg', 180000, 15),
    (1, 'Ao so mi trang', '0.7 kg', 300000, 12),
    (2, 'Giay the thao trang', '0.8 kg', 420000, 8),
    (2, 'Giay boots nam', '1 kg', 550000, 5),
    (3, 'Vong co vang', '0.1 kg', 200000, 22),
    (3, 'Tui xach da hong', '0.5 kg', 350000, 17),
    (1, 'Quan jean nam', '0.7 kg', 280000, 10),
    (1, 'Ao khoac kaki nu', '0.9 kg', 450000, 8),
    (2, 'Giay cao got nu', '0.6 kg', 380000, 12),
    (2, 'Dep the thao nam', '0.4 kg', 280000, 15);

INSERT INTO Member (Email, CompanyName, City, Country, Password)
VALUES 
    ('john.doe@example.com', 'ABC Corporation', 'New York', 'USA', 'pass123'),
    ('jane.smith@example.com', 'XYZ Ltd.', 'London', 'UK', 'secure456'),
    ('bob.jones@example.com', '123 Enterprises', 'Sydney', 'Australia', 'secret789'),
    ('alice.wang@example.com', 'Tech Innovators', 'Beijing', 'China', 'pwd123'),
    ('michael.brown@example.com', 'Global Solutions', 'Paris', 'France', 'securepass'),
    ('sara.johnson@example.com', 'Tech Co.', 'San Francisco', 'USA', 'pass456'),
    ('david.miller@example.com', 'Innovate Inc.', 'Berlin', 'Germany', 'mysecret123'),
    ('lisa.williams@example.com', 'Future Tech', 'Toronto', 'Canada', 'pwd456'),
    ('peter.wong@example.com', 'Alpha Industries', 'Tokyo', 'Japan', 'secure789'),
    ('emily.yang@example.com', 'Smart Solutions', 'Seoul', 'South Korea', 'mysecurepass');


-- Assuming you have Member, Product, and Category data already inserted

-- Inserting data into Order table
INSERT INTO [Order] (MemberId, OrderDate, RequiredDate, ShippedDate, Freight)
VALUES 
    (1, '2024-01-23 08:00:00', '2024-01-25 12:00:00', '2024-01-24 14:30:00', 20.00),
    (2, '2024-01-22 10:30:00', '2024-01-24 14:00:00', '2024-01-23 16:45:00', 15.50),
    (3, '2024-01-21 09:45:00', '2024-01-23 15:30:00', '2024-01-22 17:15:00', 18.75),
    (4, '2024-01-20 11:15:00', '2024-01-22 16:45:00', '2024-01-21 18:30:00', 12.00),
    (5, '2024-01-19 08:30:00', '2024-01-21 13:15:00', '2024-01-20 15:45:00', 25.50);

-- Assuming you have Order data already inserted
-- Inserting data into OrderDetail table
INSERT INTO OrderDetail (OrderId, ProductId, UnitPrice, Quantity, Discount)
VALUES 
    (1, 1, 180000, 2, 0.05),
    (1, 3, 300000, 1, 0.1),
    (2, 5, 550000, 1, 0.08),
    (2, 8, 280000, 3, 0.15),
    (3, 2, 420000, 1, 0.12),
    (3, 6, 200000, 2, 0.07),
    (4, 4, 280000, 4, 0.2),
    (4, 9, 450000, 2, 0.1),
    (5, 7, 350000, 1, 0.03),
    (5, 10, 380000, 2, 0.06);
