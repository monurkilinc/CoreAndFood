using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAndFood1.Data;
using CoreAndFood1.Data.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood1.Controllers
{	
    [AllowAnonymous]
    //Chartların Login İşlemine Gerek Olmadan Giriş Yapılması İçin
    public class ChartController : Controller
    {
	
		public IActionResult Index()
        {
            return View();
        }
		
		public IActionResult Index2()
        {
            return View();
        }
        public IActionResult VisualizeProductResult()
        {
            return Json(ProList());
        }
        public List<Class1> ProList()
        { 
            List<Class1>cs=new List<Class1>();
            cs.Add(new Class1()
            {
                proname = "Computer",
                stock = 150
            });
            cs.Add(new Class1()
            {
                proname = "Lcd",
                stock = 75
            });
            cs.Add(new Class1()
            {
                proname = "Usb Disk",
                stock = 250

            });
            return cs;
        }

        
        public IActionResult Index3()
        {
            return View();
        }
        public IActionResult VisualizeProductResult2()
        {
            return Json(FoodsList());
        }
        public List<Class2> FoodsList()
        {
            List<Class2> cs2=new List<Class2>();
            using(var c=new Context())
            {
                cs2=c.Foods.Select(x=> new Class2() 
                {
                    foodname=x.FoodName,
                    stock=x.Stock
                
                }).ToList();
                return cs2;
            }
        }

        public IActionResult Statistic()
        {
            Context c=new Context();
            var deger1 = c.Foods.Count();
            ViewBag.d1 = deger1;

            var deger2=c.Categories.Count();
            ViewBag.d2 = deger2;

            var foid = c.Categories.Where(x => x.CategoryName == "Fruit").Select(y=>y.CategoryID).FirstOrDefault();
            ViewBag.d = foid;

            var deger3=c.Foods.Where(x=>x.CategoryID==foid).Count();
            ViewBag.d3 = deger3;

            var deger4 = c.Foods.Where(x => x.CategoryID == c.Categories.Where(z => z.CategoryName == "Vegetables").Select(y => y.CategoryID).FirstOrDefault()).Count();
            ViewBag.d4 = deger4;

            var deger5 = c.Foods.Sum(x => x.Stock);
            ViewBag.d5 = deger5;
            
            var deger6=c.Foods.Where(x=>x.CategoryID==c.Categories.Where(z=>z.CategoryName=="Legumes").Select(y=>y.CategoryID).FirstOrDefault()).Count();
            ViewBag.d6 = deger6;

            var deger7=c.Foods.OrderByDescending(x=>x.Stock).Select(y=>y.FoodName).FirstOrDefault();
            ViewBag.d7 = deger7;

            var deger8 = c.Foods.OrderBy(x => x.Stock).Select(y => y.FoodName).FirstOrDefault();
            ViewBag.d8 = deger8;

            var deger9 = c.Foods.Average(x => x.Price).ToString("0.00");
            ViewBag.d9 = deger9;

            var deger10=c.Foods.OrderBy(x=>x.Price).Select(y=>y.Price).FirstOrDefault();
            ViewBag.d10= deger10;

            var deger11 = c.Foods.OrderBy(x => x.Price).Select(y => y.FoodName).FirstOrDefault();
            ViewBag.d11= deger11;

            var deger12 = c.Foods.OrderByDescending(x => x.Price).Select(y => y.Price).FirstOrDefault();
            ViewBag.d12= deger12;

            var deger13 = c.Foods.OrderByDescending(x => x.Price).Select(y => y.FoodName).FirstOrDefault();
            ViewBag.d13= deger13;

            var deger14 = c.Categories.Where(x => x.CategoryName == "Fruit").Select(y => y.CategoryID).FirstOrDefault();
            var deger14p=c.Foods.Where(y=>y.CategoryID==deger14).Sum(x=>x.Stock);
            ViewBag.d14 = deger14p;

            var deger15=c.Categories.Where(x=>x.CategoryName=="Vegetables").Select(y=>y.CategoryID).FirstOrDefault();
            var deger15p=c.Foods.Where(y=>y.CategoryID==deger15).Sum(x=>x.Stock);
            ViewBag.d15 = deger15p;

            var deger16 = c.Categories.Where(x => x.CategoryName == "Legumes").Select(y => y.CategoryID).FirstOrDefault();
            var deger16p=c.Foods.Where(x=>x.CategoryID==deger16).Sum(x=>x.Stock);   
            ViewBag.d16= deger16p;

            return View(); 
        
        }
    }
}
