CREATE DATABASE  IF NOT EXISTS `foo` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `foo`;
-- MySQL dump 10.13  Distrib 5.6.13, for Win32 (x86)
--
-- Host: 127.0.0.1    Database: foo
-- ------------------------------------------------------
-- Server version	5.5.20

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `event`
--

DROP TABLE IF EXISTS `event`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `event` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `EventTime` datetime DEFAULT NULL,
  `Content` text,
  `Picture` char(255) DEFAULT NULL,
  `CreateTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `event`
--

LOCK TABLES `event` WRITE;
/*!40000 ALTER TABLE `event` DISABLE KEYS */;
INSERT INTO `event` VALUES (1,'2014-01-02 00:00:00','我们度过了愉快的一天。','20140102.jpg','2014-03-12 14:27:52'),(2,'2014-03-10 16:00:00','清华论坛第52讲：History, mission and vision of the Nobel Prizes',NULL,'2014-03-12 14:27:52'),(3,'2014-03-07 00:00:00','3月7日下午，校党委书记陈旭到国学研究院调研，与国学研究院负责人和教师代表进行座谈。',NULL,'2014-03-12 14:27:52'),(4,'2014-01-03 00:00:00','我们又度过了愉快的一天。',NULL,'2014-03-12 14:27:52'),(5,'2014-01-04 00:00:00','我们还度过了愉快的一天。',NULL,'2014-03-12 14:27:52'),(6,'2014-01-05 00:00:00','我们再度过了愉快的一天。',NULL,'2014-03-12 14:27:52'),(7,'2014-01-06 00:00:00','终于，我选择了李四。','20140106.jpg','2014-03-12 14:27:52');
/*!40000 ALTER TABLE `event` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `eventparticipate`
--

DROP TABLE IF EXISTS `eventparticipate`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `eventparticipate` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `PersonID` int(11) NOT NULL,
  `EventID` int(11) NOT NULL,
  `CreateTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `PersonID` (`PersonID`),
  KEY `EventID` (`EventID`),
  CONSTRAINT `eventparticipate_ibfk_1` FOREIGN KEY (`PersonID`) REFERENCES `person` (`ID`),
  CONSTRAINT `eventparticipate_ibfk_2` FOREIGN KEY (`EventID`) REFERENCES `event` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `eventparticipate`
--

LOCK TABLES `eventparticipate` WRITE;
/*!40000 ALTER TABLE `eventparticipate` DISABLE KEYS */;
INSERT INTO `eventparticipate` VALUES (1,2,1,'2014-03-12 14:28:39'),(2,3,1,'2014-03-12 14:28:39'),(3,2,4,'2014-03-12 14:28:39'),(4,3,4,'2014-03-12 14:28:39'),(5,2,5,'2014-03-12 14:28:39'),(6,3,5,'2014-03-12 14:28:39'),(7,2,6,'2014-03-12 14:28:39'),(8,3,6,'2014-03-12 14:28:39'),(9,2,7,'2014-03-12 14:28:39'),(10,7,2,'2014-03-12 14:28:39'),(11,5,3,'2014-03-12 14:28:39'),(12,6,3,'2014-03-12 14:28:39');
/*!40000 ALTER TABLE `eventparticipate` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `eventplace`
--

DROP TABLE IF EXISTS `eventplace`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `eventplace` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `PlaceID` int(11) NOT NULL,
  `EventID` int(11) NOT NULL,
  `CreateTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `PlaceID` (`PlaceID`),
  KEY `EventID` (`EventID`),
  CONSTRAINT `eventplace_ibfk_1` FOREIGN KEY (`PlaceID`) REFERENCES `place` (`ID`),
  CONSTRAINT `eventplace_ibfk_2` FOREIGN KEY (`EventID`) REFERENCES `event` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `eventplace`
--

LOCK TABLES `eventplace` WRITE;
/*!40000 ALTER TABLE `eventplace` DISABLE KEYS */;
INSERT INTO `eventplace` VALUES (1,1,1,'2014-03-12 14:29:13'),(2,2,1,'2014-03-12 14:29:13'),(3,3,1,'2014-03-12 14:29:13'),(4,1,4,'2014-03-12 14:29:13'),(5,3,4,'2014-03-12 14:29:13'),(6,3,5,'2014-03-12 14:29:13'),(7,7,6,'2014-03-12 14:29:13'),(8,3,7,'2014-03-12 14:29:13'),(9,6,2,'2014-03-12 14:29:13'),(10,4,3,'2014-03-12 14:29:13'),(11,5,3,'2014-03-12 14:29:13');
/*!40000 ALTER TABLE `eventplace` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `person`
--

DROP TABLE IF EXISTS `person`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `person` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `PName` char(64) NOT NULL,
  `Sex` char(1) NOT NULL DEFAULT '-',
  `Birthday` date DEFAULT NULL,
  `Potrait` char(255) DEFAULT NULL,
  `CreateTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `person`
--

LOCK TABLES `person` WRITE;
/*!40000 ALTER TABLE `person` DISABLE KEYS */;
INSERT INTO `person` VALUES (1,'张三','M','1993-10-01','images20140419100530.jpg','2014-03-12 13:27:40'),(2,'李四','M','1993-10-02','2.jpg','2014-03-12 14:12:54'),(3,'王五','F','1994-01-04','images/20140419100739.jpg','2014-03-12 14:12:54'),(4,'赵六','F','1994-04-05','images/20140419100845.jpg','2014-03-12 14:12:54'),(5,'陈旭','M',NULL,'16.jpg','2014-03-12 14:12:54'),(6,'陈来','-','1970-01-01','images/20140419100806.jpg','2014-03-12 14:12:54'),(7,'Carl-Henrik','M','1970-01-01','images/20140419100830.jpg','2014-03-12 14:12:54');
/*!40000 ALTER TABLE `person` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `personnote`
--

DROP TABLE IF EXISTS `personnote`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `personnote` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `PersonID` int(11) NOT NULL,
  `Content` text,
  `CreateTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `PersonID` (`PersonID`),
  CONSTRAINT `personnote_ibfk_1` FOREIGN KEY (`PersonID`) REFERENCES `person` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `personnote`
--

LOCK TABLES `personnote` WRITE;
/*!40000 ALTER TABLE `personnote` DISABLE KEYS */;
INSERT INTO `personnote` VALUES (1,3,'求之不得，寤寐思服。悠哉悠哉，辗转反侧。','2014-03-12 14:18:43'),(2,2,'他每天都在打WoT','2014-03-12 14:18:43'),(3,2,'饭卡密码是123456','2014-03-12 14:18:43'),(4,7,'Carl-Henrik Heldin is since 1986 the Branch Director of the Ludwig Institute for Cancer Research in Uppsala, Sweden, and since 1992 also professor in Molecular Cell Biology at Uppsala University. He was born in 1952, and obtained a PhD degree in Medical and physiological Chemistry in 1980 at the University of Uppsala, where he continued to work until 1985 using a position sponsored by the Swedish Cancer Society.','2014-03-12 14:18:43'),(5,7,'The research interest of C.-H. Heldin is related to the mechanisms whereby growth factors, in particular PDGF and TGF, activate their receptors and control cell growth, migration, apoptosis and differentiation, and how perturbations of signaling pathways promote tumor progression. An aim is to explore the usefulness of signal transduction inhibitors for tumor treatment.','2014-03-12 14:18:43'),(6,7,'C.-H. Heldin is an elected member of the European Molecular Biology Organization (1989), Royal Swedish Academy of Sciences (1991), Royal Scientific Society (Uppsala; 1995), Academia Europea (1999), Japanese Association for Cancer Research (2002), Finnish Scientific Society (2006), ScanBalt Academy (2006), Hellenic Biochemical Society (2007), Norwegian Academy of Sciences and Letters (2009) and European Academy of Cancer Sciences (2009). He is Doctor honoris causa at the universities of Patras (2009), Helsinki (2010), Turku (2011) and Heidelberg (2011), and has obtained several awards for his work, including Prix Antoine Lacasagne (1989), the EMBO Medal (1992), K. Fernström’s Large medical prize (1993), the Meyenburg Prize (1999), the Pezcollar AACR Prize (2002), and the Honorary Medal of the Signal Transduction Society (2012).','2014-03-12 14:18:43'),(7,7,'C.-H. Heldin has served on the Scientific Advisory Boards for several companies and academic institutions, including European Molecular Biology Organization, Heidelberg, European Molecular Biology Laboratory, Heidelberg, German Cancer Center, Heidelberg, and Max ','2014-03-12 14:19:19'),(8,7,'C.-H. Heldin has published 396 research articles and 201 review articles, and has 26 approved patents. His work has been cited >56,000 times and his H index is 128.','2014-03-12 14:18:43'),(9,5,'校党委书记','2014-03-12 14:18:43'),(10,6,'国学研究院院长','2014-03-12 14:18:43'),(11,3,'究竟选择她还是李四呢？','2014-03-12 14:18:43'),(12,4,'好像她也不错。','2014-03-12 14:18:43'),(13,6,'头像不错','2014-04-19 13:56:22');
/*!40000 ALTER TABLE `personnote` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `persontype`
--

DROP TABLE IF EXISTS `persontype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `persontype` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `TName` char(32) NOT NULL,
  `Des` char(255) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `persontype`
--

LOCK TABLES `persontype` WRITE;
/*!40000 ALTER TABLE `persontype` DISABLE KEYS */;
INSERT INTO `persontype` VALUES (1,'大学同学','我认识的大学同学'),(2,'朋友','有点熟的人'),(3,'好朋友','很熟悉的人'),(4,'女朋友','(null)'),(5,'男朋友','？'),(6,'大学老师','曾经或现在担任过我老师的人'),(7,'中学同学','我认识的中学同学'),(8,'教授',''),(9,'清华校领导',''),(10,'清华教职工',''),(11,'外国人','');
/*!40000 ALTER TABLE `persontype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `persontypify`
--

DROP TABLE IF EXISTS `persontypify`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `persontypify` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `PersonID` int(11) NOT NULL,
  `TypeID` int(11) NOT NULL,
  `CreateTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `PersonID` (`PersonID`),
  KEY `TypeID` (`TypeID`),
  CONSTRAINT `persontypify_ibfk_1` FOREIGN KEY (`PersonID`) REFERENCES `person` (`ID`),
  CONSTRAINT `persontypify_ibfk_2` FOREIGN KEY (`TypeID`) REFERENCES `persontype` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `persontypify`
--

LOCK TABLES `persontypify` WRITE;
/*!40000 ALTER TABLE `persontypify` DISABLE KEYS */;
INSERT INTO `persontypify` VALUES (4,2,1,'2014-03-12 14:14:37'),(5,2,7,'2014-03-12 14:14:37'),(6,2,5,'2014-03-12 14:14:37'),(13,5,9,'2014-03-12 14:14:37'),(18,1,1,'2014-04-19 02:05:31'),(19,1,2,'2014-04-19 02:05:31'),(20,1,3,'2014-04-19 02:05:31'),(21,3,1,'2014-04-19 02:07:40'),(22,3,2,'2014-04-19 02:07:40'),(23,3,3,'2014-04-19 02:07:40'),(24,3,4,'2014-04-19 02:07:40'),(25,6,10,'2014-04-19 02:08:09'),(26,7,8,'2014-04-19 02:08:33'),(27,7,11,'2014-04-19 02:08:33'),(28,4,4,'2014-04-19 02:08:47'),(29,4,6,'2014-04-19 02:08:47'),(30,4,10,'2014-04-19 02:08:47');
/*!40000 ALTER TABLE `persontypify` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `place`
--

DROP TABLE IF EXISTS `place`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `place` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `PName` char(255) NOT NULL,
  `Address` char(255) DEFAULT NULL,
  `Picture` char(255) DEFAULT NULL,
  `CreateTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `place`
--

LOCK TABLES `place` WRITE;
/*!40000 ALTER TABLE `place` DISABLE KEYS */;
INSERT INTO `place` VALUES (1,'情人坡',NULL,'a.jpg','2014-03-12 14:22:10'),(2,'寓园','西门最后一个路口向南','b.jpg','2014-03-12 14:22:10'),(3,'我家',NULL,NULL,'2014-03-12 14:22:10'),(4,'清华学堂',NULL,'c.jpg','2014-03-12 14:22:10'),(5,'国学研究院','清华学堂内',NULL,'2014-03-12 14:22:10'),(6,'主楼接待厅','从主楼正面进，上一层楼',NULL,'2014-03-12 14:22:10'),(7,'六教',NULL,NULL,'2014-03-12 14:22:10');
/*!40000 ALTER TABLE `place` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `placenote`
--

DROP TABLE IF EXISTS `placenote`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `placenote` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `PlaceID` int(11) NOT NULL,
  `Content` text,
  `CreateTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `PlaceID` (`PlaceID`),
  CONSTRAINT `placenote_ibfk_1` FOREIGN KEY (`PlaceID`) REFERENCES `place` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `placenote`
--

LOCK TABLES `placenote` WRITE;
/*!40000 ALTER TABLE `placenote` DISABLE KEYS */;
INSERT INTO `placenote` VALUES (1,1,'你在坡上的一举一动都会被路人看见。','2014-03-12 14:24:45'),(2,1,'清华大学情人坡坐落于清华大学中部，是万泉河西岸的一处绿地，在西南方向与校图书馆相邻。配有草坪、树林、花坛、石亭等设施。本无名，由于仲夏夜常有情侣成双于此散心，故得“情人坡”之名。由于环境幽美，常有同学于此看书自习，散步锻炼，有时甚至可以看到新婚伉俪于此拍摄婚纱照，或某学生社团在此','2014-03-12 14:24:45'),(3,2,'东西有点贵。','2014-03-12 14:24:45'),(4,2,'美食节时的泡馍太坑了，不如桃李的。','2014-03-12 14:24:45'),(5,2,'美食节的biang biang面挺好吃，因为用了两种卤；面也很筋道。','2014-03-12 14:24:45');
/*!40000 ALTER TABLE `placenote` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `placetype`
--

DROP TABLE IF EXISTS `placetype`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `placetype` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `TName` char(255) NOT NULL,
  `Des` char(255) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `placetype`
--

LOCK TABLES `placetype` WRITE;
/*!40000 ALTER TABLE `placetype` DISABLE KEYS */;
INSERT INTO `placetype` VALUES (1,'室外休闲场所',''),(2,'食堂','清华内的食堂'),(3,'餐厅','清华外的餐厅'),(4,'私人空间',''),(5,'会议室、报告厅',''),(6,'学术场所',''),(7,'教学楼',''),(8,'校内建筑','');
/*!40000 ALTER TABLE `placetype` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `placetypify`
--

DROP TABLE IF EXISTS `placetypify`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `placetypify` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `PlaceID` int(11) NOT NULL,
  `TypeID` int(11) NOT NULL,
  `CreateTime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  KEY `PlaceID` (`PlaceID`),
  KEY `TypeID` (`TypeID`),
  CONSTRAINT `placetypify_ibfk_1` FOREIGN KEY (`PlaceID`) REFERENCES `place` (`ID`),
  CONSTRAINT `placetypify_ibfk_2` FOREIGN KEY (`TypeID`) REFERENCES `placetype` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `placetypify`
--

LOCK TABLES `placetypify` WRITE;
/*!40000 ALTER TABLE `placetypify` DISABLE KEYS */;
INSERT INTO `placetypify` VALUES (1,1,1,'2014-03-12 14:23:47'),(2,2,2,'2014-03-12 14:23:47'),(3,3,4,'2014-03-12 14:23:47'),(4,4,6,'2014-03-12 14:23:47'),(5,4,8,'2014-03-12 14:23:47'),(6,5,6,'2014-03-12 14:23:47'),(7,5,8,'2014-03-12 14:23:47'),(8,6,5,'2014-03-12 14:23:47'),(9,6,8,'2014-03-12 14:23:47'),(10,7,6,'2014-03-12 14:23:47'),(11,7,7,'2014-03-12 14:23:47'),(12,7,8,'2014-03-12 14:23:47');
/*!40000 ALTER TABLE `placetypify` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `settings`
--

DROP TABLE IF EXISTS `settings`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `settings` (
  `Nickname` varchar(50) NOT NULL,
  `Password` varchar(50) NOT NULL,
  `Potrait` varchar(255) NOT NULL,
  `FirstUse` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `settings`
--

LOCK TABLES `settings` WRITE;
/*!40000 ALTER TABLE `settings` DISABLE KEYS */;
INSERT INTO `settings` VALUES ('wp','','Potrait.jpg','2014-04-11 19:30:58');
/*!40000 ALTER TABLE `settings` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2014-04-19 22:17:46
