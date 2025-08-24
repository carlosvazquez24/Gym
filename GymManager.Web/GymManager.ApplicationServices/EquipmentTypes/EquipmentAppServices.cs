using GymManager.Core.EquipmentTypes;
using GymManager.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.ApplicationServices.EquipmentTypes
{
    public class EquipmentAppServices : IEquipmentAppServices
    {
        private readonly IRepository<int, EquipmentType> _repository;

        public EquipmentAppServices(IRepository<int, EquipmentType> repository)
        {
            _repository= repository;
        }

        public async Task<int> AddEquipmentAsync(EquipmentType equipment)
        {
            await _repository.AddAsync(equipment);
            return equipment.Id;
        }

        public async Task DeleteEquipmentAsync(int equipmentId)
        {
            await _repository.DeleteAsync(equipmentId);
        }

        public async Task EditEquipmentAsync(EquipmentType equipmentType)
        {
            await _repository.UpdateAsync(equipmentType);

        }

        public async Task<List<EquipmentType>> GetAllEquipmentsAsync()
        {
            var list = await _repository.GetAllAsync().ToListAsync();
            return list;
        }

        public async Task<EquipmentType> GetEquipmentAsync(int equipmentId)
        {
            var entity = await _repository.GetAsync(equipmentId);
            return entity;
        }
    }
}
