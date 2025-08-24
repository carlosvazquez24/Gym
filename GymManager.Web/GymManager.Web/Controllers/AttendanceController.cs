using GymManager.ApplicationServices.Attendances;
using GymManager.ApplicationServices.Members;
using GymManager.Core.Attendances;
using GymManager.Core.Members;
using GymManager.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GymManager.Web.Controllers
{
    [Authorize]
    public class AttendanceController : Controller
    {
        private readonly IMembersAppServices _membersAppServices;
        private readonly IAttendancesAppServices _attendancesAppServices;

        public AttendanceController(IMembersAppServices membersAppServices, IAttendancesAppServices attendancesAppServices)
        {
            _membersAppServices = membersAppServices;
            _attendancesAppServices = attendancesAppServices;
        }

        public async Task<IActionResult> Index()
        {

            //Se obtienen las tablas de miembros y de asistencias
            var members = await _membersAppServices.getMembersAsync();
            var attendances = await _attendancesAppServices.getAttendancesAsync();

            //Consulta para saber los miembros que están afuera

            var query = from a in attendances
                        join subconsult in (
                            from sub in attendances
                            group sub by sub.Member.Id into g
                            select new
                            {
                                MaxDate = g.Max(x => x.Date),
                                MemberId = g.Key
                            }
                        ) on new { MemberId = a.Member.Id, Date = a.Date } equals new { MemberId = subconsult.MemberId, Date = subconsult.MaxDate }
                        select new
                        {
                            a.Id,
                            a.Date,
                            MemberId = a.Member.Id,
                            a.MovementType
                        };



            //Se crea la lista de los miembros que están adentro 
            var membersInside = new List<Member>();

            //Se van agregando los miembros que están dentro del gym 
            foreach (var memberIn in query)
            {
                if (memberIn.MovementType == "checkin")
                {
                    var member = await _membersAppServices.getMemberAsync(memberIn.MemberId);
                    membersInside.Add(member);
                }


            }

            // Se obtienen todos los miembros que no estén adentro. Es decir, los miembros que están en members pero que no están en membersInside
            var membersOutside = members.Except(membersInside).ToList(); //Esto incluye a los miembros nuevos


            AttendanceViewModel viewModel = new AttendanceViewModel();

            viewModel.MembersOutside = membersOutside;

            return View(viewModel);
        }

        public async Task<IActionResult> MemberIn()
        {

            //Se obtienen las tablas de miembros y de asistencias
            var members = await _membersAppServices.getMembersAsync();
            var attendances = await _attendancesAppServices.getAttendancesAsync();

            //Consulta para saber los miembros que están afuera

            var query = from a in attendances
                                    join subconsult in (
                                        from sub in attendances
                                        group sub by sub.Member.Id into g
                                        select new
                                        {
                                            MaxDate = g.Max(x => x.Date),
                                            MemberId = g.Key
                                        }
                                    ) on new { MemberId = a.Member.Id, Date = a.Date } equals new { MemberId = subconsult.MemberId, Date = subconsult.MaxDate }
                                    select new
                                    {
                                        a.Id,
                                        a.Date,
                                        MemberId = a.Member.Id,
                                        a.MovementType
                                    };



            //Se crea la lista de los miembros que están adentro 
            var membersInside = new List<Member>();

            //Se van agregando los miembros que están dentro del gym 
            foreach (var memberIn in query)
            {
                if(memberIn.MovementType == "checkin")
                {
                    var member = await _membersAppServices.getMemberAsync(memberIn.MemberId);
                    membersInside.Add(member);
                }

                
            }

            // Se obtienen todos los miembros que no estén adentro. Es decir, los miembros que están en members pero que no están en membersInside
            var membersOutside = members.Except(membersInside).ToList(); //Esto incluye a los miembros nuevos


            AttendanceViewModel viewModel = new AttendanceViewModel();

            viewModel.MembersOutside = membersOutside;

            return View(viewModel);

        }


        public async Task<IActionResult> MemberOut()
        {
            //Se obtienen las tablas de miembros y de asistencias
            var members = await _membersAppServices.getMembersAsync();
            var attendances = await _attendancesAppServices.getAttendancesAsync();

            //Consulta para saber los miembros que están adentro

            var query = from a in attendances
                        join subconsult in (
                            from sub in attendances
                            group sub by sub.Member.Id into g
                            select new
                            {
                                MaxDate = g.Max(x => x.Date),
                                MemberId = g.Key
                            }
                        ) on new { MemberId = a.Member.Id, Date = a.Date } equals new { MemberId = subconsult.MemberId, Date = subconsult.MaxDate }
                        select new
                        {
                            a.Id,
                            a.Date,
                            MemberId = a.Member.Id,
                            a.MovementType
                        };



            //Se crea la lista de los miembros que están adentro  y pueden salir
            var membersInside = new List<Member>();

            //Se van agregando los miembros que están adentro del gym a la lista a devolver
            foreach (var memberIn in query)
            {
                if (memberIn.MovementType == "checkin")
                {
                    var member = await _membersAppServices.getMemberAsync(memberIn.MemberId);
                    membersInside.Add(member);
                }


            }


            AttendanceViewModel viewModel = new AttendanceViewModel();

            viewModel.MembersInside = membersInside;

            return View(viewModel);

        }

        public async Task<IActionResult> Check([FromBody] AttendanceViewModel viewModel)
        {

            Attendance attendance = new Attendance
            {
                Date = DateTime.Now,
                Member = new Member
                {
                    Id = viewModel.IdMember
                },
                MovementType = viewModel.Movement

            };
            await _attendancesAppServices.addAttendanceAsync(attendance);

            var respuesta = new { mensaje = "" };

            if(viewModel.Movement == "checkin")
            {
                 respuesta = new { mensaje = "The check in has been registered" };

            }else if(viewModel.Movement == "checkout")
            {
                 respuesta = new { mensaje = "The check out has been registered" };

            }
            else
            {
                respuesta = new { mensaje = "Error" };
            }



            return Json(respuesta);

        }


    }
}
