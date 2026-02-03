using MeatControlConsole.Entities;
using MeatControlConsole.Repositories;

namespace MeatControlConsole.Services
{
    internal class MeatService
    {
        private readonly IMeatRepository _repository;

        public MeatService(IMeatRepository repository)
        {
            _repository = repository;
        }
        public void AddMeat(string type, double price)
        {
            if (string.IsNullOrEmpty(type))
            {
                return;
            }

            if (price <= 0)
            {
                return;
            }

            Meat newMeat = new(GetNextMeatId(), type, price);

            _repository.Add(newMeat);

        }

        public void RemoveMeat(int id)
        {
            if (id <= 0)
            {
                return;
            }

            if (!IdExists(id))
            {
                return;
            }

            _repository.Delete(id);
        }

        public void EditMeat(int id, string type, double price)
        {
            List<Meat> meats = _repository.GetAll();

            if(price <= 0)
            {
                return;
            }

            Meat newMeat = new(id, type, price);

            _repository.Update(id, newMeat);
        }

        public bool IdExists(int id)
        {
            List<Meat> meats = _repository.GetAll();

            Meat meat = meats.Find(meat => meat.Id == id);

            if (meat == null)
                throw new Exception("This meat doesn't exists");

            return true;
        }

        public List<Meat> GetAllMeats()
        {
            return _repository.GetAll();
        }

        public Meat GetMeatById(int id)
        {
            Meat meat = _repository.GetById(id) ?? throw new Exception("Meat doesn't exists");

            return meat;
        }

        private int GetNextMeatId()
        {
            List<Meat> meats = _repository.GetAll();

            if (meats.Count == 0)
            {
                return 1;
            }

            int maxId = meats.Max(meat => meat.Id);

            return maxId + 1;
        }
    }
}
