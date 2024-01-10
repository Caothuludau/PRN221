create database UniversityDB

use UniversityDB

-- Create the Major table
CREATE TABLE Major (
    MajorID INT PRIMARY KEY IDENTITY(1,1),
    MajorName NVARCHAR(50) NOT NULL
);

-- Create the Student table
CREATE TABLE Student (
    StudentID INT PRIMARY KEY IDENTITY(1,1),
    StudentName NVARCHAR(100) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Gender NVARCHAR(10) NOT NULL,
    PhoneNumber NVARCHAR(15),
    MajorID INT FOREIGN KEY REFERENCES Major(MajorID)
);

-- Insert sample majors into the Major table
INSERT INTO Major (MajorName) VALUES ('Computer Science');
INSERT INTO Major (MajorName) VALUES ('Biology');
INSERT INTO Major (MajorName) VALUES ('Mathematics');

-- Insert sample students into the Student table
INSERT INTO Student (StudentName, DateOfBirth, Gender, PhoneNumber, MajorID)
VALUES 
    ('John Doe', '1990-05-15', 'Male', '123-456-7890', 1), -- MajorID 1 corresponds to 'Computer Science'
    ('Jane Smith', '1992-08-22', 'Female', '987-654-3210', 2), -- MajorID 2 corresponds to 'Biology'
    ('Bob Johnson', '1995-03-10', 'Male', '555-123-4567', 3); -- MajorID 3 corresponds to 'Mathematics'

-- Add more student information as needed
