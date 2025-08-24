using GymManager.ApplicationServices.Cities;
using GymManager.ApplicationServices.Members;
using GymManager.ApplicationServices.MembershipsTypes;
using GymManager.Core.Cities;
using GymManager.Core.Members;
using GymManager.Core.MembershipsTypes;
using GymManager.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace GymManager.Web.Controllers
{

    [Authorize]

    public class MembersController : Controller
    {
        private readonly IMembersAppServices _membersAppServices;
        private readonly ICitiesAppServices _citiesAppServices;
        private readonly IMembershipTypeAppService _membershipTypeAppServices;

        private readonly ILogger<MembersController> _logger;

        public MembersController(
            IMembersAppServices membersAppServices, 
            ILogger<MembersController> logger1, 
            ICitiesAppServices citiesAppServices,
            IMembershipTypeAppService membershipTypeAppService)
        {

            _membersAppServices = membersAppServices;
            _citiesAppServices = citiesAppServices;
            _membershipTypeAppServices = membershipTypeAppService;


            _logger = logger1;
        }
        public async Task<IActionResult> Index(string buscar)
        {
            _logger.LogInformation("-----------------------------------------------------------");
            _logger.LogInformation("***********  Now you are in the Members Index   ***********");
            _logger.LogInformation("-----------------------------------------------------------");


            var members = await _membersAppServices.getMembersAsync();

            if (!String.IsNullOrEmpty(buscar))
            {

                buscar = buscar.ToLower();

                // Filtrar los miembros según el criterio de búsqueda
                members = members.Where(x => x.Name!.ToLower().Contains(buscar) || x.LastName!.ToLower().Contains(buscar)).ToList();

            }

            //Crear objeto de tipo lista de mimebros para la vista
            MemberListViewModel viewModel = new MemberListViewModel();

            //Se obtiene el número de miembros
            viewModel.NewMembersCount = members.Count;

            //Se le asigna la lista de miembros de la bdd a la lista del objeto viewModel
            viewModel.Members = members;
            return View(viewModel);

        }

        public async Task<IActionResult> Edit(int memberId)
        {
            Member member = await _membersAppServices.getMemberAsync(memberId);

            var cities = await _citiesAppServices.getCitiesAsync();

            var memberships = await _membershipTypeAppServices.GetAllMembershipsTypesAsync();



            MemberViewModel miembroTransformado = new MemberViewModel
            {
                Id = member.Id,
                Name = member.Name,
                LastName = member.LastName,
                BirthDay = member.BirthDay,
                Email = member.Email,
                CityId = member.City.Id,
                MembershipTypeId = member.MembershipType.Id,
                Cities = cities       ,
                MembershipTypes = memberships

            };

            return View(miembroTransformado);
        }

        public async Task<IActionResult> Create()
        {
            // Obtener las listas de las ciudades
            var cities = await _citiesAppServices.getCitiesAsync();

            var memberships = await _membershipTypeAppServices.GetAllMembershipsTypesAsync();

            //Crear el objeto del modelo 
            MemberViewModel memberModel = new MemberViewModel();

            // y asignarle las lista de las ciudades al atributo del objeto
            memberModel.Cities = cities;
            memberModel.MembershipTypes = memberships;

            //Mandar modelo a la vista
            return View(memberModel);
        }

        public async Task<IActionResult> Delete(int memberId)
        {
            await _membersAppServices.deleteMemberAsync(memberId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Create(MemberViewModel model)
        {
            Member member = new Member
            {
                //Id = model.Id,
                Name = model.Name,
                LastName = model.LastName,
                BirthDay = model.BirthDay,
                Email = model.Email,
                AllowNewsletter = model.AllowNewsletter,
                City = new City
                {
                    Id = model.CityId
                },
                MembershipType = new MembershipType
                {
                    Id = model.MembershipTypeId
                }
            };
            await _membersAppServices.addMemberAsync(member);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Edit(MemberViewModel model)
        {
            Member member = new Member
            {
                Id = model.Id,
                Name = model.Name,
                LastName = model.LastName,
                BirthDay = model.BirthDay,
                Email = model.Email,
                AllowNewsletter = model.AllowNewsletter,
                City = new City
                {
                    Id = model.CityId
                },
                MembershipType = new MembershipType
                {
                    Id = model.MembershipTypeId
                }
            };
            await _membersAppServices.editMemberAsync(member);
            return RedirectToAction("Index");
        }


        public IActionResult Test()
        {
            return View();
        }
    }
}

