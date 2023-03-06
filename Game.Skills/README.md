## - Skill class library.
Skills are pending for definition, I still need to think if I'm going to handle everything logically or should I left some for client-side implementation.

In example, I could mathematically interpret a cone in front of the player casting a spell and damaging everything in it's area, but for this I should have a previous interpretation of the world's space and every necessary entity with a way to track it's actual location in that world's representation.

A client-sided way would be to handle visual transform and hit-boxes. IE, the player throws a fire ball, if the fire ball transform hits another character hit-box, that character should receive a hit-points update. 