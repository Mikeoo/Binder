using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Binder.Models;

namespace Binder.Services
{
    public class MockBinderDataStore : IBinderDataStore
    {
        private readonly List<HouseProfile> HouseProfilesList;


        public MockBinderDataStore()
        {
            HouseProfilesList = new List<HouseProfile>()
            {
                new HouseProfile { Id = Guid.NewGuid().ToString(), City = "Hoofddorp", Price = 100 , HouseType = HouseTypes.Apartment },

            };
        }

        async public Task<IList<HouseProfile>> GetHouseProfilesAsync()
        {
            return await Task.FromResult(HouseProfilesList);
        }
    }
}
