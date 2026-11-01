using Lab_7;

Console.OutputEncoding = System.Text.Encoding.UTF8;

while (true)
{
    Console.WriteLine("\n=== Лабораторна робота №7 (варіант 8, SOLID) ===");
    Console.WriteLine("1 - SRP: рахунок за комунальні послуги");
    Console.WriteLine("2 - OCP: ставка за кредитом");
    Console.WriteLine("3 - LSP: репозиторії");
    Console.WriteLine("4 - ISP: ігрові персонажі");
    Console.WriteLine("5 - DIP: реєстрація на курс");
    Console.WriteLine("0 - Вихід");
    Console.Write("Ваш вибір: ");

    switch (Console.ReadLine())
    {
        case "3": Task3Demo.Run(); break;
        case "2": Task2Demo.Run(); break;
        case "1": Task1Demo.Run(); break;
        case "0": return;
        default: Console.WriteLine("Невірний вибір"); break;
        
        
        
        case "4": Task4Demo.Run(); break;
        case "5": Task5Demo.Run(); break;
    }
}