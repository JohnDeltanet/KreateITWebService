using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KreateIT.Business;

namespace KreateITWebService.Models
{
    public class CourseDisplay
    {
        /// <summary>
        /// Unique course ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Course title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Course description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Course subject
        /// </summary>
        public string Subject { get; set; }

        public static implicit operator CourseDisplay(CourseBLL c)
        {
            return new CourseDisplay { ID = c.ID, Title = c.Title, Description = c.Description, Subject = c.Subject.Name };
        }

        public static List<CourseDisplay> Search(string SearchString)
        {
            return CourseBLL.Search(SearchString).Select(course => (CourseDisplay)course).ToList<CourseDisplay>();
        }
    }

}