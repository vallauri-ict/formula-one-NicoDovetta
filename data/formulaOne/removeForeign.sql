ALTER TABLE [dbo].[Drivers]  DROP CONSTRAINT [REL_DriversCountries];

ALTER TABLE [dbo].[Teams]  DROP CONSTRAINT [REL_TeamsCountries];

ALTER TABLE [dbo].[Teams]  DROP CONSTRAINT [REL_TeamsDrivers_First];
ALTER TABLE [dbo].[Teams]  DROP CONSTRAINT [REL_TeamsDrivers_Second];

ALTER TABLE [dbo].[Circuits]  DROP CONSTRAINT [REL_CircuitsCountryes];

ALTER TABLE [dbo].[Races]  DROP CONSTRAINT [REL_CircuitsRaces];

ALTER TABLE [dbo].[Results]  DROP CONSTRAINT [REL_RacesResults];
ALTER TABLE [dbo].[Results]  DROP CONSTRAINT [REL_DriversResults];