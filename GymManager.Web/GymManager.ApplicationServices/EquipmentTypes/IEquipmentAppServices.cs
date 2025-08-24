using GymManager.Core.EquipmentTypes;
using GymManager.Core.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.ApplicationServices.EquipmentTypes
{
    public interface IEquipmentAppServices
    {

        Task<List<EquipmentType>> GetAllEquipmentsAsync();

        Task<int> AddEquipmentAsync(EquipmentType equipment);

        Task DeleteEquipmentAsync(int equipmentId);

        Task EditEquipmentAsync(EquipmentType equipmentType);

        Task<EquipmentType> GetEquipmentAsync(int equipmentId);

    }
}
