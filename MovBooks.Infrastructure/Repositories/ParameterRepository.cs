using Microsoft.EntityFrameworkCore;
using MovBooks.Core.Entities;
using MovBooks.Core.Interfaces;
using MovBooks.Infrastructure.Data;
using System.Threading.Tasks;

namespace MovBooks.Infrastructure.Repositories
{
    public class ParameterRepository : BaseRepository<Parameter>, IParameterRepository
    {
        public ParameterRepository(MovBooksContext context) : base(context)
        {
        }

        public async Task<Parameter> FindByKey(string key, int? id)
        {
            var parameter = await _entities
                            .FirstOrDefaultAsync(x => (id == null || x.Id != id) && x.Key.ToLower() == key.ToLower());
            return parameter;
        }
    }
}
