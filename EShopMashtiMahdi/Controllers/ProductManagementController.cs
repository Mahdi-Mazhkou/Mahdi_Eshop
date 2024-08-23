using EShopMashtiMahdi.Views.ViewModel.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shoping.DomainModel.BusinessModel.Category;
using Shoping.DomainModel.BusinessModel.Product;
using Shoping.DomainModel.Models;
using Shopping.ApplicationServiceContract.Service;

namespace EShopMashtiMahdi.Controllers
{
    public class ProductManagementController : Controller
    {
        private readonly ISupplierApplication supplier;
        private readonly ICategoryApplication category;
        private readonly IProductApplication product;
        #region DataLoaders
        private void InflateCategorydrp()
        {
            var cats = category.GetDrp();
            cats.Insert(0, new FastCatList { CategoryID = -1, CategoryName = "...Please Select..." });
            SelectList categoryDropDown = new SelectList(cats, "CategoryID", "CategoryName");
            ViewBag.CategoryDropDown = categoryDropDown;
        }
        private void InflateSupplierdrp()
        {
            var sup = supplier.GetAll();
            sup.Insert(0, new Supplier { SupplierID = -1, SupplierName = "...Please Select..." });
            SelectList supplierDropDown = new SelectList(sup, "SupplierID", "SupplierName");
            ViewBag.supplierDropDown = supplierDropDown;

        }
        #endregion
        public ProductManagementController(ISupplierApplication supplier, ICategoryApplication category, IProductApplication product)
        {
            this.supplier = supplier;
            this.category = category;
            this.product = product;
        }
        public IActionResult Index(ProductSearchModel sm)
        {
            InflateCategorydrp();
            InflateSupplierdrp();
            return View(sm);
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var op = product.Remove(id);
            return Json(op);
        }
        public IActionResult search(ProductSearchModel sm)
        {
            return ViewComponent("ProductList", sm);
        }

        public IActionResult AddNew()
        {
            InflateCategorydrp();
            InflateSupplierdrp();
            return View();
        }
        [HttpPost]
        public IActionResult AddNew(ProductAddViewEditModel prod)
        {
           
            return View();
        }

    }
}
