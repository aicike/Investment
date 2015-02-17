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

INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (31, NULL, 'ToLoanMatching', 'Index', N'借贷匹配', N'借贷匹配', 3, NULL,0)
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

INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (51, NULL, 'GroupProfile', 'ProFile', N'账号管理', N'账号管理', 5, NULL,0)

INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (61, NULL, 'Home', 'Home', N'系统管理', N'系统管理', 6, NULL,0)
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
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 2101 ,N'机构产品列表' , N'MechanismProducts' , N'Index' , 3)
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 2101 ,N'新增机构产品' , N'MechanismProducts' , N'Add' , 4)
INSERT INTO dbo.MenuOption(MenuID ,Name ,Controller ,[Action] ,[Order]) VALUES  ( 2101 ,N'修改机构产品' , N'MechanismProducts' , N'Edit' , 5)
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
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[IsSinceApproval],[Controllers],[Action]) VALUES (1, '业务初审','无','False','WorkFlowApproval','RongZiLiXiangChuShen')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[IsSinceApproval],[Controllers],[Action]) VALUES (2, '项目立项','无','False','WorkFlowApproval','XiangMuLiXiang')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[IsSinceApproval],[Controllers],[Action]) VALUES (3, '签署协议','无','True','WorkFlowApproval','QianShuXieYi')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[IsSinceApproval],[Controllers],[Action]) VALUES (4, '协议确认','无','False','WorkFlowApproval','XieYiQueRen')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[IsSinceApproval],[Controllers],[Action]) VALUES (5, '调查辅导','无','True','WorkFlowApproval','DiaoChaFuDao')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[IsSinceApproval],[Controllers],[Action]) VALUES (6, '机构对接','无','True','WorkFlowApproval','JiGouDuiJie')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[IsSinceApproval],[Controllers],[Action]) VALUES (7, '落实放款','无','False','WorkFlowApproval','LuoShiFangKuan')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[IsSinceApproval],[Controllers],[Action]) VALUES (8, '确认收取费用','无','False','WorkFlowApproval','QueRenShouQuFeiYong')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[IsSinceApproval],[Controllers],[Action]) VALUES (9, '提交申请','无','True','WorkFlowApproval','TiJiaoShenQing')

INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[IsSinceApproval],[Controllers],[Action]) VALUES (10, '详尽调查','无','True','WorkFlowApproval','XiangJinDiaoCha')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[IsSinceApproval],[Controllers],[Action]) VALUES (11, '风控审核','无','False','WorkFlowApproval','FengKongShenHe')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[IsSinceApproval],[Controllers],[Action]) VALUES (12, '落实放款条件','无','False','WorkFlowApproval','LuoShiFangKuanTiaoJian')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[IsSinceApproval],[Controllers],[Action]) VALUES (13, '放款审批','无','False','WorkFlowApproval','FangKuanShenPi')
INSERT [dbo].[WorkFlowNodeManager] ([ID], [Name], [Remark],[IsSinceApproval],[Controllers],[Action]) VALUES (14, '放款','无','False','WorkFlowApproval','FangKuan')




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
