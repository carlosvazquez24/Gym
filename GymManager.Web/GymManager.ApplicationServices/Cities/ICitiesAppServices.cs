using GymManager.Core.Cities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.ApplicationServices.Cities
{
    public interface ICitiesAppServices
    {
        Task<List<City>> getCitiesAsync();

        Task<City> getCityAsync(int cityId);

    }
}
