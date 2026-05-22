# 🎯 Altkom.22.05.2026 - Projekt .NET 10

Nowoczesne rozwiązanie .NET 10 z praktykami DevOps i Central Package Management.

## 📋 Spis Treści

- [Projekty](#-projekty)
- [Konfiguracja CPM](#-central-package-management)
- [Szybki Start](#-szybki-start)
- [Struktura](#-struktura)
- [Dokumentacja](#-dokumentacja)

---

## 📦 Projekty

### Aplikacje

| Projekt | Typ | Opis |
|---------|-----|------|
| **WebApp** | ASP.NET Core Web | Główna aplikacja webowa |
| **ConsoleApp** | Console | Aplikacja konsolowa |
| **Hangman** | Console | Gra w wisielca |
| **ConsoleApp_Profiler** | Console | Profiler performance |
| **ConsoleApp_Debug** | Console | Debugowanie |

### Biblioteki

| Projekt | Typ | Opis |
|---------|-----|------|
| **Models** | Class Library | Modele danych |

### Testowanie & Benchmarking

| Projekt | Typ | Opis |
|---------|-----|------|
| **Hangman.UnitTests** | xUnit Tests | Testy dla Hangman |
| **BenchmarkSuite1** | BenchmarkDotNet | Performance benchmarks |

---

## 🎁 Central Package Management

Projekt używa **Central Package Management (CPM)** do zarządzania wersjami pakietów.

### 📍 Główny Plik Konfiguracji

```
📄 Directory.Packages.props
```

Zawiera centralne definicje wersji **wszystkich** pakietów NuGet w rozwiązaniu.

### Główne Korzyści

✅ **Jedna źródło prawdy** — wszystkie wersje pakietów w jednym miejscu  
✅ **Konsystencja** — wszyscy deweloperzy używają tych samych wersji  
✅ **Łatwa aktualizacja** — zmień wersję jednym klikjem  
✅ **Zero konfliktów** — uniknięcie różnych wersji tego samego pakietu  

### Jak to Działa

**Przed (bez CPM):**
```xml
<!-- WebApp.csproj -->
<PackageReference Include="Serilog" Version="4.2.0" />

<!-- Hangman.csproj -->
<PackageReference Include="Serilog" Version="4.1.0" />

⚠️ Konflikt: dwie różne wersje!
```

**Po (z CPM):**
```xml
<!-- Directory.Packages.props -->
<PackageVersion Include="Serilog" Version="4.2.0" />

<!-- WebApp.csproj -->
<PackageReference Include="Serilog" />

<!-- Hangman.csproj -->
<PackageReference Include="Serilog" />

✅ Jedna wersja dla całego rozwiązania!
```

---

## 🚀 Szybki Start

### Wymagania

- `.NET 10 SDK` (lub nowszy)
- Visual Studio 2026 Community/Professional (opcjonalne)
- Git

### Klonowanie i Setup

```bash
# Klonuj repozytorium
git clone https://github.com/lMSDl/Altkom.22.05.2026.git
cd Altkom.22.05.2026

# Przywróć pakiety
dotnet restore

# Zbuduj rozwiązanie
dotnet build

# Uruchom testy
dotnet test

# Uruchom aplikację
dotnet run --project WebApp/WebApp.csproj
```

### Pierwsze Kroki w Visual Studio

1. **Otwórz rozwiązanie**
   ```
   Altkom.22.05.2026.slnx
   ```

2. **Przywróć pakiety**
   ```
   Tools → NuGet Package Manager → Package Manager Console
   PM> dotnet restore
   ```

3. **Ustaw WebApp jako startup project**
   ```
   Project → Set as Startup Project
   ```

4. **Wciśnij F5** aby uruchomić aplikację

---

## 📁 Struktura

```
Altkom.22.05.2026/
│
├── 📄 Directory.Packages.props      ← CPM: centralna konfiguracja wersji
├── 📄 Altkom.22.05.2026.slnx       ← Solution file
│
├── 📂 WebApp/                      ← ASP.NET Core Web
│   ├── WebApp.csproj
│   ├── Controllers/
│   ├── Models/
│   ├── Views/
│   └── appsettings.json
│
├── 📂 Models/                      ← Shared Models
│   └── Models.csproj
│
├── 📂 Hangman/                     ← Gra w wisielca
│   ├── Hangman.csproj
│   └── Game.cs
│
├── 📂 Hangman.UnitTests/           ← Testy xUnit
│   ├── Hangman.UnitTests.csproj
│   └── GameTests.cs
│
├── 📂 ConsoleApp/                  ← Aplikacja konsolowa
│   └── ConsoleApp.csproj
│
├── 📂 ConsoleApp_Debug/            ← Debugowanie
│   └── ConsoleApp_Debug.csproj
│
├── 📂 ConsoleApp_Profiler/         ← Profiler
│   └── ConsoleApp_Profiler.csproj
│
├── 📂 BenchmarkSuite1/             ← Benchmarking
│   ├── BenchmarkSuite1.csproj
│   └── Benchmarks.cs
│
└── 📂 Dokumentacja/
	├── CPM-GUIDE.md                ← Przewodnik CPM
	├── CPM-CHECKLIST.md            ← Checklist dla zespołu
	├── Directory.Packages.props.md  ← Referencja pakietów
	└── README.md                   ← Ten plik
```

---

## 📚 Dokumentacja

### CPM (Central Package Management)

- **[CPM-GUIDE.md](./CPM-GUIDE.md)** — Pełny przewodnik CPM
  - Co to jest CPM?
  - Jak używać
  - Best practices
  - Troubleshooting

- **[Directory.Packages.props.md](./Directory.Packages.props.md)** — Referencja pakietów
  - Bieżące pakiety
  - Zastosowanie po projekcie
  - Procedury aktualizacji
  - Monitorowanie bezpieczeństwa

- **[CPM-CHECKLIST.md](./CPM-CHECKLIST.md)** — Praktyka dla zespołu
  - Checklist dodawania pakietu
  - Checklist aktualizacji
  - Code review guidelines
  - Polecenia diagnostyczne

---

## 🔧 Polecenia Budowania

### Build

```bash
# Zwykłe buildowanie
dotnet build

# Build z warningami jako errory
dotnet build /p:TreatWarningsAsErrors=true

# Release build
dotnet build --configuration Release
```

### Testowanie

```bash
# Uruchom wszystkie testy
dotnet test

# Uruchom testy dla konkretnego projektu
dotnet test ./Hangman.UnitTests/Hangman.UnitTests.csproj

# Uruchom z verbose output
dotnet test --verbosity detailed
```

### Benchmarking

```bash
# Uruchom benchmarks
dotnet run --project BenchmarkSuite1/BenchmarkSuite1.csproj --configuration Release
```

### Pakiety

```bash
# Pokaż wszystkie pakiety
dotnet list package

# Pokaż tylko nieaktualne
dotnet list package --outdated

# Przywróć pakiety
dotnet restore

# Wyczyść cache
dotnet clean
```

---

## 🔒 Bezpieczeństwo

### Monitorowanie Pakietów

```bash
# Sprawdzenie nieaktualnych pakietów
dotnet list package --outdated

# Sprawdzenie podatności (jeśli GitHub)
# Settings → Code security → Enable Dependabot alerts
```

### Best Practices

- ✅ Regularnie aktualizuj pakiety (`dotnet list package --outdated`)
- ✅ Monitoruj CVE dla używanych bibliotek
- ✅ Nie używaj beta wersji w production
- ✅ Zawsze testuj po aktualizacji

---

## 🎯 .NET 10 Cechy

Projekt jest zoptymalizowany dla .NET 10:

✨ **Latest C# 15 features**
```csharp
// Nullability
#nullable enable

// Implicit usings
using System;
using System.Collections.Generic;
// ... i więcej

// File-scoped namespaces (opcjonalnie)
namespace WebApp.Controllers;
```

✨ **Performance improvements**
- Szybszy GC
- Lepsze SIMD
- Optimizacje AOT

✨ **Security**
- Nowsze TLS support
- Improved cryptography APIs

---

## 🚀 Deployment

### Lokalne

```bash
dotnet run --project WebApp/WebApp.csproj
```

### Production Build

```bash
dotnet publish --configuration Release --output ./publish
```

---

## 📞 Wsparcie

### Dokumentacja

- [.NET 10 Docs](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-10)
- [NuGet.org](https://www.nuget.org/)
- [Microsoft Docs](https://learn.microsoft.com/)

### Problemy

Jeśli napotkasz problemy:

1. Sprawdź dokumentację w folderze `./`
2. Sprawdzić `CPM-GUIDE.md` sekcję Troubleshooting
3. Sprawdzić GitHub Issues

---

## 📝 Changelog

### v1.0.0 (2026-05-22)

- ✅ Setup projektu dla .NET 10
- ✅ Implementacja Central Package Management
- ✅ Dodanie dokumentacji CPM
- ✅ Konfiguracja 8 projektów
- ✅ Setup xUnit testowania
- ✅ Setup BenchmarkDotNet

---

## 📄 Licencja

MIT License — patrz plik `LICENSE`

---

## 👥 Autorzy

- **Prowadzący:** Polska kadra szkoleniowa
- **Projekt:** Altkom 2026

---

## 🎓 Notatki Szkoleniowe

Ten projekt jest używany jako materiał szkoleniowy dla:

- ✅ .NET 10 fundamentals
- ✅ Modern C# patterns
- ✅ Central Package Management
- ✅ Unit Testing best practices
- ✅ Performance benchmarking

---

**Ostatnia aktualizacja:** 2026-05-22  
**Wersja:** 1.0.0  
**Status:** ✅ Aktywny
