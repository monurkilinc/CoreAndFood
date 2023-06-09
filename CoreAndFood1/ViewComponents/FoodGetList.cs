using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAndFood1.Repositories;
using Microsoft.AspNetCore.Mvc;

//special offer kısmında ürün listelemek için

namespace CoreAndFood1.ViewComponents
{
	public class FoodGetList:ViewComponent
	{
		public IViewComponentResult Invoke() 
		
		{
			FoodRepository foodRepository= new FoodRepository();

			var foodlist = foodRepository.TList();
			return View(foodlist);
		
		}

	}
}
