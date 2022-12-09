-- Sasy.dbo.RecoveryPassword definition

-- Drop table

-- DROP TABLE Sasy.dbo.RecoveryPassword;

CREATE TABLE RecoveryPassword (
                                  UUID uniqueidentifier NULL,
                                  FK_Email nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS DEFAULT NULL NOT NULL,
                                  CONSTRAINT PK_RecoveryPassword PRIMARY KEY (FK_Email)
);


-- Sasy.dbo.RecoveryPassword foreign keys

ALTER TABLE Sasy.dbo.RecoveryPassword ADD CONSTRAINT FK_RecoveryPassword_Utenti FOREIGN KEY (FK_Email) REFERENCES Utenti(PK_Email) ON DELETE CASCADE ON UPDATE CASCADE;