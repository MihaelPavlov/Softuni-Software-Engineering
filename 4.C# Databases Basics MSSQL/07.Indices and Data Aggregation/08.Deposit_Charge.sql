SELECT wd.DepositGroup , MagicWandCreator , MIN(wd.DepositCharge) AS [MinDepositCharge] FROM WizzardDeposits AS wd
GROUP BY wd.DepositGroup , MagicWandCreator
ORDER  BY MagicWandCreator , DepositGroup