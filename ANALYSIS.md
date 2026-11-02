# Завдання 6. Прагматичний аналіз (варіант 8)

## DRY
- **Тарифи** (`TariffCalculator`): ціни 2.64 і 4.32 та ліміт 100 кВт лежать в одному місці як константи, раніше були «магічними числами» всередині методу.
- **Валідація** (`MeterReadingValidator`): ліміт 5000 кВт зведено в константу `MaxConsumptionKwh`.
- **Формат ставки в `LoanInterestCalculator`**: логування ставки стоїть в одному місці після вибору стратегії, а не повторюється в кожному `case`.

## KISS
- Вкладені `if/else` розрахунку тарифу та валідації замінено на **guard clauses** з раннім виходом (`TariffCalculator`, `SubsidyCalculator`, `MeterReadingValidator`).
- У `MortgageRateStrategy` вкладені `if/else if` замінено на **pattern matching** (`switch` вираз з `> 750`, `< 650`).
- Цикломатична складність найбільшого методу знизилась з ≈11 до ≤4.

## YAGNI
- Інтерфейс `ICrafter` **не створено**, бо жоден клас його не реалізує.
- Абстракції створено лише там, де є щонайменше дві реалізації або потреба в підміні: `ILoanRateStrategy` (4+ реалізацій), `IWriteRepository`/`IReadRepository` (різні клієнти), ролі персонажів (різні набори можливостей),
- DI-контейнер не підключали: Manual DI у Composition Root достатньо.

## Крос-рев'ю
| Pull request | Автор | Рев'юер | Знайдені зауваження |
|---|---|---|---|
| feature/a-srp-ocp-lsp | Стасік | Катьонка | [коментар](https://github.com/kskrasssss/csharp-lab7-SOLID/pull/2#issuecomment-6563118019) |
    | feature/b-isp-dip | Катьонка | [коментар](https://github.com/kskrasssss/csharp-lab7-SOLID/pull/1#issuecomment-6563105137) |