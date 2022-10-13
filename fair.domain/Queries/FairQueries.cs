using fair.domain.Filters;
using fair.domain.Entities;
using System.Linq.Expressions;

namespace fair.domain.Queries
{
    public static class FairQueries
    {
        public static Expression<Func<Fair, bool>> GetFairsByFilter(FairFilter filter)
        {
            return c => (string.IsNullOrEmpty(filter.FairName) || c.FairName.Contains(filter.FairName))
            && (string.IsNullOrEmpty(filter.Region5) || c.Region5.ToLower().Equals(filter.Region5.ToLower()))
            && (string.IsNullOrEmpty(filter.District) || c.District.Contains(filter.District))
            && (string.IsNullOrEmpty(filter.Neighborhood) || c.Neighborhood.Contains(filter.Neighborhood));
        }
    }
}
