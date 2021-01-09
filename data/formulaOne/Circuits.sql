CREATE TABLE [dbo].[Circuits]
(
	[Circuit_id] int PRIMARY KEY,
	[CountryCode] char(2),
	[Place] varchar(100) not null default 'Circuit Place',
	[Name] varchar(100) not null default 'Circuit Name',
	[Laps] int not null default 10
);

INSERT INTO [Circuits]
VALUES(
	97105500,
	'AT',
	'Spielberg',
	'Red Bull Ring',
	71
);
INSERT INTO [Circuits]
VALUES(
	97105501,
	'HU',
	'Hungaroring',
	'Mogyrod',
	70
);
INSERT INTO [Circuits]
VALUES(
	97105502,
	'GB',
	'Silverstone',
	'Silverstone Circuit',
	52
);
INSERT INTO [Circuits]
VALUES(
	97105503,
	'ES',
	'Barcellona',
	'Circuit de Barcelona - Catalunya',
	66
);
INSERT INTO [Circuits]
VALUES(
	97105504,
	'IT',
	'Monza',
	'Autodromo Nazionale di Monza',
	53
);
INSERT INTO [Circuits]
VALUES(
	97105505,
	'IT',
	'Scarpiera',
	'Autodromo Interazionale del Mugello',
	59
);
INSERT INTO [Circuits]
VALUES(
	97105506,
	'RU',
	'Sochi',
	'Sochi Autodrom',
	53
);
INSERT INTO [Circuits]
VALUES(
	97105507,
	'DE',
	'Nürburg',
	'Nürburgring',
	60
);
INSERT INTO [Circuits]
VALUES(
	97105508,
	'PT',
	'Portimão',
	'Autódromo Internacional do Algarve',
	66
);
INSERT INTO [Circuits]
VALUES(
	97105509,
	'IT',
	'Imola',
	'Autodromo Enzo e Dino Ferrari',
	63
);
INSERT INTO [Circuits]
VALUES(
	97105510,
	'BH',
	'Sakhir',
	'Barhain International Circuit',
	57
);
INSERT INTO [Circuits]
VALUES(
	97105511,
	'BH',
	'Sakhir',
	'Barhain International Circuit - OT',
	87
);
INSERT INTO [Circuits]
VALUES(
	97105512,
	'AE',
	'Isola Yas',
	'Yas Marina Circuit',
	55
);