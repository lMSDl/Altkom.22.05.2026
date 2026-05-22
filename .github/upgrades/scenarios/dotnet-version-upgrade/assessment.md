# Projects and dependencies analysis

This document provides a comprehensive overview of the projects and their dependencies in the context of upgrading to .NETCoreApp,Version=v9.0.

## Table of Contents

- [Executive Summary](#executive-Summary)
  - [Highlevel Metrics](#highlevel-metrics)
  - [Projects Compatibility](#projects-compatibility)
  - [Package Compatibility](#package-compatibility)
  - [API Compatibility](#api-compatibility)
- [Aggregate NuGet packages details](#aggregate-nuget-packages-details)
- [Top API Migration Challenges](#top-api-migration-challenges)
  - [Technologies and Features](#technologies-and-features)
  - [Most Frequent API Issues](#most-frequent-api-issues)
- [Projects Relationship Graph](#projects-relationship-graph)
- [Project Details](#project-details)

  - [BenchmarkSuite1\BenchmarkSuite1.csproj](#benchmarksuite1benchmarksuite1csproj)
  - [ConsoleApp\ConsoleApp.csproj](#consoleappconsoleappcsproj)
  - [ConsoleApp_Debug\ConsoleApp_Debug.csproj](#consoleapp_debugconsoleapp_debugcsproj)
  - [ConsoleApp_Profiler\ConsoleApp_Profiler.csproj](#consoleapp_profilerconsoleapp_profilercsproj)
  - [Hangman.UnitTests\Hangman.UnitTests.csproj](#hangmanunittestshangmanunittestscsproj)
  - [Hangman\Hangman.csproj](#hangmanhangmancsproj)
  - [Models\Models.csproj](#modelsmodelscsproj)
  - [WebApp\WebApp.csproj](#webappwebappcsproj)


## Executive Summary

### Highlevel Metrics

| Metric | Count | Status |
| :--- | :---: | :--- |
| Total Projects | 8 | 0 require upgrade |
| Total NuGet Packages | 7 | All compatible |
| Total Code Files | 29 |  |
| Total Code Files with Incidents | 0 |  |
| Total Lines of Code | 2214 |  |
| Total Number of Issues | 0 |  |
| Estimated LOC to modify | 0+ | at least 0,0% of codebase |

### Projects Compatibility

| Project | Target Framework | Difficulty | Package Issues | API Issues | Est. LOC Impact | Description |
| :--- | :---: | :---: | :---: | :---: | :---: | :--- |
| [BenchmarkSuite1\BenchmarkSuite1.csproj](#benchmarksuite1benchmarksuite1csproj) | net10.0 | ✅ None | 0 | 0 |  | DotNetCoreApp, Sdk Style = True |
| [ConsoleApp\ConsoleApp.csproj](#consoleappconsoleappcsproj) | net10.0 | ✅ None | 0 | 0 |  | DotNetCoreApp, Sdk Style = True |
| [ConsoleApp_Debug\ConsoleApp_Debug.csproj](#consoleapp_debugconsoleapp_debugcsproj) | net10.0 | ✅ None | 0 | 0 |  | DotNetCoreApp, Sdk Style = True |
| [ConsoleApp_Profiler\ConsoleApp_Profiler.csproj](#consoleapp_profilerconsoleapp_profilercsproj) | net10.0 | ✅ None | 0 | 0 |  | DotNetCoreApp, Sdk Style = True |
| [Hangman.UnitTests\Hangman.UnitTests.csproj](#hangmanunittestshangmanunittestscsproj) | net10.0 | ✅ None | 0 | 0 |  | DotNetCoreApp, Sdk Style = True |
| [Hangman\Hangman.csproj](#hangmanhangmancsproj) | net10.0 | ✅ None | 0 | 0 |  | DotNetCoreApp, Sdk Style = True |
| [Models\Models.csproj](#modelsmodelscsproj) | net10.0 | ✅ None | 0 | 0 |  | ClassLibrary, Sdk Style = True |
| [WebApp\WebApp.csproj](#webappwebappcsproj) | net10.0 | ✅ None | 0 | 0 |  | AspNetCore, Sdk Style = True |

### Package Compatibility

| Status | Count | Percentage |
| :--- | :---: | :---: |
| ✅ Compatible | 7 | 100,0% |
| ⚠️ Incompatible | 0 | 0,0% |
| 🔄 Upgrade Recommended | 0 | 0,0% |
| ***Total NuGet Packages*** | ***7*** | ***100%*** |

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 0 |  |
| ***Total APIs Analyzed*** | ***0*** |  |

## Aggregate NuGet packages details

| Package | Current Version | Suggested Version | Projects | Description |
| :--- | :---: | :---: | :--- | :--- |
| AutoFixture | 4.18.1 |  | [Hangman.UnitTests.csproj](#hangmanunittestshangmanunittestscsproj) | ✅Compatible |
| BenchmarkDotNet | 0.15.2 |  | [BenchmarkSuite1.csproj](#benchmarksuite1benchmarksuite1csproj) | ✅Compatible |
| Microsoft.NET.Test.Sdk | 17.13.0 |  | [Hangman.UnitTests.csproj](#hangmanunittestshangmanunittestscsproj) | ✅Compatible |
| Microsoft.VisualStudio.DiagnosticsHub.BenchmarkDotNetDiagnosers | 18.3.36812.1 |  | [BenchmarkSuite1.csproj](#benchmarksuite1benchmarksuite1csproj) | ✅Compatible |
| NSubstitute | 5.3.0 |  | [Hangman.UnitTests.csproj](#hangmanunittestshangmanunittestscsproj) | ✅Compatible |
| xunit | 2.9.3 |  | [Hangman.UnitTests.csproj](#hangmanunittestshangmanunittestscsproj) | ✅Compatible |
| xunit.runner.visualstudio | 3.1.5 |  | [Hangman.UnitTests.csproj](#hangmanunittestshangmanunittestscsproj) | ✅Compatible |

## Top API Migration Challenges

### Technologies and Features

| Technology | Issues | Percentage | Migration Path |
| :--- | :---: | :---: | :--- |

### Most Frequent API Issues

| API | Count | Percentage | Category |
| :--- | :---: | :---: | :--- |

## Projects Relationship Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart LR
    P1["<b>📦&nbsp;ConsoleApp.csproj</b><br/><small>net10.0</small>"]
    P2["<b>📦&nbsp;Hangman.UnitTests.csproj</b><br/><small>net10.0</small>"]
    P3["<b>📦&nbsp;Hangman.csproj</b><br/><small>net10.0</small>"]
    P4["<b>📦&nbsp;Models.csproj</b><br/><small>net10.0</small>"]
    P5["<b>📦&nbsp;WebApp.csproj</b><br/><small>net10.0</small>"]
    P6["<b>📦&nbsp;ConsoleApp_Profiler.csproj</b><br/><small>net10.0</small>"]
    P7["<b>📦&nbsp;BenchmarkSuite1.csproj</b><br/><small>net10.0</small>"]
    P8["<b>📦&nbsp;ConsoleApp_Debug.csproj</b><br/><small>net10.0</small>"]
    P2 --> P3
    P5 --> P4
    P7 --> P6
    click P1 "#consoleappconsoleappcsproj"
    click P2 "#hangmanunittestshangmanunittestscsproj"
    click P3 "#hangmanhangmancsproj"
    click P4 "#modelsmodelscsproj"
    click P5 "#webappwebappcsproj"
    click P6 "#consoleapp_profilerconsoleapp_profilercsproj"
    click P7 "#benchmarksuite1benchmarksuite1csproj"
    click P8 "#consoleapp_debugconsoleapp_debugcsproj"

```

## Project Details

<a id="benchmarksuite1benchmarksuite1csproj"></a>
### BenchmarkSuite1\BenchmarkSuite1.csproj

#### Project Info

- **Current Target Framework:** net10.0✅
- **SDK-style**: True
- **Project Kind:** DotNetCoreApp
- **Dependencies**: 1
- **Dependants**: 0
- **Number of Files**: 3
- **Lines of Code**: 216
- **Estimated LOC to modify**: 0+ (at least 0,0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph current["BenchmarkSuite1.csproj"]
        MAIN["<b>📦&nbsp;BenchmarkSuite1.csproj</b><br/><small>net10.0</small>"]
        click MAIN "#benchmarksuite1benchmarksuite1csproj"
    end
    subgraph downstream["Dependencies (1"]
        P6["<b>📦&nbsp;ConsoleApp_Profiler.csproj</b><br/><small>net10.0</small>"]
        click P6 "#consoleapp_profilerconsoleapp_profilercsproj"
    end
    MAIN --> P6

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 0 |  |
| ***Total APIs Analyzed*** | ***0*** |  |

<a id="consoleappconsoleappcsproj"></a>
### ConsoleApp\ConsoleApp.csproj

#### Project Info

- **Current Target Framework:** net10.0✅
- **SDK-style**: True
- **Project Kind:** DotNetCoreApp
- **Dependencies**: 0
- **Dependants**: 0
- **Number of Files**: 4
- **Lines of Code**: 126
- **Estimated LOC to modify**: 0+ (at least 0,0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph current["ConsoleApp.csproj"]
        MAIN["<b>📦&nbsp;ConsoleApp.csproj</b><br/><small>net10.0</small>"]
        click MAIN "#consoleappconsoleappcsproj"
    end

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 0 |  |
| ***Total APIs Analyzed*** | ***0*** |  |

<a id="consoleapp_debugconsoleapp_debugcsproj"></a>
### ConsoleApp_Debug\ConsoleApp_Debug.csproj

#### Project Info

- **Current Target Framework:** net10.0✅
- **SDK-style**: True
- **Project Kind:** DotNetCoreApp
- **Dependencies**: 0
- **Dependants**: 0
- **Number of Files**: 1
- **Lines of Code**: 80
- **Estimated LOC to modify**: 0+ (at least 0,0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph current["ConsoleApp_Debug.csproj"]
        MAIN["<b>📦&nbsp;ConsoleApp_Debug.csproj</b><br/><small>net10.0</small>"]
        click MAIN "#consoleapp_debugconsoleapp_debugcsproj"
    end

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 0 |  |
| ***Total APIs Analyzed*** | ***0*** |  |

<a id="consoleapp_profilerconsoleapp_profilercsproj"></a>
### ConsoleApp_Profiler\ConsoleApp_Profiler.csproj

#### Project Info

- **Current Target Framework:** net10.0✅
- **SDK-style**: True
- **Project Kind:** DotNetCoreApp
- **Dependencies**: 0
- **Dependants**: 1
- **Number of Files**: 1
- **Lines of Code**: 37
- **Estimated LOC to modify**: 0+ (at least 0,0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph upstream["Dependants (1)"]
        P7["<b>📦&nbsp;BenchmarkSuite1.csproj</b><br/><small>net10.0</small>"]
        click P7 "#benchmarksuite1benchmarksuite1csproj"
    end
    subgraph current["ConsoleApp_Profiler.csproj"]
        MAIN["<b>📦&nbsp;ConsoleApp_Profiler.csproj</b><br/><small>net10.0</small>"]
        click MAIN "#consoleapp_profilerconsoleapp_profilercsproj"
    end
    P7 --> MAIN

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 0 |  |
| ***Total APIs Analyzed*** | ***0*** |  |

<a id="hangmanunittestshangmanunittestscsproj"></a>
### Hangman.UnitTests\Hangman.UnitTests.csproj

#### Project Info

- **Current Target Framework:** net10.0✅
- **SDK-style**: True
- **Project Kind:** DotNetCoreApp
- **Dependencies**: 1
- **Dependants**: 0
- **Number of Files**: 7
- **Lines of Code**: 1201
- **Estimated LOC to modify**: 0+ (at least 0,0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph current["Hangman.UnitTests.csproj"]
        MAIN["<b>📦&nbsp;Hangman.UnitTests.csproj</b><br/><small>net10.0</small>"]
        click MAIN "#hangmanunittestshangmanunittestscsproj"
    end
    subgraph downstream["Dependencies (1"]
        P3["<b>📦&nbsp;Hangman.csproj</b><br/><small>net10.0</small>"]
        click P3 "#hangmanhangmancsproj"
    end
    MAIN --> P3

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 0 |  |
| ***Total APIs Analyzed*** | ***0*** |  |

<a id="hangmanhangmancsproj"></a>
### Hangman\Hangman.csproj

#### Project Info

- **Current Target Framework:** net10.0✅
- **SDK-style**: True
- **Project Kind:** DotNetCoreApp
- **Dependencies**: 0
- **Dependants**: 1
- **Number of Files**: 15
- **Lines of Code**: 386
- **Estimated LOC to modify**: 0+ (at least 0,0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph upstream["Dependants (1)"]
        P2["<b>📦&nbsp;Hangman.UnitTests.csproj</b><br/><small>net10.0</small>"]
        click P2 "#hangmanunittestshangmanunittestscsproj"
    end
    subgraph current["Hangman.csproj"]
        MAIN["<b>📦&nbsp;Hangman.csproj</b><br/><small>net10.0</small>"]
        click MAIN "#hangmanhangmancsproj"
    end
    P2 --> MAIN

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 0 |  |
| ***Total APIs Analyzed*** | ***0*** |  |

<a id="modelsmodelscsproj"></a>
### Models\Models.csproj

#### Project Info

- **Current Target Framework:** net10.0✅
- **SDK-style**: True
- **Project Kind:** ClassLibrary
- **Dependencies**: 0
- **Dependants**: 1
- **Number of Files**: 1
- **Lines of Code**: 10
- **Estimated LOC to modify**: 0+ (at least 0,0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph upstream["Dependants (1)"]
        P5["<b>📦&nbsp;WebApp.csproj</b><br/><small>net10.0</small>"]
        click P5 "#webappwebappcsproj"
    end
    subgraph current["Models.csproj"]
        MAIN["<b>📦&nbsp;Models.csproj</b><br/><small>net10.0</small>"]
        click MAIN "#modelsmodelscsproj"
    end
    P5 --> MAIN

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 0 |  |
| ***Total APIs Analyzed*** | ***0*** |  |

<a id="webappwebappcsproj"></a>
### WebApp\WebApp.csproj

#### Project Info

- **Current Target Framework:** net10.0✅
- **SDK-style**: True
- **Project Kind:** AspNetCore
- **Dependencies**: 1
- **Dependants**: 0
- **Number of Files**: 5
- **Lines of Code**: 158
- **Estimated LOC to modify**: 0+ (at least 0,0% of the project)

#### Dependency Graph

Legend:
📦 SDK-style project
⚙️ Classic project

```mermaid
flowchart TB
    subgraph current["WebApp.csproj"]
        MAIN["<b>📦&nbsp;WebApp.csproj</b><br/><small>net10.0</small>"]
        click MAIN "#webappwebappcsproj"
    end
    subgraph downstream["Dependencies (1"]
        P4["<b>📦&nbsp;Models.csproj</b><br/><small>net10.0</small>"]
        click P4 "#modelsmodelscsproj"
    end
    MAIN --> P4

```

### API Compatibility

| Category | Count | Impact |
| :--- | :---: | :--- |
| 🔴 Binary Incompatible | 0 | High - Require code changes |
| 🟡 Source Incompatible | 0 | Medium - Needs re-compilation and potential conflicting API error fixing |
| 🔵 Behavioral change | 0 | Low - Behavioral changes that may require testing at runtime |
| ✅ Compatible | 0 |  |
| ***Total APIs Analyzed*** | ***0*** |  |

