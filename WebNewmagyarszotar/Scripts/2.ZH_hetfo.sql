go
DROP FUNCTION elso_feladat 
GO
GO
create FUNCTION elso_feladat (@catId int)RETURNS TABLE AS 
RETURN
(
    SELECT top(3) Suppliers.SupplierID,Suppliers.CompanyName,(CAST(SUM(UnitsInStock*UnitPrice) as money))as osszErtek from Products
    JOIN Suppliers on Products.SupplierID=Suppliers.SupplierID
    WHERE CategoryID=@catId
    GROUP by Suppliers.SupplierID,Suppliers.CompanyName
    ORDER by SUM(UnitsInStock) DESC
)
go
--SELECT * FROM elso_feladat(0)--nem létezik a beszálíto nincs adat
--SELECT * FROM elso_feladat(1)--létezik a beszálíto és van adat

go
DROP PROCEDURE masodik_feladat
GO
CREATE PROCEDURE masodik_feladat (@catId int) AS
BEGIN
    DECLARE @suppId INT
    SELECT @suppId= SupplierID 
        FROM elso_feladat(@catId)
        ORDER by osszErtek 
    if @suppId is NULL 
    BEGIN
        PRINT 'beszállító a fentiek szerint nem azonosítható'
    END
END
GO
















