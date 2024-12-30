--instructor
-- GetForCourse

alter PROCEDURE GetInstructorsNotInCourse
    @CourseId INT,
    @Year INT
AS
BEGIN
    -- Select instructors not assigned to the given course in the specified year and semester
    SELECT 
       *
    FROM 
        Instructors i
    WHERE 
        i.Id NOT IN (
            SELECT 
                ioc.InstructorsId
            FROM 
                InstructorOfferedCourse ioc
            INNER JOIN
                OfferedCourses oc
            ON 
                ioc.OfferedCoursesCourseId = oc.CourseId
                AND ioc.OfferedCoursesYear = oc.Year
            WHERE 
                oc.CourseId = @CourseId 
                AND oc.Year = @Year 
        );
END;

-- Generic stored procedure (generic CRUD operations) ------------------------------------------
-- Insert --

alter PROCEDURE GenericInsert
    @TableName NVARCHAR(128),
    @Columns NVARCHAR(MAX),
    @Values NVARCHAR(MAX),
    @InsertedId INT=6 OUTPUT -- Output parameter for the new ID
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);

    -- Add the OUTPUT clause to capture the ID of the inserted row
    SET @SQL = 'INSERT INTO ' + QUOTENAME(@TableName) +
               ' (' + @Columns + ') OUTPUT INSERTED.CourseID VALUES (' + @Values + ') SET @InsertedId = SCOPE_IDENTITY();';

    -- Execute the dynamic SQL and set the @InsertedId
    EXEC sp_executesql @SQL, N'@InsertedId INT OUTPUT', @InsertedId OUTPUT;
	-- SET @InsertedId = SCOPE_IDENTITY();
END;


------------------------------
--generic delete--
alter PROCEDURE GenericDelete
    @TableName NVARCHAR(128),
    @KeyValue int
AS
BEGIN

    DECLARE @SQL NVARCHAR(MAX);

    SET @SQL = 'DELETE FROM ' + QUOTENAME(@TableName) +
               ' WHERE Id ='+ CAST(@KeyValue AS NVARCHAR);

    EXEC sp_executesql @SQL;
END;
GO

Exec GenericDelete Courses , 2125

---------------------
--GenericGet---

Create PROCEDURE GenericGet
    @TableName NVARCHAR(128),
    @KeyValue int
AS
BEGIN

    DECLARE @SQL NVARCHAR(MAX);

    SET @SQL = 'Select * from ' + QUOTENAME(@TableName) +
               ' WHERE Id ='+ CAST(@KeyValue AS NVARCHAR);

    EXEC sp_executesql @SQL;
END;
GO
-------------------
--GeneicGetAll

Create PROCEDURE GeneicGetAll
    @TableName NVARCHAR(128)
AS
BEGIN

    DECLARE @SQL NVARCHAR(MAX);

    SET @SQL = 'Select * from ' + QUOTENAME(@TableName) ;
              
    EXEC sp_executesql @SQL;
END;
GO

---------------------
--GenericUpdate
create PROCEDURE GenericUpdate
    @TableName NVARCHAR(128),       -- Name of the table to update
    @SetClause NVARCHAR(MAX),       -- SET clause for the update (e.g., "Column1 = Value1, Column2 = Value2")
    @WhereClause NVARCHAR(MAX)      -- WHERE clause to specify rows to update (e.g., "Id = 1")
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);

    -- Construct the dynamic SQL for the UPDATE statement
    SET @SQL = 'UPDATE ' + QUOTENAME(@TableName) +
               ' SET ' + @SetClause +
               ' WHERE ' + @WhereClause;

    -- Execute the dynamic SQL and set the @UpdatedId
    EXEC sp_executesql @SQL;
END;


--------------------------------
--OfferedCourse

--Add--
--+++++++++++
create PROCEDURE OfferedCourseInsert

    @Columns NVARCHAR(MAX),
    @Values NVARCHAR(MAX)
 
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);

  
    SET @SQL = 'INSERT INTO OfferedCourses ' +
               ' (' + @Columns + ')  VALUES (' + @Values + ') ';

    -- Execute the dynamic SQL and set the @InsertedId
    EXEC sp_executesql @SQL;
	
END;
Exec OfferedCourseInsert @Columns = 'Year, Semester, SectionNum, Time, ClassRoom, CourseId'  ,    @Values = '2, 2, 3, ''7:06 PM'', 2, 15';


Exec OfferedCourseInsert @Columns = 'Year, Semester, SectionNum, Time, ClassRoom, CourseId'  ,    @Values = 2, 3, 2, ''7:19 PM'', 22, 2026;
--+++++++++++

---delete---
create PROCEDURE DeleteOfferedCourse
    @KeyValue int,
	@year int
AS
BEGIN

    Delete from OfferedCourses where CourseId=@KeyValue and Year=@year
   
END;
GO
----------------
--get---
CREATE PROCEDURE GetOfferedCourseWithYear
    @CourseId INT,
    @Year INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT *
  
    FROM OfferedCourses oc
    INNER JOIN Courses c ON oc.CourseId = c.Id
    WHERE oc.CourseId = @CourseId AND oc.Year = @Year;
END;
----getAll_-
alter PROCEDURE GetAllOfferedCourses
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
      *
    FROM OfferedCourses
END;

---SETiNSTRUCTORtOoFFERDcOURSE

ALTER PROCEDURE AddInstructorToCourse
    @OfferedCourseId INT,
    @Year INT,
    @InstructorIds NVARCHAR(MAX) -- Comma-separated list of instructor IDs
AS
BEGIN

        IF @InstructorIds not like ''
		 begin
    -- Create a temporary table to store instructor IDs
    DECLARE @InstructorList TABLE (InstructorId INT);

    -- Split the comma-separated list into individual IDs
    INSERT INTO @InstructorList (InstructorId)
    SELECT CAST(value AS INT)
    FROM STRING_SPLIT(@InstructorIds, ',');

    -- Insert into InstructorOfferedCourse for all instructor IDs
    INSERT INTO InstructorOfferedCourse (InstructorsId, OfferedCoursesCourseId, OfferedCoursesYear)
    SELECT InstructorId, @OfferedCourseId, @Year
    FROM @InstructorList;
	end;
END;

--AddStudentstoCourse
alter PROCEDURE AddStudentsToCourse
    @OfferedCourseId INT,
    @Year INT,
	
    @StudentIds NVARCHAR(MAX),
	@Grade int-- Comma-separated list of instructor IDs
AS
BEGIN

        IF @StudentIds not like ''
		 begin
    -- Create a temporary table to store instructor IDs
    DECLARE @StudentList TABLE (StudentId INT);

    -- Split the comma-separated list into individual IDs
    INSERT INTO  @StudentList ( StudentId)
    SELECT CAST(value AS INT)
    FROM STRING_SPLIT(@StudentIds, ',');

    -- Insert into InstructorOfferedCourse for all instructor IDs
    INSERT INTO StudentsCourse(StudentId, OfferedCourseId, Year,grade)
    SELECT StudentId, @OfferedCourseId, @Year,@Grade
    FROM  @StudentList
	end;
END;
-------------------------------------------------
--==============================================
---Course--
--AddPrequestsToCourse
alter PROCEDURE AddPrequestsToCourse
    @id INT,
    @PrequestsIds NVARCHAR(MAX)
	
AS
BEGIN

    IF @PrequestsIds not like ''
	 begin
    -- Create a temporary table to store instructor IDs
    DECLARE @preTable TABLE (pre INT);

    -- Split the comma-separated list into individual IDs
    INSERT INTO  @preTable ( pre)
    SELECT CAST(value AS INT)
    FROM STRING_SPLIT(@PrequestsIds, ',');

    -- Insert into InstructorOfferedCourse for all instructor IDs
    INSERT INTO Prequestes(PrerequisitId, CourseId)
    SELECT pre, @id
    FROM  @preTable
	end;
END;






---getPrequests
CREATE PROCEDURE GetPrequestes
    @CourseId INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT C.* 
    FROM Courses C
    INNER JOIN Prequestes P ON C.Id = P.PrerequisitId
    WHERE P.CourseId = @CourseId;
END;

---update--
alter PROCEDURE UpdatePrequestes
    @CourseId INT,
    @NewPrerequisites NVARCHAR(MAX)
AS
BEGIN
  DELETE FROM Prequestes WHERE CourseId = @CourseId;
    IF @NewPrerequisites not like ''
	 begin
    DECLARE @PrerequisitesTable TABLE (PrerequisitId INT);
	
    INSERT INTO @PrerequisitesTable (PrerequisitId)
    SELECT value FROM STRING_SPLIT(@NewPrerequisites, ',');

    
	
   INSERT INTO Prequestes (CourseId, PrerequisitId)
    SELECT @CourseId, PrerequisitId FROM @PrerequisitesTable;	
 end;
END;

exec UpdatePrequestes 15,''

Exec AddStudentsToCourse  2022,2,'2',0


EXEC AddInstructorToCourse @OfferedCourseId = 5, @Year = 3, @InstructorIds = '1,4';
Exec AddInstructorToCourse  2022,2, '4,1004'


---------------------------------------------------------------------------


