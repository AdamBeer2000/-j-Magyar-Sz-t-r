DROP TABLE IF EXISTS #TEMP 
SELECT angolszo_id,angolszo.szo as 'angolszo',definicio,angolszo.bekuldo as 'angolbekuldo',magyarszo_id,CAST(magyarszo.szo as NVARCHAR) as 'forditas',magyarszo.bekuldo as 'magyarbekuldo',tetszes,nemtetszes
INTO #TEMP
FROM szotar 
JOIN angolszo on angolszo_id = angolszo.ID 
JOIN magyarszo on magyarszo_id = magyarszo.ID
WHERE angolszo.szo like '%PAR_3%' OR magyarszo.szo like '%PAR_3%' OR definicio like '%PAR_3%'

select TOP(PAR_1) *
from #TEMP
where angolszo_id NOT in 
(
    select TOP(PAR_2) with ties angolszo_id
    from #TEMP
    ORDER By angolszo,tetszes
)
ORDER By angolszo,tetszes