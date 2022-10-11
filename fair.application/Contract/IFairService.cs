using fair.application.DTO;
using fair.domain.Entities.Custom;
using fair.domain.Filters;

namespace fair.application.Contract
{
    public interface IFairService
    {
        Task<GenericResult> GetFairs(FairFilter filter);
        Task<GenericResult> Create(FairDTO dto);
        Task<GenericResult> Update(FairDTO dto);
        Task<GenericResult> Delete(int id);
    }
}
