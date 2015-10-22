# IconKeeper
Rest, WebApi, Swagger, Selfhost, LightInject.

## Database setup
You will need MySQL Workbench: https://www.mysql.com/products/workbench/

Your only table will be

Id (INT autoincrement) PK  | GuidString (String) |Path (String) |Description (String) |Height (INT) |Width (INT) |Tag (String) |Downloads (INT) |
-------------------------- | --------------------|--------------|---------------------|-------------|------------|-------------|----------------|

The database connection string is located in AppSettingsConfiguration.cs edit this string at your need.

## Run
Build and run the solution, open a browser and enter http://localhost:9878/swagger/ui/index
