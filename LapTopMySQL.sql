/*create database LapTop;
use laptop;*/
------------- Table ---------------

/*==============================================================*/
/* Table: TAIKHOAN                 		                        */
/*==============================================================*/
create table TAIKHOAN
(
   TENDANGNHAP          varchar(20) not null,
   MATKHAU              varchar(20),
   primary key (TENDANGNHAP)
);

/*==============================================================*/
/* Table: NHANVIEN                                        */
/*==============================================================*/
create table NHANVIEN
(
   MANV                 char(6) not null,
   TENDANGNHAP          varchar(20) not null,
   TENNV                varchar(50),
   NGAYSINH             date,
   GIOITINH             char(5),
   CHUCVU               varchar(10),
   DIACHI               varchar(100),
   NGAYVL               date,
   SODT                 char(12),
   primary key (MANV)
);

/*==============================================================*/
/* Table: KHACHHANG                                       */
/*==============================================================*/
create table KHACHHANG
(
   MAKH                 char(6) not null,
   TENDANGNHAP          varchar(10) not null,
   TENKH                varchar(50),
   SODT                 char(12),
   EMAIL                varchar(50),
   GIOITINH             char(5),
   primary key (MAKH)
);

/*==============================================================*/
/* Table: SANPHAM                                         */
/*==============================================================*/
create table SANPHAM
(
   MASP                 char(6) not null,
   MANHINH              char(5) not null,
   BOXULY               char(5) not null,
   RAM                  char(5) not null,
   CONGKETNOI           char(5) not null,
   DANHMUC              char(6) not null,
   TENSP                varchar(100),
   SOLUONG              int,
   MAUSAC               varchar(20),
   OCUNG                varchar(200),
   CARDMANHINH          varchar(100),
   DACBIET              varchar(100),
   HDH                  varchar(100),
   THIETKE              varchar(50),
   KHICHTHUOC_TRONGLUONG varchar(100),
   WEBCAM               varchar(50),
   PIN                  varchar(50),
   RAMAT                int,
   MOTA                 varchar(200),
   DONGIA               bigint,
   HINHANH              varchar(200),
   primary key (MASP)
)DEFAULT CHARSET=utf8mb4;


/*==============================================================*/
/* Table: BONHORAM                                        */
/*==============================================================*/
create table BONHORAM
(
   MARAM                char(5) not null,
   DUNGLUONGRAM         varchar(50),
   LOAIRAM              varchar(100),
   BUSRAM               varchar(20),
   HOTROTOIDA           varchar(10),
   primary key (MARAM)
) DEFAULT CHARSET=utf8mb4 ;

/*==============================================================*/
/* Table: BOXULY                                          */
/*==============================================================*/
create table BOXULY
(
   MABXL                char(5) not null,
   CONGNGHECPU          varchar(50),
   SONHAN               int,
   SOLUONG              int,
   TOCDOCPU             varchar(20),
   TOCDOTOIDA           varchar(50),
   BONHODEM             varchar(10),
   primary key (MABXL)
) DEFAULT CHARSET=utf8mb4;

/*==============================================================*/
/* Table: CONGKETNOI                                      */
/*==============================================================*/
create table CONGKETNOI
(
   MACKN                char(5) not null,
   CONGGIAOTIEP         varchar(200),
   KETNOIKHONGDAY       varchar(100),
   KHEDOCTHENHO         varchar(20),
   WEBCAM               varchar(50),
   TINHNANGKHAC         varchar(200),
   DENBANPHIM           varchar(10),
   primary key (MACKN)
) DEFAULT CHARSET=utf8mb4;

/*==============================================================*/
/* Table: MANHINH                                         */
/*==============================================================*/
create table MANHINH
(
   MAMH                 char(5) not null,
   KICHTHUOC            varchar(20),
   DOPHANGIAI           varchar(50),
   TANSOQUET            varchar(10),
   CONGNGHEMH           varchar(100),
   CAMUNG               varchar(10),
   primary key (MAMH)
)DEFAULT CHARSET=utf8mb4;

/*==============================================================*/
/* Table: SUKIEN                                          */
/*==============================================================*/
create table SUKIEN
(
   MASK                 char(6) not null,
   TENSK                varchar(50),
   PHANTRAMGIAMGIA      int,
   NGAYBD               date,
   NGAYKT               date,
   primary key (MASK)
);


/*==============================================================*/
/* Table: DANHMUCSANPHAM                                  */
/*==============================================================*/
create table DANHMUCSANPHAM
(
   MADM                 char(6) not null,
   TENDM                varchar(50),
   primary key (MADM)
);

/*==============================================================*/
/* Table:HOADON                                          */
/*==============================================================*/
create table HOADON
(
   MAHD                 char(6) not null,
   MAKH                 char(6) not null,
   MANV                 char(6) not null,
   MASK                 char(6),
   NGAYHD               date,
   DIACHIGIAOHANG       varchar(100),
   TONGTIEN             int,
   THANHTIEN            int,
   primary key (MAHD)
);

/*==============================================================*/
/* Table: CTHD                                            */
/*==============================================================*/
create table CTHD
(
   MAHD                 char(6) not null,
   MASP                 char(6) not null,
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

alter table HOADON add constraint FK_HD_SK foreign key (MASK)
      references SUKIEN (MASK) on delete restrict on update restrict;

alter table HOADON add constraint FK_LAP foreign key (MANV)
      references NHANVIEN (MANV) on delete restrict on update restrict;

alter table HOADON add constraint FK_THUOC foreign key (MAKH)
      references KHACHHANG (MAKH) on delete restrict on update restrict;

alter table KHACHHANG add constraint FK_CO2 foreign key (TENDANGNHAP)
      references TAIKHOAN (TENDANGNHAP) on delete restrict on update restrict;

alter table NHANVIEN add constraint FK_CO1 foreign key (TENDANGNHAP)
      references TAIKHOAN (TENDANGNHAP) on delete restrict on update restrict;

alter table SANPHAM add constraint FK_THUOC1 foreign key (DANHMUC)
      references DANHMUCSANPHAM (MADM) on delete restrict on update restrict;

alter table SANPHAM add constraint FK_THUOC3 foreign key (RAM)
      references BONHORAM (MARAM) on delete restrict on update restrict;

alter table SANPHAM add constraint FK_THUOC4 foreign key (MANHINH)
      references MANHINH (MAMH) on delete restrict on update restrict;

alter table SANPHAM add constraint FK_THUOC5 foreign key (BOXULY)
      references BOXULY (MABXL) on delete restrict on update restrict;

alter table SANPHAM add constraint FK_THUOC6 foreign key (CONGKETNOI)
      references CONGKETNOI (MACKN) on delete restrict on update restrict;

commit;