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

        [TestInitialize]
        public void Init()
        {
            serviceProvider = InfraDependencyResolver.RegisterServices();
        }

        [TestMethod]
        public async Task Insert_Fair()
        {
            var repository = serviceProvider.GetService<IFairRepository>();

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

            await repository.InsertFair(newFair);

            Assert.IsTrue(newFair.Id > 0);
        }

        [TestMethod]
        public async Task Update_Fair()
        {

        }

        [TestMethod]
        public async Task Get_Fair_By_Filter()
        {

        }

        [TestMethod]
        public async Task Delete_Fair_By_Id()
        {

        }
    }
}
