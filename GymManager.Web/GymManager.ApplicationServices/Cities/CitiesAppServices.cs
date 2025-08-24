using GymManager.Core.Members;
using GymManager.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GymManager.Core.Cities;

namespace GymManager.ApplicationServices.Cities
{
    public class CitiesAppServices : ICitiesAppServices
    {

        private readonly IRepository<int, City> _repository;

        public CitiesAppServices(IRepository<int, City> repository)
        {

            _repository = repository;

        }


        public async Task<City> getCityAsync(int cityId)
        {
            return await _repository.GetAsync(cityId);
        }

        public async Task<List<City>> getCitiesAsync()
        {

            return await _repository.GetAllAsync().ToListAsync();
        }
    }
}
