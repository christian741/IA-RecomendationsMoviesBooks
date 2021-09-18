using MovBooks.Core.CustomEntities;
using MovBooks.Core.Entities;
using MovBooks.Core.QueryFilters;
using System.Threading.Tasks;

namespace MovBooks.Core.Interfaces
{
    public interface IParameterService
    {
        PagedList<Parameter> GetAll(ParameterQueryFilter filters);
        Task<Parameter> GetById(int id);
        Task Insert(Parameter parameter);
        Task<bool> Update(Parameter parameter);
        Task<bool> Delete(int id);
        Task<Parameter> FindByKey(string key, int? id);
    }
}
