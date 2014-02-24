using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using KreateIT.Data;

namespace KreateIT.Business
{
    public class CourseBLL
    {
        #region Properties
        public int ID { get; set; }
        public int SubjectID { get; set; }
        public SubjectBLL Subject
        {
            get { return SubjectBLL.GetDetails(SubjectID); }
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AdminUserID { get; set; }
        public int TutorUserID { get; set; }
        public bool hasCertificate { get; set; }
        public int CertificateID { get; set; }
        public int OwnerID { get; set; }
        public string ControlID { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Workflow { get; set; }
        public string Key { get; set; }
        public string Status { get; set; }
        public bool ShowCohort { get; set; }
        public string Taster_Filename { get; set; }
        public int Taster_Height { get; set; }
        public int Taster_Width { get; set; }
        public string Taster_Status { get; set; }
        public bool TNC { get; set; }
        public bool isLicensed { get; set; }
        public string Image_Filename { get; set; }
        public string Image_Alt { get; set; }
        public int Image_Height { get; set; }
        public int Image_Width { get; set; }
        
        #endregion Properties

        public static implicit operator CourseBLL(DataRow dr)
        {
            return new CourseBLL
            {
                ID = dr.Table.Columns.Contains("CO_ID") ? (dr.Field<int?>("CO_ID") ?? 0) : 0,
                SubjectID = dr.Table.Columns.Contains("CO_CS_ID") ? (dr.Field<int?>("CO_CS_ID") ?? 0) : 0,
                Title = dr.Table.Columns.Contains("CO_TITLE") ? (dr.Field<string>("CO_TITLE") ?? "") : "",
                Description = dr.Table.Columns.Contains("CO_DESC") ? (dr.Field<string>("CO_DESC") ?? "") : "",
                AdminUserID = dr.Table.Columns.Contains("CO_ADMIN_U_ID") ? (dr.Field<int?>("CO_ADMIN_U_ID") ?? 0) : 0,
                TutorUserID = dr.Table.Columns.Contains("CO_TUT_U_ID") ? (dr.Field<int?>("CO_TUT_U_ID") ?? 0) : 0,
                hasCertificate = dr.Table.Columns.Contains("CO_CERT") ? (((dr.Field<string>("CO_CERT") ?? "n").Trim() == "y") ? true : false) : false,
                CertificateID = dr.Table.Columns.Contains("CO_CERT_ID") ? (dr.Field<int?>("CO_CERT_ID") ?? 0) : 0,
                OwnerID = dr.Table.Columns.Contains("CO_OWNER") ? (dr.Field<int?>("CO_OWNER") ?? 0) : 0,
                ControlID = dr.Table.Columns.Contains("CO_CONTROL") ? (dr.Field<string>("CO_CONTROL") ?? "") : "",
                CreateDate = dr.Table.Columns.Contains("CO_DT_CREATED") ? (dr.Field<DateTime?>("CO_DT_CREATED") ?? null) : null,
                Workflow = dr.Table.Columns.Contains("CO_WORKFLOW") ? (dr.Field<string>("CO_WORKFLOW") ?? "") : "",
                Key = dr.Table.Columns.Contains("CO_KEY") ? (dr.Field<string>("CO_KEY") ?? "") : "",
                Status = dr.Table.Columns.Contains("CO_STATUS") ? (dr.Field<string>("CO_STATUS") ?? "") : "",
                ShowCohort = dr.Table.Columns.Contains("CO_SHOW_COHORT") ? (((dr.Field<string>("CO_SHOW_COHORT") ?? "n").Trim() == "y") ? true : false) : false,
                Taster_Filename = dr.Table.Columns.Contains("CO_TASTER_FILENAME") ? (dr.Field<string>("CO_TASTER_FILENAME") ?? "") : "",
                Taster_Height = dr.Table.Columns.Contains("CO_TASTER_HEIGHT") ? (dr.Field<int?>("CO_TASTER_HEIGHT") ?? 0) : 0,
                Taster_Width = dr.Table.Columns.Contains("CO_TASTER_WIDTH") ? (dr.Field<int?>("CO_TASTER_WIDTH") ?? 0) : 0,
                Taster_Status = dr.Table.Columns.Contains("CO_TASTER_STATUS") ? (dr.Field<string>("CO_TASTER_STATUS") ?? "") : "",
                TNC = dr.Table.Columns.Contains("CO_TNC") ? (((dr.Field<string>("CO_TNC") ?? "n").Trim() == "y") ? true : false) : false,
                isLicensed = dr.Table.Columns.Contains("CO_LICENSED") ? (((dr.Field<string>("CO_LICENSED") ?? "n").Trim() == "y") ? true : false) : false,
                Image_Filename = dr.Table.Columns.Contains("CO_IMAGE_FILENAME") ? (dr.Field<string>("CO_IMAGE_FILENAME") ?? "") : "",
                Image_Alt = dr.Table.Columns.Contains("CO_IMAGE_ALT") ? (dr.Field<string>("CO_IMAGE_ALT") ?? "") : "",
                Image_Height = dr.Table.Columns.Contains("CO_IMAGE_HEIGHT") ? (dr.Field<int?>("CO_IMAGE_HEIGHT") ?? 0) : 0,
                Image_Width = dr.Table.Columns.Contains("CO_IMAGE_WIDTH") ? (dr.Field<int?>("CO_IMAGE_WIDTH") ?? 0) : 0
            };
        }

        public static CourseBLL GetDetails(int CourseID)
        {
            return (CourseBLL)(CourseDAL.GetDetails(CourseID).Tables[0].Rows[0]);
        }

        public static List<CourseBLL> Search(string SearchString)
        {
            return CourseDAL.Search(SearchString).Tables[0].AsEnumerable().Select(dr => (CourseBLL)(dr)).ToList<CourseBLL>();
        }
    }

    public class SubjectBLL
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Workflow { get; set; }
        public string Status { get; set; }

        public static implicit operator SubjectBLL(DataRow dr)
        {
            return new SubjectBLL
            {
                ID = dr.Table.Columns.Contains("CS_ID") ? (dr.Field<int?>("CS_ID") ?? 0) : 0,
                Name = dr.Table.Columns.Contains("CS_SUB_NAME") ? (dr.Field<string>("CS_SUB_NAME") ?? "") : "",
                Type = dr.Table.Columns.Contains("CS_TYPE") ? (dr.Field<string>("CS_TYPE") ?? "") : "",
                Workflow = dr.Table.Columns.Contains("CS_WORKFLOW") ? (dr.Field<string>("CS_WORKFLOW") ?? "") : "",
                Status = dr.Table.Columns.Contains("CS_STATUS") ? (dr.Field<string>("CS_STATUS") ?? "") : ""
            };
        }

        public static SubjectBLL GetDetails(int SubjectID)
        {
            DataTable dt = SubjectDAL.GetDetails(SubjectID).Tables[0];
            SubjectBLL s;

            if (dt.Rows.Count > 0)
            { s = (SubjectBLL)dt.Rows[0]; }
            else
            { s = new SubjectBLL { ID = 0, Name = "", Type = "", Workflow = "", Status = "" }; }

            return s;
        }

        public static List<SubjectBLL> List()
        {
            return SubjectDAL.List().Tables[0].AsEnumerable().Select( dr => (SubjectBLL)dr ).ToList();
        }

    }
}