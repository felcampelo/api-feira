using fair.domain.RepositoryInterfaces;
using fair.infra.Context;
using fair.infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fair.test
{
    [TestClass]
    public class FairRepositoryTest
    {
        IFairRepository repository;

        [TestInitialize]
        public void Init()
        {
            //repository = new FairRepository(new FairContext());
        }

        [TestMethod]
        public async Task Insert_Fair()
        {

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
