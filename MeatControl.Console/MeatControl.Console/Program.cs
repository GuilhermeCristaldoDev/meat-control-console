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
                    Environment.Exit(0);
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

            _meatService.AddMeat(type, price);

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

        int id;
        bool validId;

        do
        {
            string input = SendMessageAndGetValue("\nEnter with the meat ID to be edited: ");

            validId = int.TryParse(input, out id);

            if (!validId)
                Console.WriteLine("\nInvalid id!");
        }
        while (!validId);

        try
        {
            Meat meat = _meatService.GetMeatById(id);

            string newType = SendMessageAndGetValue("New meat type: ");

            double newPrice;
            bool validPrice;

            do
            {
                string input = SendMessageAndGetValue("New meat price: ");
                validPrice = double.TryParse(input, CultureInfo.InvariantCulture, out newPrice);
            }
            while (!validPrice);

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

    static string SendMessageAndGetValue(string message)
    {
        Console.Write(message);
        string input = Console.ReadLine();

        return input;
    }

    public static void WriteAllMeats(List<Meat> meats)
    {
        foreach (Meat meat in meats)
        {
            Console.WriteLine($"{meat.Id} - {meat.Cut} : {meat.Price.ToString("F2", CultureInfo.InvariantCulture)}");
        }
    }

}