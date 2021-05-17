SELECT magyarszo.szo FROM reactions
INNER JOIN magyarszo ON magyarszo.ID = reactions.magyarszo_id
WHERE reactions.reaction = 'L' AND reactions.felhasz_id = @userid