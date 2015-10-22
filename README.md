# IconKeeper
Rest, WebApi, Swagger, Selfhost, LightInject.

## Database setup
You will need MySQL Workbench: https://www.mysql.com/products/workbench/

Your only table will be

```
CREATE TABLE `icon` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `GuidString` varchar(255) NOT NULL,
  `Title` varchar(255) NOT NULL,
  `Path` varchar(9001) NOT NULL,
  `Description` varchar(1000) DEFAULT NULL,
  `Height` int(11) NOT NULL,
  `Width` int(11) NOT NULL,
  `Tag` varchar(1000) DEFAULT NULL,
  `Downloads` int(11) DEFAULT '0',
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Guid_UNIQUE` (`GuidString`)
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
```

The database connection string is located in AppSettingsConfiguration.cs edit this string at your need.

## Run
Build and run the solution, open a browser and enter http://localhost:9878/swagger/ui/index
