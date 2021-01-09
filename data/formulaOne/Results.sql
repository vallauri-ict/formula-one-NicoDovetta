CREATE TABLE [dbo].[Results]
(
	[Result_id] int PRIMARY KEY,
	[Race_id] int,
	[Driver_id] int,
    [FastestLap] datetime,
    [Position] char(5)
);