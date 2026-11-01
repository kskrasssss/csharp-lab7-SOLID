#nullable disable

namespace Lab_7.Legacy.Task4;

public interface IGameCharacter
{
    void Move(int x, int y);
    void CastSpell(string spellName, int manaCost);
    void CastHeal(int hpAmount);
    void CraftItem(string recipe);
    void TradeWithNpc(int npcId);
}

public class MageCharacter : IGameCharacter
{
    public void Move(int x, int y) => Console.WriteLine($"Mage moved to ({x}, {y}).");
    public void CastSpell(string spellName, int manaCost) => Console.WriteLine($"Mage cast spell {spellName}.");
    public void CastHeal(int hpAmount) => Console.WriteLine($"Mage restored {hpAmount} HP.");

    public void CraftItem(string recipe) => throw new NotImplementedException("Mage cannot craft physical items.");
    public void TradeWithNpc(int npcId) => throw new NotImplementedException("Mage is in battle mode.");
}

public class NpcVendor : IGameCharacter
{
    public void Move(int x, int y) => Console.WriteLine($"Vendor walked to shop stall at ({x}, {y}).");
    public void TradeWithNpc(int npcId) => Console.WriteLine("Vendor opened shop inventory for player.");

    public void CastSpell(string spellName, int manaCost) => throw new NotImplementedException("Vendor NPC cannot cast spells.");
    public void CastHeal(int hpAmount) => throw new NotImplementedException("Vendor NPC cannot heal entities.");
    public void CraftItem(string recipe) => throw new NotImplementedException("Vendor NPC does not craft items on demand.");
}