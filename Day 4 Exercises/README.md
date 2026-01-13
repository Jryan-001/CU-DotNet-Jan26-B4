# Day 4 – ASP.NET Core MVC Training Portal

This exercise demonstrates building an ASP.NET Core MVC web application to understand the fundamentals of Model-View-Controller architecture.

---

## 📌 Project Name

**TrainingPortal**

---

## 🎯 Objective

Develop a training portal for Chandigarh University that enables navigation between:

- **Home** – Portal introduction and overview
- **Courses** – Available training programs
- **Contact** – Department contact details

Using proper MVC conventions, Razor Views, and Tag Helpers.

---

## 🛠️ Technologies Used

| Technology | Version |
|------------|---------|
| ASP.NET Core MVC | .NET 8 |
| Language | C# |
| Frontend | Bootstrap 5 |
| IDE | Visual Studio 2026 |

---

## 📁 Project Structure

```
TrainingPortal/
├── Controllers/
│   ├── HomeController.cs
│   └── TrainingController.cs
├── Models/
│   └── ErrorViewModel.cs
├── Views/
│   ├── Training/
│   │   ├── Home.cshtml
│   │   ├── Courses.cshtml
│   │   └── Contact.cshtml
│   └── Shared/
│       └── _Layout.cshtml
├── wwwroot/
├── Program.cs
└── appsettings.json
```

---

## ✅ Key Concepts Covered

- MVC Architecture (Model-View-Controller)
- Creating Controllers and Action Methods
- Razor View Engine
- Tag Helpers (`asp-controller`, `asp-action`)
- Shared Layouts (`_Layout.cshtml`)
- Bootstrap Integration

---

## ▶️ How to Run

1. Open `TrainingPortal.slnx` in Visual Studio
2. Build the solution (`Ctrl + Shift + B`)
3. Run the application (`F5`)
4. Access the portal at `https://localhost:xxxx`

---

