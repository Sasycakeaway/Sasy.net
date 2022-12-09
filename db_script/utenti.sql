CREATE TABLE [dbo].[Ordini](
	[PK_ID] [uniqueidentifier] NOT NULL,
	[Nome] [nvarchar](256) NULL,
	[Cognome] [nvarchar](256) NULL,
	[Indirizzo] [nvarchar](256) NULL,
	[Cap] [nvarchar](256) NULL,
	[Domicilio] [nvarchar](256) NULL,
	[FK_Email] [nvarchar](100) NOT NULL,
	[Totale] [int] NULL,
	[Cart] [nvarchar](max) NULL,
	[Timestamp] [datetime] NULL,
 CONSTRAINT [PK_Ordini] PRIMARY KEY CLUSTERED 
(
	[PK_ID] ASC,
	[FK_Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
