using MeatControl.Console;
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
    bool continueOption;

    do
    {
        Console.Clear();

        Console.Write("Type of meat: ");
        string type = Console.ReadLine();


        double price;
        bool valid;
        do
        {
            Console.Write("Price: ");
            string input = Console.ReadLine();

            valid = double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out price);

            if (!valid)
                Console.WriteLine("Invalid price!");
        }
        while (!valid);

        Meat meat = new(GetMeatId(filePath), type, price);

        File.AppendAllText(filePath, meat.ToString() + Environment.NewLine);

        ConsoleKeyInfo key;

        do
        {
            Console.Write("\nAdd more one meat (y/n)? ");
            key = Console.ReadKey(true);

            if (key.KeyChar != 'y' && key.KeyChar != 'n') Console.WriteLine("\nInvalid key!");
        }
        while (key.KeyChar != 'y' && key.KeyChar != 'n');


        if (key.KeyChar == 'y')
        {
            continueOption = true;
        }
        else
        {
            continueOption = false;
        }
    }
    while (continueOption);
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

    int id;
    bool validId;

    do
    {
        Console.Write("\nEnter the meat ID to be deleted: ");
        string input = Console.ReadLine();

        validId = int.TryParse(input, CultureInfo.InvariantCulture, out id);
    }
    while (!validId);

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
