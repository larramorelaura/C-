public class MagicCaster : Enemy
{
    public List<Attack> MagicAttacks;
    
    public MagicCaster(string name, List<Attack> magicAttacks, int health =80) : base(name, magicAttacks, health)
    {
        MagicAttacks=magicAttacks;
        
    }   
    public void Heal(Enemy Target)
    {
        Target.Health+=40;
        Console.WriteLine($"{Target.Name}'s health increased to {Target.Health}");
    }
}