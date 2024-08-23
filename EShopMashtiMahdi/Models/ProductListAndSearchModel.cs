using Shoping.DomainModel.BusinessModel.Product;

namespace EShopMashtiMahdi.Models
{
    public class ProductListAndSearchModel
    {
        public ProductSearchModel sm { get; set; }
        public List<ProductListItem> productListItems  { get; set; }
    }
}
