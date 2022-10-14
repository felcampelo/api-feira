using fair.application.DTO;
using System.Net.Http.Json;
using System.Net;
using fair.domain.Entities.Custom;
using Newtonsoft.Json;
using fair.domain.Entities;

namespace fair.tests.Controller.V1
{
    public class FairControllerTest : BaseControllerTest
    {
        const string url_base = "v1/fair";

        [Fact(DisplayName = "Recuperar Feiras")]
        public async Task GetFairs()
        {
            var request = CreateRequestMessage(HttpMethod.Get, url_base);

            var response = await Client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var objReturn = await response.Content.ReadFromJsonAsync<GenericResult>();
            var fairsList = JsonConvert.DeserializeObject<List<FairDTO>>(objReturn.Content.ToString());

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(fairsList?.Any());
        }

        [Fact(DisplayName = "Criar Feira")]
        public async Task Create()
        {
            Fair newFair = new Fair
            {
                Latitude = -111111,
                Longitude = -22222,
                Address = "Quadra 107",
                Neighborhood = "Águas Claras",
                FairName = "Feira do Artesanato",
                AreaP = "2222",
                District = "Brasília",
                DistrictCode = 100,
                Number = "S/N",
                Region5 = "Centro",
                Region8 = "Oeste",
                SubCityHall = "Asa Sul",
                SubCityHallCode = 100,
                Register = "222",
                SetCens = "222"
            };

            var request = CreateRequestMessage(HttpMethod.Post, url_base, newFair);

            var response = await Client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var objReturn = await response.Content.ReadFromJsonAsync<GenericResult>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(objReturn.Success);
        }

        [Theory(DisplayName = "Atualizar Feira")]
        [InlineData(100)]
        public async Task Update(int idFair)
        {
            Fair existingFair = new Fair
            {
                Id = idFair,
                Latitude = -111111,
                Longitude = -22222,
                Address = "Quadra 107",
                Neighborhood = "Águas Claras",
                FairName = "Feira do Artesanato",
                AreaP = "2222",
                District = "Brasília",
                DistrictCode = 100,
                Number = "S/N",
                Region5 = "Centro",
                Region8 = "Oeste",
                SubCityHall = "Asa Sul",
                SubCityHallCode = 100,
                Register = "222",
                SetCens = "222"
            };

            var request = CreateRequestMessage(HttpMethod.Put, url_base, existingFair);

            var response = await Client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var objReturn = await response.Content.ReadFromJsonAsync<GenericResult>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(objReturn.Success);
        }

        [Fact(DisplayName = "Apagar Feira")]
        public async Task Delete()
        {
            int idFair = new Random().Next(1, 700);
            var request = CreateRequestMessage(HttpMethod.Delete, $"{url_base}/{idFair}");

            var response = await Client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var objReturn = await response.Content.ReadFromJsonAsync<GenericResult>();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(objReturn.Success);
        }
    }
}
