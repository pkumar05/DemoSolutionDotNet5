﻿CREATE TABLE [DS].[EmployeeProfile] (
    [Id]                   VARCHAR (36)   NOT NULL,
    [EmployeeDepartmentId] VARCHAR (36)   NOT NULL,
    [EmployeeProfileId]    VARCHAR (36)   NOT NULL,
    [Name]                 NVARCHAR (100) NOT NULL,
    [Code]                 VARCHAR (100)  NULL,
    [Descriptions]         NVARCHAR (100) NULL,
    [Active]               BIT            NOT NULL,
    [CreatedBy]            NVARCHAR (256) NOT NULL,
    [CreatedDate]          DATETIME       NOT NULL,
    [Updatedby]            NVARCHAR (256) NULL,
    [UpdatedDate]          DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([EmployeeDepartmentId]) REFERENCES [DS].[Departments] ([Id]),
    FOREIGN KEY ([EmployeeProfileId]) REFERENCES [DS].[Profile] ([Id])
);

