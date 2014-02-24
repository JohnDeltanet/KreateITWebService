using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using KreateITWebService.Models;
using System.Web.Http.Cors;
using KreateITWebService.Attributes;

namespace KreateITWebService.Controllers
{
    [RequireHttps]
    [KreateITAuthenticationFilter]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        // GET api/user
        /// <summary>
        /// Gets a list of all current users
        /// </summary>
        /// <returns>
        /// List of users in JSON or XML format.
        /// </returns>
        public List<UserDisplay> GetUsers()
        {
            return UserDisplay.List();
        }

         //GET api/user/5
        /// <summary>
        /// Get Data for a single user by User ID
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>
        /// The user data in JSON or XML format
        /// </returns>
        public UserDisplay GetUser(int id)
        {
            return UserDisplay.GetDetails(id);
        }


        // POST api/user
        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user">
        /// The user data in JSON or XML format
        /// </param>
        /// <returns></returns>
        public HttpResponseMessage PostUser(UserData user)
        {
            int ID = user.Save();
            var response = Request.CreateResponse<UserData>(HttpStatusCode.Created, user);

            string url = VirtualPathUtility.AppendTrailingSlash(Request.RequestUri.AbsoluteUri) + ID;
            response.Headers.Location = new Uri(url);
            return response;
        }

        // PUT api/user/5
        /// <summary>
        /// Updates an existing user
        /// </summary>
        /// <param name="user">
        /// The user data in JSON or XML format
        /// </param>
        public void PutUser(UserData user)
        {
            user.Save();
        }

        //// DELETE api/user/5
        //public void Delete(int id)
        //{
        //}
    }
}
