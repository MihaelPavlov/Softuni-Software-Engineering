SELECT FirstName ,LastName,FORMAT(BirthDate,'MM-dd-yyy') AS BirthDate ,c.[Name] AS Hometown,
Email FROM Accounts AS a 
INNER JOIN Cities AS c ON a.CityId = c.Id
WHERE Email LIKE 'e%'
ORDER BY c.[Name] ASC

GO

SELECT c.[Name] ,COUNT(*) AS Hotels FROM Hotels AS h
INNER JOIN Cities AS c ON h.CityId = c.Id
GROUP BY CityId , c.[Name]
ORDER BY COUNT(*) DESC , c.[Name]


GO

SELECT AccountId ,a.FirstName + ' '+ a.LastName AS FullName ,
	 	MAX(DATEDIFF(DAY , ArrivalDate , ReturnDate)) AS LongestTrip,
		MIN(DATEDIFF (DAY , ArrivalDate,ReturnDate)) AS ShortestTrip
FROM AccountsTrips AS [at]
INNER JOIN Trips AS t ON t.Id = [at].TripId
INNER JOIN Accounts AS a ON a.Id = [at].AccountId
WHERE t.CancelDate IS NULL AND a.MiddleName IS NULL
GROUP BY AccountId , a.FirstName , a.LastName
ORDER BY LongestTrip DESC , ShortestTrip ASC

GO

SELECT TOP(10) c.Id , c.[Name] , c.CountryCode , COUNT(*) FROM Accounts AS a
INNER JOIN Cities AS c ON a.CityId = c.Id 
GROUP BY a.CityId  , c.Id , c.[Name] ,c.CountryCode
ORDER BY COUNT(a.CityId) DESC

GO

SELECT a.Id , a.Email ,c.[Name] , COUNT(*) AS Trips FROM Accounts AS a
INNER JOIN Cities AS c  ON c.Id = a.CityId 
INNER JOIN Hotels AS h ON h.CityId = c.Id
INNER JOIN AccountsTrips AS [at] ON [at].AccountId = a.Id
INNER JOIN Trips AS t ON t.Id =[at].TripId
INNER JOIN Rooms AS r ON r.HotelId = h.Id
WHERE TripId = t.Id AND t.RoomId = r.Id AND r.HotelId =  h.Id AND h.CityId = a.CityId
GROUP BY a.Id , a.Email ,c.[Name] 
ORDER BY Trips DESC ,a.Id

GO

SELECT t.Id , FirstName+' ' + MiddleName + ' ' + LastName AS [Full Name],
		c.[Name] AS [From] , c2.[Name] AS [To],
		CASE
			WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
			ELSE CONVERT(NVARCHAR,DATEDIFF(day,t.ArrivalDate , t.ReturnDate)) + ' days' 
		END AS Duration
FROM Accounts AS a 
JOIN Cities AS c ON c.Id = a.CityId
JOIN AccountsTrips AS [at] ON [at].AccountId =a.Id
JOIN Trips AS t ON t.Id = [at].TripId
JOIN Rooms AS r ON r.Id =t.RoomId
JOIN Hotels AS h ON h.Id = r.HotelId
JOIN Cities AS c2 ON c2.Id = h.CityId
WHERE FirstName+' ' + MiddleName + ' ' + LastName  IS NOT NULL
ORDER BY FirstName+' ' + MiddleName + ' ' + LastName , t.Id


GO

CREATE OR alter FUNCTION udf_GetAvailableRoom(@HotelId INT , @Date DATETIME , @People INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @hotelBaseRate DECIMAL(18,2) = (SELECT TOP(1) BaseRate FROM Hotels WHERE Id = @HotelId);
	DECLARE @hotelRoomPrice DECIMAL(18,2) = (
												SELECT TOP(1) r.Price FROM Hotels  AS h
												INNER JOIN Rooms AS r ON r.HotelId = h.Id
												WHERE @HotelId = r.HotelId
											);
	DECLARE @roomId INT = (
						SELECT TOP(1) r.Id FROM Hotels  AS h
						INNER JOIN Rooms AS r ON r.HotelId = h.Id
						WHERE @HotelId = r.HotelId
						)
	DECLARE @isTheRoomFree INT = ISNULL((							
								SELECT TOP(1) r.Id FROM Rooms AS r	
								INNER JOIN Trips AS t ON t.RoomId = r.Id
								WHERE r.HotelId=112 AND @Date NOT BETWEEN t.ArrivalDate AND t.ReturnDate
								AND t.CancelDate is null
								),0)
	DECLARE @totalPrice DECIMAL(18,2) = (@hotelBaseRate + @hotelRoomPrice) * @People;
	DECLARE @isTheBedEnough INT  = (SELECT TOP(1) Beds FROM Rooms WHERE @isTheRoomFree = Id)
	DECLARE @EndResult NVARCHAR(MAX) ;
		IF (@isTheRoomFree !> 0)
		BEGIN
				IF(@isTheBedEnough >=@People)
				BEGIN
					DECLARE @roomClass nvarchar(30) = (SELECT TOP(1) [Type] FROM Rooms WHERE @isTheRoomFree = Id)

					SET @EndResult = 'Room ' + CONVERT(nvarchar(max),@HotelId) + ': ' + CONVERT(NVARCHAR(MAX) , @roomClass) + '(' + CONVERT(NVARCHAR(MAX) ,@isTheBedEnough) + ' beds) - ' + '$'  + CONVERT(NVARCHAR(MAX) , @totalPrice);
				END 
				ELSE
				BEGIN
					SET @EndResult = 'No rooms available';
				END
		END
		ELSE
		BEGIN
			SET @EndResult = 'No rooms available';
		END

	RETURN @EndResult

END

							
			SELECT dbo.udf_GetAvailableRoom(100, '2011-12-17',2)					




