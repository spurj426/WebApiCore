CREATE TABLE [dbo].[PhotoTags] (
    [PhotoTagId] INT IDENTITY (1, 1) NOT NULL,
    [PhotoId]    INT NOT NULL,
    [TagId]      INT NOT NULL,
    CONSTRAINT [PK_PhotoTags] PRIMARY KEY CLUSTERED ([PhotoTagId] ASC),
    CONSTRAINT [FK_PhotoTags_Photos] FOREIGN KEY ([PhotoId]) REFERENCES [dbo].[Photos] ([PhotoId])
);

