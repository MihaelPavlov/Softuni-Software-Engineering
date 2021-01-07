-- First Solution
SELECT TOP(2) AverageWandSizeQuery.DepositGroup FROM 	(
		SELECT wd.DepositGroup , AVG(wd.MagicWandSize) AS AverageWandSize
		FROM WizzardDeposits AS wd
		GROUP BY wd.DepositGroup) AS [AverageWandSizeQuery]
ORDER BY AverageWandSize


--Second Solution
SELECT TOP(2) MinAverageWandSize.DepositGroup FROM 	
	(SELECT  AverageWandSizeQuery.DepositGroup , MIN(AverageWandSizeQuery.AverageWandSize) as MinAverageSize FROM (
		SELECT wd.DepositGroup , AVG(wd.MagicWandSize) AS AverageWandSize
		FROM WizzardDeposits AS wd
		GROUP BY wd.DepositGroup) AS [AverageWandSizeQuery]
GROUP BY DepositGroup) 
AS [MinAverageWandSize]
ORDER BY MinAverageWandSize.MinAverageSize 


