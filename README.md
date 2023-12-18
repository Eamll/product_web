Web Api using ASP.NET Core

Sql Queries

CREATE DATABASE ProductDB;

USE ProductDB;

CREATE TABLE Producto (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(50),
    PrecioUnitario DECIMAL(18, 2),
    Descripcion NVARCHAR(500)
);
