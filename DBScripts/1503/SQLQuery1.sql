/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP 1000 [Id]
      ,[UserName]
      ,[MobilePhone]
      ,[About]
      ,[Password]
      ,[StatusCurrent]
      ,[TimeOnline]
  FROM [DBNetwork].[dbo].[User]

  delete from [dbo].[User] where Id = 9