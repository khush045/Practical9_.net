
USE PlacementDB;
GO

CREATE TABLE Students
(
    ID INT PRIMARY KEY,
    StudentID VARCHAR(20),
    Company VARCHAR(50),
    Department VARCHAR(50),
    Status VARCHAR(20),
    Package DECIMAL(6,2)
);

INSERT INTO Students VALUES
(1, 'ST101', 'TCS', 'Computer', 'Placed', 4.50),
(2, 'ST102', 'Infosys', 'IT', 'Placed', 5.00),
(3, 'ST103', 'Wipro', 'Computer', 'Placed', 3.50),
(4, 'ST104', 'Google', 'IT', 'Unplaced', 0.00),
(5, 'ST105', 'None', 'Computer', 'Unplaced', 0.00);

SELECT * FROM Students;
GO
