--Solution 1

SELECT DISTINCT SUBSTRING(wd.FirstName,1,1) AS [FirstLetter] FROM WizzardDeposits AS wd
WHERE DepositGroup = 'Troll Chest'

--Solution 2

SELECT 
  LEFT(FirstName, 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)
ORDER BY FirstLetter

--Solution 3

SELECT DISTINCT
  LEFT(FirstName, 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
ORDER BY FirstLetter