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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210203072151_addCategoryToDatabase')
BEGIN
    CREATE TABLE [Category] (
        [CategoryId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [DisplayOrder] int NOT NULL,
        CONSTRAINT [PK_Category] PRIMARY KEY ([CategoryId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210203072151_addCategoryToDatabase')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210203072151_addCategoryToDatabase', N'5.0.2');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210206062455_ApplicationTypeToDatabase')
BEGIN
    CREATE TABLE [ApplicationType] (
        [CategoryId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_ApplicationType] PRIMARY KEY ([CategoryId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210206062455_ApplicationTypeToDatabase')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210206062455_ApplicationTypeToDatabase', N'5.0.2');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210206211246_AddQuestionToDatabase')
BEGIN
    CREATE TABLE [Root] (
        [surveyId] nvarchar(450) NOT NULL,
        [Schema] nvarchar(max) NULL,
        [eventName] nvarchar(max) NULL,
        [surveyVersion] bigint NOT NULL,
        [name] nvarchar(max) NULL,
        [publishType] nvarchar(max) NULL,
        CONSTRAINT [PK_Root] PRIMARY KEY ([surveyId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210206211246_AddQuestionToDatabase')
BEGIN
    CREATE TABLE [Question] (
        [questionId] nvarchar(450) NOT NULL,
        [text] nvarchar(max) NULL,
        [RootsurveyId] nvarchar(450) NULL,
        CONSTRAINT [PK_Question] PRIMARY KEY ([questionId]),
        CONSTRAINT [FK_Question_Root_RootsurveyId] FOREIGN KEY ([RootsurveyId]) REFERENCES [Root] ([surveyId]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210206211246_AddQuestionToDatabase')
BEGIN
    CREATE INDEX [IX_Question_RootsurveyId] ON [Question] ([RootsurveyId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210206211246_AddQuestionToDatabase')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210206211246_AddQuestionToDatabase', N'5.0.2');
END;
GO

COMMIT;
GO

