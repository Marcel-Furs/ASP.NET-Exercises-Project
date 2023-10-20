using Strona_Bazy.Data.Models;

namespace Strona_Bazy.Repositories
{
    public interface ICharakterRepository
    { 
        Charakter Get(int id);
        List<Charakter> GetAll();

        bool Delete(int id);
        bool Update(Charakter charakter);
        bool Create(Charakter charakter);
    }
}
