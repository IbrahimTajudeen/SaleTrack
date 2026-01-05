# 📊 SaleTrack App

![.NET](https://img.shields.io/badge/.NET-8.0-purple)
![MAUI](https://img.shields.io/badge/.NET%20MAUI-Cross--Platform-blue)
![Platform](https://img.shields.io/badge/Platforms-Android%20%7C%20Windows%20%7C%20iOS-lightgrey)
![License](https://img.shields.io/badge/License-MIT-green)
![Status](https://img.shields.io/badge/Status-Active-success)

**SaleTrack** is a cross-platform sales tracking application built with **.NET MAUI**, designed to help individuals and small businesses record, manage, and analyze daily sales efficiently — even when offline.

The app supports secure authentication, offline-first sales recording, report generation, and role-based access, making it ideal for cashiers, sales agents, and business owners.

---

## 🚀 Features

- ✅ User Authentication (JWT-based)
- 🧾 Add & manage sales records
- 📶 Offline sales support with automatic sync
- 📊 Sales analytics & reports
- 📄 PDF report generation & preview
- 🔄 Pull-to-refresh & loading indicators
- 🎨 App theming (Light / Dark)
- 👥 Role-based UI (Cashier vs Admin)
- 🧭 Shell-based navigation with Tabs
- 🗂️ Token persistence & secure storage

---

## 🛠️ Tech Stack

### Frontend (Mobile App)
- **.NET MAUI**
- **C#**
- **MVVM Architecture**
- **Shell Navigation**
- **CommunityToolkit.Mvvm**
- **Newtonsoft.Json**

### Backend (API)
- **ASP.NET Core Web API**
- **JWT Authentication**
- **Entity Framework Core**
- **PostgreSQL / SQL Server**
- **Supabase (optional integrations)**

---

## 📱 Supported Platforms

- ✅ Android  
- ✅ Windows  
- ⚠️ iOS (Mac required)  
- ⚠️ macOS  

---

## 📂 Project Structure

SaleTrack/
│
├── Models/ # Data models (Sale, User, Reports)
├── ViewModels/ # MVVM ViewModels
├── Views/ # Pages (Login, Dashboard, Sales, Reports)
├── Services/ # API, Auth, Sync, Storage services
├── Helpers/ # Utilities & extensions
├── Resources/ # Styles, colors, images
├── AppShell.xaml # Shell navigation
└── App.xaml # App startup & theming


---

## 🔐 Authentication Flow

1. User logs in
2. API returns JWT access token
3. Token is stored securely
4. Token is attached to every API request
5. Auto logout or refresh on token expiration

---

## 🧾 Sale Data Format

Sales are stored and synced using the following structure:

```json
{
  "saleDate": "2024-06-15T14:30:00Z",
  "itemName": "Wireless Headphones",
  "pricePerItem": 99.99,
  "quantity": 2,
  "totalAmount": 199.98,
  "notes": "Customer requested black color"
}
```

📊 Reports

Daily / Monthly sales summaries

Total sales & total revenue

Exportable PDF reports

HTML-based report rendering

---

🔄 Offline Support

Sales can be added without internet

Records are stored locally

Automatic sync when connection is restored

Conflict-safe syncing strategy

---

⚙️ Setup Instructions
Prerequisites

Visual Studio 2022+

.NET 8 SDK

Android Emulator or Physical Device

---

Clone the Repository
git clone https://github.com/your-username/SaleTrack.git
cd SaleTrack

---

Run the App
dotnet build
dotnet maui run

---

🧪 Development Notes

Dependency Injection used throughout

Strict MVVM separation

Centralized error handling & alerts

Easily extensible architecture

---

🗺️ Roadmap

 Push notifications

 Multi-branch support

 Cloud backup

 Advanced analytics charts

 Web dashboard

 ---

🤝 Contributing

Contributions are welcome!

Fork the repository

Create a feature branch

Commit your changes

Open a Pull Request

---

📄 License

This project is licensed under the MIT License.

---

👤 Author

Ibrahim Tajudeen
Software Developer

GitHub: https://github.com/your-username

Email: your-email@example.com

Built with ❤️ using .NET MAUI

---

