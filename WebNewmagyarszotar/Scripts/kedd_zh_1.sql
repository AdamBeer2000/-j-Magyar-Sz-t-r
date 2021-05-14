--USE h05_ULMXXI
GO
drop function zh_elso_feladat
GO
GO
CREATE FUNCTION zh_elso_feladat (@gyarto as char(6))
RETURNS CHAR(6) as
BEGIN
    DECLARE @rendszam char(6)
    SELECT @rendszam=szgk.rendszam from szgk
    JOIN szgk_felsz on szgk.rendszam=szgk_felsz.rendszam
    WHERE szgk.kolcsonozheto=1 and szgk.gyarto=@gyarto
    GROUP by szgk.rendszam,szgk.ar
    ORDER by COUNT(*),szgk.ar DESC
    RETURN @rendszam
END
GO

--SELECT szgk.rendszam, COUNT(*),szgk.ar from szgk
--JOIN szgk_felsz on szgk.rendszam=szgk_felsz.rendszam
--WHERE szgk.kolcsonozheto=1 and szgk.gyarto='Mazda' 
--GROUP by szgk.rendszam,szgk.ar
--ORDER by COUNT(*),szgk.ar DESC

DECLARE @rendszam char(6)
set @rendszam='Mazda'
if dbo.zh_elso_feladat(@rendszam) is NULL
BEGIN 
    print 'Null'
END
ELSE
BEGIN
    PRINT dbo.zh_elso_feladat(@rendszam)
END

--PRINT dbo.zh_elso_feladat('BMW')
--PRINT dbo.zh_elso_feladat('Mazda')
--PRINT dbo.zh_elso_feladat('NemLétezekLol')