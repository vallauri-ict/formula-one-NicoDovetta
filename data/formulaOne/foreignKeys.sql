ALTER TABLE [dbo].[Drivers]  WITH CHECK ADD CONSTRAINT [REL_DriversCountries] FOREIGN KEY([CountryCode])
REFERENCES [dbo].[Countries] ([CountryCode]);

ALTER TABLE [dbo].[Teams]  WITH CHECK ADD CONSTRAINT [REL_TeamsCountries] FOREIGN KEY([CountryCode])
REFERENCES [dbo].[Countries] ([CountryCode]);

ALTER TABLE [dbo].[Teams]  WITH CHECK ADD CONSTRAINT [REL_TeamsDrivers_First] FOREIGN KEY([Driver1])
REFERENCES [dbo].[Drivers] ([Driver_id]);
ALTER TABLE [dbo].[Teams]  WITH CHECK ADD CONSTRAINT [REL_TeamsDrivers_Second] FOREIGN KEY([Driver2])
REFERENCES [dbo].[Drivers] ([Driver_id]);

ALTER TABLE [dbo].[Circuits]  WITH CHECK ADD CONSTRAINT [REL_CircuitsCountryes] FOREIGN KEY([CountryCode])
REFERENCES [dbo].[Countries] ([CountryCode]);

ALTER TABLE [dbo].[Races]  WITH CHECK ADD CONSTRAINT [REL_CircuitsRaces] FOREIGN KEY([Circuit_id])
REFERENCES [dbo].[Circuits] ([Circuit_id]);

ALTER TABLE [dbo].[Results]  WITH CHECK ADD CONSTRAINT [REL_RacesResults] FOREIGN KEY([Race_id])
REFERENCES [dbo].[Races] ([Race_id]);
ALTER TABLE [dbo].[Results]  WITH CHECK ADD CONSTRAINT [REL_DriversResults] FOREIGN KEY([Driver_id])
REFERENCES [dbo].[Drivers] ([Driver_id]);