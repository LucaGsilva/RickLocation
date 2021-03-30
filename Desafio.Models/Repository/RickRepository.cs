using Desafio.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Desafio.Models.Repository
{
    public class RickRepository : Repository<int, Rick>
    {
        public RickRepository(DbContext dBContext) : base(dBContext)
        {
        }

        public async Task<IEnumerable<Rick>> GetRicks()
        {

            var query = from rick in this.dbSet
                        .Include(r => r.Dimension)
                        select rick;
            return await query.ToListAsync();

        }
    }
}
