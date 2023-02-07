// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World! this is an update");

//must declare variable type

int[] someNumbers;
someNumbers= new int[10] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

string[] someNames;
someNames= new string[4] {"Tim", "Martin", "Nikki", "Sara"};

bool[] someBools;
someBools= new bool[10];
for(int i=0; i<someBools.Length; i+=2){
    someBools[i]=true;
    if(someBools[i+1])
    {
    someBools[i+1]=false;
    }
}


List<string> flavors = new List<string>()
{
    "strawberry", "chocolate", "vanilla", "moose tracks", "butter pecan"
};
// Console.WriteLine(flavors.Count);
// Console.WriteLine(flavors[3]);

// flavors.RemoveAt(3); 
// Console.WriteLine(flavors.Count);



Dictionary<string,string> MakeDictionary()
{
    Dictionary<string,string> myDictionary = new Dictionary<string,string>();
    
    Random rand= new Random();
    foreach (string name in someNames)
        {
            myDictionary.Add(name, flavors[rand.Next(0, flavors.Count)]);
        }
        return myDictionary;
    };

Dictionary<string,string> orders=MakeDictionary();
foreach (KeyValuePair<string,string> order in orders)
{
    Console.WriteLine(order);
}




