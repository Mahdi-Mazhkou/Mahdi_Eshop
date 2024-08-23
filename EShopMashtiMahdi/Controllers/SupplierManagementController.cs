using Microsoft.AspNetCore.Mvc;
using Shoping.DomainModel.BusinessModel.Supplier;
using Shoping.DomainModel.Models;
using Shopping.ApplicationServiceContract.Service;

namespace EShopMashtiMahdi.Controllers
{
    public class SupplierManagementController : Controller
    {
        private readonly ISupplierApplication supplierApplication;
        public SupplierManagementController(ISupplierApplication supplierApplication)
        {
            this.supplierApplication = supplierApplication;
        }

        public IActionResult Index()
        {
            var suppliers = supplierApplication.GetAll();
            return View(suppliers);
        }
        public IActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNew(SupplierAddEditModel supplier)
        {
            if (ModelState.IsValid)
            {
                var op = supplierApplication.Register(supplier);
                if (op.Success)
                { 
                   return  RedirectToAction("Index", "SupplierManagement");
                }
                else
                {
                    TempData["ErrorMessage"] = op.Message;
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid Supplier";
            }
            
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
           var op= supplierApplication.Remove(id);
            if (!op.Success)
            {
                TempData["ErrorMessage"] = op.Message;
            }
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var sup = supplierApplication.Get(id);
            return View(sup);
        }
        [HttpPost]
        public IActionResult Edit(SupplierAddEditModel sup)
        {
            if (ModelState.IsValid)
            {
                var op = supplierApplication.Update(sup);
                if (op.Success)
                {
                    return RedirectToAction("Index", "SupplierManagement");
                }
                else
                {
                    TempData["ErrorMessage"] = op.Message;
                    return View(op);
                }
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid Supplier";
                return View(sup);
            }
        }

    }
}
