using System.ComponentModel.DataAnnotations;

namespace EShopMashtiMahdi.Views.ViewModel.Products
{
    public class ProductAddViewEditModel
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage = "Please Enter The ProductName")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Product Must Between 3 and 100")]
        public string ProductName { get; set; }
        [Range(100, 10000000000, ErrorMessage = "Unit Price Must Betwee 100 and 10000000000")]
        public long UnitPrice { get; set; }
        [Required(ErrorMessage = "Please Enter The Slug")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Slug Must Betwee 3 and 100")]
        public string Slug { get; set; }
        [Required(ErrorMessage = "Please Enter PageTitle")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Page Title Must Betweem 3 and 100")]
        public string PageTitle { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public string JSONLDInformation { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }
        public IFormFile Image { get; set; }
    }
}
