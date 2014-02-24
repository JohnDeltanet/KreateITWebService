using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using KreateITWebService.Models;
using KreateITWebService.Attributes;

namespace KreateITWebService.Controllers
{
    [RequireHttps]
    [KreateITAuthenticationFilter]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CourseController : ApiController
    {
        /// <summary>
        /// Gets a list of courses
        /// </summary>
        /// <returns>
        /// List of course details in JSON or XML format
        /// </returns>
        public List<CourseDisplay> Get()
        {
            return CourseDisplay.Search("");
        }
    }
}
