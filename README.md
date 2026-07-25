# Entity Framework Core 🚀

This project is a hands-on demonstration of using **Entity Framework Core** with the **Code-First** approach in a C# .NET environment. It showcases how to define models, configure the `DbContext`, manage database migrations, and perform basic CRUD operations using LINQ and asynchronous methods.

Built around a **Football League** domain (`League`, `Team`, `Coach`, `Match`), the project goes beyond basic CRUD into temporal tables, optimistic concurrency, and database view/function mapping.

## 🏗️ Architecture

The solution is split into four projects:

* **`EntityFrameworkCore.Domain`** — entity models (`League`, `Team`, `Coach`, `Match`) and shared audit fields via `BaseDomainModel`
* **`EntityFrameworkCore.Data`** — `DbContext` classes, Fluent API configuration, and Code-First migrations
* **`EntityFrameworkCore.Api`** — ASP.NET Core Web API exposing the data layer, with Swagger
* **`EntityFrameworkCore.Console`** — a standalone console app for running EF Core operations directly

## 🔍 What This Project Covers

* ✅ Setting up **Entity Framework Core** in a .NET project
* ✅ Creating and configuring entity models
* ✅ Managing **Code-First Migrations**
* ✅ Performing **CRUD operations** with async support
* ✅ Using **LINQ queries** for data access
* ✅ Demonstrating **1:1 and 1\:N relationships**, plus a self-referencing **N:1** relationship (`Match` ↔ `Team` for Home/Away)
* ✅ Exploring **Loading Strategies** – Eager, Lazy, Explicit
* ✅ Understanding **Entity Tracking & States**
* ✅ Applying **Cascade Delete & Delete Behaviors**
* ✅ **Temporal tables** (`IsTemporal()`) on `Teams` for automatic history/audit tracking
* ✅ **Optimistic concurrency** via a `[ConcurrencyCheck]` `Version` token
* ✅ Audit fields (`CreatedAt`, `ModifiedBy`, etc.) applied automatically through a `SaveChangesAsync` override
* ✅ Mapping **database views** (`vw_TeamAndLeague`) and **database functions** into EF Core queries

## 🛠️ Technologies Used

* C# / .NET 8
* Entity Framework Core 9
* SQL Server & SQLite
* ASP.NET Core Web API + Swagger
* LINQ
* Visual Studio / Rider

## 🏁 How to Run

1. Clone the repository

2. Restore NuGet packages

3. Configure your connection string in `DbContext`

4. Run EF Core commands:

   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

5. Build and run the project
