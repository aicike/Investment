/****** Object:  Table [dbo].[Menu]    Script Date: 11/27/2014 11:31:19 ******/
SET IDENTITY_INSERT [dbo].[Menu] ON

--集团

INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (11, NULL, 'Home', 'Home', N'预算管理', N'预算管理', 2, NULL,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (12, NULL, 'ProfitLoss', 'GroupIndex', N'损益预算', N'损益预算', 1, 11,0)

INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (21, NULL, 'Home', 'Home', N'账号管理', N'账号管理', 3, NULL,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (22, NULL, 'Home', 'Home', N'个人信息', N'个人信息', 1, 21,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (23, NULL, 'Home', 'Home', N'修改密码', N'修改密码', 2, 21,0)

INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (31, NULL, 'Home', 'Home', N'系统配置', N'系统配置', 4, NULL,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (35, NULL, 'Company', 'Index', N'公司管理', N'公司管理', 1, 31,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType,IsShow) VALUES (3501, NULL, 'CompanyAccount', 'Index', N'管理用户', N'管理用户', 1, 35,0,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (32, NULL, 'Role', 'Index', N'角色管理', N'角色管理', 2, 31,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (33, NULL, 'GroupAccount', 'Index', N'集团人员管理', N'集团人员管理', 3, 31,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (34, NULL, 'Coefficient', 'Index', N'预算系数管理', N'预算系数管理', 4, 31,0)

--公司
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (101, NULL, 'Home', 'Home', N'预算管理', N'预算管理', 1, NULL,1)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (102, NULL, 'ProfitLoss', 'Index', N'损益预算', N'损益预算', 1, 101,1)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType,IsShow) VALUES (10201, NULL, 'ProfitLoss', 'Detail', N'损益预算填写', N'损益预算填写', 1, 102,1,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType,IsShow) VALUES (10202, NULL, 'ProfitLoss', 'ActualMonthList', N'损益数据列表', N'损益数据列表', 2, 102,1,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType,IsShow) VALUES (10203, NULL, 'ProfitLoss', 'RealityDetail', N'损益数据详细', N'损益数据详细', 3, 102,1,0)

INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (111, NULL, 'Home', 'Home', N'账号管理', N'账号管理', 2, NULL,1)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (112, NULL, 'Home', 'Home', N'个人信息', N'个人信息', 1, 111,1)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (113, NULL, 'Home', 'Home', N'修改密码', N'修改密码', 2, 111,1)

SET IDENTITY_INSERT [dbo].[Menu] OFF

/****** Object:  Table [dbo].[MenuOption]    Script Date: 12/05/2014 12:46:05 ******/
--集团
INSERT [dbo].[MenuOption] ([MenuID], [Name], [Controller],[Action], [Order]) VALUES (35, N'公司列表', 'Company', N'Index', 1)
INSERT [dbo].[MenuOption] ([MenuID], [Name], [Controller],[Action], [Order]) VALUES (3501, N'管理用户', 'CompanyAccount', N'Index', 2)

INSERT [dbo].[MenuOption] ([MenuID], [Name], [Controller],[Action], [Order]) VALUES (12, N'损益预算', 'ProfitLoss', N'GroupIndex', 1)

INSERT [dbo].[MenuOption] ([MenuID], [Name], [Controller],[Action], [Order]) VALUES (32, N'角色列表', 'Role', N'Index', 1)

INSERT [dbo].[MenuOption] ([MenuID], [Name], [Controller],[Action], [Order]) VALUES (33, N'人员管理', 'GroupAccount', N'Index', 1)

INSERT [dbo].[MenuOption] ([MenuID], [Name], [Controller],[Action], [Order]) VALUES (34, N'预算系数管理', 'Coefficient', N'Index', 1)

--公司
INSERT [dbo].[MenuOption] ([MenuID], [Name], [Controller],[Action], [Order]) VALUES (102, N'损益预算', 'ProfitLoss', N'Index', 1)

/****** Object:  Table [dbo].[Role]    Script Date: 12/05/2014 13:04:55 ******/
SET IDENTITY_INSERT [dbo].[Role] ON
INSERT [dbo].[Role] ([ID], [AccountType], [RoleName]) VALUES (1, 0, N'录入')
INSERT [dbo].[Role] ([ID], [AccountType], [RoleName]) VALUES (2, 0, N'审核')
SET IDENTITY_INSERT [dbo].[Role] OFF


INSERT [dbo].[RoleMenu] ([MenuID], [RoleID]) VALUES (101, 1)
INSERT [dbo].[RoleMenu] ([MenuID], [RoleID]) VALUES (102, 1)
INSERT [dbo].[RoleMenu] ([MenuID], [RoleID]) VALUES (111, 1)
INSERT [dbo].[RoleMenu] ([MenuID], [RoleID]) VALUES (113, 1)
INSERT [dbo].[RoleMenu] ([MenuID], [RoleID]) VALUES (112, 1)
INSERT [dbo].[RoleMenu] ([MenuID], [RoleID]) VALUES (11, 2)
INSERT [dbo].[RoleMenu] ([MenuID], [RoleID]) VALUES (12, 2)
INSERT [dbo].[RoleMenu] ([MenuID], [RoleID]) VALUES (21, 2)
INSERT [dbo].[RoleMenu] ([MenuID], [RoleID]) VALUES (23, 2)
INSERT [dbo].[RoleMenu] ([MenuID], [RoleID]) VALUES (22, 2)


/****** Object:  Table [dbo].[Group]    Script Date: 11/27/2014 14:40:46 ******/
SET IDENTITY_INSERT [dbo].[Group] ON
INSERT [dbo].[Group] ([ID], [Name]) VALUES (1, N'华夏汽车集团')
SET IDENTITY_INSERT [dbo].[Group] OFF


/****** Object:  Table [dbo].[GroupAccount]    Script Date: 11/27/2014 14:40:46 ******/
SET IDENTITY_INSERT [dbo].[GroupAccount] ON
INSERT [dbo].[GroupAccount] ([ID], [GroupID], [AccountNumber], [AccountPwd], [Name], [Phone], [Email]) VALUES (1, 1, N'huaxia', N'm8YlpCH5g1U=', N'华夏', N'huaxia', N'huaxia')
SET IDENTITY_INSERT [dbo].[GroupAccount] OFF


/****** Object:  Table [dbo].[Company]    Script Date: 11/27/2014 14:40:46 ******/
SET IDENTITY_INSERT [dbo].[Company] ON
INSERT [dbo].[Company] ([ID], [GroupID], [Name]) VALUES (1, 1, N'福特')
INSERT [dbo].[Company] ([ID], [GroupID], [Name]) VALUES (2, 1, N'雪佛兰')
SET IDENTITY_INSERT [dbo].[Company] OFF


/****** Object:  Table [dbo].[CompanyAccount]    Script Date: 11/27/2014 14:40:46 ******/
SET IDENTITY_INSERT [dbo].[CompanyAccount] ON
INSERT [dbo].[CompanyAccount] ([ID], [CompanyID], [AccountNumber], [AccountPwd], [Name], [Phone], [Email]) VALUES (1, 1, N'fute', N'm8YlpCH5g1U=', N'福特', N'fute', N'fute')
INSERT [dbo].[CompanyAccount] ([ID], [CompanyID], [AccountNumber], [AccountPwd], [Name], [Phone], [Email]) VALUES (2, 2, N'xuefulan', N'm8YlpCH5g1U=', N'雪佛兰', N'xuefulan', N'xuefulan')
SET IDENTITY_INSERT [dbo].[CompanyAccount] OFF

/******----------------------------******/
SET IDENTITY_INSERT [dbo].[ParticularYear] ON
INSERT [dbo].[ParticularYear] ([ID], [Year]) VALUES (1, 2015)
SET IDENTITY_INSERT [dbo].[ParticularYear] OFF


/******----------------------------******/
SET IDENTITY_INSERT [dbo].[BudgetClass] ON
INSERT [dbo].[BudgetClass] ([ID], [Name],[CoefficientURL]) VALUES (1, '损益预算','/Coefficient/ProfitLoss_Coefficient')
SET IDENTITY_INSERT [dbo].[BudgetClass] OFF


/******----------------------------******/
SET IDENTITY_INSERT [dbo].[ProfitLoss_Coefficient] ON
INSERT [dbo].[ProfitLoss_Coefficient] ([ID], [CompanyID],[FenQiShuLiang],[XinBaoShuLiang],[XuBaoShuLiang],[GuaPaiShuLiang],[ErShouCheXiaoShouShuLiang],[ZhuYingShouRu_ZhengChe]
,[ZhuYingShouRu_ZhuangShiZhuangHuang],[ZhuYingShouRu_FenQi],[ZhuYingShouRu_XinBao],[ZhuYingShouRu_XuBao],[ZhuYingShouRu_GuaPai],[ZhuYingShouRu_ErShouChe],[ZhuYingChengBen_ZhengChe]
,[ZhuYingChengBen_WeiXiuPeiJian],[ZhuYingChengBen_ZhuangShiZhuangHuang]) VALUES (1, 1,0.16,0.88,0.3,0.35,0.01,10,0.025,0.33,0.068,0.058,0.085,0.1,0.986,0.8,0.6)
INSERT [dbo].[ProfitLoss_Coefficient] ([ID], [CompanyID],[FenQiShuLiang],[XinBaoShuLiang],[XuBaoShuLiang],[GuaPaiShuLiang],[ErShouCheXiaoShouShuLiang],[ZhuYingShouRu_ZhengChe]
,[ZhuYingShouRu_ZhuangShiZhuangHuang],[ZhuYingShouRu_FenQi],[ZhuYingShouRu_XinBao],[ZhuYingShouRu_XuBao],[ZhuYingShouRu_GuaPai],[ZhuYingShouRu_ErShouChe],[ZhuYingChengBen_ZhengChe]
,[ZhuYingChengBen_WeiXiuPeiJian],[ZhuYingChengBen_ZhuangShiZhuangHuang]) VALUES (2, 2,0.16,0.88,0.3,0.35,0.01,10,0.025,0.33,0.068,0.058,0.085,0.1,0.986,0.8,0.6)
SET IDENTITY_INSERT [dbo].[ProfitLoss_Coefficient] OFF
