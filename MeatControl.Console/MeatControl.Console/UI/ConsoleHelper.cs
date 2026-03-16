namespace MeatControlConsole.UI
{
    internal static class ConsoleHelper
    {
        private const ConsoleColor Primary = ConsoleColor.DarkRed;  
        private const ConsoleColor Success = ConsoleColor.Green;
        private const ConsoleColor Error = ConsoleColor.Red;
        private const ConsoleColor Muted = ConsoleColor.DarkGray;
        private const ConsoleColor Normal = ConsoleColor.Gray;

        public static void PrintHeader()
        {
            Console.Clear();
            SetColor(Primary);
            Console.WriteLine(@"  ███╗   ███╗███████╗ █████╗ ████████╗");
            Console.WriteLine(@"  ████╗ ████║██╔════╝██╔══██╗╚══██╔══╝");
            Console.WriteLine(@"  ██╔████╔██║█████╗  ███████║   ██║   ");
            Console.WriteLine(@"  ██║╚██╔╝██║██╔══╝  ██╔══██║   ██║   ");
            Console.WriteLine(@"  ██║ ╚═╝ ██║███████╗██║  ██║   ██║   ");
            Console.WriteLine(@"  ╚═╝     ╚═╝╚══════╝╚═╝  ╚═╝   ╚═╝   ");
            SetColor(Muted);
            Console.WriteLine("           C O N T R O L   v 1 . 0\n");
            Reset();
        }

        public static void PrintSectionTitle(string title)
        {
            SetColor(Muted);
            Console.WriteLine($"\n  {title.ToUpper()}");
            PrintSeparator();
        }

        public static void PrintSeparator()
        {
            SetColor(Muted);
            Console.WriteLine("  ─────────────────────────────────────────");
            Reset();
        }

        public static void PrintMenuItem(string key, string label, bool muted = false)
        {
            Console.Write("  ");
            SetColor(muted ? Muted : Primary);
            Console.Write($"[{key}]");
            SetColor(muted ? Muted : Normal);
            Console.WriteLine($"  {label}");
            Reset();
        }

        public static void PrintSuccess(string message)
        {
            SetColor(Success);
            Console.WriteLine($"\n  + {message}");
            Reset();
        }

        public static void PrintError(string message)
        {
            SetColor(Error);
            Console.WriteLine($"\n  x {message}");
            Reset();
        }

        public static void PrintMuted(string message)
        {
            SetColor(Muted);
            Console.WriteLine($"  {message}");
            Reset();
        }

        public static void PrintPrimary(string message)
        {
            SetColor(Primary);
            Console.Write(message);
            Reset();
        }

        public static void PrintLabel(string label, string value)
        {
            SetColor(Muted);
            Console.Write($"  {label}: ");
            SetColor(Normal);
            Console.WriteLine(value);
            Reset();
        }

        public static void PressAnyKey()
        {
            SetColor(Muted);
            Console.WriteLine("\n  Press any key to continue...");
            Reset();
            Console.ReadKey(true);
        }

        public static void PrintMeatLine(string id, string name, string price)
        {
            Console.Write("  ");
            SetColor(Primary);
            Console.Write(id.PadRight(6));
            SetColor(Normal);
            Console.Write(name.PadRight(20));
            SetColor(Success);
            Console.WriteLine(price);
            Reset();
        }

        public static string FormatEnumName(string name)
        {
            string spaced = string.Concat(name.Select((c, i) => i > 0 && char.IsUpper(c) ? " " + c : c.ToString()));
            return char.ToUpper(spaced[0]) + spaced[1..].ToLower();
        }

        private static void SetColor(ConsoleColor color) => Console.ForegroundColor = color;
        private static void Reset() => Console.ResetColor();
    }
}