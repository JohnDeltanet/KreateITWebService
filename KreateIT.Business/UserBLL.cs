using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using KreateIT.Data;
using System.Security.Cryptography;

namespace KreateIT.Business
{
    public class UserBLL
    {
        #region Properties

        public int ID {get; set;}
        public string Title { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Password
        {
            set
            {
                Salt = Guid.NewGuid();
                PasswordHash = Security.GetHash(value, Salt);
            }
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DistinguishingName { get; set; }
        public string EMail { get; set; }
        public string Moderator { get; set; }
        public bool isTutor { get; set; }
        public bool isAdmin { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastAccessDate { get; set; }
        public bool AudioOn { get; set; }
        public string Key { get; set; }
        public string Status { get; set; }
        public string ModType { get; set; }
        public int DiscAccess { get; set; }
        public string UserFieldString1 { get; set; }
        public string UserFieldString2 { get; set; }
        public string UserFieldString3 { get; set; }
        public string UserFieldString4 { get; set; }
        public string UserFieldString5 { get; set; }
        public DateTime? UserFieldDate1 { get; set; }
        public DateTime? UserFieldDate2 { get; set; }
        public DateTime? UserFieldDate3 { get; set; }
        public int UserFieldList1 { get; set; }
        public int UserFieldList2 { get; set; }
        public int UserFieldList3 { get; set; }
        public string PasswordReset { get; set; }
        public DateTime? PasswordResetDate { get; set; }
        public int FailedLogins { get; set; }
        public string NONCE { get; set; }
        public bool isPasswordHashed { get; set; }
        public string TempPassword { get; set; }
        public Guid Salt { get; set; }
        public string LDAP_UniqueID { get; set; }
        public string LDAP_GUID { get; set; }
        public string Domain { get; set; }
        public string DomainUsername { get; set; }
        public bool isActiveDirectoryUser { get; set; }
        public string LanguageCode { get; set; }
        public string NetBIOSAccount { get; set; }
        public int GiftRegisterPermissionLevel { get; set; }
        public int GiftRegisterRegionID { get; set; }
        public int GiftRegisterEntityID { get; set; }
        public Guid UserGUID { get; set; }
        public bool Dashboard { get; set; }
        public DateTime? LeavingDate { get; set; }
        public DateTime? RemovalDate { get; set; }
        public int RemovalUserID { get; set; }
        public DateTime? StartDate { get; set; }
        public bool UserManagementAccess { get; set; }
        public bool UserEnrolmentAccess { get; set; }
        public bool ScheduledReportsAccess { get; set; }
        public bool ThirdPartyDatabaseUser { get; set; }
        public static int AdminID = 0;

        #endregion Properties

        public static implicit operator UserBLL(DataRow dr)
        {
            return new UserBLL
            {
                ID = dr.Table.Columns.Contains("U_ID") ? (dr.Field<int?>("U_ID") ?? 0) : 0,
                Title = dr.Table.Columns.Contains("U_TITLE") ? (dr.Field<string>("U_TITLE") ?? "") : "",
                UserName = dr.Table.Columns.Contains("U_USERNAME") ? (dr.Field<string>("U_USERNAME") ?? "") : "",
                PasswordHash = dr.Table.Columns.Contains("U_PASSWORD") ? (dr.Field<string>("U_PASSWORD") ?? "") : "",
                FirstName = dr.Table.Columns.Contains("U_NAME_FIRST") ? (dr.Field<string>("U_NAME_FIRST") ?? "") : "",
                LastName = dr.Table.Columns.Contains("U_NAME_LAST") ? (dr.Field<string>("U_NAME_LAST") ?? "") : "",
                DistinguishingName = dr.Table.Columns.Contains("U_DN") ? (dr.Field<string>("U_DN") ?? "") : "",
                EMail = dr.Table.Columns.Contains("U_EMAIL") ? (dr.Field<string>("U_EMAIL") ?? "") : "",
                Moderator = dr.Table.Columns.Contains("U_MODERATOR") ? (dr.Field<string>("U_MODERATOR") ?? "") : "",
                isTutor = dr.Table.Columns.Contains("U_TUTOR") ? (((dr.Field<string>("U_TUTOR") ?? "n").Trim() == "y") ? true : false) : false,
                isAdmin = dr.Table.Columns.Contains("U_ADMIN") ? (((dr.Field<string>("U_ADMIN") ?? "n").Trim() == "y") ? true : false) : false,
                CreateDate = dr.Table.Columns.Contains("U_CREATE_DT") ? (dr.Field<DateTime?>("U_CREATE_DT") ?? null) : null,
                LastAccessDate = dr.Table.Columns.Contains("U_LACCESS_DT") ? (dr.Field<DateTime?>("U_LACCESS_DT") ?? null) : null,
                AudioOn = dr.Table.Columns.Contains("U_AUDIO_PREF") ? (((dr.Field<int?>("U_AUDIO_PREF") ?? 1) == 1) ? true : false) : false,
                Key = dr.Table.Columns.Contains("U_KEY") ? (dr.Field<string>("U_KEY") ?? "") : "",
                Status = dr.Table.Columns.Contains("U_STATUS") ? (dr.Field<string>("U_STATUS") ?? "") : "",
                ModType = dr.Table.Columns.Contains("U_MOD_TYPE") ? (dr.Field<string>("U_MOD_TYPE") ?? "") : "",
                DiscAccess = dr.Table.Columns.Contains("U_DISC_ACCESS") ? (dr.Field<int?>("U_DISC_ACCESS") ?? 0) : 0,
                UserFieldString1 = dr.Table.Columns.Contains("U_FIELD_STR_1") ? (dr.Field<string>("U_FIELD_STR_1") ?? "") : "",
                UserFieldString2 = dr.Table.Columns.Contains("U_FIELD_STR_2") ? (dr.Field<string>("U_FIELD_STR_2") ?? "") : "",
                UserFieldString3 = dr.Table.Columns.Contains("U_FIELD_STR_3") ? (dr.Field<string>("U_FIELD_STR_3") ?? "") : "",
                UserFieldString4 = dr.Table.Columns.Contains("U_FIELD_STR_4") ? (dr.Field<string>("U_FIELD_STR_4") ?? "") : "",
                UserFieldString5 = dr.Table.Columns.Contains("U_FIELD_STR_5") ? (dr.Field<string>("U_FIELD_STR_5") ?? "") : "",
                UserFieldDate1 = dr.Table.Columns.Contains("U_FIELD_DT_1") ? (dr.Field<DateTime?>("U_FIELD_DT_1") ?? null) : null,
                UserFieldDate2 = dr.Table.Columns.Contains("U_FIELD_DT_2") ? (dr.Field<DateTime?>("U_FIELD_DT_2") ?? null) : null,
                UserFieldDate3 = dr.Table.Columns.Contains("U_FIELD_DT_3") ? (dr.Field<DateTime?>("U_FIELD_DT_3") ?? null) : null,
                UserFieldList1 = dr.Table.Columns.Contains("U_FIELD_LIST_1") ? (dr.Field<int?>("U_FIELD_LIST_1") ?? 0) : 0,
                UserFieldList2 = dr.Table.Columns.Contains("U_FIELD_LIST_2") ? (dr.Field<int?>("U_FIELD_LIST_2") ?? 0) : 0,
                UserFieldList3 = dr.Table.Columns.Contains("U_FIELD_LIST_3") ? (dr.Field<int?>("U_FIELD_LIST_3") ?? 0) : 0,
                PasswordReset = dr.Table.Columns.Contains("U_PASSWORD_RESET") ? (dr.Field<string>("U_PASSWORD_RESET") ?? "") : "",
                PasswordResetDate = dr.Table.Columns.Contains("U_PASS_RESET_TIME") ? (dr.Field<DateTime?>("U_PASS_RESET_TIME") ?? null) : null,
                FailedLogins = dr.Table.Columns.Contains("U_FAILEDLOGINS") ? (dr.Field<int?>("U_FAILEDLOGINS") ?? 0) : 0,
                NONCE = dr.Table.Columns.Contains("U_NONCE") ? (dr.Field<string>("U_NONCE") ?? "") : "",
                isPasswordHashed = dr.Table.Columns.Contains("U_PASS_HASHED") ? (((dr.Field<int?>("U_PASS_HASHED") ?? 1) == 1) ? true : false) : false,
                TempPassword = dr.Table.Columns.Contains("U_P_TEMP") ? (dr.Field<string>("U_P_TEMP") ?? "") : "",
                Salt = dr.Table.Columns.Contains("U_SALT") ? (dr.Field<Guid?>("U_SALT") ?? Guid.Empty) : Guid.Empty,
                LDAP_UniqueID = dr.Table.Columns.Contains("U_LDAP_UNIQUEID") ? (dr.Field<string>("U_LDAP_UNIQUEID") ?? "") : "",
                LDAP_GUID = dr.Table.Columns.Contains("U_LDAP_GUID") ? (dr.Field<string>("U_LDAP_GUID") ?? "") : "",
                Domain = dr.Table.Columns.Contains("U_DOMAIN") ? (dr.Field<string>("U_DOMAIN") ?? "") : "",
                DomainUsername = dr.Table.Columns.Contains("U_DOMAIN_UNAME") ? (dr.Field<string>("U_DOMAIN_UNAME") ?? "") : "",
                isActiveDirectoryUser = dr.Table.Columns.Contains("U_AD_USER") ? ((dr.Field<int?>("U_AD_USER") ?? 0) == 1 ? true : false) : false,
                LanguageCode = dr.Table.Columns.Contains("U_LANG_CODE") ? (dr.Field<string>("U_LANG_CODE") ?? "") : "",
                NetBIOSAccount = dr.Table.Columns.Contains("U_NETBIOS_ACCOUNT") ? (dr.Field<string>("U_NETBIOS_ACCOUNT") ?? "") : "",
                GiftRegisterPermissionLevel = dr.Table.Columns.Contains("U_GRPL_ACCESS_ID") ? (dr.Field<int?>("U_GRPL_ACCESS_ID") ?? 0) : 0,
                GiftRegisterRegionID = dr.Table.Columns.Contains("U_GRR_ID") ? (dr.Field<int?>("U_GRR_ID") ?? 0) : 0,
                GiftRegisterEntityID = dr.Table.Columns.Contains("U_GRE_ID") ? (dr.Field<int?>("U_GRE_ID") ?? 0) : 0,
                UserGUID = dr.Table.Columns.Contains("U_GUID") ? (dr.Field<Guid?>("U_GUID") ?? Guid.Empty) : Guid.Empty,
                Dashboard = dr.Table.Columns.Contains("U_DASHBOARD") ? (((dr.Field<string>("U_DASHBOARD") ?? "n").Trim() == "y") ? true : false) : false,
                LeavingDate = dr.Table.Columns.Contains("U_LEAVE_DT") ? (dr.Field<DateTime?>("U_LEAVE_DT") ?? null) : null,
                RemovalDate = dr.Table.Columns.Contains("U_REMOVE_DT") ? (dr.Field<DateTime?>("U_REMOVE_DT") ?? null) : null,
                RemovalUserID = dr.Table.Columns.Contains("U_REMOVE_U_ID") ? (dr.Field<int?>("U_REMOVE_U_ID") ?? 0) : 0,
                StartDate = dr.Table.Columns.Contains("U_START_DT") ? (dr.Field<DateTime?>("U_START_DT") ?? null) : null,
                UserManagementAccess = dr.Table.Columns.Contains("U_MT_USERS") ? (((dr.Field<string>("U_MT_USERS") ?? "n").Trim() == "y") ? true : false) : false,
                UserEnrolmentAccess = dr.Table.Columns.Contains("U_MT_ENROLMENTS") ? (((dr.Field<string>("U_MT_ENROLMENTS") ?? "n").Trim() == "y") ? true : false) : false,
                ScheduledReportsAccess = dr.Table.Columns.Contains("U_MT_SCHEDULED_REPORTS") ? (((dr.Field<string>("U_MT_SCHEDULED_REPORTS") ?? "n").Trim() == "y") ? true : false) : false,
                ThirdPartyDatabaseUser = dr.Table.Columns.Contains("U_TPD_USER") ? (((dr.Field<string>("U_TPD_USER") ?? "n").Trim() == "y") ? true : false) : false,
            };
        }

        public UserBLL()
        {
            this.DistinguishingName = "N/A";
            this.isTutor = false;
            this.isAdmin = false;
            this.CreateDate = DateTime.Now;
            this.AudioOn = true;
            this.Key = DateTime.Now.ToString("MdHms") + (new Random()).Next(1, 10000).ToString();
            this.ModType = "x";
            this.Status = "v";
            this.isPasswordHashed = true;
            this.GiftRegisterPermissionLevel = 1;
            this.Dashboard = false;
            this.UserManagementAccess = false;
            this.UserEnrolmentAccess = false;
            this.ScheduledReportsAccess = false;
            this.ThirdPartyDatabaseUser = false;
        }

        public UserBLL(string Title, string FirstName, string LastName, string UserName, string Password, string EMail, bool ChangePassword, string Language, 
                        bool UserManagementAccess, bool UserEnrolmentAccess, bool ScheduledReportsAccess) : this()
        {
            this.Title = Title;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.UserName = UserName;
            this.EMail = EMail;
            this.PasswordReset = ChangePassword ? "y" : "n";
            this.LanguageCode = Language;
            this.Password = Password;
            this.Dashboard = UserManagementAccess || UserEnrolmentAccess || ScheduledReportsAccess;
            this.UserManagementAccess = UserManagementAccess;
            this.UserEnrolmentAccess = UserEnrolmentAccess;
            this.ScheduledReportsAccess = ScheduledReportsAccess;
        }

        public static List<UserBLL> List()
        {
            DataTable dt = UserDAL.List().Tables[0];
            return dt.AsEnumerable().Select(d => (UserBLL)d).ToList();
        }

        public static UserBLL GetDetails(int UserID)
        {
            DataTable dt = UserDAL.GetDetails(UserID).Tables[0];
            UserBLL u;

            if (dt.Rows.Count > 0)
            { u = (UserBLL)(dt.Rows[0]); }
            else
            { u = new UserBLL(); }

            return u;
        }

        public static UserBLL GetDetails(string username)
        {
            UserBLL u;
            DataSet d = UserDAL.GetDetails(username);
            if (d.Tables[0].Rows.Count > 0)
            {
                 u = (UserBLL)(d.Tables[0].Rows[0]);
            }
            else
            {
                u = null;
            }
            return u;
        }

        public static int GetIDFromUserName(string username)
        {
            return UserDAL.GetIDFromUserName(username);
        }

        public int SaveOrUpdate()
        {
            ID = UserDAL.SaveOrUpdate(ID, Title, UserName, PasswordHash, FirstName, LastName, DistinguishingName, EMail, Moderator, isTutor,
                isAdmin, CreateDate, LastAccessDate, AudioOn, Key, Status, ModType, DiscAccess, UserFieldString1, UserFieldString2,
                UserFieldString3, UserFieldString4, UserFieldString5, UserFieldDate1, UserFieldDate2, UserFieldDate3, UserFieldList1, UserFieldList2, UserFieldList3, PasswordReset,
                PasswordResetDate, FailedLogins, NONCE, isPasswordHashed, TempPassword, Salt, LDAP_UniqueID, LDAP_GUID, Domain, DomainUsername,
                isActiveDirectoryUser, LanguageCode, NetBIOSAccount, GiftRegisterPermissionLevel, GiftRegisterRegionID, GiftRegisterEntityID, UserGUID, Dashboard, LeavingDate, RemovalDate,
                RemovalUserID, StartDate, UserManagementAccess, UserEnrolmentAccess, ScheduledReportsAccess, ThirdPartyDatabaseUser);
            return ID;
        }

        public static bool AuthoriseAdminUser(string Username, string Password)
        {
            bool isAuthorised = false;
            UserBLL u = UserBLL.GetDetails(Username);
            if (u == null)
            { isAuthorised = false; }
            else { isAuthorised = (u.isAdmin && u.PasswordHash == Security.GetHash(Password, u.Salt)); }
            if (isAuthorised) { AdminID = u.ID; }
            return isAuthorised;
        }
    }

}
