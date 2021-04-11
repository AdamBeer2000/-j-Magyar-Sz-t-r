DECLARE @magyarszo_id int
DECLARE @bekuldo varchar 

select @bekuldo= felhasznalonev 
FROM felhasznalok
WHERE ID=@bekuldo_id

INSERT into magyarszo
values (@magyarszo,@bekuldo,0,0)

SELECT @magyarszo_id= @@IDENTITY 

INSERT into szotar
VALUES(@angolszo_id,@magyarszo_id)

--SELECT * FROM angolszo