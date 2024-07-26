
CREATE DATABASE [AngularNetCRUD]
 CONTAINMENT = NONE
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO


USE [AngularNetCRUD]
GO

/****** Object:  Table [dbo].[Productos]    Script Date: 6/18/2024 5:21:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Productos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Descripcion] [varchar](100) NOT NULL,
	[Codigo] [varchar](50) NOT NULL,
	[Precio] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Productos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Productos] ADD  CONSTRAINT [DF_Productos_Nombre]  DEFAULT ('') FOR [Nombre]
GO

ALTER TABLE [dbo].[Productos] ADD  CONSTRAINT [DF_Productos_Descripcion]  DEFAULT ('') FOR [Descripcion]
GO

ALTER TABLE [dbo].[Productos] ADD  CONSTRAINT [DF_Productos_Codigo]  DEFAULT ('') FOR [Codigo]
GO

