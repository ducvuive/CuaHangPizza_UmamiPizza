drop database laptop1;
create database laptop1;
use laptop1;
------------- Table ---------------
/*==============================================================*/

CREATE TABLE `roleclaims` (
  `Id` int(11) NOT NULL primary key ,
  `RoleId` varchar(450) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
CREATE TABLE `roles` (
  `Id` varchar(450) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` varchar(256) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
CREATE TABLE `userclaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(255) NOT NULL,
  `ClaimType` longtext DEFAULT NULL,
  `ClaimValue` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
CREATE TABLE `userlogins` (
  `LoginProvider` varchar(127) NOT NULL,
  `ProviderKey` varchar(127) NOT NULL,
  `ProviderDisplayName` longtext DEFAULT NULL,
  `UserId` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
CREATE TABLE `userroles` (
  `UserId` varchar(127) NOT NULL,
  `RoleId` varchar(127) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
CREATE TABLE `usertokens` (
  `UserId` varchar(127) NOT NULL,
  `LoginProvider` varchar(127) NOT NULL,
  `Name` varchar(127) NOT NULL,
  `Value` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
CREATE TABLE `users` (
  `Id` varchar(255) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
	FullName 			varchar(100) null,
	Birthday            datetime(6) null,
    GIOITINH 			char(5),
	Address              varchar(100) null,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext DEFAULT NULL,
  `SecurityStamp` longtext DEFAULT NULL,
  `ConcurrencyStamp` longtext DEFAULT NULL,
  `PhoneNumber` longtext DEFAULT NULL,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `Photo` longtext DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;


-- Indexes for table `aspnetroles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `RoleNameIndex` (`NormalizedName`);

--
-- Indexes for table `aspnetuserclaims`
--
ALTER TABLE `userclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetUserClaims_UserId` (`UserId`);

--
-- Indexes for table `aspnetuserlogins`
--
ALTER TABLE `userlogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `IX_AspNetUserLogins_UserId` (`UserId`);

--
-- Indexes for table `aspnetuserroles`
--
ALTER TABLE `userroles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IX_AspNetUserRoles_RoleId` (`RoleId`);

--
-- Indexes for table `aspnetusers`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  ADD KEY `EmailIndex` (`NormalizedEmail`);
  
-- Indexes for table `aspnetusertokens`
--
ALTER TABLE `usertokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);
  
--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `aspnetroleclaims`
--
ALTER TABLE `roleclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `aspnetuserclaims`
--
ALTER TABLE `userclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;
  
  
  --
-- Constraints for table `aspnetroleclaims`
--
ALTER TABLE `roleclaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `roles` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserclaims`
--
ALTER TABLE `userclaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserlogins`
--
ALTER TABLE `userlogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetuserroles`
--
ALTER TABLE `userroles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `roles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `aspnetusertokens`
--
ALTER TABLE `usertokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`Id`) ON DELETE CASCADE;
  
commit;


-- /* Table: TAIKHOAN                 		                        */
-- /*==============================================================*/
-- create table TAIKHOAN
-- (
--    TENDANGNHAP          varchar(20) not null,
--    MATKHAU              varchar(20) not null,
--    QUYEN                varchar(20) not null,
--    primary key (TENDANGNHAP)
-- ) default charset = utf8mb4;

-- /*==============================================================*/
-- /* Table: NHANVIEN                                        */
-- /*==============================================================*/
-- create table NHANVIEN
-- (
--    MANV                 char(6) not null,
--    TENDANGNHAP          varchar(20) not null,
--    TENNV                varchar(50),
--    NGAYSINH             date,
--    GIOITINH             char(5),
--    CHUCVU               varchar(10),
--    DIACHI               varchar(100),
--    NGAYVL               date,
--    SODT                 char(12),
--    primary key (MANV)
-- ) default charset = utf8mb4;

-- /*==============================================================*/
-- /* Table: KHACHHANG                                       */
-- /*==============================================================*/
create table KHACHHANG
(
   MAKH                 char(6) not null,
   TENDANGNHAP          varchar(20) not null,
   TENKH                varchar(50),
   SODT                 char(12),
   EMAIL                varchar(50),
   GIOITINH             char(5),
   primary key (MAKH)
) default charset = utf8mb4;

/*==============================================================*/
/* Table: SANPHAM                                         */
/*==============================================================*/
create table SANPHAM
(
   MASP                 int AUTO_INCREMENT,
   TENSP                varchar(1000),
   DANHMUC              int not null,
   SOLUONG              int,
   MOTA                 varchar(200),
   Size					int,
   DONGIA               bigint,
   HINHANH              varchar(200),
   primary key (MASP)
)DEFAULT CHARSET=utf8mb4;


/*==============================================================*/
/* Table: SUKIEN                                          */
/*==============================================================*/
create table SUKIEN
(
   MASK                 int AUTO_INCREMENT,
   TENSK                varchar(50),
   PHANTRAMGIAMGIA      int,
   NGAYBD               date,
   NGAYKT               date,
   primary key (MASK)
) default charset = utf8mb4;


/*==============================================================*/
/* Table: DANHMUCSANPHAM                                  */
/*==============================================================*/
create table DANHMUCSANPHAM
(
   MADM                 int AUTO_INCREMENT,
   TENDM                varchar(50),
   primary key (MADM)
) default charset = utf8mb4;

/*==============================================================*/
/* Table:HOADON                                          */
/*==============================================================*/
create table HOADON  -- đơn đặt hàng
(
   MAHD                 int(6) not null,
   MAKH                 char(255) not null,
   MASK                 int,
   NGAYHD               date,
   NGUOINHAN 			varchar(50),
   nhanvienmanv			varchar(50),
   SDT					varchar(10),
   DIACHIGIAOHANG       varchar(100),
   TONGTIEN             int,
   THANHTIEN            int,
   TRANGTHAI 			int,
   primary key (MAHD)
) default charset = utf8mb4;

/*==============================================================*/
/* Table: Size                                     */
/*==============================================================*/
create table Size
(
   Id                int not null,
   Size              varchar(50),
   primary key (Id)
) DEFAULT CHARSET=utf8mb4 ;

/*==============================================================*/
/* Table: CTHD                                            */
/*==============================================================*/
create table CTHD
(
   MAHD                 int(6) not null,
   MASP                 int not null,
   SOLUONG              int,
   primary key (MAHD, MASP)
) default charset = utf8mb4;



/*==============================================================*/
/* KHOA NGOAI                                                   */
/*==============================================================*/

alter table CTHD add constraint FK_CTHD foreign key (MAHD)
      references HOADON (MAHD) on delete restrict on update restrict;

alter table CTHD add constraint FK_CTHD2 foreign key (MASP)
      references SANPHAM (MASP) on delete restrict on update restrict;


-- alter table HOADON add constraint FK_THUOC foreign key (MAKH)
--       references KHACHHANG (MAKH) on delete restrict on update restrict;

alter table hoadon add constraint FK_makhIDhd foreign key (makh)
      references users (ID) on delete restrict on update restrict;

alter table SANPHAM add constraint FK_THUOC3 foreign key (Size)
      references SIZE (Id) on delete restrict on update restrict;
      
alter table SANPHAM add constraint FK_THUOC1 foreign key (DANHMUC)
      references DANHMUCSANPHAM (MADM) on delete restrict on update restrict;


commit;

-- /*------------------- AUTO ID --------------------------*/

-- /*----- AUTOID_KHACHHANG ----*/

-- DROP FUNCTION IF EXISTS AUTO_IDKH;
-- DELIMITER $$
-- CREATE FUNCTION AUTO_IDKH()
-- RETURNS VARCHAR(6)
-- DETERMINISTIC
-- BEGIN
-- 	DECLARE MAKHNEW VARCHAR(6);
--     declare ID VARCHAR(4);
-- 	IF (SELECT COUNT(MAKH) FROM KHACHHANG) = 0 THEN
-- 		SET MAKHNEW = 'KH0001';
-- 	ELSE
-- 		SELECT MAX(RIGHT(MAKH, 4)) INTO ID from khachhang;
-- 			if ID >= 0 and ID < 9 THEN 
-- 				set MAKHNEW = CONCAT('KH000',CONVERT((CONVERT(ID, UNSIGNED) + 1),CHAR));
-- 			end if;
-- 			IF ID >= 9 and ID < 99 THEN
-- 				SET MAKHNEW = CONCAT('KH00',CONVERT((CONVERT(ID, UNSIGNED) + 1),CHAR));
-- 			end if;
--             IF ID >= 99 and ID < 999 THEN
-- 				SET MAKHNEW = CONCAT('KH0',CONVERT((CONVERT(ID, UNSIGNED) + 1),CHAR));
-- 			end if;
--             IF ID >= 999 THEN
-- 				SET MAKHNEW = CONCAT('KH',CONVERT((CONVERT(ID, UNSIGNED) + 1),CHAR));     
-- 			end if;
-- 	end if;
-- 	RETURN (MAKHNEW);
-- END$$ 
-- DELIMITER ;

-- DROP TRIGGER IF EXISTS trigger_AUTO_ID_KH;
-- DELIMITER $$
-- CREATE TRIGGER trigger_AUTO_ID_KH
--     BEFORE INSERT
--     ON KHACHHANG FOR EACH ROW
-- BEGIN
-- 	SET NEW.MAKH = AUTO_IDKH();
-- END$$    
-- DELIMITER ;



-- /*----- AUTOID_DANHMUCSANPHAM ----*/

-- DROP FUNCTION IF EXISTS AUTO_IDDMSP;
-- DELIMITER $$
-- CREATE FUNCTION AUTO_IDDMSP()
-- RETURNS VARCHAR(6)
-- DETERMINISTIC
-- BEGIN
-- 	DECLARE MADMNEW VARCHAR(6);
--     declare ID VARCHAR(4);
-- 	IF (SELECT COUNT(MADM) FROM DANHMUCSANPHAM) = 0 THEN
-- 		SET MADMNEW = 1;
-- 	ELSE
-- 		SELECT MAX(RIGHT(MADM, 4)) INTO ID from DANHMUCSANPHAM;
-- 			if ID >= 0 and ID < 9 THEN 
-- 				set MADMNEW = CONCAT('DM000',CONVERT((CONVERT(ID, UNSIGNED) + 1),CHAR));
-- 			end if;
--             if ID >= 9 and ID < 99 THEN 
-- 				set MADMNEW = CONCAT('DM00',CONVERT((CONVERT(ID, UNSIGNED) + 1),CHAR));
-- 			end if;
--             if ID >= 99 and ID < 999 THEN 
-- 				set MADMNEW = CONCAT('DM0',CONVERT((CONVERT(ID, UNSIGNED) + 1),CHAR));
-- 			end if;
-- 			IF ID >= 999 THEN
-- 					SET MADMNEW = CONCAT('DM',CONVERT((CONVERT(ID, UNSIGNED) + 1),CHAR));
-- 			END IF;
--            
-- 	end if;
-- 	RETURN (MADMNEW);
-- END$$ 
-- DELIMITER ;

-- DROP TRIGGER IF EXISTS trigger_AUTO_ID_DMSP;
-- DELIMITER $$
-- CREATE TRIGGER trigger_AUTO_ID_DMSP
--     BEFORE INSERT
--     ON DANHMUCSANPHAM FOR EACH ROW
-- BEGIN
-- 	SET NEW.MADM = AUTO_IDDMSP();
-- END$$    
-- DELIMITER ;

-- /*----- AUTOID_SANPHAM ----*/

-- DROP FUNCTION IF EXISTS AUTO_IDSP;
-- DELIMITER $$
-- CREATE FUNCTION AUTO_IDSP()
-- RETURNS VARCHAR(6)
-- DETERMINISTIC
-- BEGIN
-- 	DECLARE MASPNEW VARCHAR(6);
--     declare ID VARCHAR(4);
-- 	IF (SELECT COUNT(MASP) FROM SANPHAM) = 0 THEN
-- 		SET MASPNEW = 'SP0001';
-- 	ELSE
-- 		SELECT MAX(RIGHT(MASP, 4)) INTO ID from SANPHAM;
-- 			If ID >= 0 and ID < 9 THEN 
-- 				set MASPNEW = CONCAT('SP000',CONVERT((CONVERT(ID, UNSIGNED) + 1),CHAR));
-- 			end if;
--             if ID >= 9 and ID < 99 THEN 
-- 				set MASPNEW = CONCAT('SP00',CONVERT((CONVERT(ID, UNSIGNED) + 1),CHAR));
-- 			end if;
--             if ID >= 99 and ID < 999 THEN 
-- 				set MASPNEW = CONCAT('SP0',CONVERT((CONVERT(ID, UNSIGNED) + 1),CHAR));
-- 			end if;
-- 			IF ID >= 999 THEN
-- 					SET MASPNEW = CONCAT('SP',CONVERT((CONVERT(ID, UNSIGNED) + 1),CHAR));
-- 			END IF;
-- 	end if;
-- 	RETURN (MASPNEW);
-- END$$ 
-- DELIMITER ;

-- DROP TRIGGER IF EXISTS trigger_AUTO_ID_SP;
-- DELIMITER $$
-- CREATE TRIGGER trigger_AUTO_ID_SP
--     BEFORE INSERT
--     ON SANPHAM FOR EACH ROW
-- BEGIN
-- 	SET NEW.MASP = AUTO_IDSP();
-- END$$    
-- DELIMITER ;

 
INSERT INTO `danhmucsanpham` (`TENDM`) VALUES ('Pizza');
INSERT INTO `danhmucsanpham` (`TENDM`) VALUES ('MonAnKem');
INSERT INTO `danhmucsanpham` (`TENDM`) VALUES ('NuocUong');

INSERT INTO `size` (`Id`, `Size`) VALUES (1, 'S');
INSERT INTO `size` (`Id`, `Size`) VALUES (2, 'M');
INSERT INTO `size` (`Id`, `Size`) VALUES (3, 'L');
INSERT INTO `size` (`Id`, `Size`) VALUES (4, '');

insert into sanpham values (1,'Pizza Hải sản xốt Mayonnaise',1,100,'Phô mai, Xốt Mayonnaise, Tôm, Mực, Thanh cua, Hành tây',1,79000,'/HinhAnh/product_5.png');
insert into sanpham values (10,'Pizza Hải sản xốt Mayonnaise',1,100,'Phô mai, Xốt Mayonnaise, Tôm, Mực, Thanh cua, Hành tây',2,139000,'/HinhAnh/product_5.png');
insert into sanpham values (7,'Pizza Hải sản xốt Mayonnaise',1,100,'Phô mai, Xốt Mayonnaise, Tôm, Mực, Thanh cua, Hành tây',3,229000,'/HinhAnh/product_5.png');
insert into sanpham values (2,'Pizza Rau củ',1,100,'Phô mai, Xốt cà chua, Hành tây, Ớt chuông, Nấm, Olive, Thơm, Cà chua',1,59000,'/HinhAnh/product_6.png');
insert into sanpham values (5,'Pizza Rau củ',1,100,'Phô mai, Xốt cà chua, Hành tây, Ớt chuông, Nấm, Olive, Thơm, Cà chua',2,119000,'/HinhAnh/product_6.png');
insert into sanpham values (6,'Pizza Rau củ',1,100,'Phô mai, Xốt cà chua, Hành tây, Ớt chuông, Nấm, Olive, Thơm, Cà chua',3,209000,'/HinhAnh/product_6.png');
insert into sanpham values (3,'Pizza Bánh xèo Nhật',1,100,'Phô mai, Xốt Mayonnaise, Xốt Teriyaki, Tôm, Bạch tuộc, Bắp cải, Rong biển khô',1,79000,'/HinhAnh/product_2.png');
insert into sanpham values (8,'Pizza Bánh xèo Nhật',1,100,'Phô mai, Xốt Mayonnaise, Xốt Teriyaki, Tôm, Bạch tuộc, Bắp cải, Rong biển khô',2,139000,'/HinhAnh/product_2.png');
insert into sanpham values (9,'Pizza Bánh xèo Nhật',1,100,'Phô mai, Xốt Mayonnaise, Xốt Teriyaki, Tôm, Bạch tuộc, Bắp cải, Rong biển khô',3,229000,'/HinhAnh/product_2.png');
insert into sanpham values (4,'Pizza Lạp xưởng xốt trứng muối',1,100,'Phô mai, Xốt Mayonnaise, Tương cà, Lạp xưởng, Hành lá, Tép khô, Xốt trứng muối',1,79000,'/HinhAnh/product_1.png');
insert into sanpham values (11,'Pizza Lạp xưởng xốt trứng muối',1,100,'Phô mai, Xốt Mayonnaise, Tương cà, Lạp xưởng, Hành lá, Tép khô, Xốt trứng muối',2,139000,'/HinhAnh/product_1.png');
insert into sanpham values (12,'Pizza Lạp xưởng xốt trứng muối',1,100,'Phô mai, Xốt Mayonnaise, Tương cà, Lạp xưởng, Hành lá, Tép khô, Xốt trứng muối',3,229000,'/HinhAnh/product_1.png');
insert into sanpham values (13,'Pizza Xúc xích Ý',1,100,'Phô mai, Xốt cà chua, Xúc xích ý',1,79000,'/HinhAnh/product_3.png');
insert into sanpham values (14,'Pizza Xúc xích Ý',1,100,'Phô mai, Xốt cà chua, Xúc xích ý',1,139000,'/HinhAnh/product_3.png');
insert into sanpham values (15,'Pizza Xúc xích Ý',1,100,'Phô mai, Xốt cà chua, Xúc xích ý',1,229000,'/HinhAnh/product_3.png');
insert into sanpham values (16,'Pizza Phở',1,100,'Phô mai, Xốt bò hầm, Bò, Bò viên, Húng quế, Ngò gai',1,59000,'/HinhAnh/product_7.png');
insert into sanpham values (17,'Pizza Phở',1,100,'Phô mai, Xốt bò hầm, Bò, Bò viên, Húng quế, Ngò gai',1,119000,'/HinhAnh/product_7.png');
insert into sanpham values (18,'Pizza Phở',1,100,'Phô mai, Xốt bò hầm, Bò, Bò viên, Húng quế, Ngò gai',1,209000,'/HinhAnh/product_7.png');
insert into sanpham values (19,'Pizza Phô mai',1,100,'Phô mai, Xốt cà chua',1,59000,'/HinhAnh/product_4.png');
insert into sanpham values (20,'Pizza Phô mai',1,100,'Phô mai, Xốt cà chua',1,119000,'/HinhAnh/product_4.png');
insert into sanpham values (21,'Pizza Phô mai',1,100,'Phô mai, Xốt cà chua',1,209000,'/HinhAnh/product_4.png');
insert into sanpham values (22,'Mỳ ý hải sản',2,100,'Mỳ ý, Xốt cà chua, Tôm, Mực, Thanh cua, Phô mai','4',49000,'/HinhAnh/product_8.png');
insert into sanpham values (23,'Mỳ ý rau củ',2,100,'Mỳ ý, Xốt cà chua, Ớt chuông, Thơm, Nấm, Cà chua, Olive, Phô mai','4',39000,'/HinhAnh/product_9.png');
insert into sanpham values (24,'Salad',2,100,'Xà lách, Olive, Cà chua, Xốt Mayonnaise','4',29000,'/HinhAnh/product_10.png');
insert into sanpham values (25,'Coca',3,100,'','4',15000,'/HinhAnh/product_11.png');
insert into sanpham values (26,'Fanta',3,100,'','4',15000,'/HinhAnh/product_13.png');
insert into sanpham values (27,'Sprite',3,100,'','4',15000,'/HinhAnh/product_14.png');
insert into sanpham values (28,'Nuocsuoi',3,100,'','4',10000,'/HinhAnh/product_12.png');
