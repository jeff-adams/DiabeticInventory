CREATE DATABASE EDIS

CREATE TABLE Inventory
(
    StockNumber NUMERIC NOT NULL PRIMARY KEY,
    Brand TEXT NOT NULL,
    ItemType TEXT NOT NULL,
    UnitsOnHand INT NOT NULL,
    ReorderPoint INT NOT NULL
);

CREATE TABLE Prescription
(
    RxNumber NUMERIC NOT NULL PRIMARY KEY,
    RefillsRemaining INT NOT NULL,
    LastRefillDate DATE NOT NULL,
    StockNumber NUMERIC NOT NULL,
    FOREIGN KEY(StockNumber) REFERENCES Inventory(StockNumber)
);
