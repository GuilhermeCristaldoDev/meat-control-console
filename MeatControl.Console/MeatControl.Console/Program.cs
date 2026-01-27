using MeatControl.Console;
using System.Globalization;
using System.Transactions;

char option;
string filePath = "C:\\Users\\Guilherme\\Documents\\churrascaria\\carnes.txt";

do
{   
    Console.WriteLine("1 - Add meat");
    Console.WriteLine("2 - Remove meat");
    Console.WriteLine("3 - List all meats");
    Console.WriteLine("4 - Edit meat");
    Console.WriteLine("0 - Exit");

    ConsoleKeyInfo key = Console.ReadKey(true);
    option = key.KeyChar;

    switch (option)
    {
        case '1':
            AddMeat(filePath);
            break;
        case '2':
            Console.WriteLine("Removing meat...");
            break;
        case '3':
            ListAllMeats(filePath);
            break;
        case '4':
            Console.WriteLine("Editing meat...");
            break;
        case '0':
            Console.WriteLine("Exiting...");
            break;
        default:
            Console.WriteLine("Invalid option!");
            break;
    }
}
while (option != '0');

static void AddMeat(string filePath)
{
    Console.Clear();

    Console.Write("Type of meat: ");
    string type = Console.ReadLine();
    Console.Write("Price: ");
    double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

    Meat meat = new(GetMeatId(filePath), type, price);

    File.AppendAllText(filePath, meat.ToString() + "\n");

    char continueOption;

    Console.Write("\nAdd more one meat (y/n)? ");

    do
    {
        ConsoleKeyInfo key = Console.ReadKey(true);
        continueOption = key.KeyChar;
    }
    while (continueOption != 'y' && continueOption != 'n');

    if (continueOption == 'y')
    {
        AddMeat(filePath);
    }

    Console.Clear();
}

static int GetMeatId(string file)
{
    int lastId;

    string[] fileLines = File.ReadAllLines(file);

    if (fileLines.Length == 0)
    {
        lastId = 1;
        return lastId;
    }
    string[] lastLine = fileLines[fileLines.Length - 1].Split(';');

    lastId = int.Parse(lastLine[0]);

    lastId += 1;
    return lastId;
}

static void ListAllMeats(string file)
{
    Console.Clear();

    string[] fileLines = File.ReadAllLines(file);

    Console.WriteLine("List of meats: ");

    foreach (string line in fileLines)
    {
        Console.WriteLine(line);
    }

    Console.WriteLine();
}

