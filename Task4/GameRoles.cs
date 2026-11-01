namespace Lab_7;

public interface IMovable
{
    void Move(int x, int y);
}

public interface ISpellCaster
{
    void CastSpell(string spellName, int manaCost);
}

public interface IHealer
{
    void CastHeal(int hpAmount);
}

public interface ITrader
{
    void TradeWithNpc(int npcId);
}