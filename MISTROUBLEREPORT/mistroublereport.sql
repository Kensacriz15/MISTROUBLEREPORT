-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Jun 04, 2025 at 12:58 AM
-- Server version: 8.0.30
-- PHP Version: 8.2.17

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `mistroublereport`
--

-- --------------------------------------------------------

--
-- Table structure for table `tb_mistroublereport`
--

CREATE TABLE `tb_mistroublereport` (
  `id` int NOT NULL,
  `start_date` datetime NOT NULL,
  `name` varchar(100) NOT NULL,
  `ticket_number` varchar(50) NOT NULL,
  `description` text,
  `trouble_time` datetime DEFAULT NULL,
  `completed_time` datetime DEFAULT NULL,
  `level` varchar(20) DEFAULT NULL,
  `risk_rating` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Dumping data for table `tb_mistroublereport`
--

INSERT INTO `tb_mistroublereport` (`id`, `start_date`, `name`, `ticket_number`, `description`, `trouble_time`, `completed_time`, `level`, `risk_rating`) VALUES
(1, '2025-06-03 13:37:51', 'Ken', '03062025HR1', 'Nasira yung computer', NULL, NULL, NULL, NULL),
(2, '2025-06-03 13:38:39', 'Kenken', '03062025HR2', 'Nasira yung printer', NULL, NULL, NULL, NULL);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tb_mistroublereport`
--
ALTER TABLE `tb_mistroublereport`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `ticket_number` (`ticket_number`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tb_mistroublereport`
--
ALTER TABLE `tb_mistroublereport`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
