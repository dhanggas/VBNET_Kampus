-- phpMyAdmin SQL Dump
-- version 3.4.5
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Aug 04, 2015 at 01:49 AM
-- Server version: 5.5.16
-- PHP Version: 5.3.8

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `dbtabungan`
--

-- --------------------------------------------------------

--
-- Table structure for table `data_siswa`
--

CREATE TABLE IF NOT EXISTS `data_siswa` (
  `NIS` varchar(20) NOT NULL,
  `Nama_Siswa` varchar(20) NOT NULL,
  `Jenis_Kelamin` varchar(10) NOT NULL,
  `Alamat` text NOT NULL,
  `Tahun_Ajar` varchar(20) NOT NULL,
  `Kelas` int(11) NOT NULL,
  `Nama_Ortu` varchar(20) NOT NULL,
  `No_Telp` varchar(15) NOT NULL,
  `Saldo` double NOT NULL,
  `Keterangan` varchar(15) NOT NULL,
  PRIMARY KEY (`NIS`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `data_siswa`
--

INSERT INTO `data_siswa` (`NIS`, `Nama_Siswa`, `Jenis_Kelamin`, `Alamat`, `Tahun_Ajar`, `Kelas`, `Nama_Ortu`, `No_Telp`, `Saldo`, `Keterangan`) VALUES
('001', 'jamaludin', 'Perempuan', 'bb', '212', 5, 'kaka', '09809', 0, 'Aktif'),
('0123', 'iban', 'Laki-Laki', 'bby', '2013', 1, 'tt', '345', 0, 'Aktif');

-- --------------------------------------------------------

--
-- Table structure for table `pengambilan`
--

CREATE TABLE IF NOT EXISTS `pengambilan` (
  `No_Ambil` varchar(25) NOT NULL,
  `NIS` varchar(20) NOT NULL,
  `Nama_Siswa` varchar(20) NOT NULL,
  `Kelas` varchar(15) NOT NULL,
  `Saldo_Awal` double NOT NULL,
  `Jml_Ambil` double NOT NULL,
  `Saldo_Akhir` double NOT NULL,
  `Tgl_Ambil` date NOT NULL,
  PRIMARY KEY (`No_Ambil`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `pengguna`
--

CREATE TABLE IF NOT EXISTS `pengguna` (
  `Kd_Pengguna` varchar(25) NOT NULL,
  `Username` varchar(25) NOT NULL,
  `Password` varchar(25) NOT NULL,
  `Status` varchar(15) NOT NULL,
  PRIMARY KEY (`Kd_Pengguna`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pengguna`
--

INSERT INTO `pengguna` (`Kd_Pengguna`, `Username`, `Password`, `Status`) VALUES
('K001', 'iban', '123', 'ADMINISTRATOR'),
('K002', 'Hardin', '1234', 'KEPSEK'),
('K003', 'ibannura', '123', 'STAFF'),
('K004', 'iban', '123', 'STAFF');

-- --------------------------------------------------------

--
-- Table structure for table `setoran`
--

CREATE TABLE IF NOT EXISTS `setoran` (
  `No_Setor` varchar(25) NOT NULL,
  `NIS` varchar(25) NOT NULL,
  `Nama_Siswa` varchar(20) NOT NULL,
  `Kelas` varchar(15) NOT NULL,
  `Saldo_Awal` double NOT NULL,
  `Jml_Setor` double NOT NULL,
  `Saldo_Akhir` double NOT NULL,
  `Tgl_Setor` date NOT NULL,
  PRIMARY KEY (`No_Setor`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
