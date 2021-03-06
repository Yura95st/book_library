USE [library]
GO
/****** Object:  Table [dbo].[authors]    Script Date: 3/10/2014 5:48:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[authors](
	[author_id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](100) NOT NULL,
	[last_name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_authors] PRIMARY KEY CLUSTERED 
(
	[author_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[book_authors]    Script Date: 3/10/2014 5:48:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[book_authors](
	[book_id] [int] NOT NULL,
	[author_id] [int] NOT NULL,
 CONSTRAINT [PK_book_authors] PRIMARY KEY CLUSTERED 
(
	[book_id] ASC,
	[author_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[book_location]    Script Date: 3/10/2014 5:48:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[book_location](
	[row_num] [int] NOT NULL,
	[shelf_num] [int] NOT NULL,
	[cell_num] [int] NOT NULL,
	[book_id] [int] NOT NULL,
 CONSTRAINT [PK_book_location] PRIMARY KEY CLUSTERED 
(
	[row_num] ASC,
	[shelf_num] ASC,
	[cell_num] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[books]    Script Date: 3/10/2014 5:48:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[books](
	[book_id] [int] IDENTITY(1,1) NOT NULL,
	[book_isnb] [nchar](13) NOT NULL,
 CONSTRAINT [PK_books] PRIMARY KEY CLUSTERED 
(
	[book_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[books_isnb]    Script Date: 3/10/2014 5:48:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[books_isnb](
	[book_isnb] [nchar](13) NOT NULL,
	[title] [nvarchar](500) NOT NULL,
	[type] [int] NOT NULL,
	[pub_id] [int] NOT NULL,
	[pub_date] [timestamp] NOT NULL,
 CONSTRAINT [PK_books_isnb] PRIMARY KEY CLUSTERED 
(
	[book_isnb] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[penalties]    Script Date: 3/10/2014 5:48:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[penalties](
	[penalty_id] [int] IDENTITY(1,1) NOT NULL,
	[reader_id] [int] NOT NULL,
	[type] [int] NOT NULL,
	[exp_date] [timestamp] NOT NULL,
	[state] [int] NOT NULL,
 CONSTRAINT [PK_reader_penalties] PRIMARY KEY CLUSTERED 
(
	[penalty_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[publishers]    Script Date: 3/10/2014 5:48:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[publishers](
	[pub_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[address] [nvarchar](500) NULL,
	[city] [nvarchar](100) NULL,
	[phone] [nvarchar](50) NULL,
 CONSTRAINT [PK_publishers] PRIMARY KEY CLUSTERED 
(
	[pub_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[reader_books]    Script Date: 3/10/2014 5:48:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reader_books](
	[book_id] [int] NOT NULL,
	[reader_id] [int] NOT NULL,
	[exp_date] [timestamp] NOT NULL,
	[state] [int] NOT NULL,
	[row_id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_reader_books_1] PRIMARY KEY CLUSTERED 
(
	[row_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[readers]    Script Date: 3/10/2014 5:48:11 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[readers](
	[reader_id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](100) NOT NULL,
	[last_name] [nvarchar](100) NOT NULL,
	[phone] [nvarchar](50) NULL,
	[address] [nvarchar](500) NULL,
	[city] [nvarchar](100) NULL,
 CONSTRAINT [PK_readers] PRIMARY KEY CLUSTERED 
(
	[reader_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[reader_books] ADD  CONSTRAINT [DF_reader_books_state]  DEFAULT ((1)) FOR [state]
GO
ALTER TABLE [dbo].[book_authors]  WITH CHECK ADD  CONSTRAINT [FK_book_authors_authors] FOREIGN KEY([author_id])
REFERENCES [dbo].[authors] ([author_id])
GO
ALTER TABLE [dbo].[book_authors] CHECK CONSTRAINT [FK_book_authors_authors]
GO
ALTER TABLE [dbo].[book_authors]  WITH CHECK ADD  CONSTRAINT [FK_book_authors_books] FOREIGN KEY([book_id])
REFERENCES [dbo].[books] ([book_id])
GO
ALTER TABLE [dbo].[book_authors] CHECK CONSTRAINT [FK_book_authors_books]
GO
ALTER TABLE [dbo].[book_location]  WITH CHECK ADD  CONSTRAINT [FK_book_location_books] FOREIGN KEY([book_id])
REFERENCES [dbo].[books] ([book_id])
GO
ALTER TABLE [dbo].[book_location] CHECK CONSTRAINT [FK_book_location_books]
GO
ALTER TABLE [dbo].[books]  WITH CHECK ADD  CONSTRAINT [FK_books_books_isnb] FOREIGN KEY([book_isnb])
REFERENCES [dbo].[books_isnb] ([book_isnb])
GO
ALTER TABLE [dbo].[books] CHECK CONSTRAINT [FK_books_books_isnb]
GO
ALTER TABLE [dbo].[books_isnb]  WITH CHECK ADD  CONSTRAINT [FK_books_isnb_publishers] FOREIGN KEY([pub_id])
REFERENCES [dbo].[publishers] ([pub_id])
GO
ALTER TABLE [dbo].[books_isnb] CHECK CONSTRAINT [FK_books_isnb_publishers]
GO
ALTER TABLE [dbo].[penalties]  WITH CHECK ADD  CONSTRAINT [FK_reader_penalties_readers] FOREIGN KEY([reader_id])
REFERENCES [dbo].[readers] ([reader_id])
GO
ALTER TABLE [dbo].[penalties] CHECK CONSTRAINT [FK_reader_penalties_readers]
GO
ALTER TABLE [dbo].[reader_books]  WITH CHECK ADD  CONSTRAINT [FK_reader_books_books] FOREIGN KEY([book_id])
REFERENCES [dbo].[books] ([book_id])
GO
ALTER TABLE [dbo].[reader_books] CHECK CONSTRAINT [FK_reader_books_books]
GO
ALTER TABLE [dbo].[reader_books]  WITH CHECK ADD  CONSTRAINT [FK_reader_books_readers] FOREIGN KEY([reader_id])
REFERENCES [dbo].[readers] ([reader_id])
GO
ALTER TABLE [dbo].[reader_books] CHECK CONSTRAINT [FK_reader_books_readers]
GO
