using MeatControlConsole.Entities;
using MeatControlConsole.Entities.Enums;
using MeatControlConsole.Entities.Exceptions;
using MeatControlConsole.Services;
using MeatControlConsole.Utils;
using System.Globalization;

namespace MeatControlConsole.UI
{
    internal class MeatConsoleUI
    {
        private readonly MeatService _meatService;

        public MeatConsoleUI(MeatService service)
        {
            _meatService = service;
        }

        public void Run()
        {
            char option;

            do
            {
                Console.Clear();
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

                ListAllMeatCuts();

                int input = ConsoleReader.ReadValue<int>("Choose meat type: ");

                if (!Enum.IsDefined(typeof(MeatCut), input))
                {
                    Console.WriteLine("Invalid meat type!");
                    return;
                }

                MeatCut type = (MeatCut)input;

                decimal price = ConsoleReader.ReadValue<decimal>("Price: ");

                try
                {
                    Console.WriteLine(_meatService.AddMeat(type, price));
                }
                catch (DomainException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception)
                {
                    Console.WriteLine("Unexpected error. Try again later...");
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

            Console.WriteLine(_meatService.RemoveMeat(id));
        }

        void ListAllMeatsUI()
        {
            Console.Clear();

            try
            {
                List<Meat> meats = _meatService.GetAllMeats();

                WriteAllMeats(meats);

                MeatSummary summary = new();
                summary.CalculateSummary(meats);
                Console.WriteLine($"Qtd meats: {summary.TotalMeats} Total: R${summary.TotalValue.ToString("F2", CultureInfo.InvariantCulture)}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        void EditMeatUI()
        {
            Console.Clear();

            try
            {
                List<Meat> meats = _meatService.GetAllMeats();

                WriteAllMeats(meats);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            int id = ConsoleReader.ReadValue<int>("Enter with the meat ID to be edited: ");

            try
            {
                Meat meat = _meatService.GetMeatById(id);

                if (meat == null)
                {
                    Console.WriteLine("Meat doesn't exists!");
                    return;
                }

                ListAllMeatCuts();

                if (!ConsoleReader.ReadEnumValue<MeatCut>("New meat type: ", out var newMeatType))
                {
                    Console.WriteLine("Invalid meat type");
                    return;
                }

                decimal newPrice = ConsoleReader.ReadValue<decimal>("New meat price: ");

                Console.WriteLine(_meatService.EditMeat(id, newMeatType, newPrice));
            }
            catch (DomainException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        static void PressKeyMessage()
        {
            Console.WriteLine($"{Environment.NewLine}Press any key to continue...");
            Console.ReadKey(true);
            Console.Clear();
        }

        public static void WriteAllMeats(List<Meat> meats)
        {
            foreach (Meat meat in meats)
            {
                Console.WriteLine(meat.ToString());
            }
        }

        public static void ListAllMeatCuts()
        {
            var vet = Enum.GetValuesAsUnderlyingType<MeatCut>();

            Console.WriteLine();

            for (int i = 1; i <= vet.Length; i++)
            {
                Console.WriteLine($"{i} - {(MeatCut)i}");
            }

            Console.WriteLine();

        }
    }
}
