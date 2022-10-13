using fair.domain.Entities;
using fair.domain.RepositoryInterfaces;
using fair.ioc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace fair.test
{
    [TestClass]
    public class FairRepositoryTest
    {
        ServiceProvider? serviceProvider;
        IFairRepository? repository;

        [TestInitialize]
        public void Init()
        {
            serviceProvider = InfraDependencyResolver.RegisterServices();
            repository = serviceProvider.GetService<IFairRepository>();
        }

        [TestMethod]
        public async Task Create()
        {
            Fair newFair = new Fair
            {
                Address = "Quadra 106",
                AreaP = "3550308005041",
                District = "Brasília",
                DistrictCode = 10,
                FairName = "Feira do Artesanato de Brasília",
                Latitude = -46448044,
                Longitude = -23503846,
                Reference = "No pavilhão do parque da cidade",
                Neighborhood = "Asa Sul",
                Number = "S/N",
                Region5 = "Sul",
                Region8 = "Sul 2",
                Register = "1151-2",
                SetCens = "355030822000113",
                SubCityHall = "304 Sul",
                SubCityHallCode = 234
            };

            await repository.CreateFair(newFair);

            Assert.IsTrue(newFair.Id > 0);
        }

        [TestMethod]
        public async Task Update()
        {
            Fair fair = new Fair
            {
                Id = 4,
                Address = "Quadra 106",
                AreaP = "3550308005041",
                District = "Brasília",
                DistrictCode = 10,
                FairName = "Feira do Artesanato de Brasília ALTERADO",
                Latitude = -46448044,
                Longitude = -23503846,
                Reference = "No pavilhão do parque da cidade ALTERADO",
                Neighborhood = "Asa Sul",
                Number = "S/N",
                Region5 = "Sul",
                Region8 = "Sul 2",
                Register = "1151-2",
                SetCens = "355030822000113",
                SubCityHall = "304 Sul",
                SubCityHallCode = 234
            };

            await repository.UpdateFair(fair);

            Fair updatedFair = await repository.GetFairById(fair.Id);

            Assert.AreEqual(fair, updatedFair);
        }

        [TestMethod]
        public async Task Get_Fairs()
        {
            List<Fair> fairs = await this.repository.GetFairs(new domain.Filters.FairFilter { Region5 = "Sul" });
            Assert.IsTrue(fairs.Any());
        }

        [TestMethod]
        public async Task Delete()
        {
            Fair? firstFair = await this.repository.GetFirstFair();
            Assert.IsNotNull(firstFair);

            await this.repository.DeleteFair(firstFair.Id);

            Fair? excludedFair = await this.repository.GetFairById(firstFair.Id);

            Assert.IsNull(excludedFair);
        }
    }
}
