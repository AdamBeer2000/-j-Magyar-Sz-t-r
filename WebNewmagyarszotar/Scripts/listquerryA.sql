SELECT angolszo_id,angolszo.szo as 'angolszo',definicio,angolszo.bekuldo as 'angolbekuldo',magyarszo_id,CAST(magyarszo.szo as NVARCHAR) as 'forditas',magyarszo.bekuldo as 'magyarbekuldo',tetszes,nemtetszes
FROM szotar 
JOIN angolszo on angolszo_id = angolszo.ID 
JOIN magyarszo on magyarszo_id = magyarszo.ID
WHERE angolszo.szo like '%%' OR magyarszo.szo like '%%' OR definicio like '%%'