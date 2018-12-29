using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiCore.Models.Domain;

namespace WebApiCore.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly DbContext _dbContext;

        public CategoryRepository(DbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<IEnumerable<Category>> GetCategoriesOrderedByParentChild()
        {
            var query = "GetCategoriesOrderedByParentChild";


            // Dapper
            //var param = new DynamicParameters();
            //return await SqlMapper.QueryAsync<Category>(_dbContext.Database.GetDbConnection(), query, param, commandType: CommandType.StoredProcedure);

            //EF Core 2.1
            //var param = new SqlParameter("@p0", "Bill");
            return await _dbContext.Set<Category>().FromSql(query).ToListAsync();
        }
    }
}
