/****** Object:  Table [dbo].[Menu]    Script Date: 11/27/2014 11:31:19 ******/
SET IDENTITY_INSERT [dbo].[Menu] ON

--集团

INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (11, NULL, 'Home', 'Home', N'客户管理', N'客户管理', 1, NULL,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (12, NULL, 'Company', 'Index', N'客户管理', N'客户管理', 1, 11,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (13, NULL, 'Home', 'Home', N'融资信息列表', N'融资信息列表', 2, 11,0)
--INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (14, NULL, 'Home', 'Home', N'客户融资记录', N'客户融资记录', 3, 11,0)

INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (21, NULL, 'Home', 'Home', N'机构管理', N'机构管理', 2, NULL,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (22, NULL, 'Home', 'Home', N'机构管理', N'机构管理', 1, 21,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (23, NULL, 'Home', 'Home', N'放贷产品列表', N'放贷产品列表', 2, 21,0)
--INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (24, NULL, 'Home', 'Home', N'机构放贷记录', N'机构放贷记录', 3, 21,0)

INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (31, NULL, 'Home', 'Home', N'借贷匹配', N'借贷匹配', 3, NULL,0)

INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (41, NULL, 'Home', 'Home', N'项目管理', N'项目管理', 4, NULL,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (42, NULL, 'Home', 'Home', N'我的申请', N'我的申请', 1, 41,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (43, NULL, 'Home', 'Home', N'立项申请', N'立项申请', 2, 41,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (44, NULL, 'Home', 'Home', N'项目列表', N'项目列表', 3, 41,0)

INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (51, NULL, 'Home', 'Home', N'账号管理', N'账号管理', 5, NULL,0)

INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (61, NULL, 'Home', 'Home', N'系统管理', N'系统管理', 6, NULL,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (62, NULL, 'Role', 'Index', N'角色管理', N'角色管理', 1, 61,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (63, NULL, 'GroupAccount', 'Index', N'人员管理', N'人员管理', 2, 61,0)

SET IDENTITY_INSERT [dbo].[Menu] OFF

/****** Object:  Table [dbo].[MenuOption]    Script Date: 12/05/2014 12:46:05 ******/



/****** Object:  Table [dbo].[Role]    Script Date: 12/05/2014 13:04:55 ******/



/****** Object:  Table [dbo].[Group]    Script Date: 11/27/2014 14:40:46 ******/
SET IDENTITY_INSERT [dbo].[Group] ON
INSERT [dbo].[Group] ([ID], [Name]) VALUES (1, N'兆恒投资')
SET IDENTITY_INSERT [dbo].[Group] OFF


/****** Object:  Table [dbo].[GroupAccount]    Script Date: 11/27/2014 14:40:46 ******/
SET IDENTITY_INSERT [dbo].[GroupAccount] ON
INSERT [dbo].[GroupAccount] ([ID], [GroupID], [AccountNumber], [AccountPwd], [Name], [Phone], [Email]) VALUES (1, 1, N'zhaoheng', N'm8YlpCH5g1U=', N'zhaoheng', N'zhaoheng', N'zhaoheng')
SET IDENTITY_INSERT [dbo].[GroupAccount] OFF

/***流程分类***/
SET IDENTITY_INSERT [dbo].[WorkFlowManager] ON
INSERT [dbo].[WorkFlowManager] ([ID], [Name], [IsEnable]) VALUES (1, '大型企业或另类融资顾问业务','True')
INSERT [dbo].[WorkFlowManager] ([ID], [Name], [IsEnable]) VALUES (2, '中小企业融资顾问业务','True')
INSERT [dbo].[WorkFlowManager] ([ID], [Name], [IsEnable]) VALUES (3, '小微企业融资顾问业务','True')
INSERT [dbo].[WorkFlowManager] ([ID], [Name], [IsEnable]) VALUES (4, '自有资金业务','True')
SET IDENTITY_INSERT [dbo].[WorkFlowManager] OFF


/***流程节点***/
SET IDENTITY_INSERT [dbo].[WorkFlowNodeManager] ON
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[IsSinceApproval],[Controllers],[Acction]) VALUES (1, '融资立项初审','无','False','','')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[IsSinceApproval],[Controllers],[Acction]) VALUES (2, '项目立项','无','False','','')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[IsSinceApproval],[Controllers],[Acction]) VALUES (3, '签署协议','无','True','','')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[IsSinceApproval],[Controllers],[Acction]) VALUES (4, '协议确认','无','False','','')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[IsSinceApproval],[Controllers],[Acction]) VALUES (5, '调查辅导','无','True','','')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[IsSinceApproval],[Controllers],[Acction]) VALUES (6, '机构对接','无','False','','')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[IsSinceApproval],[Controllers],[Acction]) VALUES (7, '落实放款','无','False','','')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[IsSinceApproval],[Controllers],[Acction]) VALUES (8, '确认收取费用','无','False','','')
SET IDENTITY_INSERT [dbo].[WorkFlowNodeManager] OFF
/****** Object:  Table [dbo].[Company]    Script Date: 11/27/2014 14:40:46 ******/


/****** Object:  Table [dbo].[CompanyAccount]    Script Date: 11/27/2014 14:40:46 ******/