# ✅ CPM Checklist - Praktyka dla Zespołu

## Dla Deweloperów

Używasz CPM (Central Package Management) w tym projekcie. Poniżej praktyczne wskazówki.

---

## 📋 Checklist: Dodanie Nowego Pakietu

### Przed Dodaniem Pakietu

- [ ] Sprawdzam czy pakiet jest dostępny na [NuGet.org](https://www.nuget.org/)
- [ ] Sprawdzam aktualną wersję pakietu
- [ ] Sprawdzam czy pakiet wspiera `.NET 10.0`
- [ ] Sprawdzam licencję pakietu (kompatybilną z projektem)
- [ ] Sprawdzam CVE dla pakietu na [NVD.NIST.GOV](https://nvd.nist.gov/)

### Dodawanie Pakietu do CPM

- [ ] Otwieram `Directory.Packages.props`
- [ ] Dodaję `<PackageVersion>` w odpowiedniej kategorii
- [ ] Formatuję zgodnie z istniejącą strukturą
- [ ] Dodaję komentarz jeśli jest to nowy typ pakietu

```xml
<ItemGroup>
  <!-- Kategoria: Twój pakiet -->
  <PackageVersion Include="NazwaPakietu" Version="X.Y.Z" />
</ItemGroup>
```

### Dodawanie Pakietu do Projektu

- [ ] Otwieram `.csproj` projektu, w którym potrzebny jest pakiet
- [ ] Dodaję `<PackageReference>` **bez wersji** (!)
- [ ] Sprawdzam czy formatowanie jest poprawne

```xml
<ItemGroup>
  <PackageReference Include="NazwaPakietu" />
</ItemGroup>
```

### Weryfikacja i Commit

- [ ] Uruchamiam `dotnet clean`
- [ ] Uruchamiam `dotnet restore`
- [ ] Uruchamiam `dotnet build`
- [ ] Uruchamiam `dotnet test`
- [ ] Wszystkie testy przechodzą ✅
- [ ] Commituję zmiany z wiadomością:
  ```
  feat(packages): add <PackageName> for <purpose>
  ```

---

## 📋 Checklist: Aktualizacja Pakietu

### Przed Aktualizacją

- [ ] Sprawdzam Release Notes pakietu
- [ ] Sprawdzam czy jest to Major/Minor/Patch update
- [ ] Sprawdzam Breaking Changes
- [ ] Jeśli Major update: przygotowuję test plan

### Aktualizacja w CPM

- [ ] Otwieram `Directory.Packages.props`
- [ ] Zmieniam wersję pakietu
- [ ] Jeśli aktualizuję `Microsoft.EntityFrameworkCore`, aktualizuję **wszystkie** EF pakiety
- [ ] Jeśli aktualizuję `Microsoft.Extensions.*`, **nie muszę** aktualizować razem (ale rekomendowane)

### Weryfikacja po Aktualizacji

- [ ] Uruchamiam `dotnet clean`
- [ ] Uruchamiam `dotnet restore`
- [ ] Uruchamiam `dotnet build` (0 warnings)
- [ ] Uruchamiam `dotnet test` (wszystkie testy przechodzą)
- [ ] Sprawdzam czy aplikacja startuje poprawnie
- [ ] Commituję zmianę:
  ```
  chore(packages): update <PackageName> to X.Y.Z
  ```

---

## 📋 Checklist: Code Review (CPM)

Jak reviować PR zawierający zmiany w CPM:

### Package Addition Review

- [ ] Czy pakiet istnieje na NuGet.org?
- [ ] Czy wersja jest konkretna (nie `*`, `~`, `^`)?
- [ ] Czy pakiet wspiera `.NET 10.0`?
- [ ] Czy pakiet jest w odpowiedniej kategorii w `Directory.Packages.props`?
- [ ] Czy `PackageReference` w `.csproj` nie ma wersji?
- [ ] Czy nie ma duplikatów tego pakietu w innych `.csproj`?
- [ ] Czy licencja jest kompatybilna?
- [ ] Czy dokumentacja wyjaśnia dlaczego pakiet jest potrzebny?

### Package Update Review

- [ ] Czy to jest Minor lub Patch update (bezpieczne)?
- [ ] Jeśli Major: czy testy przechodzą?
- [ ] Czy powiązane pakiety są aktualizowane razem (np. EF Core)?
- [ ] Czy `dotnet build` i `dotnet test` przechodzą w CI?
- [ ] Czy nie ma nowszej wersji dostępnej?

### Best Practices

- ✅ Pakiety logicznie pogrupowane
- ✅ Komentarze opisują kategorię
- ✅ Spójne formatowanie i wcięcia
- ✅ Brak wersji w `.csproj` (wszystkie w `Directory.Packages.props`)
- ✅ Brak zduplikowanych `PackageReference`

---

## 🚀 Praktyki Dobre

### ✅ DOBRA PRAKTYKA: Logiczne Grupy

```xml
<ItemGroup>
  <!-- Entity Framework Core -->
  <PackageVersion Include="Microsoft.EntityFrameworkCore" Version="10.0.0" />
  <PackageVersion Include="Microsoft.EntityFrameworkCore.SqlServer" Version="10.0.0" />
  <PackageVersion Include="Microsoft.EntityFrameworkCore.Tools" Version="10.0.0" />
</ItemGroup>

<ItemGroup>
  <!-- Testing -->
  <PackageVersion Include="xunit" Version="2.9.3" />
  <PackageVersion Include="xunit.runner.visualstudio" Version="3.1.5" />
</ItemGroup>
```

### ✅ DOBRA PRAKTYKA: Informacyjny Commit

```
chore(packages): update Microsoft.EntityFrameworkCore to 10.0.1

- Updates core EF package
- Updates SqlServer provider (must be in sync)
- Updates Tools for migrations
- All tests pass
- No breaking changes detected
```

### ✅ DOBRA PRAKTYKA: Dokumentacja

```xml
<!-- Microsoft.Extensions (DI, Logging, Configuration) -->
<!-- Version: 10.0.0 (LTS - Long Term Support) -->
<!-- Używane przez WebApp, ConsoleApp -->
<PackageVersion Include="Microsoft.Extensions.DependencyInjection" Version="10.0.0" />
```

---

## ❌ Błędy do Uniknięcia

### ❌ BŁĄD: Wersja w .csproj

```xml
<!-- ❌ NIGDY TAK -->
<ItemGroup>
  <PackageReference Include="xunit" Version="2.9.3" />
</ItemGroup>

<!-- ✅ ZAWSZE TAK -->
<ItemGroup>
  <PackageReference Include="xunit" />
</ItemGroup>
```

### ❌ BŁĄD: Rozbieżne Wersje EF Core

```xml
<!-- ❌ ZŁE: Różne wersje -->
<PackageVersion Include="Microsoft.EntityFrameworkCore" Version="10.0.0" />
<PackageVersion Include="Microsoft.EntityFrameworkCore.SqlServer" Version="9.0.0" />

<!-- ✅ DOBRE: Ta sama wersja -->
<PackageVersion Include="Microsoft.EntityFrameworkCore" Version="10.0.0" />
<PackageVersion Include="Microsoft.EntityFrameworkCore.SqlServer" Version="10.0.0" />
```

### ❌ BŁĄD: Symbole Zamiast Konkretnych Wersji

```xml
<!-- ❌ NIGDY -->
<PackageVersion Include="xunit" Version="2.9.*" />
<PackageVersion Include="Serilog" Version="^4.0" />

<!-- ✅ ZAWSZE -->
<PackageVersion Include="xunit" Version="2.9.3" />
<PackageVersion Include="Serilog" Version="4.2.0" />
```

### ❌ BŁĄD: Duplikat Pakietu

```xml
<!-- ❌ Duplikat w innym ItemGroup -->
<ItemGroup>
  <PackageVersion Include="xunit" Version="2.9.3" />
</ItemGroup>

<ItemGroup>
  <PackageVersion Include="xunit" Version="2.9.3" />
</ItemGroup>

<!-- ✅ Jeden PackageVersion na pakiet -->
<ItemGroup>
  <PackageVersion Include="xunit" Version="2.9.3" />
</ItemGroup>
```

---

## 🔍 Polecenia Diagnostyczne

### Sprawdzenie Bieżących Pakietów

```powershell
# Pokaż wszystkie pakiety użyte w rozwiązaniu
dotnet list package

# Pokaż tylko nieaktualne pakiety
dotnet list package --outdated

# Pokaż pakiety z ich wersji transitive
dotnet list package --include-transitive

# Sprawdzenie dla konkretnego projektu
dotnet list ./Hangman.UnitTests/Hangman.UnitTests.csproj package
```

### Weryfikacja Poprawności

```powershell
# Wyczyść cache
dotnet clean

# Przywróć pakiety
dotnet restore

# Zbuduj (nie powinno być warnings)
dotnet build

# Uruchom testy
dotnet test

# Pokaż warnings jako errors
dotnet build --treat-warnings-as-errors
```

### Zweryfikuj CPM

```powershell
# Sprawdź czy wszystkie pakiety są z CPM
Get-Content Directory.Packages.props | Select-String "PackageVersion"

# Sprawdź czy są jeszcze wersje w .csproj (powinno być 0 wyników)
Get-ChildItem -Recurse -Include "*.csproj" | 
  ForEach-Object { 
	$content = Get-Content $_
	if ($content -match 'PackageReference.*Version=') {
	  Write-Host "❌ Znaleziono PackageReference z wersją w: $_"
	}
  }
```

---

## 📊 Raport Pakietów

### Generowanie Raportu

```powershell
# Wszystkie pakiety w tabelce
dotnet list package --format json | ConvertFrom-Json

# Eksport do CSV (jeśli potrzeba)
dotnet list package --format json | 
  ConvertFrom-Json | 
  Select-Object -ExpandProperty projects | 
  ForEach-Object {
	$_.frameworks | 
	ForEach-Object {
	  $_.topLevelPackages | 
	  ForEach-Object {
		[PSCustomObject]@{
		  Package = $_.id
		  Resolved = $_.resolvedVersion
		  Requested = $_.requestedVersion
		}
	  }
	}
  } | 
  Export-Csv -Path "packages-report.csv" -NoTypeInformation
```

---

## 🔐 Bezpieczeństwo Pakietów

### Checklist Bezpieczeństwa

- [ ] Sprawdzam CVE dla każdego nowego pakietu
- [ ] Regularnie sprawdzam `dotnet list package --outdated`
- [ ] Nie używam beta wersji poza `LTS` dla production
- [ ] Monituję bezpieczeństwo pakietów

### Narzędzia Bezpieczeństwa

```powershell
# GitHub Security (jeśli repo jest na GitHub)
# Settings -> Code security and analysis -> Enable all

# Microsoft Security Advisory
# https://aka.ms/dotnet-nuget-security

# NVD - National Vulnerability Database
# https://nvd.nist.gov/
```

---

## 📱 Notyfikacje

### GitHub Notifications

Jeśli używasz GitHub:
1. Idź do **Settings** → **Code security and analysis**
2. Włącz **Dependabot alerts**
3. Włącz **Dependabot security updates**

Będziesz dostawać notyfikacje o podatnościach pakietów!

---

## 📚 Szybka Ściąga

| Zadanie | Polecenie |
|---------|-----------|
| Wylistuj pakiety | `dotnet list package` |
| Pokaż nieaktualne | `dotnet list package --outdated` |
| Wyczyść cache | `dotnet clean` |
| Przywróć pakiety | `dotnet restore` |
| Zbuduj projekt | `dotnet build` |
| Uruchom testy | `dotnet test` |
| Pokaż warnings | `dotnet build /p:TreatWarningsAsErrors=true` |

---

## 📞 Pytania Częste

**P: Mogę dodać pakiet do `.csproj` bez dodawania do `Directory.Packages.props`?**  
O: Nie. CPM wymaga, aby wszystkie wersje były w `Directory.Packages.props`.

**P: Co jeśli dwa projekty potrzebują różnych wersji tego samego pakietu?**  
O: CPM nie pozwala na to. Musisz:
1. Wybrać wspólną wersję (backward compatible update)
2. Zwrócić się do zespołu
3. Dokumentować dlaczego różne wersje są potrzebne

**P: Czy CPM wpływa na performance buildu?**  
O: Nie, wydajność jest taka sama. CPM jest tylko mechanizmem zarządzania.

**P: Jak migrować stary projekt bez CPM do CPM?**  
O: Patrz `CPM-GUIDE.md` → sekcja "Dodawanie Nowego Pakietu".

---

## 🎯 Podsumowanie

**CPM to:**
- ✅ Centralne miejsce dla wszystkich wersji pakietów
- ✅ Gwarancja konsystencji w całym rozwiązaniu
- ✅ Łatwa aktualizacja wersji
- ✅ Zmniejszenie błędów z konfliktami wersji

**Pamiętaj:**
1. Wersje TYLKO w `Directory.Packages.props`
2. Brak wersji w `.csproj` (bez numerów!)
3. Zawsze testuj po zmianie
4. Dokumentuj dlaczego wersja

---

*Ostatnia aktualizacja: 2026-05-22*  
*Wersja: 1.0.0*
