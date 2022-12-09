-- Sasy.dbo.Ordini definition

-- Drop table

-- DROP TABLE Sasy.dbo.Ordini;

CREATE TABLE Ordini (
                        PK_ID uniqueidentifier NOT NULL,
                        Nome nvarchar(256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
                        Cognome nvarchar(256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
                        Indirizzo nvarchar(256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
                        Cap nvarchar(256) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
                        Domicilio binary(50) NULL,
                        FK_Email nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS DEFAULT NULL NOT NULL,
                        Totale int NULL,
                        Cart nvarchar(MAX) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
    [Timestamp] datetime NULL,
                        Spedizione binary(50) NULL,
                        CONSTRAINT PK_Ordini PRIMARY KEY (PK_ID,FK_Email)
);


-- Sasy.dbo.Ordini foreign keys

ALTER TABLE Sasy.dbo.Ordini ADD CONSTRAINT FK_Ordini_Utenti FOREIGN KEY (FK_Email) REFERENCES Utenti(PK_Email) ON DELETE CASCADE ON UPDATE CASCADE;