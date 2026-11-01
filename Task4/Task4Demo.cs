namespace Lab_7;

public static class Task4Demo
{
    public static void Run()
    {
        var mage = new MageCharacter();
        var vendor = new NpcVendor();

        new MovementSystem().MoveAll(new IMovable[] { mage, vendor }, 10, 20);

        var combat = new CombatSystem();
        combat.Fight(mage, "Fireball", 30);
        combat.Support(mage, 50);

        new ShopSystem().OpenShop(vendor, 7);

        // combat.Fight(vendor, ...) не скомпілюється: NpcVendor не ISpellCaster.
    }
}