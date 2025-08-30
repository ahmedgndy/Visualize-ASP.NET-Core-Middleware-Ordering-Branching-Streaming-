# 🚀 ASP.NET Core Middleware Playground

This project is a **single-file ASP.NET Core demo** showing how middleware works in real applications.  
It covers **logging, rate limiting, health checks, branching, and custom sub-pipelines**.

---

## ✨ Features

- **Global Request Logging**  
  Logs every request and response.

- **Rate Limiting (Fixed Window)**  
  - Max **2 requests / 10 seconds**  
  - Returns `429 Too Many Requests` if exceeded.

- **Health Check Middleware**  
  `/health` returns a simple *Healthy* response.

- **Branching Middleware (`/sensitive`)**  
  Special branch for sensitive endpoints with custom logging.

- **Admin Sub-Pipeline (`/admin`)**  
  Separate pipeline with its own middleware and terminal handler.

---

## ▶️ Run the Project

```bash
dotnet run
