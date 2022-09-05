# xero

Following changes made to Refactor the Code. 

1. Restructure the Solution into following projects to improve the overall design of the API solution. This enhances the readability and maintenance of the code base.

       Xero.Api – API project that contains the api controllers and aspnetcore middleware for request handling.

       Xero.Domain – Class library project for Domain model classes. Product, ProductOption etc.

       Xero.Repository – Class library project to implement unit of work repository pattern data access layer.

2. Within the API controller split the product and product option api methods in to separate controllers. 

3. Implemented the UnitOfWork Repository pattern for generic crud operations with entity framework for data access layer. 

4. Replaced inline SQL commands with linq queries to avoid any potential sql injection security issues.

5. Moved the db connection string in to appsettings.json

6. Created separate model classes for product and productoptions, moved these into domain project. This will add structure into the solution and support domain driven design.    

7. Refactor crud operations with generic repository and removed the repeated code for products, productoption data access.

8. Added dependency injection to remove tight coupling. UnitOfWork dependency injected via the .net core configure services.

       

