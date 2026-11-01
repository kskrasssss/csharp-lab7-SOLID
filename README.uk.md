🇬🇧 [English](README.md) | 🇺🇦 **Українська**

# 🧱 Lab7: Рефакторинг за принципами SOLID

Консольний проєкт на **C# / .NET**: п'ять фрагментів «поганого» коду, кожен із яких порушує окремий принцип SOLID, зарефакторено, а рішення за DRY, KISS і YAGNI задокументовано.

![C#](https://img.shields.io/badge/C%23-12-239120?logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-8.0%2B-512BD4?logo=dotnet&logoColor=white)

## 📖 Про проєкт

| Завдання | Принцип | Домен | Рішення |
|----------|---------|-------|---------|
| 1 | **SRP** | Комунальні рахунки | God Object розділено на валідатор, тариф, субсидію, форматер, реєстр, SMS і оркестратор |
| 2 | **OCP** | Ставки за кредитами | `switch` замінено патерном Strategy, новий продукт додається без зміни калькулятора |
| 3 | **LSP** | Репозиторії даних | Ієрархію розділено на ролі читання й запису, жоден нащадок не кидає `NotSupportedException` |
| 4 | **ISP** | RPG-персонажі | «Жирний» `IGameCharacter` розбито на `IMovable`, `ISpellCaster`, `IHealer`, `ITrader` |
| 5 | **DIP** | Реєстрація на курс | Абстракції, Constructor Injection, ручний Composition Root, підміна реалізацій |
| 6 | DRY / KISS / YAGNI | Усі | Див. [ANALYSIS.md](ANALYSIS.md) |

## 🛠 Технології

- **C#** та **.NET**
- **Патерни:** Strategy, Dependency Injection (ручний), Composition Root
- **Практики:** SOLID, DRY, KISS, YAGNI, guard clauses, pattern matching
- **Git / GitHub:** гілки та pull request із крос-рев'ю

## 👥 Автори

- **_Катьонка_**: [@kskrasssss](https://github.com/kskrasssss): завдання 1-3
- **_Стасік_**: [@Getis8](https://github.com/Getis8): завдання 4-5
- Завдання 6 та крос-рев'ю: обоє

## ⬇️ Як завантажити

```bash
git clone https://github.com/kskrasssss/csharp-lab7-SOLID.git
cd csharp-lab7-SOLID
```

## ▶️ Як запустити

1. Встанови [.NET SDK](https://dotnet.microsoft.com/download).
2. З кореня проєкту виконай:
   ```bash
   dotnet build
   dotnet run
   ```
3. Введи номер із меню (`1`-`5`), щоб запустити демо завдання.

## 📁 Структура

```text
├── Program.cs     # меню
├── Task1/         # SRP
├── Task2/         # OCP
├── Task3/         # LSP
├── Task4/         # ISP
├── Task5/         # DIP
└── ANALYSIS.md    # DRY, KISS, YAGNI, крос-рев'ю
```

## 📝 Ліцензія

Проєкт створено в навчальних цілях. Використовуй вільно.