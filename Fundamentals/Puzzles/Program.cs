
static string FlipACoin()
{
    string result="";
    Random rand= new Random();
    int coinFlip= rand.Next(0,2);
    if (coinFlip==1)
    {
        result= "heads";
    }
    else
    {
        result= "tails";
    }
    return result;
}

Console.WriteLine(FlipACoin());

static int DiceRoll(int size=6)
{
    Random rand= new Random();
    int roll= rand.Next(1,size+1);
    return roll;
}
Console.WriteLine(DiceRoll());

static int[] StatRoll()
{
    int[] rolls = new int[3];
    int i=0;
    while(i<3)
    {
        rolls[i] = DiceRoll();
    i++;
    }
    foreach(int roll in rolls)
    {
        Console.WriteLine(roll);
    }
    return rolls;
}

Console.WriteLine(StatRoll());

static int RollUntil(int Number)
{
    int roll=DiceRoll();
    int count=1;
    while(roll!=Number)
    {
        roll=DiceRoll();
        count++;
    }
    return count;
}

Console.WriteLine(RollUntil(5));


