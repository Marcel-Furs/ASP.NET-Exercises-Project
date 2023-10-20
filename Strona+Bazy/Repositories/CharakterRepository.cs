using Strona_Bazy.Data;
using Strona_Bazy.Data.Models;

namespace Strona_Bazy.Repositories.CharakterRepository
{
    public class CharakterRepository : ICharakterRepository
    {
        private readonly DataContext context;

        public CharakterRepository(DataContext context)
        {
            this.context = context;
        }
        public bool Create(Charakter charakter)
        {
            context.Add(charakter);
            context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var entity = Get(id);
            if (entity == null)
            {
                return false;
            }
            context.Charakter.Remove(entity);
            context.SaveChanges();
            return true;
        }

        public Charakter Get(int id)
        {
            return context.Charakter.FirstOrDefault(x => x.Id == id);
        }

        public List<Charakter> GetAll()
        {
            return context.Charakter.ToList();
        }

        public bool Update(Charakter drink)
        {

            var entity = Get(drink.Id);
            if (entity == null)
            {
                return false;
            }

            context.Update(drink);
            context.SaveChanges();
            return true;
        }
    }
}