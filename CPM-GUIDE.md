# 📦 Central Package Management (CPM) - Przewodnik

## Co to jest CPM?

**Central Package Management** to nowoczesny sposób zarządzania wersjami pakietów NuGet w rozwiązaniu .NET. Zamiast definiować wersje pakietów w każdym pliku `.csproj`, wszystkie wersje są definiowane w jednym centralnym pliku: **`Directory.Packages.props`**.

### Główne zalety:

✅ **Jedna źródło prawdy** — wszystkie pakiety w jednym miejscu  
✅ **Konsystencja** — wszyscy deweloperzy używają dokładnie tych samych wersji  
✅ **Szybka aktualizacja** — zmień wersję jednym klikjem dla całego rozwiązania  
✅ **Bezpieczeństwo** — uniknięcie konfliktów wersji między projektami  
✅ **Audit** — łatwo zobaczyć wszystkie zależności i ich wersje  
✅ **Skalabilność** — idealne dla dużych rozwiązań z wieloma projektami  

---

## 📁 Struktura CPM w Projekcie

```
Altkom.22.05.2026/
├── Directory.Packages.props          ← Centralna konfiguracja wersji
├── ConsoleApp/
│   └── ConsoleApp.csproj
├── Hangman/
│   └── Hangman.csproj
├── Hangman.UnitTests/
│   └── Hangman.UnitTests.csproj
├── Models/
│   └── Models.csproj
├── WebApp/
│   └── WebApp.csproj
├── ConsoleApp_Profiler/
│   └── ConsoleApp_Profiler.csproj
├── BenchmarkSuite1/
│   └── BenchmarkSuite1.csproj
├── ConsoleApp_Debug/
│   └── ConsoleApp_Debug.csproj
└── CPM-GUIDE.md                      ← Ten plik
```

---

## 🚀 Jak Używać CPM

### 1. Dodawanie Pakietu do Directory.Packages.props

W pliku `Directory.Packages.props` dodaj nowy `PackageVersion`:

```xml
<ItemGroup>
  <!-- Twoja nowa biblioteka -->
  <PackageVersion Include="Serilog" Version="4.2.0" />
</ItemGroup>
```

### 2. Referencjowanie Pakietu w Projekcie

W pliku `.csproj` projektu referencjonuj pakiet **bez wersji**:

```xml
<!-- PRZED (bez CPM) -->
<ItemGroup>
  <PackageReference Include="Serilog" Version="4.2.0" />
</ItemGroup>

<!-- PO (z CPM) -->
<ItemGroup>
  <PackageReference Include="Serilog" />
</ItemGroup>
```

Wersja będzie automatycznie pobrana z `Directory.Packages.props`.

### 3. Weryfikacja

Zbuduj projekt:
```powershell
dotnet build
```

Visual Studio automatycznie rozwiąże wersję pakietu z `Directory.Packages.props`.

---

## 📝 Kategorie Pakietów w CPM

Pakiety są logicznie pogrupowane w `Directory.Packages.props`:

### Microsoft.Extensions
Pakiety ekosystemu .NET do dependency injection, konfiguracji, logowania:
```xml
<PackageVersion Include="Microsoft.Extensions.DependencyInjection" Version="10.0.0" />
<PackageVersion Include="Microsoft.Extensions.Configuration" Version="10.0.0" />
<PackageVersion Include="Microsoft.Extensions.Logging" Version="10.0.0" />
```

### Entity Framework Core
Pakiety dostępu do danych:
```xml
<PackageVersion Include="Microsoft.EntityFrameworkCore" Version="10.0.0" />
<PackageVersion Include="Microsoft.EntityFrameworkCore.SqlServer" Version="10.0.0" />
```

### Testing
Pakiety do testowania:
```xml
<PackageVersion Include="xunit" Version="2.9.3" />
<PackageVersion Include="Moq" Version="4.20.70" />
<PackageVersion Include="AutoFixture" Version="4.18.1" />
```

### JSON & Serialization
Pakiety do pracy z danymi:
```xml
<PackageVersion Include="System.Text.Json" Version="10.0.0" />
<PackageVersion Include="Newtonsoft.Json" Version="13.0.3" />
```

### Logging & Monitoring
Pakiety logowania:
```xml
<PackageVersion Include="Serilog" Version="4.2.0" />
<PackageVersion Include="Serilog.Sinks.Console" Version="6.1.1" />
```

---

## 🔄 Aktualizacja Pakietów

### Scenariusz 1: Aktualizacja Jednego Pakietu

**Zmiana:** Aktualizuj wersję w `Directory.Packages.props`

```xml
<!-- PRZED -->
<PackageVersion Include="xunit" Version="2.9.3" />

<!-- PO -->
<PackageVersion Include="xunit" Version="2.10.0" />
```

Wersja jest automatycznie aktualizowana we wszystkich projektach!

### Scenariusz 2: Aktualizacja Wielu Pakietów

Edytuj `Directory.Packages.props` i zmień wersje:

```powershell
# Zbuduj projekt, aby zweryfikować kompatybilność
dotnet build

# Jeśli pojawią się błędy, przywróć starsze wersje
```

### Scenariusz 3: Upgrade do Nowszej Wersji .NET

Jeśli uaktualnisz projekt na .NET 11, musisz:

1. Zaktualizować wersje pakietów w `Directory.Packages.props`
2. Zmienić `<TargetFramework>` w każdym `.csproj`

```xml
<!-- Directory.Packages.props -->
<PackageVersion Include="Microsoft.EntityFrameworkCore" Version="11.0.0" />
<!-- Pozostałe pakiety... -->
```

```xml
<!-- Każdy .csproj -->
<PropertyGroup>
  <TargetFramework>net11.0</TargetFramework>
</PropertyGroup>
```

---

## ➕ Dodawanie Nowego Pakietu (Krok po Kroku)

### Krok 1: Dodaj do Directory.Packages.props

Otwórz `Directory.Packages.props` i dodaj nowy `PackageVersion` w odpowiedniej kategorii:

```xml
<ItemGroup>
  <!-- Logging & Monitoring -->
  <PackageVersion Include="Serilog" Version="4.2.0" />
  <PackageVersion Include="Serilog.Extensions.Logging" Version="9.0.1" />
  <PackageVersion Include="Serilog.Sinks.Console" Version="6.1.1" />
  <PackageVersion Include="Serilog.Sinks.File" Version="6.0.0" />
  <PackageVersion Include="Serilog.Sinks.MSSqlServer" Version="7.0.0" />  ← NOWY PAKIET
</ItemGroup>
```

### Krok 2: Dodaj do .csproj

W projekcie, gdzie chcesz użyć pakietu:

```xml
<ItemGroup>
  <PackageReference Include="Serilog.Sinks.MSSqlServer" />
</ItemGroup>
```

### Krok 3: Przywróć pakiety

```powershell
dotnet restore
```

### Krok 4: Zbuduj i testuj

```powershell
dotnet build
dotnet test
```

---

## 🔍 Sprawdzenie Bieżących Pakietów

### Wylistuj wszystkie pakiety w projekcie:

```powershell
dotnet list package
```

### Wylistuj nieaktualne pakiety:

```powershell
dotnet list package --outdated
```

### Sprawdź, czy wszystkie pakiety są zgodne:

```powershell
dotnet build --no-restore
```

---

## ⚠️ Best Practices

### ✅ DO:

- **Grupy logiczne** — organizuj pakiety w kategorie (Testing, Logging, EF Core, itp.)
- **Komentarze** — dodaj komentarze dla każdej kategorii
- **Spójne wersje** — jeśli możesz, używaj tej samej wersji dla powiązanych pakietów
  ```xml
  <!-- Wszystkie z EF Core powinny być w wersji 10.0.0 -->
  <PackageVersion Include="Microsoft.EntityFrameworkCore" Version="10.0.0" />
  <PackageVersion Include="Microsoft.EntityFrameworkCore.SqlServer" Version="10.0.0" />
  <PackageVersion Include="Microsoft.EntityFrameworkCore.Tools" Version="10.0.0" />
  ```
- **Referencyjne wersje** — aktualizuj razem pakiety, które są od siebie zależne
- **Testuj po aktualizacji** — zawsze uruchom `dotnet build` i `dotnet test` po zmianie wersji

### ❌ DON'T:

- ❌ Nie dodawaj wersji w `.csproj` (CPM zarządza wersjami!)
- ❌ Nie mieszaj źródeł — wszystkie pakiety powinny pochodzić z `Directory.Packages.props`
- ❌ Nie duplikuj PackageVersion — jeden pakiet, jedna definicja
- ❌ Nie używaj `*` w wersjach (zawsze podawaj konkretną wersję)
- ❌ Nie ignoruj konfliktów wersji — zawsze je rozwiąż

---

## 🐛 Troubleshooting

### Problem: "Pakiet nie znaleziony"

```
error NU1101: Unable to find package 'Serilog'
```

**Rozwiązanie:**
1. Upewnij się, że `PackageVersion` jest w `Directory.Packages.props`
2. Uruchom `dotnet restore`
3. Zbuduj projekt: `dotnet build`

### Problem: "Konflikt wersji"

```
warning NU1605: Detected package downgrade
```

**Rozwiązanie:**
1. Otwórz `Directory.Packages.props`
2. Sprawdź wersje powiązanych pakietów
3. Aktualizuj je razem (np. wszystkie EF Core)

### Problem: "PackageReference ma wersję w .csproj"

```xml
<!-- ❌ BŁĄD - wersja jest tutaj -->
<PackageReference Include="Serilog" Version="4.2.0" />
```

**Rozwiązanie:**
```xml
<!-- ✅ PRAWIDŁOWO - brak wersji -->
<PackageReference Include="Serilog" />
```

### Problem: "Build nie rozpoznaje zmian w CPM"

```powershell
# Wyczyść cache
dotnet clean

# Przywróć pakiety
dotnet restore

# Zbuduj
dotnet build
```

---

## 📊 Monitoring Pakietów

### Sprawdzenie Licencji Pakietów

Niektóre pakiety mają restrykcyjne licencje. Zawsze sprawdź:
- NuGet.org — opis licencji
- Project Documentation — szczegóły licencji

### Bezpieczeństwo

- 🔒 Regularnie aktualizuj pakiety
- 🔒 Monitoruj CVE (Common Vulnerabilities and Exposures)
- 🔒 Używaj `dotnet list package --outdated` do szukania aktualizacji

---

## 🔗 Przydatne Linki

- [Microsoft Docs: Central Package Management](https://learn.microsoft.com/en-us/nuget/consume/central-package-management)
- [NuGet.org](https://www.nuget.org/)
- [.NET 10 Documentation](https://learn.microsoft.com/en-us/dotnet/core/whats-new/dotnet-10)

---

## 📋 Szybka Ściąga

| Zadanie | Polecenie |
|---------|-----------|
| Zbuduj projekt | `dotnet build` |
| Wylistuj pakiety | `dotnet list package` |
| Wylistuj nieaktualne | `dotnet list package --outdated` |
| Przywróć pakiety | `dotnet restore` |
| Wyczyść cache | `dotnet clean` |
| Uruchom testy | `dotnet test` |

---

## 👥 Dla Zespołu

Wszystkie pliki `.csproj` są teraz **bardziej czytelne** — bez wersji pakietów rozproszonych wszędzie.

**Przed CPM:** 8 projektów × 5 pakietów = 40 wersji do zarządzania  
**Po CPM:** 1 plik (Directory.Packages.props) = 1 źródło prawdy ✨

---

## ✨ Podsumowanie

- 📍 **Lokalizacja:** `Directory.Packages.props` w głównym katalogu
- 📝 **Funkcja:** Centralne zarządzanie wersjami pakietów
- 🔧 **Użycie:** Dodaj `PackageVersion`, referencjonuj bez wersji w `.csproj`
- 🚀 **Skala:** Idealne dla zespołów i dużych rozwiązań

**Pytania?** Zwróć się do dokumentacji .NET lub odwiedź NuGet.org.

---

*Ostatnia aktualizacja: 2026-05-22*  
*Wersja: 1.0.0*
