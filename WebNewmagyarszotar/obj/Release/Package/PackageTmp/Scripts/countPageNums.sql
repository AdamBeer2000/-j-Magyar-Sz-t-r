SET NOCOUNT ON
--DECLARE @pagenum INT
--DECLARE @search VARCHAR
--DECLARE @scale INT

DECLARE @prev INT

--set @search=''
--set @scale=20

DROP TABLE IF EXISTS #TEMP 
DROP TABLE IF EXISTS #TMPTetszes
DROP TABLE IF EXISTS #TMPNemTetszes

SELECT magyarszo_id,COUNT(*) as 'tetszes'
into #TMPTetszes
FROM Reactions 
WHERE reaction='L'
GROUP by magyarszo_id

SELECT magyarszo_id,COUNT(*) as 'nemtetszes'
into #TMPNemTetszes
FROM Reactions 
WHERE reaction='D'
GROUP by magyarszo_id

SELECT angolszo.ID as 'angolszoID',
angolszo.szo as 'angolszo',
definicio,
angolszo.bekuldo as 'angolbekuldoId',
ISNULL(szotar.magyarszo_id,-1) as 'magyarszo',
ISNULL(magyarszo.szo,'Nincs mmég fordítás') as 'forditas',
ISNULL(magyarszo.bekuldo,3) as 'magyarbekuldoId',
ISNULL(#TMPTetszes.tetszes,0)as 'tetszes' ,
ISNULL(#TMPNemTetszes.nemtetszes,0) as 'nemtetszes',
ISNULL(felhasznalok.felhasznalonev,'Senki') as 'magyarbekuldoNev',
(select felhasznalok.felhasznalonev from felhasznalok WHERE felhasznalok.ID=angolszo.bekuldo) as 'angolbekuldoldoNev'
INTO #TEMP
FROM angolszo 
LEFT JOIN szotar on angolszo.ID=szotar.angolszo_id
LEFT join magyarszo on magyarszo_id=magyarszo.ID

LEFT JOIN #TMPTetszes on szotar.magyarszo_id=#TMPTetszes.magyarszo_id
LEFT JOIN #TMPNemTetszes on szotar.magyarszo_id=#TMPNemTetszes.magyarszo_id

LEFT JOIN felhasznalok on magyarszo.bekuldo = felhasznalok.ID
--INNER JOIN felhasznalok on angolszo.bekuldo = felhasznalok.ID

WHERE angolszo.szo like '%'+@search+'%' OR magyarszo.szo like '%'+@search+'%' OR definicio like '%'+@search+'%'

declare @db INT

SELECT (count(*)/20)as db
FROM
(
    SELECT  count(*) as  [db] from #TEMP 
    GROUP BY angolszo
)as ass

