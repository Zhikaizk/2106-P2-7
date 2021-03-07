DROP TABLE IF EXISTS feedback;
CREATE TABLE `feedback` (
  `feedbackId` int(11) NOT NULL,
  `household_email` varchar(45) NOT NULL,
  `feedbackType` varchar(45) NOT NULL,
  `feedbackContent` varchar(45) NOT NULL,
  `feedbackStatus` varchar(45) NOT NULL,
  PRIMARY KEY (`feedbackId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;










