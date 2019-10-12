Grace Art Auction (GAA) is an online art community made for people connected with paintings as my coursework on Object-Oriented Programming
It features information on artists, who collaborate with the auction, all of their paintings, information about famous art museums, auctions
and a personal collection of bought paintings.

There are several roles in GAA: a collector (person interested in buying a painting), a museum or gallery worker and an admin.
A user must be logged in to use the application (the first page features login and register interfaces) since it has different features for 
different roles.
Admin has rights to add\edit\delete information on all objects in the database, which is stored in MongoDB.
When an auction is created, it features information about date and time, when it will be opened. Existing paitings from the database of artists
can be added to the auction, but they cannot be bought before the specified time.
Each role has an ability to buy paintings. Painting, which is bought by a private individual, goes to his collection. Thus,
other users can see the painting on the auction, but they cannot buy it. They also cannot see the name of the buyer. If a painting is bought
by a museum worker, it adds up to the collection of the museum, all users can see it both on the page of the museum and on the auction page.
