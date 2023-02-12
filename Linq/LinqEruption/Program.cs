List<Eruption> eruptions = new List<Eruption>()
{
    new Eruption("La Palma", 2021, "Canary Is", 2426, "Stratovolcano"),
    new Eruption("Villarrica", 1963, "Chile", 2847, "Stratovolcano"),
    new Eruption("Chaiten", 2008, "Chile", 1122, "Caldera"),
    new Eruption("Kilauea", 2018, "Hawaiian Is", 1122, "Shield Volcano"),
    new Eruption("Hekla", 1206, "Iceland", 1490, "Stratovolcano"),
    new Eruption("Taupo", 1910, "New Zealand", 760, "Caldera"),
    new Eruption("Lengai, Ol Doinyo", 1927, "Tanzania", 2962, "Stratovolcano"),
    new Eruption("Santorini", 46, "Greece", 367, "Shield Volcano"),
    new Eruption("Katla", 950, "Iceland", 1490, "Subglacial Volcano"),
    new Eruption("Aira", 766, "Japan", 1117, "Stratovolcano"),
    new Eruption("Ceboruco", 930, "Mexico", 2280, "Stratovolcano"),
    new Eruption("Etna", 1329, "Italy", 3320, "Stratovolcano"),
    new Eruption("Bardarbunga", 1477, "Iceland", 2000, "Stratovolcano")
};
// Example Query - Prints all Stratovolcano eruptions
IEnumerable<Eruption> stratovolcanoEruptions = eruptions.Where(c => c.Type == "Stratovolcano");
PrintEach(stratovolcanoEruptions, "Stratovolcano eruptions.");
// Execute Assignment Tasks here!
 
// Helper method to print each item in a List or IEnumerable. This should remain at the bottom of your class!
static void PrintEach(IEnumerable<Eruption> items, string msg = "")
{
    Console.WriteLine("\n" + msg);
    foreach (Eruption item in items)
    {
        Console.WriteLine(item.ToString());
    }
}

IEnumerable<Eruption> inChile = eruptions.Where(e=> e.Location=="Chile");
PrintEach(inChile, "in Chile.");

IEnumerable<Eruption> firstHawaiian = eruptions.Where(e => e.Location=="Hawaiian Is").Take(1);
if(firstHawaiian.Count()>0)
{
    PrintEach(firstHawaiian, "first hawaiian."); 
}
else
{
    Console.WriteLine("No Hawaiian Is eruptions found.");
};


IEnumerable<Eruption> firstGreenland = eruptions.Where(e => e.Location=="Greenland").Take(1);
if(firstGreenland.Count()>0){
PrintEach(firstGreenland, "First in Greenland.");
}
else
{
    Console.WriteLine("No Greenland Eruption found.");
};

IEnumerable<Eruption> after1900NZ = eruptions.Where(e => e.Location=="New Zealand" && e.Year>1900).Take(1);
PrintEach(after1900NZ, "Eruption after 1900 in NZ.");

IEnumerable<Eruption> Over2000 = eruptions.Where(e => e.ElevationInMeters>2000);
PrintEach(Over2000, "Elevation over 2000m.");

IEnumerable<Eruption> NamesL = eruptions.Where(e => e.Volcano.StartsWith("L"));
PrintEach(NamesL, "Volcanoes that start with L.");

int Highest= eruptions.Max(e=> e.ElevationInMeters);
Console.WriteLine(Highest);

IEnumerable<Eruption> HighestVolcano = eruptions.Where(e=> e.ElevationInMeters==Highest);
PrintEach(HighestVolcano, "Highest eruption.");

IEnumerable<Eruption> AllEruptions= eruptions.OrderBy(e=> e.Volcano);
PrintEach(AllEruptions, "alpha order.");

int TotalElevations= eruptions.Sum(e=>e.ElevationInMeters);
Console.WriteLine(TotalElevations);

Console.WriteLine(eruptions.Any(e=>e.Year==2000));

IEnumerable<Eruption> stratovolcanoEruptionsFirstThree = eruptions.Where(c => c.Type == "Stratovolcano").Take(3);
PrintEach(stratovolcanoEruptionsFirstThree, "Stratovolcano eruptions, first three.");

List<string> Before1000 = eruptions.OrderBy(e=>e.Volcano).Where(e => e.Year<1000).Select(e=>e.Volcano).ToList();
Console.WriteLine("Volcanos before 1000bce");
foreach(string item in Before1000)
{
    Console.WriteLine(item);
}



