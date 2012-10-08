using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BroadwayNext_Sprint_0_1.Models.DummyModel;

namespace BroadwayNext_Sprint_0_1.Controllers
{
    public class VendorListController : ApiController
    {
        // GET api/vendorlist
        public IEnumerable<TheVendor> Get()
        {
            var theVendors = TheVendorData.TheVendorList.OrderBy(v => v.VendorNum);
            return theVendors;
        }

        // GET api/vendorlist/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/vendorlist
        public void Post([FromBody]string value)
        {
        }

        // PUT api/vendorlist/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/vendorlist/5
        public void Delete(int id)
        {
        }
    }
}
