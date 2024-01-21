USE [PaymentSystem]
GO

/****** Object:  StoredProcedure [dbo].[GetRequestStatusCounts]    Script Date: 22.01.2024 02:28:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[GetRequestStatusCounts]
AS
BEGIN
    -- Daily Counts
    SELECT
        'Daily' AS Type, 
        SUM(CASE WHEN Status = 3 THEN 1 ELSE 0 END) AS RejectedCount,
        SUM(CASE WHEN Status = 2 THEN 1 ELSE 0 END) AS ApprovedCount
    FROM
        PaymentSystem.dbo.Expense
    WHERE
        ExpenseDate = CONVERT(DATE, GETDATE())
    GROUP BY
        CONVERT(VARCHAR, ExpenseDate, 23)



    -- Monthly Counts
    SELECT
        'Monthly' AS Type, 
        SUM(CASE WHEN Status = 3 THEN 1 ELSE 0 END) AS RejectedCount,
        SUM(CASE WHEN Status = 2 THEN 1 ELSE 0 END) AS ApprovedCount
    FROM
        PaymentSystem.dbo.Expense
    WHERE
        ExpenseDate >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND
        ExpenseDate < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)
    GROUP BY
        CONVERT(VARCHAR, DATEADD(MONTH, DATEDIFF(MONTH, 0, ExpenseDate), 0), 23)
END
GO


