USE master;
GO

ALTER DATABASE FieldAgent SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
DROP DATABASE FieldAgent;
GO

CREATE DATABASE FieldAgent;
GO

USE FieldAgent;
GO

CREATE TABLE Agency (
    AgencyId int primary key identity(1,1),
    ShortName nvarchar(25) not null,
    LongName nvarchar(255) null
)
GO

CREATE TABLE [Location] (
    LocationId int primary key identity(1,1),
    AgencyId int not null foreign key references Agency(AgencyId),
    LocationName nvarchar(50) not null,
    Street1 nvarchar(50) not null,
    Street2 nvarchar(50) null,
    City nvarchar(50) not null,
    PostalCode nvarchar(15) not null,
    CountryCode varchar(5) not null
)
GO

CREATE TABLE Mission (
    MissionId int primary key identity(1,1),
    AgencyId int not null foreign key references Agency(AgencyId),
    CodeName nvarchar(50) not null,
    StartDate datetime2 not null,
    ProjectedEndDate datetime2 not null,
    ActualEndDate datetime2 null,
    OperationalCost decimal(10,2),
    Notes ntext null
)
GO

CREATE TABLE Agent(
    AgentId int primary key identity(1,1),
    FirstName nvarchar(50) not null,
    LastName nvarchar(50) not null,
    DateOfBirth datetime2 not null,
    Height decimal(5,2) not null
)
GO

CREATE TABLE Alias (
    AliasId int primary key identity(1,1),
    AgentId int not null foreign key references Agent(AgentId),
    AliasName nvarchar(50),
    InterpolId UNIQUEIDENTIFIER null,
    Persona ntext null
)
GO

CREATE TABLE MissionAgent (
    MissionId int not null foreign key references Mission(MissionId),
    AgentId int not null foreign key references Agent(AgentId),
    CONSTRAINT PK_MissionAgent PRIMARY KEY (MissionId, AgentId)
)
GO

CREATE TABLE SecurityClearance(
    SecurityClearanceId int primary key identity(1,1),
    SecurityClearanceName varchar(50) not null
)
GO

CREATE TABLE AgencyAgent (
    AgencyId int not null foreign key references Agency(AgencyId),
    AgentId int not null foreign key references Agent(AgentId),
    SecurityClearanceId int not null foreign key references SecurityClearance(SecurityClearanceId),
    BadgeId UNIQUEIDENTIFIER not null,
    ActivationDate datetime2 not null,
    DeactivationDate datetime2 null,
    IsActive bit not null default(1)
)
GO