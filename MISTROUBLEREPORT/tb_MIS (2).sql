-- phpMyAdmin SQL Dump
-- version 5.1.3
-- https://www.phpmyadmin.net/
--
-- Host: localhost
-- Generation Time: Jun 12, 2024 at 02:43 PM
-- Server version: 10.6.16-MariaDB-0ubuntu0.22.04.1
-- PHP Version: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `bbox_logistics`
--

-- --------------------------------------------------------

--
-- Table structure for table `tb_MIS`
--

CREATE TABLE `tb_MIS` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `start_date` datetime DEFAULT NULL,
  `name` char(10) NOT NULL,
  `ticket_number` varchar(25) DEFAULT NULL,
  `description` text DEFAULT NULL,
  `trouble_time` varchar(10) DEFAULT NULL,
  `completed_time` varchar(10) DEFAULT NULL,
  `level` enum('Low Impact','Negligible','Moderate','Critical') DEFAULT NULL,
  `risk_rating` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3 COLLATE=utf8mb3_general_ci;

--
-- Dumping data for table `tb_MIS`
--

INSERT INTO `tb_MIS` (`id`, `start_date`, `name`, `ticket_number`, `description`, `trouble_time`, `completed_time`, `level`, `risk_rating`) VALUES
(1, '2024-06-12 10:37:36', 'test', '12062024HR1', 'test', NULL, NULL, NULL, NULL),
(2, '2024-06-12 10:39:07', 'dwad', '12062024HR2', 'wadawdwa', NULL, NULL, NULL, NULL);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tb_MIS`
--
ALTER TABLE `tb_MIS`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tb_MIS`
--
ALTER TABLE `tb_MIS`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
