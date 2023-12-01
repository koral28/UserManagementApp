DECLARE @Users TABLE( ID INT, NAME NVARCHAR(MAX) ) 
INSERT INTO @Users VALUES(1,'Tom'),(2,'Moshe'),(3,'Sarit') 
DECLARE @locations TABLE( ID INT, Location_Time DATETIME ) 
INSERT INTO @locations 
VALUES(1, DATEADD(MINUTE,-3,GETUTCDATE())) ,
(1, DATEADD(MINUTE,-16,GETUTCDATE())) ,
(1, DATEADD(MINUTE,-23,GETUTCDATE())) ,
(2, DATEADD(MINUTE,-186,GETUTCDATE())) ,
(2, DATEADD(MINUTE,-230,GETUTCDATE())) ,
(3, DATEADD(MINUTE,-38,GETUTCDATE())) ,
(3, DATEADD(MINUTE,-600,GETUTCDATE()))  ;


WITH Locations AS (
SELECT ID, Location_Time, 
ROW_NUMBER() OVER(PARTITION BY ID ORDER BY Location_Time DESC) AS RowNumber
FROM @locations
)

SELECT U.ID, U.NAME, locations.Location_Time AS location_time
FROM @Users U
JOIN Locations locations ON U.ID = locations.ID AND locations.RowNumber = 1
ORDER BY U.ID;