using MeatControlConsole.Entities;
using MeatControlConsole.Repositories;
using MeatControlConsole.Services;
using MeatControlConsole.Utils;
using System.Globalization;

internal class Program
{
    private readonly MeatService _meatService;

    public Program(MeatService meatService)
    {
        _meatService = meatService;
    }
    private static void Main(string[] args)

    {
        string filePath = "C:\\Users\\Guilherme\\Documents\\churrascaria\\carnes.txt";

        IMeatRepository repository = new MeatRepository(filePath);
        MeatService meatService = new(repository);

        var program = new Program(meatService);
        program.Run();

    }

    public void Run()
    {
        char option;

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
                    AddMeatUI();
                    PressKeyMessage();
                    break;
                case '2':
                    RemoveMeatUI();
                    PressKeyMessage();
                    break;
                case '3':
                    ListAllMeatsUI();
                    PressKeyMessage();
                    break;
                case '4':
                    EditMeatUI();
                    PressKeyMessage();
                    break;
                case '0':
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    PressKeyMessage();
                    break;
            }
        }
        while (option != '0');
    }

    public void AddMeatUI()
    {
        bool continueOption;

        do
        {
            Console.Clear();

            string type = ConsoleReader.ReadValue<string>("Type of meat: ");
            double price = ConsoleReader.ReadValue<double>("Price: ");

            try
            {
                _meatService.AddMeat(type, price);

                Console.WriteLine("\nMeat added sucessfully!");
            }
            catch (DomainException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            ConsoleKeyInfo key;

            do
            {
                Console.Write("\nAdd more one meat (y/n)? ");
                key = Console.ReadKey(true);

                if (key.KeyChar != 'y' && key.KeyChar != 'n') Console.WriteLine("\nInvalid key!");
            }
            while (key.KeyChar != 'y' && key.KeyChar != 'n');

            continueOption = key.KeyChar == 'y';

        }
        while (continueOption);
    }

    void RemoveMeatUI()
    {
        Console.Clear();

        List<Meat> meats = _meatService.GetAllMeats();

        WriteAllMeats(meats);

        int id = ConsoleReader.ReadValue<int>("Enter with ID to be deleted: ");

        _meatService.RemoveMeat(id);

        Console.WriteLine("\nMeat deleted!");

    }

    void ListAllMeatsUI()
    {
        Console.Clear();

        List<Meat> meats = _meatService.GetAllMeats();

        WriteAllMeats(meats);
    }

    void EditMeatUI()
    {
        Console.Clear();

        List<Meat> meats = _meatService.GetAllMeats();

        WriteAllMeats(meats);

        int id = ConsoleReader.ReadValue<int>("Enter with the meat ID to be edited: ");

        try
        {
            Meat meat = _meatService.GetMeatById(id);

            string newType = ConsoleReader.ReadValue<string>("New meat type: ");

            double newPrice = ConsoleReader.ReadValue<double>("New meat price: ");

            _meatService.EditMeat(id, newType, newPrice);

            Console.WriteLine("\nItem was edited!");
        }
        catch (NotFoundExeption ex)
        {
            Console.WriteLine(ex.Message);
        }

    }

    static void PressKeyMessage()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey(true);
        Console.Clear();
    }
    public static void WriteAllMeats(List<Meat> meats)
    {
        foreach (Meat meat in meats)
        {
            Console.WriteLine($"{meat.Id} - {meat.Cut} : {meat.Price.ToString("F2", CultureInfo.InvariantCulture)}");
        }
    }

}