SELECT ws.DepositGroup,MAX(ws.MagicWandSize)AS LongestMagicWand
FROM WizzardDeposits AS ws
GROUP BY ws.DepositGroup
