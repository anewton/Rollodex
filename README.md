# Rollodex
Sample web application demoing a simple user contact database

Product/Project Requirements (initial MVP)
 - A user should be able to interact with a scrollable and pageable list of their business contacts, as well as adding, editing, and deleting their contacts.
 - Each business contact record contains basic information such as email, name and address. The application should access a simple database through a RESTful service. The UI is undefined.
 - The application must support a minimum of 20,000 users daily with each user having roughly ~1,000 contact records.
 - The application is an MVP, but the data cannot be lost.

Technical Requirements
 - A modern JavaScript UI framework of choice (Vue, React, Angular, etc.)
 - An HTTP-based API layer (.Net Core 3.1, doesn’t need to be SSL for the purposes of this test)
 - A database backend (candidate’s discretion, but should reflect a production-based solution)
   - Use YOUR preferred method for DB communication (e.g. DB/SQL client, an ORM, etc.) 

## To create initial database
 - Create data models
 - Create a data context for the models
 - Update data context with correct model DbSet properties and customize OnModelCreating
 - Setup EF migrations for SqlLite database
    ```
    dotnet tool install --global dotnet-ef
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet ef migrations add InitialCreate -p ./src/Data/Data.csproj -s ./src/Site/Site.csproj
    dotnet ef database update -p ./src/Data/Data.csproj -s ./src/Site/Site.csproj
    ```
## To create initial Site project
 - Use the Angular project template to create the correct settings for running a SPA application
 - Then make edits to the Startup.cs and Program.cs as needed to incorporate Autofac, API Controllers, and other database startup configuration
    ```
    dotnet new angular --no-https --auth None
    ```

## Remaining items to complete (TODO)
 - Add a user contact
 - Delete a user contact
 - Edit a user contact
 - Page the UI grid of user contacts
 - Unit testing of repository methods implemented and not in DbRepository.cs
 - Unit testing of service layer methods
 - Integration testing of UI
 - Load testing of the app to assure scalability to 20,000 users daily with ~1,000 contact records each (JMeter or other tool configuration and scripting)
 - Build and publish CI/CD