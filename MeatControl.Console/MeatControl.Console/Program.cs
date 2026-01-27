
char option;

do
{
    Console.WriteLine("1 - Add meat");
    Console.WriteLine("2 - Remove meat");
    Console.WriteLine("3 - List all meats");
    Console.WriteLine("4 - Edit meat");
    Console.WriteLine("0 - Exit");

    Console.Clear();

    ConsoleKeyInfo key = Console.ReadKey(true);
    option = key.KeyChar;

    switch (option)
    {
        case '1':
            Console.WriteLine("Adding meat...");
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

