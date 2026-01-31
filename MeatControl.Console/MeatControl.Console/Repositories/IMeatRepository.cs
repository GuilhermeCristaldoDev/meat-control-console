using MeatControl.Console.Entities;

namespace MeatControl.Console.Repositories
{
    internal interface IMeatRepository
    {
        void Save(Meat meat);
        List<Meat> GetAll();
        void Delete(int id);

        void Edit(int id, Meat meat);
    }
}
