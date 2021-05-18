SELECT felhasznalok.felhasznalonev, COUNT(Reactions.reaction) from felhasznalok
JOIN magyarszo on felhasznalok.ID=magyarszo.bekuldo
JOIN Reactions on Reactions.magyarszo_id= magyarszo.ID
WHERE reaction = 'L'
GROUP BY felhasznalonev