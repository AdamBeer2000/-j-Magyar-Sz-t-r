SELECT eng.ID, eng.szo, hun.ID, hun.szo, hun.tetszes, hun.nemtetszes, hun.bekuldo, eng.definicio, eng.bekuldo 
	FROM szotar AS sz 
	INNER JOIN magyarszo AS hun ON sz.magyarszo_id = hun.ID 
	INNER JOIN angolszo AS eng ON eng.ID = sz.angolszo_id 
		ORDER BY eng.szo";           