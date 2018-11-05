namespace CompanyManagement.Web.Controllers
{
    using System.Web.Mvc;
    using Common.ViewModels;
    using Service.Contracts;
    using Service.Implementations;

    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public ActionResult Index(int id)
        {
            var model = _employeeService.GetAllEmployeesByCompanyId(id);
            if (model != null)
            {
                return View(model);
            }
            return RedirectToAction("Add");
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View("Add");
        }

        [HttpPost]
        public ActionResult Add(EmployeeAddViewModel model, int id)
        {
            model.CompanyId = id;
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _employeeService.AddEmployee(model);

            return RedirectToAction("Index", new { id = model.CompanyId });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = _employeeService.GetEmployeeById(id);
            
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Edit(EmployeeEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }
            _employeeService.EditEmployee(model);

            return RedirectToAction("Index", new { id = model.CompanyId });
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = _employeeService.GetEmployeeForDeletion(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(string answer, EmployeeDeleteViewModel model)
        {
            switch (answer)
            {
                case "Yes":
                    _employeeService.DeleteById(model.Id);
                    return RedirectToAction("Index", new { id = model.CompanyId });

                case "No":
                    return RedirectToAction("Index", new { id = model.CompanyId });
            }
            return RedirectToAction("Index", new { id = model.CompanyId });
        }
    }
}