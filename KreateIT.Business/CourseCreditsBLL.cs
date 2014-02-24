using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using KreateIT.Data;

namespace KreateIT.Business
{
    public class CourseCreditsBLL
    {
        #region properties
        public int ID { get; set; }
        public DateTime CreateDate { get; set; }
        public int CreateAdminUserID { get; set; }
        public UserBLL CreateAdminUser 
        { 
            get { return UserBLL.GetDetails(CreateAdminUserID); }
        }
        public DateTime? LastEditDate { get; set; }
        public int LastEditAdminUserID { get; set; }
        public UserBLL LastEditAdminUser 
        { 
            get { return UserBLL.GetDetails(LastEditAdminUserID);}
        }
        public string Key { get; set; }
        public int CourseID { get; set; }
        public CourseBLL Course 
        { 
            get { return CourseBLL.GetDetails(CourseID); }
        }
        public int EventID { get; set; }
        public EventBLL Event 
        { 
            get { return EventBLL.GetDetails(EventID); }
        }
        public string Reference { get; set; }
        public int TotalCredits { get; set; }
        public int UsedCredits { get; set; }
        public string InvoiceNo { get; set; }
        public decimal CostPerCredit { get; set; }
        public decimal CostPerCreditBlock { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }
        #endregion properties

        public static implicit operator CourseCreditsBLL(DataRow dr)
        {
            return new CourseCreditsBLL
            {
                ID = dr.Table.Columns.Contains("CC_ID") ? (dr.Field<int?>("CC_ID") ?? 0) : 0,
                CreateDate = dr.Field<DateTime>("CC_CREATE_DT"),
                CreateAdminUserID = dr.Table.Columns.Contains("CC_CREATE_ADMIN_U_ID") ? (dr.Field<int?>("CC_CREATE_ADMIN_U_ID") ?? 0) : 0,
                LastEditDate = dr.Table.Columns.Contains("CC_LAST_EDIT_DT") ? (dr.Field<DateTime?>("CC_LAST_EDIT_DT") ?? null) : null,
                LastEditAdminUserID = dr.Table.Columns.Contains("CC_LAST_EDIT_ADMIN_U_ID") ? (dr.Field<int?>("CC_LAST_EDIT_ADMIN_U_ID") ?? 0) : 0,
                Key = dr.Table.Columns.Contains("CC_COURSE_CREDIT_KEY") ? (dr.Field<string>("CC_COURSE_CREDIT_KEY") ?? "") : "",
                CourseID = dr.Table.Columns.Contains("CC_CO_ID") ? (dr.Field<int?>("CC_CO_ID") ?? 0) : 0,
                EventID = dr.Table.Columns.Contains("CC_EV_ID") ? (dr.Field<int?>("CC_EV_ID") ?? 0) : 0,
                Reference = dr.Table.Columns.Contains("CC_REF") ? (dr.Field<string>("CC_REF") ?? "") : "",
                TotalCredits = dr.Table.Columns.Contains("CC_TOTAL_CREDITS") ? (dr.Field<int?>("CC_TOTAL_CREDITS") ?? 0) : 0,
                UsedCredits = dr.Table.Columns.Contains("CC_USED_CREDITS") ? (dr.Field<int?>("CC_USED_CREDITS") ?? 0) : 0,
                InvoiceNo = dr.Table.Columns.Contains("CC_INVOICE_NO") ? (dr.Field<string>("CC_INVOICE_NO") ?? "") : "",
                CostPerCredit = dr.Table.Columns.Contains("CC_COST_PER_CREDIT") ? (dr.Field<decimal?>("CC_COST_PER_CREDIT") ?? 0m) : 0m,
                CostPerCreditBlock = dr.Table.Columns.Contains("CC_COST_PER_CREDIT_BLOCK") ? (dr.Field<decimal?>("CC_COST_PER_CREDIT_BLOCK") ?? 0m) : 0m,
                PaymentMethod = dr.Table.Columns.Contains("CC_PAYMENT_METHOD") ? (dr.Field<string>("CC_PAYMENT_METHOD") ?? "") : "",
                Status = dr.Table.Columns.Contains("CC_STATUS") ? (dr.Field<string>("CC_STATUS") ?? "") : ""
            };
        }

        public static CourseCreditsBLL operator ++(CourseCreditsBLL cc)
        {
            cc.UsedCredits++;
            CourseCreditsDAL.IncrementUsedCredits(cc.ID);
            return cc;
        }

        public static List<CourseCreditsBLL> List()
        {
            return CourseCreditsDAL.List().Tables[0].AsEnumerable().Select(dr => (CourseCreditsBLL)dr).ToList();
        }

        public static CourseCreditsBLL GetDetails(int CourseCreditsID)
        {
            DataTable dt = CourseCreditsDAL.GetDetails(CourseCreditsID).Tables[0];
            CourseCreditsBLL cc;
            if (dt.Rows.Count > 0)
            { cc = (CourseCreditsBLL)dt.Rows[0]; }
            else
            { cc = new CourseCreditsBLL(); }
            return cc;
        }

        public static CourseCreditsBLL GetDetails(string Key)
        {
            DataTable dt = CourseCreditsDAL.GetDetails(Key).Tables[0];
            CourseCreditsBLL cc;
            if (dt.Rows.Count > 0)
            { cc = (CourseCreditsBLL)dt.Rows[0]; }
            else
            { cc = new CourseCreditsBLL(); }
            return cc;
        }

        public static int Save(int EventID, string Reference, int TotalCredits)
        {
            string CreditKey = (new Random()).Next(0, 1048575).ToString("X") + DateTime.Now.ToString("MdHms") + (new Random()).Next(1, 10000).ToString();
            return CourseCreditsDAL.Save(EventID, UserBLL.AdminID, CreditKey, Reference, TotalCredits);
        }
    }
}
