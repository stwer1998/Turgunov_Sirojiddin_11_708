--"No 1"
SELECT * FROM [dbo].[DimEmployee] AS DE
WHERE DE.Gender='M' AND DE.StartDate>'2007-08-31' 
AND DE.DepartmentName='Marketing' OR DE.DepartmentName='Information Services'

--"No 2"
SELECT DP.SpanishProductName FROM [dbo].[DimProduct] AS DP
JOIN [dbo].[FactInternetSales] ON [dbo].[FactInternetSales].ProductKey=DP.ProductKey AND 
(YEAR([dbo].[FactInternetSales].OrderDate)=2007 AND MONTH([dbo].[FactInternetSales].OrderDate)=06 OR 
MONTH([dbo].[FactInternetSales].OrderDate)=07 OR MONTH([dbo].[FactInternetSales].OrderDate)=08)
JOIN [dbo].[DimCustomer] ON [dbo].[DimCustomer].GeographyKey IN 
(SELECT [dbo].[DimGeography].GeographyKey FROM [dbo].[DimGeography]
WHERE [dbo].[DimGeography].EnglishCountryRegionName='Canada')

--"No 4"
SELECT * FROM [dbo].[DimProductSubcategory] AS SUB
WHERE SUB.ProductSubcategoryKey IN(
SELECT DM.ProductSubcategoryKey FROM [dbo].[DimProduct] AS DM
WHERE DM.ProductKey IN(
SELECT TOP(1) FI.ProductKey FROM [dbo].[FactInternetSales] AS FI
WHERE YEAR(FI.OrderDate)=2007 AND MONTH(FI.OrderDate)=06 OR MONTH(FI.OrderDate)=07 OR MONTH(FI.OrderDate)=08
ORDER BY FI.OrderQuantity))

--"No 5"
SELECT P.EnglishProductName FROM [dbo].[DimProduct] AS P
WHERE P.ProductSubcategoryKey IN
(SELECT S.ProductSubcategoryKey FROM [dbo].[DimProductSubcategory] AS S
WHERE S.ProductCategoryKey<>
(SELECT C.ProductCategoryKey FROM [dbo].[DimProductCategory] AS C
WHERE C.EnglishProductCategoryName='Accessories'))

--"No 6"
SELECT C.FirstName,P.EnglishProductName FROM [dbo].[DimCustomer] AS C,[dbo].[DimProduct] AS P
WHERE C.CustomerKey IN
(SELECT S.CustomerKey FROM [dbo].[FactInternetSales] AS S
WHERE CurrencyKey IN
(SELECT CurrencyKey FROM [dbo].[DimCurrency] AS Q
WHERE Q.CurrencyName LIKE '&DOLLAR'))

