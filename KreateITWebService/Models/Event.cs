using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KreateIT.Business;

namespace KreateITWebService.Models
{
    public class EventDisplay
    {
        /// <summary>
        /// The unique ID for this event
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// The name of this event
        /// </summary>
        public string EventName { get; set; }
        /// <summary>
        /// The subject of this event
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// The title of the course to which this event relates
        /// </summary>
        public string CourseTitle { get; set; }
        /// <summary>
        /// The description of the course to which this event relates
        /// </summary>
        public string CourseDescription { get; set; }

        public static implicit operator EventDisplay(EventBLL e)
        {
            return new EventDisplay { ID = e.ID, EventName = e.Name, Subject = e.Course.Subject.Name, CourseTitle = e.Course.Title, CourseDescription = e.Course.Description };
        }

        public static List<EventDisplay> List()
        {
            return EventBLL.ListEvents().Select(e => (EventDisplay)e).ToList();
        }

        public static EventDisplay GetDetails(int EventID)
        {
            return (EventDisplay)(EventBLL.GetDetails(EventID));
        }
    }

    public class EventData
    {
        /// <summary>
        /// The name of the event to create
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The unique ID of the course to which this event should relate
        /// </summary>
        public int CourseID { get; set; }
        /// <summary>
        /// The start date of the event (optional)
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// The end date of the event (optional)
        /// </summary>
        public DateTime? EndDate { get; set; }

        public int Create()
        {
            return EventBLL.Create(Name, CourseID, StartDate, EndDate);
        }
    }
}