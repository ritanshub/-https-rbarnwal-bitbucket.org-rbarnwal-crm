IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Customers] (
    [CreatedDate] datetime2 NULL,
    [CreatedBy] nvarchar(max) NULL,
    [CustomerID] nvarchar(450) NOT NULL,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [EmailID] nvarchar(max) NULL,
    [MobileNUmber] int NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([CustomerID])
);

GO

CREATE TABLE [Roles] (
    [CreatedDate] datetime2 NULL,
    [CreatedBy] nvarchar(max) NULL,
    [RoleID] int NOT NULL IDENTITY,
    [RoleName] nvarchar(max) NULL,
    [Active] int NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([RoleID])
);

GO

CREATE TABLE [Team] (
    [CreatedDate] datetime2 NULL,
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
    [CreatedBy] nvarchar(max) NULL,
    [EmployeeID] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NULL,
    [LastName] nvarchar(max) NULL,
    [EmailID] nvarchar(max) NULL,
    [MobileNUmber] int NOT NULL,
    [DOB] datetime2 NOT NULL,
    [Active] int NOT NULL,
    [RoleID] int NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([EmployeeID]),
    CONSTRAINT [FK_Employees_Roles_RoleID] FOREIGN KEY ([RoleID]) REFERENCES [Roles] ([RoleID]) ON DELETE CASCADE
);

GO

CREATE TABLE [Leads] (
    [CreatedDate] datetime2 NULL,
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
    [EmployeeID1] int NULL,
    [RoleID] int NOT NULL,
    CONSTRAINT [PK_ApplicationUsers] PRIMARY KEY ([UserName]),
    CONSTRAINT [FK_ApplicationUsers_Employees_EmployeeID1] FOREIGN KEY ([EmployeeID1]) REFERENCES [Employees] ([EmployeeID]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ApplicationUsers_Roles_RoleID] FOREIGN KEY ([RoleID]) REFERENCES [Roles] ([RoleID]) ON DELETE CASCADE
);

GO

CREATE TABLE [CustomerEnquiryDetails] (
    [EnquiryID] int NOT NULL IDENTITY,
    [CustomerID] int NOT NULL,
    [EmployeeID] int NOT NULL,
    [LeadID] int NOT NULL,
    [Loaction] nvarchar(max) NULL,
    [TravelSource] nvarchar(max) NULL,
    [TravelDestination] nvarchar(max) NULL,
    [TraveCategory] nvarchar(max) NULL,
    [AccomdationCategory] nvarchar(max) NULL,
    [TourCategory] nvarchar(max) NULL,
    [TravelExpectedDate] datetime2 NULL,
    [Budget] float NOT NULL,
    [Status] int NOT NULL,
    [CustomerID1] nvarchar(450) NULL,
    CONSTRAINT [PK_CustomerEnquiryDetails] PRIMARY KEY ([EnquiryID]),
    CONSTRAINT [FK_CustomerEnquiryDetails_Customers_CustomerID1] FOREIGN KEY ([CustomerID1]) REFERENCES [Customers] ([CustomerID]) ON DELETE NO ACTION,
    CONSTRAINT [FK_CustomerEnquiryDetails_Employees_EmployeeID] FOREIGN KEY ([EmployeeID]) REFERENCES [Employees] ([EmployeeID]) ON DELETE CASCADE,
    CONSTRAINT [FK_CustomerEnquiryDetails_Leads_LeadID] FOREIGN KEY ([LeadID]) REFERENCES [Leads] ([LeadID]) ON DELETE CASCADE
);

GO

CREATE TABLE [LeadEmployeeMapper] (
    [CreatedDate] datetime2 NULL,
    [CreatedBy] nvarchar(max) NULL,
    [LeadEmployeeMapperID] int NOT NULL IDENTITY,
    [LeadID] int NOT NULL,
    [EmployeeID] int NOT NULL,
    [Level] int NOT NULL,
    CONSTRAINT [PK_LeadEmployeeMapper] PRIMARY KEY ([LeadEmployeeMapperID]),
    CONSTRAINT [FK_LeadEmployeeMapper_Employees_EmployeeID] FOREIGN KEY ([EmployeeID]) REFERENCES [Employees] ([EmployeeID]) ON DELETE CASCADE,
    CONSTRAINT [FK_LeadEmployeeMapper_Leads_LeadID] FOREIGN KEY ([LeadID]) REFERENCES [Leads] ([LeadID]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_ApplicationUsers_EmployeeID1] ON [ApplicationUsers] ([EmployeeID1]);

GO

CREATE INDEX [IX_ApplicationUsers_RoleID] ON [ApplicationUsers] ([RoleID]);

GO

CREATE INDEX [IX_CustomerEnquiryDetails_CustomerID1] ON [CustomerEnquiryDetails] ([CustomerID1]);

GO

CREATE INDEX [IX_CustomerEnquiryDetails_EmployeeID] ON [CustomerEnquiryDetails] ([EmployeeID]);

GO

CREATE INDEX [IX_CustomerEnquiryDetails_LeadID] ON [CustomerEnquiryDetails] ([LeadID]);

GO

CREATE INDEX [IX_Employees_RoleID] ON [Employees] ([RoleID]);

GO

CREATE INDEX [IX_LeadEmployeeMapper_EmployeeID] ON [LeadEmployeeMapper] ([EmployeeID]);

GO

CREATE INDEX [IX_LeadEmployeeMapper_LeadID] ON [LeadEmployeeMapper] ([LeadID]);

GO

CREATE INDEX [IX_Leads_TeamId] ON [Leads] ([TeamId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20180623095602_Initial', N'2.1.1-rtm-30846');

GO

