using FrameWork.DTOS;
using Shoping.DomainModel.BusinessModel.Category;
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
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryRepository repo;
        public CategoryApplication(ICategoryRepository repo)
        {
            this.repo = repo;
        }
        public CategoryAddEditModel Get(int CategoryID)
        {
            var cat = repo.Get(CategoryID);
            CategoryAddEditModel c = new CategoryAddEditModel()
            {
                 CategoryID=cat.CategoryID,
                 CategoryName=cat.CategoryName,
                 Description=cat.Description,
                 ParentID=cat.ParentID,
                 SortOrder=cat.SortOrder
            };
            return c;
        }

        public List<FastCatList> GetDrp()
        {
            return repo.GetDrp();
        }

        public OperationResult Register(CategoryAddEditModel cat)
        {
            Category c = new Category
            {
                CategoryName=cat.CategoryName,
                Description=cat.Description,
                DirectChildCount=0,
                ParentID=cat.ParentID,
                ProductCount=0,
                SortOrder=cat.SortOrder

            };
            var op = repo.Register(c);
            repo.IncrementParentDirectChildCount(op.RecordID.Value);
            var lineage = repo.GenerateLineAge(op.RecordID.Value);
            repo.SetLineAge(lineage,op.RecordID.Value);
            return op;
        }

        public OperationResult Remove(int CategoryID)
        {
            if (repo.HasChildCategory(CategoryID))
            {
                return new OperationResult("Remove Category").ToFail("Category Has Related Child Category");
            }
            if (repo.HasRelatedProduct(CategoryID))
            {
                return new OperationResult("Remove Category").ToFail("Category Has Related Child Product");
            }
            repo.DecrementParentDirectChildCount(CategoryID);
            repo.RemoveCategoryFeature(CategoryID);
            var op = repo.Remove(CategoryID);
            return op;
        }

        public List<CategoryListItem> Search(CategorySearchModel sm, out int RecordCount)
        {
            return repo.Search(sm, out RecordCount);
        }

        public OperationResult Update(CategoryAddEditModel cat)
        {
            var oldCat = repo.Get(cat.CategoryID);
            if (oldCat.ParentID!=cat.ParentID)
            {
                repo.DecrementParentDirectChildCount(oldCat.CategoryID);
                var allOldChilderen = repo.GetChildren(oldCat.CategoryID);
                var newParentLineAge = repo.GenerateLineAge(cat.ParentID.Value);
                foreach (Category child in allOldChilderen)
                {

                }
            }

            return null;
        }
    }
}
