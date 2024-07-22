-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 21, 2024 at 10:33 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `kartu_keluarga`
--

-- --------------------------------------------------------

--
-- Table structure for table `anggotakeluarga`
--

CREATE TABLE `anggotakeluarga` (
  `NIK` char(16) NOT NULL,
  `Nomor_KK` varchar(20) DEFAULT NULL,
  `Nama_Lengkap` varchar(100) DEFAULT NULL,
  `Gelar_Depan` varchar(20) DEFAULT NULL,
  `Gelar_Belakang` varchar(20) DEFAULT NULL,
  `Passport_Number` varchar(16) DEFAULT NULL,
  `Tgl_Berakhir_Paspor` date DEFAULT NULL,
  `Nama_Sponsor` varchar(100) DEFAULT NULL,
  `Tipe_Sponsor` varchar(50) DEFAULT NULL,
  `Alamat_Sponsor` varchar(255) DEFAULT NULL,
  `Jenis_Kelamin` varchar(10) DEFAULT NULL,
  `Tempat_Lahir` varchar(50) DEFAULT NULL,
  `Tanggal_Lahir` date DEFAULT NULL,
  `Kewarganegaraan` varchar(50) DEFAULT NULL,
  `No_SK_Penetapan_WNI` varchar(50) DEFAULT NULL,
  `Akta_Lahir` tinyint(1) DEFAULT NULL,
  `Nomor_Akta_Kelahiran` varchar(50) DEFAULT NULL,
  `Golongan_Darah` varchar(3) DEFAULT NULL,
  `Agama` varchar(50) DEFAULT NULL,
  `Nama_Organisasi_Kepercayaan` varchar(100) DEFAULT NULL,
  `Status_Perkawinan` varchar(20) DEFAULT NULL,
  `Akta_Perkawinan` tinyint(1) DEFAULT NULL,
  `Nomor_Akta_Perkawinan` varchar(50) DEFAULT NULL,
  `Tanggal_Perkawinan` date DEFAULT NULL,
  `Akta_Cerai` tinyint(1) DEFAULT NULL,
  `Nomor_Akta_Cerai` varchar(50) DEFAULT NULL,
  `Tanggal_Perceraian` date DEFAULT NULL,
  `Status_Hubungan_Dalam_Keluarga` varchar(50) DEFAULT NULL,
  `Kelainan_Fisik_dan_Mental` varchar(100) DEFAULT NULL,
  `Penyandang_Cacat` tinyint(1) DEFAULT NULL,
  `Pendidikan_Terakhir` varchar(50) DEFAULT NULL,
  `Jenis_Pekerjaan` varchar(50) DEFAULT NULL,
  `Nomor_ITAS_ITAP` varchar(50) DEFAULT NULL,
  `Tanggal_Terbit_ITAS_ITAP` date DEFAULT NULL,
  `Tanggal_Akhir_ITAS_ITAP` date DEFAULT NULL,
  `Tempat_Datang_Pertama` varchar(100) DEFAULT NULL,
  `Tanggal_Kedatangan_Pertama` date DEFAULT NULL,
  `NIK_Ibu` char(16) DEFAULT NULL,
  `Nama_Ibu` varchar(100) DEFAULT NULL,
  `NIK_Ayah` char(16) DEFAULT NULL,
  `Nama_Ayah` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `anggotakeluarga`
--

INSERT INTO `anggotakeluarga` (`NIK`, `Nomor_KK`, `Nama_Lengkap`, `Gelar_Depan`, `Gelar_Belakang`, `Passport_Number`, `Tgl_Berakhir_Paspor`, `Nama_Sponsor`, `Tipe_Sponsor`, `Alamat_Sponsor`, `Jenis_Kelamin`, `Tempat_Lahir`, `Tanggal_Lahir`, `Kewarganegaraan`, `No_SK_Penetapan_WNI`, `Akta_Lahir`, `Nomor_Akta_Kelahiran`, `Golongan_Darah`, `Agama`, `Nama_Organisasi_Kepercayaan`, `Status_Perkawinan`, `Akta_Perkawinan`, `Nomor_Akta_Perkawinan`, `Tanggal_Perkawinan`, `Akta_Cerai`, `Nomor_Akta_Cerai`, `Tanggal_Perceraian`, `Status_Hubungan_Dalam_Keluarga`, `Kelainan_Fisik_dan_Mental`, `Penyandang_Cacat`, `Pendidikan_Terakhir`, `Jenis_Pekerjaan`, `Nomor_ITAS_ITAP`, `Tanggal_Terbit_ITAS_ITAP`, `Tanggal_Akhir_ITAS_ITAP`, `Tempat_Datang_Pertama`, `Tanggal_Kedatangan_Pertama`, `NIK_Ibu`, `Nama_Ibu`, `NIK_Ayah`, `Nama_Ayah`) VALUES
('', '1234123412341234', 'aa', 'aaa', 'aa', 'bbb', NULL, 'vb', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `kartukeluarga`
--

CREATE TABLE `kartukeluarga` (
  `Nomor_KK` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `kartukeluarga`
--

INSERT INTO `kartukeluarga` (`Nomor_KK`) VALUES
('1234123412341234');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `anggotakeluarga`
--
ALTER TABLE `anggotakeluarga`
  ADD PRIMARY KEY (`NIK`),
  ADD KEY `Nomor_KK` (`Nomor_KK`);

--
-- Indexes for table `kartukeluarga`
--
ALTER TABLE `kartukeluarga`
  ADD PRIMARY KEY (`Nomor_KK`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `anggotakeluarga`
--
ALTER TABLE `anggotakeluarga`
  ADD CONSTRAINT `anggotakeluarga_ibfk_1` FOREIGN KEY (`Nomor_KK`) REFERENCES `kartukeluarga` (`Nomor_KK`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
