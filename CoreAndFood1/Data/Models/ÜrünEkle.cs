using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace CoreAndFood1.Data.Models
{
    public class ÜrünEkle
    {
        public int FoodID { get; set; }
        public string? FoodName { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public IFormFile ImageURL { get; set; }
        public int Stock { get; set; }
        public int CategoryID { get; set; }


    }
}
