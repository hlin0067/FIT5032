
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/02/2023 19:18:21
-- Generated from EDMX file: C:\Users\hlin0067\source\repos\FIT5032\project100207\project100207\Models\AppointmentModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-project100207-20231002070854];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AppointmentSet'
CREATE TABLE [dbo].[AppointmentSet] (
    [AppointmentId] int IDENTITY(1,1) NOT NULL,
    [Doctor] nvarchar(max)  NOT NULL,
    [Date] datetime  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [AspNetUsersId] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [AppointmentId] in table 'AppointmentSet'
ALTER TABLE [dbo].[AppointmentSet]
ADD CONSTRAINT [PK_AppointmentSet]
    PRIMARY KEY CLUSTERED ([AppointmentId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AspNetUsersId] in table 'AppointmentSet'
ALTER TABLE [dbo].[AppointmentSet]
ADD CONSTRAINT [FK_AspNetUsersAppointment]
    FOREIGN KEY ([AspNetUsersId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUsersAppointment'
CREATE INDEX [IX_FK_AspNetUsersAppointment]
ON [dbo].[AppointmentSet]
    ([AspNetUsersId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------