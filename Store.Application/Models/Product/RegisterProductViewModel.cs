using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Store.Application.Models.Product
{
    public class RegisterProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsPerishable { get; set; }
        public int CategoryProductId { get; set; }

        public IList<SelectListItem> ProductsCategoriesSelectList { get; set; }
    }
}
