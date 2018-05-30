using System;
using System.Threading.Tasks;
using Actio.Services.Activities.Domains.Models;

namespace Actio.Services.Activities.Domains.Repositories
{
    public interface IActivityRepository
    {
        Task<Activity> GetAsync(Guid id);
        Task AddAsync(Activity activity);
    }
}