//DETTA ÄR EN ITEMBASKET KONSOLLAPP SOM man kan lägga till items och sedan printa ut allt man lagt in. Man kan även ta bort. Duplicates tas bort direkt.


//Skapar en ny lista för frukterna
List<string> recipe = new();

//Kallar på metoden Main för att starta programmet
Main();
void Main()
{

    Console.Clear();
    //kollar om man har någonting i sin basket.
    if (recipe.Count() == 0)
    {
        Console.WriteLine("you have nothing in you basket..");

    }
    else // Här skriver jag ut antalet frukter som finns i basket och loopar igenom dom.
    {
        Console.WriteLine($"you have {recipe.Count()} item(s) in your basket");

        foreach (var item in recipe)
        {
            Console.WriteLine(item);
        }
    }
    // början av programmet, vad vill man lägga till?
    Console.WriteLine("Type done if you are satisfied");
    Console.Write("what fruit do you want to add? : ");
    string? input = Console.ReadLine();

    // kör metoden och skickar med variabeln
    ValidatesAndRun(input);

}

//Denna metoden tar in vad användaren skrev in och kallar på olika metoder beroende på vad man skrev in.
void ValidatesAndRun(string input)
{
    if (input.ToUpper() == "DONE")
    {
        PrintBasket();
    }
    else if (checkForRemove(input)) //Kallar på checkForRemove metoden som returnerar true eller false när man tagit bort en frukt
    {
        Main();

    }
    else if (recipe.Contains(input)) //Finns frukten redan i recipe så tas det bort
    {
        Console.WriteLine("that ingredient has already been added!");
        Console.WriteLine($"removing {input} from basket...");
        Console.ReadKey(true);
        // TO-DO 
        // IMPLEMENT TIMER BEFORE REMOVING INPUT AND CALLING MAIN
        //recipe.Remove(input);
        Main();
    }

    else if (string.IsNullOrWhiteSpace(input)) // Kollar om har inte skrivit in någonting
    {
        Console.WriteLine("you need to type in something...");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
        Main();
    }
    else // lägger till den frukten i listan.
    {
        Add(input);
    }
}

//Adderar ett item till Listan
void Add(string item)
{
    recipe.Add(item);
    Main();
}

//Skriver ut hela korgen när man har har skrivit Done
void PrintBasket()
{
    Console.Clear();
    Console.WriteLine("You bought this");
    foreach (string fruit in recipe)
    {
        Console.WriteLine(fruit);
    }
    Console.WriteLine($"you Bought {recipe.Count()} item(s) for {recipe.Count() * 2}$ and {recipe.Count() * 1.5}cents");
}


//Denna metoden kollar om man skriver remove, därefter kallar jag på en ny metod "RemoveFruit" som tar bort själva frukten och returnerar true när den är klar.

//Sidenote - denna metod kan man nog ta bort för att göra koden bättre
bool checkForRemove(string args)
{

    if (args.ToUpper() == "REMOVE")
    {
        return RemoveFruit();
    }
    else
    {
        return false;
    }
}
//Tar bort frukten som man skriver in
bool RemoveFruit()
{
    Console.WriteLine("Which fruit do you want to remove?");
    Console.Write(":");
    string? temp = Console.ReadLine();
    // Kollar om det man skrev in finns i recipe korgen, annars skriver den ut error meddelande, visar vad man skrev och kallar på removefruit igen.
    if (recipe.Contains(temp))
    {
        recipe.Remove(temp);
        return true;
    }
    else
    {
        Console.WriteLine("invalid fruit type, maybe you misspelled.");
        Console.WriteLine($"user Typed in: {temp}");
        RemoveFruit();
        return false;
    }

}