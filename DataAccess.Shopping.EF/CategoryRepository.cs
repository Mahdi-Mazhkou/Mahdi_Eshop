using FrameWork.DTOS;
using Shoping.DomainModel.BusinessModel.Category;
using Shoping.DomainModel.Models;
using Shopping.DataAccessServiceContract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Shopping.EF
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShopingMashtiMahdiContext db;
        public CategoryRepository(ShopingMashtiMahdiContext db)
        {
            this.db = db;
        }

        public void DecrementParentDirectChildCount(int CategoryID)
        {
            var cat = Get(CategoryID);
            if (cat.ParentID != null)
            {
                var parent = Get(cat.ParentID.Value);
                parent.DirectChildCount = parent.DirectChildCount - 1;
                db.SaveChanges();
            }
        }

        public bool ExistsCategoryName(string CategoryName)
        {
            return db.Categories.Any(x=>x.CategoryName==CategoryName);
        }

        public bool ExistsCategoryName(string CategoryName, int CategoryID)
        {
            return db.Categories.Any(x => x.CategoryName == CategoryName && x.CategoryID==CategoryID);
        }

        public string GenerateLineAge(int CategoryID)
        {
            var cat = Get(CategoryID);
            string Lineage = "";
            if (cat.ParentID != null)
            {
                var parent = Get(cat.ParentID.Value);
                Lineage = parent.LineAge + CategoryID + ",";
            }
            else
            {
                Lineage = CategoryID + ",";
            }
            return Lineage;
        }

        public Category Get(int id)
        {
            return db.Categories.FirstOrDefault(x=>x.CategoryID==id);
        }

        public List<Category> GetAll()
        {
            return db.Categories.ToList();
        }

        public List<Category> GetChildren(int CategoryID)
        {
            var category = Get(CategoryID);
            return db.Categories.Where(x=>x.LineAge.StartsWith(category.LineAge)).ToList();
        }

        public List<FastCatList> GetDrp()
        {
            return db.Categories.Select(x=>new FastCatList {CategoryID=x.CategoryID,CategoryName=x.CategoryName }).ToList();
        }

        public bool HasChildCategory(int CategoryID)
        {
            return db.Categories.Any(x => x.CategoryID == CategoryID);
        }

        public bool HasRelatedProduct(int CategoryID)
        {
            return db.Products.Any(x => x.CategoryID == CategoryID);
        }

        public void IncrementParentDirectChildCount(int CategoryID)
        {
            var cat = Get(CategoryID);
            if (cat.ParentID != null)
            {
                var parent = Get(cat.ParentID.Value);
                parent.DirectChildCount = parent.DirectChildCount + 1;
                db.SaveChanges();
            }

        }

        public OperationResult Register(Category current)
        {
            OperationResult op = new OperationResult("Register Category");
            try
            {
                db.Categories.Add(current);
                db.SaveChanges();
                return op.ToSuccess("Category Registered Successfully");
            }
            catch (Exception)
            {

                return op.ToFail("Category Registered Failed");
            }
        }

        public OperationResult Remove(int id)
        {
            OperationResult op = new OperationResult("Remove Category");
            try
            {
                var cat = Get(id);
                db.Categories.Remove(cat);
                db.SaveChanges();
                return op.ToSuccess("Category removed Successfully");
            }
            catch (Exception)
            {

                return op.ToFail("Category Removed Failed");
            }

        }

        public void RemoveCategoryFeature(int CategoryID)
        {
            var category = Get(CategoryID);
            var categoryFeatures = category.CategoryFeatures.ToList();
            foreach (var item in categoryFeatures)
            {
                db.CategoryFeatures.Remove(item);
            }
            db.SaveChanges();
        }


        public List<CategoryListItem> Search(CategorySearchModel s, out int RecordCount)
        {
            if (s.PageSize == 0)
            {
                s.PageSize = 20;
            }

            var q = from cat in db.Categories select cat;

            if (!string.IsNullOrEmpty(s.CategoryName))
            {
                q = q.Where(x=>x.CategoryName.StartsWith(s.CategoryName));
            }
            if (s.ParentID != null)
            {
                q = q.Where(x => x.ProductCount == s.ProductCount);
            }

            RecordCount = q.Count();
            q = q.OrderByDescending(x => x.SortOrder).Skip(s.PageIndex * s.PageSize).Take(s.PageSize);
            var q2 = from prod in q select new CategoryListItem
            {
                 CategoryID=prod.CategoryID,
                 CategoryName=prod.CategoryName,
                 ProductCount=prod.ProductCount,
                 SortOrder=prod.SortOrder
            
            };
            return q2.ToList();
        }

        public OperationResult SetLineAge(string LineAge, int CategoryID)
        {
            OperationResult op = new OperationResult("SetLineAge Category");
            try
            {
                var cat = Get(CategoryID);
                cat.LineAge = LineAge;
                db.SaveChanges();
                return op.ToSuccess("LineAge Set Successfully");
            }
            catch (Exception ex)
            {

                return op.ToFail("LineAge Set Successfully" +ex);
            }
            
        }

        public OperationResult Update(Category current)
        {
            OperationResult op = new OperationResult("Update Category");
            try
            {
                var cat = Get(current.CategoryID);
                cat.CategoryName = current.CategoryName;
                cat.ParentID = current.ParentID;
                cat.SortOrder = current.SortOrder;
                cat.Description = current.Description;

                db.SaveChanges();
                return op.ToSuccess("Category Updated Successfully");
            }
            catch (Exception)
            {

                return op.ToFail("Category Updated Failed");
            }

        }
    }
}
