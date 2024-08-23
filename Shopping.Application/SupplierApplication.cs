using FrameWork.DTOS;
using Shoping.DomainModel.BusinessModel.Supplier;
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
    public class SupplierApplication : ISupplierApplication
    {
        private readonly ISupplierRepository repo;
        public SupplierApplication(ISupplierRepository repo)
        {
            this.repo = repo;
        }

        public SupplierAddEditModel Get(int SupplirID)
        {
            var s = repo.Get(SupplirID);
            SupplierAddEditModel sup = new SupplierAddEditModel
            {SupplierDescription=s.SupplierDescription,SupplierID=s.SupplierID,SupplierName=s.SupplierName };
            return sup;
        }

        public List<Supplier> GetAll()
        {
            return repo.GetAll();
        }

        public OperationResult Register(SupplierAddEditModel sup)
        {
            OperationResult op = new OperationResult("Add Register");
            try
            {
                if (repo.ExistsSupplierName(sup.SupplierName))
                {
                    return op.ToFail("The Supplier Already Exists");
                }
                Supplier s = new Supplier
                { SupplierName = sup.SupplierName, SupplierDescription = sup.SupplierDescription, };
                op =repo.Register(s);
                return op;
            }
            catch (Exception)
            {

                return op.ToFail("Supplier Registration Failed");
            }
        }

        public OperationResult Remove(int SupplierID)
        {
            if (repo.HasRelatedProduct(SupplierID))
            {
                return new OperationResult("Remove Supplier",SupplierID).ToFail("Supplier Has Related To Fail");
            }
            return repo.Remove(SupplierID) ;
        }

        public OperationResult Update(SupplierAddEditModel supplier)
        {
            OperationResult op = new OperationResult("Update Databases");
                Supplier s = new Supplier
                {
                    SupplierDescription = supplier.SupplierDescription,
                    SupplierName = supplier.SupplierName,
                    SupplierID = supplier.SupplierID
                };

                op = repo.Update(s);
                return op;
                        
        }
    }
}
