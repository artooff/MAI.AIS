CREATE TABLE Users
(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Login NVARCHAR(255) NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    FirstName NVARCHAR(255),
    LastName NVARCHAR(255),
    Email NVARCHAR(255),
    Treatment INT
);

CREATE TABLE Services
(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Title NVARCHAR(255) NOT NULL,
    Category NVARCHAR(255),
    Description TEXT, 
    Price DECIMAL(18,2) NOT NULL
);

CREATE TABLE Orders
(
    Id INT PRIMARY KEY AUTO_INCREMENT,
    UserId INT,
    OrderDate DATETIME NOT NULL,
    CONSTRAINT FK_Order_User FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE
);

CREATE TABLE ServicesInOrders
(
    OrderId INT,
    ServiceId INT,
    PRIMARY KEY (OrderId, ServiceId),
    CONSTRAINT FK_OrderService_Order FOREIGN KEY (OrderId) REFERENCES Orders(Id) ON DELETE CASCADE,
    CONSTRAINT FK_OrderService_Service FOREIGN KEY (ServiceId) REFERENCES Services(Id) ON DELETE CASCADE
);

INSERT INTO Users (Login, Password, FirstName, LastName, Email, Treatment)
VALUES
('user1', 'password1', 'John', 'Doe', 'john.doe@example.com', 0),
('user2', 'password2', 'Jane', 'Doe', 'jane.doe@example.com', 1),
('user3', 'password3', 'Bob', 'Smith', 'bob.smith@example.com', 0),
('user4', 'password4', 'Alice', 'Johnson', 'alice.johnson@example.com', 1),
('user5', 'password5', 'Eva', 'Brown', 'eva.brown@example.com', 0);

INSERT INTO Services (Title, Category, Description, Price)
VALUES
('Service A', 'Category A', 'Description for Service A', 19.99),
('Service B', 'Category B', 'Description for Service B', 29.99),
('Service C', 'Category C', 'Description for Service C', 39.99),
('Service D', 'Category A', 'Description for Service D', 49.99),
('Service E', 'Category B', 'Description for Service E', 59.99);

INSERT INTO Orders (UserId, OrderDate)
VALUES
(1, '2023-01-01 10:00:00'),
(2, '2023-01-02 12:30:00'),
(3, '2023-01-03 14:45:00'),
(4, '2023-01-04 16:30:00'),
(5, '2023-01-05 18:00:00');

INSERT INTO ServicesInOrders (OrderId, ServiceId)
VALUES
(1, 1),
(1, 2),
(2, 3),
(3, 4),
(4, 5);