SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";

--
-- Database: `construction_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `characteristics`
--

DROP TABLE IF EXISTS `characteristics`;
CREATE TABLE `characteristics` (
  `CharacteristicID` int NOT NULL AUTO_INCREMENT,
  `CharacteristicName` varchar(100) NOT NULL,
  `DataType` enum('INT','DECIMAL','VARCHAR','DATE') NOT NULL,
  PRIMARY KEY (`CharacteristicID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `characteristics`
--

INSERT INTO `characteristics` (`CharacteristicID`, `CharacteristicName`, `DataType`) VALUES
(1, 'Floors', 'INT'),
(2, 'MaterialType', 'VARCHAR'),
(3, 'ApartmentCount', 'INT'),
(4, 'SpanType', 'VARCHAR'),
(5, 'Width', 'DECIMAL'),
(6, 'LaneCount', 'INT'),
(7, 'RoadLength', 'DECIMAL'),
(8, 'BuildingArea', 'DECIMAL'),
(9, 'Capacity', 'INT'),
(10, 'FoundationType', 'VARCHAR');

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

DROP TABLE IF EXISTS `clients`;
CREATE TABLE `clients` (
  `ClientID` int NOT NULL AUTO_INCREMENT,
  `ClientName` varchar(100) NOT NULL,
  PRIMARY KEY (`ClientID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`ClientID`, `ClientName`) VALUES
(1, 'Nikita'),
(2, 'Никитоска'),
(3, 'ООО Заказчик');

-- --------------------------------------------------------

--
-- Table structure for table `crews`
--

DROP TABLE IF EXISTS `crews`;
CREATE TABLE `crews` (
  `CrewID` int NOT NULL AUTO_INCREMENT,
  `CrewName` varchar(100) NOT NULL,
  PRIMARY KEY (`CrewID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `crews`
--

INSERT INTO `crews` (`CrewID`, `CrewName`) VALUES
(1, 'Бригада №1'),
(2, 'Бригада №2');

-- --------------------------------------------------------

--
-- Table structure for table `equipment`
--

DROP TABLE IF EXISTS `equipment`;
CREATE TABLE `equipment` (
  `EquipmentID` int NOT NULL AUTO_INCREMENT,
  `EquipmentName` varchar(100) NOT NULL,
  PRIMARY KEY (`EquipmentID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `equipment`
--

INSERT INTO `equipment` (`EquipmentID`, `EquipmentName`) VALUES
(1, 'Экскаватор'),
(2, 'Бульдозер'),
(3, 'Кран башенный');

-- --------------------------------------------------------

--
-- Table structure for table `managements`
--

DROP TABLE IF EXISTS `managements`;
CREATE TABLE `managements` (
  `ManagementID` int NOT NULL AUTO_INCREMENT,
  `ManagementName` varchar(100) NOT NULL,
  PRIMARY KEY (`ManagementID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `managements`
--

INSERT INTO `managements` (`ManagementID`, `ManagementName`) VALUES
(1, 'Управление Центрального района'),
(2, 'Управление Северного района');

-- --------------------------------------------------------

--
-- Table structure for table `materials`
--

DROP TABLE IF EXISTS `materials`;
CREATE TABLE `materials` (
  `MaterialID` int NOT NULL AUTO_INCREMENT,
  `MaterialName` varchar(100) NOT NULL,
  PRIMARY KEY (`MaterialID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `materials`
--

INSERT INTO `materials` (`MaterialID`, `MaterialName`) VALUES
(1, 'Цемент'),
(2, 'Кирпич'),
(3, 'Трубы ПВХ'),
(4, 'Штукатурка');

-- --------------------------------------------------------

--
-- Table structure for table `positions`
--

DROP TABLE IF EXISTS `positions`;
CREATE TABLE `positions` (
  `PositionID` int NOT NULL AUTO_INCREMENT,
  `PositionName` varchar(100) NOT NULL,
  PRIMARY KEY (`PositionID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `positions`
--

INSERT INTO `positions` (`PositionID`, `PositionName`) VALUES
(1, 'Начальник управления'),
(2, 'Начальник участка'),
(3, 'Прораб'),
(4, 'Мастер'),
(5, 'Техник'),
(6, 'Инженер'),
(7, 'Технолог'),
(8, 'Каменщик'),
(9, 'Бетонщик'),
(10, 'Отделочник'),
(11, 'Сварщик'),
(12, 'Электрик'),
(13, 'Шофер'),
(14, 'Слесарь');

-- --------------------------------------------------------

--
-- Table structure for table `roles`
--

DROP TABLE IF EXISTS `roles`;
CREATE TABLE `roles` (
  `RoleID` int NOT NULL AUTO_INCREMENT,
  `RoleName` varchar(50) NOT NULL,
  PRIMARY KEY (`RoleID`),
  UNIQUE KEY `RoleName` (`RoleName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `roles`
--

INSERT INTO `roles` (`RoleID`, `RoleName`) VALUES
(1, 'admin'),
(2, 'manager'),
(5, 'user');

-- --------------------------------------------------------

--
-- Table structure for table `sites`
--

DROP TABLE IF EXISTS `sites`;
CREATE TABLE `sites` (
  `SiteID` int NOT NULL AUTO_INCREMENT,
  `ManagementID` int NOT NULL,
  `SiteName` varchar(100) NOT NULL,
  PRIMARY KEY (`SiteID`),
  KEY `ManagementID` (`ManagementID`),
  CONSTRAINT `sites_ibfk_1` FOREIGN KEY (`ManagementID`) REFERENCES `managements` (`ManagementID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `sites`
--

INSERT INTO `sites` (`SiteID`, `ManagementID`, `SiteName`) VALUES
(1, 1, 'Участок №1 ЦР'),
(2, 1, 'Участок №2 ЦР'),
(3, 2, 'Участок №1 СР');

-- --------------------------------------------------------

--
-- Table structure for table `objects`
--

DROP TABLE IF EXISTS `objects`;
CREATE TABLE `objects` (
  `ObjectID` int NOT NULL AUTO_INCREMENT,
  `ClientID` int NOT NULL,
  `SiteID` int NOT NULL,
  `ObjectName` varchar(255) DEFAULT NULL,
  `Budget` decimal(15,2) DEFAULT '0.00' COMMENT 'Бюджет, выделенный клиентом на объект',
  PRIMARY KEY (`ObjectID`),
  KEY `ClientID` (`ClientID`),
  KEY `SiteID` (`SiteID`),
  CONSTRAINT `objects_ibfk_1` FOREIGN KEY (`ClientID`) REFERENCES `clients` (`ClientID`) ON DELETE CASCADE,
  CONSTRAINT `objects_ibfk_2` FOREIGN KEY (`SiteID`) REFERENCES `sites` (`SiteID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `object_characteristics`
--

DROP TABLE IF EXISTS `object_characteristics`;
CREATE TABLE `object_characteristics` (
  `ObjectCharacteristicID` INT NOT NULL AUTO_INCREMENT,
  `ObjectID` INT NOT NULL,
  `CharacteristicID` INT NOT NULL,
  `Value` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`ObjectCharacteristicID`),
  KEY `idx_object_characteristics_objectid` (`ObjectID`),
  CONSTRAINT `object_characteristics_ibfk_1` FOREIGN KEY (`ObjectID`) REFERENCES `objects` (`ObjectID`) ON DELETE CASCADE,
  CONSTRAINT `object_characteristics_ibfk_2` FOREIGN KEY (`CharacteristicID`) REFERENCES `characteristics` (`CharacteristicID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `personnel`
--

DROP TABLE IF EXISTS `personnel`;
CREATE TABLE `personnel` (
  `PersonnelID` int NOT NULL AUTO_INCREMENT,
  `FullName` varchar(255) NOT NULL,
  `PositionID` int NOT NULL,
  `ManagementID` int DEFAULT NULL,
  `SiteID` int DEFAULT NULL,
  PRIMARY KEY (`PersonnelID`),
  KEY `PositionID` (`PositionID`),
  KEY `ManagementID` (`ManagementID`),
  KEY `SiteID` (`SiteID`),
  CONSTRAINT `personnel_ibfk_1` FOREIGN KEY (`PositionID`) REFERENCES `positions` (`PositionID`) ON DELETE RESTRICT,
  CONSTRAINT `personnel_ibfk_2` FOREIGN KEY (`ManagementID`) REFERENCES `managements` (`ManagementID`) ON DELETE SET NULL,
  CONSTRAINT `personnel_ibfk_3` FOREIGN KEY (`SiteID`) REFERENCES `sites` (`SiteID`) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `personnel`
--

INSERT INTO `personnel` (`PersonnelID`, `FullName`, `PositionID`, `ManagementID`, `SiteID`) VALUES
(1, 'Иванов Иван', 1, 1, 1),
(2, 'Петров Петр', 2, 1, 1),
(3, 'Сидоров Сидор', 3, 1, 1),
(4, 'Кузнецов Кузьма', 2, 2, 3),
(5, 'Морозова Мария', 1, 2, 2),
(6, 'Попова Ольга', 2, 2, 2),
(7, 'Попова Ольга', 6, 2, 2);

-- --------------------------------------------------------

--
-- Table structure for table `crewmembers`
--

DROP TABLE IF EXISTS `crewmembers`;
CREATE TABLE `crewmembers` (
  `CrewID` int NOT NULL,
  `PersonnelID` int NOT NULL,
  PRIMARY KEY (`CrewID`,`PersonnelID`),
  KEY `PersonnelID` (`PersonnelID`),
  CONSTRAINT `crewmembers_ibfk_1` FOREIGN KEY (`CrewID`) REFERENCES `crews` (`CrewID`) ON DELETE CASCADE,
  CONSTRAINT `crewmembers_ibfk_2` FOREIGN KEY (`PersonnelID`) REFERENCES `personnel` (`PersonnelID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `crewmembers`
--

INSERT INTO `crewmembers` (`CrewID`, `PersonnelID`) VALUES
(2, 4),
(1, 5),
(1, 6);

-- --------------------------------------------------------

--
-- Table structure for table `equipmentassignments`
--

DROP TABLE IF EXISTS `equipmentassignments`;
CREATE TABLE `equipmentassignments` (
  `AssignmentID` int NOT NULL AUTO_INCREMENT,
  `EquipmentID` int NOT NULL,
  `ObjectID` int DEFAULT NULL,
  `ManagementID` int DEFAULT NULL,
  `StartDate` date DEFAULT NULL,
  `EndDate` date DEFAULT NULL,
  PRIMARY KEY (`AssignmentID`),
  KEY `EquipmentID` (`EquipmentID`),
  KEY `ObjectID` (`ObjectID`),
  KEY `ManagementID` (`ManagementID`),
  CONSTRAINT `equipmentassignments_ibfk_1` FOREIGN KEY (`EquipmentID`) REFERENCES `equipment` (`EquipmentID`) ON DELETE CASCADE,
  CONSTRAINT `equipmentassignments_ibfk_2` FOREIGN KEY (`ObjectID`) REFERENCES `objects` (`ObjectID`) ON DELETE CASCADE,
  CONSTRAINT `equipmentassignments_ibfk_3` FOREIGN KEY (`ManagementID`) REFERENCES `managements` (`ManagementID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `UserID` int NOT NULL AUTO_INCREMENT,
  `Username` varchar(50) NOT NULL,
  `PasswordHash` varchar(255) NOT NULL,
  `RoleID` int NOT NULL,
  `Balance` int DEFAULT '10000000',
  PRIMARY KEY (`UserID`),
  UNIQUE KEY `Username` (`Username`),
  KEY `RoleID` (`RoleID`),
  CONSTRAINT `users_ibfk_1` FOREIGN KEY (`RoleID`) REFERENCES `roles` (`RoleID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`UserID`, `Username`, `PasswordHash`, `RoleID`, `Balance`) VALUES
(1, 'Nikita', 'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', 1, 997999999),
(2, 'Никитоска', 'jSPPbIboNKeqbt7VTCbOK7LnSQNTjGG91dIZeZerL3I=', 5, 966999999);

-- --------------------------------------------------------

--
-- Table structure for table `logs`
--

DROP TABLE IF EXISTS `logs`;
CREATE TABLE `logs` (
  `LogID` int NOT NULL AUTO_INCREMENT,
  `UserID` int NOT NULL,
  `Action` varchar(255) NOT NULL,
  `ActionTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`LogID`),
  KEY `UserID` (`UserID`),
  CONSTRAINT `logs_ibfk_1` FOREIGN KEY (`UserID`) REFERENCES `users` (`UserID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `logs`
--

INSERT INTO `logs` (`LogID`, `UserID`, `Action`, `ActionTime`) VALUES
(1, 1, 'User created', '2025-05-02 15:15:10'),
(2, 2, 'User created', '2025-05-02 16:20:47');

-- --------------------------------------------------------

--
-- Table structure for table `materialconsumption`
--

DROP TABLE IF EXISTS `materialconsumption`;
CREATE TABLE `materialconsumption` (
  `MaterialConsumptionID` int NOT NULL AUTO_INCREMENT,
  `ObjectID` int NOT NULL,
  `MaterialID` int NOT NULL,
  `Quantity` decimal(10,2) NOT NULL,
  `PlannedQuantity` decimal(10,2) DEFAULT '0.00' COMMENT 'Плановое количество материала по смете',
  PRIMARY KEY (`MaterialConsumptionID`),
  KEY `ObjectID` (`ObjectID`),
  KEY `MaterialID` (`MaterialID`),
  CONSTRAINT `materialconsumption_ibfk_1` FOREIGN KEY (`ObjectID`) REFERENCES `objects` (`ObjectID`) ON DELETE CASCADE,
  CONSTRAINT `materialconsumption_ibfk_2` FOREIGN KEY (`MaterialID`) REFERENCES `materials` (`MaterialID`) ON DELETE RESTRICT
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `budgetexceeding`
--

DROP TABLE IF EXISTS `budgetexceeding`;
CREATE TABLE `budgetexceeding` (
  `BudgetExceedingID` int NOT NULL AUTO_INCREMENT,
  `MaterialConsumptionID` int NOT NULL,
  `ExceededAmount` decimal(10,2) NOT NULL,
  PRIMARY KEY (`BudgetExceedingID`),
  KEY `MaterialConsumptionID` (`MaterialConsumptionID`),
  CONSTRAINT `budgetexceeding_ibfk_1` FOREIGN KEY (`MaterialConsumptionID`) REFERENCES `materialconsumption` (`MaterialConsumptionID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `rolepermissions`
--

DROP TABLE IF EXISTS `rolepermissions`;
CREATE TABLE `rolepermissions` (
  `RoleID` int NOT NULL,
  `TableName` varchar(50) NOT NULL,
  `PermissionType` enum('SELECT','INSERT','UPDATE','DELETE') NOT NULL,
  PRIMARY KEY (`RoleID`,`TableName`,`PermissionType`),
  CONSTRAINT `rolepermissions_ibfk_1` FOREIGN KEY (`RoleID`) REFERENCES `roles` (`RoleID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `worktypes`
--

DROP TABLE IF EXISTS `worktypes`;
CREATE TABLE `worktypes` (
  `WorkTypeID` int NOT NULL AUTO_INCREMENT,
  `WorkTypeName` varchar(100) NOT NULL,
  PRIMARY KEY (`WorkTypeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `worktypes`
--

INSERT INTO `worktypes` (`WorkTypeID`, `WorkTypeName`) VALUES
(1, 'Фундамент'),
(2, 'Кирпичные работы'),
(3, 'Водоснабжение'),
(4, 'Отделочные работы');

-- --------------------------------------------------------

--
-- Table structure for table `workassignments`
--

DROP TABLE IF EXISTS `workassignments`;
CREATE TABLE `workassignments` (
  `WorkAssignmentID` int NOT NULL AUTO_INCREMENT,
  `ObjectID` int NOT NULL,
  `CrewID` int NOT NULL,
  `WorkTypeID` int NOT NULL,
  `AssignmentDate` date NOT NULL,
  PRIMARY KEY (`WorkAssignmentID`),
  KEY `ObjectID` (`ObjectID`),
  KEY `CrewID` (`CrewID`),
  KEY `WorkTypeID` (`WorkTypeID`),
  CONSTRAINT `workassignments_ibfk_1` FOREIGN KEY (`ObjectID`) REFERENCES `objects` (`ObjectID`) ON DELETE CASCADE,
  CONSTRAINT `workassignments_ibfk_2` FOREIGN KEY (`CrewID`) REFERENCES `crews` (`CrewID`) ON DELETE CASCADE,
  CONSTRAINT `workassignments_ibfk_3` FOREIGN KEY (`WorkTypeID`) REFERENCES `worktypes` (`WorkTypeID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Table structure for table `workschedules`
--

DROP TABLE IF EXISTS `workschedules`;
CREATE TABLE `workschedules` (
  `ScheduleID` int NOT NULL AUTO_INCREMENT,
  `ObjectID` int NOT NULL,
  `WorkTypeID` int NOT NULL,
  `StartDate` date NOT NULL,
  `EndDate` date NOT NULL,
  `PlannedCost` decimal(12,2) DEFAULT '0.00' COMMENT 'Плановая стоимость работы',
  `ActualEndDate` date DEFAULT NULL,
  PRIMARY KEY (`ScheduleID`),
  KEY `ObjectID` (`ObjectID`),
  KEY `WorkTypeID` (`WorkTypeID`),
  CONSTRAINT `workschedules_ibfk_1` FOREIGN KEY (`ObjectID`) REFERENCES `objects` (`ObjectID`) ON DELETE CASCADE,
  CONSTRAINT `workschedules_ibfk_2` FOREIGN KEY (`WorkTypeID`) REFERENCES `worktypes` (`WorkTypeID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Views
--

--
-- Structure for view `v_logs`
--
DROP VIEW IF EXISTS `v_logs`;
CREATE OR REPLACE VIEW `v_logs` AS
SELECT
  l.LogID,
  u.Username,
  l.Action,
  l.ActionTime
FROM logs l
LEFT JOIN users u ON l.UserID = u.UserID;

-- --------------------------------------------------------

--
-- Procedures
--

DROP PROCEDURE IF EXISTS GetCrewComposition;
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetCrewComposition` (IN `p_ObjectID` INT)
BEGIN
  SELECT w.WorkAssignmentID,c.CrewID,c.CrewName,cm.PersonnelID,p.FullName,pos.PositionName
  FROM WorkAssignments w
  JOIN Crews c ON c.CrewID=w.CrewID
  JOIN CrewMembers cm ON cm.CrewID=c.CrewID
  JOIN Personnel p ON p.PersonnelID=cm.PersonnelID
  JOIN Positions pos ON pos.PositionID=p.PositionID
  WHERE w.ObjectID=p_ObjectID
  ORDER BY c.CrewID,p.FullName;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS GetCrewsByWorkTypePeriod;
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetCrewsByWorkTypePeriod` (IN `p_WorkTypeID` INT, IN `p_From` DATE, IN `p_To` DATE)
BEGIN
  SELECT DISTINCT wa.CrewID, c.CrewName, wa.ObjectID, wa.AssignmentDate
  FROM WorkAssignments wa
  JOIN Crews c ON c.CrewID=wa.CrewID
  WHERE wa.WorkTypeID=p_WorkTypeID
    AND wa.AssignmentDate BETWEEN p_From AND p_To
  ORDER BY c.CrewName, wa.AssignmentDate;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS GetCrewWorksPeriod;
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetCrewWorksPeriod` (IN `p_CrewID` INT, IN `p_From` DATE, IN `p_To` DATE)
BEGIN
  SELECT wa.WorkAssignmentID, wt.WorkTypeName, wa.ObjectID, wa.AssignmentDate
  FROM WorkAssignments wa
  JOIN WorkTypes wt ON wt.WorkTypeID=wa.WorkTypeID
  WHERE wa.CrewID=p_CrewID
    AND wa.AssignmentDate BETWEEN p_From AND p_To
  ORDER BY wa.AssignmentDate;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS GetEngineers;
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetEngineers` (IN `p_SiteID` INT, IN `p_ManagementID` INT)
BEGIN
  -- 1. Прямо по SiteID/ManagementID
  SELECT DISTINCT
    p.PersonnelID,
    p.FullName,
    pos.PositionName,
    s.SiteName,
    m.ManagementName
  FROM Personnel p
  JOIN Positions pos ON pos.PositionID = p.PositionID
  LEFT JOIN Sites s ON p.SiteID = s.SiteID
  LEFT JOIN Managements m ON p.ManagementID = m.ManagementID
  WHERE pos.PositionName IN ('Инженер','Технолог','Техник')
    AND ((p_SiteID IS NULL OR p.SiteID = p_SiteID)
         AND (p_ManagementID IS NULL OR p.ManagementID = p_ManagementID))

  UNION

  -- 2. Через бригады, работающие на объектах участка/управления
  SELECT DISTINCT
    p.PersonnelID,
    p.FullName,
    pos.PositionName,
    s.SiteName,
    m.ManagementName
  FROM Sites s
  JOIN Objects o ON o.SiteID = s.SiteID
  JOIN WorkAssignments wa ON wa.ObjectID = o.ObjectID
  JOIN CrewMembers cm ON cm.CrewID = wa.CrewID
  JOIN Personnel p ON p.PersonnelID = cm.PersonnelID
  JOIN Positions pos ON pos.PositionID = p.PositionID
  LEFT JOIN Managements m ON s.ManagementID = m.ManagementID
  WHERE pos.PositionName IN ('Инженер','Технолог','Техник')
    AND ((p_SiteID IS NULL OR s.SiteID = p_SiteID)
         AND (p_ManagementID IS NULL OR s.ManagementID = p_ManagementID))
  ORDER BY FullName;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS GetEquipmentByManagement;
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetEquipmentByManagement` (IN `p_ManagementID` INT)
BEGIN
  SELECT eq.EquipmentID, eq.EquipmentName
  FROM EquipmentAssignments ea
  JOIN Equipment eq ON eq.EquipmentID=ea.EquipmentID
  WHERE ea.ManagementID=p_ManagementID
  ORDER BY eq.EquipmentName;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS GetEquipmentByObjectPeriod;
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetEquipmentByObjectPeriod` (IN `p_ObjectID` INT, IN `p_From` DATE, IN `p_To` DATE)
BEGIN
  SELECT
    eq.EquipmentID,
    eq.EquipmentName,
    ea.StartDate,
    IFNULL(DATE_FORMAT(ea.EndDate, '%Y-%m-%d'), 'техника еще в работе') AS EndDate
  FROM EquipmentAssignments ea
  JOIN Equipment eq ON eq.EquipmentID = ea.EquipmentID
  WHERE ea.ObjectID = p_ObjectID
     OR (ea.StartDate <= p_To AND (ea.EndDate >= p_From OR ea.EndDate IS NULL))
  ORDER BY ea.StartDate;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS GetMgmtAndSitesHeads;
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetMgmtAndSitesHeads` ()
BEGIN
  SELECT
    m.ManagementID,
    m.ManagementName,
    COALESCE(mgr.FullName, 'руководитель еще не назначен') AS ManagementHead,
    s.SiteID,
    s.SiteName,
    COALESCE(sht.FullName, 'руководитель еще не назначен') AS SiteHead
  FROM Managements m
  LEFT JOIN Personnel mgr
    ON mgr.ManagementID = m.ManagementID AND mgr.PositionID = (SELECT PositionID FROM Positions WHERE PositionName='Начальник управления')
  LEFT JOIN Sites s ON s.ManagementID = m.ManagementID
  LEFT JOIN Personnel sht
    ON sht.SiteID = s.SiteID AND sht.PositionID = (SELECT PositionID FROM Positions WHERE PositionName='Начальник участка')
  ORDER BY m.ManagementID, s.SiteID;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS GetObjectReport;
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetObjectReport` (IN `p_ObjectID` INT)
BEGIN
  SELECT wa.WorkAssignmentID, wt.WorkTypeName, wa.ObjectID, wa.AssignmentDate
  FROM WorkAssignments wa
  JOIN WorkTypes wt ON wt.WorkTypeID=wa.WorkTypeID
  WHERE wa.ObjectID=p_ObjectID
  ORDER BY wa.AssignmentDate;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS GetObjectsByWorkTypePeriod;
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetObjectsByWorkTypePeriod` (IN `p_ManagementID` INT, IN `p_WorkTypeID` INT, IN `p_From` DATE, IN `p_To` DATE)
BEGIN
  SELECT DISTINCT
    o.ObjectID,
    o.ObjectName,
    s.SiteName,
    wt.WorkTypeName,
    ws.StartDate,
    ws.EndDate
  FROM WorkSchedules ws
  JOIN Objects o ON o.ObjectID = ws.ObjectID
  JOIN Sites s ON s.SiteID = o.SiteID
  JOIN Managements m ON m.ManagementID = s.ManagementID
  JOIN WorkTypes wt ON wt.WorkTypeID = ws.WorkTypeID
  WHERE ws.WorkTypeID = p_WorkTypeID
    AND ws.StartDate <= p_To
    AND ws.EndDate >= p_From
    AND (p_ManagementID IS NULL OR m.ManagementID = p_ManagementID)
  ORDER BY o.ObjectID;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS GetObjectsSchedule;
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetObjectsSchedule` (IN `p_SiteID` INT, IN `p_ManagementID` INT)
BEGIN
  SELECT
    o.ObjectID,
    o.ObjectName,
    s.SiteName,
    ws.ScheduleID,
    wt.WorkTypeName,
    ws.StartDate,
    ws.EndDate,
    (SELECT MIN(ws2.StartDate) FROM WorkSchedules ws2 WHERE ws2.ObjectID = o.ObjectID AND ws2.WorkTypeID = 1) AS FoundationStartDate
  FROM Objects o
  JOIN Sites s ON o.SiteID = s.SiteID
  JOIN Managements m ON s.ManagementID = m.ManagementID
  JOIN WorkSchedules ws ON ws.ObjectID = o.ObjectID
  JOIN WorkTypes wt ON wt.WorkTypeID = ws.WorkTypeID
  WHERE (p_SiteID IS NULL OR o.SiteID = p_SiteID)
    AND (p_ManagementID IS NULL OR s.ManagementID = p_ManagementID)
  ORDER BY o.ObjectID, ws.StartDate;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS GetOverbudgetMaterials;
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetOverbudgetMaterials` (IN `p_SiteID` INT, IN `p_ManagementID` INT)
BEGIN
  SELECT
    o.ObjectID,
    o.ObjectName,
    s.SiteName,
    m.MaterialID,
    m.MaterialName,
    mc.PlannedQuantity AS EstimatedQty,
    mc.Quantity AS ConsumedQty
  FROM MaterialConsumption mc
  JOIN Objects o ON o.ObjectID = mc.ObjectID
  JOIN Sites s ON s.SiteID = o.SiteID
  JOIN Materials m ON m.MaterialID = mc.MaterialID
  WHERE mc.Quantity > mc.PlannedQuantity
    AND (p_SiteID IS NULL OR o.SiteID = p_SiteID)
    AND (p_ManagementID IS NULL OR s.ManagementID = p_ManagementID)
  ORDER BY o.ObjectID, m.MaterialName;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS GetOverdueWorkTypes;
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetOverdueWorkTypes` (IN `p_SiteID` INT, IN `p_ManagementID` INT)
BEGIN
  SELECT
    wt.WorkTypeID,
    wt.WorkTypeName,
    o.ObjectID,
    o.ObjectName,
    s.SiteName,
    ws.EndDate AS PlannedEnd,
    ws.ActualEndDate AS ActualEnd
  FROM WorkSchedules ws
  JOIN WorkTypes wt ON wt.WorkTypeID = ws.WorkTypeID
  JOIN Objects o ON o.ObjectID = ws.ObjectID
  JOIN Sites s ON s.SiteID = o.SiteID
  WHERE ws.ActualEndDate IS NOT NULL
    AND ws.EndDate < ws.ActualEndDate
    AND (p_SiteID IS NULL OR o.SiteID = p_SiteID)
    AND (p_ManagementID IS NULL OR s.ManagementID = p_ManagementID)
  ORDER BY ws.ActualEndDate DESC;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS GetScheduleAndEstimate;
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetScheduleAndEstimate` (IN `p_ObjectID` INT)
BEGIN
  -- График
  SELECT ws.ScheduleID, wt.WorkTypeName, ws.StartDate, ws.EndDate
  FROM WorkSchedules ws
  JOIN WorkTypes wt ON wt.WorkTypeID = ws.WorkTypeID
  WHERE ws.ObjectID = p_ObjectID
  ORDER BY ws.StartDate;

  -- Смета (по materialconsumption)
  SELECT mc.MaterialConsumptionID, m.MaterialName, mc.PlannedQuantity AS EstimatedQty, mc.Quantity AS ConsumedQty
  FROM MaterialConsumption mc
  JOIN Materials m ON m.MaterialID = mc.MaterialID
  WHERE mc.ObjectID = p_ObjectID
  ORDER BY m.MaterialName;
END$$
DELIMITER ;

DROP PROCEDURE IF EXISTS GetITSByObject;
DELIMITER $$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetITSByObject` (IN `p_ObjectID` INT)
BEGIN
  SELECT DISTINCT
    p.PersonnelID,
    p.FullName,
    pos.PositionName,
    c.CrewName
  FROM workassignments wa
  JOIN crewmembers cm ON cm.CrewID = wa.CrewID
  JOIN personnel p ON p.PersonnelID = cm.PersonnelID
  JOIN positions pos ON pos.PositionID = p.PositionID
  JOIN crews c ON c.CrewID = wa.CrewID
  WHERE wa.ObjectID = p_ObjectID
    AND pos.PositionName IN ('Инженер','Технолог','Техник')
  ORDER BY p.FullName;
END$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Triggers
--

DELIMITER $$
CREATE TRIGGER `trg_overbudget` AFTER INSERT ON `budgetexceeding` FOR EACH ROW BEGIN
  INSERT INTO `Logs`(`UserID`,`Action`)
  VALUES(1, CONCAT('Overbudget: consumption ID=',NEW.`MaterialConsumptionID`, ' excess=',NEW.`ExceededAmount`));
END
$$
DELIMITER ;

DELIMITER $$
CREATE TRIGGER `trg_users_insert` AFTER INSERT ON `users` FOR EACH ROW BEGIN
  INSERT INTO `Logs`(`UserID`,`Action`)
  VALUES(NEW.`UserID`,'User created');
END
$$
DELIMITER ;

DELIMITER $$
CREATE TRIGGER `trg_crewmember_set_site` AFTER INSERT ON `crewmembers` FOR EACH ROW
BEGIN
  DECLARE v_SiteID INT;
  -- Get the latest site assigned to this crew (if any)
  SELECT wa.ObjectID, o.SiteID INTO @obj, v_SiteID
    FROM workassignments wa
    JOIN objects o ON o.ObjectID = wa.ObjectID
    WHERE wa.CrewID = NEW.CrewID
    ORDER BY wa.AssignmentDate DESC
    LIMIT 1;
  -- If a site is found, update the personnel's SiteID
  IF v_SiteID IS NOT NULL THEN
    UPDATE personnel SET SiteID = v_SiteID WHERE PersonnelID = NEW.PersonnelID;
  END IF;
END
$$
DELIMITER ;

COMMIT;

