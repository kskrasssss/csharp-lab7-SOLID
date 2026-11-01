namespace Lab_7;

public class MovementSystem
{
    public void MoveAll(IEnumerable<IMovable> units, int x, int y)
    {
        foreach (var unit in units) unit.Move(x, y);
    }
}

public class CombatSystem
{
    public void Fight(ISpellCaster caster, string spell, int mana) => caster.CastSpell(spell, mana);
    public void Support(IHealer healer, int hp) => healer.CastHeal(hp);
}

public class ShopSystem
{
    public void OpenShop(ITrader trader, int npcId) => trader.TradeWithNpc(npcId);
}