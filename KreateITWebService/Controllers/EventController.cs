using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KreateITWebService.Models;
using System.Web;
using KreateITWebService.Attributes;
using System.Web.Http.Cors;

namespace KreateITWebService.Controllers
{
    [RequireHttps]
    [KreateITAuthenticationFilter]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class EventController : ApiController
    {
        // GET api/event
        /// <summary>
        /// Gets a list of events
        /// </summary>
        /// <returns>
        /// List of events in JSON or XML format
        /// </returns>
        public List<EventDisplay> GetEvents()
        {
            return EventDisplay.List();
        }

        // GET api/event/5
        /// <summary>
        /// Gives details of single event
        /// </summary>
        /// <param name="id">
        /// The unique EventID
        /// </param>
        /// <returns>
        /// Event details in JSON or XML format
        /// </returns>
        public EventDisplay Get(int id)
        {
            return EventDisplay.GetDetails(id);
        }

        // POST api/event
        /// <summary>
        /// Creates a new event
        /// </summary>
        /// <param name="Event">
        /// Event data in JSON or XML format
        /// </param>
        /// <returns></returns>
        public HttpResponseMessage PostEvent(EventData Event)
        {
            int ID = Event.Create();
            var response = Request.CreateResponse<EventData>(HttpStatusCode.Created, Event);

            string url = VirtualPathUtility.AppendTrailingSlash(Request.RequestUri.AbsoluteUri) + ID;
            response.Headers.Location = new Uri(url);
            return response;
        }

        // PUT api/event/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/event/5
        //public void Delete(int id)
        //{
        //}
    }
}
