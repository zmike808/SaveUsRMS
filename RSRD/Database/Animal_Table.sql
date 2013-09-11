CREATE TABLE IF NOT EXISTS `animal` (  `ID` int(11) NOT NULL AUTO_INCREMENT,  `name` text,  `DateofBirth` datetime DEFAULT NULL,  `image` longblob,  `estimate` tinyint(1) DEFAULT NULL,  `vaccination` datetime DEFAULT NULL,  `sterilized` tinyint(1) DEFAULT NULL,  `female` tinyint(1) DEFAULT NULL,  `color` text,  `size` text,  `breed` text,  `crossbreed` text,  `location` text,  `owner` text,  `notes` text,  `species` text,  `status` text,  PRIMARY KEY (`ID`)) ENGINE=InnoDB AUTO_INCREMENT=372 DEFAULT CHARSET=utf8;