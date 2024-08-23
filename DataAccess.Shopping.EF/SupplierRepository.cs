using FrameWork.DTOS;
using Shoping.DomainModel.Models;
using Shopping.DataAccessServiceContract.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Shopping.EF
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ShopingMashtiMahdiContext db;
        public SupplierRepository(ShopingMashtiMahdiContext db)
        {
            this.db = db;
        }
        public bool ExistsSupplierName(string supplierName)
        {
            return db.Suppliers.Any(x => x.SupplierName == supplierName);
        }

        public Supplier Get(int id)
        {
            return db.Suppliers.FirstOrDefault(x=>x.SupplierID==id);
        }

        public List<Supplier> GetAll()
        {
            return db.Suppliers.ToList();
        }

        public bool HasRelatedProduct(int id)
        {
            var s = db.Suppliers.FirstOrDefault(x=>x.SupplierID==id);
            return s.Products.Any();
        }

        public OperationResult Register(Supplier current)
        {
            OperationResult op = new OperationResult("Add Supplier");
            try
            {
                db.Suppliers.Add(current);
                db.SaveChanges();
                return op.ToSuccess("Register Supplier Successfull",current.SupplierID);
            }
            catch (Exception ex)
            {

                return op.ToFail("Register Supplier Fail"+ex.Message) ;
            }
            
        }

        public OperationResult Remove(int id)
        {
            OperationResult op = new OperationResult("Add Supplier");
            try
            {
                db.Suppliers.Remove(db.Suppliers.FirstOrDefault(x=>x.SupplierID==id));
                db.SaveChanges();
                return op.ToSuccess("Register Supplier Successfull", id);
            }
            catch (Exception ex)
            {

                return op.ToFail("Register Supplier Fail" + ex.Message);
            }
        }

        public OperationResult Update(Supplier current)
        {
            OperationResult op = new OperationResult("Update Supplier");
            try
            {
               var old =db.Suppliers.FirstOrDefault(x => x.SupplierID == current.SupplierID);
                old.SupplierName = current.SupplierName;
                old.SupplierDescription = current.SupplierDescription;
                db.SaveChanges();
                return op.ToSuccess("Update Supplier Successfull", current.SupplierID);
            }
            catch (Exception ex)
            {

                return op.ToFail("Update Supplier Fail" + ex.Message);
            }
        }
    }
}
