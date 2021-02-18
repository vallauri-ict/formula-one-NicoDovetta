﻿SELECT t.Team_id, t.SmallName, (SELECT Drivers.FullName From Drivers, Teams as t Where Drivers.Driver_id LIKE t.Driver1) as Driver1, (SELECT Drivers.FullName From Drivers, Teams as t Where Drivers.Driver_id LIKE t.Driver2) as Driver2, t.SmallLogo
FROM Teams as t;