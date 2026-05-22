# 01-downgrade-framework: Update all projects to .NET 9

Update all 8 projects from `.NET 10.0` to `.NET 9.0` by modifying `<TargetFramework>` in project files.

**Affected Projects**: BenchmarkSuite1, ConsoleApp, ConsoleApp_Debug, ConsoleApp_Profiler, Hangman, Hangman.UnitTests, Models, WebApp

**Scope**: 
- Change `net10.0` → `net9.0` in all `.csproj` files
- All packages are compatible — no package updates required
- No API changes expected (downgrade is straightforward)

**Known Issues**: None. Assessment reports 0 compatibility issues.

**Done when**: 
- All 8 projects target `net9.0` (verified in .csproj files)
- Solution builds without errors or warnings
- All unit tests pass (Hangman.UnitTests)
- Verify no compilation errors with `dotnet build`

