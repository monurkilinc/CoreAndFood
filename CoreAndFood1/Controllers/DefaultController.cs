using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

//Web Site Teması için eklendi

namespace CoreAndFood1.Controllers
{
	public class DefaultController : Controller
	{
		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}
		[AllowAnonymous]
		public IActionResult CategoryDetails(int id)
		{
			ViewBag.x= id;
			return View(); }
	}
}
