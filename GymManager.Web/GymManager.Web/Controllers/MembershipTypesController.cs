using GymManager.ApplicationServices.MembershipsTypes;
using GymManager.Core.MembershipsTypes;
using GymManager.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymManager.Web.Controllers
{
    [Authorize]
    public class MembershipTypesController : Controller
    {
        private readonly IMembershipTypeAppService _membershipAppService;
        public MembershipTypesController(IMembershipTypeAppService membershipAppService) {
            _membershipAppService= membershipAppService;
        }


        public async Task<IActionResult> Index()
        {

            var memberships = await _membershipAppService.GetAllMembershipsTypesAsync();
            MembershipTypeListModel model = new MembershipTypeListModel();
            model.Memberships = memberships;

            return View(model);
        }

        public IActionResult Create() {
            return View();
        }

        public async Task<IActionResult> Edit(int membershipId)
        {
            MembershipType membership = await  _membershipAppService.GetMembershipTypeAsync(membershipId);
            return View(membership);
        }


        public async Task <IActionResult> Delete(int membershipId)
        {
            await _membershipAppService.DeleteMembershipTypeAsync(membershipId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async  Task<IActionResult> Create(MembershipType membership)
        {
            await _membershipAppService.AddMembershipTypeAsync(membership);
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async  Task<IActionResult> Edit (MembershipType membership)
        {
            await _membershipAppService.EditMembershipTypeAsync(membership);
            return RedirectToAction("Index");
        }
        
    }
}
