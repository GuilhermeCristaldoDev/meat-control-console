using System.Globalization;
using System.Runtime.InteropServices.ObjectiveC;

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

        public static bool ReadEnumValue<TEnum> (string message, out TEnum value)
            where TEnum : struct, Enum
        {
            int option = ConsoleReader.ReadValue<int>(message);

            if(!Enum.IsDefined(typeof(TEnum), option))
            {
                value = default;
                return false;
            }

            value = (TEnum)(Object)option;
            return true;
        }
    }
}
