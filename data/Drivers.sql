CREATE TABLE [dbo].[Driver] (
[DriverCode] int identity(1,1) NOT NULL default '',
[DriverName] varchar(100) NOT NULL default '',
[DriverSurnName] varchar(100) NOT NULL default '',
[DriverBirthDate] date NOT NULL,
[DriverBirthPlace] varchar(100) NOT NULL default '',
PRIMARY KEY ([DriverCode])
);

INSERT INTO [Driver] VALUES ('Lewis','Hamilton',07/01/1985,'Stevenage, England');