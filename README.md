# Entity Framework Core 🚀

This project is a hands-on demonstration of using **Entity Framework Core** with the **Code-First** approach in a C# .NET environment. It showcases how to define models, configure the `DbContext`, manage database migrations, and perform basic CRUD operations using LINQ and asynchronous methods.

## 🔍 What This Project Covers

* ✅ Setting up **Entity Framework Core** in a .NET project
* ✅ Creating and configuring entity models
* ✅ Managing **Code-First Migrations**
* ✅ Performing **CRUD operations** with async support
* ✅ Using **LINQ queries** for data access
* ✅ Demonstrating **1:1 and 1\:N relationships**
* ✅ Exploring **Loading Strategies** – Eager, Lazy, Explicit
* ✅ Understanding **Entity Tracking & States**
* ✅ Applying **Cascade Delete & Delete Behaviors**

## 🛠️ Technologies Used

* C# .NET
* Entity Framework Core
* SQL Server (or any EF-supported database)
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
