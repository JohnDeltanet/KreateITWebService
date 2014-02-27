using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KreateIT.Business;

namespace KreateITWebService.Models
{
    public class UserData
    {
        /// <summary>
        /// User Title (e.g. Mr, Mrs, Ms, Dr, e.t.c.)
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Users first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Users surname
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Username for user. Must by unique.
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Password for user.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Users EMail.
        /// </summary>
        public string EMail { get; set; }
        /// <summary>
        /// Should user be forced to change password on first login? (true/false)
        /// </summary>
        public bool ChangePassword { get; set; }
        /// <summary>
        /// Standard language-culture name. Supported values are en-GB, fr-FR, pt-BR, ru-RU and zh-CN. Anything else will default to English.
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// Allow access to user creation and management under the 'Management Tools' section of the website? (true/false)
        /// </summary>
        public bool AllowUserCreation { get; set; }
        /// <summary>
        /// Allow access to user enrolments under the 'Management Tools' section of the website? (true/false)
        /// </summary>
        public bool AllowUserEnrolment { get; set; }
        /// <summary>
        /// Allow access to the scheduled reports options under the 'Management Tools' section of the website? (true/false)
        /// </summary>
        public bool AllowScheduledReports { get; set; }
        /// <summary>
        /// ID of region (Company). ID's can be obtained using GET api/region
        /// </summary>
        public int RegionID { get; set; }
        /// <summary>
        /// ID of entity (Department or Location). ID's can be obtained using GET api/entity
        /// </summary>
        public int EntityID { get; set; }


        public int Save()
        {
            UserBLL u = UserBLL.GetDetails(UserName);
            if (u == null)
            {
                u = new UserBLL(Title, FirstName, LastName, UserName, Password, EMail, ChangePassword, Language, AllowUserCreation, AllowUserEnrolment, AllowScheduledReports, RegionID, EntityID);
            }
            else
            {
                u.Title = Title;
                u.FirstName = FirstName;
                u.LastName = LastName;
                u.Password = Password;
                u.EMail = EMail;
                u.PasswordReset = ChangePassword ? "y" : "n";
                u.LanguageCode = Language;
                u.Dashboard = AllowUserCreation || AllowUserEnrolment || AllowScheduledReports;
                u.UserManagementAccess = AllowUserCreation;
                u.UserEnrolmentAccess = AllowUserEnrolment;
                u.ScheduledReportsAccess = AllowScheduledReports;
                u.RegionID = RegionID;
                u.EntityID = EntityID;
            }
            int ID = u.SaveOrUpdate();
            return ID;
        }
    }

    /// <summary>
    /// User output data
    /// </summary>
    public class UserDisplay
    {
        /// <summary>
        /// Unique User ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// User Title (e.g. Mr, Mrs, Ms, Dr, e.t.c.)
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Users first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Users surname
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Username for user. Must by unique.
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Users EMail.
        /// </summary>
        public string EMail { get; set; }
        /// <summary>
        /// Should user be forced to change password on first login? (true/false)
        /// </summary>
        public bool ChangePassword { get; set; }
        /// <summary>
        /// Standard language-culture name. 
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// ID for the users Region (Company)
        /// </summary>
        public int RegionID { get; set; }
        /// <summary>
        /// Name of the users Region (Company)
        /// </summary>
        public string RegionName { get; set; }
        /// <summary>
        /// ID for the users Entity (Department or Location)
        /// </summary>
        public int EntityID { get; set; }
        /// <summary>
        /// Name of the users Entity (Department or Location)
        /// </summary>
        public string EntityName { get; set; }

        public static implicit operator UserDisplay(UserBLL u)
        {
            return new UserDisplay { ID = u.ID, Title = u.Title, FirstName = u.FirstName, LastName = u.LastName, UserName = u.UserName, EMail = u.EMail, ChangePassword = ((u.PasswordReset == "y") ? true : false), Language = u.LanguageCode, RegionID = u.RegionID, RegionName = u.Region.Name, EntityID = u.EntityID, EntityName = u.Entity.Name };
        }

        public static List<UserDisplay> List()
        {
            return UserBLL.List().AsEnumerable().Select(d => (UserDisplay)d).ToList();
        }

        public static UserDisplay GetDetails(int ID)
        {
            return (UserDisplay)UserBLL.GetDetails(ID);
        }

        public static UserDisplay GetDetails(string username)
        {
            return (UserDisplay)UserBLL.GetDetails(username);
        }
    }
}