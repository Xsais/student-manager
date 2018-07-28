CREATE DATABASE [StudentManagment]
GO
USE [StudentManagment]
GO
CREATE TABLE [Student] (
    [id] SMALLINT IDENTITY(1,1) NOT NULL ,
    [studentNumber] SMALLINT  NOT NULL ,
    [firstName] VARCHAR(50)  NOT NULL ,
    [lastName] VARCHAR(50)  NOT NULL ,
    [birthday] DATE  NOT NULL ,
    [gender] CHAR(1)  NOT NULL ,
    [startDate] SMALLINT  NOT NULL ,
    CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED (
        [id] ASC
    ),
    CONSTRAINT [UK_Student_studentNumber] UNIQUE (
        [studentNumber]
    )
)

CREATE TABLE [Professor] (
    [id] SMALLINT IDENTITY(1,1) NOT NULL ,
    [employeeNumber] SMALLINT  NOT NULL ,
    [firstName] VARCHAR(50)  NOT NULL ,
    [lastName] VARCHAR(50)  NOT NULL ,
    [birthday] DATE  NOT NULL ,
    [gender] CHAR(1)  NOT NULL ,
    [startDate] SMALLINT  NOT NULL ,
    CONSTRAINT [PK_Professor] PRIMARY KEY CLUSTERED (
        [id] ASC
    ),
    CONSTRAINT [UK_Professor_employeeNumber] UNIQUE (
        [employeeNumber]
    )
)

CREATE TABLE [Courses] (
    [id] SMALLINT IDENTITY(1,1) NOT NULL ,
    [courseCode] VARCHAR(6)  NOT NULL ,
    [name] VARCHAR(50)  NOT NULL ,
    [location] VARCHAR(50)  NOT NULL ,
    [time] TIME(2)  NOT NULL ,
    [capacity] SMALLINT  NOT NULL ,
    [credits] SMALLINT  NOT NULL ,
    CONSTRAINT [PK_Courses] PRIMARY KEY CLUSTERED (
        [id] ASC
    ),
    CONSTRAINT [UK_Courses_courseCode] UNIQUE (
        [courseCode]
    )
)

CREATE TABLE [Program] (
    [id] SMALLINT IDENTITY(1,1) NOT NULL ,
    [name] VARCHAR(100)  NOT NULL ,
    [duration] SMALLINT  NOT NULL ,
    [coop] CHAR(1)  NOT NULL ,
    [outcome] VARCHAR(50)  NOT NULL ,
    CONSTRAINT [PK_Program] PRIMARY KEY CLUSTERED (
        [id] ASC
    ),
    CONSTRAINT [UK_Program_name] UNIQUE (
        [name]
    )
)

CREATE TABLE [CourseProgram] (
    [courseId] SMALLINT  NOT NULL ,
    [programId] SMALLINT  NOT NULL 
)

CREATE TABLE [StudentCourse] (
    [studentId] SMALLINT  NOT NULL ,
    [courseId] SMALLINT  NOT NULL 
)

CREATE TABLE [ProfessorCourse] (
    [prefessorId] SMALLINT  NOT NULL ,
    [courseId] SMALLINT  NOT NULL 
)

CREATE TABLE [StudentProgram] (
    [studentId] SMALLINT  NOT NULL ,
    [programId] SMALLINT  NOT NULL 
)

ALTER TABLE [CourseProgram] WITH CHECK ADD CONSTRAINT [FK_CourseProgram_courseId] FOREIGN KEY([courseId])
REFERENCES [Courses] ([id])

ALTER TABLE [CourseProgram] CHECK CONSTRAINT [FK_CourseProgram_courseId]

ALTER TABLE [CourseProgram] WITH CHECK ADD CONSTRAINT [FK_CourseProgram_programId] FOREIGN KEY([programId])
REFERENCES [Program] ([id])

ALTER TABLE [CourseProgram] CHECK CONSTRAINT [FK_CourseProgram_programId]

ALTER TABLE [StudentCourse] WITH CHECK ADD CONSTRAINT [FK_StudentCourse_studentId] FOREIGN KEY([studentId])
REFERENCES [Student] ([id])

ALTER TABLE [StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_studentId]

ALTER TABLE [StudentCourse] WITH CHECK ADD CONSTRAINT [FK_StudentCourse_courseId] FOREIGN KEY([courseId])
REFERENCES [Courses] ([id])

ALTER TABLE [StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_courseId]

ALTER TABLE [ProfessorCourse] WITH CHECK ADD CONSTRAINT [FK_ProfessorCourse_prefessorId] FOREIGN KEY([prefessorId])
REFERENCES [Professor] ([id])

ALTER TABLE [ProfessorCourse] CHECK CONSTRAINT [FK_ProfessorCourse_prefessorId]

ALTER TABLE [ProfessorCourse] WITH CHECK ADD CONSTRAINT [FK_ProfessorCourse_courseId] FOREIGN KEY([courseId])
REFERENCES [Courses] ([id])

ALTER TABLE [ProfessorCourse] CHECK CONSTRAINT [FK_ProfessorCourse_courseId]

ALTER TABLE [StudentProgram] WITH CHECK ADD CONSTRAINT [FK_StudentProgram_studentId] FOREIGN KEY([studentId])
REFERENCES [Student] ([id])

ALTER TABLE [StudentProgram] CHECK CONSTRAINT [FK_StudentProgram_studentId]

ALTER TABLE [StudentProgram] WITH CHECK ADD CONSTRAINT [FK_StudentProgram_programId] FOREIGN KEY([programId])
REFERENCES [Program] ([id])

ALTER TABLE [StudentProgram] CHECK CONSTRAINT [FK_StudentProgram_programId]