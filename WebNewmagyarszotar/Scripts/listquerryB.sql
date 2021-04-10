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

SELECT angolszo_id,angolszo.szo as 'angolszo',definicio,angolszo.bekuldo as 'angolbekuldo',szotar.magyarszo_id,CAST(magyarszo.szo as NVARCHAR) as 'forditas',magyarszo.bekuldo as 'magyarbekuldo'
,ISNULL(#TMPTetszes.tetszes,0)as 'tetszes' ,ISNULL(#TMPNemTetszes.nemtetszes,0) as 'nemtetszes'
INTO #TEMP
FROM szotar 
JOIN angolszo on angolszo_id = angolszo.ID 
JOIN magyarszo on szotar.magyarszo_id = magyarszo.ID

FULL JOIN #TMPTetszes on szotar.magyarszo_id=#TMPTetszes.magyarszo_id
FULL JOIN #TMPNemTetszes on szotar.magyarszo_id=#TMPNemTetszes.magyarszo_id

WHERE angolszo.szo like '%PAR_3%' OR magyarszo.szo like '%PAR_3%' OR definicio like '%PAR_3%'

select TOP(PAR_1) *
from #TEMP
where angolszo_id NOT in 
(
    select TOP(PAR_2) with ties angolszo_id
    from #TEMP
    ORDER By angolszo,tetszes
)
ORDER By angolszo,tetszes DESC

