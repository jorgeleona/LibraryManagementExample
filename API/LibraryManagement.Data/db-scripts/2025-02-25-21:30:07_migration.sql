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
IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250225203934_Initial'
)
BEGIN
    CREATE TABLE [Authors] (
        [Id] uniqueidentifier NOT NULL DEFAULT (NEWID()),
        [Name] nvarchar(250) NOT NULL,
        [DateOfBirth] Date NOT NULL,
        [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
        [CreatedOn] Date NOT NULL DEFAULT (GETDATE()),
        [LastModificationOn] Date NOT NULL DEFAULT (GETDATE()),
        CONSTRAINT [PK_Authors] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250225203934_Initial'
)
BEGIN
    CREATE TABLE [Categories] (
        [Id] uniqueidentifier NOT NULL DEFAULT (NEWID()),
        [Name] nvarchar(100) NOT NULL,
        [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
        [CreatedOn] Date NOT NULL DEFAULT (GETDATE()),
        [LastModificationOn] Date NOT NULL DEFAULT (GETDATE()),
        CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250225203934_Initial'
)
BEGIN
    CREATE TABLE [Books] (
        [Id] uniqueidentifier NOT NULL DEFAULT (NEWID()),
        [Title] nvarchar(250) NOT NULL,
        [AuthorId] uniqueidentifier NOT NULL,
        [PublishedDate] Date NOT NULL,
        [Genre] nvarchar(100) NULL,
        [IsActive] bit NOT NULL DEFAULT CAST(1 AS bit),
        [CreatedOn] Date NOT NULL DEFAULT (GETDATE()),
        [LastModificationOn] Date NOT NULL DEFAULT (GETDATE()),
        CONSTRAINT [PK_Books] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Books_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [Authors] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250225203934_Initial'
)
BEGIN
    CREATE TABLE [BookCategory] (
        [Id] uniqueidentifier NOT NULL,
        [BookId] uniqueidentifier NOT NULL,
        [CategoryId] uniqueidentifier NOT NULL,
        [IsActive] bit NOT NULL,
        [CreatedOn] datetime2 NOT NULL,
        [LastModificationOn] datetime2 NOT NULL,
        CONSTRAINT [PK_BookCategory] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_BookCategory_Books_BookId] FOREIGN KEY ([BookId]) REFERENCES [Books] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_BookCategory_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id]) ON DELETE CASCADE
    );
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250225203934_Initial'
)
BEGIN
    CREATE INDEX [IX_BookCategory_BookId] ON [BookCategory] ([BookId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250225203934_Initial'
)
BEGIN
    CREATE INDEX [IX_BookCategory_CategoryId] ON [BookCategory] ([CategoryId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250225203934_Initial'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Books_AuthorId] ON [Books] ([AuthorId]);
END;

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20250225203934_Initial'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20250225203934_Initial', N'9.0.2');
END;

COMMIT;
GO

