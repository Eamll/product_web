Web Api using ASP.NET Core

Sql Queries

CREATE DATABASE eamll_webapi;

USE eamll_webapi;

CREATE TABLE Producto (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(50),
    PrecioUnitario DECIMAL(18, 2),
    Descripcion NVARCHAR(500)
);
