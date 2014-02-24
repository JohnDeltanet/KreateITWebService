using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KreateIT.Business;

namespace KreateITWebService.Models
{
    public class CourseCreditDisplay
    {
        /// <summary>
        /// Unique course credit ID
        /// </summary>
        public int CourseCreditID { get; set; }
        /// <summary>
        /// Reference for the course credit
        /// </summary>
        public string CourseCreditRef { get; set; }
        /// <summary>
        /// Unique key used in either user self enrolment or enrolment using POST api/UserEnrolment
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// The event ID that this course credit relates to.
        /// </summary>
        public int EventID { get; set; }
        /// <summary>
        /// The event name that this course credit relates to.
        /// </summary>
        public string EventName { get; set; }
        /// <summary>
        /// The name of the course that this course credit relates to.
        /// </summary>
        public string CourseName { get; set; }
        /// <summary>
        /// The total number of user enrolments allowed using this course credit
        /// </summary>
        public int TotalCredits { get; set; }
        /// <summary>
        /// The total number of users already enrolled using this course credit
        /// </summary>
        public int UsedCredits { get; set; }

        public static implicit operator CourseCreditDisplay(CourseCreditsBLL cc)
        {
            return new CourseCreditDisplay
            {
                CourseCreditID = cc.ID,
                CourseCreditRef = cc.Reference,
                Key = cc.Key,
                EventID = cc.EventID,
                EventName = cc.Event.Name,
                CourseName = cc.Course.Title,
                TotalCredits = cc.TotalCredits,
                UsedCredits = cc.UsedCredits
            };
        }

        public static List<CourseCreditDisplay> List()
        {
            return CourseCreditsBLL.List().AsEnumerable().Select(cc => (CourseCreditDisplay)cc).ToList();
        }

        public static CourseCreditDisplay GetDetails(int CourseCreditID)
        {
            return (CourseCreditDisplay)CourseCreditsBLL.GetDetails(CourseCreditID);
        }

        public static CourseCreditDisplay GetDetails(string Key)
        {
            return (CourseCreditDisplay)CourseCreditsBLL.GetDetails(Key);
        }
    }

    public class CourseCreditData
    {
        /// <summary>
        /// The event ID that this course credit should be created for
        /// </summary>
        public int EventID { get; set; }
        /// <summary>
        /// The reference for this course credit
        /// </summary>
        public string Reference { get; set; }
        /// <summary>
        /// The number of user enrolments to allow for this course credit
        /// </summary>
        public int TotalCredits { get; set; }

        public int Create()
        {
            return CourseCreditsBLL.Save(EventID, Reference, TotalCredits);
        }
    }
}