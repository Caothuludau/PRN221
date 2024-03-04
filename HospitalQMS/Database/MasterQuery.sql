
insert into PriorityType values 
(1, N'Cấp cứu', ''),
(2, N'Người khuyết tật nặng', ''),
(3, N'Phụ nữ có thai', ''),
(4, N'Người cao tuổi', N'Người trên 75 tuổi'),
(5, N'Trẻ em', N'Trẻ em dưới 6 tuổi'),
(6, N'Người có công với CM', ''),
(7, N'Có BHYT', N'Có BHYT còn hiệu lực'),
(8, N'Không BHYT', '')

--select * from PriorityType
--DELETE FROM PriorityType WHERE PriorityTypeID > -1

--
insert into StaffType values 
(1, 'Doctor'),
(2, 'Nurse'),
(3, 'Administrative Staff'),
(4, 'Technicians')

--
insert into Specialty values (1, N'Khoa Sản phụ khoa');
insert into Specialty values (2, N'Khoa Ngoại chung');
insert into Specialty values (3, N'Trung tâm Hỗ trợ sinh sản IVF');
insert into Specialty values (5, N'Khoa Nhi');
insert into Specialty values (6, N'Khoa Nội chung');
insert into Specialty values (7, N'Khoa Chẩn đoán hình ảnh và Thăm dò chức năng');
insert into Specialty values (8, N'Khoa Xét nghiệm – Giải phẫu');
insert into Specialty values (9, N'Khoa Vật lý trị liệu – Phục hồi chức năng');
insert into Specialty values (10, N'Khoa Tiêu hóa – Gan – Mật');
insert into Specialty values (11, N'Khoa Mắt');
insert into Specialty values (12, N'Khoa Răng – Hàm – Mặt');
insert into Specialty values (13, N'Khoa Tai – Mũi – Họng');
insert into Specialty values (14, N'Khoa Da liễu');
insert into Specialty values (15, N'Khoa Nam học');
insert into Specialty values (16, N'Khoa Nội tiết');
insert into Specialty values (17, N'Khoa Tim mạch');
insert into Specialty values (18, N'Khoa Thận lọc máu');
insert into Specialty values (19, N'Khoa Ung bướu');
insert into Specialty values (20, N'Khoa Khám bệnh');
insert into Specialty values (21, N'Khoa Kiểm soát nhiễm khuẩn');
insert into Specialty values (22, N'Phòng Tiêm chủng vacxin');
insert into Specialty values (23, N'Khoa Cấp cứu Hồi sức tích cực ICU');
insert into Specialty values (24, N'Khoa Cơ – Xương – Khớp');
insert into Specialty values (25, N'Khoa Tâm lý và Sức khỏe tâm thần');
insert into Specialty values (26, N'Khoa Hô Hấp');

--select * from Specialty
--ALTER TABLE Specialty
--ALTER COLUMN SName nchar(100);
--DELETE FROM Specialty WHERE SpecialtyID > -1

--
--select * from Department
insert into Department values
(1, 'A1', N'Hội trường lớn. Rẽ phải sau khi vào cổng chính, đi thẳng thêm 500m.'),
(2, 'A2', N'Khoa khám bệnh. Rẽ trái sau khi vào cổng chính, đi thẳng thêm 500m.'),
(3, 'B3', N'Khoa chẩn đoán hình ảnh. Khoa hồi sức tích cực. Đi thẳng vào từ cổng chỉnh, có hòn non bộ trước cửa tòa.'),
(4, 'B4', N'Khoa hồi sức cấp cứu. Phía sau tòa A2. Bên trái tòa B3.'),
(6, 'B6', N'Khoa nhi. Khoa phụ sản. Răng - hàm - mặt. Phía sau tòa A1. Bên phải tòa B3.')

--ROOM

--CREATE SEQUENCE RoomID_Sequence
--START WITH 1
--INCREMENT BY 2;

--ALTER TABLE Room
--ADD CONSTRAINT DF_Room_RoomID DEFAULT NEXT VALUE FOR RoomID_Sequence FOR RoomID;

--select * from room
--select * from Specialty
--select * from Department

-- Khoa Chẩn đoán hình ảnh và Thăm dò chức năng - 7
-- Khoa Xét nghiệm - Giải phẫu - 8
-- Khoa Nhi - 5
-- Khoa Sản phụ khoa - 1
-- B3 - 3
-- B6 - 6
-- Mã phòng = Department_Trái/Phải+Tầng_STT
insert into Room  (RName, Status, SpecialtyID, DepartmentID, RoomCode, [Floor])
values 
(N'Phòng Chụp X Quang', 'Active', 7, 3, 'B3_L1_1', 1),
(N'Phòng Chụp CT', 'Active', 7, 3, 'B3_L1_2', 1),
(N'Phòng Chẩn đoán, Xét nghiệm nhanh', 'Active', 8, 3, 'B3_L2_1', 2),
(N'Phòng Khám nhi', 'Active', 5, 6, 'B6_R1_1', 1),
(N'Phóng Khám sản phụ', 'Active', 5, 6, 'B6_R1_2', 1)
--select * from room
alter table room
alter column [Floor] INT NOT NULL;

--DELETE FROM Room WHERE RoomID > -1

--CREATE SEQUENCE MedicalRecordID_Sequence
--START WITH 1
--INCREMENT BY 3;

--ALTER TABLE MedicalRecord
--ADD CONSTRAINT DF_MedicalRecord_MedicalRecordID DEFAULT NEXT VALUE FOR MedicalRecordID_Sequence FOR MedicalRecordID;

--select * from MedicalRecord

INSERT INTO MedicalRecord(FullName, DateOfBirth, Gender, Diagnosis, [File], SocialInsuranceCode, DateAdmitted, DateDischarged, Note) 
VALUES (N'Nguyễn Phú Lương', '2003-03-13', 'Nam', 'Rạn xương bả vai trái', '\url\hsba', 'CH4010124600044', NULL, NULL, '')
--Nam 2003 Có BHYT 'Rạn xương bả vai trái' -> 'Phòng Chụp X Quang'

INSERT INTO MedicalRecord(FullName, DateOfBirth, Gender, Diagnosis, [File], SocialInsuranceCode, DateAdmitted, DateDischarged, Note) 
VALUES (N'Nguyễn Thị Hằng', '1995-05-21', N'Nữ', N'Viêm gan cấp tính', '\url\hsba', '', NULL, NULL, '');
--Nữ 1995 Ko BHYT 'Viêm gan cấp tính' -> 'Phòng Chụp CT'

INSERT INTO MedicalRecord(FullName, DateOfBirth, Gender, Diagnosis, [File], SocialInsuranceCode, DateAdmitted, DateDischarged, Note) 
VALUES (N'Hoàng Văn Tú', '1950-10-03', N'Nam', N'Trao ngược axit dạ dày', '\url\hsba', 'CH4010124600046', NULL, NULL, '');
--Nam 1950 Cựu chiến binh 'Trao ngược axit dạ dày' -> 'Phòng Chẩn đoán, Xét nghiệm nhanh'

INSERT INTO MedicalRecord(FullName, DateOfBirth, Gender, Diagnosis, [File], SocialInsuranceCode, DateAdmitted, DateDischarged, Note) 
VALUES (N'Phạm Thị Mai', '1978-02-15', N'Nữ', N'Bệnh viêm khớp dạng thấp', '\url\hsba', 'CH4010124600047', NULL, NULL, '');
--Nữ 1978 Mang thai 'Bệnh viêm khớp dạng thấp' -> 'Phòng Chụp X Quang'

INSERT INTO MedicalRecord(FullName, DateOfBirth, Gender, Diagnosis, [File], SocialInsuranceCode, DateAdmitted, DateDischarged, Note) 
VALUES (N'Nguyễn Hữu Tuấn', '1965-09-08', N'Nam', N'Ung thư ruột giai đoạn cuối', '\url\hsba', 'CH4010124600048', NULL, NULL, '');
--Nữ 1995 Có BHYT 'Ung thư ruột giai đoạn cuối' -> 'Phòng Chụp CT'

INSERT INTO MedicalRecord(FullName, DateOfBirth, Gender, Diagnosis, [File], SocialInsuranceCode, DateAdmitted, DateDischarged, Note) 
VALUES (N'Lê Thị Hương', '1990-12-25', N'Nữ', N'Diện tích vết thương cháy nặng', '\url\hsba', 'CH4010124600049', NULL, NULL, '');
--Nữ 1978 Có BHYT 'Diện tích vết thương cháy nặng' -> 'Phòng Chụp X Quang'

INSERT INTO MedicalRecord(FullName, DateOfBirth, Gender, Diagnosis, [File], SocialInsuranceCode, DateAdmitted, DateDischarged, Note) 
VALUES (N'Trần Văn Đông', '1973-06-17', N'Nam', N'Bệnh gan nhiễm mỡ', '\url\hsba', 'CH4010124600050', NULL, NULL, '');
--Nam 1973 Có BHYT 'Bệnh gan nhiễm mỡ' -> 'Phòng Chẩn đoán, Xét nghiệm nhanh'

INSERT INTO MedicalRecord(FullName, DateOfBirth, Gender, Diagnosis, [File], SocialInsuranceCode, DateAdmitted, DateDischarged, Note) 
VALUES (N'Nguyễn Thị Lệ', '1988-08-10', N'Nữ', N'Bệnh viêm nhiễm đường hô hấp', '\url\hsba', 'CH4010124600051', NULL, NULL, '');
--Nữ 1988 Có BHYT 'Bệnh viêm nhiễm đường hô hấp' -> 'Phòng Chẩn đoán, Xét nghiệm nhanh'

INSERT INTO MedicalRecord(FullName, DateOfBirth, Gender, Diagnosis, [File], SocialInsuranceCode, DateAdmitted, DateDischarged, Note) 
VALUES (N'Đỗ Minh Tuấn', '2020-03-02', N'Nam', N'Thủy đậu cấp tính', '\url\hsba', 'CH4010124600052', NULL, NULL, '');
--Nam 2020 Trẻ em dưới 6 tuổi 'Thủy đậu cấp tính' -> 'Phòng Khám nhi'

INSERT INTO MedicalRecord(FullName, DateOfBirth, Gender, Diagnosis, [File], SocialInsuranceCode, DateAdmitted, DateDischarged, Note) 
VALUES (N'Lê Thị Kim', '1977-07-29', N'Nữ', N'Bệnh tiểu đường', '\url\hsba', 'CH4010124600053', NULL, NULL, '');
--Nữ 1977 Có BHYT 'Bệnh tiểu đường' -> 'Phòng Chẩn đoán, Xét nghiệm nhanh'

INSERT INTO MedicalRecord(FullName, DateOfBirth, Gender, Diagnosis, [File], SocialInsuranceCode, DateAdmitted, DateDischarged, Note) 
VALUES (N'Nguyễn Văn Hoàng', '1955-11-14', N'Nam', N'Bệnh đau thắt ngực', '\url\hsba', '', NULL, NULL, '');
--Nam 1955 Ko BHYT 'Bệnh đau thắt ngực' -> 'Phòng Chụp CT'

--alter table message
--alter column MessageID int not null
--ALTER TABLE message
--ADD CONSTRAINT PK_Message PRIMARY KEY (MessageID);




--CREATE SEQUENCE PatientID_Sequence
--START WITH 1
--INCREMENT BY 1;

--ALTER TABLE Patient
--ADD CONSTRAINT DF_Patient_PatientID DEFAULT NEXT VALUE FOR PatientID_Sequence FOR PatientID;

--select * from MedicalRecord
--select * from PriorityType
--select * from Patient
--Status for Patient: (Nhập viện - Hospitalized, Chờ khám - Waiting, Đang khám - Examining, Đã khám - Examined, Hủy khám - Canceled examination, Chuyển phòng - Change Room)
insert into Patient (PName, DateOfBirth, [Status], PriorityTypeID, MedicalRecordID) 
VALUES 
(N'Nguyễn Phú Lương', '2003-03-13', 'Hospitalized', 7, 1),
(N'Nguyễn Thị Hằng', '1995-05-21', 'Hospitalized', 8, 4),
(N'Hoàng Văn Tú', '1950-10-03', 'Hospitalized', 6, 7),
(N'Phạm Thị Mai', '1978-02-15','Hospitalized', 3, 10),
(N'Nguyễn Hữu Tuấn', '1965-09-08', 'Hospitalized', 7, 13),
(N'Lê Thị Hương', '1990-12-25', 'Hospitalized', 7, 16),
(N'Trần Văn Đông', '1973-06-17', 'Hospitalized', 7, 19),
(N'Nguyễn Thị Lệ', '1988-08-10', 'Hospitalized', 7, 22),
(N'Đỗ Minh Tuấn', '2020-03-02', 'Hospitalized', 5, 25),
(N'Lê Thị Kim', '1977-07-29', 'Hospitalized', 7, 28),
(N'Nguyễn Văn Hoàng', '1955-11-14', 'Hospitalized', 8, 31);


--select * from Ticket
--ALTER TABLE Ticket
--ADD RoomID INT;

--ALTER TABLE Ticket
--ADD CONSTRAINT FK_Ticket_RoomID FOREIGN KEY (RoomID) REFERENCES Room(RoomID);

--ALTER TABLE Patient
--DROP CONSTRAINT FK_Patient_Room;
-- Drop the RoomID column
--ALTER TABLE Patient
--DROP COLUMN RoomID;

--ALTER TABLE MedicalStaff
--ALTER COLUMN Password nchar(100);


--Status for MedicalStaff: Available - Có mặt, Absent - Vắng mặt
--select * from MedicalStaff
--select * from StaffType
--select * from Specialty


--insert into MedicalStaff (StaffID, MSName, Title, [Status], StaffTypeID, SpecialtyID, [Password])
--values (176750, N'Nguyễn Phú Lương', 'Mr.', 'Available', 1, 7, '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92')
insert into MedicalStaff (StaffID, MSName, Title, [Status], StaffTypeID, SpecialtyID, [Password])
values (176726, N'Nguyễn Ngọc Hoàng San', 'Mr.', 'Available', 3, NULL, NULL)

