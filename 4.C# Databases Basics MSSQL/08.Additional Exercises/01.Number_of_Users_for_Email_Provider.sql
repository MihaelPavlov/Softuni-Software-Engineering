

SELECT Query.Email , COUNT(Query.Email) AS [Number Of Users] FROM (
               SELECT RIGHT(Email,LEN(Email) - CHARINDEX('@' , Email)) AS Email 
               FROM Users
			  ) AS [Query]
GROUP BY Email
ORDER BY COUNT(Query.Email) DESC , Query.Email ASC
