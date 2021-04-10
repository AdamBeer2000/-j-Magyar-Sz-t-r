DECLARE @vaneFelhasz INT
DECLARE @vaneEmail INT

SELECT @vaneFelhasz=COUNT(*) 
    FROM felhasznalok
    WHERE felhasznalonev=@p1
    GROUP BY felhasznalonev

SELECT @vaneEmail=COUNT(*) 
    FROM felhasznalok
    WHERE felhasznalonev=@p2
    GROUP BY felhasznalonev

if @vaneFelhasz>0 OR @vaneEmail>0
    BEGIN;
        THROW 69420, 'Már létezik ilyen nevü felhasználó vagy ilyen email cím', 1;
    END;
ELSE 
    BEGIN 
        INSERT into felhasznalok ([felhasznalonev],[emailcim],[jogosultasag],[jelszo])
        VALUES (@p1,@p2,@p3,@p4)
    END

