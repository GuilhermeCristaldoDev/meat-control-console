
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
}
while (option != '0');

