﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAndFood1.Repositories;
using Microsoft.AspNetCore.Mvc;
using CoreAndFood1.Data.Model;
using Microsoft.AspNetCore.Authorization;

namespace CoreAndFood1.Controllers
{
    public class CategoryController : Controller
    {
        CategoryRepository categoryRepository = new CategoryRepository();

        //[Authorize]
        public IActionResult Index(string p)
        {
            //arama işlemi için yazıldı
            if (!string.IsNullOrEmpty(p)) 
            {
                return View(categoryRepository.List(x => x.CategoryName == p));
            }
            return View(categoryRepository.TList());

        }
        [HttpGet]
        public IActionResult CategoryAdd() 
        {
            return View();
        
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            if(!ModelState.IsValid)
            {
                return View("CategoryAdd");
            }
            categoryRepository.TAdd(p);
            return RedirectToAction("Index");

        }
        public IActionResult CategoryGet(int id)
        {
            var x = categoryRepository.TGet(id);
            Category ct = new Category()
            {
                CategoryName = x.CategoryName,
                CategoryDescription = x.CategoryDescription,
                CategoryID= x.CategoryID,
            };
            return View(ct);

        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category p) 
        {
            var x=categoryRepository.TGet(p.CategoryID);
            x.CategoryName= p.CategoryName;
            x.CategoryDescription= p.CategoryDescription;
            x.Status = true;
            categoryRepository.TUpdate(x);
            return RedirectToAction("Index");       
        }

        public IActionResult CategoryDelete(int id) 
        { 
              categoryRepository.TDelete(new Category {CategoryID=id });
              return RedirectToAction("Index");
        
        }
    }
}
