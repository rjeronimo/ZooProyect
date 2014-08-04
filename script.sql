USE [master]
GO
CREATE DATABASE [zoologico] 
GO
CREATE TABLE [dbo].[reservas](
	[codreserva] [varchar](10) NULL,
	[codpersona] [varchar](10) NULL,
	[asistentes] [varchar](150) NULL,
	[fecha_Reserva] [varchar](10) NULL,
	[turno] [varchar](50) NULL,
	[preferencia] [varchar](50) NULL
) 
GO

CREATE DATABASE [institucion]
GO
CREATE TABLE [dbo].[institucion](
	[codigo] [int] NOT NULL,
	[RUC] [varchar](11) NULL,
	[Nombre] [varchar](50) NULL,
) 
GO
INSERT [dbo].[institucion] ([codigo], [RUC], [Nombre]) VALUES (1, N'9876789567', N'CLARIDAD')
INSERT [dbo].[institucion] ([codigo], [RUC], [Nombre]) VALUES (2, N'3457435673', N'LOS PODEROSOS')
INSERT [dbo].[institucion] ([codigo], [RUC], [Nombre]) VALUES (3, N'4556342342', N'CON FE Y APRENDES')
