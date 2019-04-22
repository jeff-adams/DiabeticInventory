CREATE DATABASE EDIS

CREATE TABLE Inventory
(
    StockNumber [NVARCHAR](32) NOT NULL PRIMARY KEY,
    Brand [NVARCHAR](24) NOT NULL,
    ItemType [NVARCHAR](24) NOT NULL,
    UnitsOnHand INT NOT NULL,
    ReorderPoint INT NOT NULL,
);

CREATE TABLE Prescription
(
    RxNumber [NVARCHAR](24) NOT NULL PRIMARY KEY,
    RefillsRemaining INT NOT NULL,
    LastRefillDate DATE NOT NULL,
    StockNumber [NVARCHAR](32) NOT NULL,
    FOREIGN KEY(StockNumber) REFERENCES Inventory(StockNumber)
);
