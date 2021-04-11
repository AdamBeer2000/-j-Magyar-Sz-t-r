DECLARE @prev INT

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

SELECT angolszo_id,angolszo.szo as 'angolszo',definicio,angolszo.bekuldo as 'angolbekuldo',szotar.magyarszo_id,CAST(magyarszo.szo as NVARCHAR) as 'forditas',magyarszo.bekuldo as 'magyarbekuldo'
,ISNULL(#TMPTetszes.tetszes,0)as 'tetszes' ,ISNULL(#TMPNemTetszes.nemtetszes,0) as 'nemtetszes'
INTO #TEMP
FROM szotar 
JOIN angolszo on angolszo_id = angolszo.ID 
JOIN magyarszo on szotar.magyarszo_id = magyarszo.ID

FULL JOIN #TMPTetszes on szotar.magyarszo_id=#TMPTetszes.magyarszo_id
FULL JOIN #TMPNemTetszes on szotar.magyarszo_id=#TMPNemTetszes.magyarszo_id

WHERE angolszo.szo like '%'+@search+'%' OR magyarszo.szo like '%'+@search+'%' OR definicio like '%'+@search+'%'

SELECT TOP(@prev) with ties angolszo_id 
into #VOTMA
FROM #TEMP
GROUP by angolszo_id,angolszo,tetszes
ORDER by angolszo,tetszes

SELECT TOP(@scale) with ties angolszo_id 
into #NEMVOTMA
FROM #TEMP
WHERE angolszo_id not IN
(
    SELECT * from #VOTMA
)
GROUP by angolszo_id,angolszo,tetszes
ORDER by angolszo,tetszes

SELECT *
FROM #TEMP
WHERE angolszo_id IN
(
    SELECT * from #NEMVOTMA
)
ORDER by angolszo,tetszes
