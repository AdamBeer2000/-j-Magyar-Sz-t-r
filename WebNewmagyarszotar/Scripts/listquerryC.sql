--DECLARE @pagenum INT
--DECLARE @search VARCHAR
--DECLARE @scale INT

DECLARE @prev INT

--set @search=''
--set @pagenum=0
--set @scale=20

set @prev=@pagenum*@scale

DROP TABLE IF EXISTS #TEMP 
DROP TABLE IF EXISTS #TMPTetszes
DROP TABLE IF EXISTS #TMPNemTetszes
DROP TABLE IF EXISTS #VOTMA
DROP TABLE IF EXISTS #NEMVOTMA

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
definicio,angolszo.bekuldo as 'angolbekuldo',
ISNULL(szotar.magyarszo_id,-1) as 'magyarszo',
ISNULL(magyarszo.szo,'Nincs mmég fordítás') as 'forditas',
ISNULL(magyarszo.bekuldo,3) as 'magyarbekuldo',
ISNULL(#TMPTetszes.tetszes,0)as 'tetszes' ,
ISNULL(#TMPNemTetszes.nemtetszes,0) as 'nemtetszes'
INTO #TEMP
FROM angolszo 
LEFT JOIN szotar on angolszo.ID=szotar.angolszo_id
LEFT join magyarszo on magyarszo_id=magyarszo.ID

LEFT JOIN #TMPTetszes on szotar.magyarszo_id=#TMPTetszes.magyarszo_id
LEFT JOIN #TMPNemTetszes on szotar.magyarszo_id=#TMPNemTetszes.magyarszo_id

WHERE angolszo.szo like '%'+@search+'%' OR magyarszo.szo like '%'+@search+'%' OR definicio like '%'+@search+'%'

SELECT TOP(@prev) with ties angolszoID 
into #VOTMA
FROM #TEMP
GROUP by angolszoID,angolszo,tetszes
ORDER by angolszo,tetszes

SELECT TOP(@scale) with ties angolszoID 
into #NEMVOTMA
FROM #TEMP
WHERE angolszoID not IN
(
    SELECT * from #VOTMA
)
GROUP by angolszoID,angolszo,tetszes
ORDER by angolszo,tetszes

SELECT *
FROM #TEMP
WHERE angolszoID IN
(
    SELECT * from #NEMVOTMA
)
ORDER by angolszo,tetszes
