namespace CompanyManagement.Web.Controllers
{
    using System.Web.Mvc;
    using Common.ViewModels;
    using Service.Contracts;
    using Service.Implementations;

    public class CompanyController : Controller
    {
        private ICompanyService _companyService;

        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = _companyService.GetAllCompanies();
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CompanyViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _companyService.CreateCompany(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var company = _companyService.GetCompanyById(id);

            return View(company);
        }

        [HttpPost]
        public ActionResult Edit(CompanyEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _companyService.EditComapny(model);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = _companyService.GetCompnyForDeletion(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(string answer, CompanyDeleteViewModel model)
        {
            switch (answer)
            {
                case "Yes":
                    _companyService.DeleteCompanyById(model.Id);
                    return RedirectToAction("Index");

                case "No":
                    return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}