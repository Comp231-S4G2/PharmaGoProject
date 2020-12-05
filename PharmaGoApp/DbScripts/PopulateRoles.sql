USE GPADb
INSERT INTO [dbo].[AspNetRoles]
           ([Id]
           ,[Name]
           ,[NormalizedName]
           ,[ConcurrencyStamp])
     VALUES
           (NEWID()
           ,'Admin'
           ,'ADMIN'
           ,NEWID())
GO
INSERT INTO [dbo].[AspNetRoles]
           ([Id]
           ,[Name]
           ,[NormalizedName]
           ,[ConcurrencyStamp])
     VALUES
           (NEWID()
           ,'Customer'
           ,'CUSTOMER'
           ,NEWID())
GO
INSERT INTO [dbo].[AspNetRoles]
           ([Id]
           ,[Name]
           ,[NormalizedName]
           ,[ConcurrencyStamp])
     VALUES
           (NEWID()
           ,'Pharmacist'
           ,'PHARMACIST'
           ,NEWID())
GO
INSERT INTO [dbo].[AspNetRoles]
           ([Id]
           ,[Name]
           ,[NormalizedName]
           ,[ConcurrencyStamp])
     VALUES
           (NEWID()
           ,'AsstPharmacist'
           ,'ASSTPHARMACIST'
           ,NEWID())
GO