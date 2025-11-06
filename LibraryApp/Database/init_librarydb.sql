DROP DATABASE IF EXISTS library;
CREATE DATABASE library;
USE library;

CREATE TABLE TacGia (
    MaTacGia INT AUTO_INCREMENT PRIMARY KEY,
    TenTacGia VARCHAR(100) NOT NULL,
    NamSinh INT,
    QuocGia VARCHAR(50)
);

CREATE TABLE Sach (
    MaSach INT AUTO_INCREMENT PRIMARY KEY,
    TuaDe VARCHAR(200) NOT NULL,
    NamXuatBan INT,
    TheLoai VARCHAR(100),
    SoLuong INT DEFAULT 0,
    MaTacGia INT,
    FOREIGN KEY (MaTacGia) REFERENCES TacGia(MaTacGia)
);

CREATE TABLE DocGia (
    MaDocGia INT AUTO_INCREMENT PRIMARY KEY,
    HoTen VARCHAR(100) NOT NULL,
    NgaySinh DATE,
    DiaChi VARCHAR(255),
    SoDienThoai VARCHAR(20),
    Email VARCHAR(100)
);

CREATE TABLE NhanVien (
    MaNhanVien INT AUTO_INCREMENT PRIMARY KEY,
    HoTen VARCHAR(100),
    ChucVu VARCHAR(50),
    NgayVaoLam DATE
);

CREATE TABLE Muon (
    MaMuon INT AUTO_INCREMENT PRIMARY KEY,
    MaDocGia INT,
    MaNhanVien INT,
    NgayMuon DATE,
    NgayTra DATE,
    FOREIGN KEY (MaDocGia) REFERENCES DocGia(MaDocGia),
    FOREIGN KEY (MaNhanVien) REFERENCES NhanVien(MaNhanVien)
);

CREATE TABLE ChiTietMuon (
    MaMuon INT,
    MaSach INT,
    SoLuong INT DEFAULT 1,
    PRIMARY KEY (MaMuon, MaSach),
    FOREIGN KEY (MaMuon) REFERENCES Muon(MaMuon),
    FOREIGN KEY (MaSach) REFERENCES Sach(MaSach)
);


INSERT INTO TacGia (TenTacGia, NamSinh, QuocGia)
VALUES 
('Nguyễn Nhật Ánh', 1955, 'Việt Nam'),
('J.K. Rowling', 1965, 'Anh'),
('Haruki Murakami', 1949, 'Nhật Bản'),
('George Orwell', 1903, 'Anh'),
('Ernest Hemingway', 1899, 'Mỹ');

INSERT INTO Sach (TuaDe, NamXuatBan, TheLoai, SoLuong, MaTacGia)
VALUES
('Cho tôi xin một vé đi tuổi thơ', 2008, 'Thiếu nhi', 7, 1),
('Harry Potter và Hòn đá Phù thủy', 1997, 'Giả tưởng', 10, 2),
('Rừng Na Uy', 1987, 'Tiểu thuyết', 5, 3),
('1984', 1949, 'Chính trị - Xã hội', 4, 4),
('Ông già và biển cả', 1952, 'Văn học cổ điển', 6, 5);

INSERT INTO DocGia (HoTen, NgaySinh, DiaChi, SoDienThoai, Email)
VALUES
('Nguyễn Văn A', '2000-05-10', 'Hà Nội', '0912345678', 'vana@gmail.com'),
('Trần Thị B', '2001-08-12', 'TP.HCM', '0987654321', 'tranthib@gmail.com'),
('Lê Văn C', '1999-12-01', 'Đà Nẵng', '0977777777', 'levanc@gmail.com');

INSERT INTO NhanVien (HoTen, ChucVu, NgayVaoLam)
VALUES
('Phạm Thị Lan', 'Thủ thư', '2018-09-10'),
('Vũ Văn E', 'Quản lý', '2019-09-15');

INSERT INTO Muon (MaDocGia, MaNhanVien, NgayMuon, NgayTra)
VALUES
(1, 1, '2025-10-17', NULL),
(2, 2, '2025-10-10', '2025-10-15'),
(3, 1, '2025-10-12', NULL);

INSERT INTO ChiTietMuon (MaMuon, MaSach, SoLuong)
VALUES
(1, 1, 1),
(1, 3, 1),
(2, 2, 1),
(3, 5, 1);

SELECT * FROM TacGia;
SELECT * FROM Sach;
SELECT * FROM DocGia;
SELECT * FROM NhanVien;
SELECT * FROM Muon;
SELECT * FROM ChiTietMuon;
