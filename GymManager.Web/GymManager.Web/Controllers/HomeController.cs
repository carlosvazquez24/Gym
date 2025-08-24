using GymManager.ApplicationServices.Members;
using GymManager.Core.Members;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManager.Web.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private readonly IMembersAppServices _membersAppServices;

        public HomeController(IMembersAppServices membersAppServices) {
            _membersAppServices= membersAppServices;
        }

        public async Task<IActionResult> Index()
        {
            List<Member> members = await _membersAppServices.getMembersAsync();
            return View(members);
        }


    }
}
