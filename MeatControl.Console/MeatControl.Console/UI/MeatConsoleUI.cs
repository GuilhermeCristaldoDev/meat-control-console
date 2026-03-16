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
                ConsoleHelper.PrintHeader();
                ConsoleHelper.PrintSectionTitle("Main Menu");
                ConsoleHelper.PrintMenuItem("1", "Add meat");
                ConsoleHelper.PrintMenuItem("2", "Remove meat");
                ConsoleHelper.PrintMenuItem("3", "List all meats");
                ConsoleHelper.PrintMenuItem("4", "Edit meat");
                ConsoleHelper.PrintMenuItem("0", "Exit", muted: true);
                ConsoleHelper.PrintSeparator();
                ConsoleHelper.PrintMuted("Choose an option ›");

                ConsoleKeyInfo key = Console.ReadKey(true);
                option = key.KeyChar;

                switch (option)
                {
                    case '1':
                        AddMeatUI();
                        break;
                    case '2':
                        RemoveMeatUI();
                        ConsoleHelper.PressAnyKey();
                        break;
                    case '3':
                        ListAllMeatsUI();
                        ConsoleHelper.PressAnyKey();
                        break;
                    case '4':
                        EditMeatUI();
                        ConsoleHelper.PressAnyKey();
                        break;
                    case '0':
                        break;
                    default:
                        ConsoleHelper.PrintError("Invalid option!");
                        ConsoleHelper.PressAnyKey();
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
                ConsoleHelper.PrintHeader();
                ConsoleHelper.PrintSectionTitle("Add Meat");
                ListAllMeatCuts();

                int input = ConsoleReader.ReadValue<int>("\n  Choose meat type: ");

                if (!Enum.IsDefined(typeof(MeatCut), input))
                {
                    ConsoleHelper.PrintError("Invalid meat type!");
                    ConsoleHelper.PressAnyKey();
                    return;
                }

                MeatCut type = (MeatCut)input;
                decimal price = ConsoleReader.ReadValue<decimal>("  Price: ");

                try
                {
                    ConsoleHelper.PrintSuccess(_meatService.AddMeat(type, price));
                }
                catch (DomainException ex)
                {
                    ConsoleHelper.PrintError(ex.Message);
                }
                catch (Exception)
                {
                    ConsoleHelper.PrintError("Unexpected error. Try again later...");
                }

                ConsoleKeyInfo key;
                do
                {
                    ConsoleHelper.PrintMuted("\n  Add another meat? (y/n)");
                    key = Console.ReadKey(true);
                    if (key.KeyChar != 'y' && key.KeyChar != 'n')
                        ConsoleHelper.PrintError("Invalid key!");
                }
                while (key.KeyChar != 'y' && key.KeyChar != 'n');

                continueOption = key.KeyChar == 'y';
            }
            while (continueOption);
        }

        void RemoveMeatUI()
        {
            ConsoleHelper.PrintHeader();
            ConsoleHelper.PrintSectionTitle("Remove Meat");

            try
            {
                List<Meat> meats = _meatService.GetAllMeats();
                WriteAllMeats(meats);

                int id = ConsoleReader.ReadValue<int>("\n  Enter ID to be deleted: ");
                ConsoleHelper.PrintSuccess(_meatService.RemoveMeat(id));
            }
            catch (FormatException ex)
            {
                ConsoleHelper.PrintError(ex.Message);
            }
        }

        void ListAllMeatsUI()
        {
            ConsoleHelper.PrintHeader();
            ConsoleHelper.PrintSectionTitle("All Meats");

            try
            {
                List<Meat> meats = _meatService.GetAllMeats();
                WriteAllMeats(meats);

                MeatSummary summary = new();
                summary.CalculateSummary(meats);

                ConsoleHelper.PrintSeparator();
                ConsoleHelper.PrintLabel("Total items", summary.TotalMeats.ToString());
                ConsoleHelper.PrintLabel("Total value", $"R$ {summary.TotalValue.ToString("F2", CultureInfo.InvariantCulture)}");
            }
            catch (FormatException ex)
            {
                ConsoleHelper.PrintError(ex.Message);
            }
        }

        void EditMeatUI()
        {
            ConsoleHelper.PrintHeader();
            ConsoleHelper.PrintSectionTitle("Edit Meat");

            try
            {
                List<Meat> meats = _meatService.GetAllMeats();
                WriteAllMeats(meats);
            }
            catch (FormatException ex)
            {
                ConsoleHelper.PrintError(ex.Message);
                return;
            }

            int id = ConsoleReader.ReadValue<int>("\n  Enter meat ID to be edited: ");

            try
            {
                Meat? meat = _meatService.GetMeatById(id);

                if (meat == null)
                {
                    ConsoleHelper.PrintError("Meat doesn't exist!");
                    return;
                }

                ListAllMeatCuts();

                if (!ConsoleReader.ReadEnumValue<MeatCut>("  New meat type: ", out var newMeatType))
                {
                    ConsoleHelper.PrintError("Invalid meat type!");
                    return;
                }

                decimal newPrice = ConsoleReader.ReadValue<decimal>("  New price: ");
                ConsoleHelper.PrintSuccess(_meatService.EditMeat(id, newMeatType, newPrice));
            }
            catch (DomainException ex)
            {
                ConsoleHelper.PrintError(ex.Message);
            }
        }

        public static void WriteAllMeats(List<Meat> meats)
        {
            foreach (Meat meat in meats)
                ConsoleHelper.PrintMeatLine(
                    $"#{meat.Id}",
                    ConsoleHelper.FormatEnumName(meat.MeatCut.ToString()),
                    $"R$ {meat.Price.ToString("F2", CultureInfo.InvariantCulture)}"
                );
        }

        public static void ListAllMeatCuts()
        {
            ConsoleHelper.PrintSeparator();
            var vet = Enum.GetValuesAsUnderlyingType<MeatCut>();
            for (int i = 1; i <= vet.Length; i++)
                ConsoleHelper.PrintLabel(i.ToString(), ConsoleHelper.FormatEnumName(((MeatCut)i).ToString()));
            ConsoleHelper.PrintSeparator();
        }
    }
}
