BEGIN TRY
    SELECT TOP(1) * 
    FROM szgk AS s
        WHERE s.gyarto =@param1 AND s.uzemanyag = @param2
            ORDER BY s.ar DESC
END TRY
BEGIN CATCH
    PRINT(CAST(ERROR_NUMBER() AS VARCHAR) + ': ' + ERROR_MESSAGE())
END CATCH
