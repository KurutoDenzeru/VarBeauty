-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 16, 2021 at 01:50 PM
-- Server version: 10.4.18-MariaDB
-- PHP Version: 8.0.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `varsalonlocal`
--

-- --------------------------------------------------------

--
-- Table structure for table `billing`
--

CREATE TABLE `billing` (
  `BillingID` int(11) NOT NULL,
  `CustomerID` int(11) NOT NULL,
  `CustomerName` varchar(100) NOT NULL,
  `CustomerDateTaken` varchar(100) NOT NULL,
  `CustomerTreatment` varchar(100) NOT NULL,
  `TreatmentPrice` varchar(100) NOT NULL,
  `EmployeeID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE `customer` (
  `CustomerID` int(11) NOT NULL,
  `CustomerName` varchar(100) NOT NULL,
  `CustomerAddress` varchar(100) NOT NULL,
  `CustomerContactNumber` varchar(100) NOT NULL,
  `CustomerDateTaken` datetime NOT NULL,
  `CustomerTreatment` varchar(100) NOT NULL,
  `TreatmentPrice` varchar(100) NOT NULL,
  `EmployeeID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `customer`
--

INSERT INTO `customer` (`CustomerID`, `CustomerName`, `CustomerAddress`, `CustomerContactNumber`, `CustomerDateTaken`, `CustomerTreatment`, `TreatmentPrice`, `EmployeeID`) VALUES
(2, 'Elish', 'Malabon', '21413', '2021-12-23 00:00:00', 'Swedish Massage', '400', 1),
(3, 'Ken', 'Cal', '789362784', '2021-12-22 00:00:00', 'Pedicure', '220', 1),
(4, 'Carlo', 'val', '1234123', '2021-12-14 00:00:00', 'Detox Treatment', '1000', 1),
(5, 'Kurt', 'Malabon', '5123213', '2021-12-14 00:00:00', 'Prenatal Massage', '400', 1),
(6, 'Pat', 'Val', '123123', '2021-12-19 00:00:00', 'Reflexology Massage', '350', 1),
(8, 'Elisha', 'Malabon', '4423123', '2021-12-15 00:00:00', 'Swedish Massage', '400', 1),
(9, 'Carl', 'Mal', '5123213', '2021-12-15 00:00:00', 'Reflexology Massage', '350', 1);

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `EmployeeID` int(11) NOT NULL,
  `EmployeeName` varchar(100) NOT NULL,
  `EmployeePosition` varchar(100) NOT NULL,
  `EmployeeContactNumber` varchar(100) NOT NULL,
  `EmployeeDateofBirth` datetime NOT NULL,
  `EmployeePassword` varchar(100) NOT NULL,
  `OwnerID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`EmployeeID`, `EmployeeName`, `EmployeePosition`, `EmployeeContactNumber`, `EmployeeDateofBirth`, `EmployeePassword`, `OwnerID`) VALUES
(1, 'Carlo', 'Apprentice', '1235123', '2021-12-15 00:00:00', 'carlo123', 0),
(4, 'kurt21', 'Junior Stylist', '4867231', '2021-03-11 00:00:00', 'kurt123', 1);

-- --------------------------------------------------------

--
-- Table structure for table `owner`
--

CREATE TABLE `owner` (
  `OwnerID` int(11) NOT NULL,
  `OwnerUsername` varchar(100) NOT NULL,
  `OwnerPassword` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `owner`
--

INSERT INTO `owner` (`OwnerID`, `OwnerUsername`, `OwnerPassword`) VALUES
(1, 'Owner123', 'Owner123');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `ProductID` int(11) NOT NULL,
  `ProductItem` varchar(100) NOT NULL,
  `ProductType` varchar(100) NOT NULL,
  `ProductStock` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`ProductID`, `ProductItem`, `ProductType`, `ProductStock`) VALUES
(2, 'Essential Oil', 'Massage Therapy', '128'),
(3, 'Lotion', 'Massage Therapy', '64'),
(4, 'Cream', 'Massage Therapy', '32'),
(5, 'Acetone', 'Manicure and Pedicure', '256'),
(6, 'Cuticle Cream', 'Manicure and Pedicure', '16'),
(7, 'Nail Polish', 'Manicure and Pedicure', '32'),
(8, 'Nail Filer', 'Manicure and Pedicure', '16'),
(9, 'Wax Strips', 'Waxing Service', '512'),
(10, 'Wax', 'Waxing Service', ' 256'),
(11, 'Shampoo', 'Hair Treatments', '128'),
(12, 'Conditioner', 'Hair Treatments', '64'),
(13, 'Neutralizing Cream', 'Hair Treatments', '50');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `billing`
--
ALTER TABLE `billing`
  ADD PRIMARY KEY (`BillingID`);

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`CustomerID`);

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`EmployeeID`);

--
-- Indexes for table `owner`
--
ALTER TABLE `owner`
  ADD PRIMARY KEY (`OwnerID`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`ProductID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `billing`
--
ALTER TABLE `billing`
  MODIFY `BillingID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `customer`
--
ALTER TABLE `customer`
  MODIFY `CustomerID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `employee`
--
ALTER TABLE `employee`
  MODIFY `EmployeeID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `owner`
--
ALTER TABLE `owner`
  MODIFY `OwnerID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `ProductID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
