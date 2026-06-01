# Mergington High School - ASP.NET Core API

Eine moderne ASP.NET Core 8.0 Web API für die Verwaltung von Schul-Aktivitäten.

## 🎯 Projekt-Übersicht

Dieses Projekt ist eine Konvertierung der ursprünglichen Python FastAPI-Anwendung zu einem modernen ASP.NET Core Web API mit vollständig beibehaltener Frontend-Funktionalität.

**Von:** Python FastAPI → **Zu:** ASP.NET Core 8.0 Web API

## 🏗️ Projektstruktur

```
MergingtonHighSchool/
├── Controllers/          # API-Endpoints
├── Models/              # Datenmodelle
├── Services/            # Business Logic
├── wwwroot/             # Statische Dateien (HTML, CSS, JS)
│   ├── index.html
│   ├── styles.css
│   └── app.js
├── Properties/          # Projekt-Konfiguration
├── Program.cs           # Application Startup
└── appsettings.json    # Konfigurationsdateien
```

## 🚀 Features

- ✅ **Alle 13 Aktivitäten** aus der Original-Datenbank
- ✅ **RESTful API** mit vollständiger Fehlerbehandlung
- ✅ **CORS aktiviert** für Frontend-Kommunikation
- ✅ **Statische Dateien** (HTML/CSS/JS) vollständig beibehalten
- ✅ **Swagger/OpenAPI** für API-Dokumentation
- ✅ **Moderne C# Features** (Nullable reference types, Top-level statements)

## 📋 API-Endpoints

### GET /activities
Ruft alle verfügbaren Aktivitäten ab.

**Response (200 OK):**
```json
{
  "Chess Club": {
    "name": "Chess Club",
    "description": "Learn strategies and compete in chess tournaments",
    "schedule": "Fridays, 3:30 PM - 5:00 PM",
    "maxParticipants": 12,
    "participants": ["michael@mergington.edu"],
    "spotsLeft": 11
  },
  ...
}
```

### POST /activities/{name}/signup
Registriert einen Schüler für eine Aktivität.

**Query Parameter:**
- `email` (required): E-Mail des Schülers

**Response (200 OK):**
```json
{
  "success": true,
  "message": "You have successfully signed up for Chess Club!"
}
```

## 🛠️ Installation & Ausführung

### Voraussetzungen
- .NET 8.0 SDK oder höher
- Optional: Visual Studio Code mit C# DevKit

### Schritte

1. **Ins Projektverzeichnis wechseln:**
   ```bash
   cd MergingtonHighSchool
   ```

2. **Abhängigkeiten wiederherstellen:**
   ```bash
   dotnet restore
   ```

3. **Anwendung ausführen:**
   ```bash
   dotnet run
   ```

4. **Im Browser öffnen:**
   - Development: `http://localhost:5000` oder `https://localhost:5001`

## 📊 Konvertierungs-Details

### Python FastAPI → ASP.NET Core

| Aspekt | Python FastAPI | ASP.NET Core |
|--------|----------------|-------------|
| Framework | FastAPI | ASP.NET Core Web API |
| Runtime | Python 3.x | .NET 8.0 |
| API-Struktur | FastAPI Routes | MVC Controllers |
| Datentypen | Python Dict | C# Classes |
| Dependency Injection | Builtin | Built-in (Modern) |
| Statische Dateien | StaticFiles Mount | UseStaticFiles() |
| CORS | @app.add_middleware | AddCors() Service |
| Fehlerbehandlung | HTTPException | IActionResult |

### Modelle-Mapping

**Python:**
```python
activities = {
    "Chess Club": {
        "description": "...",
        "schedule": "...",
        "max_participants": 12,
        "participants": ["..."]
    }
}
```

**C# (ASP.NET Core):**
```csharp
public class Activity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Schedule { get; set; }
    public int MaxParticipants { get; set; }
    public List<string> Participants { get; set; }
    public int SpotsLeft => MaxParticipants - Participants.Count;
}
```

## 🎨 Frontend (Unverändert)

Das Frontend benötigte minimal Anpassungen:
- ✅ HTML bleibt identisch
- ✅ CSS bleibt unverändert
- ✅ JavaScript wurde leicht optimiert für C# Response-Format

**Unterschiede:**
- Python-API: `result.detail` → .NET API: `result.message`
- In-Memory-Aktivitäten werden nach Signup aktualisiert

## 🧪 Testen

### Mit curl

```bash
# Alle Aktivitäten abrufen
curl http://localhost:5000/activities

# Für Aktivität anmelden
curl -X POST "http://localhost:5000/activities/Chess%20Club/signup?email=test@mergington.edu"
```

### Mit Browser
1. Öffne `http://localhost:5000` in deinem Browser
2. Durchsuche Aktivitäten
3. Melde dich für eine Aktivität an

## 🔧 Konfiguration

**appsettings.json:**
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

**CORS-Konfiguration** (in Program.cs):
- AllowAnyOrigin
- AllowAnyMethod
- AllowAnyHeader

## 📝 Lizenz

Dieses Projekt wird unter der gleichen Lizenz wie das Original bereitgestellt.

---

**Erstellt:** Juni 2026  
**Framework:** ASP.NET Core 8.0
**Sprache:** C# 13
