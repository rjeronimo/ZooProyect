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
