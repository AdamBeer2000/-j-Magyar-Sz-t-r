DECLARE @old_reaction CHAR
SELECT @old_reaction=reaction

FROM Reactions WHERE felhasz_id = @felhasz_id and  magyarszo_id = @magyarszo_id

IF(@old_reaction is not null)--reagált e már erre a szóra a felhasználó
    IF(@reaction=@old_reaction)--rá ugyan ezzel akkor visszavonja
        BEGIN
            DELETE FROM Reactions 
            WHERE felhasz_id = @felhasz_id and  magyarszo_id = @magyarszo_id
        END
    ELSE
        BEGIN                  --egyébként beálítjuk a kapot értékre
            UPDATE Reactions
            SET reaction=@reaction
            WHERE felhasz_id = @felhasz_id and  magyarszo_id = @magyarszo_id
        END
ELSE
    BEGIN
        INSERT into Reactions
        VALUES(@felhasz_id,@magyarszo_id,@reaction)

    END

SELECT * FROM Reactions
SELECT * FROM magyarszo