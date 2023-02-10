public class Enemy
{
    public string Name;

    public int Health;

    // public int _Health
    // {
    //     // GET the data from the original Health and return it
    //     get { return Health; }
    // }
    public List<Attack> AttackList;

    public Enemy(string n, List<Attack> attacks, int h=100)
    {
        Name=n;
        Health=h;
        AttackList=attacks;
    }
    public void RandomAttack()
    {
        Random rand= new Random();
        Attack attack = (AttackList[rand.Next(0,3)]);
        Console.WriteLine($"{Name} preforms {attack.Name}");
    }

    public void PerformAttack(Enemy Target, Attack ChosenAttack)
    {
        
        Target.Health-=ChosenAttack.DamageAmount;
        Console.WriteLine($"{Name} attacks {Target.Name}, dealing {ChosenAttack.DamageAmount} damage and reducing {Target.Name}'s health to {Target.Health}!!");
        
    }
}