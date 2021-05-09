--DECLARE @user_id int
--set @user_id =1
--SELECT TOP(1) tetszes FROM magyarszo WHERE bekuldo = 1 ORDER BY tetszes DESC
SELECT TOP(1) COUNT(*) from felhasznalok
JOIN magyarszo on felhasznalok.ID=magyarszo.bekuldo
JOIN Reactions on Reactions.magyarszo_id= magyarszo.ID
WHERE bekuldo = @user_id AND reaction='L'
GROUP BY magyarszo.ID
order by COUNT(*) DESC
