using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using KreateIT.Data;
using KreateIT.Exceptions;

namespace KreateIT.Business
{
    public class UserEnrolmentBLL
    {
        #region properties

        public int ID { get; set; }
        public int UserID { get; set; }
        public UserBLL user
        {
            get
            {
                return UserBLL.GetDetails(UserID);
            }
        }
        public int CourseID { get; set; }
        public CourseBLL course
        {
            get
            {
                return CourseBLL.GetDetails(CourseID);
            }
        }
        public int EventID { get; set; }
        public EventBLL Event
        { 
            get
            {
                return EventBLL.GetDetails(EventID);
            }
        }
        public int AdminUserID { get; set; }
        public UserBLL AdminUser
        {
            get
            {
                return UserBLL.GetDetails(AdminUserID);
            }
        }
        public DateTime CreateDate { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Key { get; set; }

        #endregion properties

        public static implicit operator UserEnrolmentBLL(DataRow dr)
        {
            return new UserEnrolmentBLL
            {
                ID = dr.Table.Columns.Contains("UEN_ID") ? (dr.Field<int?>("UEN_ID") ?? 0) : 0,
                UserID = dr.Table.Columns.Contains("UEN_U_ID") ? (dr.Field<int?>("UEN_U_ID") ?? 0) : 0,
                CourseID = dr.Table.Columns.Contains("UEN_CO_ID") ? (dr.Field<int?>("UEN_CO_ID") ?? 0) : 0,
                EventID = dr.Table.Columns.Contains("UEN_EV_ID") ? (dr.Field<int?>("UEN_EV_ID") ?? 0) : 0,
                AdminUserID = dr.Table.Columns.Contains("UEN_ADMIN_U_ID") ? (dr.Field<int?>("UEN_ADMIN_U_ID") ?? 0) : 0,
                CreateDate = dr.Field<DateTime>("UEN_CREATED_DT"), 
                Type = dr.Table.Columns.Contains("UEN_TYPE") ? (dr.Field<string>("UEN_TYPE") ?? "") : "",
                Status = dr.Table.Columns.Contains("UEN_STATUS") ? (dr.Field<string>("UEN_STATUS") ?? "") : ""
            };
        }

        public static UserEnrolmentBLL GetDetails(int UserEnrolmentID)
        {
            DataTable dt = UserEnrolmentDAL.GetDetails(UserEnrolmentID).Tables[0];
            UserEnrolmentBLL u = new UserEnrolmentBLL();
            if (dt.Rows.Count > 0)
            {
                u = (UserEnrolmentBLL)dt.Rows[0];
            }
            return u;
        }

        public static UserEnrolmentBLL GetDetails(int UserID, int EventID)
        {
            DataTable dt = UserEnrolmentDAL.GetDetails(UserID, EventID).Tables[0];
            UserEnrolmentBLL u = new UserEnrolmentBLL();
            if (dt.Rows.Count > 0)
            {
                u = (UserEnrolmentBLL)dt.Rows[0];
            }
            return u;
        }

        public static List<UserEnrolmentBLL> List()
        {
            DataTable dt = UserEnrolmentDAL.List().Tables[0];
            return dt.AsEnumerable().Select(r => (UserEnrolmentBLL)r).ToList();
        }

        public int Save()
        {
            CourseCreditsBLL cc = null;
            if (Key != null)
            {
                cc = CourseCreditsBLL.GetDetails(Key);
                if (cc == null) { throw new CourseCreditsException("Invalid Key."); }
                if (cc.UsedCredits < cc.TotalCredits)
                { EventID = cc.EventID; }
                else
                { throw (new CourseCreditsException("There are no credits left for this key.")); }
            }
            if (EventID > 0)
            {
                if (UserEnrolmentBLL.GetDetails(UserID, EventID).ID == 0)
                {
                    AdminUserID = UserBLL.AdminID;
                    ID = UserEnrolmentDAL.Save(UserID, EventID, AdminUserID, (cc.ID > 0) ? "s" : "a", "v", cc.ID);
                    if (ID > 0 && cc != null) { cc++; }
                }
                else
                { throw new UserEnrolException("This user is already enrolled on this event."); }
            }
            else
            { throw (new UserEnrolException("Must include valid EventID or Credit Key")); }

            return ID;
        }

    }
}
