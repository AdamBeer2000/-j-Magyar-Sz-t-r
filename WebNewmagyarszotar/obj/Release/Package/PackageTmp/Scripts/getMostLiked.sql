--DECLARE @user_id int
--set @user_id =1
--SELECT TOP(1) tetszes FROM magyarszo WHERE bekuldo = 1 ORDER BY tetszes DESC
SELECT COUNT(Reactions.reaction) from felhasznalok
JOIN magyarszo on felhasznalok.ID=magyarszo.bekuldo
JOIN Reactions on Reactions.magyarszo_id= magyarszo.ID
WHERE reaction = 'L' AND  bekuldo = @user_id
GROUP BY felhasznalonev


