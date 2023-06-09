using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAndFood1.Repositories;
using Microsoft.AspNetCore.Mvc;

//Layout değil!!!

namespace CoreAndFood1.ViewComponents

{
	public class CategoryGetList : ViewComponent
	{
		public IViewComponentResult Invoke() 
		{
			CategoryRepository categoryRepository= new CategoryRepository();
			var categorylist = categoryRepository.TList();
			return View(categorylist);
		}


	}
}
