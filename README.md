# MessagingApi

A simple .NET 8 Minimal API for managing and sending messages.  
This project demonstrates basic concepts of building a RESTful backend using .NET with clean structure, services, and middlewares — without involving authentication or database integration.

---

## 🚀 Features

- Minimal API structure
- DTO-based request models
- Clean folder separation
- Custom middlewares:
  - Logging
  - Global exception handling
- Swagger UI enabled

---

## 📁 Project Structure

```
📁 MessagingApi/
├── Controllers/
│   └── MessagesController.cs
├── Middlewares/
│   ├── ExceptionHandlingMiddleware.cs
│   └── RequestLoggingMiddleware.cs
├── Models/
│   └── Message.cs
├── Services/
│   ├── IMessageService.cs
│   └── MessageService.cs
├── Program.cs
├── Properties/
│   └── launchSettings.json
├── MessagingApi.csproj
├── Requests.http
└── README.md
```

---

## 🔧 Run Locally

Make sure you have [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) installed.

```bash
git clone https://github.com/yourusername/MessagingApi.git
cd MessagingApi
dotnet run
```

Open Swagger at: [https://localhost:5001/swagger](https://localhost:5001/swagger)

---

## ✅ Endpoints (Example)

### `GET /api/messages`
Returns all messages (in-memory).

### `POST /api/messages`
Create a new message.
```json
{
  "sender": "Umer",
  "content": "Hello World"
}
```

---

## 🛠️ Technologies

- .NET 8
- Swagger (OpenAPI)
- Dependency Injection
- C#

---

## 📄 License

MIT — do whatever you want. Credit appreciated but not required.

