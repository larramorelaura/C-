static void PrintList(List<string> MyList)
{
    foreach (string item in MyList)
    {
        Console.WriteLine(item);
    }
}
List<string> TestStringList = new List<string>() {"Harry", "Steve", "Carla", "Jeanne"};
PrintList(TestStringList);

static void SumOfNumbers(List<int> IntList)
{
    int sum=0;
    foreach (int num in IntList)
    {
        sum+=num;
    }
    Console.WriteLine(sum);
}
List<int> TestIntList = new List<int>() {2,7,12,9,3};
// You should get back 33 in this example
SumOfNumbers(TestIntList);

static int FindMax(List<int> IntList)
{
    int max=IntList[0];
    foreach (int num in IntList)
    {
        if(num>max){
            max=num;
        }

    }
    Console.WriteLine(max);
    return max;
}
List<int> TestIntList2 = new List<int>() {-9,12,10,3,17,5};
// You should get back 17 in this example
FindMax(TestIntList2);

static List<int> SquareValues(List<int> IntList)
    {
        for (int idx = 0; idx<IntList.Count; idx++)
        {
            IntList[idx]*=IntList[idx];
        }
        foreach( int num in IntList){
            Console.WriteLine(num);
        }
        return IntList;
    }
List<int> TestIntList3 = new List<int>() {1,2,3,4,5};
// You should get back [1,4,9,16,25], think about how you will show that this worked
SquareValues(TestIntList3);

static int[] NonNegatives(int[] IntArray)
{
    for(int idx=0; idx<IntArray.Length; idx++)
    {
        if (IntArray[idx]<0)
        {
            IntArray[idx]=0;
        }
    }
    foreach (int num in IntArray)
    {
        Console.WriteLine(num);
    }
    return IntArray;
}
int[] TestIntArray = new int[] {-1,2,3,-4,5};
// You should get back [0,2,3,0,5], think about how you will show that this worked
NonNegatives(TestIntArray);

static void PrintDictionary(Dictionary<string,string> MyDictionary)
{
    foreach (KeyValuePair<string,string> entry in MyDictionary)
    {
        Console.WriteLine(entry);
    }
}
Dictionary<string,string> TestDict = new Dictionary<string,string>();
TestDict.Add("HeroName", "Iron Man");
TestDict.Add("RealName", "Tony Stark");
TestDict.Add("Powers", "Money and intelligence");
PrintDictionary(TestDict);

static bool FindKey(Dictionary<string,string> MyDictionary, string SearchTerm)
{
    bool isThere=false;
    foreach(KeyValuePair<string,string> entry in MyDictionary)
    {
        if (entry.Key == SearchTerm)
        {
            isThere= true;
        }
    }
    return isThere;
}
// Use the TestDict from the earlier example or make your own
// This should print true
Console.WriteLine(FindKey(TestDict, "RealName"));
// This should print false
Console.WriteLine(FindKey(TestDict, "Name"));

// Ex: Given ["Julie", "Harold", "James", "Monica"] and [6,12,7,10], return a dictionary
// {
//	"Julie": 6,
//	"Harold": 12,
//	"James": 7,
//	"Monica": 10
// } 
static Dictionary<string,int> GenerateDictionary(List<string> Names, List<int> Numbers)
{
    Dictionary<string,int> myDictionary= new Dictionary<string,int>();
    for (int i=0; i<Names.Count; i++)
    {
        myDictionary.Add(Names[i], Numbers[i]);
    }
    foreach(KeyValuePair<string,int> entry in myDictionary)
    {
        Console.WriteLine(entry);
    }
    return myDictionary;
}
// We've shown several examples of how to set your tests up properly, it's your turn to set it up!
// Your test code here
List<string> TestNames = new List<string>() {"Julie", "Harold", "James", "Monica"};
List<int> TestNumbers= new List<int>() {6, 12, 7, 10};
GenerateDictionary(TestNames, TestNumbers);


