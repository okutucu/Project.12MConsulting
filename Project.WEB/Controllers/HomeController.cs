using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.WEB.DTOs;

namespace Project.WEB.Controllers
{
    public class HomeController : Controller
    {
        TestContext context = new TestContext();

        public HomeController()
        {

        }



        public async Task<IActionResult> Index()
        {
            List<Stk> stks = await context.Stks.ToListAsync();
            ViewBag.stks = new SelectList(stks, "Id", "MalKodu");

            return View();
        }

        public async Task<IActionResult> GetBySelected(RequestDto requestDto)
        {
            return View();
        }
    }
}
