using MeatControl.Console.Entities;
using System.Globalization;

namespace MeatControl.Console.Repositories
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
            File.AppendAllText(_filePath, $"{meat.Id};{meat.Cut};{meat.Price.ToString("F2", CultureInfo.InvariantCulture)}{Environment.NewLine}");
        }

        public List<Meat> GetAll()
        {
            List<Meat> meats = [];

            if (File.Exists(_filePath))
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

            foreach (Meat meat in meats)
            {
                if(meat.Id == id)
                {
                    meats.Remove(meat);
                }
            }

            File.WriteAllLines(_filePath, (string) meats);
        }

        public void Edit(int id, Meat meat)
        {

        }
    }
}
