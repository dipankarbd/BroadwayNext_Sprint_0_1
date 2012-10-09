﻿using BroadwayNext_Sprint_0_1.Models;
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

        //Dipankar's Contoller Methods
        //================================================================================
        public JsonResult GetAllVendors(int pageSize, int currentPage)
        {
            TGFContext db = new TGFContext();

            db.Configuration.ProxyCreationEnabled = false;

            //var vendors, rowCount;
            try
            {

                var vendors = db.Vendors.Include("VendorInsurances").Include("VendorRemitToes").Include("VendorNotes").OrderBy(v => v.Vendnum).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

                int rowCount = db.Vendors.Count();

                return Json(new { Data = vendors, VirtualRowCount = rowCount }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                throw;
            }
            
            
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
            //if (ModelState.IsValid)
            //{
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
            // }
            //else
            //{
            //   return Json(new { Success = result, Message = "Invalid Model" });
            // }
        }

        //=================     /Dipankar      ================================================ 


        public JsonResult GetAllVendorsTEST(int pageSize, int currentPage, int? vendorNum, string companyName = null)
        {
            TGFContext db = new TGFContext();

            db.Configuration.ProxyCreationEnabled = false;

            //var vendors, rowCount;
            Expression<Func<Vendor, bool>> filterVendorNum= null;
            if (vendorNum.HasValue)
            {
                filterVendorNum = (v => v.Vendnum == 1578511699);
            }

            Expression<Func<Vendor, bool>> filterActive = null;
            if (string.IsNullOrEmpty(companyName))
            {
                filterActive = (v => v.Company.Equals(companyName, StringComparison.CurrentCultureIgnoreCase));
            }

            try
            {

                IQueryable<Vendor> vendors = db.Vendors;;
                if (filterVendorNum != null)
                {
                    vendors = vendors.Where(filterVendorNum);
                }

                if (filterActive != null)
                {
                    vendors = vendors.Where(filterActive);
                }
                vendors = vendors.Include("VendorInsurances").Include("VendorRemitToes").Include("VendorNotes").OrderBy(v => v.Vendnum).Skip((currentPage - 1) * pageSize).Take(pageSize);

                int rowCount = vendors.Count();
                return Json(new { Data = vendors.ToList(), VirtualRowCount = rowCount }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {

                throw;
            }


        }


        //public JsonResult GetAllVendors(int pageSize, int currentPage)
        //{
        //    TGFContext db = new TGFContext();

        //    db.Configuration.ProxyCreationEnabled = false;

        //    //var vendors, rowCount;
        //    try
        //    {

        //        var vendors = db.Vendors.Include("VendorInsurances").Include("VendorRemitToes").Include("VendorNotes").OrderBy(v => v.Vendnum).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

        //        int rowCount = db.Vendors.Count();

        //        return Json(new { Data = vendors, VirtualRowCount = rowCount }, JsonRequestBehavior.AllowGet);

        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}



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

            vendor.InputDate = DateTime.Now;
            vendor.LastModifiedDate = DateTime.Now;

            foreach (var remitTo in vendor.VendorRemitToes)
            {
                remitTo.InputDate = DateTime.Now;
                remitTo.LastModifiedDate = DateTime.Now;
            }

            var result = false;

            using (Uow)
            {

                string error = "";
                //if (!ModelState.IsValid)
                //{

                //    // my custom error class
                //    //var error = new ApiMessageError() { message = "Model is invalid" };
                //    foreach (var prop in ModelState.Values)
                //    {
                //        //error = "";
                //        if (prop.Errors.Any())
                //            error = prop.Errors.First().ErrorMessage + " < ## >";
                //        //error.errors.Add(prop.Errors.First().ErrorMessage);
                //    }
                //    string last = error;
                //    // Return the error object as a response with an error code
                //    //return Request.CreateResponse<ApiMessageError>(HttpStatusCode.Conflict, error);
                //}
                //if (ModelState.IsValid)
                //{

                    //foreach (var remitToes in vendor.VendorRemitToes)
                    //    {
                    //        Uow.RemitTo.Update(remitToes);
                    //    }
                    //Uow.Vendors.Update(vendor);
                    //Uow.RemitTo.Update(vendor.VendorRemitToes);

                    if (vendor.VendorID == Guid.Empty)  //This is New
                    {
                        vendor.VendorID = Guid.NewGuid();
                        Uow.Vendors.Insert(vendor);
                        foreach (var remitToes in vendor.VendorRemitToes)
                        {
                            Uow.RemitTo.Insert(remitToes);
                        }
                        result = Uow.Commit() > 0;
                    }
                    else
                    {
                        foreach (var remitToes in vendor.VendorRemitToes)
                        {
                            Uow.RemitTo.Update(remitToes);
                        }
                        Uow.Vendors.Update(vendor);

                        result = Uow.Commit() > 0;
                    }

                    //DbConnection con = Uow.Vendors.context.ObjectContext.Connection;
                    //if (con.State == ConnectionState.Closed)
                    //{
                    //    con.Open();
                    //}
                    //DbTransaction dbTrans = con.BeginTransaction();
                    //try
                    //{
                    //    foreach (var remitToes in vendor.VendorRemitToes)
                    //    {
                    //        Uow.RemitTo.Update(remitToes);
                    //    }
                    //    Uow.Vendors.Update(vendor);
                       
                    //    int i = Uow.Commit();
                    //    dbTrans.Commit();
                    //}
                    //catch (Exception ex)
                    //{
                    //    dbTrans.Rollback();
                    //    throw;
                    //}
                    //finally
                    //{
                    //    if (con.State == ConnectionState.Open)
                    //        con.Close();
                    //}

                    //return RedirectToAction("Index");
                //}

                //return Json(new { Success = result, VendorContact = contact });
                return Json (new { Sucess = result} ); 
            }
        }

    }
}
