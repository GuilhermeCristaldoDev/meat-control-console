
using MeatControlConsole.Repositories;
using MeatControlConsole.Services;
using MeatControlConsole.UI;

internal class Program
{
    private static void Main(string[] args)

    {
        string baseDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string sessionsDir = Path.Combine(baseDir, "MeatConsole");
        Directory.CreateDirectory(sessionsDir);
        string filePath = Path.Combine(sessionsDir, $"session_{DateOnly.FromDateTime(DateTime.Now):yyyy-MM-dd}.txt");

        IMeatRepository repository = new MeatRepository(filePath);
        MeatService meatService = new(repository);

        MeatConsoleUI ui = new(meatService);
        ui.Run();
    }
}