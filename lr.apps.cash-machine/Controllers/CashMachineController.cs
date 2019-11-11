using lr.libs.cash_machine.Models;
using lr.libs.cash_machine.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace lr.apps.cash_machine.Controllers
{
    public class CashMachineController : Controller
    {
        private readonly ICashMachineService _service;

        public CashMachineController(ICashMachineService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NoteView(WithdrawResponse request)
        {
            return View(request);
        }

        [HttpGet]
        public IActionResult Withdraw()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Withdraw(WithdrawRequest request)
        {
            return this.Handle(
                request: request,
                response: _service.Withdraw(request)
            );
        }
    }
}