using System.Collections.Generic;
using System.Threading.Tasks;
using Actio.Services.Activities.Domains.Models;

namespace Actio.Services.Activities.Domains.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetAsync(string name);
        Task<IEnumerable<Category>> BrowseAsync();
        Task AddAsync(Category category);
    }
}