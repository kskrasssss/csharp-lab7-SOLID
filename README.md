🇬🇧 **English** | 🇺🇦 [Українська](README.uk.md)

# 🧱 Lab7: SOLID Refactoring Toolkit

A **C# / .NET** console project that refactors five pieces of legacy code, each violating a different SOLID principle, and documents DRY, KISS and YAGNI decisions.

![C#](https://img.shields.io/badge/C%23-12-239120?logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-8.0%2B-512BD4?logo=dotnet&logoColor=white)

## 📖 About

| Task | Principle | Domain | Solution |
|------|-----------|--------|----------|
| 1 | **SRP** | Utility billing | A God Object split into validator, tariff, subsidy, formatter, registry, SMS notifier and an orchestrator |
| 2 | **OCP** | Loan interest rates | `switch` replaced with the Strategy pattern; a new product is added without changing the calculator |
| 3 | **LSP** | Data repositories | The hierarchy is split into read and write role interfaces, so no subclass throws `NotSupportedException` |
| 4 | **ISP** | RPG characters | A fat `IGameCharacter` split into `IMovable`, `ISpellCaster`, `IHealer`, `ITrader` |
| 5 | **DIP** | Course registration | Abstractions, constructor injection, manual Composition Root, swappable implementations |
| 6 | DRY / KISS / YAGNI | All | See [ANALYSIS.md](ANALYSIS.md) |

## 🛠 Tech stack

- **C#** and **.NET**
- **Patterns:** Strategy, Dependency Injection (manual), Composition Root
- **Practices:** SOLID, DRY, KISS, YAGNI, guard clauses, pattern matching
- **Git / GitHub:** feature branches and pull requests with cross-review

## 👥 Authors

- **_Katyonka_**: [@kskrasssss](https://github.com/kskrasssss): tasks 1-3
- **_Stasik_**: [@Getis8](https://github.com/Getis8): tasks 4-5
- Task 6 and cross-review: both

## ⬇️ Download

```bash
git clone https://github.com/kskrasssss/csharp-lab7-SOLID.git
cd csharp-lab7-SOLID
```

## ▶️ Run

1. Install the [.NET SDK](https://dotnet.microsoft.com/download).
2. From the project root run:
   ```bash
   dotnet build
   dotnet run
   ```
3. Enter a number from the menu (`1`-`5`) to run a task demo. Console text is in Ukrainian.

## 📁 Structure

```text
├── Program.cs     # menu
├── Task1/         # SRP
├── Task2/         # OCP
├── Task3/         # LSP
├── Task4/         # ISP
├── Task5/         # DIP
└── ANALYSIS.md    # DRY, KISS, YAGNI, cross-review
```

## 📝 License

Created for educational purposes. Feel free to use it.