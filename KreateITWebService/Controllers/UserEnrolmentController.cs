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
using KreateIT.Exceptions;

namespace KreateITWebService.Controllers
{
    [RequireHttps]
    [KreateITAuthenticationFilter]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserEnrolmentController : ApiController
    {
        // GET api/userenrolment
        /// <summary>
        /// List User enrolments
        /// </summary>
        /// <returns>
        /// List of user enrolments in JSON or XML format
        /// </returns>
        public List<UserEnrolmentDisplay> GetUserEnrolments()
        {
            return UserEnrolmentDisplay.List();
        }

        // GET api/userenrolment/5
        /// <summary>
        /// Get details for single user enrolment
        /// </summary>
        /// <param name="id">
        /// Unique user enrolment ID
        /// </param>
        /// <returns>
        /// User enrolment details in JSON or XML format
        /// </returns>
        public UserEnrolmentDisplay GetUserEnrolment(int id)
        {
            return UserEnrolmentDisplay.GetDetails(id);
        }

        // POST api/userenrolment
        //public HttpResponseMessage PostUserEnrolment(UserEnrolmentData userEnrolment)
        //{
        //    int ID = userEnrolment.Save();
        //    var response = Request.CreateResponse<UserEnrolmentData>(HttpStatusCode.Created, userEnrolment);

        //    string url = VirtualPathUtility.AppendTrailingSlash(Request.RequestUri.AbsoluteUri) + ID;
        //    response.Headers.Location = new Uri(url);
        //    return response;
        //}

        /// <summary>
        /// Enrol a user on a course using either an EventID or a course credit key
        /// </summary>
        /// <param name="userEnrolment">
        /// User enrolment details in JSON or XML format
        /// </param>
        /// <returns></returns>
        public HttpResponseMessage PostUserEnrolment(UserEnrolmentData userEnrolment)
        {
            var response = Request.CreateResponse<UserEnrolmentData>(HttpStatusCode.Created, userEnrolment);
            try
            {
                int ID = userEnrolment.Save();
                string url = VirtualPathUtility.AppendTrailingSlash(Request.RequestUri.AbsoluteUri) + ID;
                response.Headers.Location = new Uri(url);
            }
            catch (UserEnrolException ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.ReasonPhrase = ex.Message;
            }
            catch (CourseCreditsException ex)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.ReasonPhrase = ex.Message;
            }
            return response;
        }

        // PUT api/userenrolment/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/userenrolment/5
        //public void Delete(int id)
        //{
        //}
    }
}
