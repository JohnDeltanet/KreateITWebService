using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using KreateITWebService.Models;
using KreateITWebService.Attributes;

namespace KreateITWebService.Controllers
{
    [RequireHttps]
    [KreateITAuthenticationFilter]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RegionController : ApiController
    {
        // GET api/region
        /// <summary>
        /// Get a list of regions
        /// </summary>
        /// <returns>List of regions in JSON or XML format</returns>
        public List<RegionDisplay> Get()
        {
            return RegionDisplay.List();
        }

        // GET api/region/5
        /// <summary>
        /// Shows details of a single region
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Region details in JSON or XML format</returns>
        public RegionDisplay Get(int id)
        {
            return RegionDisplay.GetDetails(id);
        }

        // POST api/region
        /// <summary>
        /// Creates a new region
        /// </summary>
        /// <param name="Region">Region data in JSON or XML format</param>
        /// <returns></returns>
        public HttpResponseMessage PostEvent(RegionData Region)
        {
            int ID = Region.Create();
            var response = Request.CreateResponse<RegionData>(HttpStatusCode.Created, Region);

            string url = VirtualPathUtility.AppendTrailingSlash(Request.RequestUri.AbsoluteUri) + ID;
            response.Headers.Location = new Uri(url);
            return response;
        }

        //// PUT api/region/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/region/5
        //public void Delete(int id)
        //{
        //}
    }
}
