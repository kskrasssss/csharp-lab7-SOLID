namespace Lab_7;

public class MageCharacter : IMovable, ISpellCaster, IHealer
{
    public void Move(int x, int y) => Console.WriteLine($"Mage moved to ({x}, {y}).");
    public void CastSpell(string spellName, int manaCost) => Console.WriteLine($"Mage cast spell {spellName}.");
    public void CastHeal(int hpAmount) => Console.WriteLine($"Mage restored {hpAmount} HP.");
}

public class NpcVendor : IMovable, ITrader
{
    public void Move(int x, int y) => Console.WriteLine($"Vendor walked to shop stall at ({x}, {y}).");
    public void TradeWithNpc(int npcId) => Console.WriteLine("Vendor opened shop inventory for player.");
}