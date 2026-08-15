# Movie Platform - Onion Architecture ASP.NET Core

A full-featured movie and series platform built with **ASP.NET Core 9** using **Onion Architecture**. The project focuses on clean architecture principles, maintainability, scalability, and separation of concerns.

## Technologies

* ASP.NET Core 9
* Entity Framework Core
* Microsoft SQL Server
* ASP.NET Core Identity
* MediatR
* CQRS
* AutoMapper
* RESTful Web API
* Onion Architecture

## Architecture

The application follows **Onion Architecture** and is divided into independent layers:

* **Domain** — Core entities and domain models
* **Application** — Business logic, CQRS operations, interfaces, and use cases
* **Infrastructure** — Data persistence and external service implementations
* **Presentation** — Web API and user interface

This structure keeps business logic independent from infrastructure concerns and provides a maintainable and extensible codebase.

## Features

* Movie and series management
* Movie detail pages
* Actor and category management
* Search and filtering
* User registration and authentication
* Role-based authorization
* Admin panel
* CRUD operations
* RESTful API architecture
* Responsive user interface

## Authentication & Authorization

Authentication and authorization are implemented using **ASP.NET Core Identity**.

The application supports:

* User registration and login
* Role-based access control
* Protected endpoints
* Admin and user roles

## Database

The application uses **Microsoft SQL Server** with **Entity Framework Core** for data persistence and database operations.

## Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/Muhamet-Ali/OnionArchitecture-MoviePlatform.git
cd OnionArchitecture-MoviePlatform
```

### 2. Configure the database

Update the database connection settings using your local configuration or environment variables.

### 3. Apply migrations

```bash
dotnet ef database update
```

### 4. Run the application

```bash
dotnet run
```

## Project Goals

The main goal of this project is to demonstrate the implementation of modern backend development practices with ASP.NET Core, including clean architecture, separation of concerns, authentication and authorization, database management, and maintainable application design.
