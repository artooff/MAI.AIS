CREATE TABLE Users (
    Id INT PRIMARY KEY,
    Login VARCHAR(255) NOT NULL,
    Password VARCHAR(255) NOT NULL,
    FirstName VARCHAR(255),
    LastName VARCHAR(255),
    Email VARCHAR(255),
    Treatment INT
);