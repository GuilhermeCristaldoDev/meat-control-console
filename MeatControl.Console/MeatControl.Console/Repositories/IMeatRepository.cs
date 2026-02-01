using MeatControl.Console.Entities;

namespace MeatControl.Console.Repositories
{
    internal interface IMeatRepository
    {
        void Add(Meat meat);
        List<Meat> GetAll();
        void Delete(int id);

        void Edit(int id, Meat meat);

    }
}
