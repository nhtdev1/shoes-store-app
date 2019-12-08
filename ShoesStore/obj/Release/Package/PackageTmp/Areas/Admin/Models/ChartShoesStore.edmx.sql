
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/14/2019 23:32:49
-- Generated from EDMX file: D:\Microsoft Visual Studio\repos\ASP.NET\ShoesStore\ShoesStore\Areas\Admin\Models\ChartShoesStore.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ChartShoesStore];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Points'
CREATE TABLE [dbo].[Points] (
    [x] int IDENTITY(1,1) NOT NULL,
    [y] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [x] in table 'Points'
ALTER TABLE [dbo].[Points]
ADD CONSTRAINT [PK_Points]
    PRIMARY KEY CLUSTERED ([x] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------