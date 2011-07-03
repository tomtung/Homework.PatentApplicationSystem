USE [HW_PAS]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON

GO
CREATE TABLE [dbo].[客户](
	[客户号] [varchar](50) NOT NULL,
	[类型] [varchar](50) NULL,
	[地址] [varchar](50) NULL,
	[邮编] [varchar](50) NULL,
 CONSTRAINT [PK_客户] PRIMARY KEY CLUSTERED 
(
	[客户号] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[发明人](
	[身份证号] [varchar](50) NOT NULL,
	[姓名] [varchar](50) NULL,
	[电话] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
 CONSTRAINT [PK_发明人] PRIMARY KEY CLUSTERED 
(
	[身份证号] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[案件文件](
	[案件编号] [varchar](50) NOT NULL,
	[文件名] [varchar](50) NOT NULL,
	[创建人] [varchar](50) NULL,
	[创建日期] [datetime] NULL,
	[文件路径] [varchar](50) NULL,
 CONSTRAINT [PK_案件文件] PRIMARY KEY CLUSTERED 
(
	[案件编号] ASC,
	[文件名] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[员工](
	[用户名] [varchar](50) NOT NULL,
	[密码] [varchar](50) NULL,
	[角色] [varchar](50) NULL,
 CONSTRAINT [PK_员工] PRIMARY KEY CLUSTERED 
(
	[用户名] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[申请人](
	[证件号] [varchar](50) NOT NULL,
	[类型] [varchar](50) NULL,
	[中文名] [varchar](50) NULL,
	[英文名] [varchar](50) NULL,
	[简称] [varchar](50) NULL,
	[国家] [varchar](50) NULL,
	[省] [varchar](50) NULL,
	[市区县] [varchar](50) NULL,
	[中国地址] [varchar](50) NULL,
	[外国地址] [varchar](50) NULL,
	[邮编] [varchar](50) NULL,
	[电话] [varchar](50) NULL,
	[传真] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
 CONSTRAINT [PK_申请人] PRIMARY KEY CLUSTERED 
(
	[证件号] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[客户联系人](
	[姓名] [varchar](50) NULL,
	[电话] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[联系人类型] [varchar](50) NULL,
	[客户号] [varchar](50) NULL
) ON [PRIMARY]

CREATE TABLE [dbo].[案件](
	[编号] [varchar](50) NOT NULL,
	[名称] [varchar](50) NULL,
	[案件类型] [varchar](50) NULL,
	[创建时间] [datetime] NULL,
	[绝限日] [datetime] NULL,
	[状态] [varchar](50) NULL,
	[客户号] [varchar](50) NULL,
	[申请人证件号] [varchar](50) NULL,
	[发明人身份证号] [varchar](50) NULL,
	[主办员用户名] [varchar](50) NULL,
	[翻译用户名] [varchar](50) NULL,
	[一校用户名] [varchar](50) NULL,
	[二校用户名] [varchar](50) NULL,
 CONSTRAINT [PK_案件] PRIMARY KEY CLUSTERED 
(
	[编号] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[WorkflowBookmark](
	[CaseId] [varchar](50) NOT NULL,
	[WorkflowInstanceId] [varchar](50) NOT NULL,
	[BookmarkName] [varchar](50) NOT NULL
) ON [PRIMARY]


GO

ALTER TABLE [dbo].[客户联系人]  WITH CHECK ADD  CONSTRAINT [FK_客户联系人_客户] FOREIGN KEY([客户号])
REFERENCES [dbo].[客户] ([客户号])

ALTER TABLE [dbo].[客户联系人] CHECK CONSTRAINT [FK_客户联系人_客户]

ALTER TABLE [dbo].[案件]  WITH CHECK ADD  CONSTRAINT [FK_案件_发明人] FOREIGN KEY([发明人身份证号])
REFERENCES [dbo].[发明人] ([身份证号])

ALTER TABLE [dbo].[案件] CHECK CONSTRAINT [FK_案件_发明人]

ALTER TABLE [dbo].[案件]  WITH CHECK ADD  CONSTRAINT [FK_案件_客户] FOREIGN KEY([客户号])
REFERENCES [dbo].[客户] ([客户号])

ALTER TABLE [dbo].[案件] CHECK CONSTRAINT [FK_案件_客户]

ALTER TABLE [dbo].[案件]  WITH CHECK ADD  CONSTRAINT [FK_案件_申请人] FOREIGN KEY([申请人证件号])
REFERENCES [dbo].[申请人] ([证件号])

ALTER TABLE [dbo].[案件] CHECK CONSTRAINT [FK_案件_申请人]

ALTER TABLE [dbo].[案件]  WITH CHECK ADD  CONSTRAINT [FK_案件_员工_主办员] FOREIGN KEY([主办员用户名])
REFERENCES [dbo].[员工] ([用户名])

ALTER TABLE [dbo].[案件] CHECK CONSTRAINT [FK_案件_员工_主办员]

ALTER TABLE [dbo].[案件]  WITH CHECK ADD  CONSTRAINT [FK_案件_员工_翻译] FOREIGN KEY([翻译用户名])
REFERENCES [dbo].[员工] ([用户名])

ALTER TABLE [dbo].[案件] CHECK CONSTRAINT [FK_案件_员工_翻译]

ALTER TABLE [dbo].[案件]  WITH CHECK ADD  CONSTRAINT [FK_案件_员工_一校] FOREIGN KEY([一校用户名])
REFERENCES [dbo].[员工] ([用户名])

ALTER TABLE [dbo].[案件] CHECK CONSTRAINT [FK_案件_员工_一校]

ALTER TABLE [dbo].[案件]  WITH CHECK ADD  CONSTRAINT [FK_案件_员工_二校] FOREIGN KEY([二校用户名])
REFERENCES [dbo].[员工] ([用户名])

ALTER TABLE [dbo].[案件] CHECK CONSTRAINT [FK_案件_员工_二校]

ALTER TABLE [dbo].[WorkflowBookmark]  WITH CHECK ADD  CONSTRAINT [FK_WorkflowBookmark_案件] FOREIGN KEY([CaseId])
REFERENCES [dbo].[案件] ([编号])

ALTER TABLE [dbo].[WorkflowBookmark] CHECK CONSTRAINT [FK_WorkflowBookmark_案件]

GO

SET ANSI_PADDING OFF
GO
