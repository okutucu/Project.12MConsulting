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


                int enrtyConvertDate = Convert.ToInt32((requestDto.EntryDate).ToOADate());
                int finishConvertDate = Convert.ToInt32((requestDto.FinishDate).ToOADate());

                SqlParameter entryDate = new("@BaslangicTarihi", SqlDbType.Int);
                entryDate.Value = enrtyConvertDate;
                SqlParameter finishDate = new ("@BitisTarihi", SqlDbType.Int);
                finishDate.Value = finishConvertDate;



                Stk stks = await context.Stks.FirstOrDefaultAsync(x => x.Id == requestDto.CommodityCodeId);

                var customFilterResults = context.FilterResults.FromSqlRaw("EXECUTE sp_GetByParameters @Malkodu @BaslangicTarihi @BitisTarihi", stks.MalKodu, entryDate, finishDate).ToList();

                return View(customFilterResults);
            }
        }
    }
}