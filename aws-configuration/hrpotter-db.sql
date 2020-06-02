CREATE DATABASE  IF NOT EXISTS `hrpotter_db` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `hrpotter_db`;
-- MySQL dump 10.13  Distrib 8.0.20, for Win64 (x86_64)
--
-- Host: hrpotter-global-database-cluster.cluster-ctpolt3nhrqm.us-east-1.rds.amazonaws.com    Database: hrpotter_db
-- ------------------------------------------------------
-- Server version	5.6.10

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `ApplicationStatus`
--

DROP TABLE IF EXISTS `ApplicationStatus`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ApplicationStatus` (
  `Id` int(11) NOT NULL,
  `Description` char(100) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ApplicationStatus`
--

LOCK TABLES `ApplicationStatus` WRITE;
/*!40000 ALTER TABLE `ApplicationStatus` DISABLE KEYS */;
INSERT INTO `ApplicationStatus` VALUES (1,'To be reviewed'),(2,'Reviewed'),(3,'Approved'),(4,'Rejected');
/*!40000 ALTER TABLE `ApplicationStatus` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Companies`
--

DROP TABLE IF EXISTS `Companies`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Companies` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Companies`
--

LOCK TABLES `Companies` WRITE;
/*!40000 ALTER TABLE `Companies` DISABLE KEYS */;
INSERT INTO `Companies` VALUES (1,'Microsoft'),(2,'Apple'),(3,'Google'),(4,'EBR-IT'),(5,'Wizarding World'),(6,'Hewlett-Packard'),(10,'testfff'),(11,'my_company_after_identification');
/*!40000 ALTER TABLE `Companies` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `JobApplications`
--

DROP TABLE IF EXISTS `JobApplications`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `JobApplications` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `JobOfferId` int(11) NOT NULL,
  `FirstName` longtext NOT NULL,
  `LastName` varchar(100) CHARACTER SET utf8 NOT NULL,
  `Email` longtext NOT NULL,
  `Phone` longtext,
  `CvUrl` longtext,
  `IsStudent` tinyint(4) NOT NULL,
  `Description` longtext,
  `Status` int(11) NOT NULL,
  `CreatorId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_JobApplications_CreatorId` (`CreatorId`),
  KEY `IX_JobApplications_JobOfferId` (`JobOfferId`),
  KEY `IX_JobApplications_LastName` (`LastName`),
  KEY `Status` (`Status`),
  CONSTRAINT `JobApplications_ibfk_1` FOREIGN KEY (`Status`) REFERENCES `ApplicationStatus` (`Id`),
  CONSTRAINT `JobApplications_ibfk_2` FOREIGN KEY (`JobOfferId`) REFERENCES `JobOffers` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `JobApplications_ibfk_3` FOREIGN KEY (`CreatorId`) REFERENCES `Users` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `JobApplications`
--

LOCK TABLES `JobApplications` WRITE;
/*!40000 ALTER TABLE `JobApplications` DISABLE KEYS */;
INSERT INTO `JobApplications` VALUES (1,2,'Stefan','Johnson','johnson@nsa.gov',NULL,NULL,0,'lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum',1,2),(2,3,'Bogdan','Smith','smith@nsa.gov',NULL,NULL,0,NULL,1,2),(3,5,'Ambro?y','Miller','miller@nsa.gov',NULL,'TAiJF_Cwiczenie_04.pdf',1,NULL,1,2),(5,1,'Lech','Wilson','wilson@nsa.gov',NULL,NULL,0,NULL,4,7),(8,2,'Maciej','Kowalski','blabla@op.pl',NULL,NULL,1,'MY desc',2,8),(9,1,'Maciej','Kowalski','oo@oo.pl','555444333',NULL,1,'gg',1,8),(13,1,'test1','kowalski','rr@op.pl',NULL,'AzureServicePrincipal.pdf',0,NULL,3,7),(14,1,'test1','Wiczołek','przemyslaw.wk@gmail.com','797378190',NULL,1,'blabla',2,7),(18,6,'Maciej22','Wiczołek','przemyslaw.wk@gmail.com','797378190',NULL,1,'gg',1,8),(19,1,'Maciej22','Wiczołek22','przemyslaw.wk@gmail.com','797378190',NULL,0,NULL,2,8),(20,11,'Maciej','Wiczołek','przemyslaw.wk@gmail.com','797378190','9f1d06e9-0d5b-4eec-8962-eb3a10341c86#_#Przemys?awWiczo?ek_konspekt.pdf',0,NULL,1,8),(22,10,'test1','my_last_nae','prz@op.pl','444555333',NULL,1,'my_desc',4,7),(38,2,'noname','asd','a@wp.pl','123123123','6ee22333-9f42-4f01-9dbc-b3546e21e1eb#_#knn.pdf',0,NULL,1,11),(39,1,'noname','sfd','a@wp.pl','123123123','5c3f4b42-76c1-43da-b1a3-94d11e88b513#_#?wiczenie nr 23 instrukcja.pdf',0,NULL,1,11),(40,3,'noname','asd','a@wp.pl','123123123','d5b8ca76-7955-447b-89ac-14101a27b8a0#_#Efekt Fotoelektryczny.pdf',0,NULL,1,11);
/*!40000 ALTER TABLE `JobApplications` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `JobOffers`
--

DROP TABLE IF EXISTS `JobOffers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `JobOffers` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `JobTitle` varchar(450) NOT NULL,
  `CompanyId` int(11) NOT NULL,
  `Location` longtext NOT NULL,
  `SalaryFrom` int(11) DEFAULT NULL,
  `SalaryTo` int(11) DEFAULT NULL,
  `Created` datetime NOT NULL,
  `ValidUntil` datetime DEFAULT NULL,
  `Description` varchar(10000) DEFAULT NULL,
  `CreatorId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_JobOffers_CompanyId` (`CompanyId`),
  KEY `IX_JobOffers_CreatorId` (`CreatorId`),
  KEY `IX_JobOffers_JobTitle` (`JobTitle`(255)),
  CONSTRAINT `JobOffers_ibfk_1` FOREIGN KEY (`CompanyId`) REFERENCES `Companies` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `JobOffers_ibfk_2` FOREIGN KEY (`CreatorId`) REFERENCES `Users` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `JobOffers`
--

LOCK TABLES `JobOffers` WRITE;
/*!40000 ALTER TABLE `JobOffers` DISABLE KEYS */;
INSERT INTO `JobOffers` VALUES (1,'Backend Developer',1,'Warsaw',NULL,15000,'2019-12-17 00:38:05','2019-12-29 00:00:00','lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum\nhhello',6),(2,'Frontend Developer',2,'Warsaw',10000,NULL,'2019-12-17 00:38:05','2019-12-27 00:38:05','lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum',4),(3,'Manager',1,'New York',15000,25000,'2019-12-17 00:38:05','2019-12-22 00:00:00','2323232',6),(4,'Teacher',3,'Paris',10000,15000,'2019-12-17 00:38:05',NULL,'lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum',4),(5,'Cook',4,'Venice',10000,15000,'2019-12-17 00:38:05',NULL,'lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum',4),(6,'Manager',1,'Venice',15000,25000,'2019-12-17 00:38:05',NULL,NULL,6),(7,'I_Did_it',2,'Venice',4000,25000,'2019-12-17 00:38:05','2020-05-29 00:00:00','stt',6),(8,'Tst2',1,'Venice',15000,25000,'2019-12-17 00:38:05',NULL,NULL,6),(9,'Tst3',1,'Venice',15000,25000,'2019-12-17 00:38:05',NULL,NULL,6),(10,'Tst4',1,'Venice',15000,25000,'2019-12-17 00:38:05',NULL,NULL,6),(11,'Tst5',1,'Venice',15000,25000,'2019-12-17 00:38:05',NULL,NULL,6),(12,'Tst6',1,'Venice',15000,25000,'2019-12-17 00:38:05',NULL,NULL,6),(13,'Tst7',1,'Venice',15000,25000,'2019-12-17 00:38:05',NULL,NULL,6),(15,'Tst9',1,'Venice',15000,25000,'2019-12-17 00:38:05',NULL,NULL,6),(16,'MyTiel',6,'Warsaw',1000,10000,'2019-12-17 15:31:13','2019-12-18 00:00:00','lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum',NULL),(17,'yests',1,'gf',100,1000,'2019-12-17 16:43:25','2019-12-20 00:00:00','lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum lorem ipsum',6);
/*!40000 ALTER TABLE `JobOffers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Roles`
--

DROP TABLE IF EXISTS `Roles`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Roles` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_Roles_Name` (`Name`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Roles`
--

LOCK TABLES `Roles` WRITE;
/*!40000 ALTER TABLE `Roles` DISABLE KEYS */;
INSERT INTO `Roles` VALUES (3,'Admin'),(2,'HR'),(1,'User');
/*!40000 ALTER TABLE `Roles` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Users`
--

DROP TABLE IF EXISTS `Users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Users` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `B2CKey` varchar(200) CHARACTER SET utf8 DEFAULT NULL,
  `Name` longtext,
  `RoleId` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IX_Users_B2CKey` (`B2CKey`),
  KEY `IX_Users_RoleId` (`RoleId`),
  CONSTRAINT `Users_ibfk_1` FOREIGN KEY (`RoleId`) REFERENCES `Roles` (`Id`) ON DELETE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Users`
--

LOCK TABLES `Users` WRITE;
/*!40000 ALTER TABLE `Users` DISABLE KEYS */;
INSERT INTO `Users` VALUES (1,'c3513236-6bcd-4443-bcc3-f39edb2a372b','admin',3),(2,'48243631-2f99-4553-88f5-8dd9a07a92e3','testUser',1),(4,'701dcb7e-0a16-46f5-a846-d5a06cbd774c','stefan',2),(6,'6fa35afc-2051-424b-9d4d-b4933c023081','hr1',2),(7,'879cc927-1809-47a6-a0c2-ee4f76815b15','test1',1),(8,'6a88ff8f-195b-4a8e-9a15-3f7633d638bf','Maciej',1),(9,'75fd7a4e-5a1b-4e81-bb7b-83bad723fd3e','SKN',1),(10,'aceeddbb-78a9-45a3-baf1-f67b0dd1c3dd','User',1),(11,'6f7a5f7f-c158-4a1c-b9e2-083770588328','noname',1);
/*!40000 ALTER TABLE `Users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-06-02 20:39:56
