DECLARE @magyarszo_id int

INSERT into magyarszo
values (cast(@magyarszo as nvarchar(50))collate Hungarian_100_CI_AI_SC_UTF8,@bekuldo_id,0,0)

SELECT @magyarszo_id= @@IDENTITY 

INSERT into szotar
VALUES(@angolszo_id,@magyarszo_id)

--SELECT * FROM angolszo