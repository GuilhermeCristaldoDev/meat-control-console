using MeatControlConsole.Entities;

namespace MeatControlConsole.Repositories
{
    internal interface IMeatRepository
    {
        void Add(Meat meat);
        List<Meat> GetAll();
        void Delete(int id);

        void Update(int id, Meat meat);

        Meat GetById(int id);

    }
}
