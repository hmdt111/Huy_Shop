using Microsoft.AspNetCore.Mvc;

namespace Do_An.Areas.Admin.Controllers
{
    public abstract class ControllerTemplateMethod : Controller
    {
        protected abstract void PrintRoutes();

        protected abstract void PrintDIs();

        public void PrintInformation()
        {
            PrintRoutes();
            PrintDIs();
        }
    }
}
