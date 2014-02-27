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
    public class EntityController : ApiController
    {
        // GET api/entity
        /// <summary>
        /// Get a list of entities
        /// </summary>
        /// <returns>List of entities in JSON or XML format</returns>
        public List<EntityDisplay> Get()
        {
            return EntityDisplay.List();
        }

        // GET api/entity/5
        /// <summary>
        /// Shows details of a single entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Entity details in JSON or XML format</returns>
        public EntityDisplay Get(int id)
        {
            return EntityDisplay.GetDetails(id);
        }

        // POST api/entity
        /// <summary>
        /// Creates a new entity
        /// </summary>
        /// <param name="Entity">Entity data in JSON or XML format</param>
        /// <returns></returns>
        public HttpResponseMessage PostEvent(EntityData Entity)
        {
            int ID = Entity.Create();
            var response = Request.CreateResponse<EntityData>(HttpStatusCode.Created, Entity);

            string url = VirtualPathUtility.AppendTrailingSlash(Request.RequestUri.AbsoluteUri) + ID;
            response.Headers.Location = new Uri(url);
            return response;
        }

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}