---

# 🎓 Student Management System

A **Student Management System** built using **ASP.NET Core MVC**, following **Clean Architecture**, **Repository Pattern**, and **Infrastructure Services** to manage students, departments, courses, instructors, and users.

---

## 🚀 Features

* User Authentication & Authorization using **ASP.NET Identity**
* User Registration & Login
* Role Management (Admin)
* Department Management (CRUD + Soft Delete)
* Course Management with department relationships
* Trainee Management with image upload
* Instructor Management with image upload
* Course results and trainee grades
* Search functionality
* File upload, update, and delete
* Server-side validation
* Clean separation of concerns

---

## 🛠 Tech Stack

* ASP.NET Core MVC
* C#
* Entity Framework Core
* SQL Server
* ASP.NET Identity
* Bootstrap
* Repository Pattern

---

## 🏗 Architecture

The project follows a **clean, layered architecture**:

* **Controllers** – Handle HTTP requests
* **Models (Entities)** – Database entities
* **ViewModels** – UI data shaping
* **Repositories** – Data access abstraction
* **Infrastructure** – Shared services (File handling)
* **Identity** – Authentication & role management

---

## 📁 Infrastructure Layer

### FileService

A reusable service responsible for:

* Uploading files asynchronously
* Updating existing files
* Deleting files safely
* Generating unique file names
* Logging errors using `ILogger`

Used for managing **Trainee** and **Instructor** images.

---

## 📂 Project Structure

```
FirstProject/
│
├── Controllers/
├── Models/
│   └── Entities/
├── ViewModels/
├── Repositories/
│   └── Interfaces/
├── Infrastructure/
│   ├── IFileService.cs
│   └── FileService.cs
├── wwwroot/
│   └── Images/
├── Data/
├── Views/
└── Program.cs
```

---

## ▶️ How to Run

1. Clone the repository

   ```bash
   git clone https://github.com/ziad-abdo96/Student-Management-System.git
   ```

2. Open the solution in **Visual Studio**

3. Update the connection string in `appsettings.json`

4. Apply migrations and update the database

5. Run the project (F5)

---

## 🎯 Purpose

Built to practice real-world **ASP.NET Core MVC** development with:

* Clean Architecture
* Repository Pattern
* Infrastructure services
* Identity & Roles
* File handling
* CRUD operations

---

## 👤 Author

**Ziad Abdo**
Junior Full Stack Developer (.NET)

---

