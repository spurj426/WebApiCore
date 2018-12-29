CREATE TABLE [dbo].[Photos] (
    [PhotoId]        INT            IDENTITY (1, 1) NOT NULL,
    [FileName]       VARCHAR (50)   NOT NULL,
    [MediumFileName] VARCHAR (50)   NULL,
    [SmallFileName]  VARCHAR (50)   NULL,
    [Caption]        VARCHAR (100)  NULL,
    [Details]        VARCHAR (1000) NULL,
    [OwnerId]        INT            NULL,
    CONSTRAINT [PK_Photos] PRIMARY KEY CLUSTERED ([PhotoId] ASC)
);

