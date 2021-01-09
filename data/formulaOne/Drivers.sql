CREATE TABLE [dbo].[Drivers]
(
	[Driver_id] int PRIMARY KEY,
	[CountryCode] char(2) NOT NULL ,
	[HelmetImage] image NOT NULL,
	[FullImage] image NOT NULL,
	[FullName] varchar(100) NOT NULL default '',
	[Podiums] int NOT NULL default 0,
	[Points] int default 0,
	[Dob] date,
	[Pob] varchar(150) NOT NULL default ''
);

SET DATEFORMAT dmy;

INSERT INTO [Drivers]
VALUES(
	98091300,
	'TH',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Albon_Helmet.png',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Alezander_Albon.jpg',
	'Alexander Albon',
	2,
	197,
	CONVERT(date,'1996-03-23'),
	'London'
);
INSERT INTO [Drivers]
VALUES(
	98091301,
	'IT',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Giovinazzi_Helmet.png',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Antonio_Giovinazzi.jpg',
	'Antonio Giovinazzi',
	18,
	0,
	CONVERT(date,'1993-12-14'),
	'Martina Franca'
);
INSERT INTO [Drivers]
VALUES(
	98091302,
	'GB',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Hamilton_Helmet.png',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Lewis_Hamilton.jpg',
	'Lewis Hamilton',
	165,
	3778,
	CONVERT(date,'1985-01-07'),
	'Stevenage'
);
INSERT INTO [Drivers]
VALUES(
	98091303,
	'GB',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Norris_Helmet.png',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Lando_Norris.jpg',
	'Lando Norris',
	1,
	146,
	CONVERT(date,'1999-11-13'),
	'Bristol'
);
INSERT INTO [Drivers]
VALUES(
	98091304,
	'GB',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Russle_Helmet.png',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\George_Russel.jpg',
	'George Russel',
	0,
	3,
	CONVERT(date,'1998-02-15'),
	'Kings Lynn'
);
INSERT INTO [Drivers]
VALUES(
	98091305,
	'FI',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Bottas_Helmet.png',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Valtteri_Bottas.jpg',
	'Valtteri Bottas',
	56,
	1512,
	CONVERT(date,'1989-08-28'),
	'Nastola'
);
INSERT INTO [Drivers]
VALUES(
	98091306,
	'RU',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Kvyat_Helmet.png',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Daniil_Kvyat.jpg',
	'Daniil Kvyat',
	3,
	202,
	CONVERT(date,'1994-04-26'),
	'Ufa'
);
INSERT INTO [Drivers]
VALUES(
	98091307,
	'FR',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Ocon_Helmet.png',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Esteban_Ocon.jpg',
	'Esteban Ocon',
	1,
	198,
	CONVERT(date,'1996-09-17'),
	'Évreux'
);
INSERT INTO [Drivers]
VALUES(
	98091308,
	'ES',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Sainz_Helmet.png',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Carlos_Sainz.jpg',
	'Carlos Sainz',
	2,
	372,
	CONVERT(date,'1994-09-01'),
	'Madrid'
);
INSERT INTO [Drivers]
VALUES(
	98091309,
	'FR',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Gasly_Helmet.png',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Pierre_Gasly.jpg',
	'Pierre Gasly',
	2,
	199,
	CONVERT(date,'1996-02-07'),
	'Rouen'
);
INSERT INTO [Drivers]
VALUES(
	98091310,
	'CA',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Latifi_Helmet.png',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Nicholas_Latifi.jpg',
	'Nicholas Latifi',
	0,
	17,
	CONVERT(date,'1995-06-29'),
	'Montreal'
);
INSERT INTO [Drivers]
VALUES(
	98091311,
	'MX',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Perez_Helmet.png',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Sergio_Perez.jpg',
	'Sergio Perez',
	10,
	706,
	CONVERT(date,'1990-01-26'),
	'Guadalajara'
);
INSERT INTO [Drivers]
VALUES(
	98091312,
	'CA',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Stroll_Helmet.png',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Lance_Stroll.jpg',
	'Lance Stroll',
	3,
	142,
	CONVERT(date,'1996-03-23'),
	'Montreal'
);
INSERT INTO [Drivers]
VALUES(
	98091313,
	'MC',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Leclerc_Helmet.png',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Charles_Leclerc.jpg',
	'Charles Leclerc',
	12,
	401,
	CONVERT(date,'1997-10-16'),
	'Monte Carlo'
);
INSERT INTO [Drivers]
VALUES(
	98091314,
	'FI',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Raikkonen_Helmet.png',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Kimi_Raicconen.jpg',
	'Kimi Räikkönen',
	103,
	1863,
	CONVERT(date,'1979-10-17'),
	'Espoo'
);
INSERT INTO [Drivers]
VALUES(
	98091315,
	'NL',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Verstappen_Helmet.png',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Max_Verstappen.jpg',
	'Max Verstappen',
	42,
	1162,
	CONVERT(date,'1997-09-30'),
	'Hasselt'
);
INSERT INTO [Drivers]
VALUES(
	98091316,
	'FR',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Grosjean_Helmet.png',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Romain_Grosjean.jpg',
	'Romain Grosjean',
	10,
	391,
	CONVERT(date,'1986-04-17'),
	'Geneva'
);
INSERT INTO [Drivers]
VALUES(
	98091317,
	'DK',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Magnussen_Helmet.png',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Kevin_Magnussen.jpg',
	'Kevin Magnussen',
	1,
	158,
	CONVERT(date,'1992-10-05'),
	'Roskilde'
);
INSERT INTO [Drivers]
VALUES(
	98091318,
	'AU',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Ricciardo_Helmet.png',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Daniel_Ricciardo.jpg',
	'Daniel Ricciardo',
	31,
	1159,
	CONVERT(date,'1989-07-01'),
	'Perth'
);
INSERT INTO [Drivers]
VALUES(
	98091319,
	'DE',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Vettel_Helmet.png',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Sebastian_Vettel.jpg',
	'Sebastian Vettel',
	121,
	3018,
	CONVERT(date,'1987-07-03'),
	'Heppenheim'
);
INSERT INTO [Drivers]
VALUES(
	98091320,
	'nn',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Helmet.png',
	'C:\\data\\formulaOne\\img\\Driver_Stuff\\Person.png',
	'Pietro Fittipaldi',
	0,
	0,
	CONVERT(date,'1996-06-25'),
	'n/a'
);