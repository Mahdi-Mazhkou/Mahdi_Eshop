using EShopMashtiMahdi.Models;
using Microsoft.AspNetCore.Mvc;
using Shoping.DomainModel.BusinessModel.Product;
using Shopping.ApplicationServiceContract.Service;
using System.Runtime.CompilerServices;

namespace EShopMashtiMahdi.ViewComponents
{
    [ViewComponent(Name ="ProductList")]
    public class ProductListViewComponent:ViewComponent
    {
        private readonly IProductApplication repo;

        public ProductListViewComponent(IProductApplication repo)
        {
                this.repo = repo;
        }
        public IViewComponentResult Invoke(ProductSearchModel sm)
        {
            int rc = 0;
            var products = repo.Search(sm,out rc);
            ProductListAndSearchModel psm = new ProductListAndSearchModel {sm=sm,productListItems=products };
            sm.RecordCount = rc;
            if (sm.PageSize == 0)
            {
                sm.PageSize = 1;
            }
            if (sm.RecordCount % sm.PageSize == 0)
            {
                sm.PageCount = sm.RecordCount / sm.PageSize;
            }
            else
            {
                sm.PageCount = sm.RecordCount / sm.PageSize + 1;
            }

            return View(psm);
        }
    }
}
