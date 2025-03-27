# Product Management Dashboard API

This is an ASP.NET Core Web API for managing products. It provides endpoints for creating, reading, updating, and deleting product information.This project uses Entity Framework Core for database operations.

## Setup Instructions

1.  **Prerequisites:**
    * [.NET SDK](https://dotnet.microsoft.com/download) (version compatible with ASP.NET Core)
    * [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or SQL Server Express)
    * [Node.js and npm](https://nodejs.org/) (for running the React frontend on localhost:3000)

2.  **Clone the Repository:**
    ```bash
    git clone <your-repository-url>
    cd <your-repository-directory>
    ```

3.  **Configure Database Connection:**
    * Open the `appsettings.json` file.
    * Update the `ProductDbContext` connection string to match your SQL Server instance:

        ```json
        {
          "Logging": {
            "LogLevel": {
              "Default": "Information",
              "Microsoft.AspNetCore": "Warning"
            }
          },
          "AllowedHosts": "*",
          "ConnectionStrings": {
            "ProductDbContext": "Server=<your-server>;Database=<your-database>;User Id=<your-user-id>;Password=<your-password>;TrustServerCertificate=True;"
          }
        }
        ```

        Replace:
        * `<your-server>`: The server name (e.g., `(localdb)\mssqllocaldb` or `.\SQLEXPRESS`).
        * `<your-database>`: The name of your database (e.g., `ProductDB`).
        * `<your-user-id>`: Your SQL Server user ID.
        * `<your-password>`: Your SQL Server password.
        * `TrustServerCertificate=True`: Add this if your SQL server is using a self signed certificate.

4.  **Apply Database Migrations:**
    * Open a terminal in the project directory.
    * Run the following commands:

        ```bash
        dotnet tool install --global dotnet-ef
        dotnet ef database update
        ```

        This will create the database and tables based on the `Product` model.

5.  **Run the API:**
    * In the terminal, run:

        ```bash
        dotnet run
        ```

    * The API will start and listen on `https://localhost:7227`.

6.  **CORS Configuration:**
    * The API is configured to allow requests from `http://localhost:3000` (for a React frontend). If you are using a different origin, update the CORS policy in `Program.cs`.

## API Endpoints

### Products

* **`GET /api/Product/GetAllProducts`**
    * Retrieves a list of all products.
    * Response: An array of `Product` objects.
    * Example Response:
        ```json
        [
          {
            "id": 1,
            "productName": "Laptop",
            "productCode": "LAP001",
            "price": 1200,
            "quantity": 10,
            "category": "Electronics",
            "createdAt": "2023-10-27T10:00:00Z"
          },
        ]
        ```

* **`POST /api/Product/AddProduct`**
    * Adds a new product.
    * Request Body: A `Product` object.
    * Response: The created `Product` object.
    * Example Request Body:
        ```json
        {
          "productName": "Smartphone",
          "productCode": "SPH002",
          "price": 800,
          "quantity": 20,
          "category": "Electronics"
        }
        ```

* **`PATCH /api/Product/UpdateProduct/{id}`**
    * Updates an existing product.
    * `{id}`: The ID of the product to update.
    * Request Body: A `Product` object with the updated fields.
    * Response: The updated `Product` object.
    * Example Request Body:
        ```json
        {
          "id": 1,
          "price": 1300,
          "quantity": 15
        }
        ```

* **`DELETE /api/Product/deleteProduct/{id}`**
    * Deletes a product.
    * `{id}`: The ID of the product to delete.
    * Response: `true` if the product was deleted, `false` otherwise.

### Product Model

```csharp
public class Product
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string ProductCode { get; set; }
    public float Price { get; set; }
    public int Quantity { get; set; }
    public string Category { get; set; }
    public DateTime CreatedAt { get; set; }
}

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

## Unit Testing

### Setting Up Unit Tests
Unit tests are written using the xUnit framework. The test project is located in the `ProductManagementDashboard.Tests` directory.

### Running Unit Tests
To run the unit tests, use the following command:
dotnet test

    
