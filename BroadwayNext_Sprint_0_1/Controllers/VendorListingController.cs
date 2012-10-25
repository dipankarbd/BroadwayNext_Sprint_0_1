using BroadwayNext_Sprint_0_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using BroadwayNext_Sprint_0_1.Data;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;

namespace BroadwayNext_Sprint_0_1.Controllers
{
    public class VendorListingController : Controller
    {
        //
        // GET: /VendorListing/
        private UnitOfWork Uow;

        public VendorListingController()
        {
            this.Uow = new UnitOfWork();
        }


        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetVendorContacts(Guid vendorId, int pageSize, int currentPage)
        {
            TGFContext db = new TGFContext();

            db.Configuration.ProxyCreationEnabled = false;

            var contactsQuery = db.VendorContacts.Include("Vendor").Where(c => c.VendorID == vendorId);
            var rowCount = contactsQuery.Count();
            var contacts = contactsQuery.OrderBy(c => c.Firstname).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            contacts.ForEach(c =>
            {
                c.Vendnum = c.Vendor.Vendnum;
            });
            return Json(new { Data = contacts, VirtualRowCount = rowCount }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveVendorContact(VendorContact contact)
        {
            contact.InputDate = DateTime.Now;
            contact.LastModifiedDate = DateTime.Now;
            var result = false;
            if (ModelState.IsValid)
            {
                using (this.Uow)
                {
                    if (contact.VendorContactID == Guid.Empty)
                    {
                        contact.VendorContactID = Guid.NewGuid();
                        this.Uow.VendorContacts.Insert(contact);
                        result = this.Uow.Commit() > 0;
                    }
                    else
                    {
                        this.Uow.VendorContacts.Update(contact);
                        result = this.Uow.Commit() > 0;
                    }
                }
                return Json(new { Success = result, VendorContact = contact });
            }
            else
            {
                return Json(new { Success = result, Message = "Invalid Model" });
            }
        }
        public JsonResult DeleteVendorContact(VendorContact contact)
        {
            bool result = false;
            using (this.Uow)
            {
                this.Uow.VendorContacts.Delete(contact);
                result = this.Uow.Commit() > 0;
            }
            return Json(new { Success = result });
        }
        public JsonResult GetVendorShipTos(Guid vendorId, int pageSize, int currentPage)
        {
            TGFContext db = new TGFContext();

            db.Configuration.ProxyCreationEnabled = false;

            var shiptosQuery = db.VendorShipToes.Where(c => c.VendorID == vendorId);
            var rowCount = shiptosQuery.Count();
            var shiptos = shiptosQuery.OrderBy(s => s.Recipient).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return Json(new { Data = shiptos, VirtualRowCount = rowCount }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveVendorShipTo(VendorShipTo shipto)
        {
            shipto.InputDate = DateTime.Now;
            shipto.LastModifiedDate = DateTime.Now;
            var result = false;
            //if (ModelState.IsValid)
            //{
            using (this.Uow)
            {
                if (shipto.VendorShipToID == Guid.Empty)
                {
                    shipto.VendorShipToID = Guid.NewGuid();
                    this.Uow.VendorShipTos.Insert(shipto);
                    result = this.Uow.Commit() > 0;
                }
                else
                {
                    this.Uow.VendorShipTos.Update(shipto);
                    result = this.Uow.Commit() > 0;
                }
            }
            return Json(new { Success = result, VendorShipTo = shipto });
            // }
            //else
            //{
            //   return Json(new { Success = result, Message = "Invalid Model" });
            // }
        }
        public JsonResult DeleteVendorShipTo(VendorShipTo shipto)
        {
            bool result = false;
            using (this.Uow)
            {
                this.Uow.VendorShipTos.Delete(shipto);
                result = this.Uow.Commit() > 0;
            }
            return Json(new { Success = result });
        }

        public JsonResult GetVendorTerminations(Guid vendorId, int pageSize, int currentPage)
        {
            TGFContext db = new TGFContext();

            db.Configuration.ProxyCreationEnabled = false;

            var terminationsQuery = db.VendorTerminations.Include("Division1").Include("TerminationReason1").Where(c => c.VendorID == vendorId);
            var rowCount = terminationsQuery.Count();
            var terminations = terminationsQuery.OrderByDescending(s => s.TerminationDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

            return Json(new { Data = terminations, VirtualRowCount = rowCount }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SaveVendorTermination(VendorTermination termination)
        {
            var result = false;
            if (ModelState.IsValid)
            {
                using (this.Uow)
                {
                    if (termination.VendorTerminationID == Guid.Empty)
                    {
                        termination.InputDate = DateTime.Now;
                        termination.LastModifiedDate = DateTime.Now;
                        termination.VendorTerminationID = Guid.NewGuid();
                        this.Uow.VendorTerminations.Insert(termination);
                        result = this.Uow.Commit() > 0;
                    }
                    else
                    {
                        TGFContext db = new TGFContext();
                        termination.LastModifiedDate = DateTime.Now;
                        this.Uow.VendorTerminations.Update(termination);
                        result = this.Uow.Commit() > 0;
                    }
                }
                return Json(new { Success = result, VendorShipTo = termination });
            }
            else
            {
                return Json(new { Success = result, Message = "Invalid Model" });
            }
        }
        public JsonResult DeleteVendorTermination(VendorTermination termination)
        {
            bool result = false;
            using (this.Uow)
            {
                this.Uow.VendorTerminations.Delete(termination);
                result = this.Uow.Commit() > 0;
            }
            return Json(new { Success = result });
        }
        //=================     /     ================================================ 


        public JsonResult GetAllVendors(int pageSize, int currentPage, int? vendorNum, string companyName = null)
        {
            TGFContext db = new TGFContext();
            db.Configuration.ProxyCreationEnabled = false;
            db.VendorInsuranceTypes.Load();
            //var vendors, rowCount;
            Expression<Func<Vendor, bool>> filterVendorNum = null;
            if (vendorNum.HasValue)
            {
                filterVendorNum = (v => v.Vendnum == vendorNum);   //1578511699
            }
            Expression<Func<Vendor, bool>> filterName = null;
            if (!string.IsNullOrEmpty(companyName))
            {
                filterName = (v => v.Company.Equals(companyName, StringComparison.CurrentCultureIgnoreCase));
            }
            try
            {
                IQueryable<Vendor> vendors = db.Vendors; ;
                if (filterVendorNum != null)
                {
                    vendors = vendors.Where(filterVendorNum);
                }
                if (filterName != null)
                {
                    vendors = vendors.Where(filterName);
                }
                int rowCount = vendors.Count();
                var vendorList= vendors.Include("VendorInsurances").Include("VendorRemitToes").OrderBy(v => v.Vendnum).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
                return Json(new { Data = vendorList, InsuranceTypes = db.VendorInsuranceTypes.ToList(), VirtualRowCount = rowCount }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw;
            }


        }



        public JsonResult GetVendors()
        {
            //Tested -- Works
            //IEnumerable<Vendor> vendors = Uow.Vendors.Get(           
            //    includeProperties: "VendorRemitToes");
            ////Json(vendors, JsonRequestBehavior.AllowGet);
            //return (Json(vendors, JsonRequestBehavior.AllowGet));

            ////   Test 2 --
            //IEnumerable<Vendor> vendors = Uow.Vendors.Get(includeProperties: "VendorRemitToes");
            ////Json(vendors, JsonRequestBehavior.AllowGet);
            //return (Json(vendors, JsonRequestBehavior.AllowGet));

            //-- /Test



            // Test 1 -- Works
            try
            {
                int num = 1;
                var db = new TGFContext();

                db.Configuration.LazyLoadingEnabled = false;
                db.Configuration.ProxyCreationEnabled = false;
                IEnumerable<Vendor> vendor = db.Vendors
                                                    .Include("VendorInsurances")
                                                    .Include("VendorRemitToes")
                                                    .Include("VendorNotes")
                                                    .OrderBy(v => v.VendorID)
                    //.Where(v => v.Vendnum == num)
                                                    .Skip(0)
                                                    .Take(2)
                                                    .ToList();


                var test = vendor;
                return (Json(vendor, JsonRequestBehavior.AllowGet));
            }
            catch (Exception ex)
            {

                throw;
            }
            //-- /Test
        }

        [HttpPost]
        public ActionResult Save(Vendor vendor)
        {

            DateTime InputDate = DateTime.Now;
            DateTime LastModifiedDate = DateTime.Now;

            var result = false;

            using (Uow)
            {

                string error = "";

                if (vendor.VendorID == Guid.Empty)  //This is New
                {
                    vendor.VendorID = Guid.NewGuid();
                    vendor.InputDate = InputDate;
                    vendor.LastModifiedDate = LastModifiedDate;
                    //
                    Uow.Vendors.Insert(vendor);

                    foreach (var remitToes in vendor.VendorRemitToes)
                    {
                        if (remitToes.VendorID == Guid.Empty)
                        {
                            remitToes.VendorID = vendor.VendorID;
                            remitToes.VendorRemitToID = Guid.NewGuid();
                            remitToes.InputDate = InputDate;
                            remitToes.LastModifiedDate = LastModifiedDate;
                            Uow.RemitTo.Insert(remitToes);
                        }
                    }
                    //Handle insurance 
                    foreach (var insurance in vendor.VendorInsurances)
                    {
                        if (insurance.VendorID == Guid.Empty)   //this is new Insurance
                        {
                            insurance.VendorID = vendor.VendorID;
                            insurance.VendorInsuranceID = Guid.NewGuid();
                            insurance.InputDate = InputDate;
                            insurance.LastModifiedDate = LastModifiedDate;
                            Uow.VendorInsurances.Insert(insurance);
                        }
                    }
                }
                else
                {
                    foreach (var remitToes in vendor.VendorRemitToes)
                    {
                        if (remitToes.VendorID == Guid.Empty)       //This is new
                        {
                            remitToes.VendorID = vendor.VendorID;
                            remitToes.VendorRemitToID = Guid.NewGuid();
                            remitToes.InputDate = InputDate;
                            remitToes.LastModifiedDate = LastModifiedDate;
                            Uow.RemitTo.Insert(remitToes);
                        }
                        else
                        {
                            remitToes.LastModifiedDate = LastModifiedDate;
                            Uow.RemitTo.Update(remitToes);
                        }
                    }
                    //Handle Insurance
                    foreach (var insurance in vendor.VendorInsurances)
                    {
                        if (insurance.VendorID == Guid.Empty)   //this is new Insurance
                        {
                            insurance.VendorID = vendor.VendorID;
                            insurance.VendorInsuranceID = Guid.NewGuid();
                            insurance.InputDate = InputDate;
                            insurance.LastModifiedDate = LastModifiedDate;
                            Uow.VendorInsurances.Insert(insurance);
                        }
                        else
                        {
                            insurance.LastModifiedDate = LastModifiedDate;
                            Uow.VendorInsurances.Update(insurance);
                        }
                    }
                    //
                    vendor.LastModifiedDate = LastModifiedDate;
                    Uow.Vendors.Update(vendor);
                }
                try
                {
                    result = Uow.Commit() > 0;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    
                }
                catch (Exception e)
                {

                }

                //return Json(new { Success = result, VendorContact = contact });
                return Json(new { Sucess = result });
            }
        }

        [HttpPost]
        public JsonResult DeleteVendorAll(Guid vendorID)
        {
            var result = false;
            using (Uow)
            {
                IEnumerable<Vendor> vendors = Uow.Vendors.Get(includeProperties: "VendorRemitToes, VendorInsurances, VendorContacts, VendorShipToes, VendorTerminations").Where(v=> v.VendorID == vendorID).ToList();
                try
                {
                    //vendors.for
                    foreach (var vendor in vendors)
                    {
                        foreach (var remitToes in vendor.VendorRemitToes.ToList())
                        {
                            if (remitToes.VendorRemitToID != Guid.Empty)
                                Uow.RemitTo.Delete(remitToes);
                        }
                        foreach (var insurance in vendor.VendorInsurances.ToList())
                        {
                            if (insurance.VendorInsuranceID != Guid.Empty)
                                Uow.VendorInsurances.Delete(insurance);
                        }
                        foreach (var contact in vendor.VendorContacts.ToList())
                        {
                            if (contact.VendorContactID != Guid.Empty)
                                Uow.VendorContacts.Delete(contact);
                        }
                        foreach (var shipTo in vendor.VendorShipToes.ToList())
                        {
                            if (shipTo.VendorShipToID != Guid.Empty)
                                Uow.VendorShipTos.Delete(shipTo);
                        }
                        foreach (var termination in vendor.VendorTerminations.ToList())
                        {
                            if (termination.VendorTerminationID != Guid.Empty)
                                Uow.VendorTerminations.Delete(termination);
                        }
                        vendor.VendorRemitToes = null;
                        vendor.VendorInsurances = null;
                        vendor.VendorContacts = null;
                        vendor.VendorShipToes = null;
                        vendor.VendorTerminations = null;
                        //now delete the main Vendor
                        Uow.Vendors.Delete(vendor);

                        try
                        {
                            result = Uow.Commit() > 0;
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                    throw;
                }
            }
            return Json(new { Success = result });
        }



        //[HttpPost]
        //public JsonResult DeleteVendor(Vendor vendor)
        //{
        //    bool result = false;
        //    using (Uow)
        //    {
        //        foreach (var remitToes in vendor.VendorRemitToes)
        //        {
        //            if(remitToes.VendorRemitToID != Guid.Empty)
        //                Uow.RemitTo.Delete(remitToes);
        //        }
        //        foreach (var insurance in vendor.VendorInsurances)
        //        {
        //            if(insurance.VendorInsuranceID != Guid.Empty)
        //                Uow.VendorInsurances.Delete(insurance);
        //        }
        //        vendor.VendorRemitToes = null;
        //        vendor.VendorInsurances = null;
        //        //now delete the main Vendor
        //        Uow.Vendors.Delete(vendor);

        //        try
        //        {
        //            result = Uow.Commit() > 0;  
        //        }
        //        catch (Exception ex)
        //        {
                    
        //            throw;
        //        }
        //    }

        //    return Json(new { Success = result });
        //}


        public JsonResult GetReasons()
        {
            TGFContext db = new TGFContext();

            db.Configuration.ProxyCreationEnabled = false;

            var terminationsQuery = db.TerminationReasons.OrderBy(obj => obj.Code);
            var rowCount = terminationsQuery.Count();
            var terminations = terminationsQuery.ToList();

            return Json(new { Data = terminations, VirtualRowCount = rowCount }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDivisions()
        {
            TGFContext db = new TGFContext();

            db.Configuration.ProxyCreationEnabled = false;

            var divisionsQuery = db.Divisions.OrderBy(obj => obj.Code);
            var rowCount = divisionsQuery.Count();
            var divisions = divisionsQuery.ToList();

            return Json(new { Data = divisions, VirtualRowCount = rowCount }, JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult GetInsuranceTypes()
        {
            IEnumerable<VendorInsuranceType> insTypes = Uow.InsuranceTypes.Get();
            return (Json(insTypes.ToList(), JsonRequestBehavior.AllowGet));
        }

    }
}
