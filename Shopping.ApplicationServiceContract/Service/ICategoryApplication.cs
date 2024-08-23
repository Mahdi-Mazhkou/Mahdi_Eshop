using FrameWork.DTOS;
using Shoping.DomainModel.BusinessModel.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.ApplicationServiceContract.Service
{
    public  interface ICategoryApplication
    {
        OperationResult Register(CategoryAddEditModel cat);
        OperationResult Update(CategoryAddEditModel cat);
        OperationResult Remove(int CategoryID);
        List<CategoryListItem> Search(CategorySearchModel sm,out int RecordCount);
        CategoryAddEditModel Get(int CategoryID);
        List<FastCatList> GetDrp();


    }
}
