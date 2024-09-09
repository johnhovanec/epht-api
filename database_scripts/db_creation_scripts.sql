/*===================   epht].Config_Topic_Test   =====================*/

USE [MDHEPHT]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TABLE [epht].[Config_Topic_Test](
-- Note that table columns are named to match the existing application object structure
	topic_ID [int] NOT NULL,
	--[topic_Title] [nvarchar](255) NULL,   -- note that topics.js's topicPath == Topic_Title in the original Config_Topic table 
	topicTitle [nvarchar](255) NULL,
	topicPath [nvarchar](255) NULL,
	category [nvarchar](255) NULL,
	defaultTabPath [nvarchar](255) NULL,
	overview [nvarchar](4000) NULL,
	aboutData [nvarchar](4000) NULL,
	countySuppressionRuleRange [nvarchar](500) NULL,
	countySuppressionRulePopMin [nvarchar](500) NULL,
	subCountySuppressionRuleRange [nvarchar](500) NULL,
	subCountySuppressionRulePopMin [nvarchar](500) NULL,
	
 CONSTRAINT [PK_Config_Topic_Test_ID] PRIMARY KEY CLUSTERED 
(
	[topic_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO



/*===================   epht].Config_Theme_Test   =====================*/		

USE [MDHEPHT]
GO

/****** Object:  Table [epht].[Config_Theme]    Script Date: 9/9/2024 11:24:02 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [epht].[Config_Theme_Test](
-- Note that table columns are named to match the existing application object structure
	theme_ID [int] IDENTITY(1,1) NOT NULL,
	topic_ID [int]  FOREIGN KEY REFERENCES  epht.Config_Topic_Test(topic_ID),  -- FK to Config_Topic_Test table
	defaultTabPath [nvarchar](255) NULL,
	themeTitle [nvarchar](255) NULL,
	themePath [nvarchar](255) NULL, -- note that topics.js's themePath == Theme in the original Config_Topic table,
	themeOverviewText [nvarchar](4000), -- this had been stored as a separate themeOverviews object in the root of the topic, as part of the theme we just need the text.
	about [nvarchar](max) NULL,
	resources [nvarchar](max) NULL,
 CONSTRAINT [PK_Config_Theme_Test_ID] PRIMARY KEY CLUSTERED 
(
	[theme_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_Config_Theme_Test] UNIQUE NONCLUSTERED 
(
	[topic_ID] ASC,
	[themePath] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


/*===================   epht].Config_Tab_Test   =====================*/		

USE [MDHEPHT]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [epht].[Config_Tab_Test](
-- Note that table columns are named to match the existing application object structure
	tab_ID [int] IDENTITY(1,1) NOT NULL,
	theme_ID [int]  FOREIGN KEY REFERENCES  epht.Config_Theme_Test(theme_ID),  -- FK to Config_Theme_Test table
	tabTitle [nvarchar](255) NULL,
	tabPath [nvarchar](255) NULL, 
	contentType [nvarchar](50) NULL,
	exportTitle [nvarchar](1000) NULL,
	chartType [nvarchar](255) NULL,
	selectable [bit] NULL,
	baseline [nvarchar](255) NULL, 
	defaultSelection [nvarchar](255) NULL, 
	infoTitle [nvarchar](500) NULL,		-- was formerly part of the "info" object
	infoId [nvarchar](500) NULL,		-- was formerly part of the "info" object
	infoSubtitle [nvarchar](500) NULL,	-- was formerly part of the "info" object
	chartTitle [nvarchar](500) NULL,
	displayChartTitle [bit] NULL,
	chartYAxisField [nvarchar](500) NULL,
	displayChartDiscontinuityGraphic [bit] NULL,
	displayXAxisLabel [bit] NULL,
	xAxisLabel [nvarchar](500) NULL,
	[url] [nvarchar](4000) NULL,
	tableTitle [nvarchar](1000) NULL

 CONSTRAINT [PK_Config_Tab_Test_ID] PRIMARY KEY CLUSTERED 
(
	[tab_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
 CONSTRAINT [AK_Config_Tab_Test] UNIQUE NONCLUSTERED 
(
	[tab_ID] ASC,
	[tabPath] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO