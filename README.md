# Boxer Assessment – Employee Registry

## 📌 Application Overview

The **Boxer Assessment – Employee Registry** is a full-stack application built as part of a technical assessment.

It demonstrates a clean and maintainable implementation of:

- A **.NET 8 Web API**
- An **Angular frontend**
- A simple **employee management system**

The focus of this solution is **correctness, clarity, and clean structure**.

---

## 🧱 Architecture Overview

The application follows a **layered architecture** with clear separation of concerns.

### Backend Layers

- **API Layer**
  - ASP.NET Core Controllers
  - RESTful endpoints
  - API key authentication middleware

- **Service Layer**
  - Business logic
  - DTO mapping

- **Repository Layer**
  - Entity Framework Core data access
  - SQL Server persistence

- **Domain Layer**
  - Core entities (`Employee`, `JobTitle`)

- **Middleware**
  - Global exception handling
  - API key validation

- **Test Project**
  - Unit tests for service logic

---

## 🗄️ Database Design

The database consists of two tables:

### JobTitle
- Lookup table for job titles
- Enforces unique job title names

### Employee
- Stores employee records
- Linked to `JobTitle`
- Enforces:
  - Unique email addresses
  - Non-negative salaries
  - Referential integrity

Seed data is included for demonstration purposes.

---

## 🔗 API Features

### Employees
- Get paged and searchable list
- Get employee by ID
- Create employee
- Update employee
- Delete employee

### Job Titles
- Retrieve all job titles (lookup)

### Security
- Simple API key authentication using the request header:

## 🧪 Testing Strategy

Unit tests are implemented for:

- Employee service
- Job title service

### Tools Used
- NUnit
- Moq

Tests focus on correctness and core business behavior.

Frontend tests are out of scope for this assessment.

---

## 🔌 API Testing (Postman)

A **Postman collection and environment** are included for testing the API endpoints.

### 📁 Location

These files can be used for importing:

- [Postman Collection](/Backend/Postman/Boxer%20Assessment%20API.postman_collection.json)
- [Postman Environment](/Backend/Postman/Boxer%20Assessment%20-%20IIS%20Express.postman_environment.json)

## 🖥️ Frontend Application (Angular)

The frontend is a standalone Angular application that consumes the API.

### Features
- Employee list with search and pagination
- Create and edit employee forms
- Delete employees
- Job title lookup dropdown
- Salary displayed in **South African Rand (R)**

### Frontend Architecture
- Standalone Angular components
- Angular routing
- Template-driven forms
- Services for API communication
- HTTP interceptor for API key injection

---

## ⚙️ Technologies Used

### Backend
- ASP.NET Core (.NET 8)
- Entity Framework Core
- SQL Server
- Swagger / OpenAPI
- NUnit
- Moq

### Frontend
- Angular
- TypeScript
- Angular Forms
- Angular Router
- Angular Signals

---

## ▶️ Running the Application

### Backend
1. Ensure SQL Server is running
2. Execute the provided database script
3. Update the connection string if needed
4. Run the API project
5. Swagger UI will be available at `/swagger`

### Frontend
1. Navigate to `Frontend/boxer-assessment-ui`
2. Install dependencies:
 ```bash
 npm install
 ng serve