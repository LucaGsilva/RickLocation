using Desafio.Models.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Desafio.Models.Repository
{
    public class TravelRepository : Repository<int, Travel>
    {
        public TravelRepository(DbContext dBContext) : base(dBContext)
        {
        }

        public async Task<IList<Travel>> GetByRick(int rickId)
        {
            var query = from travel in this.dbSet
                        .Include(t => t.Dimension)
                        where travel.RickId == rickId
                        select travel;

            return await query.ToListAsync();
         }

    }
}
