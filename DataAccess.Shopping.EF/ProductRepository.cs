using FrameWork.DTOS;
using Microsoft.EntityFrameworkCore;
using Shoping.DomainModel.BusinessModel.Product;
using Shoping.DomainModel.Models;
using Shopping.DataAccessServiceContract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Shopping.EF
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopingMashtiMahdiContext db;
        public ProductRepository(ShopingMashtiMahdiContext db)
        {
            this.db = db;
        }
        public OperationResult AssignCategoryFeatureToProductAfterRegistration(int ProductID)
        {
            OperationResult op = new OperationResult("AssignCategoryFeatureToProductAfterRegistration");
            try
            {
                var prod = Get(ProductID);
                var cat = db.Categories.FirstOrDefault(x => x.CategoryID == prod.CategoryID);
                var categoryFeature = cat.CategoryFeatures.ToList();
                foreach (var feature in categoryFeature)
                {
                    ProductFeature pf = new ProductFeature
                    {
                        EffectOnUnitPrice = 0,
                        FeatureID = feature.FeatureID,
                        ProductID = ProductID,
                        ProductFeatureValue = string.Empty,

                    };
                    db.ProductFeatures.Add(pf);
                }
                db.SaveChanges();
                return op.ToSuccess("AssignCategoryFeatureToProductAfterRegistration Successfull",ProductID);
            }
            catch (Exception)
            {

                return op.ToFail("AssignCategoryFeatureToProductAfterRegistration Fail");
            }
           
        }

        public OperationResult AssignKeyWordToProduct(int KeyWordID, int ProductID)
        {
            OperationResult op = new OperationResult("AssignKeyWordToProduct");
            try
            {
                ProductKeyword pk = new ProductKeyword {keywordID=KeyWordID, ProductID=ProductID };
                db.ProductKeywords.Add(pk);
                db.SaveChanges();
                return op.ToSuccess("AssignKeyWordToProduct successfull");
            }
            catch (Exception ex)
            {

                return op.ToFail("AssignKeyWordToProduct Failed"+ex);
            }
           
        }

        public OperationResult AssingFeatureValueForSpeceficProductAndFeature(int ProductID, int FeatureID, string FeatureValue, int EffectOnPrice)
        {
            OperationResult op = new OperationResult("AssingFeatureValueForSpeceficProductAndFeature");

            try
            {
                var pf = db.ProductFeatures.FirstOrDefault(x => x.ProductID == ProductID && x.FeatureID == FeatureID);
                pf.EffectOnUnitPrice = EffectOnPrice;
                pf.ProductFeatureValue = FeatureValue;
                db.SaveChanges();
                return op.ToSuccess("Feature Value Assigned");
            }
            catch (Exception ex)
            {

                return op.ToFail("Feature Value To Failed" +ex);
            }
        }

        public OperationResult DisAboveKeyWordFromProduct(int KeyWordID, int ProductID)
        {
            OperationResult op = new OperationResult("DisAboveKeyWordFromProduct");
            try
            {
                db.ProductKeywords.Remove(db.ProductKeywords.FirstOrDefault(x => x.keywordID == KeyWordID && x.ProductID == ProductID));
                db.SaveChanges();
                return op.ToSuccess("Product Keyword Removed Successfull");
            }
            catch (Exception ex)
            {

                return op.ToFail("remove keyword Has Failed" +ex.Message);
            }
            
        }

        public bool ExistsFeature(string FeatureName)
        {
            return db.Features.Any(x=>x.FeatureName==FeatureName);
        }

        public bool ExistsKeyWord(string KeyWord)
        {
            return db.KeyWords.Any(x => x.KeyWordText == KeyWord );
        }

        public bool ExistsProductKey(int ProductID, int KeyWordID)
        {
            return db.ProductKeywords.Any(x=>x.ProductID==ProductID && x.keywordID==KeyWordID);
        }

        public bool ExistsProductName(string ProductName)
        {
            return db.Products.Any(x => x.ProductName == ProductName);
        }

        public bool ExistsProductNameForAnotherProduct(string ProductName, int ProductID)
        {
            return db.Products.Any(x => x.ProductID != ProductID && x.ProductName == ProductName);
        }

        public bool ExistsSlug(string Slug)
        {
            return db.Products.Any(x=>x.Slug==Slug);
        }

        public bool ExistsSlugForAnotherProduct(string Slug, int ProductID)
        {
            return db.Products.Any(x => x.ProductID!=ProductID &&  x.Slug == Slug);
        }

        public Product Get(int id)
        {
            return db.Products.FirstOrDefault(x=>x.ProductID==id);
        }

        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public bool HasRelatedOrders(int ProductID)
        {
            return Get(ProductID).OrderDetails.Any();
        }

        public OperationResult Register(Product current)
        {
            OperationResult op = new OperationResult("Register Product");
            try
            {
                db.Products.Add(current);
                db.SaveChanges();
                return op.ToSuccess("Register Product Successfull" , current.ProductID);
            }
            catch (Exception ex)
            {

                return op.ToFail("Register To Fail"+ex);
            }
        }

        public OperationResult RegisterFeatureAndAssignItToProduct(ProductFeatureAddModel pf)
        {
            OperationResult op = new OperationResult("RegisterFeatureAndAssignItToProduct");

            try
            {
                var feature = new Feature { FeatureName = pf.FeatureName };
                db.Features.Add(feature);
                db.SaveChanges();
                var pfv = new ProductFeature
                {
                    EffectOnUnitPrice = pf.EffectOnUnitPrice,
                    ProductID = pf.ProductID,
                    FeatureID = feature.FeatureID,
                    ProductFeatureValue = pf.FeatureValue
                };
                db.ProductFeatures.Add(pfv);
                db.SaveChanges();
                return op.ToSuccess("Register Successfull", pf.ProductID);
            }
            catch (Exception ex)
            {

                return op.ToFail("Register Failed" + ex.Message);
            }
           
        }

        public OperationResult RegisterKeyWordAndAssignItToTheProduct(string KeyWord, int ProductID)
        {
            OperationResult op = new OperationResult("RegisterKeyWordAndAssignItToTheProduct");
            try
            {
                var Keyword = new KeyWord { KeyWordText = KeyWord };
                db.KeyWords.Add(Keyword);
                db.SaveChanges();
                db.ProductKeywords.Add(new ProductKeyword { keywordID = Keyword.KeyWordID, ProductID = ProductID });
                db.SaveChanges();
                return op.ToSuccess("Keyword Successfully Registred");
            }
            catch (Exception ex)
            {

                return op.ToFail("Keyword Failed Registred"+ex.Message);
            }
           
        }

        public OperationResult Remove(int id)
        {
            OperationResult op = new OperationResult("Remove Product");
            try
            {
                var prod = db.Products.FirstOrDefault(x => x.ProductID == id);
                var pfs = prod.ProductFeatures.ToList();
                var pfk = prod.ProductKeywords.ToList();
                foreach (var item in pfs)
                {
                    db.ProductFeatures.Remove(item);
                }
                foreach (var item in pfk)
                {
                    db.ProductKeywords.Remove(item);
                }   
                db.SaveChanges();
                db.Products.Remove(prod);
                db.SaveChanges();
                return op.ToSuccess("Remove Product Successfull", id);
            }
            catch (Exception ex)
            {

                return op.ToFail("Remove Has Failed" + ex.Message);
            }
           
        }

        public List<ProductListItem> Search(ProductSearchModel s, out int RecordCount)
        {
            if (s.PageSize == 0)
            {
                s.PageSize = 1;
            }
            var q = from prod in db.Products select prod;
            if (!string.IsNullOrEmpty(s.ProductName))
            {
                q = q.Where(x => x.ProductName == s.ProductName);
            }
            if (!string.IsNullOrEmpty(s.Slug))
            {
                q = q.Where(x => x.Slug == s.Slug);
            }
            if (s.CategotyID != null && s.CategotyID > 0)
            {
                q = q.Where(x => x.CategoryID == s.CategotyID);
            }
            if(s.SupplierID!= null && s.SupplierID > 0)
            {
                q = q.Where(x=>x.SupplierID==s.SupplierID);
            }
            if (s.UnitPriceFrom!=null)
            {
                q = q.Where(x => x.UnitPrice >= s.UnitPriceFrom);
            }
            if (s.UnitPriceTo != null)
            {
                q = q.Where(x=>x.UnitPrice <=s.UnitPriceTo);
            }
            RecordCount = q.Count();
            q = q.OrderByDescending(x => x.ProductID).Skip(s.PageIndex * s.PageSize).Take(s.PageSize);
            var q2 = from prod in q select new ProductListItem
            {
                CategoryName = prod.Category.CategoryName,
                ProductName=prod.ProductName,
                HasRelatedOrder=prod.OrderDetails.Any(),
                ProductID=prod.ProductID,
                Slug = prod.Slug,
                SupplierName=prod.Supplier.SupplierName,
                UnitPrice=prod.UnitPrice
            };

            return q2.ToList();

        }

        public OperationResult Update(Product current)
        {
            OperationResult op = new OperationResult("Update Product",current.ProductID);
            try
            {
                db.Products.Attach(current);
                db.Entry<Product>(current).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return op.ToSuccess("Product Update Is Successfull");
            }
            catch (Exception ex)
            {

                return op.ToFail("Product Update Fail" +ex.Message);
            }
        }
    }
}
