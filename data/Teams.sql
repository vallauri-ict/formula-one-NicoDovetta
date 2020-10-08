CREATE TABLE [dbo].[Team] (
[TeamId] int identity(1,1) NOT NULL,
[TeamShortName] varchar(100) NOT NULL default '',
[TeamLongName] varchar(100) NOT NULL default '',
[TeamChief] varchar(100) NOT NULL default '',
[PowerUnit] varchar(100) NOT NULL default '',
[ShortName] varchar(100) NOT NULL default '',
[CarChassis] varchar(100) NOT NULL default '',
[CarColor] varchar(100) NOT NULL default '',
[TeamShortLogo] varchar(100) NOT NULL default '',
[TeamExplicitLogo] varchar(100) NOT NULL default '',
PRIMARY KEY ([TeamId])
);