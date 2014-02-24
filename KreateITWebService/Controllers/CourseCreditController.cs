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
    public class CourseCreditController : ApiController
    {
        // GET api/coursecredit
        /// <summary>
        /// Gets a list of course credits
        /// </summary>
        /// <returns>
        /// List of course credits in JSON or XML format
        /// </returns>
        public List<CourseCreditDisplay> GetCourseCredits()
        {
            return CourseCreditDisplay.List();
        }

        // GET api/coursecredit/5
        /// <summary>
        /// Gets the details for a single course credit
        /// </summary>
        /// <param name="id">
        /// The unique course credit id.
        /// </param>
        /// <returns>
        /// Course credit details in JSON or XML format
        /// </returns>
        public CourseCreditDisplay GetCourseCreditDetails(int id)
        {
            return CourseCreditDisplay.GetDetails(id);
        }

        // POST api/coursecredit
        /// <summary>
        /// Create a new course credit
        /// </summary>
        /// <param name="cc">
        /// Course credit data in JSON or XML format
        /// </param>
        /// <returns></returns>
        public HttpResponseMessage PostCourseCredit(CourseCreditData cc)
        {
            int ID = cc.Create();
            var response = Request.CreateResponse<CourseCreditData>(HttpStatusCode.Created, cc);

            string url = VirtualPathUtility.AppendTrailingSlash(Request.RequestUri.AbsoluteUri) + ID;
            response.Headers.Location = new Uri(url);
            return response;
        }

        //// PUT api/coursecredit/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/coursecredit/5
        //public void Delete(int id)
        //{
        //}
    }
}
