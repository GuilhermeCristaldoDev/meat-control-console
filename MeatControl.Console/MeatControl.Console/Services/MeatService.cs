using MeatControlConsole.Entities;
using MeatControlConsole.Entities.Exceptions;
using MeatControlConsole.Repositories;
using MeatControlConsole.Entities.Enums;

namespace MeatControlConsole.Services
{
    internal class MeatService
    {
        private readonly IMeatRepository _repository;

        public MeatService(IMeatRepository repository)
        {
            _repository = repository;
        }
        public string AddMeat(MeatCut type, decimal price)
        {
            Meat newMeat = new(GetNextMeatId(), type, price);
            _repository.Add(newMeat);
            return "Meat added sucessfully!";
        }

        public string RemoveMeat(int id)
        {

            if (!IdExists(id))
                return "Meat doesn't exists!";


            _repository.Delete(id);

            return "Meat deleted!";
        }

        public string EditMeat(int id, MeatCut type, decimal price)
        {
            if (!IdExists(id))
                return "Meat doesn't exists!";

            if (price <= 0)
                return "Price can't be less or equal zero!";

            Meat newMeat = new(id, type, price);
            _repository.Update(id, newMeat);

            return "Meat updated!";
        }

        public bool IdExists(int id)
        {
            List<Meat> meats = _repository.GetAll();

            Meat meat = meats.Find(meat => meat.Id == id);

            return meat != null;
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
