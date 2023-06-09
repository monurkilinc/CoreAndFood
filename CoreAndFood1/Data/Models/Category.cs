using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace CoreAndFood1.Data.Model
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Category Name Is Not Empty!!!")]
        [StringLength(20, ErrorMessage = "Please only enter between 4-20 characters!", MinimumLength = 4)]
        public string? CategoryName { get; set; }

        [Required(ErrorMessage = "Category Description Is Not Empty!!!")]
        public string? CategoryDescription { get; set; }
        public List<Food>? Foods { get; set; }

        public bool Status { get; set; }
    }
}
