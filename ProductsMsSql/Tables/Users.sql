﻿CREATE TABLE [dbo].[Users]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Login] NVARCHAR(50) NOT NULL, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(50) NOT NULL, 
    [RoleId] INT NOT NULL DEFAULT 0, 
    [IsActive] BIT NOT NULL DEFAULT 0
     CONSTRAINT FK_Role FOREIGN KEY ([RoleId]) REFERENCES Roles(Id)
)
