---------
Chapter 9
---------
XBAP projects have a hard-coded debug path. In order to successfully test the XBAP project on your computer, double-click Properties in the Solution Explorer, choose the Debug section, and update the path in the "Command-line arguments" text box.

----------------------
Chapter 16, 17, and 18
----------------------
The DataBinding projects use the StoreDatabase class library. It requires a SQL Server database named Store, which you can install using the store.sql script.

Alternatively, you can test the database examples using a "simulated" approach that retrieves the same data from an XML file. To use this approach, rename the StoreDatabase folder to something else, and rename the StoreDatabaseFileBased folder to StoreDatabase. Now the projects will use this alternate version of the StoreDatabase component.
