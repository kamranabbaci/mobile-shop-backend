# 📱 JS Mobile Shop Management System

A complete Mobile Shop Management System developed using **Angular**, **ASP.NET Core Web API**, **SQL Server**, **Bootstrap**, and **Chart.js**.

The system enables mobile shop owners to manage products, inventory, customers, sales, invoices, and business analytics through a modern web-based dashboard.

---

## 🚀 Features

### 🏠 Dashboard
- Business overview
- Sales summary
- Revenue tracking
- Quick navigation
- Real-time statistics

### 📦 Product Management
- Add products
- Update products
- Delete products
- Product pricing
- Product stock management

### 📋 Inventory Management
- Add inventory items
- Update inventory
- Delete inventory
- Reorder level tracking
- Low stock monitoring

### 👥 Customer Management
- Add customers
- Update customer details
- Delete customers
- Customer purchase history
- Customer search and filtering

### 💰 Sales Management
- Create sales transactions
- Select customer and product
- Automatic total calculation
- Inventory deduction after sale
- Invoice generation

### 🧾 Invoice Module
- Professional printable invoice
- Customer details
- Product details
- Pricing summary
- Print functionality

### 📊 Sales Dashboard
- Total sales
- Total revenue
- Daily sales statistics
- Monthly sales statistics
- Top selling products
- Top customers
- Interactive charts using Chart.js

### 🎨 User Interface
- Responsive design
- Modern dashboard
- Bootstrap styling
- Loading spinners
- Success and error alerts
- Professional color scheme

---

## 🛠 Technology Stack

### Frontend
- Angular
- TypeScript
- Bootstrap 5
- Chart.js
- HTML5
- CSS3

### Backend
- ASP.NET Core Web API
- C#
- ADO.NET
- REST APIs

### Database
- Microsoft SQL Server
- Stored Procedures

---

## 📂 Project Structure

```text
MobileShop
│
├── Frontend (Angular)
│   ├── Home
│   ├── Products
│   ├── Inventory
│   ├── Customers
│   ├── Sales
│   ├── Sales Dashboard
│   ├── Header
│   └── Footer
│
└── Backend (.NET API)
    ├── Controllers
    ├── Models
    ├── Database
    └── Stored Procedures
```

---

## 📸 Modules

### Product Module
- Product CRUD operations
- Product listing

### Inventory Module
- Inventory management
- Stock tracking
- Reorder monitoring

### Customer Module
- Customer CRUD
- Purchase history

### Sales Module
- Sales processing
- Automatic inventory updates
- Invoice generation

### Analytics Dashboard
- Revenue charts
- Daily sales charts
- Monthly sales charts
- Top products analysis
- Top customer analysis

---

## ⚙️ Installation

### Clone Repository

```bash
git clone https://github.com/YOUR_USERNAME/mobile-shop-frontend.git
```

or

```bash
git clone https://github.com/YOUR_USERNAME/mobile-shop-backend.git
```

---

## Frontend Setup

```bash
npm install
```

Run Angular application:

```bash
ng serve
```

Application runs on:

```text
http://localhost:4200
```

---

## Backend Setup

Open the solution in Visual Studio.

Restore packages:

```bash
dotnet restore
```

Run API:

```bash
dotnet run
```

API runs on:

```text
http://localhost:5138
```

---

## Database Setup

1. Create SQL Server Database:

```sql
CREATE DATABASE techDb;
```

2. Execute all tables.

3. Execute all stored procedures.

4. Update connection string in:

```json
appsettings.json
```

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=techDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

---


## Screenshots

### Home Dashboard

<img width="737" height="733" alt="image" src="https://github.com/user-attachments/assets/7643d998-7ee0-4b2e-a678-d6667e18a355" />



### Product Management

<img width="1891" height="823" alt="image" src="https://github.com/user-attachments/assets/9c51419b-f2cf-4273-8cea-3b3d9c2231de" />


### Sales Dashboard

<img width="1896" height="712" alt="image" src="https://github.com/user-attachments/assets/3a1e0fef-794b-43e5-ae40-05bee25aeecb" />


---

## Author

**Kamran Abbasi**

### GitHub

https://github.com/kamranabbaci

---

## License

© 2026 JS Mobile Shop Management System
