# ASP.NET 8 Web API Coding Exercise

## Tech Stack

- ASP.NET Core 8 Web API
- Entity Framework Core
- SQLite
- Swagger

## Getting Started

### Prerequisites

Make sure you have the following installed:

- .NET 8 SDK

Verify your .NET version:

```bash
dotnet --version
```

### 1. Clone the Repository

```bash
git clone https://github.com/itchan17/CodingExercise.git
cd CodingExercise
```

### 2. Restore Dependencies

```bash
dotnet restore
```

### 3. Run Database Migrations

Apply the existing Entity Framework Core migrations:

```bash
dotnet ef database update
```

If the Entity Framework Core CLI is not installed, install it using:

```bash
dotnet tool install --global dotnet-ef
```

### 4. Build the Project

```bash
dotnet build
```

### 5. Run the API

```bash
dotnet run
```

### 6. Open Swagger

Open the following URL in your browser:

```text
http://localhost:5065/swagger/index.html
```

Swagger provides documentation for the available API endpoints and allows you to test the API directly from the browser.

## Project Structure

```text
CodingExercise/
├── Controllers/        # API controllers and endpoints
├── Data/               # Database context and configuration
├── Dtos/               # Data Transfer Objects
├── Mappings/           # Entity-to-DTO and DTO-to-entity mappings
├── Models/             # Entity/domain models
├── Migrations/         # Entity Framework Core migrations
├── Program.cs          # Application entry point and configuration
├── appsettings.json    # Application configuration
└── ProjectName.csproj  # Project configuration
```

## API Endpoints

### Pizza

| Method   | Endpoint                    | Description           |
| -------- | --------------------------- | --------------------- |
| `GET`    | `/api/pizzas`               | Get all pizzas        |
| `POST`   | `/api/pizzas`               | Create a new pizza    |
| `PUT`    | `/api/pizzas/{id}`          | Update pizza details  |
| `PUT`    | `/api/pizzas/{id}/toppings` | Update pizza toppings |
| `DELETE` | `/api/pizzas/{id}`          | Delete a pizza        |

### Topping

| Method   | Endpoint             | Description          |
| -------- | -------------------- | -------------------- |
| `GET`    | `/api/toppings`      | Get all toppings     |
| `POST`   | `/api/toppings`      | Create a new topping |
| `PUT`    | `/api/toppings/{id}` | Update a topping     |
| `DELETE` | `/api/toppings/{id}` | Delete a topping     |
