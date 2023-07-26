IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Person] (
    [TenantId] int NOT NULL,
    [PersonId] int NOT NULL,
    [Name] nvarchar(24) NULL,
    [LastName] nvarchar(24) NULL,
    [Email] nvarchar(24) NULL,
    [ModifiedBy] int NULL,
    [DateCreated] datetime NULL,
    [Active] bit NULL,
    CONSTRAINT [PK_TenantId_PersonId] PRIMARY KEY ([TenantId], [PersonId])
);
GO

CREATE TABLE [Product] (
    [TenantId] int NOT NULL,
    [ProductId] int NOT NULL,
    [Name] nvarchar(60) NULL,
    [Description] nvarchar(120) NULL,
    [Price] decimal(5,2) NULL,
    [ProductTypeId] int NULL,
    [ModifiedBy] int NULL,
    [DateCreated] datetime NULL,
    [Active] bit NULL,
    CONSTRAINT [PK_ProductId_TenantId] PRIMARY KEY ([ProductId], [TenantId])
);
GO

CREATE TABLE [ProductType] (
    [TenantId] int NOT NULL,
    [ProductTypeId] int NOT NULL,
    [Name] nvarchar(60) NULL,
    [Description] nvarchar(120) NULL,
    [ModifiedBy] int NULL,
    [DateCreated] datetime NULL,
    [Active] bit NULL,
    CONSTRAINT [PK_ProductTypeId_TenantId] PRIMARY KEY ([ProductTypeId], [TenantId])
);
GO

CREATE TABLE [Tenant] (
    [TenantId] int NOT NULL,
    [Name] nvarchar(30) NULL,
    [ModifiedBy] int NULL,
    [DateCreated] datetime NULL,
    [Active] bit NULL,
    CONSTRAINT [PK_TenantId] PRIMARY KEY ([TenantId])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230726004312_Night-Prototype', N'7.0.2');
GO

COMMIT;
GO

