SELECT SUM(k.Diff) AS SumDifference
FROM(
SELECT wd.DepositAmount -(SELECT w.DepositAmount  FROM WizzardDeposits AS w WHERE w.Id = wd.Id+1)
AS Diff
	FROM WizzardDeposits AS wd)AS k