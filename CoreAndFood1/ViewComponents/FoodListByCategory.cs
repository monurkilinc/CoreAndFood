using CoreAndFood1.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoreAndFood1.ViewComponents
{
	public class FoodListByCategory:ViewComponent 
	{
		public IViewComponentResult Invoke(int id)

		{
			//Ürünleri id degerine göre listelemek için kullandık
			FoodRepository foodRepository = new FoodRepository();

			var foodlist = foodRepository.List(x=>x.CategoryID==id);
			return View(foodlist);

		}
	}
}
