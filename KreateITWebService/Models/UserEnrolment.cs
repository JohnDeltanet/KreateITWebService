using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KreateIT.Business;
using KreateIT.Exceptions;

namespace KreateITWebService.Models
{
    public class UserEnrolmentData
    {
        /// <summary>
        /// The unique username of the user to enrol
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// The unique event ID of the event on which the user should be enrolled (either EventID or Key must have a valid entry, if both are present 'Key' takes precedence)
        /// </summary>
        public int EventID { get; set; }
        /// <summary>
        /// The unique key of the course credit to user for this enrolment (either EventID or Key must have a valid entry, if both are present 'Key' takes precedence)
        /// </summary>
        public string Key { get; set; }

        public int Save()
        {
            int uID = UserBLL.GetIDFromUserName(this.UserName);
            int i = 0;
            if (uID == 0)
            {
                throw new UserEnrolException("Username not found");
            }
            else
            {
                UserEnrolmentBLL u = new UserEnrolmentBLL { UserID = uID, EventID = this.EventID, Key = this.Key };
                i = u.Save();
            }
            return i;
        }
    }

    //public class UserEnrolmentWithKeyData
    //{
    //    public string UserName { get; set; }
        

    //    public int Save()
    //    {
    //        int uID = UserBLL.GetIDFromUserName(this.UserName);
    //        int i = 0;
    //        if (uID == 0)
    //        {
    //            throw new UserEnrolException("Username not found");
    //        }
    //        else
    //        {
    //            UserEnrolmentBLL u = new UserEnrolmentBLL { UserID = uID, Key = this.Key };
    //            i = u.Save();
    //        }
    //        return i;
    //    }
    //}

    public class UserEnrolmentDisplay
    {
        /// <summary>
        /// The unique ID for this enrolment
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// The unique username of the user that has been enrolled
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// The unique event ID of the event on which the user has been enrolled
        /// </summary>
        public int EventID { get; set; }
        /// <summary>
        /// The event name on which the user has been enrolled
        /// </summary>
        public string EventName { get; set; }
        /// <summary>
        /// The name of the course on which the user has been enrolled
        /// </summary>
        public string CourseName { get; set; }

        public static implicit operator UserEnrolmentDisplay(UserEnrolmentBLL userEnrol)
        {
            return new UserEnrolmentDisplay { ID = userEnrol.ID, UserName = userEnrol.user.UserName, EventID = userEnrol.EventID, EventName = userEnrol.Event.Name, CourseName = userEnrol.course.Title };
        }

        public static UserEnrolmentDisplay GetDetails(int EnrolmentID)
        {
            return (UserEnrolmentDisplay)UserEnrolmentBLL.GetDetails(EnrolmentID);
        }

        public static List<UserEnrolmentDisplay> List()
        {
            return UserEnrolmentBLL.List().AsEnumerable().Select(r => (UserEnrolmentDisplay)r).ToList();
        }
    }
}