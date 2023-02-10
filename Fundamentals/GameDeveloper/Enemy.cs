public class Enemy
{
    public string Name;

    private int Health;

    public int _Health
    {
        // GET the data from the original Health and return it
        get { return Health; }
    }
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
        Console.WriteLine($"{Name} performs {attack.Name}");
    }
}