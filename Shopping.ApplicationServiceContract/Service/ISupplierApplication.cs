using FrameWork.DTOS;
using Shoping.DomainModel.BusinessModel.Supplier;
using Shoping.DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.ApplicationServiceContract.Service
{
    public  interface ISupplierApplication
    {
        OperationResult Register(SupplierAddEditModel sup);
        OperationResult Remove(int SupplierID);
        OperationResult Update(SupplierAddEditModel supplier);
        List<Supplier> GetAll();
        SupplierAddEditModel Get(int SupplirID);
    }
}
