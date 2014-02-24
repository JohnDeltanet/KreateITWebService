using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using KreateIT.Data;

namespace KreateIT.Business
{
    public class EventBLL
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public int CourseID { get; set; }
        public CourseBLL Course
        {
            get { return CourseBLL.GetDetails(CourseID); }
        }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Days { get; set; }
        public int TutorID { get; set; }
        public UserBLL Tutor
        {
            get { return UserBLL.GetDetails(TutorID); }
        }
        public bool inCatalogue { get; set; }
        public bool SelfEnrol { get; set; }
        public bool GroupOnly { get; set; }
        public bool EnrolRequest { get; set; }
        public bool Taster { get; set; }
        public string Key { get; set; }
        public string Workflow { get; set; }
        public string Status { get; set; }
        public bool AutoEnrol { get; set; }
        public bool ReEnrol { get; set; }
        public int ReEnrolPeriod { get; set; }
        public int ReEnrolOriginalEventID { get; set; }
        public int ReEnrolVersionNo { get; set; }
        public bool EnrolmentLocked { get; set; }
        public bool ReEnrolActive { get; set; }

        public static implicit operator EventBLL(DataRow dr)
        {
            return new EventBLL
            {
                ID = dr.Table.Columns.Contains("EV_ID") ? (dr.Field<int?>("EV_ID") ?? 0) : 0,
                Name = dr.Table.Columns.Contains("EV_NAME") ? (dr.Field<string>("EV_NAME") ?? "") : "",
                OriginalName = dr.Table.Columns.Contains("EV_ORIGINAL_NAME") ? (dr.Field<string>("EV_ORIGINAL_NAME") ?? "") : "",
                CourseID = dr.Table.Columns.Contains("EV_CO_ID") ? (dr.Field<int?>("EV_CO_ID") ?? 0) : 0,
                StartDate = dr.Table.Columns.Contains("EV_START_DT") ? (dr.Field<DateTime?>("EV_START_DT") ?? null) : null,
                EndDate = dr.Table.Columns.Contains("EV_END_DT") ? (dr.Field<DateTime?>("EV_END_DT") ?? null) : null,
                Days = dr.Table.Columns.Contains("EV_DAYS") ? (dr.Field<int?>("EV_DAYS") ?? 0) : 0,
                TutorID = dr.Table.Columns.Contains("EV_TUTOR") ? (dr.Field<int?>("EV_TUTOR") ?? 0) : 0,
                inCatalogue = dr.Table.Columns.Contains("EV_CATALOGUE") ? (((dr.Field<string>("EV_CATALOGUE") ?? "n").Trim() == "y") ? true : false) : false,
                SelfEnrol = dr.Table.Columns.Contains("EV_SELF_ENROL") ? (((dr.Field<string>("EV_SELF_ENROL") ?? "n").Trim() == "y") ? true : false) : false,
                GroupOnly = dr.Table.Columns.Contains("EV_GROUP_ONLY") ? (((dr.Field<string>("EV_GROUP_ONLY") ?? "n").Trim() == "y") ? true : false) : false,
                EnrolRequest = dr.Table.Columns.Contains("EV_ENROL_REQUEST") ? (((dr.Field<string>("EV_ENROL_REQUEST") ?? "n").Trim() == "y") ? true : false) : false,
                Taster = dr.Table.Columns.Contains("EV_TASTER") ? (((dr.Field<string>("EV_TASTER") ?? "n").Trim() == "y") ? true : false) : false,
                Key = dr.Table.Columns.Contains("EV_KEY") ? (dr.Field<string>("EV_KEY") ?? "") : "",
                Workflow = dr.Table.Columns.Contains("EV_WORKFLOW") ? (dr.Field<string>("EV_WORKFLOW") ?? "") : "",
                Status = dr.Table.Columns.Contains("EV_STATUS") ? (dr.Field<string>("EV_STATUS") ?? "") : "",
                AutoEnrol = dr.Table.Columns.Contains("EV_AUTO_ENROL") ? (((dr.Field<string>("EV_AUTO_ENROL") ?? "n").Trim() == "y") ? true : false) : false,
                ReEnrol = dr.Table.Columns.Contains("EV_RE_ENROL_TYPE") ? (((dr.Field<string>("EV_RE_ENROL_TYPE") ?? "n").Trim() == "y") ? true : false) : false,
                ReEnrolPeriod = dr.Table.Columns.Contains("EV_RE_ENROL_PERIOD") ? (dr.Field<int?>("EV_RE_ENROL_PERIOD") ?? 0) : 0,
                ReEnrolOriginalEventID = dr.Table.Columns.Contains("EV_RE_ENROL_ORIGINATOR_EV_ID") ? (dr.Field<int?>("EV_RE_ENROL_ORIGINATOR_EV_ID") ?? 0) : 0,
                ReEnrolVersionNo = dr.Table.Columns.Contains("EV_RE_ENROL_VERSION_NO") ? (dr.Field<int?>("EV_RE_ENROL_VERSION_NO") ?? 0) : 0,
                EnrolmentLocked = dr.Table.Columns.Contains("EV_ENROLMENT_LOCKED") ? (((dr.Field<string>("EV_ENROLMENT_LOCKED") ?? "n").Trim() == "y") ? true : false) : false,
                ReEnrolActive = dr.Table.Columns.Contains("EV_RE_ENROL_ACTIVE") ? (((dr.Field<string>("EV_RE_ENROL_ACTIVE") ?? "n").Trim() == "y") ? true : false) : false
            };
        }

        public static List<EventBLL> ListEvents()
        {
            return EventDAL.ListEvents().Tables[0].AsEnumerable().Select(r => (EventBLL)r).ToList();
        }

        public static int Create(string Name, int CourseID, DateTime? StartDate, DateTime? EndDate)
        {
            return EventDAL.Create(Name, CourseID, StartDate, EndDate);
        }

        public static EventBLL GetDetails(int EventID)
        {
            return (EventBLL)(EventDAL.GetDetails(EventID).Tables[0].Rows[0]);
        }

    }
}
