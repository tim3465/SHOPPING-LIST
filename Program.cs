using System.Linq;

Dictionary<string, decimal> groceries = new Dictionary<string, decimal>()
{
{"honeydew", 3.49m},
{"dragonfruit", 2.19m},
{"figs", 2.09m},
{"grapefruit", 1.99m},
{"Elderberry", 1.79m},
{"cauliflower", 1.59m},
{ "apple", 0.99m },
{ "banana", 0.59m},
    };

List<string> shopingList = new List<string>();
bool menuRun = true;
while (menuRun)
{
    //Displays all the items available in the market 
    Console.Clear();
    Console.WriteLine("Welcome to Chirpus Market!");
    Console.WriteLine("#.Item".PadRight(30) + "$Price".PadLeft(9));
    Console.WriteLine("=======================================");
    int cont = 1; 
    //Iterates through the dictionary to display items 
    foreach (KeyValuePair<string, decimal> kvp in groceries)
    {
        Console.WriteLine(cont + "." + kvp.Key.PadRight(30) + $"{kvp.Value:c}".PadLeft(7));
        cont++;
    }
    bool addItemRun = true;

     //gets user input for what items to add to cart at the end of this while loop
     //option is given to select another item via y/n
    while (addItemRun)
    {
        Console.Write("\nWhat item would you like to order?(by # or by NAME):");
        // will keep menu  
        string entry = Console.ReadLine().ToLower().Trim();
        int number;
        //This series of if/else if statements determines
        //whether to select the item by name or number 
        if (int.TryParse(entry, out number))
        {
            //This one is by item number 
            cont = 1;
            foreach (KeyValuePair<string, decimal> kvp in groceries)
            {
                if (cont == number)
                {
                    Console.WriteLine($"Adding {entry}.{kvp.Key} to cart at {kvp.Value:c}");
                    shopingList.Add(kvp.Key);
                    addItemRun=false;
                    break;
                }
                cont++;

            }
        }
        else if (groceries.ContainsKey(entry))
        {
            //This one is by item name  
            Console.WriteLine($"Adding {entry} to cart at {groceries[entry]:c}");
            shopingList.Add(entry);
            addItemRun = false;
            break;
        }
        else
        {
            Console.WriteLine("\nSorry, we don't have those.  Please try again.\n");
        }
    }
    //The while statement checks for user entry for y/n
    //If 'n' is selected then it will break the main loop 
    while (true)
    {
        Console.Write("Would you like to add more to the list y/n: ");
        string entry = Console.ReadLine().ToLower().Trim();
        if (entry == "y" || entry == "n")
        {
            if (entry == "n")
            {
                menuRun = false;
                break;
            }
            else
            {
                break;
            }
        }
        else
        {
            Console.WriteLine("Invalid entry ");
        }
    }
}

//Display receipt 
Console.Clear();
Console.WriteLine("Thanks for your order!\n");
Console.WriteLine("Here's what you got:\n");
Console.WriteLine("#.Item".PadRight(30) + "$Price".PadLeft(7));
Console.WriteLine("=======================================");

//This line translates the shopping list into order list
//with the most expensive items first and the cheapest items last.
List<string> ordedList = shopingList.OrderByDescending(a => groceries[a]).ToList();
//Displays all the items in the shopping cart and totals them.
decimal totle = 0;
foreach (string item in ordedList)
{
    Console.WriteLine(item.PadRight(30) + $"{groceries[item]:c}".PadLeft(7));
    totle += groceries[item];
}
Console.WriteLine("---------------------------------------");
Console.WriteLine("Total".PadRight(30) + $"{totle:c}".PadLeft(7));
Console.WriteLine($"\nAverage price/item".PadRight(30) + $"{totle / (ordedList.Count):c}".PadLeft(8));
Console.WriteLine($"Most expensive {ordedList[0]}".PadRight(30) +  $"{groceries[ordedList[0]]:c}".PadLeft(7));
Console.WriteLine($"Cheapest {ordedList[ordedList.Count - 1]}".PadRight(30) + $"{groceries[ordedList[ordedList.Count - 1]]:c}".PadLeft(7));






