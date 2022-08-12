CREATE TABLE [DS].[Departments] (
    [Id]           VARCHAR (36)   NOT NULL,
    [Name]         VARCHAR (100)  NOT NULL,
    [Code]         VARCHAR (100)  NULL,
    [Descriptions] NVARCHAR (100) NULL,
    [Active]       BIT            NOT NULL,
    [CreatedBy]    NVARCHAR (256) NOT NULL,
    [CreatedDate]  DATETIME       NOT NULL,
    [Updatedby]    NVARCHAR (256) NULL,
    [UpdatedDate]  DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

