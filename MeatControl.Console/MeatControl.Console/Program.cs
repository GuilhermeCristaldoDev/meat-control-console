using MeatControl.Console;
using System.Data;
using System.Globalization;

char option;
string filePath = "C:\\Users\\Guilherme\\Documents\\churrascaria\\carnes.txt";

do
{
    Console.WriteLine("[1] - Add meat");
    Console.WriteLine("[2] - Remove meat");
    Console.WriteLine("[3] - List all meats");
    Console.WriteLine("[4] - Edit meat");
    Console.WriteLine("[0] - Exit");

    ConsoleKeyInfo key = Console.ReadKey(true);
    option = key.KeyChar;

    switch (option)
    {
        case '1':
            AddMeat(filePath);
            PressKeyMessage();
            break;
        case '2':
            RemoveMeat(filePath);
            PressKeyMessage();
            break;
        case '3':
            ListAllMeats(filePath);
            PressKeyMessage();
            break;
        case '4':
            Console.WriteLine("Editing meat...");
            PressKeyMessage();
            break;
        case '0':
            Console.WriteLine("Exiting...");
            break;
        default:
            Console.WriteLine("Invalid option!");
            PressKeyMessage();
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

    File.AppendAllText(filePath, meat.ToString() + Environment.NewLine);

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
}

static void RemoveMeat(string file)
{
    Console.Clear();

    ListAllMeats(file);

    Console.Write("\nEnter the meat ID to be deleted: ");
    int id = int.Parse(Console.ReadLine());

    string[] lines = File.ReadAllLines(file);

    bool idExists = false;
    string firstChar;

    foreach (string line in lines)
    {
        firstChar = line.Split(';')[0];

        if (int.Parse(firstChar) == id)
        {
            idExists = true;
        }
    }

    if (!idExists)
    {
        Console.Clear();
        Console.WriteLine("Id not exist!");
    }

    if (idExists)
    {
        File.WriteAllText(file, string.Empty);

        foreach (string line in lines)
        {
            firstChar = line.Split(';')[0];

            if (int.Parse(firstChar) != id)
            {
                File.AppendAllText(file, line + Environment.NewLine);
            }
        }

        Console.WriteLine("\nMeat deleted!");
    }

}

static void PressKeyMessage()
{
    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey(true);
    Console.Clear();
}
