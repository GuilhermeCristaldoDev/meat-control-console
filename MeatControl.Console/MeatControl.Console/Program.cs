using MeatControl.Console;
using System.Data;
using System.Globalization;

char option;

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
            AddMeat();
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
        default:
            Console.WriteLine("Invalid option!");
            break;
    }
}
while (option != '0');

static void AddMeat()
{
    Console.Clear();

    Console.Write("Type of meat: ");
    string type = Console.ReadLine();
    Console.Write("Price: ");
    double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

    Meat meat = new(type, price);

    //create file

    char option;

    Console.Write("\nAdd more one meat (y/n)? ");

    do
    {
        ConsoleKeyInfo key = Console.ReadKey(true);
        option = key.KeyChar;
    }
    while (option != 'y' && option != 'n');

    if (option == 'y')
    {
        AddMeat();
    }

    Console.Clear();
}

