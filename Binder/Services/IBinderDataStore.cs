using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Binder.Models;

namespace Binder.Services
{
    public interface IBinderDataStore 
    {
      Task<IList<HouseProfile>> GetHouseProfilesAsync();
    }
}
