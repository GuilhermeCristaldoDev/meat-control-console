using MeatControl.Console.Entities;
using MeatControl.Console.Repositories;
using MeatControl.Console.Services;
using System.Globalization;

internal class Program
{
    private readonly MeatService _meatService;

    public Program (MeatService meatService)
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
                    ListAllMeats();
                    PressKeyMessage();
                    break;
                case '4':
                    EditMeat();
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

    void RemoveMeatUI( )
    {
        Console.Clear();

        List<Meat> meats = _meatService.GetAllMeats();

        foreach (Meat meat in meats)
        {
            Console.WriteLine($"${meat.Id} - {meat.Cut} : {meat.Price}");
        }

        int id;
        bool validId;

        do
        {
            string input = SendMessageAndGetValue("Enter with the meat ID to be deleted: ");
            validId = int.TryParse(input, CultureInfo.InvariantCulture, out id);
        }
        while (!validId);

        string[] lines = File.ReadAllLines(file);

        bool idExists = CheckIdExist(id, lines);

        if (!idExists)
        {
            Console.Clear();
            Console.WriteLine("Id not exist!");
            return;
        }

        RemoveLine(file, lines, id);
        Console.WriteLine("\nMeat deleted!");

    }

    void ListAllMeats(string file)
    {
        Console.Clear();

        string[] fileLines = File.ReadAllLines(file);

        Console.WriteLine("List of meats: ");

        foreach (string line in fileLines)
        {
            Console.WriteLine(line);
        }
    }

   

    static void RemoveLine(string file, string[] lines, int id)
    {
        List<string> remainingLines = [];

        string firstChar;

        foreach (string line in lines)
        {
            firstChar = line.Split(';')[0];

            if (int.Parse(firstChar) != id)
            {
                remainingLines.Add(line);
            }
        }

        File.WriteAllLines(file, remainingLines);
    }

    bool CheckIdExist(int id, string[] lines)
    {
        string firstChar;

        foreach (string line in lines)
        {
            firstChar = line.Split(';')[0];

            if (int.Parse(firstChar) == id)
            {
                return true;
            }
        }

        return false;
    }

    void PressKeyMessage()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey(true);
        Console.Clear();
    }

    string SendMessageAndGetValue(string message)
    {
        Console.Write(message);
        string input = Console.ReadLine();

        return input;
    }

    void EditMeat(string file)
    {
        ListAllMeats(file);

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

        string[] fileLines = File.ReadAllLines(file);

        bool existId = CheckIdExist(id, fileLines);

        if (!existId)
        {
            Console.Clear();
            Console.WriteLine("Id do not exist!");
            return;
        }

        string inputType = "";

        List<string> list = [];

        foreach (string line in fileLines)
        {
            string firstChar = line.Split(";")[0];

            if (int.Parse(firstChar) != id)
            {
                list.Add(line);
            }
            else
            {
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

                string editedItem = $"{id};{type};{price}";

                list.Add(editedItem);
            }
        }

        File.WriteAllLines(file, list);

        Console.WriteLine("\nItem was edited!");

    }
}