using AssignmentSigortamNet.Data;
using AssignmentSigortamNet.Integration;
using AssignmentSigortamNet.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AssignmentSigortamNet.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerService _customerService;
        public HomeController()
        {
            _customerService = new CustomerService();
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult GetCustomer(Guid customerId)
        {
            return View(_customerService.GetCustomer(customerId));
        }
        [HttpGet]
        public IActionResult AllCustomer()
        {
            return View(_customerService.GetAllCustomer());
        }
        [HttpGet]
        public IActionResult SearchCustomer()
        {
            return View(new SearchCustomerViewModel());
        }

        [HttpPost]
        public IActionResult SearchCustomer(SearchCustomerViewModel model)
        {
            model.Result = _customerService.SearchCustomer(model.FirstName, model.LastName, model.NationalIdNumber);
            return View(model);
        }

        [HttpGet]
        public IActionResult AddCustomer()
        {
            return View(new AddCustomerViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddCustomerViewModel model)
        {
            var result = _customerService.AddCustomer(model.Customer);

            return View(new AddCustomerViewModel
            {
                Customer = result.Data,
                ActionResult = new Result { IsSuccess = result.IsSuccess, Message = result.Message }
            });
        }
        public IActionResult DeleteCustomer(Guid customerId)
        {
            return View(_customerService.DeleteCustomer(customerId));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
