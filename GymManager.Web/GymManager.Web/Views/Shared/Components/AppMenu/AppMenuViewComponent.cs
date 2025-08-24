
using GymManager.ApplicationServices.Navigation;
using GymManager.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GymManager.Web.Views.Shared.Components.AppMenu
{
    public class AppMenuViewComponent : ViewComponent
    {

        private readonly IMenuAppService _appMenuViewComponent;
        public AppMenuViewComponent(IMenuAppService menuAppService) {
            _appMenuViewComponent = menuAppService;
        }

        public IViewComponentResult Invoke(string currentPageName = null)
        {
            var model = new MenuViewModel {
                CurrentPageName = currentPageName,
                Menu = _appMenuViewComponent.GetMenu()
            };

            return View("Default", model);
        }
    }
}
