USE [MDHEPHT]
GO

/****** Object:  Table [epht].[Config_Topic]    Script Date: 9/9/2024 9:54:43 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [epht].[Config_Topic_Test](
	topic_ID [int] NOT NULL,
	--[topic_Title] [nvarchar](255) NULL,   -- note that topics.js topicPath == the original Config_Topic Topic_Title
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
	
 CONSTRAINT [PK_Topic_ID] PRIMARY KEY CLUSTERED 
(
	[Topic_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


