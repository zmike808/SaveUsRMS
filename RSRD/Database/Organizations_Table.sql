CREATE TABLE `Organizations` (
  `id` int(11) NOT NULL auto_increment,
  `name` text,
  `address` text,
  `phone` text,
  `email` text,
  `fax` text,
  `website` text,
  `aboutus` text,
  `hours` text,
  `servicesprovided` text,
  `logo` blob,
  PRIMARY KEY  (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
