using fair.domain.Filters;
using fair.domain.Queries;
using fair.infra.Repository.Base;
using fair.domain.Entities;
using fair.infra.Context;
using Microsoft.EntityFrameworkCore;
using fair.domain.RepositoryInterfaces;

namespace fair.infra.Repository
{
    public class FairRepository : BaseRepository<Fair, int>, IFairRepository
    {
        public FairRepository(FairContext context)
            : base(context)
        { }

        public async Task CreateFair(Fair fair) =>
            await this.Insert(fair);

        public async Task UpdateFair(Fair fair) =>
            await this.Update(fair);

        public async Task DeleteFair(int idFair) =>
            await this.DeleteById(idFair);

        public async Task<List<Fair>> GetFairs(FairFilter filter) =>
            await this.GetWhere(FairQueries.GetFairsByFilter(filter)).ToListAsync();
    }
}
