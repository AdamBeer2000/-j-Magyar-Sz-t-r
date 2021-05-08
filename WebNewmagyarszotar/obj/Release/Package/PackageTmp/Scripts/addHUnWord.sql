DECLARE @magyarszo_id int

INSERT into magyarszo
values (@magyarszo,@bekuldo_id,0,0)

SELECT @magyarszo_id= @@IDENTITY 

INSERT into szotar
VALUES(@angolszo_id,@magyarszo_id)

--SELECT * FROM angolszo