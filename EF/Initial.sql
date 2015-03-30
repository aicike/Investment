/****** Object:  Table [dbo].[Menu]    Script Date: 11/27/2014 11:31:19 ******/
SET IDENTITY_INSERT [dbo].[Menu] ON

--集团
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (11, NULL, 'Home', 'Home', N'客户管理', N'客户管理', 1, NULL,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (1101, NULL, 'Company', 'Index', N'客户信息', N'客户信息', 1, 11,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (1102, NULL, 'Financing', 'Index', N'贷款信息列表', N'贷款信息列表', 2, 11,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (1103, NULL, 'Financing', 'IndexALL', N'贷款信息列表（全）', N'贷款信息列表（全）', 3, 11,0)

INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (21, NULL, 'Home', 'Home', N'机构管理', N'机构管理', 2, NULL,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (2101, NULL, 'Mechanism', 'Index', N'机构信息', N'机构信息', 1, 21,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType,IsShow) VALUES (210101, NULL, 'MechanismProducts', 'Index', N'机构产品列表', N'机构产品列表', 1, 2101,0,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType,IsShow) VALUES (210102, NULL, 'MechanismProducts', 'Add', N'机构产品添加', N'机构产品添加', 2, 2101,0,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType,IsShow) VALUES (210103, NULL, 'MechanismProducts', 'Edit', N'机构产品修改', N'机构产品修改', 3, 2101,0,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (2102, NULL, 'MechanismProducts', 'SelAll', N'机构产品列表', N'机构产品列表', 2, 21,0)

INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (31, NULL, 'ToLoanMatching', 'IndexAll', N'借贷匹配', N'借贷匹配', 3, NULL,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType,IsShow) VALUES (310101, NULL, 'WorkFlowApproval', 'Preview', N'待定业务预览', N'待定业务预览', 1, 31,0,0)

INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (41, NULL, 'Home', 'Home', N'项目管理', N'项目管理', 4, NULL,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (4101, NULL, 'WorkFlow', 'Pending', N'待定业务', N'待定业务', 1, 41,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType,IsShow) VALUES (410101, NULL, 'WorkFlowApproval', 'Pending', N'待定业务表单', N'待定业务表单', 1, 4101,0,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (4102, NULL, 'WorkFlow', 'MyApplication', N'我的申请', N'我的申请', 2, 41,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (4103, NULL, 'WorkFlow', 'Backlog', N'我的待办', N'我的待办', 3, 41,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType,IsShow) VALUES (410301, NULL, 'WorkLog', 'Index', N'工作日志', N'工作日志', 1, 4103,0,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (4104, NULL, 'WorkFlow', 'History', N'我的已办', N'我的已办', 4, 41,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (4105, NULL, 'WorkFlow', 'Assist', N'辅助项目', N'辅助项目', 5, 41,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (4106, NULL, 'WorkFlow', 'List', N'项目列表', N'项目列表', 6, 41,0)

INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (71, NULL, 'WorkLog', 'Index', N'日志管理', N'日志管理', 5, NULL,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (7101, NULL, 'WorkLog', 'MyWorkLog', N'我的日志', N'我的日志', 1, 71,0)
--INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (7102, NULL, 'Index', 'WorkLog', N'日志管理', N'日志管理', 2, 71,0)

INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (51, NULL, 'GroupProfile', 'ProFile', N'账号管理', N'账号管理', 6, NULL,0)

INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (61, NULL, 'Home', 'Home', N'系统管理', N'系统管理', 7, NULL,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (6101, NULL, 'Role', 'Index', N'角色管理', N'角色管理', 1, 61,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (6102, NULL, 'Position', 'Index', N'职位管理', N'职位管理', 2, 61,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (6103, NULL, 'GroupAccount', 'Index', N'人员管理', N'人员管理', 3, 61,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (6104, NULL, 'WorkFlowManager', 'Index', N'流程配置', N'流程配置', 4, 61,0)


SET IDENTITY_INSERT [dbo].[Menu] OFF

/****** Object:  Table [dbo].[MenuOption]    Script Date: 12/05/2014 12:46:05 ******/
--客户、贷款信息管理
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 1101 ,N'新增客户' , N'Company' , N'Add' , 1)
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 1101 ,N'详细' , N'Company' , N'Detail' , 2)
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 1101 ,N'修改' , N'Company' , N'Edit' , 3)
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 1101 ,N'删除' , N'Company' , N'Delete' , 4)
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 1101 ,N'贷款信息列表' , N'Company' , N'Financing' , 5)
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 1101 ,N'新增贷款信息' , N'Company' , N'AddFinancing' , 6)
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 1101 ,N'查看贷款信息' , N'Financing' , N'Detail' , 7)
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 1101 ,N'修改贷款信息' , N'Company' , N'EditFinancing' , 8)
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 1101 ,N'删除贷款信息' , N'Company' , N'DeleteFinancing' , 9)
--查看贷款详细
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 1102 ,N'详细' , N'Financing' , N'Detail' , 1)
--查看贷款详细
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 1103 ,N'详细' , N'Financing' , N'Detail' , 1)
--机构、产品管理
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 2101 ,N'添加' , N'Mechanism' , N'Add' , 1)
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 2101 ,N'修改' , N'Mechanism' , N'Edit' , 2)
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 2102 ,N'机构产品列表' , N'MechanismProducts' , N'Index' , 3)
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 2102 ,N'新增机构产品' , N'MechanismProducts' , N'Add' , 4)
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 2102 ,N'修改机构产品' , N'MechanismProducts' , N'Edit' , 5)
--项目管理

--角色管理
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 6101 ,N'新增' , N'Role' , N'Add' , 1)
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 6101 ,N'修改' , N'Role' , N'Edit' , 2)
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 6101 ,N'删除' , N'Role' , N'Delete' ,3)
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 6101 ,N'分配权限' , N'Role' , N'RoleMenu' , 4)

--职位管理
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 6102 ,N'新增' , N'Role' , N'Add' , 1)
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 6102 ,N'修改' , N'Role' , N'Edit' , 2)
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 6102 ,N'删除' , N'Role' , N'Delete' ,3)

--人员管理
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 6103 ,N'新增' , N'GroupAccount' , N'Add' , 1)
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 6103 ,N'修改' , N'GroupAccount' , N'Edit' , 2)

--------------------------------------------------------------------------角色数据，角色分配的权限数据-------------------------------------------------------------------
/****** Object:  Table [dbo].[Role]    Script Date: 03/30/2015 09:51:17 ******/
SET IDENTITY_INSERT [dbo].[Role] ON
INSERT [dbo].[Role] ([ID], [AccountType], [RoleName]) VALUES (1, 0, N'系统管理员')
INSERT [dbo].[Role] ([ID], [AccountType], [RoleName]) VALUES (4, 0, N'机构维护')
INSERT [dbo].[Role] ([ID], [AccountType], [RoleName]) VALUES (5, 0, N'人员维护')
INSERT [dbo].[Role] ([ID], [AccountType], [RoleName]) VALUES (6, 0, N'职位维护')
INSERT [dbo].[Role] ([ID], [AccountType], [RoleName]) VALUES (10, 0, N'系统维护人员')
INSERT [dbo].[Role] ([ID], [AccountType], [RoleName]) VALUES (12, 0, N'客户管理')
INSERT [dbo].[Role] ([ID], [AccountType], [RoleName]) VALUES (13, 0, N'客户分配')
INSERT [dbo].[Role] ([ID], [AccountType], [RoleName]) VALUES (14, 0, N'业务人员')
INSERT [dbo].[Role] ([ID], [AccountType], [RoleName]) VALUES (15, 0, N'借贷匹配')
INSERT [dbo].[Role] ([ID], [AccountType], [RoleName]) VALUES (16, 0, N'审批人员')
INSERT [dbo].[Role] ([ID], [AccountType], [RoleName]) VALUES (17, 0, N'删除客户')
INSERT [dbo].[Role] ([ID], [AccountType], [RoleName]) VALUES (18, 0, N'基本操作')
INSERT [dbo].[Role] ([ID], [AccountType], [RoleName]) VALUES (19, 0, N'日志填写')
SET IDENTITY_INSERT [dbo].[Role] OFF
/****** Object:  Table [dbo].[RoleMenu]    Script Date: 03/30/2015 09:51:17 ******/
SET IDENTITY_INSERT [dbo].[RoleMenu] ON
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (55, 51, 10)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (56, 61, 10)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (57, 6101, 10)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (58, 6102, 10)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (59, 6103, 10)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (60, 6104, 10)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (112, 11, 13)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (113, 1103, 13)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (123, 11, 12)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (124, 1101, 12)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (125, 1102, 12)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (126, 61, 5)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (127, 6103, 5)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (128, 21, 4)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (129, 2101, 4)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (130, 2102, 4)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (144, 31, 15)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (145, 61, 6)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (146, 6102, 6)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (147, 41, 16)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (148, 4103, 16)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (149, 4104, 16)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (150, 1101, 17)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (151, 51, 18)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (175, 11, 14)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (176, 1101, 14)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (177, 1102, 14)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (178, 41, 14)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (179, 4101, 14)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (180, 4102, 14)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (181, 4103, 14)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (182, 4104, 14)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (183, 4105, 14)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (184, 4106, 14)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (185, 51, 14)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (186, 71, 19)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (187, 7101, 19)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (188, 11, 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (189, 1101, 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (190, 1102, 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (191, 1103, 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (192, 21, 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (193, 2101, 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (194, 2102, 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (195, 31, 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (196, 41, 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (197, 4101, 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (198, 4102, 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (199, 4103, 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (200, 4104, 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (201, 4105, 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (202, 4106, 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (203, 51, 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (204, 61, 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (205, 6101, 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (206, 6102, 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (207, 6103, 1)
INSERT [dbo].[RoleMenu] ([ID], [MenuID], [RoleID]) VALUES (208, 6104, 1)
SET IDENTITY_INSERT [dbo].[RoleMenu] OFF
/****** Object:  Table [dbo].[RoleOption]    Script Date: 03/30/2015 09:51:17 ******/
SET IDENTITY_INSERT [dbo].[RoleOption] ON
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (73, 10, 17)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (74, 10, 18)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (75, 10, 19)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (76, 10, 20)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (77, 10, 21)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (78, 10, 22)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (79, 10, 23)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (80, 10, 24)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (81, 10, 25)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (152, 13, 11)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (154, 12, 1)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (155, 12, 2)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (156, 12, 3)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (157, 12, 5)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (158, 12, 6)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (159, 12, 7)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (160, 12, 8)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (161, 12, 10)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (162, 5, 24)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (163, 5, 25)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (164, 4, 12)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (165, 4, 13)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (166, 4, 14)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (167, 4, 15)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (168, 4, 16)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (177, 6, 21)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (178, 6, 22)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (179, 17, 4)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (180, 17, 9)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (206, 14, 1)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (207, 14, 2)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (208, 14, 3)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (209, 14, 5)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (210, 14, 6)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (211, 14, 7)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (212, 14, 8)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (213, 14, 10)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (214, 1, 1)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (215, 1, 2)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (216, 1, 3)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (217, 1, 4)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (218, 1, 5)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (219, 1, 6)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (220, 1, 7)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (221, 1, 8)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (222, 1, 9)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (223, 1, 10)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (224, 1, 11)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (225, 1, 12)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (226, 1, 13)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (227, 1, 14)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (228, 1, 15)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (229, 1, 16)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (230, 1, 17)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (231, 1, 18)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (232, 1, 19)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (233, 1, 20)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (234, 1, 21)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (235, 1, 22)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (236, 1, 23)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (237, 1, 24)
INSERT [dbo].[RoleOption] ([ID], [RoleID], [MenuOptionID]) VALUES (238, 1, 25)
SET IDENTITY_INSERT [dbo].[RoleOption] OFF
--------------------------------------------------------------------------角色数据，角色分配的权限数据-------------------------------------------------------------------






--行业分类
SET IDENTITY_INSERT [dbo].[Industry] ON
INSERT INTO dbo.Industry (ID, Name) VALUES ( 1, N'农、林、牧、渔业')
INSERT INTO dbo.Industry (ID, Name) VALUES ( 2, N'工业')
INSERT INTO dbo.Industry (ID, Name) VALUES ( 3, N'建筑业')
INSERT INTO dbo.Industry (ID, Name) VALUES ( 4, N'批发业')
INSERT INTO dbo.Industry (ID, Name) VALUES ( 5, N'零售业')
INSERT INTO dbo.Industry (ID, Name) VALUES ( 6, N'交通运输业')
INSERT INTO dbo.Industry (ID, Name) VALUES ( 7, N'仓储业')
INSERT INTO dbo.Industry (ID, Name) VALUES ( 8, N'邮政业')
INSERT INTO dbo.Industry (ID, Name) VALUES ( 9, N'住宿业')
INSERT INTO dbo.Industry (ID, Name) VALUES ( 10, N'餐饮业')
INSERT INTO dbo.Industry (ID, Name) VALUES ( 11, N'信息传输业')
INSERT INTO dbo.Industry (ID, Name) VALUES ( 12, N'软件和信息技术服务业')
INSERT INTO dbo.Industry (ID, Name) VALUES ( 13, N'房地产开发经营')
INSERT INTO dbo.Industry (ID, Name) VALUES ( 14, N'物业管理')
INSERT INTO dbo.Industry (ID, Name) VALUES ( 15, N'租赁和商务服务业')
INSERT INTO dbo.Industry (ID, Name) VALUES ( 16, N'其他未列明行业')
SET IDENTITY_INSERT [dbo].[Industry] OFF

--行业级别
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 0 ,0,NULL ,NULL,1)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 1 ,50,NULL ,NULL,1)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 2 ,500,NULL ,NULL,1)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 3 ,20000,NULL ,NULL,1)

INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 0 ,0,NULL ,0,2)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 1 ,300,NULL ,20,2)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 2 ,2000,NULL ,300,2)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 3 ,40000,NULL ,1000,2)

INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 0 ,0,0 ,NULL,3)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 1 ,300,300 ,NULL,3)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 2 ,6000,5000 ,NULL,3)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 3 ,80000,80000 ,NULL,3)

INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 0 ,0,NULL ,0,4)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 1 ,1000,NULL ,5,4)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 2 ,5000,NULL ,20,4)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 3 ,40000,NULL ,200,4)

INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 0 ,0,NULL ,0,5)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 1 ,100,NULL ,10,5)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 2 ,500,NULL ,50,5)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 3 ,20000,NULL ,300,5)

INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 0 ,0,NULL ,0,6)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 1 ,200,NULL ,20,6)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 2 ,3000,NULL ,300,6)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 3 ,30000,NULL ,1000,6)

INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 0 ,0,NULL ,0,7)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 1 ,100,NULL ,20,7)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 2 ,1000,NULL ,100,7)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 3 ,3000,NULL ,200,7)

INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 0 ,0,NULL ,0,8)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 1 ,300,NULL ,20,8)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 2 ,2000,NULL ,300,8)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 3 ,30000,NULL ,1000,8)

INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 0 ,0,NULL ,0,9)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 1 ,100,NULL ,10,9)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 2 ,2000,NULL ,100,9)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 3 ,10000,NULL ,300,9)

INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 0 ,0,NULL ,0,10)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 1 ,100,NULL ,10,10)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 2 ,2000,NULL ,100,10)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 3 ,10000,NULL ,300,10)

INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 0 ,0,NULL ,0,11)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 1 ,100,NULL ,10,11)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 2 ,1000,NULL ,100,11)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 3 ,100000,NULL ,2000,11)

INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 0 ,0,NULL ,0,12)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 1 ,50,NULL ,10,12)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 2 ,1000,NULL ,100,12)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 3 ,10000,NULL ,300,12)

INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 0 ,0,0 ,NULL,13)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 1 ,100,2000 ,NULL,13)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 2 ,1000,5000 ,NULL,13)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 3 ,20000,10000 ,NULL,13)

INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 0 ,0,NULL ,0,14)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 1 ,500,NULL ,100,14)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 2 ,1000,NULL ,300,14)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 3 ,5000,NULL ,1000,14)

INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 0 ,0,NULL ,0,15)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 1 ,100,NULL ,10,15)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 2 ,8000,NULL ,100,15)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 3 ,12000,NULL ,300,15)

INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 0 ,NULL,NULL ,0,16)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 1 ,NULL,NULL ,10,16)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 2 ,NULL,NULL ,100,16)
INSERT INTO dbo.IndustryLevel( Level ,YingYeShouRu , ZongZiChan , ChongYeRenYuan ,IndustryID)VALUES  ( 3 ,NULL,NULL ,300,16)

/****** Object:  Table [dbo].[Role]    Script Date: 12/05/2014 13:04:55 ******/



/****** Object:  Table [dbo].[Group]    Script Date: 11/27/2014 14:40:46 ******/
SET IDENTITY_INSERT [dbo].[Group] ON
INSERT [dbo].[Group] ([ID], [Name]) VALUES (1, N'兆恒投资')
SET IDENTITY_INSERT [dbo].[Group] OFF


/****** Object:  Table [dbo].[GroupAccount]    Script Date: 11/27/2014 14:40:46 ******/
SET IDENTITY_INSERT [dbo].[GroupAccount] ON
INSERT [dbo].[GroupAccount] ([ID], [GroupID], [AccountNumber], [AccountPwd], [Name], [Phone], [Email]) VALUES (1, 1, N'admin', N'8ZjHBEPwxeqwCrxssgd2cQ==', N'zhaoheng', N'zhaoheng', N'zhaoheng')
SET IDENTITY_INSERT [dbo].[GroupAccount] OFF

/***流程分类***/
SET IDENTITY_INSERT [dbo].[WorkFlowManager] ON
INSERT [dbo].[WorkFlowManager] ([ID], [Name], [IsEnable]) VALUES (1, '大型企业或另类贷款顾问业务','True')
INSERT [dbo].[WorkFlowManager] ([ID], [Name], [IsEnable]) VALUES (2, '中小企业贷款顾问业务','True')
INSERT [dbo].[WorkFlowManager] ([ID], [Name], [IsEnable]) VALUES (3, '小微企业贷款顾问业务','True')
INSERT [dbo].[WorkFlowManager] ([ID], [Name], [IsEnable]) VALUES (4, '自有资金业务','True')
SET IDENTITY_INSERT [dbo].[WorkFlowManager] OFF


/***流程节点***/
SET IDENTITY_INSERT [dbo].[WorkFlowNodeManager] ON
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[Controllers],[Action]) VALUES (1, '业务初审','无','WorkFlowApproval','RongZiLiXiangChuShen')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[Controllers],[Action]) VALUES (2, '项目立项','无','WorkFlowApproval','XiangMuLiXiang')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[Controllers],[Action]) VALUES (3, '签署协议','无','WorkFlowApproval','QianShuXieYi')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[Controllers],[Action]) VALUES (4, '协议确认','无','WorkFlowApproval','XieYiQueRen')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[Controllers],[Action]) VALUES (5, '调查辅导','无','WorkFlowApproval','DiaoChaFuDao')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[Controllers],[Action]) VALUES (6, '机构对接','无','WorkFlowApproval','JiGouDuiJie')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[Controllers],[Action]) VALUES (7, '落实放款','无','WorkFlowApproval','LuoShiFangKuan')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[Controllers],[Action]) VALUES (8, '确认收取费用','无','WorkFlowApproval','QueRenShouQuFeiYong')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[Controllers],[Action]) VALUES (9, '提交申请','无','WorkFlowApproval','TiJiaoShenQing')

INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[Controllers],[Action]) VALUES (10, '详尽调查','无','WorkFlowApproval','XiangJinDiaoCha')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[Controllers],[Action]) VALUES (11, '风控审核','无','WorkFlowApproval','FengKongShenHe')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[Controllers],[Action]) VALUES (12, '落实放款条件','无','WorkFlowApproval','LuoShiFangKuanTiaoJian')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[Controllers],[Action]) VALUES (13, '放款审批','无','WorkFlowApproval','FangKuanShenPi')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[Controllers],[Action]) VALUES (14, '放款','无','WorkFlowApproval','FangKuan')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[Controllers],[Action]) VALUES (15, '确认放款日期','无','WorkFlowApproval','FangKuanRiQi')


SET IDENTITY_INSERT [dbo].[WorkFlowNodeManager] OFF
/****** Object:  Table [dbo].[Company]    Script Date: 11/27/2014 14:40:46 ******/


/****** Object:  Table [dbo].[CompanyAccount]    Script Date: 11/27/2014 14:40:46 ******/
/**生成流程单号函数 @prefix 流程前缀 @digit位数 @WorkFlowManagerID流程类别ID**/

GO
Create function GetWorkFlowNumber(@prefix varchar(10),@digit int)
returns varchar(100)
as
begin
	declare @predate varchar(12)= convert(varchar(50),getdate(),112)
	declare @Number varchar(100) = UPPER(@prefix)+@predate

	declare @Prefixcnt int = DATALENGTH(@prefix)
	declare @MaxNumber varchar(100) 
	select @MaxNumber =Max(Number) from dbo.WorkFlow where  Number like '%'+@Number+'%'  
	
	declare @lasNum varchar(50)='0'
	if(@MaxNumber is null)
		begin
			declare @i int = 1
			while @i<@digit
				begin
					if(@i=@digit-1)
						begin
							set @lasNum =@lasNum+'1'
						end
					else
						begin
							set @lasNum =@lasNum+'0'
						end
					
					set @i=@i+1
				end
			set @Number = @Number+@lasNum
		end
	else
		begin
			declare @lastNumber int = replace(@MaxNumber,@Number,'')
			set @lastNumber = @lastNumber+1
			declare @l int = 1
			while @l<(@digit-DATALENGTH(convert(varchar(10),@lastNumber)))
				begin
					set @lasNum ='0'+@lasNum
					set @l=@l+1
				end
			set @Number = @Number+@lasNum+convert(varchar(10),@lastNumber)
		end
	return @Number
end
