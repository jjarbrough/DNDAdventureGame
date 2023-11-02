CREATE DATABASE  IF NOT EXISTS `dndadventure` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `dndadventure`;
-- MySQL dump 10.13  Distrib 8.0.34, for Win64 (x86_64)
--
-- Host: localhost    Database: dndadventure
-- ------------------------------------------------------
-- Server version	8.0.34

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
-- Table structure for table `encounter`
--

DROP TABLE IF EXISTS `encounter`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `encounter` (
  `idEncounters` int NOT NULL AUTO_INCREMENT,
  `soundEffects` varchar(2000) NOT NULL,
  `difficultyToRun` int NOT NULL,
  `isTown` tinyint NOT NULL,
  `fromAfar` varchar(200) NOT NULL,
  `locationDescription` varchar(2000) NOT NULL,
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`idEncounters`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `encounter`
--

LOCK TABLES `encounter` WRITE;
/*!40000 ALTER TABLE `encounter` DISABLE KEYS */;
INSERT INTO `encounter` VALUES (1,'246230__andreangelo__squelchy-mouth-cave-hq.wav',12,0,'A large Cave mouth looming wide','Stepping into a cave, you leave behind the outside world\'s brightness and warmth. \nAs your eyes adjust to the dim light, the temperature drops, and you feel a cool, damp air brushing against your skin. \nThe ground beneath your feet becomes uneven, and the echo of your footsteps fills the enclosed space. \nThe scent of earth and minerals lingers in the air, and the mysterious darkness ahead beckons you to explore further.','cave'),(2,'378209__felixblume__the-sounds-of-the-meadow-gran-sabana-venezuela.wav',6,0,'A welcoming meadow, dotted with flowers and small plants','Walking into a meadow, you step into a vast expanse of open space. \nSunlight bathes the area, warming your skin and brightening the surroundings. \nThe ground is covered with soft, knee-high grasses and wildflowers that sway gently in the breeze. \nThe air is filled with the scent of earth and blossoms. \nIn the distance, you might hear the chirping of birds or the buzzing of insects. \nIt\'s a peaceful and open landscape, inviting you to take in the natural beauty all around.','meadow'),(3,'135472__kvgarlic__summeropenfielddusk.wav',5,0,'A field with rolling hills','Walking into a field, you enter a spacious landscape with ground covered by short grasses and crops.\n Sunlight bathes the area, and the surroundings are open with a distant horizon or trees in the periphery. \nThe air carries the earthy scent of vegetation, and you can hear the rustling of leaves, \nthe chirping of birds, and the gentle swaying of plants in the wind.','field'),(4,'531724__klankbeeld__forest-summer-roond-021-200619_0186.wav',10,0,'A Dense and gloomy forest','Walking into a forest, you step into a dense and verdant environment. \nThe ground is covered with fallen leaves, twigs, and soft soil. \nTall trees rise around you, their branches forming a natural canopy overhead, dimming the light. \nThe air is cool, and the scent of earth and moss surrounds you. \nThe forest is alive with the chirping of birds, rustling of small animals, and the occasional crackling of branches. \nIt\'s a serene and mysterious realm, inviting you to explore its depths.','forest'),(5,'423119__ogsoundfx__medieval-city-sample.wav',12,1,'A town peeking over the hills in the distance','Walking into town narrow cobblestone streets wind between centuries-old stone buildings. \nOverhanging timber-framed houses line the lanes, and the air is filled with the scent of opportunity. \nThe town bustles with activity as villagers go about their daily routines. \nYou hear the clip-clop of horses\' hooves, merchants haggling at market stalls, and the distant chime of a church bell.','town'),(6,'399744__inspectorj__ambience-florida-frogs-gathering-a.wav',15,0,'What appears to be wetlands covered in fog','As you step into the bog, the ground beneath your feet gives way, sinking into a squelchy, muddy morass. \nThe air is thick with a damp, earthy aroma, and the dense fog conceals much of the landscape. \nWaterlogged plants with twisted, moss-covered branches reach out from the murky waters, and the eerie chorus of croaking frogs and buzzing insects fills the air. \nYour every step is accompanied by a sucking sound as your boots struggle to break free from the mire, \nmaking each movement a slow and cautious endeavor in this eerie, desolate wetland.','bog'),(7,'543449__kostas17__howling-wind.wav',6,0,'majestic mountain peaks disappearing into the clouds','Walking up to a mountain is a gradual journey of ascending terrain. \nAs you approach the mountain, the landscape becomes steeper, and the air grows crisper. \nThe path typically leads through forests, meadows, or rocky trails, with each step offering a closer view of the majestic peak ahead. \nThe mountain looms larger and more imposing as you get nearer, and the anticipation of the climb ahead intensifies with each stride.','mountain'),(8,'584595__tosha73__mountain-river.wav',6,0,'A river winding its way in the distance','Approaching a river, you see the glistening water ahead. \nThe gentle sound of flowing water fills the air, and the earthy scent of the surrounding nature surrounds you. \nYou walk toward the riverbank, feeling the cool breeze and the soft, uneven ground underfoot. \nThe lush greenery and wildlife along the river\'s edge add to the tranquil atmosphere, making it a serene and inviting spot.','river');
/*!40000 ALTER TABLE `encounter` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `enemy`
--

DROP TABLE IF EXISTS `enemy`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `enemy` (
  `idEnemies` int NOT NULL AUTO_INCREMENT,
  `xp` int DEFAULT NULL,
  `conScore` int DEFAULT NULL,
  `gold` int DEFAULT NULL,
  `weaponType` varchar(45) DEFAULT NULL,
  `name` varchar(45) DEFAULT NULL,
  `health` int DEFAULT NULL,
  `damageDie` int DEFAULT NULL,
  `isAlive` tinyint DEFAULT NULL,
  PRIMARY KEY (`idEnemies`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `enemy`
--

LOCK TABLES `enemy` WRITE;
/*!40000 ALTER TABLE `enemy` DISABLE KEYS */;
INSERT INTO `enemy` VALUES (1,15,2,20,'claws','bear',25,8,1),(2,5,0,8,'knife','Goblin',10,4,1),(3,3,2,5,'claws','Kobold',5,4,1),(4,25,1,30,'club','Troll',35,12,1);
/*!40000 ALTER TABLE `enemy` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-11-02 18:44:36
