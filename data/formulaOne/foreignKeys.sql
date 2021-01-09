ALTER TABLE [dbo].[Driver]  WITH CHECK ADD CONSTRAINT [REL_DriverCountry] FOREIGN KEY([CountryCode])
REFERENCES [dbo].[Country] ([CountryCode])
ON UPDATE CASCADE;

ALTER TABLE [dbo].[Team]  WITH CHECK ADD CONSTRAINT [REL_TeamCountry] FOREIGN KEY([CountryCode])
REFERENCES [dbo].[Country] ([CountryCode])
ON UPDATE CASCADE;

ALTER TABLE [dbo].[Team]  WITH CHECK ADD CONSTRAINT [REL_TeamDriver_First] FOREIGN KEY([FirstDriverCode])
REFERENCES [dbo].[Driver] ([id])

ALTER TABLE [dbo].[Team]  WITH CHECK ADD CONSTRAINT [REL_TeamDriver_Second] FOREIGN KEY([SecondDriverCode])
REFERENCES [dbo].[Driver] ([id]);