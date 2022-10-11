using fair.infra.Repository.Base;
using feira.domain.Entities;
using feira.infra.Context;

namespace fair.infra.Repository
{
    public class FairRepository : BaseRepository<Fair, int>
    {
        public FairRepository(FairContext context)
            : base(context)
        { }

        public async Task GetFairs()
        {
            try
            {
                //await this.GetWhere(c=>)
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
