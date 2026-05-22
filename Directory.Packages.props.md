# 📋 Directory.Packages.props - Referencja Pakietów

## Przegląd

Plik `Directory.Packages.props` zawiera **centralną konfigurację wszystkich pakietów NuGet** używanych w rozwiązaniu Altkom.22.05.2026.

**Lokalizacja:** `/Directory.Packages.props`

**Cel:** Zarządzanie wersjami pakietów w jednym miejscu dla całego rozwiązania.

---

## 📦 Bieżące Pakiety

### Microsoft.Extensions (ASP.NET Core & DI)

Pakiety do dependency injection, konfiguracji i logowania w aplikacjach .NET:

| Pakiet | Wersja | Przeznaczenie |
|--------|--------|--------------|
| `Microsoft.Extensions.Configuration` | 10.0.0 | Zarządzanie konfiguracją |
| `Microsoft.Extensions.Configuration.Json` | 10.0.0 | Konfiguracja z JSON |
| `Microsoft.Extensions.DependencyInjection` | 10.0.0 | Dependency Injection |
| `Microsoft.Extensions.Hosting` | 10.0.0 | Hosting aplikacji |
| `Microsoft.Extensions.Logging` | 10.0.0 | Logowanie |
| `Microsoft.Extensions.Logging.Console` | 10.0.0 | Logowanie do konsoli |
| `Microsoft.Extensions.Options` | 10.0.0 | Opcje konfiguracji |

**Używane przez:** WebApp, ConsoleApp, Hangman  
**Zawsze aktualizuj razem** do tej samej wersji!

---

### Entity Framework Core (Dostęp do Danych)

Pakiety do pracy z bazą danych w .NET Core:

| Pakiet | Wersja | Przeznaczenie |
|--------|--------|--------------|
| `Microsoft.EntityFrameworkCore` | 10.0.0 | Core EF functionality |
| `Microsoft.EntityFrameworkCore.SqlServer` | 10.0.0 | SQL Server provider |
| `Microsoft.EntityFrameworkCore.Tools` | 10.0.0 | Migration tools (PMC) |
| `Microsoft.EntityFrameworkCore.Proxies` | 10.0.0 | Lazy loading proxies |

**Używane przez:** WebApp, Models  
**Uwaga:** `EntityFrameworkCore.Tools` jest DevDependency (tylko do Development)

---

### ASP.NET Core Web (Dla WebApp)

Pakiety dla aplikacji web:

| Pakiet | Wersja | Przeznaczenie |
|--------|--------|--------------|
| `Microsoft.AspNetCore.Mvc` | 10.0.0 | MVC framework |
| `Microsoft.AspNetCore.OpenApi` | 10.0.0 | OpenAPI support |

**Używane przez:** WebApp

---

### Testing (Testowanie Jednostkowe)

Pakiety do testowania:

| Pakiet | Wersja | Przeznaczenie |
|--------|--------|--------------|
| `xunit` | 2.9.3 | Testing framework |
| `xunit.runner.visualstudio` | 3.1.5 | Visual Studio test runner |
| `Microsoft.NET.Test.Sdk` | 17.13.0 | Test SDK |
| `Moq` | 4.20.70 | Mocking library |
| `FluentAssertions` | 6.12.1 | Assertion helpers |
| `AutoFixture` | 4.18.1 | Test data generation |
| `NSubstitute` | 5.3.0 | Alternative mocking |

**Używane przez:** Hangman.UnitTests  
**Rekomendacja:** Zawsze uruchom `dotnet test` po aktualizacji

---

### JSON Serialization

Pakiety do pracy z JSON:

| Pakiet | Wersja | Przeznaczenie |
|--------|--------|--------------|
| `System.Text.Json` | 10.0.0 | Built-in JSON (.NET 10) |
| `Newtonsoft.Json` | 13.0.3 | Legacy JSON support |

**Uwaga:** `System.Text.Json` jest preferowany w .NET 10, ale czasem potrzebny jest `Newtonsoft.Json` dla kompatybilności wstecz.

---

### Validation (Walidacja Danych)

Pakiety do walidacji:

| Pakiet | Wersja | Przeznaczenie |
|--------|--------|--------------|
| `FluentValidation` | 11.11.0 | Fluent validation framework |
| `DataAnnotations.Localization` | 5.0.0 | Lokalizacja |

**Używane przez:** WebApp, Models

---

### Mapping (AutoMapper)

Pakiety do mapowania modeli:

| Pakiet | Wersja | Przeznaczenie |
|--------|--------|--------------|
| `AutoMapper` | 13.0.1 | Object mapping |
| `AutoMapper.Extensions.Microsoft.DependencyInjection` | 12.0.1 | DI Integration |

**Używane przez:** WebApp

---

### Logging & Monitoring

Pakiety do zaawansowanego logowania:

| Pakiet | Wersja | Przeznaczenie |
|--------|--------|--------------|
| `Serilog` | 4.2.0 | Structured logging |
| `Serilog.Extensions.Logging` | 9.0.1 | ILogger integration |
| `Serilog.Sinks.Console` | 6.1.1 | Console sink |
| `Serilog.Sinks.File` | 6.0.0 | File sink |

**Używane przez:** WebApp, ConsoleApp (opcjonalnie)

---

### Utilities (Narzędzia)

| Pakiet | Wersja | Przeznaczenie |
|--------|--------|--------------|
| `LanguageExt.Core` | 4.4.49 | Functional programming |

---

### Code Quality (Analiza Kodu)

| Pakiet | Wersja | Przeznaczenie |
|--------|--------|--------------|
| `StyleCop.Analyzers` | 1.2.0-beta.556 | Code style checks |
| `Microsoft.CodeAnalysis.NetAnalyzers` | 10.0.0 | Code analysis |

**Uwaga:** To są analuzery, automatycznie aktywne podczas budzenia.

---

### Benchmarking (Performance)

| Pakiet | Wersja | Przeznaczenie |
|--------|--------|--------------|
| `BenchmarkDotNet` | 0.15.2 | Performance benchmarking |
| `Microsoft.VisualStudio.DiagnosticsHub.BenchmarkDotNetDiagnosers` | 18.3.36812.1 | Profiling integration |

**Używane przez:** BenchmarkSuite1

---

## 📊 Przegląd Użycia Pakietów po Projekcie

### ConsoleApp
- Brak PackageReference (projekt czysto .NET)

### ConsoleApp_Debug
- Brak PackageReference

### ConsoleApp_Profiler
- Brak PackageReference

### Hangman
- Brak PackageReference

### Hangman.UnitTests
- ✅ `Microsoft.NET.Test.Sdk`
- ✅ `AutoFixture`
- ✅ `NSubstitute`
- ✅ `xunit`
- ✅ `xunit.runner.visualstudio`

### Models
- Brak PackageReference (tylko modele)

### WebApp
- ✅ `Microsoft.Extensions.*` (cały stack)
- ✅ `Microsoft.EntityFrameworkCore.*` (cały stack)
- ✅ `Microsoft.AspNetCore.Mvc`
- ✅ `Microsoft.AspNetCore.OpenApi`
- ✅ `Serilog` (opcjonalnie)
- ✅ `FluentValidation` (opcjonalnie)
- ✅ `AutoMapper` (opcjonalnie)

### BenchmarkSuite1
- ✅ `BenchmarkDotNet`
- ✅ `Microsoft.VisualStudio.DiagnosticsHub.BenchmarkDotNetDiagnosers`

---

## 🔄 Aktualizacja Wersji

### Procedura Aktualizacji Pakietu

1. **Edytuj `Directory.Packages.props`**
   ```xml
   <!-- PRZED -->
   <PackageVersion Include="xunit" Version="2.9.3" />

   <!-- PO -->
   <PackageVersion Include="xunit" Version="2.10.0" />
   ```

2. **Wyczyść cache i przywróć pakiety**
   ```powershell
   dotnet clean
   dotnet restore
   ```

3. **Zbuduj projekt**
   ```powershell
   dotnet build
   ```

4. **Uruchom testy**
   ```powershell
   dotnet test
   ```

5. **Zatwierdź zmiany**
   ```powershell
   git add Directory.Packages.props
   git commit -m "chore: update packages to newer versions"
   ```

---

## ⚙️ Konfiguracja .NET 10

Wszystkie pakiety powinny wspierać `.NET 10.0`:

```xml
<PropertyGroup>
  <TargetFramework>net10.0</TargetFramework>
  <LangVersion>latest</LangVersion>
  <Nullable>enable</Nullable>
</PropertyGroup>
```

---

## 🔍 Sprawdzenie Konfliktów Wersji

Uruchom polecenie, aby sprawdzić, czy są konflikty:

```powershell
# Pokaż wersje wszystkich pakietów
dotnet list package

# Pokaż tylko nieaktualne pakiety
dotnet list package --outdated

# Pokaż rozdzielczość pakietów z transitive dependencies
dotnet list package --include-transitive
```

---

## 🔒 Bezpieczeństwo Pakietów

### Monitorowanie Bezpieczeństwa

```powershell
# Sprawdzenie podatności znanych pakietów
dotnet package search <package-name>

# Lub offline - odwiedź https://www.cvedetails.com/
```

### Rekomendacje

- 🔒 Używaj `.NET 10` (Long Term Support)
- 🔒 Regularnie aktualizuj pakiety (`dotnet list package --outdated`)
- 🔒 Monitoruj CVE dla używanych pakietów
- 🔒 Nie używaj beta wersji w production

---

## 📝 Dodawanie Nowego Pakietu

### 1. Edytuj Directory.Packages.props

Dodaj nowy `PackageVersion` w odpowiedniej kategorii:

```xml
<ItemGroup>
  <!-- Twoja kategoria -->
  <PackageVersion Include="NazwaPakietu" Version="X.Y.Z" />
</ItemGroup>
```

### 2. Edytuj .csproj Projektu

W projekcie, gdzie chcesz użyć pakietu:

```xml
<ItemGroup>
  <PackageReference Include="NazwaPakietu" />
</ItemGroup>
```

### 3. Przywróć i Zbuduj

```powershell
dotnet restore
dotnet build
```

---

## 🎯 Najważniejsze Zasady

| Reguła | Opis |
|--------|------|
| **Jedna wersja** | Jeden pakiet = jedna wersja w `Directory.Packages.props` |
| **Razem z zależnościami** | EF Core, Extensions zawsze aktualizuj razem |
| **Zawsze testuj** | Po aktualizacji zawsze uruchom `dotnet test` |
| **Brak wersji w .csproj** | Wersje tylko w `Directory.Packages.props` |
| **Komentarze w kodzie** | Dokumentuj dlaczego używasz konkretnej wersji |
| **Monitoruj CVE** | Regularnie sprawdzaj bezpieczeństwo |

---

## 🆘 Problemy & Rozwiązania

### Problem: "Pakiet nie znaleziony"

```
error NU1101: Unable to find package 'XYZ'
```

**Rozwiązanie:**
1. Sprawdzić czy `PackageVersion` jest w `Directory.Packages.props`
2. Uruchomić `dotnet restore`
3. Sprawdzić czy pakiet istnieje na NuGet.org

### Problem: "Konflikt wersji"

```
warning NU1605: Detected package downgrade
```

**Rozwiązanie:**
1. Sprawdzić transitive dependencies
2. Aktualizować wszystkie powiązane pakiety
3. Uruchomić `dotnet restore` i `dotnet build`

### Problem: "Build time warning"

```
warning NU1701: Package is not compatible with project
```

**Rozwiązanie:**
1. Sprawdzić target framework w `.csproj`
2. Sprawdzić kompatybilność pakietu z .NET 10
3. Rozważyć aktualizację do nowszej wersji pakietu

---

## 📚 Przydatne Zasoby

- [NuGet.org](https://www.nuget.org/) — Baza pakietów
- [Microsoft Docs: CPM](https://learn.microsoft.com/en-us/nuget/consume/central-package-management)
- [.NET 10 Release Notes](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-10)
- [Semantic Versioning](https://semver.org/) — Jak czytać wersje

---

## 📞 FAQ

**P: Czy mogę mieć różne wersje tego samego pakietu dla różnych projektów?**  
O: Nie. CPM wymusza jedną wersję dla całego rozwiązania. Jeśli potrzebujesz różnych wersji, musisz:
- Zwrócić się do zespołu
- Rozważyć inny pakiet
- Zrezygnować z CPM dla tego pakietu (nie rekomendowane)

**P: Czy mogę używać versji z symbolami ( `~`, `^`, `*` )?**  
O: Nie. CPM wymaga konkretnych wersji (SemVer).

**P: Co jeśli pakiet jest już w transitive dependency?**  
O: Zawsze lepiej jawnie zdefiniować w `Directory.Packages.props`, nawet jeśli jest transitive.

**P: Czy CPM jest obowiązkowe?**  
O: Nie, ale jest zdecydowanie rekomendowane dla:
- Rozwiązań z wieloma projektami
- Zespołów
- Long-term support projektów

---

*Ostatnia aktualizacja: 2026-05-22*  
*Wersja: 1.0.0*
