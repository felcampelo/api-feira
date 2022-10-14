using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using fair.application.DTO;

namespace fair.test.Controller.V1
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
            var objReturn = await response.Content.ReadFromJsonAsync<IEnumerable<FairDTO>>();

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.True(objReturn?.Any());
        }
    }
}
