CREATE TABLE [dbo].[Team]
(
	[id] int PRIMARY KEY IDENTITY(1,1),
	[SmallLogo] image NOT NULL default '',
	[FullLogo] image NOT NULL default '',
	[CarImage] image NOT NULL default '',
	[Color] varchar(100) NOT NULL default '',
	[SmallName] varchar(100) NOT NULL default '',
	[FullName] varchar(100) UNIQUE NOT NULL default '',
	[Base] varchar(100) NOT NULL default '',
	[TeamChief] varchar(100) NOT NULL default '',
	[PowerUnit] varchar(100) NOT NULL default '',
	[CountryCode] char(2) NOT NULL default '',
	[WorldChampionships] int default 0,
);

INSERT INTO [Team]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'#960000',
		'Alfa Romeo Racing ORLEN',
		'Alfa Romeo',
		'Hinwil',
		'Frédéric Vasseur',
		'Ferrari',
		'CH',
		0        
);
INSERT INTO [Team]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'#FFFFFF',
		'Scuderia AlphaTauri Honda',
		'Alphatauri',
		'Faenza',
		'Franz Tost',
		'Honda',
		'IT',
		0        
);
INSERT INTO [Team]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'#DC0000',
		'Scuderia Ferrari Mission Winnow',
		'Ferrari',
		'Maranello',
		'Mattia Binotto',
		'Ferrari',
		'IT',
		16       
);
INSERT INTO [Team]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'#787878',
		'Haas F1 Team',
		'Haas',
		'Kannapolis',
		'Guenther Steiner',
		'Ferrari',
		'US',
		0        
);
INSERT INTO [Team]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'#FF8700',
		'McLaren F1 Team',
		'McLaren',
		'Woking',
		'Andreas Seidl',
		'Renault',
		'GB',
		8        
);
INSERT INTO [Team]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'#00D2BE',
		'Mercedes-AMG Petronas F1 Team',
		'Mercedes',
		'Brackley',
		'Toto Wolff',
		'Mercedes',
		'GB',
		6       
);
INSERT INTO [Team]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'#0600EF',
		'Aston Martin Red Bull Racing',
		'Red Bull Racing',
		'Milton Keynes',
		'Christian Horner',
		'Honda',
		'GB',
		4        
);
INSERT INTO [Team]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'#FFF500',
		'Renault DP World F1 Team',
		'Renault',
		'Enstone',
		'Cyril Abiteboul',
		'Renault',
		'GB',
		2        
);

INSERT INTO [Team]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'#F596C8',
		'BWT Racing Point F1 Team',
		'Racing Point',
		'Silverstone',
		'Otmar Szafnauer',
		'Mercedes',
		'GB',
		0        
);

INSERT INTO [Team]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'#0082FA',
		'Williams Racing',
		'Williams',
		'Grove',
		'Simon Roberts',
		'Mercedes',
		'GB',
		9        
);