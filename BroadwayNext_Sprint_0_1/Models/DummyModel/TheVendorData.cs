using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BroadwayNext_Sprint_0_1.Models.DummyModel
{
    public static class TheVendorData
    {
        //sample data
        public static List<TheVendor> TheVendorList = CreateSampleVendorListData();

        private static List<TheVendor> CreateSampleVendorListData()
        {
            List<TheVendor> the_Vendors = new List<TheVendor>();

            //Create Dummy Vendors... as many as required...
            for (int i = 0; i < 10; i++)
            {
                string state = (i % 2 == 0) ? "AL" : "CA";
                bool active = (i % 2 == 0) ? true : false;
                var vendor = new TheVendor()
                {
                    VendorNum = i,
                    Company = "Company " + i,
                    Address1 = "Address " + i,
                    City = "City " + i,
                    State = state,
                    Zip = "36608",
                    Phone = "2413563698",
                    Fax = "1234567890",
                    DBA = "The DBA",
                    VendorType = "Type " + i,
                    Terms = "Terms " + i,
                    Emergency = "Emergency " + i,
                    Active = active,
                    W9 = false,
                    InputDate = DateTime.Now.Date,
                    InputBy = "User 1"
                };
                the_Vendors.Add(vendor);
            }
            
            //return mock data
            return the_Vendors;
        }

    }
}