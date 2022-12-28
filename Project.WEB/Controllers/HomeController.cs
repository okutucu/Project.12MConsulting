using System;
using System.Data;
using System.Diagnostics.Metrics;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Project.WEB.DTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Project.WEB.Controllers
{
    public class HomeController : Controller
    {
        

        public HomeController()
        {
        }


        public async Task<IActionResult> Index()
        {
            using (var context = new TestContext())
            {

                List<Stk> stks = await context.Stks.ToListAsync();
                ViewBag.stks = new SelectList(stks, "Id", "MalKodu");

                return View();
            }
          
        }

        public async Task<IActionResult> GetBySelected(RequestDto requestDto)
        {
            using (var context = new TestContext())
            {

                Stk stks = await context.Stks.FirstOrDefaultAsync(x => x.Id == requestDto.CommodityCodeId);
 

                int enrtyConvertDate = Convert.ToInt32((requestDto.EntryDate).ToOADate());
                int finishConvertDate = Convert.ToInt32((requestDto.FinishDate).ToOADate());

      

                var data = await context.FilterResults.FromSqlRaw($"EXEC dbo.sp_GetByParameters @Malkodu = {stks.MalKodu}, @BaslangicTarihi = {enrtyConvertDate}, @BitisTarihi = {finishConvertDate}").ToListAsync();

                return View(data);
            }
        }
    }
}