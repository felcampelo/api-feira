using fair.domain.Filters;
using fair.domain.Entities;

namespace fair.domain.RepositoryInterfaces
{
    public interface IFairRepository
    {
        Task CreateFair(Fair fair);
        Task UpdateFair(Fair fair);
        Task DeleteFair(int idFair);
        Task<Fair?> GetFairById(int idFair);
        Task<Fair?> GetFirstFair();
        Task<List<Fair>> GetFairs(FairFilter filter);
    }
}
