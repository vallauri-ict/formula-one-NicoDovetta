CREATE TABLE [dbo].[Teams]
(
	[Team_id] int PRIMARY KEY,
	[Driver1] int unique NOT NULL,
	[Driver2] int unique NOT NULL,
	[SmallName] varchar(100) NOT NULL default '',
	[FullName] varchar(100) UNIQUE NOT NULL default '',
	[SmallLogo] image NOT NULL default '',
	[FullLogo] image NOT NULL default '',
	[CarImage] image NOT NULL default '',
	[Base] varchar(100) NOT NULL default '',
	[Country_Code] char(2) not null,
	[TeamChief] varchar(100) NOT NULL default '',
	[PowerUnit] varchar(100) NOT NULL default '',
	[WorldChampionships] int default 0
);

INSERT INTO [Teams]
VALUES(
	10819900,
	98091314,
	98091301,
	'Alfa Romeo Racing ORLEN',
	'Alfa Romeo',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\Alfa_Romeo\\Small_Logo.png',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\Alfa_Romeo\\Full_Logo.jpg',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\Alfa_Romeo\\Car.png',
	'Hinwil',
	'CH',
	'Frédéric Vasseur',
	'Ferrari',
	0
);
INSERT INTO [Teams]
VALUES(
	10819901,
	98091306,
	98091309,
	'Scuderia AlphaTauri Honda',
	'Alphatauri',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\Alphatauri\\Small_Logo.png',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\Alphatauri\\Full_Logo.jpg',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\Alphatauri\\Car.png',
	'Faenza',
	'IT',
	'Franz Tost',
	'Honda',
	0
);
INSERT INTO [Teams]
VALUES(
	10819902,
	98091313,
	98091319,
	'Scuderia Ferrari Mission Winnow',
	'Ferrari',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\Ferrari\\Small_Logo.png',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\Ferrari\\Full_Logo.jpg',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\Ferrari\\Car.png',
	'Maranello',
	'IT',
	'Mattia Binotto',
	'Ferrari',
	16
);
INSERT INTO [Teams]
VALUES(
	10819903,
	98091317,
	98091320,
	'Haas F1 Team',
	'Haas',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\Haas\\Small_Logo.png',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\Haas\\Full_Logo.jpg',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\Haas\\Car.png',
	'Kannapolis',
	'US',
	'Guenther Steiner',
	'Ferrari',
	0
);
INSERT INTO [Teams]
VALUES(
	10819904,
	98091308,
	98091303,
	'McLaren F1 Team',
	'McLaren',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\McLaren\\Small_Logo.png',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\McLaren\\Full_Logo.jpg',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\McLaren\\Car.png',
	'Woking',
	'GB',
	'Andreas Seidl',
	'Renault',
	8
);
INSERT INTO [Teams]
VALUES(
	10819905,
	98091305,
	98091302,
	'Mercedes-AMG Petronas F1 Team',
	'Mercedes',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\Mercedes\\Small_Logo.png',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\Mercedes\\Full_Logo.jpg',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\Mercedes\\Car.png',
	'Brackley',
	'GB',
	'Toto Wolff',
	'Mercedes',
	7
);
INSERT INTO [Teams]
VALUES(
	10819906,
	98091315,
	98091300,
	'Aston Martin Red Bull Racing',
	'Red Bull Racing',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\Red_Bull\\Small_Logo.png',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\Red_Bull\\Full_Logo.jpg',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\Red_Bull\\Car.png',
	'Milton Keynes',
	'GB',
	'Christian Horner',
	'Honda',
	4
);
INSERT INTO [Teams]
VALUES(
	10819907,
	98091318,
	98091307,
	'Renault DP World F1 Team',
	'Renault',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\Renault\\Small_Logo.png',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\Renault\\Full_Logo.jpg',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\Renault\\Car.png',
	'Enstone',
	'GB',
	'Cyril Abiteboul',
	'Renault',
	2
);

INSERT INTO [Teams]
VALUES(
	10819908,
	98091311,
	98091312,
	'BWT Racing Point F1 Team',
	'Racing Point',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\Racing_Point\\Small_Logo.png',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\Racing_Point\\Full_Logo.jpg',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\Racing_Point\\Full_Logo.png',
	'Silverstone',
	'GB',
	'Otmar Szafnauer',
	'Mercedes',
	0
);

INSERT INTO [Teams]
VALUES(
	10819909,
	98091310,
	98091304,
	'Williams Racing',
	'Williams',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\Alfa_Romeo\\Small_Logo.png',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\Alfa_Romeo\\Full_Logo.jpg',
	'C:\\data\\formulaOne\\img\\Team_Stuff\\Alfa_Romeo\\Full_Logo.png',
	'Grove',
	'GB',
	'Simon Roberts',
	'Mercedes',
	9
);