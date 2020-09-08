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
                new HouseProfile { Id = Guid.NewGuid().ToString(), City = "Hoofddorp", ZipCode = "2131RW", IsRent = true, HouseNumber = 12, HouseNumberAddition = "a", Price = 100 , Latitude = 52.309390 ,Longitude = 4.681150 , Photo = "" , HouseType = HouseTypes.Apartment },
                new HouseProfile { Id = Guid.NewGuid().ToString(), City = "Voorburg", ZipCode = "2274XD", IsRent = true, HouseNumber = 101, HouseNumberAddition = "", Price = 200 , Latitude = 52.074940 ,Longitude = 4.354430 , Photo = "" , HouseType = HouseTypes.Apartment },
                new HouseProfile { Id = Guid.NewGuid().ToString(), City = "Veenendaal", ZipCode = "3903WN", IsRent = false, HouseNumber = 16, HouseNumberAddition = "", Price = 392500 , Latitude = 52.006190 ,Longitude = 5.548050 , Photo = "" , HouseType = HouseTypes.TerracedHouse },
                new HouseProfile { Id = Guid.NewGuid().ToString(), City = "Nunspeet", ZipCode = "8072BZ", IsRent = false, HouseNumber = 82, HouseNumberAddition = "", Price = 270000 , Latitude = 52.381280 ,Longitude = 5.799750 , Photo = "" , HouseType = HouseTypes.Bungalow },
                new HouseProfile { Id = Guid.NewGuid().ToString(), City = "Middelie", ZipCode = "1472GR", IsRent = false, HouseNumber = 40, HouseNumberAddition = "", Price = 15000000 , Latitude = 52.543428 ,Longitude = 5.0112434 , Photo = "" , HouseType = HouseTypes.Villa },
                new HouseProfile { Id = Guid.NewGuid().ToString(), City = "Ubbergen", ZipCode = "6574AA", IsRent = false, HouseNumber = 11, HouseNumberAddition = "", Price = 25000000 , Latitude = 51.8381519 ,Longitude = 5.8992003 , Photo = "" , HouseType = HouseTypes.Villa }
            };
        }

        async public Task<IList<HouseProfile>> GetHouseProfilesAsync()
        {
            return await Task.FromResult(HouseProfilesList);
        }
    }
}
