using fair.application.DTO;
using System.Net.Http.Json;
using System.Net;
using fair.domain.Entities.Custom;
using Newtonsoft.Json;

namespace fair.tests.Controller.V1
{
    public class FairControllerTest : BaseControllerTest
    {
        const string url_base = "v1/fair";

        [Fact()]
        public async Task GetFairs()
        {
            //Arrage            
            var request = CreateRequestMessage(HttpMethod.Get, url_base);

            //Act
            var response = await Client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var objReturn = await response.Content.ReadFromJsonAsync<GenericResult>() as GenericResult;
            var fairsList = JsonConvert.DeserializeObject<List<FairDTO>>(objReturn.Content.ToString());


            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(fairsList?.Any());
        }
    }
}
