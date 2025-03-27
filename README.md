# Product Management Dashboard

## Overview
The Product Management Dashboard is a .NET 8 application designed to manage product information, including product names, codes, prices, quantities, and categories. This project uses Entity Framework Core for database operations.

## Prerequisites
- .NET 8 SDK
- SQL Server

## Initial Setup and Configuration

### Database Migration
The initial database migration creates a `Product` table with the following columns:
- `Id` (int): Primary key, auto-incremented.
- `ProductName` (string): Name of the product.
- `ProductCode` (string): Unique code for the product.
- `Price` (float): Price of the product.
- `Quantity` (int): Quantity of the product in stock.
- `Category` (string): Category of the product.
- `CreatedAt` (DateTime): Timestamp of when the product was created.

### Applying Migrations
To apply the initial migration and create the database schema, follow these steps:

1. Open a terminal or command prompt.
2. Navigate to the project directory.
3. Run the following command to apply the migration: dotnet ef database update

### Running the Application
To run the application, use the following command: dotnet run

## Project Structure
- `Migrations/`: Contains the database migration files.
- `Models/`: Contains the data models.
- `Controllers/`: Contains the API controllers.
- `Views/`: Contains the Razor views (if applicable).

## Contributing
Contributions are welcome! Please fork the repository and submit a pull request.

    
