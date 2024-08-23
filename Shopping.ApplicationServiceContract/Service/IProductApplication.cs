using FrameWork.DTOS;
using Shoping.DomainModel.BusinessModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.ApplicationServiceContract.Service
{
    public  interface IProductApplication
    {
        OperationResult AssignKeyWordToProduct(int KeyWordID, int ProductID);
        OperationResult RegisterKeyWordAndAssignItToTheProduct(string KeyWord, int ProductID);
        OperationResult DisAboveKeyWordFromProduct(int KeyWordID, int ProductID);
        OperationResult AssingFeatureValueForSpeceficProductAndFeature(int ProductID, int FeatureID, string FeatureValue, int EffectOnPrice);
        OperationResult RegisterFeatureAndAssignItToProduct(ProductFeatureAddModel pf);
        ProductAddEditModel Get(int id);
        OperationResult Remove(int id);
        OperationResult Update(ProductAddEditModel current);
        OperationResult Register(ProductAddEditModel current);
        List<ProductListItem> Search(ProductSearchModel s, out int RecordCount);
    }
}
