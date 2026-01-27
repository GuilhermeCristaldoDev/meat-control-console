using MeatControl.Console;
using System.Globalization;

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
            Console.WriteLine("Adding meat...");
            AddMeat(filePath);
            break;
        case '2':
            Console.WriteLine("Removing meat...");
            break;
        case '3':
            Console.WriteLine("Listing all meats...");
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

    Meat meat = new(getMeatId(filePath), type, price);

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

static int getMeatId(string file)
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

