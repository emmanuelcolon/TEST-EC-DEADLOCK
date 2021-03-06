USE [master]
GO
/****** Object:  Database [TEST_DEADLOCK]    Script Date: 8/15/2020 2:45:56 PM ******/
CREATE DATABASE [TEST_DEADLOCK]

USE [TEST_DEADLOCK]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 8/15/2020 2:45:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[PersonaId] [int] IDENTITY(1,1) NOT NULL,
	[NombreCompleto] [varchar](255) NOT NULL,
	[PosicionTrabajoId] [int] NOT NULL,
 CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED 
(
	[PersonaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Posicion_Trabajo]    Script Date: 8/15/2020 2:45:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Posicion_Trabajo](
	[PosicionTrabajoId] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](255) NOT NULL,
 CONSTRAINT [PK_Posicion_Trabajo] PRIMARY KEY CLUSTERED 
(
	[PosicionTrabajoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Persona] ON 
GO
INSERT [dbo].[Persona] ([PersonaId], [NombreCompleto], [PosicionTrabajoId]) VALUES (1, N'EMMANUEL COLON', 1)
GO
INSERT [dbo].[Persona] ([PersonaId], [NombreCompleto], [PosicionTrabajoId]) VALUES (2, N'LIONEL MESSI', 2)
GO
INSERT [dbo].[Persona] ([PersonaId], [NombreCompleto], [PosicionTrabajoId]) VALUES (3, N'CRISTIANO RONALDO', 3)
GO
SET IDENTITY_INSERT [dbo].[Persona] OFF
GO
SET IDENTITY_INSERT [dbo].[Posicion_Trabajo] ON 
GO
INSERT [dbo].[Posicion_Trabajo] ([PosicionTrabajoId], [Nombre]) VALUES (1, N'DEVELOPER')
GO
INSERT [dbo].[Posicion_Trabajo] ([PosicionTrabajoId], [Nombre]) VALUES (2, N'ANALYST')
GO
INSERT [dbo].[Posicion_Trabajo] ([PosicionTrabajoId], [Nombre]) VALUES (3, N'DIRECTOR')
GO
SET IDENTITY_INSERT [dbo].[Posicion_Trabajo] OFF
GO
ALTER TABLE [dbo].[Persona]  WITH CHECK ADD  CONSTRAINT [FK_Persona_Posicion_Trabajo] FOREIGN KEY([PosicionTrabajoId])
REFERENCES [dbo].[Posicion_Trabajo] ([PosicionTrabajoId])
GO
ALTER TABLE [dbo].[Persona] CHECK CONSTRAINT [FK_Persona_Posicion_Trabajo]
GO
/****** Object:  StoredProcedure [dbo].[spLimpiarAmbasTablas]    Script Date: 8/15/2020 2:45:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spLimpiarAmbasTablas]
	 @PersonaId int,
	 @PosicionTrabajoId int
 AS
 BEGIN 
 
	DELETE FROM Persona WHERE PersonaId = @PersonaId
	DELETE FROM Posicion_Trabajo WHERE PosicionTrabajoId = @PosicionTrabajoId

 END
GO
USE [master]
GO
ALTER DATABASE [TEST_DEADLOCK] SET  READ_WRITE 
GO
