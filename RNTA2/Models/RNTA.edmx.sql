
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/29/2020 19:18:58
-- Generated from EDMX file: C:\Users\benzarti imed eddine\source\repos\RNTA\RNTA2\Models\RNTA.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RNTA];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__Employee__Depart__1DE57479]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [FK__Employee__Depart__1DE57479];
GO
IF OBJECT_ID(N'[dbo].[FK__Employee__Depart__20C1E124]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [FK__Employee__Depart__20C1E124];
GO
IF OBJECT_ID(N'[dbo].[FK__UserRoleM__RoleI__239E4DCF]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRoleMapping] DROP CONSTRAINT [FK__UserRoleM__RoleI__239E4DCF];
GO
IF OBJECT_ID(N'[dbo].[FK__UserRoleM__UserI__22AA2996]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRoleMapping] DROP CONSTRAINT [FK__UserRoleM__UserI__22AA2996];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Department]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Department];
GO
IF OBJECT_ID(N'[dbo].[Employee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employee];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[UserRoleMapping]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRoleMapping];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Department'
CREATE TABLE [dbo].[Department] (
    [DeptId] int IDENTITY(1,1) NOT NULL,
    [DepartmentName] nvarchar(50)  NULL
);
GO

-- Creating table 'Employee'
CREATE TABLE [dbo].[Employee] (
    [EmpId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Gender] char(10)  NULL,
    [Age] int  NULL,
    [Position] nvarchar(50)  NULL,
    [Office] nvarchar(50)  NULL,
    [HireDate] datetime  NULL,
    [Salary] int  NULL,
    [DepartmentId] int  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [RoleID] int IDENTITY(1,1) NOT NULL,
    [RoleName] varchar(50)  NULL
);
GO

-- Creating table 'UserRoleMapping'
CREATE TABLE [dbo].[UserRoleMapping] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NULL,
    [RoleId] int  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [AppUserName] varchar(50)  NULL,
    [FullName] varchar(50)  NULL,
    [Email] varchar(50)  NULL,
    [Password] varchar(50)  NULL,
    [DOB] datetime  NULL,
    [Adress] varchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [DeptId] in table 'Department'
ALTER TABLE [dbo].[Department]
ADD CONSTRAINT [PK_Department]
    PRIMARY KEY CLUSTERED ([DeptId] ASC);
GO

-- Creating primary key on [EmpId] in table 'Employee'
ALTER TABLE [dbo].[Employee]
ADD CONSTRAINT [PK_Employee]
    PRIMARY KEY CLUSTERED ([EmpId] ASC);
GO

-- Creating primary key on [RoleID] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleID] ASC);
GO

-- Creating primary key on [Id] in table 'UserRoleMapping'
ALTER TABLE [dbo].[UserRoleMapping]
ADD CONSTRAINT [PK_UserRoleMapping]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [DepartmentId] in table 'Employee'
ALTER TABLE [dbo].[Employee]
ADD CONSTRAINT [FK__Employee__Depart__1DE57479]
    FOREIGN KEY ([DepartmentId])
    REFERENCES [dbo].[Department]
        ([DeptId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__Employee__Depart__1DE57479'
CREATE INDEX [IX_FK__Employee__Depart__1DE57479]
ON [dbo].[Employee]
    ([DepartmentId]);
GO

-- Creating foreign key on [RoleId] in table 'UserRoleMapping'
ALTER TABLE [dbo].[UserRoleMapping]
ADD CONSTRAINT [FK__UserRoleM__RoleI__239E4DCF]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[Roles]
        ([RoleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__UserRoleM__RoleI__239E4DCF'
CREATE INDEX [IX_FK__UserRoleM__RoleI__239E4DCF]
ON [dbo].[UserRoleMapping]
    ([RoleId]);
GO

-- Creating foreign key on [UserId] in table 'UserRoleMapping'
ALTER TABLE [dbo].[UserRoleMapping]
ADD CONSTRAINT [FK__UserRoleM__UserI__22AA2996]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__UserRoleM__UserI__22AA2996'
CREATE INDEX [IX_FK__UserRoleM__UserI__22AA2996]
ON [dbo].[UserRoleMapping]
    ([UserId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------