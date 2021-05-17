SELECT eng.ID, eng.szo, hun.ID, hun.szo, hun.tetszes, hun.nemtetszes, hun.bekuldo, eng.definicio, eng.bekuldo
FROM szotar AS sz 
INNER JOIN magyarszo AS hun ON sz.magyarszo_id = hun.ID 
INNER JOIN angolszo AS eng ON eng.ID = sz.angolszo_id 
WHERE sz.magyarszo_id NOT IN 
(
    select magyarszo_id from Reactions
    WHERE felhasz_id=@userid
)
AND angolszo_id in 
(
    SELECT angolszo_id FROM szotar
    WHERE magyarszo_id NOT IN 
    (
        select magyarszo_id from Reactions
        WHERE felhasz_id=@userid
    )
    GROUP BY angolszo_id 
    HAVING COUNT(*)>=2
)
ORDER BY eng.szo