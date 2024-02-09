SELECT TOP (1000) [RegNo]
      ,[FirstName]
      ,[LastName]
      ,[GPA]
      ,[Contact]
  FROM [Lab3_Tasks].[dbo].[Student];


SELECT *
 FROM Student;

SELECT RegNo, FirstName
FROM Student;

SELECT *
 FROM Student
 WHERE GPA>3.5;

SELECT *
 FROM Student
 WHERE GPA<=3.5;

SELECT CONCAT(FirstName, LastName) AS FullName
FROM Student;




