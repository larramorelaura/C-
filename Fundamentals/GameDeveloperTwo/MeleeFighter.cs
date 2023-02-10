
public class MeleeFighter : Enemy
{
    public List<Attack> MeleeAttacks;
    public MeleeFighter(string name, List<Attack> meleeAttacks, int health =120) : base(name, meleeAttacks, health)
    {
        MeleeAttacks=meleeAttacks;
    }   

    public void Rage(Enemy Target, Attack ChosenAttack)
    {
        ChosenAttack.DamageAmount+=10;
        base.PerformAttack(Target, ChosenAttack);
    }
}