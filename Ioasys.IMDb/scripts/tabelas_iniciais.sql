IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Administradores] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(200) NOT NULL,
    [Login] varchar(200) NOT NULL,
    [Senha] varchar(100) NOT NULL,
    [Ativo] bit NOT NULL,
    [NivelAcesso] int NOT NULL,
    CONSTRAINT [PK_Administradores] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Usuarios] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(200) NOT NULL,
    [Login] varchar(200) NOT NULL,
    [Senha] varchar(100) NOT NULL,
    [Ativo] bit NOT NULL,
    [NivelAcesso] int NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210428181901_tabelas_iniciais', N'3.1.14');

GO

