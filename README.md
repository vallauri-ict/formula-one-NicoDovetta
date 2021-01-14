# FORMULA ONE PROJECT (C# .NET FRAMEWORK 4.8)
## DOVETTA NICOLAS - 5^B Informatica A.S. 2020/2021
## I.I.S. "G. Vallauri" - Fossano (CN)

To make it function the "data" folder needs to be put into C: volume.

### 1. Database scheme

![dbShceme](/dbScheme.PNG)

### 2. Console application
  Serve the purpose of manage the DataBase. Implement the options of:
  * Create table: for all the table in the database you  will find a row in the CLI for create it;

  * Show table (beta version): displays all the element in the selectted table and use the method String.Format() to have some kind of table. If your screen resolution    is too slmall to display it all it make a mess and it will not display the images;

  * Create DB backup: create a backup of the current database state. The name is the current date or a personalized one. If it founds already a file with that name it will continue asking for the name or as if you want to overwrite it (with the date function);

  * Restore DB backup: first it displays all the backup present in the database backup folder, than it ask for the name and procede to restore the backup;

  * Set relations: makes the table relations on the foreign keys. If there are not all the table in the database it will throw an error and then it will continue;

  * Remove relations: Delete the table relations on the foreign keys. If there are not all the table or relations in the database it will throw an error and then it will continue;


### 3. WebApplication_F1 (asp .NET)

First it load all the table name in a selectBox. On the change of the selectBox selected index it will automatically send the page to the server with the new element selected and the server will fill a table with all the element in the table.


### 4. dll_Utilities

  1. Utils_Database.cs: contains all the functions ot method that will interact with the database.


https://docs.microsoft.com/it-it/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.0&tabs=visual-studio
