CREATE TABLE [dbo].[Driver]
(
	[id] int PRIMARY KEY IDENTITY(1,1),
	[HelmetImage] image NOT NULL,
	[FullImage] image NOT NULL,
	[FullName] varchar(100) NOT NULL default '',
	[Number] int UNIQUE NOT NULL,
	[TeamId] int NOT NULL,
	[Podiums] int NOT NULL,
	[CountryCode] char(2) NOT NULL ,
	[Dob] date,
);

INSERT INTO [Driver]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'Alexander Albon',
		23,
		7,
		1,
		'TH',
		CONVERT(date,'1996-03-23')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'Antonio Giovinazzi',
		99,
		1,
		0,
		'IT',
		CONVERT(date,'1993-12-14')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'Lewis Hamilton',
		44,
		6,
		159,
		'GB',
		CONVERT(date,'1985-01-07')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'Lando Norris',
		4,
		5,
		1,
		'GB',
		CONVERT(date,'1999-11-13')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'George Russel',
		63,
		10,
		0,
		'GB',
		CONVERT(date,'1998-02-15')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'Valtteri Bottas',
		77,
		6,
		53,
		'FI',
		CONVERT(date,'1989-08-28')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'Danil Kvyat',
		26,
		2,
		3,
		'RU',
		CONVERT(date,'1994-04-26')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'Esteban Ocon',
		31,
		8,
		0,
		'FR',
		CONVERT(date,'1996-09-17')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'Carlos Sainz',
		55,
		5,
		2,
		'ES',
		CONVERT(date,'1994-09-01')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'Pierre Gasly',
		10,
		2,
		2,
		'FR',
		CONVERT(date,'1996-02-07')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'Nicholas Latifi',
		6,
		10,
		0,
		'CA',
		CONVERT(date,'1995-06-29')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'Sergio Perez',
		11,
		9,
		8,
		'MX',
		CONVERT(date,'1990-01-26')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'Lance Stroll',
		18,
		9,
		2,
		'CA',
		CONVERT(date,'1996-03-23')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'Charles Leclerc',
		16,
		3,
		12,
		'MC',
		CONVERT(date,'1997-10-16')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'Kimi Raikkonen',
		7,
		1,
		103,
		'FI',
		CONVERT(date,'1979-10-17')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'Max Verstappen',
		33,
		7,
		38,
		'NL',
		CONVERT(date,'1997-09-30')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'Romain Grosjean',
		8,
		4,
		10,
		'FR',
		CONVERT(date,'1986-04-17')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'Kevin Magnussen',
		20,
		4,
		1,
		'DK',
		CONVERT(date,'1992-10-05')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'Daniel Ricciardo',
		3,
		8,
		29,
		'AU',
		CONVERT(date,'1989-07-01')
);
INSERT INTO [Driver]
VALUES(
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'C:\\data\\formulaOne\\img\\immagine.jpg',
		'Sebastian Vettel',
		5,
		3,
		120,
		'DE',
		CONVERT(date,'1987-07-03')
);