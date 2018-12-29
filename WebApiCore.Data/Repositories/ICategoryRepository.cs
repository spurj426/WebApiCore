using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCore.Data.Infrastructure;
using WebApiCore.Models.Domain;

namespace WebApiCore.Data.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<Category>> GetCategoriesOrderedByParentChild();
    }
}
