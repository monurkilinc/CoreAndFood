using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using CoreAndFood1.Data.Model;
using CoreAndFood1.Data.Models;
using CoreAndFood1.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace CoreAndFood1.Controllers
{
    public class FoodController : Controller
    {
        FoodRepository foodRepository = new FoodRepository();
        Context c=new Context();
        public IActionResult Index(int page=1)
        {
           
            return View(foodRepository.TList("Category").ToPagedList(page,5));
           
        }
        [HttpGet]
        public IActionResult AddFood() 
        {
            List<SelectListItem> values = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString(),

                                           }).ToList();
            ViewBag.v1 = values;
            return View();
        }
        [HttpPost]
        
        //Dosya secerek resim ekleme işlemi için düzenlendi
       public IActionResult AddFood(ÜrünEkle p)
        {
            Food f=new Food();
            if(p.ImageURL!= null) 
            {
                var extension = Path.GetExtension(p.ImageURL.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/resimler/",newimagename);
                var stream=new FileStream(location,FileMode.Create);
                p.ImageURL.CopyTo(stream);  
                f.ImageURL=newimagename;
            }
            f.FoodName=p.FoodName;
            f.Price= p.Price;
            f.Stock= p.Stock;
            f.CategoryID=p.CategoryID;
            f.Description= p.Description;
            foodRepository.TAdd(f);
            return RedirectToAction("Index");
        
        }
        
        public IActionResult GetFood(int id)

        {
            var x = foodRepository.TGet(id);
            List<SelectListItem> values = (from y in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = y.CategoryName,
                                               Value = y.CategoryID.ToString(),

                                           }).ToList();
            ViewBag.v1 = values;
            
            Food ct = new Food()
            {
                FoodID= x.FoodID,
                FoodName = x.FoodName,
                Price = x.Price,
                Stock = x.Stock,
                CategoryID = x.CategoryID,
                Description= x.Description,
                ImageURL= x.ImageURL,
            };
            return View(ct);

        }



        public IActionResult DeleteFood(int id) 
        {
            foodRepository.TDelete(new Food { FoodID=id});
            return RedirectToAction("Index","Food");
        }
        [HttpPost]
        public IActionResult UpdateFood(Food p)
        {
            var x = foodRepository.TGet(p.FoodID);

            x.FoodName = p.FoodName;
            x.Stock = p.Stock;
            x.Price = p.Price;
            x.ImageURL = p.ImageURL;
            x.Category = p.Category;
            x.Description = p.Description;
            x.CategoryID = p.CategoryID;

            foodRepository.TUpdate(x);
            return RedirectToAction("Index");
        }

    }
}
