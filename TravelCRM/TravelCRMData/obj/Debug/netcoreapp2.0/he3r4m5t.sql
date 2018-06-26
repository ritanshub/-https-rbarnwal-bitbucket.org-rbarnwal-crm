IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [LeadEmployeeMapper] (
    [CreatedDate] datetime2 NULL,
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] nvarchar(max) NULL,
    [LeadID] int NOT NULL,
    [ManagerID] nvarchar(max) NULL,
    [Level] int NOT NULL,
    CONSTRAINT [PK_LeadEmployeeMapper] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Roles] (
    [CreatedDate] datetime2 NULL,
    [Id] int NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [RoleID] int NOT NULL IDENTITY,
    [RoleName] nvarchar(max) NULL,
    [Active] int NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([RoleID])
);

GO

CREATE TABLE [Team] (
    [CreatedDate] datetime2 NULL,
    [Id] int NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [TeamId] int NOT NULL IDENTITY,
    [TeamName] nvarchar(max) NULL,
    [ManagerName] nvarchar(max) NULL,
    [ManagerID] int NOT NULL,
    CONSTRAINT [PK_Team] PRIMARY KEY ([TeamId])
);

GO

CREATE TABLE [Employees] (
    [CreatedDate] datetime2 NULL,
    [Id] int NOT NULL IDENTITY,
    [CreatedBy] nvarchar(max) NULL,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [EmailID] nvarchar(max) NULL,
    [MobileNUmber] int NOT NULL,
    [DOB] datetime2 NOT NULL,
    [Active] int NOT NULL,
    [RoleID] int NOT NULL,
    [RoleID1] int NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Employees_Roles_RoleID1] FOREIGN KEY ([RoleID1]) REFERENCES [Roles] ([RoleID]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Leads] (
    [CreatedDate] datetime2 NULL,
    [Id] int NOT NULL,
    [CreatedBy] nvarchar(max) NULL,
    [LeadID] int NOT NULL IDENTITY,
    [LeadSource] nvarchar(max) NULL,
    [ModifiedTime] datetime2 NULL,
    [JourneySource] nvarchar(max) NULL,
    [JourneyDestination] nvarchar(max) NULL,
    [Budget] float NOT NULL,
    [CurrentStatus] int NOT NULL,
    [ModeOfTravel] int NOT NULL,
    [TeamId] int NOT NULL,
    [StayPeriod] nvarchar(max) NULL,
    CONSTRAINT [PK_Leads] PRIMARY KEY ([LeadID]),
    CONSTRAINT [FK_Leads_Team_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [Team] ([TeamId]) ON DELETE CASCADE
);

GO

CREATE TABLE [ApplicationUsers] (
    [UserName] nvarchar(450) NOT NULL,
    [Password] nvarchar(max) NULL,
    [Role] nvarchar(max) NULL,
    [IsLoggedIn] bit NOT NULL,
    [EmployeeID] nvarchar(max) NULL,
    [empId] int NULL,
    [RoleID] int NOT NULL,
    CONSTRAINT [PK_ApplicationUsers] PRIMARY KEY ([UserName]),
    CONSTRAINT [FK_ApplicationUsers_Roles_RoleID] FOREIGN KEY ([RoleID]) REFERENCES [Roles] ([RoleID]) ON DELETE CASCADE,
    CONSTRAINT [FK_ApplicationUsers_Employees_empId] FOREIGN KEY ([empId]) REFERENCES [Employees] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_ApplicationUsers_RoleID] ON [ApplicationUsers] ([RoleID]);

GO

CREATE INDEX [IX_ApplicationUsers_empId] ON [ApplicationUsers] ([empId]);

GO

CREATE INDEX [IX_Employees_RoleID1] ON [Employees] ([RoleID1]);

GO

CREATE INDEX [IX_Leads_TeamId] ON [Leads] ([TeamId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180620190847_Initail', N'2.1.1-rtm-30846');

GO

