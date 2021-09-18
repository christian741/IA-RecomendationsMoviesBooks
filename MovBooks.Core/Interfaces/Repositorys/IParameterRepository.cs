using MovBooks.Core.Entities;
using System.Threading.Tasks;

namespace MovBooks.Core.Interfaces
{
    public interface IParameterRepository : IRepository<Parameter>
    {
        Task<Parameter> FindByKey(string key, int? id);
    }
}
