using GymManager.ApplicationServices.EquipmentTypes;
using GymManager.Core.EquipmentTypes;
using GymManager.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManager.Web.Controllers
{
    [Authorize]

    public class EquipmentTypesController : Controller
    {

        private readonly IEquipmentAppServices _equipmentAppServices;

        public EquipmentTypesController(IEquipmentAppServices equipmentAppServices)
        {
            _equipmentAppServices= equipmentAppServices;

        }

        public async Task<IActionResult> Index()
        {
            //Obtener la lista de los equipos del gimnasio
            var list = await _equipmentAppServices.GetAllEquipmentsAsync();

            //Crear el objeto del modelo y asignarle la lista
            EquipmentListModel equipmentListModel = new EquipmentListModel();
            equipmentListModel.EquipmentTypes = list;


            return View(equipmentListModel);
        }

        public async Task<IActionResult> Edit(int equipmentId)
        {
            EquipmentType equipment = await _equipmentAppServices.GetEquipmentAsync(equipmentId);

            return View(equipment);

        }

        public async Task<IActionResult> Delete(int equipmentId)
        {
            await _equipmentAppServices.DeleteEquipmentAsync(equipmentId);
            return RedirectToAction("Index");

        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EquipmentType equipmentType)
        {
            await _equipmentAppServices.AddEquipmentAsync(equipmentType);
            return RedirectToAction("Index");

        }


        [HttpPost]
        public async Task<IActionResult> Edit(EquipmentType equipmentType)
        {
            await _equipmentAppServices.EditEquipmentAsync(equipmentType);
            return RedirectToAction("Index");
        }



    }
}
