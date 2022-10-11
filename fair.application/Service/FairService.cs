using AutoMapper;
using fair.application.Contract;
using fair.application.DTO;
using fair.domain.Entities;
using fair.domain.Entities.Custom;
using fair.domain.Filters;
using fair.domain.RepositoryInterfaces;

namespace fair.application.Service
{
    public class FairService : IFairService
    {
        private readonly IMapper mapper;
        private readonly IFairRepository fairRepository;

        public FairService(IFairRepository fairRepository,
            IMapper mapper)
        {
            this.fairRepository = fairRepository;
            this.mapper = mapper;
        }

        public async Task<GenericResult> GetFairs(FairFilter filter)
        {
            GenericResult result = new GenericResult { Success = true };

            try
            {
                var fairs = await this.fairRepository.GetFairs(filter);
                result.Content = fairs.Select(c => mapper.Map<FairDTO>(c));
                result.TotalRecords = fairs.Count;

            }
            catch (Exception err)
            {
                result.ErrorMessage = err.Message;
            }

            return result;
        }

        public async Task<GenericResult> Create(FairDTO dto)
        {
            GenericResult result = new GenericResult { Success = true };

            try
            {
                var model = mapper.Map<Fair>(dto);
                await this.fairRepository.CreateFair(model);
            }
            catch (Exception err)
            {
                result.ErrorMessage = err.Message;
            }

            return result;
        }

        public async Task<GenericResult> Update(FairDTO dto)
        {
            GenericResult result = new GenericResult { Success = true };

            try
            {
                var model = mapper.Map<Fair>(dto);
                await this.fairRepository.UpdateFair(model);
            }
            catch (Exception err)
            {
                result.ErrorMessage = err.Message;
            }

            return result;
        }

        public async Task<GenericResult> Delete(int id)
        {
            GenericResult result = new GenericResult { Success = true };

            try
            {
                await this.fairRepository.DeleteFair(id);
            }
            catch (Exception err)
            {
                result.ErrorMessage = err.Message;
            }

            return result;
        }
    }
}
