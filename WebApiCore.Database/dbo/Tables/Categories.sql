CREATE TABLE [dbo].[Categories] (
    [CategoryId]   INT           IDENTITY (1, 1) NOT NULL,
    [CategoryName] VARCHAR (50)  NOT NULL,
    [Description]  VARCHAR (100) NULL,
    [ParentId]     INT           NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([CategoryId] ASC)
);

