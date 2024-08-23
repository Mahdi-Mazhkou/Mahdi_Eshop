using FrameWork.BaseRepositories;
using Shoping.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DataAccessServiceContract.Repositories
{
    public  interface ISupplierRepository:IBaseRepository<Supplier,int>
    {
        bool ExistsSupplierName(string supplierName);
        bool HasRelatedProduct(int id);
    }
}
