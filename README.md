# 🏫 School Management System - C# .NET Framework

This is a Windows-based School Management System built using **C# (.NET Framework)** with **SQL Server** as the backend. The application helps school administrators efficiently manage students, teachers, courses, classes, and fees.

---

## 📌 Features

- 🔐 **Login Panel** (Admin Authentication)
- 👨‍🏫 **Add Teacher** (Store and manage teacher records)
- 🎓 **Add Student** (Store and manage student records)
- 🏫 **Add Classes** (Define classes and sections)
- 📘 **Add Courses** (Course management)
- 💵 **Add Student Fee** (Record fee payments)
- 📄 **Check Student Fee Status** (Track fee payment status)
- 📅 **Student Attendance by Class** ✅
  - Select a class
  - Load students of that class
  - Mark Present / Absent
  - Save and manage daily records

---

## 🛠️ Technologies Used

| Technology         | Description                  |
|--------------------|------------------------------|
| C# (.NET Framework) | For building the desktop app |
| Windows Forms       | GUI development              |
| SQL Server          | Backend database             |
| ADO.NET             | Data access and queries      |

---

## 📂 Database Structure (Overview)

- **Students Table**: Stores student info (name, class, contact, etc.)
- **Teachers Table**: Stores teacher info (name, subject, etc.)
- **Courses Table**: List of available courses
- **Classes Table**: Class sections and IDs
- **Fees Table**: Student fee data and status

---

## 🚀 How to Run

1. Clone or download the repository.
2. Open the solution `.sln` file in **Visual Studio**.
3. Update the database connection string in the config file.
4. Run SQL scripts (provided in the `Database` folder if any) to create the required tables.
5. Build and run the project.

---

## 🔐 Admin Login

To access the application, use the following admin credentials:

- **Username:** `admin`
- **Password:** `123`
