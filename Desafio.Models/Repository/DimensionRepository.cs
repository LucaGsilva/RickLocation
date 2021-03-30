using Desafio.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Models.Repository
{
    public class DimensionRepository : Repository<int, Dimension>
    {
        public DimensionRepository(DbContext dBContext) : base(dBContext)
        {
        }

        public Task<Dimension> GetByName(string dimension)
        {
            var query = from d in this.dbSet
                        where d.Name == dimension
                        select d;
            return query.FirstOrDefaultAsync();
        }
    }
}
