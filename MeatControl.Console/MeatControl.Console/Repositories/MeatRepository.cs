using MeatControlConsole.Entities;
using System.Globalization;

namespace MeatControlConsole.Repositories
{
    internal class MeatRepository : IMeatRepository
    {
        private readonly string _filePath;

        public MeatRepository(string filePath)
        {
            _filePath = filePath;
        }
        public void Add(Meat meat)
        {
            File.AppendAllText(_filePath, $"{meat.Id};{meat.Cut};{meat.Price.ToString(CultureInfo.InvariantCulture)}{Environment.NewLine}");
        }

        public List<Meat> GetAll()
        {
            List<Meat> meats = [];

            if (!File.Exists(_filePath))
                return meats;

            foreach (string line in File.ReadLines(_filePath))
            {
                string[] values = line.Split(';');

                meats.Add(new Meat(int.Parse(values[0]),
                    values[1],
                    double.Parse(values[2])));
            }

            return meats;
        }

        public void Delete(int id)
        {
            List<Meat> meats = GetAll();

            meats.RemoveAll(meat => meat.Id == id);

            var lines = meats.Select(meat => $"{meat.Id};{meat.Cut};{meat.Price.ToString(CultureInfo.InvariantCulture)}");

            File.WriteAllLines(_filePath, lines);
        }

        public void Update(int id, Meat newMeat)
        {
            List<Meat> meats = GetAll();

            meats = [.. meats.Select(meat =>
                meat.Id == id ? newMeat : meat
             )];

            var lines = meats.Select(m => $"{m.Id};{m.Cut};{m.Price.ToString("F2", CultureInfo.InvariantCulture)}");

            File.WriteAllLines(_filePath, lines);
        }

        public Meat GetById(int id)
        {
            List<Meat> meats = GetAll();

            return meats.Find(meat => meat.Id == id);
        }
    }
}
