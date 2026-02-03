using System.Globalization;

namespace MeatControlConsole.Utils
{
    internal static class ConsoleReader
    {

        public static T ReadValue<T>(string message)
            where T : IParsable<T>
        {
            while (true)
            {
                Console.Write(message);
                var input = Console.ReadLine();

                if (T.TryParse(input, CultureInfo.InvariantCulture, out var result))
                    return result;

                Console.WriteLine("Invalid input!");
            }
        }
    }
}
