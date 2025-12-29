/* =========================================================
   Database: boxer_assessment
   Purpose : Simple Employee Registry (Assessment)
   ========================================================= */

IF DB_ID('boxer_assessment') IS NULL
BEGIN
    CREATE DATABASE boxer_assessment;
END
GO

USE boxer_assessment;
GO

/* =========================================================
   Drop tables if they already exist (clean re-run)
   ========================================================= */

IF OBJECT_ID('dbo.Employee', 'U') IS NOT NULL
    DROP TABLE dbo.Employee;

IF OBJECT_ID('dbo.JobTitle', 'U') IS NOT NULL
    DROP TABLE dbo.JobTitle;
GO

/* =========================================================
   Table: JobTitle (Lookup Table)
   ========================================================= */

CREATE TABLE dbo.JobTitle
(
    JobTitleId     INT IDENTITY(1,1) NOT NULL,
    TitleName      NVARCHAR(100)     NOT NULL,
    CreatedDate    DATETIME2         NOT NULL DEFAULT SYSUTCDATETIME(),
    ModifiedDate   DATETIME2         NULL,

    CONSTRAINT PK_JobTitle PRIMARY KEY (JobTitleId),
    CONSTRAINT UQ_JobTitle_TitleName UNIQUE (TitleName)
);
GO

/* =========================================================
   Table: Employee
   ========================================================= */

CREATE TABLE dbo.Employee
(
    EmployeeId     INT IDENTITY(1,1) NOT NULL,
    FirstName      NVARCHAR(100)     NOT NULL,
    LastName       NVARCHAR(100)     NOT NULL,
    Email          NVARCHAR(255)     NOT NULL,
    Salary         DECIMAL(18,2)     NOT NULL,
    IsActive       BIT               NOT NULL,
    JobTitleId     INT               NOT NULL,
    CreatedDate    DATETIME2         NOT NULL DEFAULT SYSUTCDATETIME(),
    ModifiedDate   DATETIME2         NULL,

    CONSTRAINT PK_Employee PRIMARY KEY (EmployeeId),

    CONSTRAINT UQ_Employee_Email UNIQUE (Email),

    CONSTRAINT CK_Employee_Salary CHECK (Salary >= 0),

    CONSTRAINT FK_Employee_JobTitle
        FOREIGN KEY (JobTitleId)
        REFERENCES dbo.JobTitle (JobTitleId)
        ON DELETE CASCADE
);
GO

/* =========================================================
   Seed Data: JobTitle
   ========================================================= */

INSERT INTO dbo.JobTitle (TitleName)
VALUES
('Junior Developer'),
('Developer'),
('Senior Developer'),
('QA Engineer'),
('Manager');
GO

/* =========================================================
   Seed Data: Employee (20 Rows)
   ========================================================= */

INSERT INTO dbo.Employee
(
    FirstName,
    LastName,
    Email,
    Salary,
    IsActive,
    JobTitleId
)
VALUES
('John',     'Doe',       'john.doe@company.com',        45000, 1, 1),
('Jane',     'Smith',     'jane.smith@company.com',      55000, 1, 2),
('Michael',  'Brown',     'michael.brown@company.com',   75000, 1, 3),
('Sarah',    'Johnson',   'sarah.johnson@company.com',   52000, 1, 2),
('David',    'Wilson',    'david.wilson@company.com',    48000, 0, 1),
('Emma',     'Taylor',    'emma.taylor@company.com',     70000, 1, 3),
('Chris',    'Anderson',  'chris.anderson@company.com',  46000, 1, 4),
('Olivia',   'Thomas',    'olivia.thomas@company.com',   80000, 1, 5),
('Daniel',   'Moore',     'daniel.moore@company.com',    60000, 0, 2),
('Sophia',   'Jackson',   'sophia.jackson@company.com',  72000, 1, 3),
('Ryan',     'Martins',   'ryan.martins@company.com',    47000, 1, 1),
('Lauren',   'Naidoo',    'lauren.naidoo@company.com',  56000, 1, 2),
('Kevin',    'Pillay',    'kevin.pillay@company.com',   78000, 1, 3),
('Ayesha',   'Khan',      'ayesha.khan@company.com',    53000, 1, 2),
('Mark',     'Roberts',   'mark.roberts@company.com',   49000, 0, 1),
('Nadia',    'Patel',     'nadia.patel@company.com',    71000, 1, 3),
('Luke',     'Stevens',   'luke.stevens@company.com',   46500, 1, 4),
('Hannah',   'White',     'hannah.white@company.com',   82000, 1, 5),
('Brandon',  'Lee',       'brandon.lee@company.com',    61000, 0, 2),
('Priya',    'Singh',     'priya.singh@company.com',    74000, 1, 3);
GO
