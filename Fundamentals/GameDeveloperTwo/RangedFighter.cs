public class RangedFighter : Enemy
{
    public List<Attack> RangedAttacks;
    public int Distance;
    public RangedFighter(string name, List<Attack> rangedAttacks, int health =120, int distance=5) : base(name, rangedAttacks, health)
    {
        RangedAttacks=rangedAttacks;
        Distance=distance;
    }   
    public void Dash(RangedFighter Self)
    {   
        Self.Distance+=20;
        Console.WriteLine($"{Self.Name} is now {Self.Distance} away from the enemy");
    }
}