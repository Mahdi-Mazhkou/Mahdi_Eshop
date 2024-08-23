using FrameWork.DTOS;
using Shoping.DomainModel.BusinessModel.Product;
using Shoping.DomainModel.Models;
using Shopping.ApplicationServiceContract.Service;
using Shopping.DataAccessServiceContract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository repo;

        public ProductApplication(IProductRepository repo)
        {
            this.repo = repo;
        }
        private Product ToModel(ProductAddEditModel prod)
        {
            return new Product
            {
                CategoryID = prod.CategoryID,
                MetaDescription = prod.MetaDescription,
                ImageUrl = prod.ImageUrl,
                JSONLDInformation = prod.JSONLDInformation,
                ProductName = prod.ProductName,
                MetaKeyword = prod.MetaKeyword,
                PageTitle = prod.PageTitle,
                ProductID = prod.ProductID,
                Slug = prod.Slug,
                SupplierID = prod.SupplierID,
                UnitPrice = prod.UnitPrice

            };
        }
        private ProductAddEditModel ToAddEditModel(Product prod)
        {
            return new ProductAddEditModel
            {
                CategoryID = prod.CategoryID,
                MetaDescription = prod.MetaDescription,
                ImageUrl = prod.ImageUrl,
                JSONLDInformation = prod.JSONLDInformation,
                ProductName = prod.ProductName,
                MetaKeyword = prod.MetaKeyword,
                PageTitle = prod.PageTitle,
                ProductID = prod.ProductID,
                Slug = prod.Slug,
                SupplierID = prod.SupplierID,
                UnitPrice = prod.UnitPrice

            };
        }
        public OperationResult AssignKeyWordToProduct(int KeyWordID, int ProductID)
        {
            if (repo.ExistsProductKey(ProductID, KeyWordID))
            {
                return new OperationResult("AssignKeyWordToProduct").ToFail("Product Alrady Exists");
            }
            return repo.AssignKeyWordToProduct(KeyWordID,ProductID);
        }

        public OperationResult AssingFeatureValueForSpeceficProductAndFeature(int ProductID, int FeatureID, string FeatureValue, int EffectOnPrice)
        {
            return repo.AssingFeatureValueForSpeceficProductAndFeature(ProductID, FeatureID, FeatureValue, EffectOnPrice);
        }

        public OperationResult DisAboveKeyWordFromProduct(int KeyWordID, int ProductID)
        {
            return repo.DisAboveKeyWordFromProduct(KeyWordID,ProductID);
        }

        public ProductAddEditModel Get(int id)
        {
            var product = repo.Get(id);
            ProductAddEditModel model = ToAddEditModel(product);
            return model;
        }

        public OperationResult Register(ProductAddEditModel current)
        {
            if (repo.ExistsProductName(current.ProductName))
            {
                return new OperationResult("Register Product").ToFail("Product  Already Exists");
            }
            if (repo.ExistsSlug(current.Slug))
            {
                return new OperationResult("Register Product").ToFail("Duplicate Slug");
            }
            Product p = ToModel(current);
            var opProduct= repo.Register(p);
            if (opProduct.Success)
            {
                repo.AssignCategoryFeatureToProductAfterRegistration(opProduct.RecordID.Value);
            }
            return opProduct;
        }

        public OperationResult RegisterFeatureAndAssignItToProduct(ProductFeatureAddModel pf)
        {
            if (repo.ExistsFeature(pf.FeatureName))
            {
                return new OperationResult("RegisterFeatureAndAssignItToProduct").ToFail("Feature Already Exists");
            }
            return repo.RegisterFeatureAndAssignItToProduct(pf);
        }

        public OperationResult RegisterKeyWordAndAssignItToTheProduct(string KeyWord, int ProductID)
        {
            if (repo.ExistsKeyWord(KeyWord))
            {
                return new OperationResult("Register Keyword").ToFail("Duplicate Keyword");
            }
            return repo.RegisterKeyWordAndAssignItToTheProduct(KeyWord,ProductID);
        }

        public OperationResult Remove(int id)
        {
            if (repo.HasRelatedOrders(id))
            {
                return new OperationResult("Remove Prodcut").ToFail("Product Has Relate Orders");
            }
            return repo.Remove(id);
        }

        public List<ProductListItem> Search(ProductSearchModel s, out int RecordCount)
        {
            return repo.Search(s, out RecordCount);
        }

        public OperationResult Update(ProductAddEditModel current)
        {
            if (repo.ExistsProductNameForAnotherProduct(current.ProductName,current.ProductID))
            {
                return new OperationResult("Update Product").ToFail("Update Product Failed");
            }
            if (repo.ExistsSlugForAnotherProduct(current.Slug, current.ProductID))
            {
                return new OperationResult("Update Product").ToFail("slug Already Blogs To Another Prducts");
            }

            Product p = ToModel(current);
            return  repo.Update(p);
        }
    }
}
