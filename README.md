# 🎓 Student Management System

An **ASP.NET Core MVC** web application for managing student records with **Entity Framework Core**, **SQL Server**, **AJAX**, **JSON**, **Bootstrap**, and **Serilog** for centralized logging and exception handling.

---

## 🚀 Features Implemented

### ✅ Student Module
- Create Student
- Edit Student
- Delete Student
- View Student Details
- Server-Side Form Validation

### ✅ Course Module
- Multiple Course Selection
- Checkbox Binding
- Display Selected Courses

### ✅ Relationships
- Many-to-Many Relationship
- Navigation Properties
- Junction Table (`CourseStudentModel`)

### ✅ Database
- SQL Server Integration
- Entity Framework Core
- Code-First Migrations

### ✅ AJAX & JSON
- Fetch Student Details using AJAX
- Return JSON from Controller
- Bootstrap Modal Popup
- Display Student Details without Page Refresh

### ✅ Exception Handling & Logging
- Global Exception Handling
- Custom Error Page
- Centralized Exception Logging
- Serilog Integration
- Console Logging
- Daily Rolling Log Files
- Configuration using `appsettings.json`

---

## 📝 Logging

This project uses **Serilog** for centralized logging to capture application events and exceptions in a structured and maintainable way.

### Logging Features

- ✅ Console Logging
- ✅ File Logging
- ✅ Daily Rolling Log Files
- ✅ Structured Logging
- ✅ Global Exception Logging
- ✅ Configuration-driven Logging using `appsettings.json`

---

## 🛠 Tech Stack

| Technology | Used |
|------------|------|
| ASP.NET Core MVC | ✅ |
| C# | ✅ |
| Entity Framework Core | ✅ |
| SQL Server | ✅ |
| Razor Views | ✅ |
| Bootstrap | ✅ |
| jQuery | ✅ |
| AJAX | ✅ |
| JSON | ✅ |
| Serilog | ✅ |
| Git & GitHub | ✅ |

---

## 📂 Database Structure

### Students
- Id
- Name
- Email
- Age
- EnrollmentId
- Specialisation

### Course
- Id
- CourseName

### CourseStudentModel
- StudentsId
- CoursesId

---

## 📸 Current Functionalities

- ✅ Create Student
- ✅ Edit Student
- ✅ Delete Student
- ✅ View Student Details
- ✅ Multiple Course Selection
- ✅ Display Selected Courses
- ✅ Many-to-Many Relationship
- ✅ Validation using Data Annotations
- ✅ AJAX-based Student Details
- ✅ JSON Response
- ✅ Bootstrap Modal Popup
- ✅ Global Exception Handling
- ✅ Custom Error Page
- ✅ Serilog Logging
- ✅ Daily Rolling Log Files

---

## 🧠 Concepts Covered

- CRUD Operations
- ASP.NET Core MVC
- Entity Framework Core
- SQL Server Integration
- LINQ Queries
- ViewModels
- Razor Syntax
- Data Annotations
- Navigation Properties
- Many-to-Many Relationships
- Eager Loading (`Include()`)
- JSON Serialization
- jQuery
- AJAX
- DOM Manipulation
- Bootstrap Modal
- Asynchronous Programming
- Global Exception Handling
- MVC Exception Pipeline
- Serilog Logging
- Structured Logging
- Rolling Log Files
- Configuration-driven Logging
- Custom Error Pages

---

## 📁 Project Structure

```text
StudentForm
│
├── Controllers
├── Models
├── ViewModel
├── Views
├── Infra
├── Handlers
├── Migrations
├── Logs
├── wwwroot
├── appsettings.json
├── Program.cs
└── StudentForm.sln
```

---

## 🔮 Upcoming Features

- 🔍 Search Students
- 📄 Pagination
- 📚 Course CRUD
- 🔐 Authentication
- 👥 Role-Based Authorization
- 📊 Dashboard
- 🎨 Enhanced UI with Bootstrap

---

## ⚡ Learning Outcomes

✔ ASP.NET Core MVC

✔ Entity Framework Core

✔ SQL Server Integration

✔ CRUD Operations

✔ LINQ Queries

✔ ViewModels

✔ Validation using Data Annotations

✔ Navigation Properties

✔ Many-to-Many Relationships

✔ AJAX & JSON

✔ Bootstrap Modal

✔ DOM Manipulation

✔ Asynchronous Programming

✔ Global Exception Handling

✔ Serilog Logging

✔ Structured Logging

✔ Rolling Log Files

✔ Configuration using `appsettings.json`

✔ Custom Error Pages

---

## 👩‍💻 Author

**Jahnvi Srivastava**


⭐ **If you found this project helpful, consider giving it a Star!**
