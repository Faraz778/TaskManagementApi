# Task Management API

A RESTful Task Management API built with **ASP.NET Core Web API**, **Entity Framework Core**, **SQL Server**, and **JWT Authentication**.

This project provides secure user authentication and user-specific task management with filtering, pagination, validation, and password hashing.

## 🚀 Features

* User Registration
* User Login with JWT Authentication
* Secure Password Hashing
* User CRUD Operations
* Task CRUD Operations
* User-specific Task Authorization
* Task Completion Filtering
* Pagination
* DTOs for Request/Response Data
* Input Validation
* Global Exception Handling
* Entity Framework Core
* SQL Server Database
* Service Layer Architecture
* Dependency Injection

## 🛠️ Technologies

* **C#**
* **ASP.NET Core Web API**
* **Entity Framework Core**
* **SQL Server**
* **JWT (JSON Web Token)**
* **ASP.NET Core Identity PasswordHasher**
* **LINQ**
* **Postman**
* **Git & GitHub**

## 📁 Project Structure

```text
TaskManagementApi/
│
├── Controllers/
│   ├── TasksController.cs
│   └── UsersController.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── DTOs/
│   ├── CreateTaskDto.cs
│   ├── UpdateTaskDto.cs
│   ├── TaskResponseDto.cs
│   ├── CreateUserDto.cs
│   ├── UpdateUserDto.cs
│   ├── UserResponseDto.cs
│   ├── LoginUserDto.cs
│   └── LoginResponseDto.cs
│
├── Models/
│   ├── TaskItem.cs
│   └── User.cs
│
├── Services/
│   ├── ITaskService.cs
│   ├── TaskService.cs
│   ├── IUserService.cs
│   └── UserService.cs
│
├── Migrations/
│
├── Program.cs
└── appsettings.json
```

## 🔐 Authentication

The API uses **JWT Bearer Authentication**.

After a successful login, the API returns a JWT token.

Use the token in Postman:

```text
Authorization → Bearer Token → <your-token>
```

Protected task endpoints require a valid JWT token.

Each authenticated user can only access their own tasks.

## 📌 API Endpoints

### Users

| Method | Endpoint           | Description             |
| ------ | ------------------ | ----------------------- |
| GET    | `/api/Users`       | Get all users           |
| GET    | `/api/Users/{id}`  | Get user by ID          |
| POST   | `/api/Users`       | Register a new user     |
| PUT    | `/api/Users/{id}`  | Update user             |
| DELETE | `/api/Users/{id}`  | Delete user             |
| POST   | `/api/Users/login` | Login and get JWT token |

### Tasks

All task endpoints require authentication.

| Method | Endpoint          | Description              |
| ------ | ----------------- | ------------------------ |
| GET    | `/api/Tasks`      | Get current user's tasks |
| GET    | `/api/Tasks/{id}` | Get task by ID           |
| POST   | `/api/Tasks`      | Create a task            |
| PUT    | `/api/Tasks/{id}` | Update a task            |
| DELETE | `/api/Tasks/{id}` | Delete a task            |

### Task Filtering

Get completed tasks:

```text
GET /api/Tasks?completed=true
```

Get incomplete tasks:

```text
GET /api/Tasks?completed=false
```

### Pagination

```text
GET /api/Tasks?page=1&pageSize=10
```

Filtering and pagination can also be combined:

```text
GET /api/Tasks?completed=false&page=1&pageSize=10
```

## 📝 Example Request

### Register User

```json
{
  "userName": "Faraz",
  "userEmail": "faraz@example.com",
  "userPassword": "Password123"
}
```

### Login

```json
{
  "userEmail": "faraz@example.com",
  "userPassword": "Password123"
}
```

### Create Task

```json
{
  "title": "Learn ASP.NET Core",
  "description": "Practice building Web APIs"
}
```

### Update Task

```json
{
  "title": "Learn ASP.NET Core",
  "description": "Practice JWT and Web API development",
  "isCompleted": true
}
```

## 🗄️ Database Setup

The project uses **SQL Server** with **Entity Framework Core Code First**.

Update the connection string in `appsettings.json` according to your SQL Server configuration.

Then run:

```bash
dotnet ef database update
```

Or use Visual Studio Package Manager Console:

```powershell
Update-Database
```

## 🔑 JWT Configuration

JWT configuration is kept outside the source code using **User Secrets**.

Example configuration structure:

```json
{
  "Jwt": {
    "Key": "your-secure-secret-key",
    "Issuer": "TaskManagementApi",
    "Audience": "TaskManagementApiUsers"
  }
}
```

**Do not commit real JWT secrets or passwords to GitHub.**

## ▶️ Run the Project

Clone the repository:

```bash
git clone <your-github-repository-url>
```

Navigate to the project:

```bash
cd TaskManagementApi
```

Restore dependencies:

```bash
dotnet restore
```

Apply database migrations:

```bash
dotnet ef database update
```

Run the API:

```bash
dotnet run
```

The API can then be tested using **Postman**.

## 🧪 Testing

The API was tested using Postman, including:

* User registration
* User login
* Password hashing
* JWT token generation
* Invalid login handling
* Task creation
* Task retrieval
* Task update
* Task deletion
* Completed/incomplete filtering
* Pagination
* Unauthorized requests
* User-specific task authorization
* DTO validation

## 🏗️ Architecture

The project follows a simple layered architecture:

```text
Postman
   ↓
Controller
   ↓
Service
   ↓
DbContext
   ↓
SQL Server
```

### Controller

Handles HTTP requests and responses.

### Service

Contains business logic and database operations.

### DTOs

Controls the data sent to and returned from the API.

### DbContext

Handles communication between the application and SQL Server.

## 🎯 Learning Goals

This project was built to practice:

* ASP.NET Core Web API
* REST API development
* Entity Framework Core
* SQL Server
* Dependency Injection
* Service Layer Architecture
* DTOs
* LINQ
* JWT Authentication
* Authorization
* Password Hashing
* Validation
* Pagination
* Exception Handling

## 👨‍💻 Author

**Muhammad Faraz**

.NET Developer | ASP.NET Core | C# | SQL Server

Built as a backend development project to strengthen practical ASP.NET Core Web API skills.
