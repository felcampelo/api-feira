using fair.domain.Filters;
using fair.domain.Queries;
using fair.infra.Repository.Base;
using fair.domain.Entities;
using fair.infra.Context;
using Microsoft.EntityFrameworkCore;

namespace fair.infra.Repository
{
    public class FairRepository : BaseRepository<Fair, int>
    {
        public FairRepository(FairContext context)
            : base(context)
        { }

        public async Task InsertFair(Fair fair) =>
            await this.Insert(fair);

        public async Task UpdateFair(Fair fair) =>
            await this.Update(fair);

        public async Task DeleteFair(int idFair) =>
            await this.DeleteById(idFair);

        public async Task GetFairs(FairFilter filter) =>

            await this.GetWhere(FairQueries.GetFairsByFilter(filter))
                .Select(c => new
                {
                    c.Id
                }).ToListAsync();
    }
}
