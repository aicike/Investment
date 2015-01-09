/****** Object:  Table [dbo].[Menu]    Script Date: 11/27/2014 11:31:19 ******/
SET IDENTITY_INSERT [dbo].[Menu] ON

--集团

INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (11, NULL, 'Home', 'Home', N'客户管理', N'客户管理', 1, NULL,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (1101, NULL, 'Company', 'Index', N'客户管理', N'客户管理', 1, 11,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (1102, NULL, 'Financing', 'Index', N'融资信息列表', N'融资信息列表', 2, 11,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (1103, NULL, 'Financing', 'IndexALL', N'融资信息列表（全）', N'融资信息列表（全）', 3, 11,0)
--INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (14, NULL, 'Home', 'Home', N'客户融资记录', N'客户融资记录', 3, 11,0)

INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (21, NULL, 'Home', 'Home', N'机构管理', N'机构管理', 2, NULL,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (2101, NULL, 'Mechanism', 'Index', N'机构管理', N'机构管理', 1, 21,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (2102, NULL, 'Home', 'Home', N'放贷产品列表', N'放贷产品列表', 2, 21,0)
--INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (24, NULL, 'Home', 'Home', N'机构放贷记录', N'机构放贷记录', 3, 21,0)

INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (31, NULL, 'InfoMatching', 'Index', N'借贷匹配', N'借贷匹配', 3, NULL,0)

INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (41, NULL, 'Home', 'Home', N'项目管理', N'项目管理', 4, NULL,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (4101, NULL, 'Home', 'Home', N'待定业务单', N'待定业务单', 1, 41,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (4102, NULL, 'Home', 'Home', N'我的申请', N'我的申请', 2, 41,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (4103, NULL, 'Home', 'Home', N'立项申请', N'立项申请', 3, 41,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (4104, NULL, 'Home', 'Home', N'项目列表', N'项目列表', 4, 41,0)

INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (51, NULL, 'GroupProfile', 'ProFile', N'账号管理', N'账号管理', 5, NULL,0)

INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (61, NULL, 'Home', 'Home', N'系统管理', N'系统管理', 6, NULL,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (6101, NULL, 'Role', 'Index', N'角色管理', N'角色管理', 1, 61,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (6102, NULL, 'Position', 'Index', N'职位管理', N'职位管理', 2, 61,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (6103, NULL, 'GroupAccount', 'Index', N'人员管理', N'人员管理', 3, 61,0)
INSERT [dbo].[Menu] ([ID], [Area], [Controller], [Action], [Name], [ShowName], [Order], [ParentMenuID],AccountType) VALUES (6104, NULL, 'WorkFlowManager', 'Index', N'流程配置', N'流程配置', 4, 61,0)

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
/**生成流程单号函数 @prefix 流程前缀 @digit位数 @WorkFlowManagerID流程类别ID**/
GO
Create function GetWorkFlowNumber(@prefix varchar(10),@digit int,@WorkFlowManagerID int)
returns varchar(100)
as
begin
	declare @predate varchar(12)= convert(varchar(50),getdate(),112)
	declare @Number varchar(100) = UPPER(@prefix)+@predate

	declare @Prefixcnt int = DATALENGTH(@prefix)
	declare @MaxNumber varchar(100) 
	select @MaxNumber =Max(Number) from dbo.WorkFlow where WorkFlowManagerID= @WorkFlowManagerID and Number like '%'+@Number+'%'  
	
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

GO
