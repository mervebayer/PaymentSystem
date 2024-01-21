USE [PaymentSystem]
GO

/****** Object:  StoredProcedure [dbo].[GetExpensesByTime]    Script Date: 22.01.2024 02:24:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetExpensesByTime]
AS
BEGIN
    -- Daily Expenses
    SELECT
        'Daily' AS Type, 
        COUNT(DISTINCT UserId) AS UniqueUserCount,
        SUM(Amount) AS TotalAmount,
		SUM(Amount) / COUNT(DISTINCT UserId) AS AverageAmount
    FROM
        PaymentSystem.dbo.Expense
    WHERE
        ExpenseDate = CONVERT(DATE, GETDATE())
    GROUP BY
        CONVERT(VARCHAR, ExpenseDate, 23)


    -- Monthly Expenses
    SELECT
        'Monthly' AS Type,  
        COUNT(DISTINCT UserId) AS UniqueUserCount,
        SUM(Amount) AS TotalAmount,
		SUM(Amount) / COUNT(DISTINCT UserId) AS AverageAmount
    FROM
        PaymentSystem.dbo.Expense
    WHERE
        ExpenseDate >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND
        ExpenseDate < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)
    GROUP BY
        CONVERT(VARCHAR, DATEADD(MONTH, DATEDIFF(MONTH, 0, ExpenseDate), 0), 23)
END
GO


