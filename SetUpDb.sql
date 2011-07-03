-- 创建数据库
CREATE DATABASE [HW_PAS]
GO

USE [HW_PAS]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON

-- 创建用于保存工作流的持久性数据库
-- 拷贝自%WINDIR%\Microsoft.NET\Framework\v4.xxx\SQL\EN\SqlWorkflowInstanceStoreSchema.sql
if not exists( select 1 from [dbo].[sysusers] where name=N'System.Activities.DurableInstancing.InstanceStoreUsers' and issqlrole=1 )
	create role [System.Activities.DurableInstancing.InstanceStoreUsers]
go

if not exists( select 1 from [dbo].[sysusers] where name=N'System.Activities.DurableInstancing.WorkflowActivationUsers' and issqlrole=1 )
	create role [System.Activities.DurableInstancing.WorkflowActivationUsers]
go

if not exists( select 1 from [dbo].[sysusers] where name=N'System.Activities.DurableInstancing.InstanceStoreObservers' and issqlrole=1 )
	create role [System.Activities.DurableInstancing.InstanceStoreObservers]
go

if not exists (select * from sys.schemas where name = N'System.Activities.DurableInstancing')
	exec ('create schema [System.Activities.DurableInstancing]')
go

if exists (select * from sys.views where object_id = object_id(N'[System.Activities.DurableInstancing].[InstancePromotedProperties]'))
      drop view [System.Activities.DurableInstancing].[InstancePromotedProperties]
go

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[InstancesTable]') and type in (N'U'))
	drop table [System.Activities.DurableInstancing].[InstancesTable]
go

create table [System.Activities.DurableInstancing].[InstancesTable]
(
	[Id] uniqueidentifier not null,
	[SurrogateInstanceId] bigint identity not null,
	[SurrogateLockOwnerId] bigint null,
	[PrimitiveDataProperties] varbinary(max) default null,
	[ComplexDataProperties] varbinary(max) default null,
	[WriteOnlyPrimitiveDataProperties] varbinary(max) default null,
	[WriteOnlyComplexDataProperties] varbinary(max) default null,
	[MetadataProperties] varbinary(max) default null,
	[DataEncodingOption] tinyint default 0,
	[MetadataEncodingOption] tinyint default 0,
	[Version] bigint not null,
	[PendingTimer] datetime null,
	[CreationTime] datetime not null,
	[LastUpdated] datetime default null,
	[WorkflowHostType] uniqueidentifier null,
	[ServiceDeploymentId] bigint null,
	[SuspensionExceptionName] nvarchar(450) default null,
	[SuspensionReason] nvarchar(max) default null,
	[BlockingBookmarks] nvarchar(max) default null,
	[LastMachineRunOn] nvarchar(450) default null,
	[ExecutionStatus] nvarchar(450) default null,
	[IsInitialized] bit default 0,
	[IsSuspended] bit default 0,
	[IsReadyToRun] bit default 0,
	[IsCompleted] bit default 0
)
go

create unique clustered index [CIX_InstancesTable]
	on [System.Activities.DurableInstancing].[InstancesTable] ([SurrogateInstanceId])
	with (allow_page_locks = off)
go

create unique nonclustered index [NCIX_InstancesTable_Id]
	on [System.Activities.DurableInstancing].[InstancesTable] ([Id])
	include ([Version], [SurrogateLockOwnerId], [IsCompleted])
	with (allow_page_locks = off)
go

create nonclustered index [NCIX_InstancesTable_SurrogateLockOwnerId]
	on [System.Activities.DurableInstancing].[InstancesTable] ([SurrogateLockOwnerId])
	with (allow_page_locks = off)
go

create nonclustered index NCIX_InstancesTable_LastUpdated
	on [System.Activities.DurableInstancing].[InstancesTable] ([LastUpdated])
	with (allow_page_locks = off)
go

create nonclustered index [NCIX_InstancesTable_CreationTime]
	on [System.Activities.DurableInstancing].[InstancesTable] ([CreationTime])
	with (allow_page_locks = off)
go

create nonclustered index [NCIX_InstancesTable_SuspensionExceptionName]
	on [System.Activities.DurableInstancing].[InstancesTable] ([SuspensionExceptionName])
	with (allow_page_locks = off)
go

create nonclustered index [NCIX_InstancesTable_ServiceDeploymentId]
	on [System.Activities.DurableInstancing].[InstancesTable] ([ServiceDeploymentId])
	with (allow_page_locks = off)
go

create nonclustered index [NCIX_InstancesTable_WorkflowHostType]
	on [System.Activities.DurableInstancing].[InstancesTable] ([WorkflowHostType])
	with (allow_page_locks = off)
go

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[RunnableInstancesTable]') and type in (N'U'))
	drop table [System.Activities.DurableInstancing].[RunnableInstancesTable]
go

create table [System.Activities.DurableInstancing].[RunnableInstancesTable]
(
	[SurrogateInstanceId] bigint not null,		
	[WorkflowHostType] uniqueidentifier null,
	[ServiceDeploymentId] bigint null,
	[RunnableTime] datetime not null
)
go

create unique clustered index [CIX_RunnableInstancesTable_SurrogateInstanceId]
	on [System.Activities.DurableInstancing].[RunnableInstancesTable] ([SurrogateInstanceId])
	with (ignore_dup_key = on, allow_page_locks = off)
go

create nonclustered index [NCIX_RunnableInstancesTable]
	on [System.Activities.DurableInstancing].[RunnableInstancesTable] ([WorkflowHostType], [RunnableTime])
	with (allow_page_locks = off)
go

create nonclustered index [NCIX_RunnableInstancesTable_RunnableTime]
	on [System.Activities.DurableInstancing].[RunnableInstancesTable] ([RunnableTime]) include ([WorkflowHostType], [ServiceDeploymentId])
	with (allow_page_locks = off)
go

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[KeysTable]') and type in (N'U'))
	drop table [System.Activities.DurableInstancing].[KeysTable]
go

create table [System.Activities.DurableInstancing].[KeysTable]
(
	[Id] uniqueidentifier not null,
	[SurrogateKeyId] bigint identity not null,
	[SurrogateInstanceId] bigint null,
	[EncodingOption] tinyint null,
	[Properties] varbinary(max) null,
	[IsAssociated] bit
) 
go

create unique clustered index [CIX_KeysTable]
	on [System.Activities.DurableInstancing].[KeysTable] ([Id])	
	with (ignore_dup_key = on, allow_page_locks = off)
go

create nonclustered index [NCIX_KeysTable_SurrogateInstanceId]
	on [System.Activities.DurableInstancing].[KeysTable] ([SurrogateInstanceId])
	with (allow_page_locks = off)
go

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[LockOwnersTable]') and type in (N'U'))
	drop table [System.Activities.DurableInstancing].[LockOwnersTable]
go

create table [System.Activities.DurableInstancing].[LockOwnersTable]
(
	[Id] uniqueidentifier not null,
	[SurrogateLockOwnerId] bigint identity not null,
	[LockExpiration] datetime not null,
	[WorkflowHostType] uniqueidentifier null,
	[MachineName] nvarchar(128) not null,
	[EnqueueCommand] bit not null,
	[DeletesInstanceOnCompletion] bit not null,
	[PrimitiveLockOwnerData] varbinary(max) default null,
	[ComplexLockOwnerData] varbinary(max) default null,
	[WriteOnlyPrimitiveLockOwnerData] varbinary(max) default null,
	[WriteOnlyComplexLockOwnerData] varbinary(max) default null,
	[EncodingOption] tinyint default 0
)
go

create unique clustered index [CIX_LockOwnersTable]
	on [System.Activities.DurableInstancing].[LockOwnersTable] ([SurrogateLockOwnerId])
	with (allow_page_locks = off)
go

create unique nonclustered index [NCIX_LockOwnersTable_Id]
	on [System.Activities.DurableInstancing].[LockOwnersTable] ([Id])
	with (ignore_dup_key = on, allow_page_locks = off)

create nonclustered index [NCIX_LockOwnersTable_LockExpiration]
	on [System.Activities.DurableInstancing].[LockOwnersTable] ([LockExpiration]) include ([WorkflowHostType], [MachineName])
	with (allow_page_locks = off)
go

create nonclustered index [NCIX_LockOwnersTable_WorkflowHostType]
	on [System.Activities.DurableInstancing].[LockOwnersTable] ([WorkflowHostType])
	with (allow_page_locks = off)
go

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[InstanceMetadataChangesTable]') and type in (N'U'))
	drop table [System.Activities.DurableInstancing].[InstanceMetadataChangesTable]
go

create table [System.Activities.DurableInstancing].[InstanceMetadataChangesTable]
(
	[SurrogateInstanceId] bigint not null,
	[ChangeTime] bigint identity,
	[EncodingOption] tinyint not null,
	[Change] varbinary(max) not null
)
go

create unique clustered index [CIX_InstanceMetadataChangesTable]
	on [System.Activities.DurableInstancing].[InstanceMetadataChangesTable] ([SurrogateInstanceId], [ChangeTime])
go

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[ServiceDeploymentsTable]') and type in (N'U'))
	drop table [System.Activities.DurableInstancing].[ServiceDeploymentsTable]
go

create table [System.Activities.DurableInstancing].[ServiceDeploymentsTable]
(
	[Id] bigint identity not null,
	[ServiceDeploymentHash] uniqueidentifier not null,
	[SiteName] nvarchar(max) not null,
	[RelativeServicePath] nvarchar(max) not null,
	[RelativeApplicationPath] nvarchar(max) not null,
	[ServiceName] nvarchar(max) not null,
	[ServiceNamespace] nvarchar(max) not null,
)
go

create unique clustered index [CIX_ServiceDeploymentsTable]
	on [System.Activities.DurableInstancing].[ServiceDeploymentsTable] ([Id])
	with (allow_page_locks = off)
go

create unique nonclustered index [NCIX_ServiceDeploymentsTable_ServiceDeploymentHash]
	on [System.Activities.DurableInstancing].[ServiceDeploymentsTable] ([ServiceDeploymentHash])
	with (ignore_dup_key = on, allow_page_locks = off)
go

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[InstancePromotedPropertiesTable]') and type in (N'U'))
	drop table [System.Activities.DurableInstancing].[InstancePromotedPropertiesTable]
go

create table [System.Activities.DurableInstancing].[InstancePromotedPropertiesTable]
(
	  [SurrogateInstanceId] bigint not null,
      [PromotionName] nvarchar(400) not null,
      [Value1] sql_variant null,
      [Value2] sql_variant null,
      [Value3] sql_variant null,
      [Value4] sql_variant null,
      [Value5] sql_variant null,
      [Value6] sql_variant null,
      [Value7] sql_variant null,
      [Value8] sql_variant null,
      [Value9] sql_variant null,
      [Value10] sql_variant null,
      [Value11] sql_variant null,
      [Value12] sql_variant null,
      [Value13] sql_variant null,
      [Value14] sql_variant null,
      [Value15] sql_variant null,
      [Value16] sql_variant null,
      [Value17] sql_variant null,
      [Value18] sql_variant null,
      [Value19] sql_variant null,
      [Value20] sql_variant null,
      [Value21] sql_variant null,
      [Value22] sql_variant null,
      [Value23] sql_variant null,
      [Value24] sql_variant null,
      [Value25] sql_variant null,
      [Value26] sql_variant null,
      [Value27] sql_variant null,
      [Value28] sql_variant null,
      [Value29] sql_variant null,
      [Value30] sql_variant null,
      [Value31] sql_variant null,
      [Value32] sql_variant null,
      [Value33] varbinary(max) null,
      [Value34] varbinary(max) null,
      [Value35] varbinary(max) null,
      [Value36] varbinary(max) null,
      [Value37] varbinary(max) null,
      [Value38] varbinary(max) null,
      [Value39] varbinary(max) null,
      [Value40] varbinary(max) null,
      [Value41] varbinary(max) null,
      [Value42] varbinary(max) null,
      [Value43] varbinary(max) null,
      [Value44] varbinary(max) null,
      [Value45] varbinary(max) null,
      [Value46] varbinary(max) null,
      [Value47] varbinary(max) null,
      [Value48] varbinary(max) null,
      [Value49] varbinary(max) null,
      [Value50] varbinary(max) null,
      [Value51] varbinary(max) null,
      [Value52] varbinary(max) null,
      [Value53] varbinary(max) null,
      [Value54] varbinary(max) null,
      [Value55] varbinary(max) null,
      [Value56] varbinary(max) null,
      [Value57] varbinary(max) null,
      [Value58] varbinary(max) null,
      [Value59] varbinary(max) null,
      [Value60] varbinary(max) null,
      [Value61] varbinary(max) null,
      [Value62] varbinary(max) null,
      [Value63] varbinary(max) null,
      [Value64] varbinary(max) null
)
go

create unique clustered index [CIX_InstancePromotedPropertiesTable]
	on [System.Activities.DurableInstancing].[InstancePromotedPropertiesTable] ([SurrogateInstanceId], [PromotionName])
	with (allow_page_locks = off)
go

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[SqlWorkflowInstanceStoreVersionTable]') and type in (N'U'))
	drop table [System.Activities.DurableInstancing].[SqlWorkflowInstanceStoreVersionTable]
go

create table [System.Activities.DurableInstancing].[SqlWorkflowInstanceStoreVersionTable]
(
	[Major] bigint,
	[Minor] bigint,
	[Build] bigint,
	[Revision] bigint,
	[LastUpdated] datetime
)
go

create unique clustered index [CIX_SqlWorkflowInstanceStoreVersionTable]
	on [System.Activities.DurableInstancing].[SqlWorkflowInstanceStoreVersionTable] ([Major], [Minor], [Build], [Revision])
go

insert into [System.Activities.DurableInstancing].[SqlWorkflowInstanceStoreVersionTable]
values (4, 0, 0, 0, getutcdate())

if exists (select * from sys.views where object_id = object_id(N'[System.Activities.DurableInstancing].[Instances]'))
      drop view [System.Activities.DurableInstancing].[Instances]
go

create view [System.Activities.DurableInstancing].[Instances] as
      select [InstancesTable].[Id] as [InstanceId],
             [PendingTimer],
             [CreationTime],
             [LastUpdated] as [LastUpdatedTime],
             [InstancesTable].[ServiceDeploymentId],
             [SuspensionExceptionName],
             [SuspensionReason],
             [BlockingBookmarks] as [ActiveBookmarks],
             case when [LockOwnersTable].[LockExpiration] > getutcdate()
				then [LockOwnersTable].[MachineName]
				else null
				end as [CurrentMachine],
             [LastMachineRunOn] as [LastMachine],
             [ExecutionStatus],
             [IsInitialized],
             [IsSuspended],
             [IsCompleted],
             [InstancesTable].[DataEncodingOption] as [EncodingOption],
             [PrimitiveDataProperties] as [ReadWritePrimitiveDataProperties],
             [WriteOnlyPrimitiveDataProperties],
             [ComplexDataProperties] as [ReadWriteComplexDataProperties],
             [WriteOnlyComplexDataProperties]
      from [System.Activities.DurableInstancing].[InstancesTable]
      left outer join [System.Activities.DurableInstancing].[LockOwnersTable]
      on [InstancesTable].[SurrogateLockOwnerId] = [LockOwnersTable].[SurrogateLockOwnerId]
go

grant select on object::[System.Activities.DurableInstancing].[Instances] to [System.Activities.DurableInstancing.InstanceStoreObservers]
go

grant delete on object::[System.Activities.DurableInstancing].[Instances] to [System.Activities.DurableInstancing.InstanceStoreUsers]
go

if exists (select * from sys.views where object_id = object_id(N'[System.Activities.DurableInstancing].[ServiceDeployments]'))
      drop view [System.Activities.DurableInstancing].[ServiceDeployments]
go

create view [System.Activities.DurableInstancing].[ServiceDeployments] as
      select [Id] as [ServiceDeploymentId],
             [SiteName],
             [RelativeServicePath],
             [RelativeApplicationPath],
             [ServiceName],
             [ServiceNamespace]
      from [System.Activities.DurableInstancing].[ServiceDeploymentsTable]
go

grant select on object::[System.Activities.DurableInstancing].[ServiceDeployments] to [System.Activities.DurableInstancing.InstanceStoreObservers]
go

grant delete on object::[System.Activities.DurableInstancing].[ServiceDeployments] to [System.Activities.DurableInstancing.InstanceStoreUsers]
go

create view [System.Activities.DurableInstancing].[InstancePromotedProperties] with schemabinding as
      select [InstancesTable].[Id] as [InstanceId],
			 [InstancesTable].[DataEncodingOption] as [EncodingOption],
			 [PromotionName],
			 [Value1],
			 [Value2],
			 [Value3],
			 [Value4],
			 [Value5],
			 [Value6],
			 [Value7],
			 [Value8],
			 [Value9],
			 [Value10],
			 [Value11],
			 [Value12],
			 [Value13],
			 [Value14],
			 [Value15],
			 [Value16],
			 [Value17],
			 [Value18],
			 [Value19],
			 [Value20],
			 [Value21],
			 [Value22],
			 [Value23],
			 [Value24],
			 [Value25],
			 [Value26],
			 [Value27],
			 [Value28],
			 [Value29],
			 [Value30],
			 [Value31],
			 [Value32],
			 [Value33],
			 [Value34],
			 [Value35],
			 [Value36],
			 [Value37],
			 [Value38],
			 [Value39],
			 [Value40],
			 [Value41],
			 [Value42],
			 [Value43],
			 [Value44],
			 [Value45],
			 [Value46],
			 [Value47],
			 [Value48],
			 [Value49],
			 [Value50],
			 [Value51],
			 [Value52],
			 [Value53],
			 [Value54],
			 [Value55],
			 [Value56],
			 [Value57],
			 [Value58],
			 [Value59],
			 [Value60],
			 [Value61],
			 [Value62],
			 [Value63],
			 [Value64]
    from [System.Activities.DurableInstancing].[InstancePromotedPropertiesTable]
    join [System.Activities.DurableInstancing].[InstancesTable]
    on [InstancePromotedPropertiesTable].[SurrogateInstanceId] = [InstancesTable].[SurrogateInstanceId]
go

grant select on object::[System.Activities.DurableInstancing].[InstancePromotedProperties] to [System.Activities.DurableInstancing.InstanceStoreObservers]
go

-- 拷贝自%WINDIR%\Microsoft.NET\Framework\v4.xxx\SQL\EN\SqlWorkflowInstanceStoreLogic.sql
if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[InsertRunnableInstanceEntry]') and type in (N'P', N'PC'))
	drop procedure [System.Activities.DurableInstancing].[InsertRunnableInstanceEntry]
go

create procedure [System.Activities.DurableInstancing].[InsertRunnableInstanceEntry]
	@surrogateInstanceId bigint,
	@workflowHostType uniqueidentifier,
	@serviceDeploymentId bigint, 
	@isSuspended bit,
	@isReadyToRun bit,
	@pendingTimer datetime
AS
begin    
	set nocount on;
	set transaction isolation level read committed;
	set xact_abort on;	
	
	declare @runnableTime datetime
	
	if (@isSuspended  = 0)
	begin
		if (@isReadyToRun = 1)
		begin
			set @runnableTime = getutcdate()					
		end
		else if (@pendingTimer is not null)
		begin
			set @runnableTime = @pendingTimer
		end
	end
		
	if (@runnableTime is not null and @workflowHostType is not null)
	begin	
		insert into [RunnableInstancesTable]
			([SurrogateInstanceId], [WorkflowHostType], [ServiceDeploymentId], [RunnableTime])
			values( @surrogateInstanceId, @workflowHostType, @serviceDeploymentId, @runnableTime)
	end
end
go

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[RecoverInstanceLocks]') and type in (N'P', N'PC'))
	drop procedure [System.Activities.DurableInstancing].[RecoverInstanceLocks]
go

create procedure [System.Activities.DurableInstancing].[RecoverInstanceLocks]
as
begin
	set nocount on;
	set transaction isolation level read committed;
	set xact_abort on;
	set deadlock_priority low;
    
	declare @now as datetime
	set @now = getutcdate()	
	
	insert into [RunnableInstancesTable] ([SurrogateInstanceId], [WorkflowHostType], [ServiceDeploymentId], [RunnableTime])
		select top (1000) instances.[SurrogateInstanceId], instances.[WorkflowHostType], instances.[ServiceDeploymentId], @now
		from [LockOwnersTable] lockOwners with (readpast) inner loop join
			 [InstancesTable] instances with (readpast)
				on instances.[SurrogateLockOwnerId] = lockOwners.[SurrogateLockOwnerId]
			where 
				lockOwners.[LockExpiration] <= @now and
				instances.[IsInitialized] = 1 and
				instances.[IsSuspended] = 0

	delete from [LockOwnersTable] with (readpast)
	from [LockOwnersTable] lockOwners
	where [LockExpiration] <= @now
	and not exists
	(
		select top (1) 1
		from [InstancesTable] instances with (nolock)
		where instances.[SurrogateLockOwnerId] = lockOwners.[SurrogateLockOwnerId]
	)
end
go

grant execute on [System.Activities.DurableInstancing].[RecoverInstanceLocks] to [System.Activities.DurableInstancing.InstanceStoreUsers]
go

grant execute on [System.Activities.DurableInstancing].[RecoverInstanceLocks] to [System.Activities.DurableInstancing.WorkflowActivationUsers]
go

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[ParseBinaryPropertyValue]') and type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
	drop function [System.Activities.DurableInstancing].[ParseBinaryPropertyValue]
go

create function [System.Activities.DurableInstancing].[ParseBinaryPropertyValue] (@startPosition int, @length int, @concatenatedKeyProperties varbinary(max))
returns varbinary(max)
as
begin
	if (@length > 0)
		return substring(@concatenatedKeyProperties, @startPosition + 1, @length)
	return null
end
go

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[GetExpirationTime]') and type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
	drop function [System.Activities.DurableInstancing].[GetExpirationTime]
go

create function [System.Activities.DurableInstancing].[GetExpirationTime] (@offsetInMilliseconds bigint)
returns datetime
as
begin

	if (@offsetInMilliseconds is null)
	begin
		return null
	end

	declare @hourInMillisecond bigint
	declare @offsetInHours bigint
	declare @remainingOffsetInMilliseconds bigint
	declare @expirationTimer datetime

	set @hourInMillisecond = 60*60*1000
	set @offsetInHours = @offsetInMilliseconds / @hourInMillisecond
	set @remainingOffsetInMilliseconds = @offsetInMilliseconds % @hourInMillisecond

	set @expirationTimer = getutcdate()
	set @expirationTimer = dateadd (hour, @offsetInHours, @expirationTimer)
	set @expirationTimer = dateadd (millisecond,@remainingOffsetInMilliseconds, @expirationTimer)

	return @expirationTimer

end
go

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[CreateLockOwner]') and type in (N'P', N'PC'))
	drop procedure [System.Activities.DurableInstancing].[CreateLockOwner]
go

create procedure [System.Activities.DurableInstancing].[CreateLockOwner]
	@lockOwnerId uniqueidentifier,
	@lockTimeout int,
	@workflowHostType uniqueidentifier,
	@enqueueCommand bit,
	@deleteInstanceOnCompletion bit,	
	@primitiveLockOwnerData varbinary(max),
	@complexLockOwnerData varbinary(max),
	@writeOnlyPrimitiveLockOwnerData varbinary(max),
	@writeOnlyComplexLockOwnerData varbinary(max),
	@encodingOption tinyint,
	@machineName nvarchar(128)
as
begin
	set nocount on
	set transaction isolation level read committed
	set xact_abort on;	
	
	begin transaction
	
	declare @lockAcquired bigint
	declare @lockExpiration datetime
	declare @now datetime
	declare @result int
	declare @surrogateLockOwnerId bigint
	
	set @result = 0
	
	exec @lockAcquired = sp_getapplock @Resource = 'InstanceStoreLock', @LockMode = 'Shared', @LockTimeout = 10000
		
	if (@lockAcquired < 0)
	begin
		select @result as 'Result'
		set @result = 13
	end
	
	if (@result = 0)
	begin
		set @now = getutcdate()
		
		if (@lockTimeout = 0)
			set @lockExpiration = '9999-12-31T23:59:59';
		else 
			set @lockExpiration = dateadd(second, @lockTimeout, getutcdate());
		
		insert into [LockOwnersTable] ([Id], [LockExpiration], [MachineName], [WorkflowHostType], [EnqueueCommand], [DeletesInstanceOnCompletion], [PrimitiveLockOwnerData], [ComplexLockOwnerData], [WriteOnlyPrimitiveLockOwnerData], [WriteOnlyComplexLockOwnerData], [EncodingOption])
		values (@lockOwnerId, @lockExpiration, @machineName, @workflowHostType, @enqueueCommand, @deleteInstanceOnCompletion, @primitiveLockOwnerData, @complexLockOwnerData, @writeOnlyPrimitiveLockOwnerData, @writeOnlyComplexLockOwnerData, @encodingOption)
		
		set @surrogateLockOwnerId = scope_identity()
	end
	
	if (@result != 13)
		exec sp_releaseapplock @Resource = 'InstanceStoreLock'
	
	if (@result = 0)
	begin
		commit transaction
		select 0 as 'Result', @surrogateLockOwnerId
	end
	else
		rollback transaction
end
go

grant execute on [System.Activities.DurableInstancing].[CreateLockOwner] to [System.Activities.DurableInstancing.InstanceStoreUsers] 
go

grant execute on [System.Activities.DurableInstancing].[CreateLockOwner] to [System.Activities.DurableInstancing.WorkflowActivationUsers] 
go

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[DeleteLockOwner]') and type in (N'P', N'PC'))
	drop procedure [System.Activities.DurableInstancing].[DeleteLockOwner]
go

create procedure [System.Activities.DurableInstancing].[DeleteLockOwner]
	@surrogateLockOwnerId bigint
as
begin
	set nocount on
	set transaction isolation level read committed
	set deadlock_priority low
	set xact_abort on;	
	
	begin transaction
	
	declare @lockAcquired bigint
	declare @result int
	set @result = 0
	
	exec @lockAcquired = sp_getapplock @Resource = 'InstanceStoreLock', @LockMode = 'Shared', @LockTimeout = 10000
		
	if (@lockAcquired < 0)
	begin
		select @result as 'Result'
		set @result = 13
	end
	
	if (@result = 0)
	begin
		update [LockOwnersTable]
		set [LockExpiration] = '2000-01-01T00:00:00'
		where [SurrogateLockOwnerId] = @surrogateLockOwnerId
	end
	
	if (@result != 13)
		exec sp_releaseapplock @Resource = 'InstanceStoreLock' 
	
	if (@result = 0)
	begin
		commit transaction
		select 0 as 'Result'
	end
	else
		rollback transaction
end
go

grant execute on [System.Activities.DurableInstancing].[DeleteLockOwner] to [System.Activities.DurableInstancing.InstanceStoreUsers] 
go

grant execute on [System.Activities.DurableInstancing].[DeleteLockOwner] to [System.Activities.DurableInstancing.WorkflowActivationUsers] 
go

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[ExtendLock]') and type in (N'P', N'PC'))
	drop procedure [System.Activities.DurableInstancing].[ExtendLock]
go
create procedure [System.Activities.DurableInstancing].[ExtendLock]
	@surrogateLockOwnerId bigint,
	@lockTimeout int	
as
begin
	set nocount on
	set transaction isolation level read committed
	set xact_abort on;	
	
	begin transaction	
	
	declare @now datetime
	declare @newLockExpiration datetime
	declare @result int
	
	set @now = getutcdate()
	set @result = 0
	
	if (@lockTimeout = 0)
		set @newLockExpiration = '9999-12-31T23:59:59'
	else
		set @newLockExpiration = dateadd(second, @lockTimeout, @now)
	
	update [LockOwnersTable]
	set [LockExpiration] = @newLockExpiration
	where ([SurrogateLockOwnerId] = @surrogateLockOwnerId) and
		  ([LockExpiration] > @now)
	
	if (@@rowcount = 0) 
	begin
		if exists (select * from [LockOwnersTable] where ([SurrogateLockOwnerId] = @surrogateLockOwnerId))
		begin
			exec [System.Activities.DurableInstancing].[DeleteLockOwner] @surrogateLockOwnerId
			set @result = 11
		end
		else
			set @result = 12
	end
	
	select @result as 'Result'
	commit transaction
end
go

grant execute on [System.Activities.DurableInstancing].[ExtendLock] to [System.Activities.DurableInstancing.InstanceStoreUsers] 
go

grant execute on [System.Activities.DurableInstancing].[ExtendLock] to [System.Activities.DurableInstancing.WorkflowActivationUsers] 
go

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[AssociateKeys]') and type in (N'P', N'PC'))
	drop procedure [System.Activities.DurableInstancing].[AssociateKeys]
go
create procedure [System.Activities.DurableInstancing].[AssociateKeys]
	@surrogateInstanceId bigint,
	@keysToAssociate xml = null,
	@concatenatedKeyProperties varbinary(max) = null,
	@encodingOption tinyint,
	@singleKeyId uniqueidentifier
as
begin	
	set nocount on
	set transaction isolation level read committed
	set xact_abort on;	
	
	declare @badKeyId uniqueidentifier
	declare @numberOfKeys int
	declare @result int
	declare @keys table([KeyId] uniqueidentifier, [Properties] varbinary(max))
	
	set @result = 0
	
	if (@keysToAssociate is not null)
	begin
		insert into @keys
		select T.Item.value('@KeyId', 'uniqueidentifier') as [KeyId],
			   [System.Activities.DurableInstancing].[ParseBinaryPropertyValue](T.Item.value('@StartPosition', 'int'), T.Item.value('@BinaryLength', 'int'), @concatenatedKeyProperties) as [Properties]
	    from @keysToAssociate.nodes('/CorrelationKeys/CorrelationKey') as T(Item)
		option (maxdop 1)

		select @numberOfKeys = count(1) from @keys
		
		insert into [KeysTable] ([Id], [SurrogateInstanceId], [IsAssociated])
		select [KeyId], @surrogateInstanceId, 1
		from @keys as [Keys]
		
		if (@@rowcount != @numberOfKeys)
		begin
			select top 1 @badKeyId = [Keys].[KeyId] 
			from @keys as [Keys]
			join [KeysTable] on [Keys].[KeyId] = [KeysTable].[Id]
			where [KeysTable].[SurrogateInstanceId] != @surrogateInstanceId
			
			if (@@rowcount != 0)
			begin
				select 3 as 'Result', @badKeyId
				return 3
			end
		end
		
		update [KeysTable]
		set [Properties] = [Keys].[Properties],
			[EncodingOption] = @encodingOption
		from @keys as [Keys]
		join [KeysTable] on [Keys].[KeyId] = [KeysTable].[Id]
		where [KeysTable].[EncodingOption] is null
	end
	
	if (@singleKeyId is not null)
	begin
InsertSingleKey:
		update [KeysTable]
		set [Properties] = @concatenatedKeyProperties,
			[EncodingOption] = @encodingOption
		where ([Id] = @singleKeyId) and ([SurrogateInstanceId] = @surrogateInstanceId)
			  
		if (@@rowcount != 1)
		begin
			if exists (select [Id] from [KeysTable] where [Id] = @singleKeyId)
			begin
				select 3 as 'Result', @singleKeyId
				return 3
			end
			
			insert into [KeysTable] ([Id], [SurrogateInstanceId], [IsAssociated], [Properties], [EncodingOption])
			values (@singleKeyId, @surrogateInstanceId, 1, @concatenatedKeyProperties, @encodingOption)
			
			if (@@rowcount = 0)
				goto InsertSingleKey
		end
	end
end
go

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[CompleteKeys]') and type in (N'P', N'PC'))
	drop procedure [System.Activities.DurableInstancing].[CompleteKeys]
go
create procedure [System.Activities.DurableInstancing].[CompleteKeys]
	@surrogateInstanceId bigint,
	@keysToComplete xml = null
as
begin	
	set nocount on
	set transaction isolation level read committed
	set xact_abort on;	
	
	declare @badKeyId uniqueidentifier
	declare @numberOfKeys int
	declare @result int
	declare @keyIds table([KeyId] uniqueidentifier)
	
	set @result = 0
	
	if (@keysToComplete is not null)
	begin
		insert into @keyIds
		select T.Item.value('@KeyId', 'uniqueidentifier')
		from @keysToComplete.nodes('//CorrelationKey') as T(Item)
		option(maxdop 1)
		
		select @numberOfKeys = count(1) from @keyIds
		
		update [KeysTable]
		set [IsAssociated] = 0
		from @keyIds as [KeyIds]
		join [KeysTable] on [KeyIds].[KeyId] = [KeysTable].[Id]
		where [SurrogateInstanceId] = @surrogateInstanceId
		
		if (@@rowcount != @numberOfKeys)
		begin
			select top 1 @badKeyId = [MissingKeys].[MissingKeyId]
			from
				(select [KeyIds].[KeyId] as [MissingKeyId] 
				 from @keyIds as [KeyIds]
				 except
				 select [Id] from [KeysTable] where [SurrogateInstanceId] = @surrogateInstanceId) as MissingKeys
		
			select 4 as 'Result', @badKeyId
			return 4
		end
	end
end
go

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[FreeKeys]') and type in (N'P', N'PC'))
	drop procedure [System.Activities.DurableInstancing].[FreeKeys]
go
create procedure [System.Activities.DurableInstancing].[FreeKeys]
	@surrogateInstanceId bigint,
	@keysToFree xml = null
as
begin	
	set nocount on
	set transaction isolation level read committed
	set xact_abort on;	
	
	declare @badKeyId uniqueidentifier
	declare @numberOfKeys int
	declare @result int
	declare @keyIds table([KeyId] uniqueidentifier)
	
	set @result = 0
	
	if (@keysToFree is not null)
	begin
		insert into @keyIds
		select T.Item.value('@KeyId', 'uniqueidentifier')
		from @keysToFree.nodes('//CorrelationKey') as T(Item)
		option(maxdop 1)
		
		select @numberOfKeys = count(1) from @keyIds
		
		delete [KeysTable]
		from @keyIds as [KeyIds]
		join [KeysTable] on [KeyIds].[KeyId] = [KeysTable].[Id]
		where [SurrogateInstanceId] = @surrogateInstanceId

		if (@@rowcount != @numberOfKeys)
		begin
			select top 1 @badKeyId = [MissingKeys].[MissingKeyId] from
				(select [KeyIds].[KeyId] as [MissingKeyId]
				 from @keyIds as [KeyIds]
				 except
				 select [Id] from [KeysTable] where [SurrogateInstanceId] = @surrogateInstanceId) as MissingKeys
		
			select 4 as 'Result', @badKeyId
			return 4
		end
	end
end
go

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[CreateInstance]') and type in (N'P', N'PC'))
	drop procedure [System.Activities.DurableInstancing].[CreateInstance]
go
create procedure [System.Activities.DurableInstancing].[CreateInstance]
	@instanceId uniqueidentifier,
	@surrogateLockOwnerId bigint,
	@workflowHostType uniqueidentifier,
	@serviceDeploymentId bigint,
	@surrogateInstanceId bigint output,
	@result int output
as
begin
	set nocount on
	set transaction isolation level read committed
	set xact_abort on;	
	
	set @surrogateInstanceId = 0
	set @result = 0
	
	begin try
		insert into [InstancesTable] ([Id], [SurrogateLockOwnerId], [CreationTime], [WorkflowHostType], [ServiceDeploymentId], [Version])
		values (@instanceId, @surrogateLockOwnerId, getutcdate(), @workflowHostType, @serviceDeploymentId, 1)
		
		set @surrogateInstanceId = scope_identity()		
	end try
	begin catch
		if (error_number() != 2601)
		begin
			set @result = 99
			select @result as 'Result'
		end
	end catch
end
go

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[LockInstance]') and type in (N'P', N'PC'))
	drop procedure [System.Activities.DurableInstancing].[LockInstance]
go
create procedure [System.Activities.DurableInstancing].[LockInstance]
	@instanceId uniqueidentifier,
	@surrogateLockOwnerId bigint,
	@handleInstanceVersion bigint,
	@handleIsBoundToLock bit,
	@surrogateInstanceId bigint output,
	@lockVersion bigint output,
	@result int output
as
begin
	set nocount on
	set transaction isolation level read committed
	set xact_abort on;	
	
	declare @isCompleted bit
	declare @currentLockOwnerId bigint
	declare @currentVersion bigint

TryLockInstance:
	set @currentLockOwnerId = 0
	set @surrogateInstanceId = 0
	set @result = 0
	
	update [InstancesTable]
	set [SurrogateLockOwnerId] = @surrogateLockOwnerId,
		@lockVersion = [Version] = case when ([InstancesTable].[SurrogateLockOwnerId] is null or 
											  [InstancesTable].[SurrogateLockOwnerId] != @surrogateLockOwnerId)
									then [Version] + 1
									else [Version]
								  end,
		@surrogateInstanceId = [SurrogateInstanceId]
	from [InstancesTable]
	left outer join [LockOwnersTable] on [InstancesTable].[SurrogateLockOwnerId] = [LockOwnersTable].[SurrogateLockOwnerId]
	where ([InstancesTable].[Id] = @instanceId) and
		  ([InstancesTable].[IsCompleted] = 0) and
		  (
		   (@handleIsBoundToLock = 0 and
		    (
		     ([InstancesTable].[SurrogateLockOwnerId] is null) or
		     ([LockOwnersTable].[SurrogateLockOwnerId] is null) or
			  (
		       ([LockOwnersTable].[LockExpiration] < getutcdate()) and
               ([LockOwnersTable].[SurrogateLockOwnerId] != @surrogateLockOwnerId)
			  )
		    )
		   ) or 
		   (
			(@handleIsBoundToLock = 1) and
		    ([LockOwnersTable].[SurrogateLockOwnerId] = @surrogateLockOwnerId) and
		    ([LockOwnersTable].[LockExpiration] > getutcdate()) and
		    ([InstancesTable].[Version] = @handleInstanceVersion)
		   )
		  )
	
	if (@@rowcount = 0)
	begin
		if not exists (select * from [LockOwnersTable] where ([SurrogateLockOwnerId] = @surrogateLockOwnerId) and ([LockExpiration] > getutcdate()))
		begin
			if exists (select * from [LockOwnersTable] where [SurrogateLockOwnerId] = @surrogateLockOwnerId)
				set @result = 11
			else
				set @result = 12
			
			select @result as 'Result'
			return 0
		end
		
		select @currentLockOwnerId = [SurrogateLockOwnerId],
			   @isCompleted = [IsCompleted],
			   @currentVersion = [Version]
		from [InstancesTable]
		where [Id] = @instanceId
	
		if (@@rowcount = 1)
		begin
			if (@isCompleted = 1)
				set @result = 7
			else if (@currentLockOwnerId = @surrogateLockOwnerId)
			begin
				if (@handleIsBoundToLock = 1)
					set @result = 10
				else
					set @result = 14
			end
			else if (@handleIsBoundToLock = 0)
				set @result = 2
			else
				set @result = 6
		end
		else if (@handleIsBoundToLock = 1)
			set @result = 6
	end

	if (@result != 0 and @result != 2)
		select @result as 'Result', @instanceId, @currentVersion
	else if (@result = 2)
	begin
		select @result as 'Result', @instanceId, [LockOwnersTable].[Id], [LockOwnersTable].[EncodingOption], [PrimitiveLockOwnerData], [ComplexLockOwnerData]
		from [LockOwnersTable]
		join [InstancesTable] on [InstancesTable].[SurrogateLockOwnerId] = [LockOwnersTable].[SurrogateLockOwnerId]
		where [InstancesTable].[SurrogateLockOwnerId] = @currentLockOwnerId and
			  [InstancesTable].[Id] = @instanceId
		
		if (@@rowcount = 0)
			goto TryLockInstance
	end
end
go

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[UnlockInstance]') and type in (N'P', N'PC'))
	drop procedure [System.Activities.DurableInstancing].[UnlockInstance]
go
create procedure [System.Activities.DurableInstancing].[UnlockInstance]
	@surrogateLockOwnerId bigint,
	@instanceId uniqueidentifier,
	@handleInstanceVersion bigint
as
begin
	set nocount on
	set transaction isolation level read committed		
	set xact_abort on;	
	begin transaction
	
	declare @pendingTimer datetime
	declare @surrogateInstanceId bigint
	declare @workflowHostType uniqueidentifier
	declare @serviceDeploymentId bigint
	declare @enqueueCommand bit	
	declare @isReadyToRun bit	
	declare @isSuspended bit
	declare @now datetime
	
	set @now = getutcdate()
		
	update [InstancesTable]
	set [SurrogateLockOwnerId] = null,
	    @surrogateInstanceId = [SurrogateInstanceId],
	    @workflowHostType = [WorkflowHostType],
   	    @serviceDeploymentId = [ServiceDeploymentId],
	    @pendingTimer = [PendingTimer],
	    @isReadyToRun =  [IsReadyToRun],
	    @isSuspended = [IsSuspended]
	where [Id] = @instanceId and
		  [SurrogateLockOwnerId] = @surrogateLockOwnerId and
		  [Version] = @handleInstanceVersion
	
	exec [System.Activities.DurableInstancing].[InsertRunnableInstanceEntry] @surrogateInstanceId, @workflowHostType, @serviceDeploymentId, @isSuspended, @isReadyToRun, @pendingTimer    
	
	commit transaction
end
go

grant execute on [System.Activities.DurableInstancing].[UnlockInstance] to [System.Activities.DurableInstancing.InstanceStoreUsers] 
go

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[DetectRunnableInstances]') and type in (N'P', N'PC'))
	drop procedure [System.Activities.DurableInstancing].[DetectRunnableInstances]
go

create procedure [System.Activities.DurableInstancing].[DetectRunnableInstances]
	@workflowHostType uniqueidentifier
as
begin
	set nocount on
	set transaction isolation level read committed	
	set xact_abort on;	
	set deadlock_priority low
	
	declare @nextRunnableTime datetime

	select top 1 @nextRunnableTime = [RunnableInstancesTable].[RunnableTime]
			  from [RunnableInstancesTable] with (readpast)
			  where [WorkflowHostType] = @workflowHostType
			  order by [WorkflowHostType], [RunnableTime]
			  
	select 0 as 'Result', @nextRunnableTime, getutcdate()
end
go

grant execute on [System.Activities.DurableInstancing].[DetectRunnableInstances] to [System.Activities.DurableInstancing.InstanceStoreUsers] 
go

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[GetActivatableWorkflowsActivationParameters]') and type in (N'P', N'PC'))
	drop procedure [System.Activities.DurableInstancing].[GetActivatableWorkflowsActivationParameters]
go

create procedure [System.Activities.DurableInstancing].[GetActivatableWorkflowsActivationParameters]
	@machineName nvarchar(128)
as
begin
	set nocount on
	set transaction isolation level read committed	
	set xact_abort on;	
	set deadlock_priority low
	
	declare @now datetime
	set @now = getutcdate()
	
	select 0 as 'Result'
	
	select top(1000) serviceDeployments.[SiteName], serviceDeployments.[RelativeApplicationPath], serviceDeployments.[RelativeServicePath]
	from (
		select distinct [ServiceDeploymentId], [WorkflowHostType]
		from [RunnableInstancesTable] with (readpast)
		where [RunnableTime] <= @now
		) runnableWorkflows inner join [ServiceDeploymentsTable] serviceDeployments
		on runnableWorkflows.[ServiceDeploymentId] = serviceDeployments.[Id]
	where not exists (
						select top (1) 1
						from [LockOwnersTable] lockOwners
						where lockOwners.[LockExpiration] > @now
						and lockOwners.[MachineName] = @machineName
						and lockOwners.[WorkflowHostType] = runnableWorkflows.[WorkflowHostType]
					  )
end
go

grant execute on [System.Activities.DurableInstancing].[GetActivatableWorkflowsActivationParameters] to [System.Activities.DurableInstancing.InstanceStoreUsers]
go

grant execute on [System.Activities.DurableInstancing].[GetActivatableWorkflowsActivationParameters] to [System.Activities.DurableInstancing.WorkflowActivationUsers]
go

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[LoadInstance]') and type in (N'P', N'PC'))
	drop procedure [System.Activities.DurableInstancing].[LoadInstance]
go
create procedure [System.Activities.DurableInstancing].[LoadInstance]
	@surrogateLockOwnerId bigint,
	@operationType tinyint,
	@handleInstanceVersion bigint,
	@handleIsBoundToLock bit,
	@keyToLoadBy uniqueidentifier = null,
	@instanceId uniqueidentifier = null,
	@keysToAssociate xml = null,
	@encodingOption tinyint,
	@concatenatedKeyProperties varbinary(max) = null,
	@singleKeyId uniqueidentifier,
	@operationTimeout int
as
begin
	set nocount on
	set transaction isolation level read committed	
	set xact_abort on;		
	set deadlock_priority low
	begin transaction
	
	declare @result int
	declare @lockAcquired bigint
	declare @isInitialized bit
	declare @createKey bit
	declare @createdInstance bit
	declare @keyIsAssociated bit
	declare @loadedByKey bit
	declare @now datetime
	declare @surrogateInstanceId bigint

	set @createdInstance = 0
	set @isInitialized = 0
	set @keyIsAssociated = 0
	set @result = 0
	set @surrogateInstanceId = null
	
	exec @lockAcquired = sp_getapplock @Resource = 'InstanceStoreLock', @LockMode = 'Shared', @LockTimeout = @operationTimeout
	
	if (@lockAcquired < 0)
	begin
		set @result = 13
		select @result as 'Result'
	end
	
	if (@result = 0)
	begin
		set @now = getutcdate()

		if (@operationType = 0) or (@operationType = 2)
		begin
MapKeyToInstanceId:
			set @loadedByKey = 0
			set @createKey = 0
			
			select @surrogateInstanceId = [SurrogateInstanceId],
				   @keyIsAssociated = [IsAssociated]
			from [KeysTable]
			where [Id] = @keyToLoadBy
			
			if (@@rowcount = 0)
			begin
				if (@operationType = 2)
				begin
					set @result = 4
					select @result as 'Result', @keyToLoadBy 
				end
					set @createKey = 1
			end
			else if (@keyIsAssociated = 0)
			begin
				set @result = 8
				select @result as 'Result', @keyToLoadBy
			end
			else
			begin
				select @instanceId = [Id]
				from [InstancesTable]
				where [SurrogateInstanceId] = @surrogateInstanceId

				if (@@rowcount = 0)
					goto MapKeyToInstanceId

				set @loadedByKey = 1
			end
		end
	end

	if (@result = 0)
	begin
LockOrCreateInstance:
		exec [System.Activities.DurableInstancing].[LockInstance] @instanceId, @surrogateLockOwnerId, @handleInstanceVersion, @handleIsBoundToLock, @surrogateInstanceId output, null, @result output
														  
		if (@result = 0 and @surrogateInstanceId = 0)
		begin
			if (@loadedByKey = 1)
				goto MapKeyToInstanceId
			
			if (@operationType > 1)
			begin
				set @result = 1
				select @result as 'Result', @instanceId as 'InstanceId'
			end
			else
			begin				
				exec [System.Activities.DurableInstancing].[CreateInstance] @instanceId, @surrogateLockOwnerId, null, null, @surrogateInstanceId output, @result output
			
				if (@result = 0 and @surrogateInstanceId = 0)
					goto LockOrCreateInstance
				else if (@surrogateInstanceId > 0)
					set @createdInstance = 1
			end
		end
		else if (@result = 0)
		begin
			delete from [RunnableInstancesTable]
			where [SurrogateInstanceId] = @surrogateInstanceId
		end
	end
		
	if (@result = 0)
	begin
		if (@createKey = 1) 
		begin
			select @isInitialized = [IsInitialized]
			from [InstancesTable]
			where [SurrogateInstanceId] = @surrogateInstanceId
			
			if (@isInitialized = 1)
			begin
				set @result = 5
				select @result as 'Result', @instanceId
			end
			else
			begin													
				insert into [KeysTable] ([Id], [SurrogateInstanceId], [IsAssociated])
				values (@keyToLoadBy, @surrogateInstanceId, 1)
				
				if (@@rowcount = 0)
				begin
					if (@createdInstance = 1)
					begin
						delete [InstancesTable]
						where [SurrogateInstanceId] = @surrogateInstanceId
					end
					else
					begin
						update [InstancesTable]
						set [SurrogateLockOwnerId] = null
						where [SurrogateInstanceId] = @surrogateInstanceId
					end
					
					goto MapKeyToInstanceId
				end
			end
		end
		else if (@loadedByKey = 1 and not exists(select [Id] from [KeysTable] where ([Id] = @keyToLoadBy) and ([IsAssociated] = 1)))
		begin
			set @result = 8
			select @result as 'Result', @keyToLoadBy
		end
		
		if (@operationType > 1 and not exists(select [Id] from [InstancesTable] where ([Id] = @instanceId) and ([IsInitialized] = 1)))
		begin
			set @result = 1
			select @result as 'Result', @instanceId as 'InstanceId'
		end
		
		if (@result = 0)
			exec @result = [System.Activities.DurableInstancing].[AssociateKeys] @surrogateInstanceId, @keysToAssociate, @concatenatedKeyProperties, @encodingOption, @singleKeyId
		
		-- Ensure that this key's data will never be overwritten.
		if (@result = 0 and @createKey = 1)
		begin
			update [KeysTable]
			set [EncodingOption] = @encodingOption
			where [Id] = @keyToLoadBy
		end
	end
	
	if (@result != 13)
		exec sp_releaseapplock @Resource = 'InstanceStoreLock'
		
	if (@result = 0)
	begin
		select @result as 'Result',
			   [Id],
			   [SurrogateInstanceId],
			   [PrimitiveDataProperties],
			   [ComplexDataProperties],
			   [MetadataProperties],
			   [DataEncodingOption],
			   [MetadataEncodingOption],
			   [Version],
			   [IsInitialized],
			   @createdInstance
		from [InstancesTable]
		where [SurrogateInstanceId] = @surrogateInstanceId
		
		if (@createdInstance = 0)
		begin
			select @result as 'Result',
				   [EncodingOption],
				   [Change]
			from [InstanceMetadataChangesTable]
			where [SurrogateInstanceId] = @surrogateInstanceId
			order by([ChangeTime])
			
			if (@@rowcount = 0)
			select @result as 'Result', null, null
				
			select @result as 'Result',
				   [Id],
				   [IsAssociated],
				   [EncodingOption],
				   [Properties]
			from [KeysTable] with (index(NCIX_KeysTable_SurrogateInstanceId))
			where ([KeysTable].[SurrogateInstanceId] = @surrogateInstanceId)
			
			if (@@rowcount = 0)
				select @result as 'Result', null, null, null, null
		end

		commit transaction
	end
	else if (@result = 2 or @result = 14)
		commit transaction
	else
		rollback transaction
end
go

grant execute on [System.Activities.DurableInstancing].[LoadInstance] to [System.Activities.DurableInstancing.InstanceStoreUsers] 
go

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[TryLoadRunnableInstance]') and type in (N'P', N'PC'))
	drop procedure [System.Activities.DurableInstancing].[TryLoadRunnableInstance]
go

create procedure [System.Activities.DurableInstancing].[TryLoadRunnableInstance]
	@surrogateLockOwnerId bigint,
	@workflowHostType uniqueidentifier,
	@operationType tinyint,
	@handleInstanceVersion bigint,
	@handleIsBoundToLock bit,
	@encodingOption tinyint,	
	@operationTimeout int
as
begin
	set nocount on
	set transaction isolation level read committed	
	set xact_abort on;	
	set deadlock_priority low
	begin tran
	
	declare @instanceId uniqueIdentifier
	declare @now datetime
	set @now = getutcdate()
	
	select top (1) @instanceId = instances.[Id]
	from [RunnableInstancesTable] runnableInstances with (readpast, updlock)
		inner loop join [InstancesTable] instances with (readpast, updlock)
		on runnableInstances.[SurrogateInstanceId] = instances.[SurrogateInstanceId]
	where runnableInstances.[WorkflowHostType] = @workflowHostType
		  and 
	      runnableInstances.[RunnableTime] <= @now
    
    if (@@rowcount = 1)
    begin
		select 0 as 'Result', cast(1 as bit)				
		exec [System.Activities.DurableInstancing].[LoadInstance] @surrogateLockOwnerId, @operationType, @handleInstanceVersion, @handleIsBoundToLock, null, @instanceId, null, @encodingOption, null, null, @operationTimeout
    end	
    else
    begin
		select 0 as 'Result', cast(0 as bit)
    end
    
    if (@@trancount > 0)
    begin
		commit tran
    end
end
go

grant execute on [System.Activities.DurableInstancing].[TryLoadRunnableInstance] to [System.Activities.DurableInstancing.InstanceStoreUsers] 
go

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[DeleteInstance]') and type in (N'P', N'PC'))
	drop procedure [System.Activities.DurableInstancing].[DeleteInstance]
go
create procedure [System.Activities.DurableInstancing].[DeleteInstance]
	@surrogateInstanceId bigint = null
as
begin	
	set nocount on
	set transaction isolation level read committed		
	set xact_abort on;	
	
	delete [InstancePromotedPropertiesTable]
	where [SurrogateInstanceId] = @surrogateInstanceId
		
	delete [KeysTable]
	where [SurrogateInstanceId] = @surrogateInstanceId
		
	delete [InstanceMetadataChangesTable]
	where [SurrogateInstanceId] = @surrogateInstanceId

	delete [RunnableInstancesTable] 
	where [SurrogateInstanceId] = @surrogateInstanceId

	delete [InstancesTable] 
	where [SurrogateInstanceId] = @surrogateInstanceId

end
go

grant execute on [System.Activities.DurableInstancing].[DeleteInstance] to [System.Activities.DurableInstancing.InstanceStoreUsers] 
go

if exists (select * from sys.triggers where object_id = OBJECT_ID(N'[System.Activities.DurableInstancing].[DeleteInstanceTrigger]'))
	drop trigger [System.Activities.DurableInstancing].[DeleteInstanceTrigger]
go

create trigger [System.Activities.DurableInstancing].[DeleteInstanceTrigger] on [System.Activities.DurableInstancing].[Instances]
instead of delete
as
begin	
	if (@@rowcount = 0)
		return
		
	set nocount on
	set transaction isolation level read committed		
	set xact_abort on;	
	
	declare @surrogateInstanceIds table ([SurrogateInstanceId] bigint primary key)		
	
	insert into @surrogateInstanceIds
	select [SurrogateInstanceId]
	from deleted as [DeletedInstances]
	join [InstancesTable] on [InstancesTable].[Id] = [DeletedInstances].[InstanceId]
	
	delete [InstancePromotedPropertiesTable]
	from @surrogateInstanceIds as [InstancesToDelete]
	inner merge join [System.Activities.DurableInstancing].[InstancePromotedPropertiesTable] on [InstancePromotedPropertiesTable].[SurrogateInstanceId] = [InstancesToDelete].[SurrogateInstanceId]
	
	delete [KeysTable]
	from @surrogateInstanceIds as [InstancesToDelete]
	inner loop join [System.Activities.DurableInstancing].[KeysTable] on [KeysTable].[SurrogateInstanceId] = [InstancesToDelete].[SurrogateInstanceId]
	
	delete from [InstanceMetadataChangesTable]
	from @surrogateInstanceIds as [InstancesToDelete]
	inner merge join [System.Activities.DurableInstancing].[InstanceMetadataChangesTable] on [InstanceMetadataChangesTable].[SurrogateInstanceId] = [InstancesToDelete].[SurrogateInstanceId]
	
	delete [RunnableInstancesTable]
	from @surrogateInstanceIds as [InstancesToDelete]
	inner loop join [System.Activities.DurableInstancing].[RunnableInstancesTable] on [RunnableInstancesTable].[SurrogateInstanceId] = [InstancesToDelete].[SurrogateInstanceId]
	
	delete [InstancesTable]
	from @surrogateInstanceIds as [InstancesToDelete]
	inner merge join [System.Activities.DurableInstancing].[InstancesTable] on [InstancesTable].[SurrogateInstanceId] = [InstancesToDelete].[SurrogateInstanceId]
end
go	

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[CreateServiceDeployment]') and type in (N'P', N'PC'))
	drop procedure [System.Activities.DurableInstancing].[CreateServiceDeployment]
go
create procedure [System.Activities.DurableInstancing].[CreateServiceDeployment]	
	@serviceDeploymentHash uniqueIdentifier,
	@siteName nvarchar(max),
	@relativeServicePath nvarchar(max),
	@relativeApplicationPath nvarchar(max),
	@serviceName nvarchar(max),
    @serviceNamespace nvarchar(max),
    @serviceDeploymentId bigint output
as
begin
	set nocount on
	set transaction isolation level read committed		
	set xact_abort on;	
	
		--Create or select the service deployment id
		insert into [ServiceDeploymentsTable]
			([ServiceDeploymentHash], [SiteName], [RelativeServicePath], [RelativeApplicationPath], [ServiceName], [ServiceNamespace])
			values (@serviceDeploymentHash, @siteName, @relativeServicePath, @relativeApplicationPath, @serviceName, @serviceNamespace)
			
		if (@@rowcount = 0)
		begin		
			select @serviceDeploymentId = [Id]
			from [ServiceDeploymentsTable]
			where [ServiceDeploymentHash] = @serviceDeploymentHash		
		end
		else			
		begin
			set @serviceDeploymentId = scope_identity()		
		end	
		
		select 0 as 'Result', @serviceDeploymentId		
end	
go

grant execute on [System.Activities.DurableInstancing].[CreateServiceDeployment] to [System.Activities.DurableInstancing.InstanceStoreUsers] 
go

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[SaveInstance]') and type in (N'P', N'PC'))
	drop procedure [System.Activities.DurableInstancing].[SaveInstance]
go
create procedure [System.Activities.DurableInstancing].[SaveInstance]
	@instanceId uniqueidentifier,
	@surrogateLockOwnerId bigint,
	@handleInstanceVersion bigint,
	@handleIsBoundToLock bit,
	@primitiveDataProperties varbinary(max),
	@complexDataProperties varbinary(max),
	@writeOnlyPrimitiveDataProperties varbinary(max),
	@writeOnlyComplexDataProperties varbinary(max),
	@metadataProperties varbinary(max),
	@metadataIsConsistent bit,
	@encodingOption tinyint,
	@timerDurationMilliseconds bigint,
	@suspensionStateChange tinyint,
	@suspensionReason nvarchar(max),
	@suspensionExceptionName nvarchar(450),
	@keysToAssociate xml,
	@keysToComplete xml,
	@keysToFree xml,
	@concatenatedKeyProperties varbinary(max),
	@unlockInstance bit,
	@isReadyToRun bit,
	@isCompleted bit,
	@singleKeyId uniqueidentifier,
	@lastMachineRunOn nvarchar(450),
	@executionStatus nvarchar(450),
	@blockingBookmarks nvarchar(max),
	@workflowHostType uniqueidentifier,
	@serviceDeploymentId bigint,
	@operationTimeout int
as
begin
	set nocount on
	set transaction isolation level read committed		
	set xact_abort on;	

	declare @currentInstanceVersion bigint
	declare @deleteInstanceOnCompletion bit
	declare @enqueueCommand bit
	declare @isSuspended bit
	declare @lockAcquired bigint
	declare @metadataUpdateOnly bit
	declare @now datetime
	declare @result int
	declare @surrogateInstanceId bigint
	declare @pendingTimer datetime
	
	set @result = 0
	set @metadataUpdateOnly = 0
	
	exec @lockAcquired = sp_getapplock @Resource = 'InstanceStoreLock', @LockMode = 'Shared', @LockTimeout = @operationTimeout
		
	if (@lockAcquired < 0)
	begin
		select @result as 'Result'
		set @result = 13
	end
	
	set @now = getutcdate()
	
	if (@primitiveDataProperties is null and @complexDataProperties is null and @writeOnlyPrimitiveDataProperties is null and @writeOnlyComplexDataProperties is null)
		set @metadataUpdateOnly = 1

LockOrCreateInstance:
	if (@result = 0)
	begin
		exec [System.Activities.DurableInstancing].[LockInstance] @instanceId, @surrogateLockOwnerId, @handleInstanceVersion, @handleIsBoundToLock, @surrogateInstanceId output, @currentInstanceVersion output, @result output
															  
		if (@result = 0 and @surrogateInstanceId = 0)
		begin
			exec [System.Activities.DurableInstancing].[CreateInstance] @instanceId, @surrogateLockOwnerId, @workflowHostType, @serviceDeploymentId, @surrogateInstanceId output, @result output
			
			if (@result = 0 and @surrogateInstanceId = 0)
				goto LockOrCreateInstance
			
			set @currentInstanceVersion = 1
		end
	end
	
	if (@result = 0)
	begin
		select @enqueueCommand = [EnqueueCommand],
			   @deleteInstanceOnCompletion = [DeletesInstanceOnCompletion]
		from [LockOwnersTable]
		where ([SurrogateLockOwnerId] = @surrogateLockOwnerId)
		
		if (@isCompleted = 1 and @deleteInstanceOnCompletion = 1)
		begin
			exec [System.Activities.DurableInstancing].[DeleteInstance] @surrogateInstanceId
			goto Finally
		end
		
		update [InstancesTable] 
		set @instanceId = [InstancesTable].[Id],
			@workflowHostType = [WorkflowHostType] = 
					case when (@workflowHostType is null)
						then [WorkflowHostType]
						else @workflowHostType 
					end,
			@serviceDeploymentId = [ServiceDeploymentId] = 
					case when (@serviceDeploymentId is null)
						then [ServiceDeploymentId]
						else @serviceDeploymentId 
					end,
			@pendingTimer = [PendingTimer] = 
					case when (@metadataUpdateOnly = 1)
						then [PendingTimer]
						else [System.Activities.DurableInstancing].[GetExpirationTime](@timerDurationMilliseconds)
					end,
			@isReadyToRun = [IsReadyToRun] = 
					case when (@metadataUpdateOnly = 1)
						then [IsReadyToRun]
						else @isReadyToRun
					end,
			@isSuspended = [IsSuspended] = 
					case when (@suspensionStateChange = 0) then [IsSuspended]
						 when (@suspensionStateChange = 1) then 1
						 else 0
					end,
			[SurrogateLockOwnerId] = case when (@unlockInstance = 1 or @isCompleted = 1)
										then null
										else @surrogateLockOwnerId
									 end,
			[PrimitiveDataProperties] = case when (@metadataUpdateOnly = 1)
										then [PrimitiveDataProperties]
										else @primitiveDataProperties
									   end,
			[ComplexDataProperties] = case when (@metadataUpdateOnly = 1)
										then [ComplexDataProperties]
										else @complexDataProperties
									   end,
			[WriteOnlyPrimitiveDataProperties] = case when (@metadataUpdateOnly = 1)
										then [WriteOnlyPrimitiveDataProperties]
										else @writeOnlyPrimitiveDataProperties
									   end,
			[WriteOnlyComplexDataProperties] = case when (@metadataUpdateOnly = 1)
										then [WriteOnlyComplexDataProperties]
										else @writeOnlyComplexDataProperties
									   end,
			[MetadataProperties] = case
									 when (@metadataIsConsistent = 1) then @metadataProperties
									 else [MetadataProperties]
								   end,
			[SuspensionReason] = case
									when (@suspensionStateChange = 0) then [SuspensionReason]
									when (@suspensionStateChange = 1) then @suspensionReason
									else null
								 end,
			[SuspensionExceptionName] = case
									when (@suspensionStateChange = 0) then [SuspensionExceptionName]
									when (@suspensionStateChange = 1) then @suspensionExceptionName
									else null
								 end,
			[IsCompleted] = @isCompleted,
			[IsInitialized] = case
								when (@metadataUpdateOnly = 0) then 1
								else [IsInitialized]
							  end,
			[DataEncodingOption] = case
									when (@metadataUpdateOnly = 0) then @encodingOption
									else [DataEncodingOption]
								   end,
			[MetadataEncodingOption] = case
									when (@metadataIsConsistent = 1) then @encodingOption
									else [MetadataEncodingOption]
								   end,
			[BlockingBookmarks] = case
									when (@metadataUpdateOnly = 0) then @blockingBookmarks
									else [BlockingBookmarks]
								  end,
			[LastUpdated] = @now,
			[LastMachineRunOn] = case
									when (@metadataUpdateOnly = 0) then @lastMachineRunOn
									else [LastMachineRunOn]
								 end,
			[ExecutionStatus] = case
									when (@metadataUpdateOnly = 0) then @executionStatus
									else [ExecutionStatus]
								end
		from [InstancesTable]		
		where ([InstancesTable].[SurrogateInstanceId] = @surrogateInstanceId)
	
		if (@@rowcount = 0)
		begin
			set @result = 99
			select @result as 'Result' 
		end
		else
		begin
			if (@keysToAssociate is not null or @singleKeyId is not null)
				exec @result = [System.Activities.DurableInstancing].[AssociateKeys] @surrogateInstanceId, @keysToAssociate, @concatenatedKeyProperties, @encodingOption, @singleKeyId
			
			if (@result = 0 and @keysToComplete is not null)
				exec @result = [System.Activities.DurableInstancing].[CompleteKeys] @surrogateInstanceId, @keysToComplete
			
			if (@result = 0 and @keysToFree is not null)
				exec @result = [System.Activities.DurableInstancing].[FreeKeys] @surrogateInstanceId, @keysToFree
			
			if (@result = 0) and (@metadataUpdateOnly = 0)
			begin
				delete from [InstancePromotedPropertiesTable]
				where [SurrogateInstanceId] = @surrogateInstanceId
			end
			
			if (@result = 0)
			begin
				if (@metadataIsConsistent = 1)
				begin
					delete from [InstanceMetadataChangesTable]
					where [SurrogateInstanceId] = @surrogateInstanceId
				end
				else if (@metadataProperties is not null)
				begin
					insert into [InstanceMetadataChangesTable] ([SurrogateInstanceId], [EncodingOption], [Change])
					values (@surrogateInstanceId, @encodingOption, @metadataProperties)
				end
			end
			
			if (@result = 0 and @unlockInstance = 1 and @isCompleted = 0)
				exec [System.Activities.DurableInstancing].[InsertRunnableInstanceEntry] @surrogateInstanceId, @workflowHostType, @serviceDeploymentId, @isSuspended, @isReadyToRun, @pendingTimer				
		end
	end

Finally:
	if (@result != 13)
		exec sp_releaseapplock @Resource = 'InstanceStoreLock'
	
	if (@result = 0)
		select @result as 'Result', @currentInstanceVersion

	return @result
end
go

grant execute on [System.Activities.DurableInstancing].[SaveInstance] to [System.Activities.DurableInstancing.InstanceStoreUsers] 
go

if exists (select * from sys.triggers where object_id = OBJECT_ID(N'[System.Activities.DurableInstancing].[DeleteServiceDeploymentTrigger]'))
	drop trigger [System.Activities.DurableInstancing].[DeleteServiceDeploymentTrigger]
go

create trigger [System.Activities.DurableInstancing].[DeleteServiceDeploymentTrigger] on [System.Activities.DurableInstancing].[ServiceDeployments]
instead of delete
as
begin	
	if (@@rowcount = 0)
		return	
		
	set nocount on
	set transaction isolation level read committed		
	set xact_abort on;	
	
	declare @lockAcquired bigint
	declare @candidateDeploymentIdsPass1 table([Id] bigint primary key)
	
	exec @lockAcquired = sp_getapplock @Resource = 'InstanceStoreLock', @LockMode = 'Exclusive', @LockTimeout = 25000
	
	if (@lockAcquired < 0)
		return

	insert into @candidateDeploymentIdsPass1
	select [ServiceDeploymentId] from deleted
	except
	select [ServiceDeploymentId] from [InstancesTable]
	
	delete [ServiceDeploymentsTable]
	from [ServiceDeploymentsTable]
	join @candidateDeploymentIdsPass1 as [OrphanedIds] on [OrphanedIds].[Id] = [ServiceDeploymentsTable].[Id]
	
	exec sp_releaseapplock @Resource = 'InstanceStoreLock'
end
go	

if exists (select * from sys.objects where object_id = object_id(N'[System.Activities.DurableInstancing].[InsertPromotedProperties]') and type in (N'P', N'PC'))
	drop procedure [System.Activities.DurableInstancing].[InsertPromotedProperties]
go

create procedure [System.Activities.DurableInstancing].[InsertPromotedProperties]
	@instanceId uniqueidentifier,
	@promotionName nvarchar(400),
	@value1 sql_variant = null,
	@value2 sql_variant = null,
	@value3 sql_variant = null,
	@value4 sql_variant = null,
	@value5 sql_variant = null,
	@value6 sql_variant = null,
	@value7 sql_variant = null,
	@value8 sql_variant = null,
	@value9 sql_variant = null,
	@value10 sql_variant = null,
	@value11 sql_variant = null,
	@value12 sql_variant = null,
	@value13 sql_variant = null,
	@value14 sql_variant = null,
	@value15 sql_variant = null,
	@value16 sql_variant = null,
	@value17 sql_variant = null,
	@value18 sql_variant = null,
	@value19 sql_variant = null,
	@value20 sql_variant = null,
	@value21 sql_variant = null,
	@value22 sql_variant = null,
	@value23 sql_variant = null,
	@value24 sql_variant = null,
	@value25 sql_variant = null,
	@value26 sql_variant = null,
	@value27 sql_variant = null,
	@value28 sql_variant = null,
	@value29 sql_variant = null,
	@value30 sql_variant = null,
	@value31 sql_variant = null,
	@value32 sql_variant = null,
	@value33 varbinary(max) = null,
	@value34 varbinary(max) = null,
	@value35 varbinary(max) = null,
	@value36 varbinary(max) = null,
	@value37 varbinary(max) = null,
	@value38 varbinary(max) = null,
	@value39 varbinary(max) = null,
	@value40 varbinary(max) = null,
	@value41 varbinary(max) = null,
	@value42 varbinary(max) = null,
	@value43 varbinary(max) = null,
	@value44 varbinary(max) = null,
	@value45 varbinary(max) = null,
	@value46 varbinary(max) = null,
	@value47 varbinary(max) = null,
	@value48 varbinary(max) = null,
	@value49 varbinary(max) = null,
	@value50 varbinary(max) = null,
	@value51 varbinary(max) = null,
	@value52 varbinary(max) = null,
	@value53 varbinary(max) = null,
	@value54 varbinary(max) = null,
	@value55 varbinary(max) = null,
	@value56 varbinary(max) = null,
	@value57 varbinary(max) = null,
	@value58 varbinary(max) = null,
	@value59 varbinary(max) = null,
	@value60 varbinary(max) = null,
	@value61 varbinary(max) = null,
	@value62 varbinary(max) = null,
	@value63 varbinary(max) = null,
	@value64 varbinary(max) = null
as
begin
	set nocount on
	set transaction isolation level read committed		
	set xact_abort on;	

	declare @surrogateInstanceId bigint

	select @surrogateInstanceId = [SurrogateInstanceId]
	from [InstancesTable]
	where [Id] = @instanceId

	insert into [System.Activities.DurableInstancing].[InstancePromotedPropertiesTable]
	values (@surrogateInstanceId, @promotionName, @value1, @value2, @value3, @value4, @value5, @value6, @value7, @value8,
			@value9, @value10, @value11, @value12, @value13, @value14, @value15, @value16, @value17, @value18, @value19,
			@value20, @value21, @value22, @value23, @value24, @value25, @value26, @value27, @value28, @value29, @value30,
			@value31, @value32, @value33, @value34, @value35, @value36, @value37, @value38, @value39, @value40, @value41,
			@value42, @value43, @value44, @value45, @value46, @value47, @value48, @value49, @value50, @value51, @value52,
			@value53, @value54, @value55, @value56, @value57, @value58, @value59, @value60, @value61, @value62, @value63,
			@value64)
end
go

grant execute on [System.Activities.DurableInstancing].[InsertPromotedProperties] to [System.Activities.DurableInstancing.InstanceStoreUsers]
go


-- 创建存储应用数据的表
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
