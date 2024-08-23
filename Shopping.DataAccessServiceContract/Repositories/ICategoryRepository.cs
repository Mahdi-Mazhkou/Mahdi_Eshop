using FrameWork.BaseRepositories;
using FrameWork.DTOS;
using Shoping.DomainModel.BusinessModel.Category;
using Shoping.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DataAccessServiceContract.Repositories
{
    public   interface ICategoryRepository:IBaseRepositorySearchable<Category,int,CategorySearchModel,CategoryListItem>
    {
        bool ExistsCategoryName(string CategoryName);
        bool ExistsCategoryName(string CategoryName,int CategoryID);
        void IncrementParentDirectChildCount(int CategoryID);
        void DecrementParentDirectChildCount(int CategoryID);
        string GenerateLineAge(int CategoryID); 
        OperationResult SetLineAge(string LineAge,int CategoryID);
        bool HasRelatedProduct(int CategoryID);
        bool HasChildCategory(int CategoryID);
        void RemoveCategoryFeature(int CategoryID);
        List<Category> GetChildren(int CategoryID);
        List<FastCatList> GetDrp();
    }
}
