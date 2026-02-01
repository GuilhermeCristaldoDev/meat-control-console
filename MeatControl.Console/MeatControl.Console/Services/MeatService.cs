using MeatControl.Console.Entities;
using MeatControl.Console.Repositories;

namespace MeatControl.Console.Services
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
            if(id <= 0)
            {
                return;
            }

            if(!IdExists(id))
            {
                return;
            }

            _repository.Delete(id);
        }

        public bool IdExists(int id)
        {
            List<Meat> meats = _repository.GetAll();

            if (meats.Count == 0) {
                return false;
            }

            bool idExist = false;

            foreach (Meat meat in meats)
            {
                if(id == meat.Id)
                {
                    idExist = true;
                }
            }

            return idExist;
        }

        public List<Meat> GetAllMeats()
        {
            return _repository.GetAll();
        }

        private int GetNextMeatId()
        {
            List<Meat> meats = _repository.GetAll();

            if (meats.Count == 0)
            {
                return 1;
            }

            int maxId = 0;

            for (int i = 0; i < meats.Count; i++)
            {
                if (maxId < meats[i].Id)
                {
                    maxId = meats[i].Id;
                }
            }

            return maxId + 1;
        }
    }
}
