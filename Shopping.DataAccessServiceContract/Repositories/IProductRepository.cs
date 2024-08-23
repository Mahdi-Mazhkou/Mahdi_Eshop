using FrameWork.BaseRepositories;
using FrameWork.DTOS;
using Shoping.DomainModel.BusinessModel.Product;
using Shoping.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DataAccessServiceContract.Repositories
{
    public  interface IProductRepository:IBaseRepositorySearchable<Product,int,ProductSearchModel,ProductListItem>
    {
        bool ExistsProductName(string ProductName);
        bool ExistsProductNameForAnotherProduct(string ProductName,int ProductID);
        bool ExistsSlug(string Slug);
        bool ExistsSlugForAnotherProduct(string Slug,int ProductID);
        bool ExistsProductKey(int ProductID,int KeyWordID);
        bool ExistsFeature(string FeatureName);
        OperationResult AssignKeyWordToProduct(int KeyWordID,int ProductID);
        OperationResult RegisterKeyWordAndAssignItToTheProduct(string KeyWord,int ProductID);
        bool ExistsKeyWord(string KeyWord);
        OperationResult DisAboveKeyWordFromProduct(int KeyWordID,int ProductID);
        OperationResult AssignCategoryFeatureToProductAfterRegistration(int ProductID);
        OperationResult AssingFeatureValueForSpeceficProductAndFeature(int ProductID, int FeatureID, string FeatureValue, int EffectOnPrice);
        OperationResult RegisterFeatureAndAssignItToProduct(ProductFeatureAddModel pf);
        bool HasRelatedOrders(int ProductID);
    }
}
