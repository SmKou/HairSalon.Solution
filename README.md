# Eau Claire's Salon

By: Stella Marie

## Technologies Used

- C# 12
- .Net 6.0
  - Entity Framework Core
  - MySql

## Description

Eau Claire's Salon is an MVC web app for managing stylists with specific specialties working at a salon and their clients. A client can only see a single stylist.

- List of all stylists
- Select a stylist, see details and list of all clients for stylist
- Add new stylist
- Add client to specific stylist
  - Cannot add clients if not stylists have been added

### In Consideration

- Include form: search for stylist by name
  - Display as list of results
- Include form: search for client by name
  - Display as list of results
- Add feature: add appointment to client
- Add feature: add appointment to stylist
  - Check for conflicting appointments
- Add feature: cost per appointment for stylist
- Add styling

## Complete Setup

This app requires use of a database.

## Database Schemas

## Database

To setup your own database, you may need to download MySQL Server and MySQL Workbench. Using Workbench is not completely necessary, being a GUI (and it is slower than using CLI), but if you are starting out with databases, Workbench may make it easier. Note that if you use CLI, your tables and column names will need to be surrounded by backticks \`\` as in: \`restaurant_list\`.\'cuisines\'. The query writer in Workbench would not require use of the backticks, which would be added for you when it generates a SQL script.

- Setup a database: ```CREATE DATABASE hairsalon;```
- Select the database: ```USE hairsalon;```
- Add three tables:
  - ```CREATE TABLE specialties (SpecialtyId INT PRIMARY KEY NOT NULL AUTO_INCREMENT, Name VARCHAR(255));```
  - ```CREATE TABLE stylists (StylistId INT PRIMARY KEY NOT NULL AUTO_INCREMENT, NAME VARCHAR(255), SpecialtyId INT, FOREIGN KEY (SpecialtyId) REFERENCES specialties(SpecialtyId));```
  - ```CREATE TABLE clients (ClientId INT NOT NULL AUTO_INCREMENT, Name VARCHAR(255), StylistId INT, PRIMARY KEY (ClientId), FOREIGN KEY (StylistId) REFERENCES stylists(StylistId))```

Note: Two formats for setting up a table and designating its primary key have been listed here. They work the same.

```sql
CREATE TABLE tablename (id INT PRIMARY KEY NOT NULL AUTO_INCREMENT);

CREATE TABLE tablename (id INT NOT NULL AUTO_INCREMENT, PRIMARY KEY (id))
```

In your IDE:
- Create a file in the HairSalon assembly: appsettings.json
  - Do not remove the mention of this file from .gitignore
- Add this code:

```json
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=[hostname];Port=[port_number];database=[database_name];uid=[username];pwd=[password]"
    }
}
```

Replace the values accordingly and brackets are not to be included.

### Run the App

Once you have a database setup and the connection string included in the appsettings.json, you can run the app:

- Navigate to main page of repo
- Either fork or clone project to local directory
- Bash or Terminal: ```dotnet run --project HairSalon```
  - If you navigate into the main assembly: HairSalon, use ```dotnet run```

If the app does not launch in the browser:
- Run the app
- Open a browser
- Enter the url: https://localhost:5001/

## Known Bugs

Please report any issues in using the app.

## License

[MIT](https://choosealicense.com/licenses/mit/)

Copyright (c) 2023 Sm Kou