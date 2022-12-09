-- Sasy.dbo.Newsletter definition

-- Drop table

-- DROP TABLE Sasy.dbo.Newsletter;

CREATE TABLE Newsletter (
                            FK_Email nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
                            PK_Token uniqueidentifier NOT NULL,
                            CONSTRAINT PK_Newsletter PRIMARY KEY (FK_Email,PK_Token)
);


-- Sasy.dbo.Newsletter foreign keys

ALTER TABLE Sasy.dbo.Newsletter ADD CONSTRAINT FK_Newsletter_Utenti FOREIGN KEY (FK_Email) REFERENCES Utenti(PK_Email);