using fair.domain.Filters;
using fair.domain.Entities;

namespace fair.domain.RepositoryInterfaces
{
    public interface IFairRepository
    {
        Task InsertFair(Fair fair);
        Task UpdateFair(Fair fair);
        Task DeleteFair(int idFair);
        Task GetFairs(FairFilter filter);
    }
}
