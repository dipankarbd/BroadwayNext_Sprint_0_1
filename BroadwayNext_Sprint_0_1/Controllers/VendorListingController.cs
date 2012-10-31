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
        private UnitOfWork UoW;

        public VendorListingController()
        {
            this.UoW = new UnitOfWork();
        }


        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetVendorContacts(Guid vendorID, int pageSize, int currentPage)
        {
            int totalRowCount;
            using (UoW)
            {
                var contacts = UoW.VendorContacts.Get(out totalRowCount, filter: c => c.VendorID == vendorID);
                return Json(new { Data = contacts, VirtualRowCount = totalRowCount }, JsonRequestBehavior.AllowGet);
            }
        }


        //public JsonResult GetVendorContacts1(Guid vendorId, int pageSize, int currentPage)
        //{
        //    TGFContext db = new TGFContext();

        //    db.Configuration.ProxyCreationEnabled = false;

        //    var contactsQuery = db.VendorContacts.Include("Vendor").Where(c => c.VendorID == vendorId);
        //    var rowCount = contactsQuery.Count();
        //    var contacts = contactsQuery.OrderBy(c => c.Firstname).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

        //    contacts.ForEach(c =>
        //    {
        //        c.Vendnum = c.Vendor.Vendnum;
        //    });
        //    return Json(new { Data = contacts, VirtualRowCount = rowCount }, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult SaveVendorContact(VendorContact contact)
        {
            contact.InputDate = DateTime.Now;
            contact.LastModifiedDate = DateTime.Now;
            var result = false;
            if (ModelState.IsValid)
            {
                using (this.UoW)
                {
                    if (contact.VendorContactID == Guid.Empty)
                    {
                        contact.VendorContactID = Guid.NewGuid();
                        this.UoW.VendorContacts.Insert(contact);
                        result = this.UoW.Commit() > 0;
                    }
                    else
                    {
                        this.UoW.VendorContacts.Update(contact);
                        result = this.UoW.Commit() > 0;
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
            using (this.UoW)
            {
                this.UoW.VendorContacts.Delete(contact);
                result = this.UoW.Commit() > 0;
            }
            return Json(new { Success = result });
        }


        public JsonResult GetVendorShipTos(Guid vendorID, int pageSize, int currentPage)
        {
            int totalRowCount;
            using (UoW)
            {
                var shipToes = UoW.VendorShipTos.Get(out totalRowCount, filter: c => c.VendorID == vendorID);
                return Json(new { Data = shipToes, VirtualRowCount = totalRowCount }, JsonRequestBehavior.AllowGet);
            }
        }

        //public JsonResult GetVendorShipTos1(Guid vendorId, int pageSize, int currentPage)
        //{
        //    TGFContext db = new TGFContext();

        //    db.Configuration.ProxyCreationEnabled = false;

        //    var shiptosQuery = db.VendorShipToes.Where(c => c.VendorID == vendorId);
        //    var rowCount = shiptosQuery.Count();
        //    var shiptos = shiptosQuery.OrderBy(s => s.Recipient).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

        //    return Json(new { Data = shiptos, VirtualRowCount = rowCount }, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult SaveVendorShipTo(VendorShipTo shipto)
        {
            shipto.InputDate = DateTime.Now;
            shipto.LastModifiedDate = DateTime.Now;
            var result = false;
            //if (ModelState.IsValid)
            //{
            using (this.UoW)
            {
                if (shipto.VendorShipToID == Guid.Empty)
                {
                    shipto.VendorShipToID = Guid.NewGuid();
                    this.UoW.VendorShipTos.Insert(shipto);
                    result = this.UoW.Commit() > 0;
                }
                else
                {
                    this.UoW.VendorShipTos.Update(shipto);
                    result = this.UoW.Commit() > 0;
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
            using (this.UoW)
            {
                this.UoW.VendorShipTos.Delete(shipto);
                result = this.UoW.Commit() > 0;
            }
            return Json(new { Success = result });
        }

        public JsonResult GetVendorTerminations(Guid vendorID, int pageSize, int currentPage)
        {
            int totalRowCount;
            using (UoW)
            {
                var terminations = UoW.VendorTerminations.Get(out totalRowCount,
                                                            includeProperties: "Division1, TerminationReason1",
                                                            filter: c => c.VendorID == vendorID);
                return Json(new { Data = terminations, VirtualRowCount = totalRowCount }, JsonRequestBehavior.AllowGet);
            }
        }

        //public JsonResult GetVendorTerminations1(Guid vendorId, int pageSize, int currentPage)
        //{
        //    TGFContext db = new TGFContext();

        //    db.Configuration.ProxyCreationEnabled = false;

        //    var terminationsQuery = db.VendorTerminations.Include("Division1").Include("TerminationReason1").Where(c => c.VendorID == vendorId);
        //    var rowCount = terminationsQuery.Count();
        //    var terminations = terminationsQuery.OrderByDescending(s => s.TerminationDate).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

        //    return Json(new { Data = terminations, VirtualRowCount = rowCount }, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult SaveVendorTermination(VendorTermination termination)
        {
            var result = false;
            if (ModelState.IsValid)
            {
                using (this.UoW)
                {
                    if (termination.VendorTerminationID == Guid.Empty)
                    {
                        termination.InputDate = DateTime.Now;
                        termination.LastModifiedDate = DateTime.Now;
                        termination.VendorTerminationID = Guid.NewGuid();
                        this.UoW.VendorTerminations.Insert(termination);
                        result = this.UoW.Commit() > 0;
                    }
                    else
                    {
                        TGFContext db = new TGFContext();
                        termination.LastModifiedDate = DateTime.Now;
                        this.UoW.VendorTerminations.Update(termination);
                        result = this.UoW.Commit() > 0;
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
            using (this.UoW)
            {
                this.UoW.VendorTerminations.Delete(termination);
                result = this.UoW.Commit() > 0;
            }
            return Json(new { Success = result });
        }
        //=================     /     ================================================ 

        public JsonResult GetAllVendors(int pageSize, int currentPage, string searchStr)
        {
            int totalRowCount;
            Expression<Func<Vendor, bool>> searchFilter = null;

            if(!string.IsNullOrEmpty(searchStr)){
                int vendorNum; bool result;
                result = Int32.TryParse(searchStr, out vendorNum);
                if(result == true){
                    searchFilter = (v => (v.Vendnum == vendorNum) || 
                                    (v.Company.ToLower().Contains(searchStr.ToLower())) || 
                                    (v.Phone.Contains(searchStr) || 
                                    (v.DBA.ToLower().Contains(searchStr.ToLower()) ) ) );
                }
                else
	            {
                    searchFilter = (v => (v.Company.ToLower().Contains(searchStr.ToLower())) ||
                                         (v.Phone.Contains(searchStr) ||
                                        (v.DBA.ToLower().Contains(searchStr.ToLower()))));
	            }
            }

            using (UoW)
            {
                //Get the Insurance Types explicity loaded
                var insTypes = UoW.InsuranceTypes.Get();
                //Now get the Vendors
                var vendors = UoW.Vendors.Get(out totalRowCount,
                    filter: searchFilter,
                    orderBy: c => c.OrderBy(v => v.Vendnum),
                    includeProperties: "VendorInsurances, VendorRemitToes",
                    pageSize: pageSize,
                    currentPage: currentPage);

                return Json(new { Data = vendors, InsuranceTypes = insTypes, VirtualRowCount = totalRowCount }, JsonRequestBehavior.AllowGet);
            }
        }



        //public JsonResult GetAllVendors1(int pageSize, int currentPage, int? vendorNum, string companyName = null)
        //{
        //    TGFContext db = new TGFContext();
        //    db.Configuration.ProxyCreationEnabled = false;
        //    db.VendorInsuranceTypes.Load();
        //    //var vendors, rowCount;
        //    Expression<Func<Vendor, bool>> filterVendorNum = null;
        //    if (vendorNum.HasValue)
        //    {
        //        filterVendorNum = (v => v.Vendnum == vendorNum);   //1578511699
        //    }
        //    Expression<Func<Vendor, bool>> filterName = null;
        //    if (!string.IsNullOrEmpty(companyName))
        //    {
        //        filterName = (v => v.Company.Equals(companyName, StringComparison.CurrentCultureIgnoreCase));
        //    }
        //    try
        //    {
        //        IQueryable<Vendor> vendors = db.Vendors; ;
        //        if (filterVendorNum != null)
        //        {
        //            vendors = vendors.Where(filterVendorNum);
        //        }
        //        if (filterName != null)
        //        {
        //            vendors = vendors.Where(filterName);
        //        }
        //        int rowCount = vendors.Count();
        //        var vendorList= vendors.Include("VendorInsurances").Include("VendorRemitToes").OrderBy(v => v.Vendnum).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        //        return Json(new { Data = vendorList, InsuranceTypes = db.VendorInsuranceTypes.ToList(), VirtualRowCount = rowCount }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }


        //}


        [HttpPost]
        public ActionResult Save(Vendor vendor)
        {

            DateTime InputDate = DateTime.Now;
            DateTime LastModifiedDate = DateTime.Now;

            var result = false;

            using (UoW)
            {

                string error = "";

                if (vendor.VendorID == Guid.Empty)  //This is New
                {
                    vendor.VendorID = Guid.NewGuid();
                    vendor.InputDate = InputDate;
                    vendor.LastModifiedDate = LastModifiedDate;
                    //
                    UoW.Vendors.Insert(vendor);

                    foreach (var remitToes in vendor.VendorRemitToes)
                    {
                        if (remitToes.VendorID == Guid.Empty)
                        {
                            remitToes.VendorID = vendor.VendorID;
                            remitToes.VendorRemitToID = Guid.NewGuid();
                            remitToes.InputDate = InputDate;
                            remitToes.LastModifiedDate = LastModifiedDate;
                            UoW.RemitTo.Insert(remitToes);
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
                            UoW.VendorInsurances.Insert(insurance);
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
                            UoW.RemitTo.Insert(remitToes);
                        }
                        else
                        {
                            remitToes.LastModifiedDate = LastModifiedDate;
                            UoW.RemitTo.Update(remitToes);
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
                            UoW.VendorInsurances.Insert(insurance);
                        }
                        else
                        {
                            insurance.LastModifiedDate = LastModifiedDate;
                            UoW.VendorInsurances.Update(insurance);
                        }
                    }
                    //
                    vendor.LastModifiedDate = LastModifiedDate;
                    UoW.Vendors.Update(vendor);
                }
                try
                {
                    result = UoW.Commit() > 0;
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
            using (UoW)
            {
                IEnumerable<Vendor> vendors = UoW.Vendors.Get(includeProperties: "VendorRemitToes, VendorInsurances, VendorContacts, VendorShipToes, VendorTerminations").Where(v=> v.VendorID == vendorID).ToList();
                try
                {
                    //vendors.for
                    foreach (var vendor in vendors)
                    {
                        foreach (var remitToes in vendor.VendorRemitToes.ToList())
                        {
                            if (remitToes.VendorRemitToID != Guid.Empty)
                                UoW.RemitTo.Delete(remitToes);
                        }
                        foreach (var insurance in vendor.VendorInsurances.ToList())
                        {
                            if (insurance.VendorInsuranceID != Guid.Empty)
                                UoW.VendorInsurances.Delete(insurance);
                        }
                        foreach (var contact in vendor.VendorContacts.ToList())
                        {
                            if (contact.VendorContactID != Guid.Empty)
                                UoW.VendorContacts.Delete(contact);
                        }
                        foreach (var shipTo in vendor.VendorShipToes.ToList())
                        {
                            if (shipTo.VendorShipToID != Guid.Empty)
                                UoW.VendorShipTos.Delete(shipTo);
                        }
                        foreach (var termination in vendor.VendorTerminations.ToList())
                        {
                            if (termination.VendorTerminationID != Guid.Empty)
                                UoW.VendorTerminations.Delete(termination);
                        }
                        vendor.VendorRemitToes = null;
                        vendor.VendorInsurances = null;
                        vendor.VendorContacts = null;
                        vendor.VendorShipToes = null;
                        vendor.VendorTerminations = null;
                        //now delete the main Vendor
                        UoW.Vendors.Delete(vendor);

                        try
                        {
                            result = UoW.Commit() > 0;
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




        //public JsonResult GetReasons1()
        //{
        //    TGFContext db = new TGFContext();

        //    db.Configuration.ProxyCreationEnabled = false;

        //    var terminationsQuery = db.TerminationReasons.OrderBy(obj => obj.Code);
        //    var rowCount = terminationsQuery.Count();
        //    var terminations = terminationsQuery.ToList();

        //    return Json(new { Data = terminations, VirtualRowCount = rowCount }, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult GetDivisions1()
        //{
        //    TGFContext db = new TGFContext();

        //    db.Configuration.ProxyCreationEnabled = false;

        //    var divisionsQuery = db.Divisions.OrderBy(obj => obj.Code);
        //    var rowCount = divisionsQuery.Count();
        //    var divisions = divisionsQuery.ToList();

        //    return Json(new { Data = divisions, VirtualRowCount = rowCount }, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult GetReasons()
        {
            int totalRowCount;
            using (UoW)
            {
                var terminationReasons = UoW.TerminationReasons.Get(out totalRowCount, orderBy: c => c.OrderBy(tr => tr.Code));
                return Json(new { Data = terminationReasons, VirtualRowCount = totalRowCount }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetDivisions()
        {
            int totalRowCount;
            using (UoW)
            {
                var divisions = UoW.Divisions.Get(out totalRowCount, orderBy: c => c.OrderBy(d => d.Code));
                return Json(new { Data = divisions, VirtualRowCount = totalRowCount }, JsonRequestBehavior.AllowGet);
            }
        }
        
        public JsonResult GetInsuranceTypes()
        {
            using (UoW)
            {
                var insTypes = UoW.InsuranceTypes.Get();
                return (Json(insTypes.ToList(), JsonRequestBehavior.AllowGet));
            }
        }

    }
}
