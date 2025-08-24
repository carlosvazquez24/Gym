using GymManager.ApplicationServices.Members;
using GymManager.ApplicationServices.MembershipRenewal;
using GymManager.ApplicationServices.MembershipsTypes;
using GymManager.Core.Members;
using GymManager.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text;

namespace GymManager.Web.Controllers
{
    [Authorize]
    public class MembershipRenewalController : Controller
    {
        
        private readonly IMembersAppServices _membersAppServices;
        private readonly IMembershipTypeAppService _membershipTypeAppService;
        private readonly IMembershipRenewalAppServices _membershipRenewalAppServices;

        public MembershipRenewalController(IMembersAppServices membersAppServices,
            IMembershipTypeAppService membershipTypeAppService,
            IMembershipRenewalAppServices membershipRenewalAppServices)
        {
            _membersAppServices= membersAppServices;
            _membershipTypeAppService = membershipTypeAppService;
            _membershipRenewalAppServices = membershipRenewalAppServices;
        }


        public async Task<IActionResult> IndexAsync(string buscar)
        {

            //Obtener las listas de members y memberships de la base de datos
            var members = await _membersAppServices.getMembersAsync();
            var memberships = await _membershipTypeAppService.GetAllMembershipsTypesAsync();

            //Hacer el inner join con consulta de linq
            var membersWithMemberships = from memb in members
                                         join ships in memberships
                                         on memb.MembershipType.Id equals ships.Id
                                         select new
                                         {
                                             MemberId = memb.Id,
                                             MemberName = memb.Name,
                                             MemberLastName = memb.LastName,
                                             MembershipId = ships.Id,
                                             MembershipName = ships.Name,
                                             MembershipDuration = ships.Duration   ,
                                             MembershipExpirationDate = memb.MembershipExpirationDate
                                         };
            Console.WriteLine(membersWithMemberships);


            //Crear una vista temporal que nos servirá para añadir los elementos
            var lista = new List<MembershipRenewalViewModel>();

            //Recorrer la lista creada de linq
            foreach (var element in membersWithMemberships)
            {
                //Por cada registro se creará un nuevo elemento de la clase MembershipRenewalViewModel
                MembershipRenewalViewModel newElement = new MembershipRenewalViewModel()
                {
                    MemberId = element.MemberId,
                    MembershipId = element.MembershipId,
                    MemberName = element.MemberName,
                    MemberLastName = element.MemberLastName,
                    MembershipName = element.MembershipName,
                    MembershipDuration = element.MembershipDuration,
                    MembershipTypes = memberships   ,
                    MembershipExpirationDate = element.MembershipExpirationDate

                };


                //Se añadirá el elemento a la lista
                lista.Add(newElement);
            }

            //Se crea un objeto de la clase MembershipRenewalListModel
            MembershipRenewalListModel model = new MembershipRenewalListModel();

            //Si hay un string en el buscador, se filtrarán los resultados de acuerdo a lo que usuario ingresó, buscando entre el nombre y apellido
            if (!String.IsNullOrEmpty(buscar))
            {
                //Las palabras que el usuario ingresó se vuelven mínusculas y se quitán acentos
                buscar = buscar.ToLower();
                buscar = buscar.Replace("á","a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u");

                //Se filtra la lista con el valor que se le ingresó (buscar)
                lista = lista.Where(x => x.MemberName!.ToLower().Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Contains(buscar)  || 
                x.MemberLastName!.ToLower().Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Contains(buscar)).ToList();
            }

            //Se le asigna la lista a la lista que tiene el modelo MembershipRenewalList 
            model.MembershipRenewalList = lista;

            //Se manda el modelo a la vista
            return View(model);
        }
        
        public async Task <IActionResult> Edit(int memberId)
        {
            var memberships = await _membershipTypeAppService.GetAllMembershipsTypesAsync(); //Obtener la lista de membresias

            var member = await _membersAppServices.getMemberAsync(memberId); //Obtener miembro por id

            MembershipRenewalViewModel memberModel = new MembershipRenewalViewModel(); 

            //Asignarle los atributos del miembro al nuevo objeto del modelo MembershipRenewalViewModel
            memberModel.MemberName = member.Name;
            memberModel.MemberLastName = member.LastName;
            memberModel.MemberId = memberId;

            memberModel.MembershipExpirationDate = member.MembershipExpirationDate;


            //Obtener la membresia del miembro que se editó, buscando entre las listas de miembros de cada membresia
            var membershipMatch = memberships.Where(x => x.Members.Any(x => x.Id == memberId)).FirstOrDefault();

            //Asignarle los atributos de la membresia qdel miembro al nuevo objeto del modelo
            memberModel.MembershipId = membershipMatch.Id;

            memberModel.MembershipName = membershipMatch.Name;

            memberModel.MembershipDuration = membershipMatch.Duration;

            memberModel.MembershipTypes = memberships;

            //Mandar el objeto a la vista para que sólo pueda editar el ID de la membresia mediante el nombre
            return View(memberModel);
        }


        [HttpPost]

        public async Task<IActionResult> Edit (MembershipRenewalViewModel membershipRenewalModel)
        {
            //Obtener el miembro a actualizar 
            var memberToUpdate =await _membersAppServices.getMemberAsync(membershipRenewalModel.MemberId);

            //Actualizar la fecha de renovación

            memberToUpdate.MembershipExpirationDate = DateTime.Now.AddMonths(membershipRenewalModel.MembershipDuration);

            //Asignarle la nueva membresia a actualizar
            memberToUpdate.MembershipType = await _membershipTypeAppService.GetMembershipTypeAsync(membershipRenewalModel.MembershipId);

            //Actualizar la entidad mediante los métodos de Repository
            await _membershipRenewalAppServices.editMemberAsync(memberToUpdate);

            //Redireccionar al Index
            return RedirectToAction("Index");

        }

    }
}
